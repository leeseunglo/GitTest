using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class GameRoomUserInfo
	{
		public string characterId { get; set; }

		public string role { get; set; }

		public DateTime dateUserJoined { get; set; }

		public bool userLeft { get; set; }

		public DateTime dateUserLeft { get; set; }

		public bool userDeported { get; set; }
	}
}
