using ClientForm.Client;
using ClientForm.Common;
using ClientForm.Config;
using Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using ClientForm.Scenario;

namespace ClientForm
{
	public partial class MainForm_New : Form, IMainForm
	{
		private bool m_isTestMode = false;
		private LoginUserInfo m_loginUserInfo = null;
		private Dictionary<string, TabPage> m_dicTabPage = new Dictionary<string, TabPage>();

		public MainForm_New()
		{
			Log.InitMainLogger("ChatLog");

			InitializeComponent();

			// 리소스 로드
			ConfigData.INST.Load();

			// Form 셋팅
			setFormData();
		}

		#region private function
		private void setFormData()
		{
			InitLoginUserComboBox();
			InitClientTypeComboBox();
		}
		private void OpenChattingForm(IChatClient chatClient)
		{
			Helper.ControlUpdate(tc_Chatting, () =>
			{
				Form chattingForm = new LimeGameChatForm(chatClient);
				chattingForm.TopLevel = false;

				TabPage page = new TabPage((tc_Chatting.TabPages.Count + 1).ToString());
				page.Controls.Add(chattingForm);
				tc_Chatting.TabPages.Add(page);

				chattingForm.WindowState = FormWindowState.Maximized;
				chattingForm.Show();

				chatClient.SetActions(this, chattingForm);

				m_dicTabPage.Add(chatClient.GetUserKey(), page);
			});
		}
		#endregion

		#region external form event
		#region Initialize combo box
		public void SetLoginUserInfo(LoginUserInfo userInfo)
		{
			m_loginUserInfo = userInfo;
		}

		public void InitLoginUserComboBox()
		{
			Helper.SetController(ref cb_LoginUserInfo, "계정을 선택해 주세요.", ConfigData.INST.LoginUserMgr.GetKeys());
			InitControl();
		}
		public void InitClientTypeComboBox()
		{
			Helper.SetController(ref cb_ClientType, string.Empty, Enum.GetNames(typeof(eClientType)));
		}

		private void InitControl()
		{
			tb_ServerName.Clear();
			tb_GameName.Clear();
			tb_ServerKey.Clear();
			tb_LoginId.Clear();
			tb_Password.Clear();
			tb_CharacterID.Clear();
			tb_NickName.Clear();
		}
		#endregion

		public void OnLogout(string loginUserKey)
		{
			try
			{
				Helper.ControlUpdate(tc_Chatting, () =>
				{
					TabPage page = null;
					if (false == m_dicTabPage.TryGetValue(loginUserKey, out page))
						throw new Exception($"not found tab page. {loginUserKey}");

					tc_Chatting.TabPages.Remove(page);
					m_dicTabPage.Remove(loginUserKey);
				});
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"OnLogout. exception Msg:{ex.Message}");
			}
		}

		public void OnRemoveLoginHistory(string strKey)
		{
			Helper.ControlUpdate(cb_LoginUserInfo, () =>
			{
				cb_LoginUserInfo.Items.Remove(strKey);
				ConfigData.INST.LoginUserMgr.Remove(strKey);
			});
		}

		public async Task<IChatClient> OnLogin(eClientType clientType, bool isTestMode, IChatClient chatClient = null)
		{
			ServerInfo serverInfo = ConfigData.INST.ServerInfoMgr.Get(m_loginUserInfo.ServerName);
			if (null == serverInfo)
				throw new Exception("not found server info");

			if (null == chatClient)
			{
				chatClient = GameUserFactory.CreateChatClient(clientType, m_loginUserInfo);
				if (null == chatClient)
					throw new Exception("create game user fail");
			}

			chatClient.Initialize(isTestMode);
			if (false == await chatClient.Login(serverInfo.Address).ConfigureAwait(false))
				throw new Exception("game user login fail");

			return chatClient;
		}
		#endregion

		public void SendMessage()
		{

		}

		#region form event definition function
		private async void b_Login_Click(object sender, EventArgs e)
		{
			try
			{
				Helper.SetEnable(b_Login, false);
				{
					if (null == m_loginUserInfo)
					{
						Helper.FocusHandle(cb_LoginUserInfo, "계정을 선택해 주세요.");
						return;
					}

					if (0 == cb_ClientType.SelectedIndex)
					{
						Helper.FocusHandle(cb_ClientType, "클라이언트 타입을 선택해 주세요.");
						return;
					}

					eClientType clientType = ConvertHelper.GetEnumValue<eClientType>(cb_ClientType.Text);
					IChatClient chatClient = await OnLogin(clientType, m_isTestMode).ConfigureAwait(false);
					if (null == chatClient)
						return;

					OpenChattingForm(chatClient);
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"b_Login_Click. exception Msg:{ex.Message}");
			}
			finally
			{
				Helper.SetEnable(b_Login, true);
			}
		}

		private void cb_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = sender as ComboBox;
			Helper.RemoveTitle(ref comboBox);
		}

		private void cb_LoginUserInfo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (0 == cb_LoginUserInfo.SelectedIndex)
				return;

			string userKey = cb_LoginUserInfo.Text;
			var userinfo = ConfigData.INST.LoginUserMgr.Get(userKey);
			if (null == userinfo)
			{
				OnRemoveLoginHistory(userKey);
				Log.ErrorLog($"not found user info. {userKey}");
				return;
			}

			SetLoginUserInfo(userinfo);
			tb_ServerName.Text = userinfo.ServerName;
			tb_GameName.Text = userinfo.GameName;
			tb_ServerKey.Text = userinfo.ServerKey;
			tb_LoginId.Text = userinfo.LoginID;
			tb_Password.Text = userinfo.Password;
			tb_CharacterID.Text = userinfo.CharacterID;
			tb_NickName.Text = userinfo.NickName;
		}

		#region form controller
		private void b_UserManagement_Click(object sender, EventArgs e)
		{
			Helper.OpenForm(new UserManagementForm(InitLoginUserComboBox));
		}

		private void b_ScenarioTest_Click(object sender, EventArgs e)
		{
			Helper.OpenForm(new ScenarioForm());
		}

		private void b_TestMode_Click(object sender, EventArgs e)
		{
			m_isTestMode = !m_isTestMode;
			b_TestMode.Text = "Test " + (m_isTestMode ? "Off" : "On");
		}
		#endregion

		#endregion
	}
}
