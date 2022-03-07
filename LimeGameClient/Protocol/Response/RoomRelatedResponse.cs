using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class CommonRoomResponse : Response
	{
		public GameRoomInfo gameRoomInfo { get; set; }
		public long gameUserId { get; set; }
	}

	public class CreateRoomResponse : CommonRoomResponse
	{
	}

	public class JoinRoomResponse : CommonRoomResponse
	{
	}

	public class LeaveRoomResponse : CommonRoomResponse
	{
	}

	public class DeleteRoomResponse : Response
	{

	}

	public class CreateOneOnOneRoomWithUserResponse : Response
	{
		public GameRoomInfo gameRoomInfo { get; set; }
		public long gameUserId { get; set; }

	}

	public class GetJoinedRoomListResponse : Response
	{
		public List<GameRoomInfo> gameRoomInfoList { get; set; }
	}

	public class GetDeportedUserListResponse : Response
	{
		public GameRoomKeyInfo gameRoomKeyInfo { get; set; }
		public List<GameRoomUserInfo> deportedUserInfoList { get; set; }
	}
}
