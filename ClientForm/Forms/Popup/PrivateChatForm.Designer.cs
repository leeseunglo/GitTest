
namespace ClientForm
{
	partial class PrivateChatForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.tb_NickName = new System.Windows.Forms.TextBox();
			this.b_Create = new System.Windows.Forms.Button();
			this.b_Cancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cb_RoomType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("굴림", 9F);
			this.label1.Location = new System.Drawing.Point(19, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "닉네임";
			// 
			// tb_NickName
			// 
			this.tb_NickName.Font = new System.Drawing.Font("굴림", 9F);
			this.tb_NickName.Location = new System.Drawing.Point(63, 8);
			this.tb_NickName.Name = "tb_NickName";
			this.tb_NickName.Size = new System.Drawing.Size(131, 21);
			this.tb_NickName.TabIndex = 1;
			this.tb_NickName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// b_Create
			// 
			this.b_Create.Location = new System.Drawing.Point(30, 65);
			this.b_Create.Name = "b_Create";
			this.b_Create.Size = new System.Drawing.Size(72, 26);
			this.b_Create.TabIndex = 3;
			this.b_Create.Text = "만들기";
			this.b_Create.UseVisualStyleBackColor = true;
			this.b_Create.Click += new System.EventHandler(this.b_Create_Click);
			// 
			// b_Cancel
			// 
			this.b_Cancel.Location = new System.Drawing.Point(106, 65);
			this.b_Cancel.Name = "b_Cancel";
			this.b_Cancel.Size = new System.Drawing.Size(72, 26);
			this.b_Cancel.TabIndex = 4;
			this.b_Cancel.Text = "취소";
			this.b_Cancel.UseVisualStyleBackColor = true;
			this.b_Cancel.Click += new System.EventHandler(this.b_Cancel_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("굴림", 9F);
			this.label2.Location = new System.Drawing.Point(3, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "채팅 종류";
			// 
			// cb_RoomType
			// 
			this.cb_RoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_RoomType.FormattingEnabled = true;
			this.cb_RoomType.Location = new System.Drawing.Point(63, 35);
			this.cb_RoomType.Name = "cb_RoomType";
			this.cb_RoomType.Size = new System.Drawing.Size(131, 20);
			this.cb_RoomType.TabIndex = 6;
			// 
			// PrivateChatForm
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(201, 97);
			this.ControlBox = false;
			this.Controls.Add(this.cb_RoomType);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.b_Cancel);
			this.Controls.Add(this.b_Create);
			this.Controls.Add(this.tb_NickName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "PrivateChatForm";
			this.Text = "1:1 ChatForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tb_NickName;
		private System.Windows.Forms.Button b_Create;
		private System.Windows.Forms.Button b_Cancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cb_RoomType;
	}
}