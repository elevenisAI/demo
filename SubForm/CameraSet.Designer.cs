namespace demo.SubForm
{
    partial class CameraSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraSet));
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.BTlogin = new Sunny.UI.UIHeaderButton();
            this.TBpassword = new Sunny.UI.UITextBox();
            this.TBName = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.TBPORT = new Sunny.UI.UITextBox();
            this.TBIP = new Sunny.UI.UIIPTextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.NB_BinarizeM = new RexControl.UCNumTextBox();
            this.BT_Save = new Sunny.UI.UIButton();
            this.ucNumTextBox3 = new RexControl.UCNumTextBox();
            this.LB_const = new Sunny.UI.UILabel();
            this.ucNumTextBox2 = new RexControl.UCNumTextBox();
            this.LB_BLsize = new Sunny.UI.UILabel();
            this.NB_Binarize = new RexControl.UCNumTextBox();
            this.CB_BinarizeMode = new Sunny.UI.UIComboBox();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.ucNumTextBox1 = new RexControl.UCNumTextBox();
            this.BTModelSelect = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiCheckBoxGroup1 = new Sunny.UI.UICheckBoxGroup();
            this.CBcamera = new System.Windows.Forms.ComboBox();
            this.LBcamera = new Sunny.UI.UILabel();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiGroupBox1.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.uiGroupBox4.SuspendLayout();
            this.uiCheckBoxGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiPanel1);
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(2, 91);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1336, 178);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "相机IP设置";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.BTlogin);
            this.uiPanel1.Controls.Add(this.TBpassword);
            this.uiPanel1.Controls.Add(this.TBName);
            this.uiPanel1.Controls.Add(this.uiLabel7);
            this.uiPanel1.Controls.Add(this.uiLabel6);
            this.uiPanel1.Controls.Add(this.TBPORT);
            this.uiPanel1.Controls.Add(this.TBIP);
            this.uiPanel1.Controls.Add(this.uiLabel5);
            this.uiPanel1.Controls.Add(this.uiLabel4);
            this.uiPanel1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(4, 37);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1170, 140);
            this.uiPanel1.TabIndex = 2;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTlogin
            // 
            this.BTlogin.Font = new System.Drawing.Font("宋体", 12F);
            this.BTlogin.Image = ((System.Drawing.Image)(resources.GetObject("BTlogin.Image")));
            this.BTlogin.Location = new System.Drawing.Point(607, 63);
            this.BTlogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.BTlogin.Name = "BTlogin";
            this.BTlogin.Padding = new System.Windows.Forms.Padding(0, 8, 0, 3);
            this.BTlogin.Radius = 0;
            this.BTlogin.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.BTlogin.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.BTlogin.Size = new System.Drawing.Size(81, 29);
            this.BTlogin.TabIndex = 8;
            this.BTlogin.Text = "登录";
            this.BTlogin.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTlogin.Click += new System.EventHandler(this.BTlogin_Click);
            // 
            // TBpassword
            // 
            this.TBpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBpassword.Font = new System.Drawing.Font("宋体", 12F);
            this.TBpassword.Location = new System.Drawing.Point(443, 63);
            this.TBpassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBpassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBpassword.Name = "TBpassword";
            this.TBpassword.Padding = new System.Windows.Forms.Padding(5);
            this.TBpassword.ShowText = false;
            this.TBpassword.Size = new System.Drawing.Size(141, 29);
            this.TBpassword.TabIndex = 7;
            this.TBpassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TBpassword.Watermark = "";
            // 
            // TBName
            // 
            this.TBName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBName.Font = new System.Drawing.Font("宋体", 12F);
            this.TBName.Location = new System.Drawing.Point(136, 63);
            this.TBName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBName.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBName.Name = "TBName";
            this.TBName.Padding = new System.Windows.Forms.Padding(5);
            this.TBName.ShowText = false;
            this.TBName.Size = new System.Drawing.Size(150, 29);
            this.TBName.TabIndex = 6;
            this.TBName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TBName.Watermark = "";
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel7.Location = new System.Drawing.Point(330, 69);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(150, 23);
            this.uiLabel7.TabIndex = 5;
            this.uiLabel7.Text = "Pwd(密码)：";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(3, 69);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(150, 23);
            this.uiLabel6.TabIndex = 4;
            this.uiLabel6.Text = "Name(用户名)：";
            // 
            // TBPORT
            // 
            this.TBPORT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBPORT.Font = new System.Drawing.Font("宋体", 12F);
            this.TBPORT.Location = new System.Drawing.Point(443, 16);
            this.TBPORT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBPORT.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBPORT.Name = "TBPORT";
            this.TBPORT.Padding = new System.Windows.Forms.Padding(5);
            this.TBPORT.ShowText = false;
            this.TBPORT.Size = new System.Drawing.Size(141, 29);
            this.TBPORT.TabIndex = 3;
            this.TBPORT.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TBPORT.Watermark = "";
            // 
            // TBIP
            // 
            this.TBIP.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TBIP.Font = new System.Drawing.Font("宋体", 12F);
            this.TBIP.Location = new System.Drawing.Point(136, 16);
            this.TBIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBIP.MinimumSize = new System.Drawing.Size(1, 1);
            this.TBIP.Name = "TBIP";
            this.TBIP.Padding = new System.Windows.Forms.Padding(1);
            this.TBIP.ShowText = false;
            this.TBIP.Size = new System.Drawing.Size(150, 29);
            this.TBIP.TabIndex = 1;
            this.TBIP.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(330, 22);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(140, 23);
            this.uiLabel5.TabIndex = 2;
            this.uiLabel5.Text = "Port(端口)：";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(3, 22);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(150, 23);
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "IP(设备地址)：";
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox2.Controls.Add(this.uiButton3);
            this.uiGroupBox2.Controls.Add(this.uiButton2);
            this.uiGroupBox2.Controls.Add(this.uiLabel3);
            this.uiGroupBox2.Controls.Add(this.ucNumTextBox1);
            this.uiGroupBox2.Controls.Add(this.BTModelSelect);
            this.uiGroupBox2.Controls.Add(this.uiLabel2);
            this.uiGroupBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.uiGroupBox2.Location = new System.Drawing.Point(2, 266);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(1174, 559);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "相机算法设置";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.uiGroupBox4);
            this.uiGroupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(11, 90);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(947, 247);
            this.uiGroupBox3.TabIndex = 6;
            this.uiGroupBox3.Text = null;
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.uiLabel1);
            this.uiGroupBox4.Controls.Add(this.NB_BinarizeM);
            this.uiGroupBox4.Controls.Add(this.BT_Save);
            this.uiGroupBox4.Controls.Add(this.ucNumTextBox3);
            this.uiGroupBox4.Controls.Add(this.LB_const);
            this.uiGroupBox4.Controls.Add(this.ucNumTextBox2);
            this.uiGroupBox4.Controls.Add(this.LB_BLsize);
            this.uiGroupBox4.Controls.Add(this.NB_Binarize);
            this.uiGroupBox4.Controls.Add(this.CB_BinarizeMode);
            this.uiGroupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox4.Location = new System.Drawing.Point(0, 21);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Size = new System.Drawing.Size(943, 88);
            this.uiGroupBox4.TabIndex = 5;
            this.uiGroupBox4.Text = "传统算法";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NB_BinarizeM
            // 
            this.NB_BinarizeM.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NB_BinarizeM.InputType = RexControl.Text.TextInputType.Number;
            this.NB_BinarizeM.IsNumCanInput = true;
            this.NB_BinarizeM.KeyBoardType = RexControl.Text.KeyBoardType.UCKeyBorderNum;
            this.NB_BinarizeM.Location = new System.Drawing.Point(273, 58);
            this.NB_BinarizeM.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NB_BinarizeM.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NB_BinarizeM.Name = "NB_BinarizeM";
            this.NB_BinarizeM.Num = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NB_BinarizeM.Padding = new System.Windows.Forms.Padding(2);
            this.NB_BinarizeM.Size = new System.Drawing.Size(118, 27);
            this.NB_BinarizeM.TabIndex = 9;
            // 
            // BT_Save
            // 
            this.BT_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Save.Font = new System.Drawing.Font("宋体", 12F);
            this.BT_Save.Location = new System.Drawing.Point(777, 31);
            this.BT_Save.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(100, 35);
            this.BT_Save.TabIndex = 7;
            this.BT_Save.Text = "保存";
            this.BT_Save.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // ucNumTextBox3
            // 
            this.ucNumTextBox3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucNumTextBox3.InputType = RexControl.Text.TextInputType.Number;
            this.ucNumTextBox3.IsNumCanInput = true;
            this.ucNumTextBox3.KeyBoardType = RexControl.Text.KeyBoardType.UCKeyBorderNum;
            this.ucNumTextBox3.Location = new System.Drawing.Point(624, 48);
            this.ucNumTextBox3.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ucNumTextBox3.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucNumTextBox3.Name = "ucNumTextBox3";
            this.ucNumTextBox3.Num = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ucNumTextBox3.Padding = new System.Windows.Forms.Padding(2);
            this.ucNumTextBox3.Size = new System.Drawing.Size(147, 27);
            this.ucNumTextBox3.TabIndex = 8;
            // 
            // LB_const
            // 
            this.LB_const.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_const.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LB_const.Location = new System.Drawing.Point(620, 22);
            this.LB_const.Name = "LB_const";
            this.LB_const.Size = new System.Drawing.Size(151, 23);
            this.LB_const.TabIndex = 7;
            this.LB_const.Text = "默认常数";
            this.LB_const.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ucNumTextBox2
            // 
            this.ucNumTextBox2.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ucNumTextBox2.InputType = RexControl.Text.TextInputType.Number;
            this.ucNumTextBox2.IsNumCanInput = true;
            this.ucNumTextBox2.KeyBoardType = RexControl.Text.KeyBoardType.UCKeyBorderNum;
            this.ucNumTextBox2.Location = new System.Drawing.Point(467, 48);
            this.ucNumTextBox2.MaxValue = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.ucNumTextBox2.MinValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ucNumTextBox2.Name = "ucNumTextBox2";
            this.ucNumTextBox2.Num = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.ucNumTextBox2.Padding = new System.Windows.Forms.Padding(2);
            this.ucNumTextBox2.Size = new System.Drawing.Size(147, 27);
            this.ucNumTextBox2.TabIndex = 6;
            // 
            // LB_BLsize
            // 
            this.LB_BLsize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_BLsize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LB_BLsize.Location = new System.Drawing.Point(463, 22);
            this.LB_BLsize.Name = "LB_BLsize";
            this.LB_BLsize.Size = new System.Drawing.Size(151, 23);
            this.LB_BLsize.TabIndex = 5;
            this.LB_BLsize.Text = "块大小";
            this.LB_BLsize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NB_Binarize
            // 
            this.NB_Binarize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NB_Binarize.InputType = RexControl.Text.TextInputType.Number;
            this.NB_Binarize.IsNumCanInput = true;
            this.NB_Binarize.KeyBoardType = RexControl.Text.KeyBoardType.UCKeyBorderNum;
            this.NB_Binarize.Location = new System.Drawing.Point(273, 22);
            this.NB_Binarize.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NB_Binarize.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NB_Binarize.Name = "NB_Binarize";
            this.NB_Binarize.Num = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NB_Binarize.Padding = new System.Windows.Forms.Padding(2);
            this.NB_Binarize.Size = new System.Drawing.Size(118, 33);
            this.NB_Binarize.TabIndex = 4;
            // 
            // CB_BinarizeMode
            // 
            this.CB_BinarizeMode.DataSource = null;
            this.CB_BinarizeMode.FillColor = System.Drawing.Color.White;
            this.CB_BinarizeMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_BinarizeMode.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CB_BinarizeMode.Items.AddRange(new object[] {
            "AdaptiveGaussian"});
            this.CB_BinarizeMode.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CB_BinarizeMode.Location = new System.Drawing.Point(116, 37);
            this.CB_BinarizeMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_BinarizeMode.MinimumSize = new System.Drawing.Size(63, 0);
            this.CB_BinarizeMode.Name = "CB_BinarizeMode";
            this.CB_BinarizeMode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CB_BinarizeMode.Size = new System.Drawing.Size(150, 29);
            this.CB_BinarizeMode.SymbolSize = 24;
            this.CB_BinarizeMode.TabIndex = 1;
            this.CB_BinarizeMode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CB_BinarizeMode.Watermark = "";
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.Font = new System.Drawing.Font("宋体", 12F);
            this.uiButton3.Location = new System.Drawing.Point(399, 377);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(100, 35);
            this.uiButton3.TabIndex = 5;
            this.uiButton3.Text = "取消";
            this.uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("宋体", 12F);
            this.uiButton2.Location = new System.Drawing.Point(102, 377);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(100, 35);
            this.uiButton2.TabIndex = 4;
            this.uiButton2.Text = "保存";
            this.uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(177, 62);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(113, 23);
            this.uiLabel3.TabIndex = 3;
            this.uiLabel3.Text = "置信度";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ucNumTextBox1
            // 
            this.ucNumTextBox1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ucNumTextBox1.InputType = RexControl.Text.TextInputType.Number;
            this.ucNumTextBox1.IsNumCanInput = true;
            this.ucNumTextBox1.KeyBoardType = RexControl.Text.KeyBoardType.UCKeyBorderNum;
            this.ucNumTextBox1.Location = new System.Drawing.Point(19, 58);
            this.ucNumTextBox1.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ucNumTextBox1.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucNumTextBox1.Name = "ucNumTextBox1";
            this.ucNumTextBox1.Num = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.ucNumTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.ucNumTextBox1.Size = new System.Drawing.Size(143, 27);
            this.ucNumTextBox1.TabIndex = 2;
            // 
            // BTModelSelect
            // 
            this.BTModelSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTModelSelect.FillColor2 = System.Drawing.Color.White;
            this.BTModelSelect.FillHoverColor = System.Drawing.Color.White;
            this.BTModelSelect.FillPressColor = System.Drawing.Color.IndianRed;
            this.BTModelSelect.FillSelectedColor = System.Drawing.Color.DarkSalmon;
            this.BTModelSelect.Font = new System.Drawing.Font("宋体", 12F);
            this.BTModelSelect.ForeColor = System.Drawing.Color.LightGray;
            this.BTModelSelect.ForeHoverColor = System.Drawing.Color.RosyBrown;
            this.BTModelSelect.ForePressColor = System.Drawing.Color.RosyBrown;
            this.BTModelSelect.ForeSelectedColor = System.Drawing.Color.RosyBrown;
            this.BTModelSelect.Location = new System.Drawing.Point(181, 33);
            this.BTModelSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.BTModelSelect.Name = "BTModelSelect";
            this.BTModelSelect.RectColor = System.Drawing.Color.White;
            this.BTModelSelect.RectHoverColor = System.Drawing.Color.White;
            this.BTModelSelect.Size = new System.Drawing.Size(109, 22);
            this.BTModelSelect.TabIndex = 1;
            this.BTModelSelect.Text = "模型选择";
            this.BTModelSelect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTModelSelect.Click += new System.EventHandler(this.BTModelSelect_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(19, 32);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(143, 23);
            this.uiLabel2.TabIndex = 0;
            // 
            // uiCheckBoxGroup1
            // 
            this.uiCheckBoxGroup1.Controls.Add(this.CBcamera);
            this.uiCheckBoxGroup1.Controls.Add(this.LBcamera);
            this.uiCheckBoxGroup1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiCheckBoxGroup1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.uiCheckBoxGroup1.Location = new System.Drawing.Point(2, -3);
            this.uiCheckBoxGroup1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiCheckBoxGroup1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBoxGroup1.Name = "uiCheckBoxGroup1";
            this.uiCheckBoxGroup1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiCheckBoxGroup1.SelectedIndexes = ((System.Collections.Generic.List<int>)(resources.GetObject("uiCheckBoxGroup1.SelectedIndexes")));
            this.uiCheckBoxGroup1.Size = new System.Drawing.Size(1174, 120);
            this.uiCheckBoxGroup1.TabIndex = 2;
            this.uiCheckBoxGroup1.Text = "相机选择";
            this.uiCheckBoxGroup1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CBcamera
            // 
            this.CBcamera.FormattingEnabled = true;
            this.CBcamera.Location = new System.Drawing.Point(19, 35);
            this.CBcamera.Name = "CBcamera";
            this.CBcamera.Size = new System.Drawing.Size(290, 28);
            this.CBcamera.TabIndex = 2;
            // 
            // LBcamera
            // 
            this.LBcamera.Font = new System.Drawing.Font("宋体", 12F);
            this.LBcamera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.LBcamera.Location = new System.Drawing.Point(334, 40);
            this.LBcamera.Name = "LBcamera";
            this.LBcamera.Size = new System.Drawing.Size(140, 23);
            this.LBcamera.TabIndex = 1;
            this.LBcamera.Visible = false;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(4, 37);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(98, 29);
            this.uiLabel1.TabIndex = 10;
            this.uiLabel1.Text = "二值化";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CameraSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 794);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiCheckBoxGroup1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "CameraSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "相机设置";
            this.Load += new System.EventHandler(this.CameraSet_Load);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox4.ResumeLayout(false);
            this.uiCheckBoxGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UICheckBoxGroup uiCheckBoxGroup1;
        private Sunny.UI.UILabel LBcamera;
        private Sunny.UI.UIButton BTModelSelect;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private RexControl.UCNumTextBox ucNumTextBox1;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITextBox TBpassword;
        private Sunny.UI.UITextBox TBName;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox TBPORT;
        private Sunny.UI.UIIPTextBox TBIP;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIHeaderButton BTlogin;
        private System.Windows.Forms.ComboBox CBcamera;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UIComboBox CB_BinarizeMode;
        private RexControl.UCNumTextBox NB_Binarize;
        private Sunny.UI.UIGroupBox uiGroupBox4;
        private RexControl.UCNumTextBox ucNumTextBox2;
        private Sunny.UI.UILabel LB_BLsize;
        private RexControl.UCNumTextBox ucNumTextBox3;
        private Sunny.UI.UILabel LB_const;
        private Sunny.UI.UIButton BT_Save;
        private RexControl.UCNumTextBox NB_BinarizeM;
        private Sunny.UI.UILabel uiLabel1;
    }
}