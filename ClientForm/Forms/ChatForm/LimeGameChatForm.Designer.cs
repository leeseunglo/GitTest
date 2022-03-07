
namespace ClientForm
{
	partial class LimeGameChatForm
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
			this.cb_MessageType = new System.Windows.Forms.ComboBox();
			this.tb_SendMsg = new System.Windows.Forms.TextBox();
			this.b_OpenChatGroupForm = new System.Windows.Forms.Button();
			this.b_Logout = new System.Windows.Forms.Button();
			this.lb_textBox = new System.Windows.Forms.ListBox();
			this.b_Report = new System.Windows.Forms.Button();
			this.b_Block = new System.Windows.Forms.Button();
			this.b_OpenPrivateChatForm = new System.Windows.Forms.Button();
			this.label_NickName = new System.Windows.Forms.Label();
			this.b_UserStatus = new System.Windows.Forms.Button();
			this.b_JoinedRoom = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cb_MessageType
			// 
			this.cb_MessageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_MessageType.Enabled = false;
			this.cb_MessageType.FormattingEnabled = true;
			this.cb_MessageType.Location = new System.Drawing.Point(0, 225);
			this.cb_MessageType.Name = "cb_MessageType";
			this.cb_MessageType.Size = new System.Drawing.Size(155, 20);
			this.cb_MessageType.TabIndex = 24;
			// 
			// tb_SendMsg
			// 
			this.tb_SendMsg.Enabled = false;
			this.tb_SendMsg.Location = new System.Drawing.Point(157, 225);
			this.tb_SendMsg.Name = "tb_SendMsg";
			this.tb_SendMsg.Size = new System.Drawing.Size(254, 21);
			this.tb_SendMsg.TabIndex = 23;
			this.tb_SendMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_SendMsg_KeyDown);
			// 
			// b_OpenChatGroupForm
			// 
			this.b_OpenChatGroupForm.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.b_OpenChatGroupForm.Location = new System.Drawing.Point(414, 50);
			this.b_OpenChatGroupForm.Name = "b_OpenChatGroupForm";
			this.b_OpenChatGroupForm.Size = new System.Drawing.Size(73, 24);
			this.b_OpenChatGroupForm.TabIndex = 22;
			this.b_OpenChatGroupForm.Text = "그룹 채팅";
			this.b_OpenChatGroupForm.UseVisualStyleBackColor = true;
			this.b_OpenChatGroupForm.Click += new System.EventHandler(this.b_OpenChatGroupForm_Click);
			// 
			// b_Logout
			// 
			this.b_Logout.Font = new System.Drawing.Font("굴림", 8.25F);
			this.b_Logout.Location = new System.Drawing.Point(414, 26);
			this.b_Logout.Name = "b_Logout";
			this.b_Logout.Size = new System.Drawing.Size(73, 24);
			this.b_Logout.TabIndex = 26;
			this.b_Logout.Text = "Logout";
			this.b_Logout.UseVisualStyleBackColor = true;
			this.b_Logout.Click += new System.EventHandler(this.b_Logout_Click);
			// 
			// lb_textBox
			// 
			this.lb_textBox.FormattingEnabled = true;
			this.lb_textBox.ItemHeight = 12;
			this.lb_textBox.Location = new System.Drawing.Point(0, 26);
			this.lb_textBox.Name = "lb_textBox";
			this.lb_textBox.Size = new System.Drawing.Size(411, 196);
			this.lb_textBox.TabIndex = 27;
			// 
			// b_Report
			// 
			this.b_Report.Enabled = false;
			this.b_Report.Font = new System.Drawing.Font("굴림", 8.25F);
			this.b_Report.Location = new System.Drawing.Point(413, 146);
			this.b_Report.Name = "b_Report";
			this.b_Report.Size = new System.Drawing.Size(73, 24);
			this.b_Report.TabIndex = 28;
			this.b_Report.Text = "신 고";
			this.b_Report.UseVisualStyleBackColor = true;
			this.b_Report.Click += new System.EventHandler(this.b_Report_Click);
			// 
			// b_Block
			// 
			this.b_Block.Enabled = false;
			this.b_Block.Font = new System.Drawing.Font("굴림", 8.25F);
			this.b_Block.Location = new System.Drawing.Point(413, 122);
			this.b_Block.Name = "b_Block";
			this.b_Block.Size = new System.Drawing.Size(73, 24);
			this.b_Block.TabIndex = 29;
			this.b_Block.Text = "차 단";
			this.b_Block.UseVisualStyleBackColor = true;
			// 
			// b_OpenPrivateChatForm
			// 
			this.b_OpenPrivateChatForm.Font = new System.Drawing.Font("굴림", 8.25F);
			this.b_OpenPrivateChatForm.Location = new System.Drawing.Point(414, 74);
			this.b_OpenPrivateChatForm.Name = "b_OpenPrivateChatForm";
			this.b_OpenPrivateChatForm.Size = new System.Drawing.Size(73, 24);
			this.b_OpenPrivateChatForm.TabIndex = 30;
			this.b_OpenPrivateChatForm.Text = "1:1 채팅";
			this.b_OpenPrivateChatForm.UseVisualStyleBackColor = true;
			this.b_OpenPrivateChatForm.Click += new System.EventHandler(this.b_OpenPrivateChatForm_Click);
			// 
			// label_NickName
			// 
			this.label_NickName.AutoSize = true;
			this.label_NickName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
			this.label_NickName.Location = new System.Drawing.Point(7, 5);
			this.label_NickName.Name = "label_NickName";
			this.label_NickName.Size = new System.Drawing.Size(73, 12);
			this.label_NickName.TabIndex = 31;
			this.label_NickName.Text = "UserName";
			// 
			// b_UserStatus
			// 
			this.b_UserStatus.Font = new System.Drawing.Font("굴림", 8.25F);
			this.b_UserStatus.Location = new System.Drawing.Point(413, 170);
			this.b_UserStatus.Name = "b_UserStatus";
			this.b_UserStatus.Size = new System.Drawing.Size(73, 24);
			this.b_UserStatus.TabIndex = 32;
			this.b_UserStatus.Text = "상태 정보";
			this.b_UserStatus.UseVisualStyleBackColor = true;
			this.b_UserStatus.Click += new System.EventHandler(this.b_UserStatus_Click);
			// 
			// b_JoinedRoom
			// 
			this.b_JoinedRoom.Font = new System.Drawing.Font("굴림", 8.25F);
			this.b_JoinedRoom.Location = new System.Drawing.Point(414, 98);
			this.b_JoinedRoom.Name = "b_JoinedRoom";
			this.b_JoinedRoom.Size = new System.Drawing.Size(72, 24);
			this.b_JoinedRoom.TabIndex = 33;
			this.b_JoinedRoom.Text = "채팅룸 갱신";
			this.b_JoinedRoom.UseVisualStyleBackColor = true;
			// 
			// LimeGameChatForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 249);
			this.ControlBox = false;
			this.Controls.Add(this.b_JoinedRoom);
			this.Controls.Add(this.b_UserStatus);
			this.Controls.Add(this.label_NickName);
			this.Controls.Add(this.b_OpenPrivateChatForm);
			this.Controls.Add(this.b_Block);
			this.Controls.Add(this.b_Report);
			this.Controls.Add(this.lb_textBox);
			this.Controls.Add(this.b_Logout);
			this.Controls.Add(this.cb_MessageType);
			this.Controls.Add(this.tb_SendMsg);
			this.Controls.Add(this.b_OpenChatGroupForm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "LimeGameChatForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox cb_MessageType;
		private System.Windows.Forms.TextBox tb_SendMsg;
		private System.Windows.Forms.Button b_OpenChatGroupForm;
		private System.Windows.Forms.Button b_Logout;
		private System.Windows.Forms.ListBox lb_textBox;
		private System.Windows.Forms.Button b_Report;
		private System.Windows.Forms.Button b_Block;
		private System.Windows.Forms.Button b_OpenPrivateChatForm;
		private System.Windows.Forms.Label label_NickName;
		private System.Windows.Forms.Button b_UserStatus;
		private System.Windows.Forms.Button b_JoinedRoom;
	}
}