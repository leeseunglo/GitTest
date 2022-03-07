using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class GameMessageInfo
	{
		public string userName { get; set; }
		public string type { get; set; }
		public string subType { get; set; }
		public string content { get; set; }
		public string bigContent { get; set; }
		public string attribute { get; set; }
	}

	public class GameChatMessageInfo
	{
		public string guid { get; set; }
		public string content { get; set; }
		public DateTime dateCreated { get; set; }
	}
}
