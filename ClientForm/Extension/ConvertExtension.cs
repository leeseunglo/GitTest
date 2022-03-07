using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientProtocol.Protocol;
using ClientForm.Config;
using Newtonsoft.Json;

namespace ClientForm.Extension
{
	public static partial class ConvertExtension
	{
		public static string GetUserKey(this LoginUserInfo info)
		{
			return GetUserKey(info.ServerName, info.GameName, info.ServerKey, info.NickName);
		}

		public static string GetUserKey(string targetServer, string gameName, string serverKey, string nickName)
		{
			GameCodeInfo gameCodeInfo = ConfigData.INST.GameCodeMgr.Get(gameName);
			return $"{targetServer}/{gameCodeInfo.Code}({serverKey})[{nickName}]";
		}

		#region scenario
		public static Request MakeRequestByScenarioDetailType(eScenarioDetailType detailType, string jsonData)
		{
			Request requestData = null;
			switch (detailType)
			{
				case eScenarioDetailType.Login:
					return null;

				case eScenarioDetailType.SendMessage:
					requestData = JsonConvert.DeserializeObject<SendMessageRequest>(jsonData);
					break;

				case eScenarioDetailType.CreateRoom:
					requestData = JsonConvert.DeserializeObject<CreateRoomRequest>(jsonData);
					break;

				case eScenarioDetailType.JoinRoom:
					requestData = JsonConvert.DeserializeObject<JoinRoomRequest>(jsonData);
					break;

				case eScenarioDetailType.LeaveRoom:
					requestData = JsonConvert.DeserializeObject<LeaveRoomRequest>(jsonData);
					break;

				case eScenarioDetailType.ReceiveMessage:
				case eScenarioDetailType.NotReceiveMessage:
					requestData = JsonConvert.DeserializeObject<RecvMessageCheck>(jsonData);
					break;
			}

			return requestData;
		}
		#endregion

		/*
		public static T ToMsgInfo<T>(this IMsgInfo info) where T : class
		{
			if (false == info is T)
				return null;

			return info as T;
		}
		
		
		public static GameRoomKeyInfo ToGameRoomKeyInfo(this IMsgInfo info)
		{
			LimeGameRoomMsgInfo msgInfo = info.ToMsgInfo<LimeGameRoomMsgInfo>();
			if (null == msgInfo)
				return null;

			return new GameRoomKeyInfo()
			{
				type = msgInfo.RoomType,
				serverKey = msgInfo.ServerKey,
				roomKey = msgInfo.RoomKey
			};
		}
		*/
	}
}
