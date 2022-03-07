using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProtocol.Protocol
{
	public class CommonRoomRequest : Request
	{
		public GameRoomKeyInfo gameRoomKeyInfo { get; set; }
	}

	public class CreateRoomRequest : CommonRoomRequest
	{
	}

	public class DeleteRoomRequest : CommonRoomRequest
	{
	}

	public class JoinRoomRequest : CommonRoomRequest
	{
	}

	public class LeaveRoomRequest : CommonRoomRequest
	{
	}

	public class GetJoinedRoomListRequest : Request
	{
	}

	public class GetDeportedUserListRequest : Request
	{
		public GameRoomKeyInfo gameRoomKeyInfo { get; set; }
	}

	public class CreateOneOnOneRoomWithUserRequest : Request
	{
		public GameUserKey gameUserKey { get; set; }
	}
}
