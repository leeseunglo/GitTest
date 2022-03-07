namespace ClientForm
{
    partial class ServerInfoForm
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
			this.b_Remove = new System.Windows.Forms.Button();
			this.b_Close = new System.Windows.Forms.Button();
			this.tb_ServerName = new System.Windows.Forms.TextBox();
			this.tb_ServerAddress = new System.Windows.Forms.TextBox();
			this.b_Add = new System.Windows.Forms.Button();
			this.cb_ServerList = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// b_Remove
			// 
			this.b_Remove.Location = new System.Drawing.Point(189, 96);
			this.b_Remove.Name = "b_Remove";
			this.b_Remove.Size = new System.Drawing.Size(53, 34);
			this.b_Remove.TabIndex = 0;
			this.b_Remove.Text = "삭제";
			this.b_Remove.UseVisualStyleBackColor = true;
			this.b_Remove.Click += new System.EventHandler(this.b_Remove_Click);
			// 
			// b_Close
			// 
			this.b_Close.Location = new System.Drawing.Point(244, 96);
			this.b_Close.Name = "b_Close";
			this.b_Close.Size = new System.Drawing.Size(53, 34);
			this.b_Close.TabIndex = 1;
			this.b_Close.Text = "닫기";
			this.b_Close.UseVisualStyleBackColor = true;
			this.b_Close.Click += new System.EventHandler(this.b_Close_Click);
			// 
			// tb_ServerName
			// 
			this.tb_ServerName.Location = new System.Drawing.Point(72, 42);
			this.tb_ServerName.Name = "tb_ServerName";
			this.tb_ServerName.Size = new System.Drawing.Size(225, 21);
			this.tb_ServerName.TabIndex = 2;
			this.tb_ServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tb_ServerAddress
			// 
			this.tb_ServerAddress.Location = new System.Drawing.Point(72, 69);
			this.tb_ServerAddress.Name = "tb_ServerAddress";
			this.tb_ServerAddress.Size = new System.Drawing.Size(225, 21);
			this.tb_ServerAddress.TabIndex = 3;
			this.tb_ServerAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// b_Add
			// 
			this.b_Add.Location = new System.Drawing.Point(134, 96);
			this.b_Add.Name = "b_Add";
			this.b_Add.Size = new System.Drawing.Size(53, 34);
			this.b_Add.TabIndex = 5;
			this.b_Add.Text = "추가";
			this.b_Add.UseVisualStyleBackColor = true;
			this.b_Add.Click += new System.EventHandler(this.b_Add_Click);
			// 
			// cb_ServerList
			// 
			this.cb_ServerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_ServerList.FormattingEnabled = true;
			this.cb_ServerList.Location = new System.Drawing.Point(163, 12);
			this.cb_ServerList.Name = "cb_ServerList";
			this.cb_ServerList.Size = new System.Drawing.Size(134, 20);
			this.cb_ServerList.TabIndex = 4;
			this.cb_ServerList.SelectedIndexChanged += new System.EventHandler(this.cb_ServerList_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(56, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "추가된 서버 정보";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "서버 이름";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "서버 주소";
			// 
			// ServerInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(307, 140);
			this.ControlBox = false;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.b_Add);
			this.Controls.Add(this.cb_ServerList);
			this.Controls.Add(this.tb_ServerAddress);
			this.Controls.Add(this.tb_ServerName);
			this.Controls.Add(this.b_Close);
			this.Controls.Add(this.b_Remove);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ServerInfoForm";
			this.Text = "서버 정보 관리";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_Remove;
        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.TextBox tb_ServerName;
        private System.Windows.Forms.TextBox tb_ServerAddress;
        private System.Windows.Forms.Button b_Add;
        private System.Windows.Forms.ComboBox cb_ServerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
	}
}