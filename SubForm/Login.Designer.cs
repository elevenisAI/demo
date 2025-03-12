namespace demo.SubForm
{
    partial class Login
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
            this.uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            this.txtUsername = new Sunny.UI.UITextBox();
            this.txtPassword = new Sunny.UI.UITextBox();
            this.uiSmoothLabel2 = new Sunny.UI.UISmoothLabel();
            this.BTenter = new Sunny.UI.UIButton();
            this.BTesc = new Sunny.UI.UIButton();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.BTChangepassword = new Sunny.UI.UIButton();
            this.txtCurrentPassword = new Sunny.UI.UITextBox();
            this.txtNewPassword = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.LBtip = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtConfirmNewPassword = new Sunny.UI.UITextBox();
            this.BTConfirmTheChanges = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiSmoothLabel1
            // 
            this.uiSmoothLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSmoothLabel1.Location = new System.Drawing.Point(41, 30);
            this.uiSmoothLabel1.Name = "uiSmoothLabel1";
            this.uiSmoothLabel1.Size = new System.Drawing.Size(434, 33);
            this.uiSmoothLabel1.TabIndex = 0;
            this.uiSmoothLabel1.Text = "用户：";
            // 
            // txtUsername
            // 
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.Font = new System.Drawing.Font("宋体", 12F);
            this.txtUsername.Location = new System.Drawing.Point(101, 30);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsername.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(5);
            this.txtUsername.ShowText = false;
            this.txtUsername.Size = new System.Drawing.Size(207, 28);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Admin";
            this.txtUsername.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtUsername.Watermark = "";
            // 
            // txtPassword
            // 
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPassword.Location = new System.Drawing.Point(101, 73);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ShowText = false;
            this.txtPassword.Size = new System.Drawing.Size(207, 29);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPassword.Watermark = "";
            // 
            // uiSmoothLabel2
            // 
            this.uiSmoothLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSmoothLabel2.Location = new System.Drawing.Point(41, 73);
            this.uiSmoothLabel2.Name = "uiSmoothLabel2";
            this.uiSmoothLabel2.Size = new System.Drawing.Size(434, 33);
            this.uiSmoothLabel2.TabIndex = 3;
            this.uiSmoothLabel2.Text = "密码：";
            // 
            // BTenter
            // 
            this.BTenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTenter.Font = new System.Drawing.Font("宋体", 12F);
            this.BTenter.Location = new System.Drawing.Point(105, 136);
            this.BTenter.MinimumSize = new System.Drawing.Size(1, 1);
            this.BTenter.Name = "BTenter";
            this.BTenter.Size = new System.Drawing.Size(77, 35);
            this.BTenter.TabIndex = 4;
            this.BTenter.Text = "登录";
            this.BTenter.Click += new System.EventHandler(this.BTenter_Click);
            // 
            // BTesc
            // 
            this.BTesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTesc.Font = new System.Drawing.Font("宋体", 12F);
            this.BTesc.Location = new System.Drawing.Point(231, 136);
            this.BTesc.MinimumSize = new System.Drawing.Size(1, 1);
            this.BTesc.Name = "BTesc";
            this.BTesc.Size = new System.Drawing.Size(77, 35);
            this.BTesc.TabIndex = 5;
            this.BTesc.Text = "取消";
            this.BTesc.Click += new System.EventHandler(this.BTesc_Click);
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.Font = new System.Drawing.Font("宋体", 12F);
            this.uiButton3.Location = new System.Drawing.Point(315, 73);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(100, 29);
            this.uiButton3.TabIndex = 6;
            this.uiButton3.Text = "显示输入";
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // BTChangepassword
            // 
            this.BTChangepassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTChangepassword.Font = new System.Drawing.Font("宋体", 12F);
            this.BTChangepassword.Location = new System.Drawing.Point(315, 138);
            this.BTChangepassword.MinimumSize = new System.Drawing.Size(1, 1);
            this.BTChangepassword.Name = "BTChangepassword";
            this.BTChangepassword.Size = new System.Drawing.Size(100, 35);
            this.BTChangepassword.TabIndex = 7;
            this.BTChangepassword.Text = "修改密码";
            this.BTChangepassword.Click += new System.EventHandler(this.BTChangepassword_Click);
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.txtCurrentPassword.Location = new System.Drawing.Point(137, 179);
            this.txtCurrentPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCurrentPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txtCurrentPassword.ShowText = false;
            this.txtCurrentPassword.Size = new System.Drawing.Size(171, 29);
            this.txtCurrentPassword.TabIndex = 9;
            this.txtCurrentPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCurrentPassword.Visible = false;
            this.txtCurrentPassword.Watermark = "";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.txtNewPassword.Location = new System.Drawing.Point(137, 210);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txtNewPassword.ShowText = false;
            this.txtNewPassword.Size = new System.Drawing.Size(171, 29);
            this.txtNewPassword.TabIndex = 10;
            this.txtNewPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNewPassword.Visible = false;
            this.txtNewPassword.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(12, 179);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(118, 23);
            this.uiLabel1.TabIndex = 11;
            this.uiLabel1.Text = "旧密码：";
            this.uiLabel1.Visible = false;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(12, 216);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(118, 23);
            this.uiLabel2.TabIndex = 12;
            this.uiLabel2.Text = "新密码：";
            this.uiLabel2.Visible = false;
            // 
            // LBtip
            // 
            this.LBtip.Font = new System.Drawing.Font("宋体", 12F);
            this.LBtip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LBtip.Location = new System.Drawing.Point(101, 105);
            this.LBtip.Name = "LBtip";
            this.LBtip.Size = new System.Drawing.Size(207, 28);
            this.LBtip.TabIndex = 13;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(12, 249);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(118, 23);
            this.uiLabel3.TabIndex = 14;
            this.uiLabel3.Text = "确认密码：";
            this.uiLabel3.Visible = false;
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmNewPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(137, 243);
            this.txtConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmNewPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txtConfirmNewPassword.ShowText = false;
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(171, 29);
            this.txtConfirmNewPassword.TabIndex = 15;
            this.txtConfirmNewPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtConfirmNewPassword.Visible = false;
            this.txtConfirmNewPassword.Watermark = "";
            // 
            // BTConfirmTheChanges
            // 
            this.BTConfirmTheChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTConfirmTheChanges.Font = new System.Drawing.Font("宋体", 12F);
            this.BTConfirmTheChanges.Location = new System.Drawing.Point(315, 179);
            this.BTConfirmTheChanges.MinimumSize = new System.Drawing.Size(1, 1);
            this.BTConfirmTheChanges.Name = "BTConfirmTheChanges";
            this.BTConfirmTheChanges.Size = new System.Drawing.Size(100, 93);
            this.BTConfirmTheChanges.TabIndex = 17;
            this.BTConfirmTheChanges.Text = "确认修改";
            this.BTConfirmTheChanges.Visible = false;
            this.BTConfirmTheChanges.Click += new System.EventHandler(this.BTConfirmTheChanges_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 285);
            this.Controls.Add(this.BTConfirmTheChanges);
            this.Controls.Add(this.txtConfirmNewPassword);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.LBtip);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.BTChangepassword);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.BTesc);
            this.Controls.Add(this.BTenter);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.uiSmoothLabel2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.uiSmoothLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private Sunny.UI.UITextBox txtUsername;
        private Sunny.UI.UITextBox txtPassword;
        private Sunny.UI.UISmoothLabel uiSmoothLabel2;
        private Sunny.UI.UIButton BTenter;
        private Sunny.UI.UIButton BTesc;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton BTChangepassword;
        private Sunny.UI.UITextBox txtCurrentPassword;
        private Sunny.UI.UITextBox txtNewPassword;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel LBtip;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtConfirmNewPassword;
        private Sunny.UI.UIButton BTConfirmTheChanges;
    }
}