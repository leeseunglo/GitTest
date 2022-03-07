using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;
using Core;

namespace ClientForm
{
	public class LimeGameRoomKey
	{
		private Dictionary<string, GameRoomKeyInfo> m_dicGameRoomKeyInfo = new Dictionary<string, GameRoomKeyInfo>();
		private Dictionary<GameRoomKeyInfo, string> m_dicGameRoomName = new Dictionary<GameRoomKeyInfo, string>();

		public void Add(string strName, GameRoomKeyInfo keyInfo)
		{
			if (false == m_dicGameRoomKeyInfo.ContainsKey(strName))
			{
				m_dicGameRoomKeyInfo.Add(strName, keyInfo);
				m_dicGameRoomName.Add(keyInfo, strName);
			}
			else
			{
				m_dicGameRoomKeyInfo[strName] = keyInfo;
				m_dicGameRoomName[keyInfo] = strName;
			}
		}

		public bool Remove(string strName)
		{
			GameRoomKeyInfo keyInfo = null;
			if (false == m_dicGameRoomKeyInfo.TryGetValue(strName, out keyInfo))
			{
				Log.ErrorLog($"LimeGameRoomInfo. remove fail. RoomName:{strName}");
				return false;
			}

			m_dicGameRoomKeyInfo.Remove(strName);
			m_dicGameRoomName.Remove(keyInfo);
			return true;
		}

		public int GetCount()
		{
			return m_dicGameRoomKeyInfo.Count;
		}

		public bool ContainsKey(string roomName)
		{
			return m_dicGameRoomKeyInfo.ContainsKey(roomName);
		}

		public bool ContainsKey(GameRoomKeyInfo keyInfo)
		{
			return m_dicGameRoomName.ContainsKey(keyInfo);
		}

		public string GetGameRoomName(GameRoomKeyInfo keyInfo)
		{
			if (false == m_dicGameRoomName.ContainsKey(keyInfo))
				return string.Empty;

			return m_dicGameRoomName[keyInfo];
		}

		public GameRoomKeyInfo GetGameRoomKeyInfo(string roomName)
		{
			if (false == m_dicGameRoomKeyInfo.ContainsKey(roomName))
			{
				Log.ErrorLog($"LimeGameRoomInfo. not found game room key info. Name{roomName}");
				return null;
			}

			return m_dicGameRoomKeyInfo[roomName];
		}

		public string[] GetGameRoomNames()
		{
			return m_dicGameRoomName.Values.ToArray();
		}
	}
}
