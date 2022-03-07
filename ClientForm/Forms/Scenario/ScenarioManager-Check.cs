using System;
using System.Collections.Generic;
using Core;
using Core.Util;
using Newtonsoft.Json;
using ClientProtocol.Protocol;

namespace ClientForm.Scenario
{
	#region check scenario
	public partial class ScenarioManager
	{
		private Regulator m_updateTime = null;
		private int m_runCount = 0; 
		private void initCheckScenario(long updateTick, long timeOutTick)
		{
			m_updateTime = new Regulator(updateTick);
			m_runCount = (int)(timeOutTick / updateTick);
		}

		private void ScenarioRecvCheck(ScenarioActionInfo actionInfo)
		{
			try
			{
				int count = 0;
				bool checkData = false;
				while (m_runCount > count)
				{
					if (false == m_updateTime.IsUpdate())
						continue;

					Log.ErrorLog($"ScenarioCheck {count}");
					switch (actionInfo.DetailType)
					{
						case eScenarioDetailType.Login:
							checkData = (1 == actionInfo.UserInfo.GetRecvData("LoginWithTokenResponse").Count);
							break;

						case eScenarioDetailType.SendMessage:
							checkData = RecvSendMessageCheck(actionInfo.UserInfo, actionInfo.ActionData);
							break;

						case eScenarioDetailType.CreateRoom:
							checkData = RecvGameRoomCheck(actionInfo.UserInfo, "CreateRoomResponse", (actionInfo.ActionData as CreateRoomRequest)?.gameRoomKeyInfo);
							break;
						case eScenarioDetailType.JoinRoom:
							checkData = RecvGameRoomCheck(actionInfo.UserInfo, "JoinRoomResponse", (actionInfo.ActionData as JoinRoomRequest)?.gameRoomKeyInfo);
							break;
						case eScenarioDetailType.LeaveRoom:
							checkData = RecvGameRoomCheck(actionInfo.UserInfo, "LeaveRoomResponse", (actionInfo.ActionData as LeaveRoomRequest)?.gameRoomKeyInfo);
							break;

						case eScenarioDetailType.ReceiveMessage:
						case eScenarioDetailType.NotReceiveMessage:
							{
								var actionData = actionInfo.ActionData as RecvMessageCheck;
								if (null == actionData)
									throw new Exception($"action data fail. ActionData:{JsonConvert.SerializeObject(actionInfo.ActionData)}");

								checkData = (null != RecvMessageCheck(actionInfo.UserInfo, actionData.gameRoomKeyInfo, actionData.content));
							}
							break;
					}

					// 응답을 정상적으로 받았다.
					if (true == checkData)
					{
						actionInfo.RecvCheck();
						return;
					}

					++count;
				}

				if (false == checkData)
				{
					// 체크해야 하는 데이터가 존재하면 안되는 것이 정상이다.
					if (eScenarioDetailType.NotReceiveMessage == actionInfo.DetailType)
						actionInfo.RecvCheck();
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"ScenarioRecvCheck fail. Msg:{ex.Message}, ActionData:{JsonConvert.SerializeObject(actionInfo)}");
			}
		}

		private bool RecvSendMessageCheck(LimeGameScenarioClient scenarioClient, Request reqData)
		{
			var actionData = reqData as SendMessageRequest;
			if (null == actionData)
				throw new Exception($"action data fail. ActionData:{JsonConvert.SerializeObject(reqData)}");

			ServerNotiMessageResponse notiMessage = RecvMessageCheck(scenarioClient, actionData.gameRoomKeyInfo, actionData.gameMessageInfo.content);
			if (null == notiMessage)
				return false;

			List<Response> liRecvData = scenarioClient.GetRecvData("SendMessageResponse");
			foreach (var data in liRecvData)
			{
				SendMessageResponse recvData = data as SendMessageResponse;
				if (null == recvData)
					throw new Exception($"recv data fail. RecvData:{JsonConvert.SerializeObject(recvData)}");

				if (notiMessage.guid == recvData.guid)
					return true;
			}

			return false;
		}
 
		private bool RecvGameRoomCheck(LimeGameScenarioClient scenarioClient, string resName, GameRoomKeyInfo gameRoomKeyInfo)
		{
			List<Response> liRecvData = scenarioClient.GetRecvData(resName);
			foreach (var data in liRecvData)
			{
				CommonRoomResponse recvData = data as CommonRoomResponse;
				if (null == recvData)
					throw new Exception($"recv data fail. RecvData:{JsonConvert.SerializeObject(recvData)}");

				if (true == recvData.gameRoomInfo.gameRoomKeyInfo.Equals(gameRoomKeyInfo))
					return true;
			}

			return false;
		}

		private ServerNotiMessageResponse RecvMessageCheck(LimeGameScenarioClient scenarioClient, GameRoomKeyInfo gameRoomKeyInfo, string content)
		{
			List<Response> liRecvData = scenarioClient.GetRecvData("ServerNotiMessageResponse");
			foreach (var data in liRecvData)
			{
				ServerNotiMessageResponse recvData = data as ServerNotiMessageResponse;
				if (null == recvData)
					throw new Exception($"recv data fail. RecvData:{JsonConvert.SerializeObject(recvData)}");

				if (false == recvData.gameRoomKeyInfo.Equals(gameRoomKeyInfo))
					continue;

				if (recvData.content == content)
					return recvData;
			}

			return null;
		}
	}
	#endregion
}
