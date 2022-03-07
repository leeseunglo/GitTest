using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;

namespace ClientForm.Common
{
	public partial class MessageInfo
	{
		public GameRoomKeyInfo RoomKey { get; private set; }
		public string Guid { get; private set; }
		public string UserName { get; private set; }
		public string Content { get; private set; }
		public DateTime CreateDate { get; private set; }

		public MessageInfo(GameRoomKeyInfo roomKey, string guid, string userName, string content)
		{
			RoomKey = roomKey;
			Guid = guid;
			UserName = userName;
			Content = content;
			CreateDate = DateTime.Now;
		}
	}
}
