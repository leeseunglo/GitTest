using System;
using System.Threading.Tasks;
using Core;
using Newtonsoft.Json;
using ClientProtocol.Protocol;
using ClientForm.Common;

namespace ClientForm.Scenario
{
	public partial class LimeGameScenarioClient
	{
		private void SendMessage(ScenarioActionInfo actionInfo)
		{
			Request request = null;
			switch (actionInfo.DetailType)
			{
				case eScenarioDetailType.CreateRoom:
					request = actionInfo.ActionData as CreateRoomRequest;
					break;

				case eScenarioDetailType.JoinRoom:
					request = actionInfo.ActionData as JoinRoomRequest;
					break;

				case eScenarioDetailType.LeaveRoom:
					request = actionInfo.ActionData as LeaveRoomRequest;
					break;

				case eScenarioDetailType.SendMessage:
					request = actionInfo.ActionData as SendMessageRequest;
					break;
			}

			base.SendMessage(request);
		}

		public void OnCreateRoomRequest(Request req)
		{
			var reqData = req as CreateRoomRequest;
			if (null == reqData)
				return;

			AddGameRoom(reqData.gameRoomKeyInfo);
		}

		public void OnJoinRoomRequest(Request req)
		{
			var reqData = req as JoinRoomRequest;
			if (null == reqData)
				return;

			AddGameRoom(reqData.gameRoomKeyInfo);
		}
	}
}
