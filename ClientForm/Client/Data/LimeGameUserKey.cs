using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;
using Core;

namespace ClientForm
{
	public class LimeGameUserKey
	{
		private Dictionary<string, GameUserKey> m_dicGameUserKey = new Dictionary<string, GameUserKey>();

		public void Add(string strName, string strCharacterId, string strServerId)
		{
			if (true == m_dicGameUserKey.ContainsKey(strName))
				return;

			m_dicGameUserKey.Add(strName, new GameUserKey(strCharacterId, strServerId));
		}

		public void Remove(string strName)
		{
			if (false == m_dicGameUserKey.ContainsKey(strName))
				return;

			m_dicGameUserKey.Remove(strName);
		}

		public GameUserKey GetGetUserKey(string strName)
		{
			GameUserKey key = null;
			if (false == m_dicGameUserKey.TryGetValue(strName, out key))
			{
				Log.ErrorLog($"not found game user key. Name:{strName}");
				return null;
			}

			return key;
		}
	}
}
