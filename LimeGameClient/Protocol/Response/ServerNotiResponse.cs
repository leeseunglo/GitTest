using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol	
{
	public class ServerNotiMessageResponse : Response
	{
		public string guid { get; set; }
		public string seq { get; set; }
		public string gameUserId { get; set; }
		public string roomId { get; set; }
		public string playNcCharId { get; set; }
		public string userName { get; set; }

		public string receiverCharacterId { get; set; }
		public string receiverUserName { get; set; }
		public string serverId { get; set; }
		public string receiverServerId { get; set; }

		public string alias { get; set; }
		public string classId { get; set; }
		public string className { get; set; }
		public bool hasCastle { get; set; }
		public int ranking { get; set; }
		public string gender { get; set; }

		public string type { get; set; }
		public string subType { get; set; }
		public string content { get; set; }
		public string attribute { get; set; }
		public string optional { get; set; }

		public GameRoomKeyInfo gameRoomKeyInfo { get; set; }
		public string role { get; set; }
		public bool isFromGame { get; set; }
		public string senderGameCode { get; set; }
		public int castleNo { get; set; }
		
		public string guildId { get; set; }
		public string receiverGameCode;
	}
}
