using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;
using Core;
using Newtonsoft.Json;

namespace ClientForm
{
	public class JoinedGameRoomInfo
	{
		private Dictionary<string, GameRoomKeyInfo> m_dicGameRoomKeyInfo = new Dictionary<string, GameRoomKeyInfo>();
		private Dictionary<GameRoomKeyInfo, List<string>> m_dicRoomJoinedUser = new Dictionary<GameRoomKeyInfo, List<string>>();

		public void JoinUser(string userKey, GameRoomKeyInfo roomKeyInfo)
		{
			List<string> liUserName = null;
			if (false == m_dicRoomJoinedUser.TryGetValue(roomKeyInfo, out liUserName))
			{
				m_dicGameRoomKeyInfo.Add(roomKeyInfo.GetInfo(), roomKeyInfo);
				m_dicRoomJoinedUser.Add(roomKeyInfo, liUserName = new List<string>() { userKey });
			}
			else
			{
				if (true == liUserName.Contains(userKey))
					return;

				liUserName.Add(userKey);
			}
		}

		public void LeaveUser(string userKey, GameRoomKeyInfo roomKeyInfo)
		{
			List<string> liUserName = null;
			if (false == m_dicRoomJoinedUser.TryGetValue(roomKeyInfo, out liUserName))
			{
				Log.ErrorLog("RemoveGameRoomKey. none game room key info.");
				return;
			}

			int removeCnt = liUserName.RemoveAll(x => x.Equals(userKey));
			if (removeCnt > 1)
				Log.ErrorLog($"RemoveGameRoomKey. remove room exception. UserKey:{userKey}, Cnt:{removeCnt}");

			if (0 == liUserName.Count)
			{
				m_dicGameRoomKeyInfo.Remove(roomKeyInfo.GetInfo());
				m_dicRoomJoinedUser.Remove(roomKeyInfo);
			}
		}

		public GameRoomKeyInfo GetRoomInfo(string strRoomKey)
		{
			GameRoomKeyInfo roomKeyInfo = null;
			if (false == m_dicGameRoomKeyInfo.TryGetValue(strRoomKey, out roomKeyInfo))
			{
				Log.ErrorLog($"GetGameRoomKeyInfo. not found game room key info. GameRoomKey:{strRoomKey}");
				return null;
			}

			return roomKeyInfo;
		}

		public string[] GetGameRoomNames()
		{
			return m_dicGameRoomKeyInfo.Keys.ToArray();
		}

		public bool IsExistJoinedUser(string strRoomKey, string strUserKey)
		{
			try
			{
				GameRoomKeyInfo roomKeyInfo = GetRoomInfo(strRoomKey);
				if (null == roomKeyInfo)
					throw new Exception($"not found game room info. Key:{strRoomKey}");

				List<string> liUserName = null;
				if (false == m_dicRoomJoinedUser.TryGetValue(roomKeyInfo, out liUserName))
					throw new Exception($"not found joined user info. Key:{strRoomKey}");

				return liUserName.Contains(strUserKey);
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"IsExistJoinedUser exception. Msg:{ex.Message}");
				throw ex; 
			}
		}
	}
}
