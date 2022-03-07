using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ClientProtocol.Protocol;
using ClientProtocol.Extension;
using Core;
using Core.Protocol.Http;
using Core.Protocol.Stomp;

namespace ClientProtocol.Model
{
	public class LimeClientProxy : AbsClientProxy
	{
		public string LimeToken { get; private set; } = string.Empty;
		public StompInfo StompInfo { get; private set; } = null;

		private LimeStompClient m_webSocket = null;

		public override void Dispose()
		{

		}

		public override async Task<Response> Login(string url, string email, string passWord, string gameCode, string serverKey, string characterId)
		{
			try
			{
				HttpClient httpClient = new HttpClient();
                httpClient["Lime-Trace-id"] = "1000";
                httpClient["Lime-API-Version"] = "120";

				var npReq = new GetAuthnTokenRequest()
				{
					username = email,
					password = passWord,
					clientType = "GAME",
					gameCode = gameCode,
					deviceId = "_LIME_A"
				};

				url = $"http://{url}";
				var npURL = url + CommandMap.INST.GetMethod(npReq);
				var npRes = await httpClient.PostAsJsonAsync<GetAuthnTokenRequest, GetAuthnTokenResponse>(npURL, npReq).ConfigureAwait(false);

				var loginReq = new LoginWithTokenRequest()
				{
					gameCode = npReq.gameCode,
					characterId = characterId,
					serverKey = serverKey,
					deviceId = npReq.deviceId,
					clientType = npReq.clientType,
					authnToken = npRes.authnToken
				};

				var loginURL = url + CommandMap.INST.GetMethod(loginReq);
				var loginRes = await httpClient.PostAsJsonAsync<LoginWithTokenRequest, LoginWithTokenResponse>(loginURL, loginReq).ConfigureAwait(false);

				StompInfo = loginRes.subscriptionInfo.ToStompInfo();
				LimeToken = loginRes.mtalkToken;
                m_webSocket = new LimeStompClient(StompInfo.SubscribeURL, LimeToken);
				return loginRes;
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"Login. exception Msg:{ex.Message}");
				return null;
			}
		}

		public override void Connect()
		{
			m_webSocket.Connect(StompInfo.Login, StompInfo.PassCode, LimeToken, null, onMessage, null, null);
			m_webSocket.Subscribe(StompInfo.TopicName);
		}

		public override void SendMessage(Request req)
		{
			if (null == req)
			{
				Log.ErrorLog($"SendMessage. send packet request data null");
				return;
			}

			m_webSocket.SendMessage(StompInfo.ServerAppDest, req);
		}
	}
}
