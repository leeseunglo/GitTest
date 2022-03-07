using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using Core;
using Newtonsoft.Json;
using ClientProtocol.Model;
using ClientProtocol.Protocol;
using ClientForm.Config;
using ClientForm.Client;
using ClientForm.Extension;

namespace ClientForm.Scenario
{
	public partial class LimeGameScenarioClient : LimeGameClient
	{
		private ScenarioManager m_scenarioMgr = null;

		public LimeGameScenarioClient(LoginUserInfo userInfo, ScenarioManager scenarioMgr)
			: base(userInfo)
		{
			m_scenarioMgr = scenarioMgr;
		}

		private void AddGameRoom(GameRoomKeyInfo keyInfo)
		{
			if (true == m_gameRoomKeyInfo.Contains(keyInfo))
				return;

			m_gameRoomKeyInfo.Add(keyInfo);
		}

		public string GetNickName() { return UserInfo.NickName; }

		public void RemoveUser()
		{
			var gameUser = m_clientProxy as LimeClientProxyStandalone;
			if (null == gameUser)
				return;

			gameUser.RemoveUser();
		}

		public override void SendMessage(Request req)
		{
			if (null == req)
			{
				Log.ErrorLog("request data null");
				return;
			}

			var reqName = req.GetType().Name;
			string methodName = $"On{reqName}";
			MethodInfo methodInfo = this.GetType().GetMethod(methodName, new Type[] { typeof(Request) });
			if (null != methodInfo)
				methodInfo.Invoke(this, new object[] { req });

			Log.ErrorLog($"Request Data >> {JsonConvert.SerializeObject(req)}");
			m_scenarioMgr.ScenarioPush(GetUserKey(), GetScenarioDetailType(reqName), req);
		}

		public async Task<bool> SendScenarioMessage(ScenarioActionInfo actionInfo, bool isTestMode)
		{
			try
			{
				if (eScenarioDetailType.Login == actionInfo.DetailType)
				{
					MainForm mainForm = new MainForm();
					mainForm.SetLoginUserInfo(UserInfo);
					await mainForm.OnLogin(eClientType.None, isTestMode, this).ConfigureAwait(false);
				}
				else
				{
					SendMessage(actionInfo);
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"SendScenarioMessage. exception Msg:{ex.Message}");
				return false;
			}

			return true;
		}

		public override void OnApplyRecvMessage(string method, string content)
		{
			try
			{
				Type resType = CommandMap.INST.GetResponseType(method);
				if (null == resType)
					throw new Exception($"not found response type. Method:{method}");

				var resData = JsonConvert.DeserializeObject(content, resType);
				if (null == resData)
					throw new Exception($"deserialize object fail. {resType.Name}");

				ResponseLog(resData);
				AddRecvData(resType.Name, resData);
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"OnApplyResponse. exception Msg:{ex.Message}");
			}
		}

		private eScenarioDetailType GetScenarioDetailType(string reqName)
		{
			switch (reqName)
			{
				case "CreateRoomRequest":
					return eScenarioDetailType.CreateRoom;
				case "JoinRoomRequest": 
					return eScenarioDetailType.JoinRoom;
				case "SendMessageRequest": 
					return eScenarioDetailType.SendMessage;
				default:
					Log.ErrorLog($"scenario action not request case. {reqName}");
					return eScenarioDetailType.None;
			}
		}
	}

	#region game room method
	public partial class LimeGameScenarioClient
	{
		private List<GameRoomKeyInfo> m_gameRoomKeyInfo = new List<GameRoomKeyInfo>();

		public string[] GetGameRoomKeyNames()
		{
			return m_gameRoomKeyInfo.Select(x => x.GetInfo()).ToArray();
		}

		public override GameRoomKeyInfo GetGameRoomKeyInfo(string strType)
		{
			GameRoomKeyInfo gameRoomKey = m_gameRoomKeyInfo.Find(x => x.GetInfo().Equals(strType));
			if (null == gameRoomKey)
				return null;

			return gameRoomKey;
		}
	}
	#endregion

	#region meaage method
	public partial class LimeGameScenarioClient
	{
		private RecvMessageCheck makeRecvMessageCheck(string strRoomKey, string strMsg)
		{
			GameRoomKeyInfo gameRoomKey = m_scenarioMgr.GetGameRoomKeyInfo(strRoomKey);
			if (null == gameRoomKey)
				return null;

			return new RecvMessageCheck()
			{
				gameRoomKeyInfo = gameRoomKey,
				content = strMsg
			};
		}

		public override void SendTalk(string strRoomKey, string strMsg)
		{
			GameRoomKeyInfo gameRoomKey = m_scenarioMgr.GetGameRoomKeyInfo(strRoomKey);
			if (null == gameRoomKey)
				return;

			SendMessageRequest req = new SendMessageRequest()
			{
				gameRoomKeyInfo = gameRoomKey,
				gameMessageInfo = new GameMessageInfo()
				{
					userName = UserInfo.NickName,
					type = eMessageType.PUBLISH.ToString(),
					subType = eMessageSubType.WORLD.ToString(),
					content = strMsg
				}
			};

			SendMessage(req);
		}

		public void SendMessage(eScenarioType scenarioType, string roomKey, string strMsg)
		{
			switch (scenarioType)
			{
				case eScenarioType.SendMessage:
					SendTalk(roomKey, strMsg);
					break;

				case eScenarioType.ReceiveMessage:
					m_scenarioMgr.ScenarioPush(GetUserKey(), eScenarioDetailType.ReceiveMessage, makeRecvMessageCheck(roomKey, strMsg));
					break;

				case eScenarioType.NotReceiveMessage:
					m_scenarioMgr.ScenarioPush(GetUserKey(), eScenarioDetailType.NotReceiveMessage, makeRecvMessageCheck(roomKey, strMsg));
					break;
			}
		}
	}
	#endregion

	#region recv message
	public partial class LimeGameScenarioClient
	{
		private Dictionary<string, List<Response>> m_dicRecvData = new Dictionary<string, List<Response>>();

		private void AddRecvData(string resType, object resData)
		{
			List<Response> liData = null;
			if (false == m_dicRecvData.TryGetValue(resType, out liData))
				m_dicRecvData.Add(resType, liData = new List<Response>());

			liData.Add(resData as Response);
		}

		public List<Response> GetRecvData(string resType)
		{
			if (false == m_dicRecvData.ContainsKey(resType))
				return new List<Response>();

			return m_dicRecvData[resType];
		}
	}
	#endregion
}
