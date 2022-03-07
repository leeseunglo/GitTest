using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientForm.Common;
using ClientForm.Config;
using ClientForm.Client;
using Core;
using Core.Util;
using Newtonsoft.Json;
using ClientProtocol.Protocol;

namespace ClientForm.Scenario
{
	public partial class ScenarioManager
	{
		private ScenarioForm m_scenarioForm = null;
		private Dictionary<string, LimeGameScenarioClient> m_dicGameClient = new Dictionary<string, LimeGameScenarioClient>();
		private List<ScenarioActionInfo> m_liScenarioActionInfo = new List<ScenarioActionInfo>();

		public ScenarioManager(ScenarioForm form, int timeOut)
		{
			m_scenarioForm = form;
			initCheckScenario(1000, timeOut);
		}

		#region set scenario data
		private bool AddScenarioItemData(string userKey, eScenarioDetailType detailType, Request actionData, LoginUserInfo userInfo = null)
		{
			try
			{
				bool isContainsUser = m_dicGameClient.ContainsKey(userKey);
				if (eScenarioDetailType.Login == detailType)
				{
					if (true == isContainsUser)
						throw new Exception("already user login push");

					if (null == userInfo)
					{
						userInfo = ConfigData.INST.LoginUserMgr.Get(userKey);
						if (null == userInfo)
							Log.ErrorLog($"not found user info. {userKey}");
					}

					m_dicGameClient.Add(userKey, new LimeGameScenarioClient(userInfo, this));
				}
				else
				{
					if (false == isContainsUser)
						throw new Exception("not login action user");

					switch (detailType)
					{
						case eScenarioDetailType.CreateRoom:
						case eScenarioDetailType.JoinRoom:
							AddGameRoomKey(userKey, actionData);
							break;

						case eScenarioDetailType.LeaveRoom:
							RemoveGameRoomKey(userKey, actionData);
							break;
					}
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"SetScenarioItemData fail. Msg:{ex.Message}");
				return false;
			}

			return true;
		}
		private void AddScenarioData(ScenarioActionInfo scenarioInfo)
		{
			m_liScenarioActionInfo.Add(scenarioInfo);
			m_scenarioForm.ScenarioViewPush(scenarioInfo);
		}
		#endregion

		public void Reset()
		{
			m_dicGameClient.Values.ToList().ForEach(x => x.RemoveUser());
			m_scenarioForm.InitFormData();
		}

		public void ScenarioPush(string userKey, eScenarioDetailType detailType, Request actionData)
		{
			if (false == AddScenarioItemData(userKey, detailType, actionData))
				return;

			int num = m_liScenarioActionInfo.Count + 1;
			ScenarioActionInfo scenarioInfo = new ScenarioActionInfo(num, m_dicGameClient[userKey], detailType, actionData, !isSendAction(detailType));
			AddScenarioData(scenarioInfo);
		}

		public void OpenScenarioItemForm(string userKey, eScenarioType scenarioType)
		{
			try
			{
				if (eScenarioType.Login == scenarioType)
				{
					ScenarioPush(userKey, eScenarioDetailType.Login, null);
				}
				else
				{
					// MainForm -> SubForm -> ScenarioPush 가 이루어 지기에, 여기에서 체크를 해야 한다.
					LimeGameScenarioClient gameClient = null;
					if (false == m_dicGameClient.TryGetValue(userKey, out gameClient))
						throw new Exception("not login action user");

					switch (scenarioType)
					{
						case eScenarioType.ChatGroupRoom:
							Helper.OpenForm(new ChatGroupForm(gameClient));
							break;

						case eScenarioType.SendMessage:
						case eScenarioType.ReceiveMessage:
						case eScenarioType.NotReceiveMessage:
							Helper.OpenForm(new MessageForm(gameClient, scenarioType, m_joinedGameRoomInfo));
							break;
					}
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"Scenario push fail. Msg:{ex.Message}");
			}
		}

		public async Task ScenarioRun()
		{
			try
			{
				Log.ErrorLog("\n\n==========================================================");
				foreach (var info in m_liScenarioActionInfo)
				{
					Thread.Sleep(1000);
					if (false == isSendAction(info.DetailType))
						continue;

					if (true == info.Send)
						throw new Exception($"send is already a success. Data:{JsonConvert.SerializeObject(info)}");

					await info.UserInfo.SendScenarioMessage(info, m_scenarioForm.IsTestMode).ConfigureAwait(false);

					info.SendCheck();
					m_scenarioForm.UpdateResult(info);
					Log.ErrorLog($"Send >> {JsonConvert.SerializeObject(info)}");
				}

				Log.ErrorLog("\n\n==========================================================");
				foreach (var info in m_liScenarioActionInfo)
				{
					if (true == info.Recv)
						throw new Exception($"recv is already a success. Data:{JsonConvert.SerializeObject(info)}");

					ScenarioRecvCheck(info);
					m_scenarioForm.UpdateResult(info);
					Log.ErrorLog($"Recv >> {JsonConvert.SerializeObject(info)}");
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"ScenarioRun fail. Msg:{ex.Message}");
			}
		}

		private bool isSendAction(eScenarioDetailType scenarioDetailType)
		{
			if (eScenarioDetailType.ReceiveMessage == scenarioDetailType ||
				eScenarioDetailType.NotReceiveMessage == scenarioDetailType)
				return false;

			return true;
		}
	}

	public partial class ScenarioManager
	{
		private JoinedGameRoomInfo m_joinedGameRoomInfo = new JoinedGameRoomInfo();

		private void AddGameRoomKey(string userKey, Request actionData)
		{
			var reqData = actionData as CommonRoomRequest;
			if (null == reqData)
			{
				Log.ErrorLog($"AddGameRoomKeyInfo. action data convert fail. Data:{JsonConvert.SerializeObject(actionData)}");
				return;
			}

			m_joinedGameRoomInfo.JoinUser(userKey, reqData.gameRoomKeyInfo);
		}

		private void RemoveGameRoomKey(string userKey, Request actionData)
		{
			var reqData = actionData as CommonRoomRequest;
			if (null == reqData)
			{
				Log.ErrorLog($"RemoveGameRoomKey. action data convert fail. Data:{JsonConvert.SerializeObject(actionData)}");
				return;
			}

			m_joinedGameRoomInfo.LeaveUser(userKey, reqData.gameRoomKeyInfo);
		}

		public GameRoomKeyInfo GetGameRoomKeyInfo(string strRoomKey)
		{
			return m_joinedGameRoomInfo.GetRoomInfo(strRoomKey);
		}
	}
}
