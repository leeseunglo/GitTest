using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protocol.Stomp
{
    public class StompMessage
    {
		public string Body { get; private set; }
		public string Command { get; private set; }
		public Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();

		public string this[string header]
		{
			get { return Headers.ContainsKey(header) ? Headers[header] : string.Empty; }
			set { Headers[header] = value; }
		}

        public StompMessage(string command)
            : this(command, string.Empty)
        {
        }

        public StompMessage(string command, string body)
            : this(command, body, new Dictionary<string, string>())
        {
        }

        internal StompMessage(string command, string body, Dictionary<string, string> headers)
        {
            Command = command;
            Body = body;
			Headers = headers;

            //this["content-length"] = body.Length.ToString();
            this["content-length"] = Encoding.UTF8.GetByteCount(body).ToString();
        }
    }
}
