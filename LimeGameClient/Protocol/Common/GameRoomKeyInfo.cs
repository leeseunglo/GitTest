using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class GameRoomKeyInfo
	{
		public string type { get; set; }
		public string serverKey { get; set; }
		public string roomKey { get; set; }

		public GameRoomKeyInfo()
		{

		}

		public GameRoomKeyInfo(string strType, string strServerKey, string strRoomKey)
		{
			type = strType;
			serverKey = strServerKey;
			roomKey = strRoomKey;
		}

		public override bool Equals(object obj)
		{
			var objValue = obj as GameRoomKeyInfo;
			if (null == objValue)
				return false;

			return type.Equals(objValue.type) && serverKey.Equals(objValue.serverKey) && roomKey.Equals(objValue.roomKey);
		}

		public override int GetHashCode()
		{
			return GetInfo().GetHashCode();
		}

		public string GetInfo()
		{
			return $"{type}/{serverKey}/{roomKey}";
		}
	}
}
