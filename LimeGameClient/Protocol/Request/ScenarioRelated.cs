using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class RecvMessageCheck : Request
	{
		public GameRoomKeyInfo gameRoomKeyInfo { get; set; }
		public string content { get; set; }
	}
}
