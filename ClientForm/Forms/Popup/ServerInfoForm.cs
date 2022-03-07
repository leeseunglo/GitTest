using System;
using System.Windows.Forms;
using ClientForm.Common;
using ClientForm.Config;
using Core;

namespace ClientForm
{
    public partial class ServerInfoForm : Form
    {
        private Action m_actionResetComboBox = null;

        public ServerInfoForm(Action resetComboBox)
        {
            InitializeComponent();

            InitFormData();

            m_actionResetComboBox = resetComboBox;
        }

        #region set function
        private void InitFormData()
        {
            InitComboBox();
        }

        private void InitComboBox(bool resetTopForm = false)
		{
            Helper.SetController(ref cb_ServerList, "서버 정보", ConfigData.INST.ServerInfoMgr.GetKeys());
            if (true == resetTopForm)
                m_actionResetComboBox?.Invoke();
        }

        private void InitTextBox()
		{
            tb_ServerName.Clear();
            tb_ServerAddress.Clear();
        }
		#endregion

		#region button event definition function
		private void b_Add_Click(object sender, EventArgs e)
        {
            string serverName = tb_ServerName.Text.ToString();
            if (string.IsNullOrEmpty(serverName))
            {
                Helper.FocusHandle(tb_ServerName, "서버 이름을 적어주세요.");
                return;
            }

            string serverAddress = tb_ServerAddress.Text.ToString();
            if (string.IsNullOrEmpty(serverAddress))
            {
                Helper.FocusHandle(tb_ServerName, "서버 주소를 적어주세요.");
                return;
            }

            InitTextBox();
            ConfigData.INST.ServerInfoMgr.AddInfo(new ServerInfo(serverName, serverAddress));
            if (true == cb_ServerList.Items.Contains(serverName))
                return;

            InitComboBox(true);
        }

        private void b_Remove_Click(object sender, EventArgs e)
        {
            try
			{
                string strKey = tb_ServerName.Text;
                if (string.IsNullOrEmpty(strKey))
                    throw new Exception("remove key null");

                if (false == ConfigData.INST.ServerInfoMgr.Remove(strKey))
                    throw new Exception($"not found key. {strKey}");

                InitTextBox();
                InitComboBox(true);
            }
            catch (Exception ex)
			{
                Log.ErrorLog($"ServerInfoForm. remove event fail. {ex.Message}");
            }
        }

        private void b_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
		#endregion

		private void cb_ServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 == cb_ServerList.SelectedIndex)
                return;

            string strKey = cb_ServerList.SelectedItem.ToString();
            ServerInfo info = ConfigData.INST.ServerInfoMgr.Get(strKey);
            if (null == info)
                return;

            tb_ServerName.Text = info.Name;
            tb_ServerAddress.Text = info.Address;
        }
    }
}
