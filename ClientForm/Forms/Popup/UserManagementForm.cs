using System;
using System.Windows.Forms;
using ClientForm.Common;
using ClientForm.Config;
using Core;
using ClientForm.Extension;

namespace ClientForm
{
	public partial class UserManagementForm : Form
	{
		private Action m_actionResetComboBox = null;

		public UserManagementForm(Action resetComboBox)
		{
			InitializeComponent();

			InitFormData();

			m_actionResetComboBox = resetComboBox;
		}

		#region private function
		private void InitFormData()
		{
			InitUserComboBox();
			InitServerComboBox();
			InitGameCodeComboBox();
		}

		private void InitUserComboBox(bool resetTopForm = false)
		{
			Helper.SetController(ref cb_UserInfos, "계정 정보", ConfigData.INST.LoginUserMgr.GetKeys());
			if (true == resetTopForm)
				m_actionResetComboBox?.Invoke();
		}

		private void InitServerComboBox()
		{
			Helper.SetController(ref cb_ServerList, "서버 정보", ConfigData.INST.ServerInfoMgr.GetKeys());
		}

		private void InitGameCodeComboBox()
		{
			Helper.SetController(ref cb_GameCodeList, "게임 코드", ConfigData.INST.GameCodeMgr.GetKeys());
		}

		private void InitControl()
		{
			InitServerComboBox();
			InitGameCodeComboBox();

			tb_ServerKey.Clear();
			tb_LoginId.Clear();
			tb_Password.Clear();
			tb_CharacterID.Clear();
			tb_NickName.Clear();
		}

		private bool isValidControl()
		{
			if (0 == cb_ServerList.SelectedIndex)
				throw new Exception("not selected target server.");
			
			if (0 == cb_GameCodeList.SelectedIndex)
				throw new Exception("not selected game code fail.");

			if (true == Helper.EmptyTextBox(tb_LoginId, tb_Password, tb_CharacterID, tb_NickName, tb_ServerKey))
				throw new Exception("empty text box.");

			return true;
		}
		#endregion

		#region button event definition function
		private void b_Update_Click(object sender, EventArgs e)
		{
			try
			{
				if (false == isValidControl())
					throw new Exception("valid control fail.");

				{
					string serverName = cb_ServerList.Text;
					string gameCode = cb_GameCodeList.Text;
					var userInfo = new LoginUserInfo(serverName, gameCode, tb_ServerKey.Text, tb_LoginId.Text, tb_Password.Text, tb_CharacterID.Text, tb_NickName.Text);
					ConfigData.INST.LoginUserMgr.AddInfo(userInfo);

					InitUserComboBox(true);
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"b_Update_Click. exception Msg:{ex.Message}");
			}
		}

		private void b_Remove_Click(object sender, EventArgs e)
		{
			try
			{
				if (false == isValidControl())
					throw new Exception("valid control fail.");

				{
					string serverName = cb_ServerList.Text;
					string gameCode = cb_GameCodeList.Text;
					string strKey = ConvertExtension.GetUserKey(serverName, gameCode, tb_ServerKey.Text, tb_NickName.Text);
					if (false == ConfigData.INST.LoginUserMgr.Remove(strKey))
						throw new Exception($"not found key. {strKey}");

					InitControl();
					InitUserComboBox(true);
				}
			}
			catch (Exception ex)
			{
				Log.ErrorLog($"b_Remove_Click. exception Msg:{ex.Message}");
			}
		}

		private void b_Close_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion

		#region form controller
		private void b_ServerInfo_Click(object sender, EventArgs e)
		{
			Helper.OpenForm(new ServerInfoForm(InitServerComboBox));
		}

		private void b_GameCodeInfo_Click(object sender, EventArgs e)
		{
			Helper.OpenForm(new GameCodeForm(InitGameCodeComboBox));
		}
		#endregion

		private void UserManagementForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ConfigData.INST.Save();
		}

		private void cb_UserInfos_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (0 == cb_UserInfos.SelectedIndex)
				return;

			string strKey = cb_UserInfos.SelectedItem.ToString();
			LoginUserInfo info = ConfigData.INST.LoginUserMgr.Get(strKey);
			if (null == info)
			{
				Log.ErrorLog($"not found user info. {strKey}");
				return;
			}

			Helper.SetComboBox(ref cb_ServerList, info.ServerName);
			Helper.SetComboBox(ref cb_GameCodeList, info.GameName);

			tb_ServerKey.Text = info.ServerKey;
			tb_LoginId.Text = info.LoginID;
			tb_Password.Text = info.Password;
			tb_CharacterID.Text = info.CharacterID;
			tb_NickName.Text = info.NickName;
		}
	}
}
