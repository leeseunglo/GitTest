using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Util;

namespace ClientProtocol.Protocol
{
	#region method type
	public enum EMethodType
	{
		None = 0,

		// Login
		GetAuthnToken,
		LoginWithToken,
		LogoutWithToken,

		// Room
		CreateRoom,
		DeleteRoom,
		JoinRoom,
		LeaveRoom,
		GetJoinedRoomList,
		GetRoomUsers,
		GetDeportedUserList,

		// Message
		SendMessage,

		// User
		UpdateUserRole,
		TransferOwner,
		DeportUser,
		UnDeportUser,
		BanUser,
		UnbenUser,
		BlockUser,
		UnblockUser,
		GetBlockUserList,
	}
	#endregion method type

	public class CommandMap : TSingleton<CommandMap>
	{
		public const string SYSTEM_MESSAGE = "/system/message";

		private Dictionary<string, string> m_dicMethodByRequestTypeName = new Dictionary<string, string>();
		private Dictionary<string, Type> m_dicResponseTypeByMethod = new Dictionary<string, Type>();

		public CommandMap()
		{
			initCommandMap();
		}

		#region public function
		public string GetMethod(Request req)
		{
			string requestName = req.GetType().Name;
			if (false == m_dicMethodByRequestTypeName.ContainsKey(requestName))
			{
				return string.Empty;
			}

			return m_dicMethodByRequestTypeName[requestName];
		}

		public Type GetResponseType(string strMethod)
		{
			if (false == m_dicResponseTypeByMethod.ContainsKey(strMethod))
			{
				return null;
			}

			return m_dicResponseTypeByMethod[strMethod];
		}
		#endregion public function

		#region private function
		private void addProtocolAndMethod(string strName, string strMethod)
		{
			m_dicMethodByRequestTypeName.Add($"{strName}Request", strMethod);
			m_dicResponseTypeByMethod.Add(strMethod, Type.GetType($"ClientProtocol.Protocol.{strName}Response"));
		}

		private void initCommandMap()
		{
			addProtocolAndMethod("GetAuthnToken", "/login/getAuthnToken");
			addProtocolAndMethod("LoginWithToken", "/gameLogin/loginWithToken");
			addProtocolAndMethod("LogoutWithToken", "/gameLogin/logoutWithJwtToken");

			addProtocolAndMethod("CreateRoom", "/gameClient/createRoom");
			addProtocolAndMethod("DeleteRoom", "/gameClient/deleteRoom");
			addProtocolAndMethod("JoinRoom", "/gameClient/joinRoom");
			addProtocolAndMethod("LeaveRoom", "/gameClient/leaveRoom");
			addProtocolAndMethod("GetJoinedRoomList", "/gameClient/getJoinedRoomList");
			addProtocolAndMethod("CreateOneOnOneRoomWithUser", "/gameClient/createOneOnOneRoomWithUser");

			addProtocolAndMethod("SendMessage", "/gameClient/sendMessage");
			addProtocolAndMethod("SendWhisper", "/gameClient/sendWhisper");

			addProtocolAndMethod("GameReport", "/gameClient/createGameReport");

			// User 관련 API
			addProtocolAndMethod("UpdateCharcharacterStatus", "/gameClient/updateCharacterStatus");

			// Server Message
			addProtocolAndMethod("ServerNotiMessage", "GAME");

			/*
			m_commandMap.Add(EMethodType.UpdateUserRole, "/gameClient/updateUserRole");
			m_commandMap.Add(EMethodType.TransferOwner, "/gameClient/transferOwner");
			m_commandMap.Add(EMethodType.DeportUser, "/gameClient/deportUser");
			m_commandMap.Add(EMethodType.UnDeportUser, "/gameClient/undeportUser");
			m_commandMap.Add(EMethodType.BanUser, "/gameClient/banUser");
			m_commandMap.Add(EMethodType.UnbenUser, "/gameClient/unbanUser");
			m_commandMap.Add(EMethodType.BlockUser, "/gameClient/blockUser");
			m_commandMap.Add(EMethodType.UnblockUser, "/gameClient/unblockUser");
			m_commandMap.Add(EMethodType.GetBlockUserList, "/gameClient/getBlockUserList");
			*/
		}
		#endregion private function
	}
}
