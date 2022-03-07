using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Core.Util;
using Core.Protocol.Stomp;
using ClientProtocol.Protocol;
using ClientProtocol.Extension;

namespace ClientProtocol.Model
{
	using ResponseFormat = Tuple<string, string>;

	public partial class LimeClientProxyStandalone
	{
		class ExampleServerResponse
		{
			public string tid { get; set; }
			public string type { get; set; }
			public string method { get; set; }
			public Response jsonData { get; set; }
		}

		private GameRoomInfo makeGameRoomInfo(GameRoomKeyInfo keyInfo)
		{
			string strGameCode = "l2m";
			return new GameRoomInfo()
			{
				gameRoomKeyInfo = keyInfo,
				gameCode = strGameCode,
				name = $"{strGameCode}.{keyInfo.type}.{keyInfo.roomKey}",
				deleted = false
			};
		}

		private string makeSampleResponse(Request req, Response res)
		{
			return JsonConvert.SerializeObject(new SampleRespone()
			{
				method = CommandMap.INST.GetMethod(req),
				jsonData = res
			});
		}

		public ResponseFormat makeCreateRoomResponse(Request req)
		{
			var roomKeyInfo = (req as CreateRoomRequest).gameRoomKeyInfo;
			JoinRoomUser(roomKeyInfo, m_nickName);
			var resMsg = makeSampleResponse(req, new CreateRoomResponse() { gameRoomInfo = makeGameRoomInfo(roomKeyInfo) });
			return new ResponseFormat(StompCommand.MESSAGE, resMsg);
		}

		public ResponseFormat makeJoinRoomResponse(Request req)
		{
			var roomKeyInfo = (req as JoinRoomRequest).gameRoomKeyInfo;
			JoinRoomUser(roomKeyInfo, m_nickName);
			var resMsg = makeSampleResponse(req, new JoinRoomResponse() { gameRoomInfo = makeGameRoomInfo(roomKeyInfo) });
			return new ResponseFormat(StompCommand.MESSAGE, resMsg);
		}

		public ResponseFormat makeLeaveRoomResponse(Request req)
		{
			var roomKeyInfo = (req as LeaveRoomRequest).gameRoomKeyInfo;
			var resMsg = makeSampleResponse(req, new LeaveRoomResponse() { gameRoomInfo = makeGameRoomInfo(roomKeyInfo) });
			return new ResponseFormat(StompCommand.MESSAGE, resMsg);
		}

		public ResponseFormat makeSendMessageResponse(Request req)
		{
			var guid = DateTime.Now.Ticks.ToString();
			return new ResponseFormat(StompCommand.MESSAGE, makeSampleResponse(req, new SendMessageResponse() { guid = guid }));
		}

		public ResponseFormat makeSendWhisperResponse(Request req)
		{
			var guid = DateTime.Now.Ticks.ToString();
			return new ResponseFormat(StompCommand.MESSAGE, makeSampleResponse(req, new SendWhisperResponse() { guid = guid }));
		}

		public ResponseFormat makeLogoutWithTokenResponse(Request req)
		{
			var resMsg = makeSampleResponse(req, new LogoutWithTokenResponse() { message = "SUCCESS" });
			return new ResponseFormat(StompCommand.MESSAGE, resMsg);
		}

		public ResponseFormat makeGetJoinedRoomListResponse(Request req)
		{
			var gameRoomList = new List<GameRoomKeyInfo>()
			{
				new GameRoomKeyInfo("WORLD", "1000", "1001"),
				new GameRoomKeyInfo("WORLD", "2000", "2001"),
				new GameRoomKeyInfo("WORLD", "3000", "3001")
			};

			var rseMsg = new GetJoinedRoomListResponse();
			rseMsg.gameRoomInfoList = new List<GameRoomInfo>();
			gameRoomList.ForEach(x => rseMsg.gameRoomInfoList.Add(new GameRoomInfo()
			{
				gameRoomKeyInfo = x,
				name = $"{x.type}.{x.serverKey}.{x.roomKey}"
			}));

			return new ResponseFormat(StompCommand.MESSAGE, makeSampleResponse(req, rseMsg));
		}
	}
}

