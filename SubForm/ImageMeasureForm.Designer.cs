namespace demo.SubForm
{
    partial class ImageMeasureForm
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
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.TB_CurrentImage = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.BT_BeforeImage = new Sunny.UI.UIButton();
            this.BT_NextImage = new Sunny.UI.UIButton();
            this.BT_measureFromFile = new Sunny.UI.UIButton();
            this.BT_Stop = new Sunny.UI.UIButton();
            this.BT_ImageFileSelect = new Sunny.UI.UIButton();
            this.TB_SelectedFolderPath = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.BT_AutoMeasure = new Sunny.UI.UIButton();
            this.BT_measureContinue = new Sunny.UI.UIButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.TB_imagePath = new Sunny.UI.UITextBox();
            this.BT_ImageSelect = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.BT_measureFormImage = new Sunny.UI.UIButton();
            this.CB_CameraSelect = new Sunny.UI.UIComboBox();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.uiGroupBox1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(977, 355);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.TB_CurrentImage);
            this.uiGroupBox1.Controls.Add(this.uiLabel4);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox1.Controls.Add(this.uiGroupBox2);
            this.uiGroupBox1.Controls.Add(this.CB_CameraSelect);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(977, 355);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "图片测量";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_CurrentImage
            // 
            this.TB_CurrentImage.CausesValidation = false;
            this.TB_CurrentImage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_CurrentImage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_CurrentImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TB_CurrentImage.Location = new System.Drawing.Point(370, 30);
            this.TB_CurrentImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_CurrentImage.MinimumSize = new System.Drawing.Size(1, 16);
            this.TB_CurrentImage.Name = "TB_CurrentImage";
            this.TB_CurrentImage.Padding = new System.Windows.Forms.Padding(5);
            this.TB_CurrentImage.ReadOnly = true;
            this.TB_CurrentImage.ShowText = false;
            this.TB_CurrentImage.Size = new System.Drawing.Size(197, 29);
            this.TB_CurrentImage.TabIndex = 13;
            this.TB_CurrentImage.Text = "xxx.jpg";
            this.TB_CurrentImage.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_CurrentImage.Watermark = "";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(249, 30);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(100, 29);
            this.uiLabel4.TabIndex = 12;
            this.uiLabel4.Text = "图片名称";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(12, 30);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 29);
            this.uiLabel3.TabIndex = 11;
            this.uiLabel3.Text = "相机选择";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.BT_BeforeImage);
            this.uiGroupBox3.Controls.Add(this.BT_NextImage);
            this.uiGroupBox3.Controls.Add(this.BT_measureFromFile);
            this.uiGroupBox3.Controls.Add(this.BT_Stop);
            this.uiGroupBox3.Controls.Add(this.BT_ImageFileSelect);
            this.uiGroupBox3.Controls.Add(this.TB_SelectedFolderPath);
            this.uiGroupBox3.Controls.Add(this.uiLabel2);
            this.uiGroupBox3.Controls.Add(this.BT_AutoMeasure);
            this.uiGroupBox3.Controls.Add(this.BT_measureContinue);
            this.uiGroupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(4, 154);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(720, 172);
            this.uiGroupBox3.TabIndex = 10;
            this.uiGroupBox3.Text = "批量图片测量";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BT_BeforeImage
            // 
            this.BT_BeforeImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_BeforeImage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_BeforeImage.Location = new System.Drawing.Point(483, 74);
            this.BT_BeforeImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_BeforeImage.Name = "BT_BeforeImage";
            this.BT_BeforeImage.Size = new System.Drawing.Size(80, 29);
            this.BT_BeforeImage.TabIndex = 10;
            this.BT_BeforeImage.Text = "上一张";
            this.BT_BeforeImage.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_BeforeImage.Click += new System.EventHandler(this.BT_BeforeImage_Click);
            // 
            // BT_NextImage
            // 
            this.BT_NextImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_NextImage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_NextImage.Location = new System.Drawing.Point(382, 74);
            this.BT_NextImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_NextImage.Name = "BT_NextImage";
            this.BT_NextImage.Size = new System.Drawing.Size(80, 29);
            this.BT_NextImage.TabIndex = 9;
            this.BT_NextImage.Text = "下一张";
            this.BT_NextImage.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_NextImage.Click += new System.EventHandler(this.BT_NextImage_Click);
            // 
            // BT_measureFromFile
            // 
            this.BT_measureFromFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_measureFromFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_measureFromFile.Location = new System.Drawing.Point(638, 32);
            this.BT_measureFromFile.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_measureFromFile.Name = "BT_measureFromFile";
            this.BT_measureFromFile.Size = new System.Drawing.Size(64, 29);
            this.BT_measureFromFile.TabIndex = 8;
            this.BT_measureFromFile.Text = "测量";
            this.BT_measureFromFile.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_measureFromFile.Click += new System.EventHandler(this.BT_measureFromFile_Click);
            // 
            // BT_Stop
            // 
            this.BT_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_Stop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Stop.Location = new System.Drawing.Point(275, 74);
            this.BT_Stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(80, 29);
            this.BT_Stop.TabIndex = 3;
            this.BT_Stop.Text = "停止";
            this.BT_Stop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_Stop.Click += new System.EventHandler(this.BT_Stop_Click);
            // 
            // BT_ImageFileSelect
            // 
            this.BT_ImageFileSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_ImageFileSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_ImageFileSelect.Location = new System.Drawing.Point(556, 35);
            this.BT_ImageFileSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_ImageFileSelect.Name = "BT_ImageFileSelect";
            this.BT_ImageFileSelect.Size = new System.Drawing.Size(38, 29);
            this.BT_ImageFileSelect.TabIndex = 2;
            this.BT_ImageFileSelect.Text = "...";
            this.BT_ImageFileSelect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_ImageFileSelect.Click += new System.EventHandler(this.BT_ImageFileSelect_Click);
            // 
            // TB_SelectedFolderPath
            // 
            this.TB_SelectedFolderPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_SelectedFolderPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_SelectedFolderPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TB_SelectedFolderPath.Location = new System.Drawing.Point(133, 32);
            this.TB_SelectedFolderPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_SelectedFolderPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.TB_SelectedFolderPath.Name = "TB_SelectedFolderPath";
            this.TB_SelectedFolderPath.Padding = new System.Windows.Forms.Padding(5);
            this.TB_SelectedFolderPath.ReadOnly = true;
            this.TB_SelectedFolderPath.ShowText = false;
            this.TB_SelectedFolderPath.Size = new System.Drawing.Size(406, 29);
            this.TB_SelectedFolderPath.TabIndex = 1;
            this.TB_SelectedFolderPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_SelectedFolderPath.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(8, 32);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(118, 29);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "文件夹选择";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_AutoMeasure
            // 
            this.BT_AutoMeasure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_AutoMeasure.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_AutoMeasure.Location = new System.Drawing.Point(8, 74);
            this.BT_AutoMeasure.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_AutoMeasure.Name = "BT_AutoMeasure";
            this.BT_AutoMeasure.Size = new System.Drawing.Size(114, 29);
            this.BT_AutoMeasure.TabIndex = 0;
            this.BT_AutoMeasure.Text = "自动测量";
            this.BT_AutoMeasure.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_AutoMeasure.Click += new System.EventHandler(this.BT_AutoMeasure_Click);
            // 
            // BT_measureContinue
            // 
            this.BT_measureContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_measureContinue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_measureContinue.Location = new System.Drawing.Point(133, 74);
            this.BT_measureContinue.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_measureContinue.Name = "BT_measureContinue";
            this.BT_measureContinue.Size = new System.Drawing.Size(127, 29);
            this.BT_measureContinue.TabIndex = 1;
            this.BT_measureContinue.Text = "继续自动测量";
            this.BT_measureContinue.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_measureContinue.Click += new System.EventHandler(this.BT_measureContinue_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.TB_imagePath);
            this.uiGroupBox2.Controls.Add(this.BT_ImageSelect);
            this.uiGroupBox2.Controls.Add(this.uiLabel1);
            this.uiGroupBox2.Controls.Add(this.BT_measureFormImage);
            this.uiGroupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 69);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(720, 75);
            this.uiGroupBox2.TabIndex = 9;
            this.uiGroupBox2.Text = "单张图片测量";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_imagePath
            // 
            this.TB_imagePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TB_imagePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_imagePath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TB_imagePath.Location = new System.Drawing.Point(133, 32);
            this.TB_imagePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_imagePath.MinimumSize = new System.Drawing.Size(1, 16);
            this.TB_imagePath.Name = "TB_imagePath";
            this.TB_imagePath.Padding = new System.Windows.Forms.Padding(5);
            this.TB_imagePath.ReadOnly = true;
            this.TB_imagePath.ShowText = false;
            this.TB_imagePath.Size = new System.Drawing.Size(406, 29);
            this.TB_imagePath.TabIndex = 3;
            this.TB_imagePath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TB_imagePath.Watermark = "";
            // 
            // BT_ImageSelect
            // 
            this.BT_ImageSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_ImageSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_ImageSelect.Location = new System.Drawing.Point(556, 32);
            this.BT_ImageSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_ImageSelect.Name = "BT_ImageSelect";
            this.BT_ImageSelect.Size = new System.Drawing.Size(38, 29);
            this.BT_ImageSelect.TabIndex = 2;
            this.BT_ImageSelect.Text = "...";
            this.BT_ImageSelect.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_ImageSelect.Click += new System.EventHandler(this.BT_ImageSelect_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(8, 32);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 29);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "图片选择";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_measureFormImage
            // 
            this.BT_measureFormImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BT_measureFormImage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_measureFormImage.Location = new System.Drawing.Point(637, 32);
            this.BT_measureFormImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.BT_measureFormImage.Name = "BT_measureFormImage";
            this.BT_measureFormImage.Size = new System.Drawing.Size(65, 29);
            this.BT_measureFormImage.TabIndex = 0;
            this.BT_measureFormImage.Text = "测量";
            this.BT_measureFormImage.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BT_measureFormImage.Click += new System.EventHandler(this.BT_measureFormImage_Click);
            // 
            // CB_CameraSelect
            // 
            this.CB_CameraSelect.DataSource = null;
            this.CB_CameraSelect.FillColor = System.Drawing.Color.White;
            this.CB_CameraSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CB_CameraSelect.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CB_CameraSelect.Items.AddRange(new object[] {
            "相机1",
            "相机2",
            "相机3",
            "相机4",
            "相机5",
            "相机6"});
            this.CB_CameraSelect.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CB_CameraSelect.Location = new System.Drawing.Point(122, 30);
            this.CB_CameraSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_CameraSelect.MinimumSize = new System.Drawing.Size(63, 0);
            this.CB_CameraSelect.Name = "CB_CameraSelect";
            this.CB_CameraSelect.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CB_CameraSelect.Size = new System.Drawing.Size(93, 29);
            this.CB_CameraSelect.SymbolSize = 24;
            this.CB_CameraSelect.TabIndex = 4;
            this.CB_CameraSelect.Text = "相机1";
            this.CB_CameraSelect.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CB_CameraSelect.Watermark = "";
            this.CB_CameraSelect.SelectedIndexChanged += new System.EventHandler(this.CB_CameraSelect_SelectedIndexChanged);
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.uiTextBox1.Location = new System.Drawing.Point(118, 32);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(600, 29);
            this.uiTextBox1.TabIndex = 1;
            this.uiTextBox1.Text = "uiTextBox1";
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // ImageMeasureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 355);
            this.Controls.Add(this.uiPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImageMeasureForm";
            this.Text = "ImageMeasureForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageMeasureForm_FormClosed);
            this.uiPanel1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIButton BT_measureContinue;
        private Sunny.UI.UIComboBox CB_CameraSelect;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UIButton BT_measureFromFile;
        private Sunny.UI.UIButton BT_Stop;
        private Sunny.UI.UIButton BT_ImageFileSelect;
        public Sunny.UI.UITextBox TB_SelectedFolderPath;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton BT_AutoMeasure;
        public Sunny.UI.UITextBox TB_CurrentImage;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIButton BT_ImageSelect;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton BT_measureFormImage;
        public Sunny.UI.UITextBox uiTextBox1;
        public Sunny.UI.UITextBox TB_imagePath;
        private Sunny.UI.UIButton BT_BeforeImage;
        private Sunny.UI.UIButton BT_NextImage;
    }
}