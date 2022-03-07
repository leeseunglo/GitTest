using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Core;
using Core.Protocol.Stomp;
using ClientProtocol.Protocol;
using ClientProtocol.Extension;

namespace ClientProtocol.Model
{
	using ResponseFormat = Tuple<string, string>;

	public partial class LimeClientProxyStandalone : AbsClientProxy
	{
		class SampleRespone
		{
			public string tid = "123qdsd123415-21312eqewda";
			public string type = "RESPONSE";
			public string method = "";
			public long gameUserId = 0;
			public Response jsonData = null;
		}

		private readonly int m_requestLength = "Request".Length;

		private string m_nickName = "";

		public override void Dispose()
		{
			DisposeAutoEvent();
		}

		public override async Task<Response> Login(string url, string email, string passWord, string gameCode, string serverKey, string characterId)
		{
			return new LoginWithTokenResponse();
		}

		public void RemoveUser()
		{
			m_dicUserInfo.Remove(m_nickName);

			var keys = m_dicChatRoomUser.Keys.ToList();
			foreach (var key in keys)
			{
				m_dicChatRoomUser[key].RemoveAll(x => x == m_nickName);
				if (0 == m_dicChatRoomUser[key].Count)
					m_dicChatRoomUser.Remove(key);
			}
		}

		public override void Connect()
		{
			onMessage(StompCommand.CONNECTED, "");
			StartAutoEvent();
		}

		public override void SendMessage(Request req)
		{
			string reqName = req.GetType().Name;
			reqName = reqName.Substring(0, reqName.Length - m_requestLength);

			string methodName = $"make{reqName}Response";
			MethodInfo methodInfo = this.GetType().GetMethod(methodName, new Type[] { typeof(Request) });
			if (null == methodInfo)
				throw new Exception($"method null. {methodName}");

			var resFormat = (ResponseFormat)methodInfo.Invoke(this, new object[] { req });
			onMessage(resFormat.Item1, resFormat.Item2);

			if ("SendMessage" == reqName)
				new Thread(() => OnServerNotiMessageResponse(req, resFormat.Item2)).Start();
		}
	}

	#region static method
	public partial class LimeClientProxyStandalone
	{
		class UserInfo
		{
			public string CharacterID { get; private set; }
			public LimeClientProxyStandalone Info { get; private set; }

			public UserInfo(string characterId, LimeClientProxyStandalone info)
			{
				CharacterID = characterId;
				Info = info;
			}
		}

		private static Dictionary<string, UserInfo> m_dicUserInfo = new Dictionary<string, UserInfo>();
		private static Dictionary<GameRoomKeyInfo, List<string>> m_dicChatRoomUser = new Dictionary<GameRoomKeyInfo, List<string>>();

		public LimeClientProxyStandalone(string nickName, string characterId)
		{
			SetAutoEvent();
			m_nickName = nickName;
			m_dicUserInfo.Add(nickName, new UserInfo(characterId, this));
		}

		private static void JoinRoomUser(GameRoomKeyInfo roomKeyInfo, string nickName)
		{
			List<string> liNickName = null;
			if (false == m_dicChatRoomUser.TryGetValue(roomKeyInfo, out liNickName))
				m_dicChatRoomUser.Add(roomKeyInfo, liNickName = new List<string>());

			if (true == liNickName.Contains(nickName))
				return;

			liNickName.Add(nickName);
		}

		private static void OnServerNotiMessageResponse(Request req, string resData)
		{
			try
			{
				//Thread.Sleep(3000);
					
				var reqData = req as SendMessageRequest;
				if (null == reqData)
					throw new Exception($"request data fail");

				List<string> liNickName = null;
				if (false == m_dicChatRoomUser.TryGetValue(reqData.gameRoomKeyInfo, out liNickName))
					throw new Exception($"not found nick name list");

				var guid = ConvertResponseData<SendMessageResponse>(resData).guid;
				var notiMsg = makeNotiMessageResponse(reqData, guid);
				liNickName.ForEach(x =>
				{
					UserInfo user = null;
					if (false == m_dicUserInfo.TryGetValue(x, out user))
						throw new Exception($"not found user. NickName:{x}");

					user.Info.onMessage(notiMsg.Item1, notiMsg.Item2);
				});
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"LimeGameUserStandalone.NotiMessage exception. Data:{JsonConvert.SerializeObject(req)}, Msg:{ex.Message}");
			}
		}

		private static T ConvertResponseData<T>(string strMsg)
		{
			JObject jsonObj = (JObject)JsonConvert.DeserializeObject(strMsg);
			string content = jsonObj["jsonData"].ToString();
			return JsonConvert.DeserializeObject<T>(content);
		}

		private static ResponseFormat makeNotiMessageResponse(SendMessageRequest reqData, string guid)
		{
			UserInfo info = m_dicUserInfo[reqData.gameMessageInfo.userName];
			var resMsg = new ExampleServerResponse()
			{
				tid = "5ff36c928c00f853503c817be73845ea",
				type = "MESSAGE",
				method = "GAME",
				jsonData = new ServerNotiMessageResponse()
				{
					guid = guid,
					seq = "0",
					gameUserId = "609000924585107562",
					roomId = "663437069515637037",
					playNcCharId = info.CharacterID,
					serverId = "1",
					alias = "19689E9A-206D-46B1-958E-8EC0592E1606",
					classId = "112010",
					className = "엘븐 나이트",
					hasCastle = false,
					ranking = 0,
					type = reqData.gameMessageInfo.type,
					subType = reqData.gameMessageInfo.subType,
					content = reqData.gameMessageInfo.content,
					attribute = reqData.gameMessageInfo.attribute,
					userName = reqData.gameMessageInfo.userName,
					gameRoomKeyInfo = reqData.gameRoomKeyInfo
				}
			};

			return new ResponseFormat(StompCommand.MESSAGE, JsonConvert.SerializeObject(resMsg));
		}
	}
	#endregion

	public partial class LimeClientProxyStandalone
	{
		private AutoEvent m_autoSender = null;
		private int m_updateCount = 0;

		private void SetAutoEvent()
		{
			//m_autoSender = new AutoEvent(1000, RunEvent);
		}

		private void DisposeAutoEvent()
		{
			if (null == m_autoSender)
				return;

			m_autoSender.Stop();
			m_autoSender = null;
		}

		private void StartAutoEvent()
		{
			if (null == m_autoSender)
				return;

			m_autoSender.Start();
		}

		private bool RunEvent()
		{
			string resMsg = $"auto send message {++m_updateCount}";
			onMessage(StompCommand.MESSAGE, $"{{\"type\":\"MESSAGE\",\"method\":\"GAME\",\"jsonData\":{{\"userName\":\"System\",\"content\":\"{resMsg}\"}}}}");
			return true;
		}
	}
}

