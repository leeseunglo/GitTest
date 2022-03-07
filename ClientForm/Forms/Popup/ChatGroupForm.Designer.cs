namespace ClientForm
{
	partial class ChatGroupForm
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
			this.tb_RoomKey = new System.Windows.Forms.TextBox();
			this.tb_ServerKey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.b_Create = new System.Windows.Forms.Button();
			this.b_Join = new System.Windows.Forms.Button();
			this.b_Leave = new System.Windows.Forms.Button();
			this.b_Cancel = new System.Windows.Forms.Button();
			this.cb_RoomType = new System.Windows.Forms.ComboBox();
			this.cb_JoinedRoom = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tb_RoomKey
			// 
			this.tb_RoomKey.Location = new System.Drawing.Point(83, 93);
			this.tb_RoomKey.Name = "tb_RoomKey";
			this.tb_RoomKey.Size = new System.Drawing.Size(132, 21);
			this.tb_RoomKey.TabIndex = 3;
			this.tb_RoomKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tb_ServerKey
			// 
			this.tb_ServerKey.Location = new System.Drawing.Point(83, 65);
			this.tb_ServerKey.Name = "tb_ServerKey";
			this.tb_ServerKey.Size = new System.Drawing.Size(132, 21);
			this.tb_ServerKey.TabIndex = 2;
			this.tb_ServerKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(43, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 12);
			this.label1.TabIndex = 10;
			this.label1.Text = "Type";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 12);
			this.label2.TabIndex = 11;
			this.label2.Text = "ServerKey";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "RoomKey";
			// 
			// b_Create
			// 
			this.b_Create.Location = new System.Drawing.Point(47, 124);
			this.b_Create.Name = "b_Create";
			this.b_Create.Size = new System.Drawing.Size(86, 27);
			this.b_Create.TabIndex = 4;
			this.b_Create.Text = "생성";
			this.b_Create.UseVisualStyleBackColor = true;
			this.b_Create.Click += new System.EventHandler(this.b_Create_Click);
			// 
			// b_Join
			// 
			this.b_Join.Location = new System.Drawing.Point(135, 124);
			this.b_Join.Name = "b_Join";
			this.b_Join.Size = new System.Drawing.Size(86, 27);
			this.b_Join.TabIndex = 5;
			this.b_Join.Text = "입장";
			this.b_Join.UseVisualStyleBackColor = true;
			this.b_Join.Click += new System.EventHandler(this.b_Join_Click);
			// 
			// b_Leave
			// 
			this.b_Leave.Location = new System.Drawing.Point(47, 154);
			this.b_Leave.Name = "b_Leave";
			this.b_Leave.Size = new System.Drawing.Size(86, 27);
			this.b_Leave.TabIndex = 6;
			this.b_Leave.Text = "퇴장";
			this.b_Leave.UseVisualStyleBackColor = true;
			this.b_Leave.Click += new System.EventHandler(this.b_Leave_Click);
			// 
			// b_Cancel
			// 
			this.b_Cancel.Location = new System.Drawing.Point(135, 153);
			this.b_Cancel.Name = "b_Cancel";
			this.b_Cancel.Size = new System.Drawing.Size(86, 28);
			this.b_Cancel.TabIndex = 7;
			this.b_Cancel.Text = "취소";
			this.b_Cancel.UseVisualStyleBackColor = true;
			this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
			// 
			// cb_RoomType
			// 
			this.cb_RoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_RoomType.FormattingEnabled = true;
			this.cb_RoomType.Location = new System.Drawing.Point(83, 38);
			this.cb_RoomType.Name = "cb_RoomType";
			this.cb_RoomType.Size = new System.Drawing.Size(132, 20);
			this.cb_RoomType.TabIndex = 1;
			this.cb_RoomType.SelectedIndexChanged += new System.EventHandler(this.cb_RoomType_SelectedIndexChanged);
			// 
			// cb_JoinedRoom
			// 
			this.cb_JoinedRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_JoinedRoom.Enabled = false;
			this.cb_JoinedRoom.FormattingEnabled = true;
			this.cb_JoinedRoom.Location = new System.Drawing.Point(83, 12);
			this.cb_JoinedRoom.Name = "cb_JoinedRoom";
			this.cb_JoinedRoom.Size = new System.Drawing.Size(132, 20);
			this.cb_JoinedRoom.TabIndex = 13;
			this.cb_JoinedRoom.SelectedIndexChanged += new System.EventHandler(this.cb_JoinRoom_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 12);
			this.label4.TabIndex = 14;
			this.label4.Text = "JoinRoom";
			// 
			// ChatGroupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 186);
			this.Controls.Add(this.cb_JoinedRoom);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cb_RoomType);
			this.Controls.Add(this.b_Cancel);
			this.Controls.Add(this.b_Leave);
			this.Controls.Add(this.b_Join);
			this.Controls.Add(this.b_Create);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tb_ServerKey);
			this.Controls.Add(this.tb_RoomKey);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ChatGroupForm";
			this.Text = "ChatGroupForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox tb_RoomKey;
		private System.Windows.Forms.TextBox tb_ServerKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button b_Create;
		private System.Windows.Forms.Button b_Join;
		private System.Windows.Forms.Button b_Leave;
		private System.Windows.Forms.Button b_Cancel;
		private System.Windows.Forms.ComboBox cb_RoomType;
		private System.Windows.Forms.ComboBox cb_JoinedRoom;
		private System.Windows.Forms.Label label4;
	}
}