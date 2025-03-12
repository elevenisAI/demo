namespace demo.SubForm
{
    partial class AutoStart
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
            this.CboxAutoStart = new Sunny.UI.UICheckBox();
            this.BTSave = new Sunny.UI.UIButton();
            this.BTEsc = new Sunny.UI.UIButton();
            this.LBState = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // CboxAutoStart
            // 
            this.CboxAutoStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CboxAutoStart.Font = new System.Drawing.Font("宋体", 12F);
            this.CboxAutoStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.CboxAutoStart.Location = new System.Drawing.Point(12, 12);
            this.CboxAutoStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.CboxAutoStart.Name = "CboxAutoStart";
            this.CboxAutoStart.Size = new System.Drawing.Size(150, 29);
            this.CboxAutoStart.TabIndex = 0;
            this.CboxAutoStart.Text = "开机自启动";
            // 
            // BTSave
            // 
            this.BTSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTSave.Font = new System.Drawing.Font("宋体", 12F);
            this.BTSave.Location = new System.Drawing.Point(41, 118);
            this.BTSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(63, 23);
            this.BTSave.TabIndex = 1;
            this.BTSave.Text = "保存";
            this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
            // 
            // BTEsc
            // 
            this.BTEsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTEsc.Font = new System.Drawing.Font("宋体", 12F);
            this.BTEsc.Location = new System.Drawing.Point(243, 118);
            this.BTEsc.MinimumSize = new System.Drawing.Size(1, 1);
            this.BTEsc.Name = "BTEsc";
            this.BTEsc.Size = new System.Drawing.Size(63, 23);
            this.BTEsc.TabIndex = 2;
            this.BTEsc.Text = "取消";
            this.BTEsc.Click += new System.EventHandler(this.BTEsc_Click);
            // 
            // LBState
            // 
            this.LBState.Font = new System.Drawing.Font("宋体", 12F);
            this.LBState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LBState.Location = new System.Drawing.Point(122, 118);
            this.LBState.Name = "LBState";
            this.LBState.Size = new System.Drawing.Size(100, 23);
            this.LBState.TabIndex = 3;
            // 
            // AutoStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 153);
            this.Controls.Add(this.LBState);
            this.Controls.Add(this.BTEsc);
            this.Controls.Add(this.BTSave);
            this.Controls.Add(this.CboxAutoStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AutoStart";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.AutoStart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UICheckBox CboxAutoStart;
        private Sunny.UI.UIButton BTSave;
        private Sunny.UI.UIButton BTEsc;
        private Sunny.UI.UILabel LBState;
    }
}