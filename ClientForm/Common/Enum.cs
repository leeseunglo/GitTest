using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientForm
{
	public enum eClientType
	{
		None,
		LimeGame,
		LimePurple
	}

	public enum eConfigData
	{
		ServerInfo,
		GameCode,
		LoginUser,
		Room
	}

	public enum eGameRoomType
	{
		WORLD,
		REGION,
		LINE,
		GUILD,
		MERCENARY,
		PARTY,
		WHISPER,
		ONE_ON_ONE,
		INTERWORLD,
		NORMAL,
		ALL,				// ALL은 GameProxy 전용, 실제 게임에는 서비스하지 않는 타입
		SA_INTER_WORLD,
		SA_INTER_REGION,
		SA_INTER_PARTY,
		WORLD_GROUP,
		GUILD_UNION,
		GUILD_FEDERATION,
		SA_INTER_MERCENARY
	}

	public enum eMessageType
	{
		SYSTEM,
		ENTER,
		CLOSE,
		LEAVE,
		BAN,
		DEPORT,
		UNBAN,
		UNDEPORT,
		CREATE,
		UPDATE,
		ENTER_BULK,

		PUBLISH,
		NEMO,
		IMAGE,
		TIMER,

		CHANGE_OWNER,
		CHANGE_MANAGER,
		CHANGE_MEMBER,
		CREATE_CHANNEL,
		DELETE_CHANNEL,
		CREATE_GROUP,
		UPDATE_CHANNEL,
		ACTIVATE
	}

	public enum eMessageSubType
	{
		NORMAL = 0,

		SA_INTER_WORLD = 1,
		SA_INTER_REGION,
		SA_INTER_PARTY,
		WORLD_GROUP,
		GUILD_UNION,
		GUILD_FEDERATION,
		SA_INTER_MERCENARY,

		WORLD = 11,
		REGION,
		GUILD,
		LINE,
		PARTY,
		WHISPER,
		FRIEND,
		MERCENARY,
		ONE_ON_ONE,

		START = 21,
		STOP,
		HALT,
		PAUSER,
		RESU8MER
	}

	public enum eGameReportReason
	{
		NONE,
		OBSCENE,	// 음란
		INSULT,		// 욕설
		PLASTER,	// 도배
		ADVERTISE	// 광고
	}

	public enum eScenarioType
	{
		Login,
		ChatGroupRoom,

		// 메세지 관련
		SendMessage,
		ReceiveMessage,
		NotReceiveMessage,
	}

	public enum eScenarioDetailType
	{
		None,
		Login,

		CreateRoom,
		JoinRoom,
		LeaveRoom,

		SendMessage,
		ReceiveMessage,
		NotReceiveMessage,
	}
}
