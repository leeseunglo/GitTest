using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Protocol.Stomp
{
    public class StompCommand
    {
        //Client Command
        public const string CONNECT = "CONNECT";
        public const string DISCONNECT = "DISCONNECT";        
        public const string SUBSCRIBE = "SUBSCRIBE";
        public const string UNSUBSCRIBE = "UNSUBSCRIBE";
        public const string SEND = "SEND";

        //Server Response
        public const string CONNECTED = "CONNECTED";
        public const string MESSAGE = "MESSAGE";
		public const string RECEIPT = "RECEIPT";
		public const string ERROR = "ERROR";
        public const string GAME = "GAME";

        //System
        public const string SYSTEM = "SYSTEM";
    }
}
