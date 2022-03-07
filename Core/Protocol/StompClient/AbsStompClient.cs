using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Core.Protocol.Stomp
{
    public interface IStompClient
    {
        void Configure(string strWebSocketURI, int waitTimeSecond);
        void Connect(StompMessage stompMsg);

        bool IsConnected();
        void Disconnect();
        void Subscribe(string strTopic);
        void Unsubscribe();
        void Send(string strURI, string strMsg);
    }

    public abstract class AbsStompClient
    {
		private readonly StompMessageSerializer serializer = new StompMessageSerializer();
		private readonly string contentType = string.Empty;
        private readonly string token = string.Empty;

		private WebSocket m_webSocket = null;
        private Action<string> m_actionCallOpen;
        private Action<string, string> m_actionCallMsg;
        private Action<string> m_actionCallError;
        private Action<string> m_actionCallClose;
        public bool IsConnected { get; private set; } = false;

        public AbsStompClient(string strWebSocketURI, int waitTimeSecond, string strToken = "", string strContentType = "application/json")
        {
			m_webSocket = new WebSocket(strWebSocketURI);
			m_webSocket.WaitTime = TimeSpan.FromSeconds(waitTimeSecond);

            token = strToken;
            contentType = strContentType;
		}

        public void Connect(StompMessage stompMsg, Action<string> funcOpen, Action<string, string> funcMsg, Action<string> funcError, Action<string> funcClose)
        {
            if (null == m_webSocket)
            {

            }

            if (null == stompMsg)
            {

            }

			m_actionCallOpen = funcOpen;
			m_actionCallMsg = funcMsg;
			m_actionCallError = funcError;
			m_actionCallClose = funcClose;

			m_webSocket.OnOpen += onOpen;
			m_webSocket.OnMessage += onMessage;
			m_webSocket.OnError += onError;
			m_webSocket.OnClose += onClose;
			m_webSocket.Connect();

			m_webSocket.Send(serializer.Serialize(stompMsg));
            IsConnected = true;
        }

        public void Disconnect()
        {

            IsConnected = false;
        }

		public void Send(string strURI, string jsonMsg)
		{
			var msg = new StompMessage(StompCommand.SEND, jsonMsg);
			msg["content-type"] = contentType;
            msg["Authorization"] = token;
            msg["destination"] = strURI;

            Send(msg);
		}

		public void Subscribe(string strTopic)
        {
			var msg = new StompMessage(StompCommand.SUBSCRIBE);
			msg["id"] = Guid.NewGuid().ToString();
			msg["destination"] = strTopic;

			Send(msg);
		}

        public void Unsubscribe()
        {
        }

        private void onOpen(object sender, EventArgs e)
        {
            Trace.WriteLine("stomp > opne");
			m_actionCallOpen?.Invoke("Opened.");
		}

        private void onMessage(object sender, MessageEventArgs e)
        {
            if (true == ignoreData(e.Data))
                return;

            Log.DebugLog(e.Data);
            var stompMsg = serializer.Deserialize(e.Data);
            /*
			var content = stompMsg.Body;
			switch (stompMsg.Command)
			{
				case StompCommand.CONNECTED:
					content = "Connected successfully.";
					break;

				case StompCommand.RECEIPT:
					content = "Disconnected successfully.";
					break;

				case StompCommand.MESSAGE:
					break;
			}
			*/

			m_actionCallMsg?.Invoke(stompMsg.Command, stompMsg.Body);
		}

        private bool ignoreData(string strData)
        {
            if (string.IsNullOrEmpty(strData))
                return true;

            if ("\n" == strData)
                return true;

            return false;
        }

        private void onError(object sender, ErrorEventArgs e)
        {
            Trace.WriteLine("stomp > error");
			m_actionCallError?.Invoke(e.Message);
		}

        private void onClose(object sender, CloseEventArgs e)
        {
            Trace.WriteLine("stomp > close");
			m_actionCallClose?.Invoke("Close.");
		}

		private void Send(StompMessage stompMsg)
		{
			string msg = serializer.Serialize(stompMsg);
			m_webSocket.Send(msg);
		}
    }
}
