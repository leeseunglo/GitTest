using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Core.Protocol.Stomp;
using ClientProtocol.Protocol;

namespace ClientProtocol
{
	public class LimeStompClient : AbsStompClient
	{
		private readonly JsonSerializerSettings _jsonSerialzeSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

		public LimeStompClient(string strWebSocketURI, string limeToken)
			: base(strWebSocketURI, 60, limeToken)
		{

		}

		public void Connect(string strLogin, string strPassCode, string strAuth, Action<string> funcOpen, Action<string, string> funcMsg, Action<string> funcError, Action<string> funcClose)
		{
			var stompMsg = new StompMessage(StompCommand.CONNECT);
			stompMsg["accept-version"] = "1.0,1.1,1.2";
			stompMsg["heart-beat"] = "0,10000";
			stompMsg["login"] = strLogin;
			stompMsg["passcode"] = strPassCode;
			stompMsg["Authorization"] = strAuth;

			base.Connect(stompMsg, funcOpen, funcMsg, funcError, funcClose);
		}

		public void SendMessage(string strURI, Request req)
		{
			var stompRequest = new StompRequest()
			{
				tid = Guid.NewGuid().ToString(),
				method = CommandMap.INST.GetMethod(req),
				@params = req
			};

			var message = JsonConvert.SerializeObject(stompRequest, _jsonSerialzeSetting);
			base.Send(strURI, message);
		}
	}
}
