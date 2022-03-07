using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;
using ClientProtocol.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Core.Protocol.Stomp;

namespace ClientProtocol.Model
{
	public interface IClientProxy
	{
		void Dispose();

		Task<Response> Login(string url, string email, string passWord, string gameCode, string serverKey, string characterId);

		void SetResponseFunc(Action<string, string> func);

		void Connect();

		void SendMessage(Request req);
	}

	public abstract class AbsClientProxy : IClientProxy
	{
		private Action<string, string> m_actionResMsg = null;

		#region interface method
		public abstract void Dispose();
		public abstract Task<Response> Login(string url, string email, string passWord, string gameCode, string serverKey, string characterId);
		public abstract void Connect();
		public abstract void SendMessage(Request req);
		#endregion

		public void SetResponseFunc(Action<string, string> func)
		{
			m_actionResMsg = func;
		}

		protected void onMessage(string strCmd, string strMsg)
		{
			var method = Helper.GetIgnoreMethod(strCmd);
			var content = strMsg;
			switch (strCmd)
			{
				case StompCommand.CONNECTED:
					content = "Connected successfully.";
					break;

				case StompCommand.RECEIPT:
					content = "Disconnected successfully.";
					break;

				case StompCommand.MESSAGE:
					JObject jsonObj = (JObject)JsonConvert.DeserializeObject(strMsg);
					method = jsonObj["method"].ToString();
					content = jsonObj["jsonData"].ToString();
					break;
			}

			if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(method))
				return;

			m_actionResMsg?.Invoke(method, content);
		}
	}
}
