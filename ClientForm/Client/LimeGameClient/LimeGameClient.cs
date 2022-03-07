using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Newtonsoft.Json;
using ClientProtocol.Model;
using ClientProtocol.Protocol;
using ClientForm.Common;
using ClientForm.Config;
using ClientForm.Extension;

namespace ClientForm.Client
{
	public partial class LimeGameClient
	{
		public LoginUserInfo UserInfo { get; private set; } = null;
		public GameCodeInfo GameCode { get; private set; } = null;

		protected IClientProxy m_clientProxy = null;

		private LimeGameRoomKey m_limeGameRoomKey = new LimeGameRoomKey();
		private LimeGameUserKey m_limeGameUserKey = new LimeGameUserKey();

		#region client property
		private Action<string> m_actionLogout = null;
		private Action<string, MessageInfo> m_actionDisplayMsg = null;
		private Action<string, eSendMessageType, bool> m_actionMsgType = null;
		#endregion

		public LimeGameClient(LoginUserInfo userInfo)
		{
			UserInfo = userInfo;
			GameCode = ConfigData.INST.GameCodeMgr.Get(UserInfo.GameName);

			SetGameUserKey();
			SetIgnoreResponse();
		}

		public LimeGameUserKey GetGameUserKey()
		{
			return m_limeGameUserKey;
		}

		public LimeGameRoomKey GetGameRoomKey()
		{
			return m_limeGameRoomKey;
		}

		private string GetGameRoomName(GameRoomKeyInfo roomKeyInfo)
		{
			// 1:1 채팅 방은 이름 패턴.
			if (eGameRoomType.ONE_ON_ONE.ToString() == roomKeyInfo.type)
				return $"ngp.{roomKeyInfo.type}.{roomKeyInfo.roomKey}";

			return string.Empty;
		}

		#region set data
		private void SetGameUserKey()
		{
			m_limeGameUserKey.Add("Roya", "281474976711572", "1");
			m_limeGameUserKey.Add("BBB", "281474976711451", "1");
		}
		#endregion

		private void AddGameRoom(string strName, GameRoomKeyInfo keyInfo)
		{
			if (string.IsNullOrEmpty(strName))
			{
				Log.ErrorLog($"AddGameRoom. is null or empty room name. {strName}, {JsonConvert.SerializeObject(keyInfo)}");
				return;
			}

			m_limeGameRoomKey.Add(strName, keyInfo);
			m_actionMsgType?.Invoke(strName, eSendMessageType.Message, false);
		}

		private void LeaveGameRoom(string strName)
		{
			if (false == m_limeGameRoomKey.Remove(strName))
			{
				Log.ErrorLog($"LeaveGameRoom. not found game room key. {strName}");
				return;
			}

			m_actionMsgType?.Invoke(strName, eSendMessageType.Message, true);
		}

		private void DisplayMessage(string roomName, MessageInfo msgInfo)
		{
			m_actionDisplayMsg?.Invoke(roomName, msgInfo);
		}
	}

	public partial class LimeGameClient : IChatClient
	{
		public eClientType GetClientType()
		{
			return eClientType.LimeGame;
		}

		public void Initialize(bool isTestMode)
		{
			if (true == isTestMode)
				m_clientProxy = new LimeClientProxyStandalone(UserInfo.NickName, UserInfo.CharacterID);
			else
				m_clientProxy = new LimeClientProxy();
		}

		public void SetActions(IMainForm mainForm, Form form)
		{
			if (null == mainForm)
			{
				Log.ErrorLog("LimeGameUserInfo.SetActions main form null");
				return;
			}

			m_actionLogout = mainForm.OnLogout;
			if (false == form is LimeGameChatForm)
				return;

			LimeGameChatForm chattingForm = form as LimeGameChatForm;
			m_actionDisplayMsg = chattingForm.OnDisplayMessage;
			m_actionMsgType = chattingForm.OnUpdateMessageType;
		}

		public string GetUserKey()
		{
			return UserInfo.GetUserKey();
		}
	}

	#region virtual function
	public partial class LimeGameClient
	{
		public virtual GameRoomKeyInfo GetGameRoomKeyInfo(string strType)
		{
			GameRoomKeyInfo gameRoomKey = m_limeGameRoomKey.GetGameRoomKeyInfo(strType);
			if (null == gameRoomKey)
				return null;

			return gameRoomKey;
		}

		public virtual void SendMessage(Request req)
		{
			if (null == req)
			{
				Log.ErrorLog("SendMessage. request data null");
				return;
			}

			Log.DebugLog($"Request >> {JsonConvert.SerializeObject(req)}");
			m_clientProxy.SendMessage(req);
		}

		public virtual void SendTalk(string strType, string strMsg)
		{
			GameRoomKeyInfo gameRoomKey = GetGameRoomKeyInfo(strType);
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

		public virtual void SendWhisper(string strNickName, string strMsg)
		{
			GameUserKey gameUserKey = m_limeGameUserKey.GetGetUserKey(strNickName);
			if (null == gameUserKey)
				return;

			SendWhisperRequest req = new SendWhisperRequest()
			{
				gameUserKey = gameUserKey,
				gameMessageInfo = new GameMessageInfo()
				{
					userName = UserInfo.NickName,
					type = eMessageType.PUBLISH.ToString(),
					subType = eMessageSubType.WHISPER.ToString(),
					content = strMsg
				}
			};

			SendMessage(req);
		}

		public virtual void RecvMessage(string method, string content)
		{
			if (string.IsNullOrEmpty(method))
			{
				Log.ErrorLog($"OnResponse. method nuil. {method}");
				return;
			}

			if (CommandMap.SYSTEM_MESSAGE == method)
				Log.DebugLog($"System Msg >> {UserInfo.LoginID}, {content}");
			else
				OnApplyRecvMessage(method, content);
		}

		public virtual void OnApplyRecvMessage(string method, string content)
		{
			try
			{
				Type resType = CommandMap.INST.GetResponseType(method);
				if (null == resType)
					throw new Exception($"not found response type. Method:{method}");

				var resData = JsonConvert.DeserializeObject(content, resType);
				if (null == resData)
					throw new Exception($"deserialize object fail. {resType.Name}");

				if (false == ignoreResponse(resType.Name))
				{
					string methodName = $"On{resType.Name}";
					MethodInfo methodInfo = this.GetType().GetMethod(methodName, new Type[] { typeof(Response) });
					if (null == methodInfo)
						throw new Exception($"method null. {resType.Name}");

					methodInfo.Invoke(this, new object[] { resData });
				}

				ResponseLog(resData);
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"OnApplyResponse. exception Msg:{ex.Message}");
			}
		}
	}
	#endregion
}
