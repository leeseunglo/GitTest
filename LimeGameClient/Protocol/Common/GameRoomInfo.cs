using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class GameRoomInfo
	{
		public GameRoomKeyInfo gameRoomKeyInfo { get; set; }
		public string gameCode { get; set; }
		public string name { get; set; }
		public int memberCount { get; set; }
		public long dateCreated { get; set; }
		public bool deleted { get; set; }
		public long gameRoomId { get; set; }
	}
}
