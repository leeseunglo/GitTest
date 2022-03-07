using System;
using System.Threading.Tasks;
using Core;
using Newtonsoft.Json;
using ClientProtocol.Protocol;
using ClientForm.Common;

namespace ClientForm.Client
{
	public partial class LimeGameClient : IChatClient
	{
		public async Task<bool> Login(string serverURL)
		{
			try
			{
				if (null == m_clientProxy)
					throw new Exception("game user null");

				var loginRes = await m_clientProxy.Login(serverURL, UserInfo.LoginID, UserInfo.Password, GameCode.Code, UserInfo.ServerKey, UserInfo.CharacterID).ConfigureAwait(false);
				if (null == loginRes)
					throw new Exception("login fail.");

				m_clientProxy.SetResponseFunc(RecvMessage);
				m_clientProxy.Connect();

				//OnLoginWithTokenResponse(loginRes);

				// 응답 처리의 로직을 통일하기 위해서 일단 처리.
				var method = CommandMap.INST.GetMethod(new LoginWithTokenRequest());
				OnApplyRecvMessage(method, JsonConvert.SerializeObject(loginRes));
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"Login. exception Msg:{ex.Message}");
				return false;
			}

			return true;
		}

		public void Logout()
		{
			SendMessage(new LogoutWithTokenRequest() { });
		}

		public void CreateReportMessage(MessageInfo msgInfo, eGameReportReason eReason)
		{
			try
			{
				if (null == msgInfo || eGameReportReason.NONE == eReason)
					throw new Exception($"input data fail. MsgInfo:{JsonConvert.SerializeObject(msgInfo)}, Reason:{eReason.ToString()}");

				GameReportRequest req = new GameReportRequest()
				{
					gameRoomKeyInfo = msgInfo.RoomKey,
					gameChatMessageInfo = new GameChatMessageInfo()
					{
						guid = msgInfo.Guid,
						content = msgInfo.Content,
						dateCreated = msgInfo.CreateDate
					},
					gameCode = GameCode.Code,
					characterId = UserInfo.CharacterID,
					serverKey = UserInfo.ServerKey,
					reason = eReason.ToString()
				};

				SendMessage(req);
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"CreateReportMessage. exception Msg:{ex.Message}");
			}
		}
	}
}
