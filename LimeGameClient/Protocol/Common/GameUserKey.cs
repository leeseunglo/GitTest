using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class GameUserKey
	{
		public string characterId { get; set; }
		public string serverKey { get; set; }

		public GameUserKey()
		{

		}

		public GameUserKey(string strCharacterId, string strServerId)
		{
			characterId = strCharacterId;
			serverKey = strServerId;
		}
	}
}
