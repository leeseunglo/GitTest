using System;
using System.Windows.Forms;
using ClientForm.Common;
using ClientForm.Config;
using Core;
using ClientProtocol.Protocol;

namespace ClientForm.Scenario
{
	public partial class ScenarioForm : Form
	{
		private ScenarioManager m_scenarioMgr = null;

		public bool IsTestMode { get { return is_TestMode.Checked; } }

		public ScenarioForm()
		{
			InitializeComponent();

			InitFormData();
		}

		#region private function
		public void InitFormData()
		{
			{
				lv_ScenarioList.Items.Clear();
			}

			int timeOut = int.Parse(tb_TimeOut.Text) * 1000;
			m_scenarioMgr = new ScenarioManager(this, Math.Max(timeOut, 1000));

			Helper.SetController(ref cb_LoginUserInfo, "계정 정보", ConfigData.INST.LoginUserMgr.GetKeys());
			Helper.SetController(ref cb_ActionList, "시나리오 이벤트", Enum.GetNames(typeof(eScenarioType)));
		}
		#endregion

		#region button event definition function
		private void b_ScenarioPush_Click(object sender, EventArgs e)
		{
			if (0 == cb_LoginUserInfo.SelectedIndex)
			{
				Helper.FocusHandle(cb_LoginUserInfo, "selected action play user");
				return;
			}

			if (0 == cb_ActionList.SelectedIndex)
			{
				Helper.FocusHandle(cb_ActionList, "selected action");
				return;
			}

			eScenarioType scenarioType = ConvertHelper.GetEnumValue<eScenarioType>(cb_ActionList.Text);
			m_scenarioMgr.OpenScenarioItemForm(cb_LoginUserInfo.Text, scenarioType);
		}

		private async void b_ScenarioStart_Click(object sender, EventArgs e)
		{
			try
			{
				Helper.SetEnable(gb_ScenarioController, false);
				{
					await m_scenarioMgr.ScenarioRun().ConfigureAwait(false);
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"scenario start fail. exception Msg:{ex.Message}");
			}
			finally
			{
				Helper.SetEnable(gb_ScenarioController, true);
			}
		}

		private void b_Reset_Click(object sender, EventArgs e)
		{
			m_scenarioMgr.Reset();
		}

		private void b_OpenFile_Click(object sender, EventArgs e)
		{
			if (DialogResult.OK == Dialog_OpenScenarioFile.ShowDialog())
			{
				m_scenarioMgr.OpenFile(Dialog_OpenScenarioFile.FileName);
			}
		}

		private void b_ScenarioFileWrite_Click(object sender, EventArgs e)
		{
			if (DialogResult.OK == Dialog_ScenarioFileWrite.ShowDialog())
			{
				m_scenarioMgr.SaveFile(Dialog_ScenarioFileWrite.FileName);
			}
		}

		private void ScenarioForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_scenarioMgr.Reset();
		}
		#endregion

		public void ScenarioViewPush(ScenarioActionInfo action)
		{
			ListViewItem viewInfo = new ListViewItem(action.Num.ToString());
			viewInfo.SubItems.Add(action.Num.ToString());
			viewInfo.SubItems.Add(action.UserInfo.GetNickName());
			viewInfo.SubItems.Add(action.DetailType.ToString());
			viewInfo.SubItems.Add(GetActionData(action));
			viewInfo.SubItems.Add(action.Send.ToString());
			viewInfo.SubItems.Add(action.Recv.ToString());
			lv_ScenarioList.Items.Add(viewInfo);
		}

		public void UpdateResult(ScenarioActionInfo action)
		{
			Helper.ControlUpdate(lv_ScenarioList, () =>
			{
				var info = lv_ScenarioList.Items[action.Num - 1];
				info.SubItems[5].Text = action.Send.ToString();
				info.SubItems[6].Text = action.Recv.ToString();
			});
		}

		private string GetActionData(ScenarioActionInfo action)
		{
			switch (action.DetailType)
			{
				case eScenarioDetailType.CreateRoom:
					return $"RoomKey:{(action.ActionData as CreateRoomRequest).gameRoomKeyInfo.GetInfo()}";
				case eScenarioDetailType.JoinRoom:
					return $"RoomKey:{(action.ActionData as JoinRoomRequest).gameRoomKeyInfo.GetInfo()}";
				case eScenarioDetailType.LeaveRoom:
					return $"RoomKey:{(action.ActionData as LeaveRoomRequest).gameRoomKeyInfo.GetInfo()}";

				case eScenarioDetailType.SendMessage:
					{
						var req = action.ActionData as SendMessageRequest;
						return $"RoomKey:{req.gameRoomKeyInfo.GetInfo()}, Msg:{req.gameMessageInfo.content}";
					}

				case eScenarioDetailType.ReceiveMessage:
				case eScenarioDetailType.NotReceiveMessage:
					{
						var req = action.ActionData as RecvMessageCheck;
						return $"RoomKey:{req.gameRoomKeyInfo.GetInfo()}, Msg:{req.content}";
					}
			}

			return "";
		}
	}
}
