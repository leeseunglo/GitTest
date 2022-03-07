
namespace ClientForm
{
	partial class UserManagementForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label7 = new System.Windows.Forms.Label();
            this.tb_NickName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_GameCodeList = new System.Windows.Forms.ComboBox();
            this.tb_CharacterID = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.tb_LoginId = new System.Windows.Forms.TextBox();
            this.cb_ServerList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ServerKey = new System.Windows.Forms.TextBox();
            this.b_Close = new System.Windows.Forms.Button();
            this.b_TestConnection = new System.Windows.Forms.Button();
            this.cb_UserInfos = new System.Windows.Forms.ComboBox();
            this.b_Remove = new System.Windows.Forms.Button();
            this.b_Update = new System.Windows.Forms.Button();
            this.b_ServerInfo = new System.Windows.Forms.Button();
            this.b_GameCodeInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 8F);
            this.label7.Location = new System.Drawing.Point(16, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 11);
            this.label7.TabIndex = 34;
            this.label7.Text = "이    름";
            // 
            // tb_NickName
            // 
            this.tb_NickName.Font = new System.Drawing.Font("굴림", 8F);
            this.tb_NickName.Location = new System.Drawing.Point(61, 177);
            this.tb_NickName.Name = "tb_NickName";
            this.tb_NickName.Size = new System.Drawing.Size(182, 20);
            this.tb_NickName.TabIndex = 33;
            this.tb_NickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 8F);
            this.label5.Location = new System.Drawing.Point(6, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 11);
            this.label5.TabIndex = 32;
            this.label5.Text = "캐릭터 ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 8F);
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 11);
            this.label4.TabIndex = 31;
            this.label4.Text = "비밀 번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 8F);
            this.label3.Location = new System.Drawing.Point(13, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 11);
            this.label3.TabIndex = 30;
            this.label3.Text = "아 이 디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 8F);
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 11);
            this.label2.TabIndex = 29;
            this.label2.Text = "게임 코드";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 8F);
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 11);
            this.label1.TabIndex = 28;
            this.label1.Text = "서버 선택";
            // 
            // cb_GameCodeList
            // 
            this.cb_GameCodeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_GameCodeList.FormattingEnabled = true;
            this.cb_GameCodeList.Location = new System.Drawing.Point(61, 62);
            this.cb_GameCodeList.Name = "cb_GameCodeList";
            this.cb_GameCodeList.Size = new System.Drawing.Size(141, 20);
            this.cb_GameCodeList.TabIndex = 27;
            // 
            // tb_CharacterID
            // 
            this.tb_CharacterID.Font = new System.Drawing.Font("굴림", 8F);
            this.tb_CharacterID.Location = new System.Drawing.Point(61, 154);
            this.tb_CharacterID.Name = "tb_CharacterID";
            this.tb_CharacterID.Size = new System.Drawing.Size(182, 20);
            this.tb_CharacterID.TabIndex = 26;
            this.tb_CharacterID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Password
            // 
            this.tb_Password.Font = new System.Drawing.Font("굴림", 8F);
            this.tb_Password.Location = new System.Drawing.Point(61, 131);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(182, 20);
            this.tb_Password.TabIndex = 25;
            this.tb_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_LoginId
            // 
            this.tb_LoginId.Font = new System.Drawing.Font("굴림", 8F);
            this.tb_LoginId.Location = new System.Drawing.Point(61, 108);
            this.tb_LoginId.Name = "tb_LoginId";
            this.tb_LoginId.Size = new System.Drawing.Size(182, 20);
            this.tb_LoginId.TabIndex = 24;
            this.tb_LoginId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_ServerList
            // 
            this.cb_ServerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ServerList.FormattingEnabled = true;
            this.cb_ServerList.Location = new System.Drawing.Point(61, 39);
            this.cb_ServerList.Name = "cb_ServerList";
            this.cb_ServerList.Size = new System.Drawing.Size(141, 20);
            this.cb_ServerList.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 8F);
            this.label6.Location = new System.Drawing.Point(13, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 11);
            this.label6.TabIndex = 36;
            this.label6.Text = "서 버 키";
            // 
            // tb_ServerKey
            // 
            this.tb_ServerKey.Font = new System.Drawing.Font("굴림", 8F);
            this.tb_ServerKey.Location = new System.Drawing.Point(61, 85);
            this.tb_ServerKey.Name = "tb_ServerKey";
            this.tb_ServerKey.Size = new System.Drawing.Size(182, 20);
            this.tb_ServerKey.TabIndex = 35;
            this.tb_ServerKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // b_Close
            // 
            this.b_Close.Font = new System.Drawing.Font("굴림", 8F);
            this.b_Close.Location = new System.Drawing.Point(181, 228);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(63, 32);
            this.b_Close.TabIndex = 38;
            this.b_Close.Text = "닫기";
            this.b_Close.UseVisualStyleBackColor = true;
            this.b_Close.Click += new System.EventHandler(this.b_Close_Click);
            // 
            // b_TestConnection
            // 
            this.b_TestConnection.Enabled = false;
            this.b_TestConnection.Font = new System.Drawing.Font("굴림", 8F);
            this.b_TestConnection.Location = new System.Drawing.Point(128, 203);
            this.b_TestConnection.Name = "b_TestConnection";
            this.b_TestConnection.Size = new System.Drawing.Size(116, 23);
            this.b_TestConnection.TabIndex = 39;
            this.b_TestConnection.Text = "계정 접속 테스트";
            this.b_TestConnection.UseVisualStyleBackColor = true;
            // 
            // cb_UserInfos
            // 
            this.cb_UserInfos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UserInfos.FormattingEnabled = true;
            this.cb_UserInfos.Location = new System.Drawing.Point(12, 8);
            this.cb_UserInfos.Name = "cb_UserInfos";
            this.cb_UserInfos.Size = new System.Drawing.Size(231, 20);
            this.cb_UserInfos.TabIndex = 40;
            this.cb_UserInfos.SelectedIndexChanged += new System.EventHandler(this.cb_UserInfos_SelectedIndexChanged);
            // 
            // b_Remove
            // 
            this.b_Remove.Font = new System.Drawing.Font("굴림", 8F);
            this.b_Remove.Location = new System.Drawing.Point(118, 228);
            this.b_Remove.Name = "b_Remove";
            this.b_Remove.Size = new System.Drawing.Size(63, 32);
            this.b_Remove.TabIndex = 43;
            this.b_Remove.Text = "삭 제";
            this.b_Remove.UseVisualStyleBackColor = true;
            this.b_Remove.Click += new System.EventHandler(this.b_Remove_Click);
            // 
            // b_Update
            // 
            this.b_Update.Font = new System.Drawing.Font("굴림", 8F);
            this.b_Update.Location = new System.Drawing.Point(55, 228);
            this.b_Update.Name = "b_Update";
            this.b_Update.Size = new System.Drawing.Size(63, 32);
            this.b_Update.TabIndex = 41;
            this.b_Update.Text = "추 가";
            this.b_Update.UseVisualStyleBackColor = true;
            this.b_Update.Click += new System.EventHandler(this.b_Update_Click);
            // 
            // b_ServerInfo
            // 
            this.b_ServerInfo.Font = new System.Drawing.Font("굴림", 8F);
            this.b_ServerInfo.Location = new System.Drawing.Point(204, 38);
            this.b_ServerInfo.Name = "b_ServerInfo";
            this.b_ServerInfo.Size = new System.Drawing.Size(40, 22);
            this.b_ServerInfo.TabIndex = 44;
            this.b_ServerInfo.Text = "추가";
            this.b_ServerInfo.UseVisualStyleBackColor = true;
            this.b_ServerInfo.Click += new System.EventHandler(this.b_ServerInfo_Click);
            // 
            // b_GameCodeInfo
            // 
            this.b_GameCodeInfo.Font = new System.Drawing.Font("굴림", 8F);
            this.b_GameCodeInfo.Location = new System.Drawing.Point(204, 61);
            this.b_GameCodeInfo.Name = "b_GameCodeInfo";
            this.b_GameCodeInfo.Size = new System.Drawing.Size(40, 22);
            this.b_GameCodeInfo.TabIndex = 45;
            this.b_GameCodeInfo.Text = "추가";
            this.b_GameCodeInfo.UseVisualStyleBackColor = true;
            this.b_GameCodeInfo.Click += new System.EventHandler(this.b_GameCodeInfo_Click);
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 268);
            this.ControlBox = false;
            this.Controls.Add(this.b_GameCodeInfo);
            this.Controls.Add(this.b_ServerInfo);
            this.Controls.Add(this.b_Remove);
            this.Controls.Add(this.b_Update);
            this.Controls.Add(this.cb_UserInfos);
            this.Controls.Add(this.b_TestConnection);
            this.Controls.Add(this.b_Close);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_ServerKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_NickName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_GameCodeList);
            this.Controls.Add(this.tb_CharacterID);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_LoginId);
            this.Controls.Add(this.cb_ServerList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserManagementForm";
            this.Text = "유저 관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserManagementForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tb_NickName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cb_GameCodeList;
		private System.Windows.Forms.TextBox tb_CharacterID;
		private System.Windows.Forms.TextBox tb_Password;
		private System.Windows.Forms.TextBox tb_LoginId;
		private System.Windows.Forms.ComboBox cb_ServerList;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tb_ServerKey;
		private System.Windows.Forms.Button b_Close;
		private System.Windows.Forms.Button b_TestConnection;
		private System.Windows.Forms.ComboBox cb_UserInfos;
		private System.Windows.Forms.Button b_Remove;
		private System.Windows.Forms.Button b_Update;
		private System.Windows.Forms.Button b_ServerInfo;
		private System.Windows.Forms.Button b_GameCodeInfo;
	}
}