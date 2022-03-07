using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class SendMessageResponse : Response
	{
		public string guid { get; set; }
	}

	public class SendWhisperResponse : Response
	{
		public string guid { get; set; }
	}

	public class GameReportResponse : Response
	{
		public string message { get; set; }
	}
}
