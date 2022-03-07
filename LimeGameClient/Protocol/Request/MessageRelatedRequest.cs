using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class SendMessageRequest : Request
	{
		public GameRoomKeyInfo gameRoomKeyInfo { get; set; }
		public GameMessageInfo gameMessageInfo { get; set; }
	}

	public class SendWhisperRequest : Request
	{
		public GameUserKey gameUserKey { get; set; }
		public GameMessageInfo gameMessageInfo { get; set; }
	}

	public class GameReportRequest : Request
	{
		public GameRoomKeyInfo gameRoomKeyInfo { get; set; }
		public GameChatMessageInfo gameChatMessageInfo { get; set; }

		public string gameCode { get; set; }
		public string characterId { get; set; }
		public string serverKey { get; set; }
		public string reason { get; set; }
	}
}
