using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using demo.Algorithm;
using demo.Cameras;
using demo.Helps;
using demo.ImageTools;
using demo.log4net;
using demo.Properties;
using demo.SubForm;
using log;
using log4net.Core;
using NetSDKCS;
using OpenCvSharp;
using Rex.UI;
using RexControl;
using RexHelps;
using Sunny.UI;
using static System.Net.Mime.MediaTypeNames;
using static demo.Algorithm.opencvAlgorithm;


namespace demo
{
    public partial class MainForm : Form

    {
        /// <summary>
        /// 图片测量工具窗口暂停自动测量标志位
        /// </summary>
        public static bool isAutoMeasuring = false;
        /// <summary>
        /// 自动测量文件夹图片索引
        /// </summary>
        public static int currentIndex = 0;
        public static IEnumerable<string> imageFoldPath = null;
        /// <summary>
        /// 图片测量工具窗口选择的当前测量相机
        /// </summary>
        public static string measureSelectCamera;
        /// <summary>
        /// 图片测量工具窗口
        /// </summary>
        public static ImageMeasureForm imageMeasureForm;
        /// <summary>
     /// ini文件读取
     /// </summary>
        public static RIni ini = new RIni(Path.Combine(System.Windows.Forms.Application.StartupPath, "CameraConfig.ini"));
        public static RIni iniSetting = new RIni(Path.Combine(System.Windows.Forms.Application.StartupPath, "SettingConfig.ini"));
        /// <summary>
        /// 相机设置二值化传值
        /// </summary>
        public static BinarizationMethod method;
        public static int maxValue;
        public static int blockSize;
        public static int constant;
        public static int threshold;
        /// <summary>
        /// 控制取流频率计数
        /// </summary>
        int id;
        public static long camerFrameRate = 48;
        /// <summary>
        /// 预览标志位
        /// </summary>
        public static bool isPreviewingOne = false; // 用于记录是否正在预览
        public static bool isManualMeasure = false;
        /// <summary>
        /// 图片转换算法工具对象
        /// </summary>
        public ImageConversion imageConversion = new ImageConversion();//图片转换算法工具对象
        /// <summary>
        /// 回调函数设置，几个相机几个回调函数
        /// </summary>
        private static fRealDataCallBackEx2 m_RealDataCallBackEx2;
        /// <summary>
        /// 程序是否正在运行标志位
        /// </summary>
        public static bool isRunning = false;//程序开始检测标志位
        CameraSet cameraSetForm;
        /// <summary>
        /// 权限设置枚举
        /// </summary>
        public static Permission.Role userRole = Permission.Role.Operator;
        /// <summary>
        /// 计时器以及状态栏
        /// </summary>
        private Timer timer = null;
        private PerformanceCounter privateBytesCounter;//监控内存字节变量
        /// <summary>
        /// 二值化算法开关标志
        /// </summary>
        public bool isBinary = false;

        public MainForm()
        {
            // 检测磁盘剩余容量，防止存图系统硬盘容量卡死
            if (!CheckDiskSpace())
            {
                // 如果剩余容量小于 25%，关闭软件
                MessageBox.Show("磁盘剩余容量不足 25%，软件将关闭。", "磁盘空间不足", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Windows.Forms.Application.Exit();
                Environment.Exit(1);
            }
            // 初始化 PerformanceCounter 来监控私有字节
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            privateBytesCounter = new PerformanceCounter("Process", "Private Bytes", Process.GetCurrentProcess().ProcessName);
            m_RealDataCallBackEx2 = new fRealDataCallBackEx2(RealDataCallBack);//设置回调
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Log.LoadConfig("D:\\cSharp\\y\\demo\\log4net.config");
            Log.InitializeRichTextBox(this.RichTextBoxLog);
            ShowTime();
            // 自动加载相机配置
            LoadBinarizationParameters();
            cNumericUpDown1.Value = double.Parse(iniSetting.ReadValue("Config", "FrameRate", "48"));
        }
        /// <summary>
        /// 开机自启动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开机自启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoStart autoForm = new AutoStart(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            autoForm.ShowDialog();
        }
        /// <summary>
        /// 账户权限登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTLogin_Click(object sender, EventArgs e)
        {
            SubForm.Login loginForm = new SubForm.Login(this);
            loginForm.ShowDialog();
        }
       
       
        #region 上下文菜单相机设置窗口
        private void CameraSetForm_OnBinarizationParametersChanged(BinarizationMethod _method, int _threshold, int _maxValue, int _blockSize, int _constant)
        {
            method = _method;
            threshold = _threshold;
            maxValue = _maxValue;
            blockSize = _blockSize;
            constant = _constant;
        }
        /// <summary>
        /// 相机设置可以在此处更新添加订阅事件
        /// </summary>
        private void ShowCameraSetForm()
        {
            if (cameraSetForm == null || cameraSetForm.IsDisposed)
            {

                cameraSetForm = new CameraSet();
                // 订阅事件
                cameraSetForm.OnBinarizationParametersChanged += CameraSetForm_OnBinarizationParametersChanged;
                // 可以在这里设置窗体的其他属性，例如窗体的StartPosition
                cameraSetForm.StartPosition = FormStartPosition.CenterScreen;
            }
            cameraSetForm.Show();
        }
        /// <summary>
        /// 相机设置ui窗口显示，带有权限验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 相机设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userRole == Permission.Role.Admin)
            {
                ShowCameraSetForm();
            }
            else
            {
                Log.WriteInfo("权限不足");
            }
        }


        private void 相机设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (userRole == Permission.Role.Admin)
            {
                ShowCameraSetForm();
            }
            else
            {
                Log.WriteInfo("权限不足");
            }
        }

        private void 相机设置ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (userRole == Permission.Role.Admin)
            {
                ShowCameraSetForm();
            }
            else
            {
                Log.WriteInfo("权限不足");
            }
        }

        private void 相机设置ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (userRole == Permission.Role.Admin)
            {
                ShowCameraSetForm();
            }
            else
            {
                Log.WriteInfo("权限不足");
            }
        }

        private void 相机设置ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (userRole == Permission.Role.Admin)
            {
                ShowCameraSetForm();
            }
            else
            {
                Log.WriteInfo("权限不足");
            }
        }

        private void 相机设置ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (userRole == Permission.Role.Admin)
            {
                ShowCameraSetForm();
            }
            else
            {
                Log.WriteInfo("权限不足");
            }
        }
        #endregion

        #region 工具栏相机设置按钮
        /// <summary>
        /// 工具栏与右键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 相机设定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userRole == Permission.Role.Admin)
                ShowCameraSetForm();

        }


        #endregion
        #region 改变登陆后标签
        public void UpdateLoginStatusLabel(string message)
        {
            if (this.loginStatusLabel.InvokeRequired)
            {
                this.loginStatusLabel.BeginInvoke(new Action<string>(UpdateLoginStatusLabel), message);
            }
            else
            {
                this.loginStatusLabel.Text = message;
            }
        }

        #endregion
        #region 退出登录按钮
        private void BTLoginOut_Click(object sender, EventArgs e)
        {
            if (userRole == Permission.Role.Admin)
            {
                userRole = Permission.Role.Operator;
                Log.WriteInfo("Admin用户登出");
                loginStatusLabel.Text = "Operator";
            }
            else
            {
                Log.WriteWarns("默认用户无法登出");
            }
        }
        #endregion

        #region 系统实时时间
        private void ShowTime()
        {
            // 定义格式化的时间字符串
            string formattedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 更新 UI 元素，例如 Label 来显示当前时间
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => Currenttime.Text = formattedTime));
            }
            else
            {
                Currenttime.Text = formattedTime;
            }

            // 如果 Timer 未启动，则启动它
            if (timer == null || !timer.Enabled)
            {
                timer = new Timer();
                timer.Interval = 1000; // 设置定时器间隔为1秒
                timer.Tick += (sender, e) => Timer_Tick(sender, e);
                timer.Start();
            }
        }
        /// <summary>
        /// 定时器 可启动多逻辑任务 默认定时器为1s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 更新UI元素，例如Label来显示当前时间
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => Currenttime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                Currenttime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            try
            {
                // 读取当前进程的私有字节数
                long privateBytesValue = (long)privateBytesCounter.NextValue();
                // 转换为兆字节并显示在UI上
                string memoryUsage = (privateBytesValue / (1024 * 1024)).ToString("0.00") + " MB";
                // 更新UI控件，例如 Label 控件
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() => LBmemory.Text = memoryUsage));
                }
                else
                {
                    LBmemory.Text = memoryUsage;
                }
            }
            catch (Exception ex)
            {
                // 处理可能出现的异常
                MessageBox.Show("Error retrieving memory usage: " + ex.Message);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            NETClient.Cleanup();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NETClient.Cleanup();
        }

        /// <summary>
        /// 相机1开启检测按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isPreviewingOne) // 如果当前未在预览
            {
                Camera camera = CameraManager.Instance.GetCamera("192.168.1.101");
                if (camera != null)
                {
                    camera.playID = NETClient.RealPlay(camera.loginID, 0, this.pictureBox1.Handle);
                    m_RealDataCallBackEx2 = new fRealDataCallBackEx2(RealDataCallBack);
                    bool s = NETClient.SetRealDataCallBack(camera.playID, m_RealDataCallBackEx2, IntPtr.Zero, EM_REALDATA_FLAG.YUV_DATA);

                    // 更新UI
                    isPreviewingOne = true;
                    开启ToolStripMenuItem.Text = "停止检测";
                    this.Invoke(new Action(() => Log.WriteInfo("相机1开启")));
                }
            }
            else // 如果当前正在预览
            {
                Camera camera = CameraManager.Instance.GetCamera("192.168.1.101");
                // 更新UI
                isPreviewingOne = false;
                if (camera != null)
                {
                    fRealDataCallBackEx2 m_RealDataCallBackEx2 = null;
                    NETClient.SetRealDataCallBack(camera.playID, m_RealDataCallBackEx2, IntPtr.Zero, EM_REALDATA_FLAG.YUV_DATA); // 清除回调
                    NETClient.StopRealPlay(camera.playID); // 停止预览
                    开启ToolStripMenuItem.Text = "开启检测";
                    this.Invoke(new Action(() => Log.WriteInfo("相机1停止")));
                    //this.Invoke(new Action(() => pictureBox1.Image = null));
                }
            }
        }
        #region 预览回调函数需要自己实现，每个相机都不一样   
        private async void RealDataCallBack(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr param, IntPtr pUser)
        {
            if (id == 20000) { id = 0; }
            id++;//控制取流频率
            if (id % camerFrameRate == 0)
            {
                if (!isPreviewingOne) return; // 如果未在预览，直接返回
                byte[] frameData = new byte[(int)dwBufSize];
                Marshal.Copy(pBuffer, frameData, 0, (int)dwBufSize);
                await ProcessFrameAsync(frameData);
            }

        }
        #endregion
        private async Task ProcessFrameAsync(byte[] frameData, Bitmap image = null)
        {
            if ((!isPreviewingOne || frameData == null)&&!isManualMeasure) return;
            if (frameData.Length != 1)
            {
                await Task.Run(() =>
                {
                    // 将 YUV 数据转换为 Bitmap
                    Bitmap tmp = ConvertYUVToBitmap(frameData, 1920, 1080);
                    // 将 Bitmap 转换为 Mat
                    Mat mat = imageConversion.BitmapToMat(tmp);
                    // 对 Mat 进行二值化处理
                    if (isBinary == true)
                    {
                        Mat binaryMat = opencvAlgorithm.Binarize(mat, method, threshold, maxValue, blockSize, constant);
                        Bitmap processedBitmap = imageConversion.MatToBitmap(binaryMat);

                        // 更新 UI
                        UpdatePictureBox(this.pictureBox2, processedBitmap);

                        // 释放资源
                        mat.Dispose();
                        binaryMat.Dispose();
                    }
                    else
                    {
                        UpdatePictureBox(this.pictureBox2, tmp);
                        mat.Dispose();
                    }

                });
            }
            else
            {
                if (isPreviewingOne) { Log.WriteWarns("请关闭实时检测后再开启图片测量！");return; }
                if (image != null&&frameData.Length == 1)
                {
                    await Task.Run(() =>
                    {
                        // 将 YUV 数据转换为 Bitmap
                        Bitmap tmp = image;
                        // 将 Bitmap 转换为 Mat
                        Mat mat = imageConversion.BitmapToMat(tmp);
                        // 对 Mat 进行二值化处理
                        if (isBinary == true)
                        {
                            Mat binaryMat = opencvAlgorithm.Binarize(mat, method, threshold, maxValue, blockSize, constant);
                            Bitmap processedBitmap = imageConversion.MatToBitmap(binaryMat);

                            // 更新 UI
                            UpdatePictureBox(this.pictureBox2, processedBitmap);

                            // 释放资源
                            mat.Dispose();
                            binaryMat.Dispose();
                        }
                        else
                        {
                            UpdatePictureBox(this.pictureBox2, tmp);
                            mat.Dispose();
                        }

                    });
                }
                
            }
        }
        /// <summary>
        /// 更新显示的picturebox方法
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="bitmap"></param>
        private void UpdatePictureBox(PictureBox pictureBox, Bitmap bitmap)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke(new Action(() =>
                {
                    UpdatePictureBox(pictureBox, bitmap);
                }));
            }
            else
            {
                pictureBox.Image?.Dispose(); // 释放旧的图像资源
                pictureBox.Image = bitmap;
            }
        }


        /// <summary>
        /// debug检测代码
        /// </summary>
        /// <param name="image"></param>
        private void DetectImage(Mat image)
        {
            // 在这里调用检测逻辑
            // 检测结果处理
            try
            {
                // 定义保存路径和文件名
                string savePath = "F:\\testImageSave\\相机1原图\\";
                string fileName = "captured_image_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";

                // 确保目录存在
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                // 保存二值化后的图像
                Cv2.ImWrite(savePath + fileName, image);
            }
            catch (Exception ex)
            {
                // 处理任何可能发生的异常
                Console.WriteLine($"Failed to save image: {ex.Message}");
            }
        }


        /// <summary>
        /// YUV转Bitmap
        /// </summary>
        /// <param name="yuvData"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Bitmap ConvertYUVToBitmap(byte[] yuvData, int width, int height)
        {
            int frameSize = width * height; // Y分量的大小
            int qFrameSize = frameSize / 4; // U和V分量的大小

            byte[] rgbData = new byte[width * height * 3]; // RGB数据缓冲区

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int yIndex = i * width + j;
                    int uIndex = (i / 2) * (width / 2) + (j / 2);
                    int vIndex = uIndex; // V分量的索引与U分量相同

                    int y = yuvData[yIndex] & 0xff;
                    int u = yuvData[frameSize + uIndex] & 0xff;
                    int v = yuvData[frameSize + qFrameSize + vIndex] & 0xff;

                    // YUV转RGB
                    int r = (int)(y + 1.402 * (v - 128));
                    int g = (int)(y - 0.34414 * (u - 128) - 0.71414 * (v - 128));
                    int b = (int)(y + 1.772 * (u - 128));

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    int rgbIndex = yIndex * 3;
                    rgbData[rgbIndex] = (byte)b;
                    rgbData[rgbIndex + 1] = (byte)g;
                    rgbData[rgbIndex + 2] = (byte)r;
                }
            }

            // 创建Bitmap并设置像素数据
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;
            Marshal.Copy(rgbData, 0, ptr, rgbData.Length);
            bitmap.UnlockBits(bmpData);

            return bitmap;
        }

        private async void 原图目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 定义要打开的文件夹路径
            string folderPath = "F:\\testImageSave\\";

            // 确保路径以反斜杠结尾
            if (!folderPath.EndsWith("\\"))
            {
                folderPath += "\\";
            }

            // 在后台线程中打开文件夹
            await Task.Run(() =>
            {
                try
                {
                    // 使用Process启动文件资源管理器
                    System.Diagnostics.Process.Start("explorer.exe", folderPath);
                }
                catch (Exception ex)
                {
                    // 异步更新UI以显示错误消息
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"无法打开文件夹: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }

        private void 保存图片ToolStripMenuItem1_Click(object sender, EventArgs e)
        {//
            SaveImage(pictureBox2);
        }
        /// <summary>
        /// 相机截屏目录
        /// </summary>
        /// <param name="pictureBox"></param>
        private void SaveImage(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("没有可保存的图片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 定义保存路径和文件名
            string savePath = "F:\\testImageSave\\shotcutImage";
            string fileName = "saved_image_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";

            // 确保目录存在
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            // 保存图片
            try
            {
                pictureBox.Image.Save(Path.Combine(savePath, fileName), ImageFormat.Jpeg);
                MessageBox.Show($"图片已保存到：{Path.Combine(savePath, fileName)}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存图片失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 二值化开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 切换 isBinary 的值
            isBinary = !isBinary;

            // 更新菜单项的文本以反映当前状态
            二值化开ToolStripMenuItem.Text = isBinary ? "二值化关" : "二值化开";
        }
        /// <summary>
        /// 相机1登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void 相机登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraManager.Instance.GetCamera("192.168.1.101") == null)
            {
                try
                {
                    string[] sections = ini.ReadSections();
                    foreach (string section in sections) {
                        if (section.StartsWith("Cameras1"))
                        {
                            string ip = ini.ReadValue(section, "IP", "");
                            string portText = ini.ReadValue(section, "Port", "");
                            string name = ini.ReadValue(section, "Name", "");
                            string password = ini.ReadValue(section, "Password", "");
                            ushort port;
                            ushort.TryParse(portText, out port);
                            Camera camera = new Camera(ip, port, name, password, 1);
                            bool loginSuccess = await Task.Run(() => camera.Login());
                            if (loginSuccess)
                            {
                                CameraManager.Instance.AddCamera(camera);
                                Log.WriteInfo("IP：" + ip + "登陆成功");
                            }
                            else 
                            {
                                Log.WriteErrors(ip+"检查输入配置是否有误");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteErrors(ex);
                    Log.WriteErrors("检查输入配置是否有误");
                }
            }
            else
            {
                Log.WriteWarns("相机已登录");
            }

        }
        /// <summary>
        /// 图片测量窗口显示，以及事件绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 图片测量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(imageMeasureForm != null&&!imageMeasureForm.IsDisposed)
            {
                imageMeasureForm.Show();
            }
            else
            {
                imageMeasureForm = new ImageMeasureForm();               
                imageMeasureForm.ImagePathSelected += ImageMeasureForm_ImageSelected;//图片测量事件
                imageMeasureForm.ImageFolderPathSelected += ImageMeasureForm_ImageFolderPathSelected;//文件夹选择事件
                imageMeasureForm.MeasureRequested += ImageMeasureForm_MeasureRequested;//单张测量事件
                imageMeasureForm.MeasureFoldRequested += ImageMeasureForm_MeasureRequested;
                imageMeasureForm.AutoMeasureRequested += AutoImageMeasure;
                imageMeasureForm.CloseWindowEvent += ImageMeasureForm_CloseWindowEvent; // 订阅子窗口关闭事件
                imageMeasureForm.NextImageRequested += ImageMeasureForm_NextImageRequested;//下一张图片事件
                imageMeasureForm.PreviousImageRequested += ImageMeasureForm_PreviousImageRequested;//上一张图片事件
                imageMeasureForm.ContinueAutoMeasure += ImageMeasureForm_ContinueMeasure;
                imageMeasureForm.Show();
            }
        }
        /// <summary>
        /// 更新手动测量标志位方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageMeasureForm_CloseWindowEvent(object sender, EventArgs e)
        {
            // 更新父窗口中的变量
            isManualMeasure = false;
        }
        /// <summary>
        /// 选择测量文件夹事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="selectedFolderPath"></param>
        public void ImageMeasureForm_ImageFolderPathSelected(object sender, string selectedFolderPath)
        {
            string folderPath = selectedFolderPath;
            IEnumerable<string> imagePaths = ImageEnumerator.EnumerateImagesInFolder(folderPath);
            imageFoldPath = imagePaths;//将获取的文件夹路径集合返回给主窗口的变量存储以便于测量文件夹方法使用
            if (imagePaths != null && imagePaths.Any())
            {
                measureSelectCamera = imageMeasureForm.imageMeasureCamera;
                //文件夹图片默认设置为第一张显示
                switch (measureSelectCamera)
                {
                    case "相机1":
                        System.Drawing.Image image = System.Drawing.Image.FromFile(imageFoldPath.ElementAtOrDefault(0));
                        Bitmap bitmap = new Bitmap(image);
                        pictureBox2.Image = bitmap;
                        GC.Collect(0);//回收第0代
                        break;
                    case "相机2":
                        pictureBox4.Image = null;
                        break;
                    case "相机3":
                        pictureBox6.Image = null;
                        break;
                    case "相机4":
                        pictureBox8.Image = null;
                        break;
                    case "相机5":
                        pictureBox10.Image = null;
                        break;
                    case "相机6":
                        pictureBox12.Image = null;
                        break;
                }
            }else
            {
                MessageBox.Show("未选择文件夹或文件夹为空。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }
        /// <summary>
        /// 继续测量事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ImageMeasureForm_ContinueMeasure(object sender, EventArgs e)
        {
           
            byte[] byteArray = new byte[1];
            switch (measureSelectCamera)
            {
                case "相机1":
                    if (currentIndex < imageFoldPath.Count() - 1 && isAutoMeasuring)
                    {
                        foreach (string imagePath in imageFoldPath)
                        {
                            if(isAutoMeasuring == false)
                            {
                                break;
                            }
                                // 在这里处理每个图片路径
                                System.Drawing.Image image = System.Drawing.Image.FromFile(imageFoldPath.ElementAt(currentIndex));
                                // 将Image转换为Bitmap
                                Bitmap bitmap = new Bitmap(image);
                                await ProcessFrameAsync(byteArray, bitmap);
                                currentIndex++;
                                await Task.Delay(1000);   
                        }
                    }
                    else
                    {
                        Log.WriteInfo("自动测量已停止！");
                    }
                    break;
                case "相机2":
                    // 执行测量操作
                    PerformMeasurement(pictureBox4);
                    break;
                case "相机3":
                    // 执行测量操作
                    PerformMeasurement(pictureBox6);
                    break;
                case "相机4":
                    // 执行测量操作
                    PerformMeasurement(pictureBox8);
                    break;
                case "相机5":
                    // 执行测量操作
                    PerformMeasurement(pictureBox10);
                    break;
                case "相机6":
                    // 执行测量操作
                    PerformMeasurement(pictureBox12);
                    break;
            }

        }

        /// <summary>
        /// 测量文件夹图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AutoImageMeasure(object sender, EventArgs e)
        {
            //imageFoldPath变量是子窗口事件传递的文件夹路径
            if (imageFoldPath!=null)
            {
                byte[] byteArray = new byte[1];
                switch (measureSelectCamera)
                {
                    case "相机1":
                        // 从文件路径加载图片
                        foreach (string imagePath in imageFoldPath)
                        {
                            if (isAutoMeasuring)
                            {
                                // 在这里处理每个图片路径
                                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                                // 将Image转换为Bitmap
                                Bitmap bitmap = new Bitmap(image);
                                await ProcessFrameAsync(byteArray, bitmap);
                                currentIndex++;
                                await Task.Delay(1000);
                            }
                            else
                            {
                                Log.WriteInfo("自动测量已停止！");
                                break;
                            }
                        }
                        
                        //PerformMeasurement(pictureBox2);
                        break;
                    case "相机2":
                        // 执行测量操作
                        PerformMeasurement(pictureBox4);
                        break;
                    case "相机3":
                        // 执行测量操作
                        PerformMeasurement(pictureBox6);
                        break;
                    case "相机4":
                        // 执行测量操作
                        PerformMeasurement(pictureBox8);
                        break;
                    case "相机5":
                        // 执行测量操作
                        PerformMeasurement(pictureBox10);
                        break;
                    case "相机6":
                        // 执行测量操作
                        PerformMeasurement(pictureBox12);
                        break;
                }
            } 
            
        }
        /// <summary>
        /// 从文件路径显示图片方法
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="pictureBox"></param>
        private void LoadAndDisplayImage(string imagePath,PictureBox pictureBox)
        {
            if (System.IO.File.Exists(imagePath))
            {
                pictureBox.Image = System.Drawing.Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("文件不存在！");
            }
        }
        /// <summary>
        /// 上一张图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageMeasureForm_PreviousImageRequested(object sender, EventArgs e)
        {
            
            measureSelectCamera = imageMeasureForm.imageMeasureCamera;
            switch (measureSelectCamera)
            {
                case "相机1":

                    if (currentIndex > 0)
                    {
                        currentIndex--;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox2);
                    }
                    break;
                case "相机2":
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox4);
                    }
                    break;
                case "相机3":
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox6);
                    }
                    break;
                case "相机4":
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox8);
                    }
                    break;
                case "相机5":
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox10);
                    }
                    break;
                case "相机6":
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox12);
                    }
                    break;
            }

        }
        /// <summary>
        /// 下一张图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageMeasureForm_NextImageRequested(object sender, EventArgs e)
        {
            measureSelectCamera = imageMeasureForm.imageMeasureCamera;
            switch (measureSelectCamera)
            {
                case "相机1":
                    if (currentIndex < imageFoldPath.Count() - 1)
                    {
                        currentIndex++;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox2);
                    }
                    break;
                case "相机2":
                    if (currentIndex < imageFoldPath.Count() - 1)
                    {
                        currentIndex++;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox4);
                    }
                    break;
                case "相机3":
                    if (currentIndex < imageFoldPath.Count() - 1)
                    {
                        currentIndex++;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox6);
                    }
                    break;
                case "相机4":
                    if (currentIndex < imageFoldPath.Count() - 1)
                    {
                        currentIndex++;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox8);
                    }
                    break;
                case "相机5":
                    if (currentIndex < imageFoldPath.Count() - 1)
                    {
                        currentIndex++;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox10);
                    }
                    break;
                case "相机6":
                    if (currentIndex < imageFoldPath.Count() - 1)
                    {
                        currentIndex++;
                        LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox12);
                    }
                    break;
            }
            
        }
        /// <summary>
        /// 图片测量显示到哪个picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="imagePath"></param>
        private void ImageMeasureForm_ImageSelected(object sender, string imagePath)
        {
            measureSelectCamera = imageMeasureForm.imageMeasureCamera;
            switch (measureSelectCamera)
            {
                case "相机1":
                    pictureBox2.Image = System.Drawing.Image.FromFile(imagePath);
                    break;
                case "相机2":
                    pictureBox4.Image = System.Drawing.Image.FromFile(imagePath);
                    break;
                case "相机3":
                    pictureBox6.Image = System.Drawing.Image.FromFile(imagePath);
                    break;
                case "相机4":
                    pictureBox8.Image = System.Drawing.Image.FromFile(imagePath);
                    break;
                case "相机5":
                    pictureBox10.Image = System.Drawing.Image.FromFile(imagePath);
                    break;
                case "相机6":
                    pictureBox12.Image = System.Drawing.Image.FromFile(imagePath);
                    break;
            }
            
        }
        /// <summary>
        /// 相机测量助手，单张图片测量按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageMeasureForm_MeasureRequested(object sender, EventArgs e)
        {
            switch (measureSelectCamera)
            {
                case "相机1":
                    // 执行测量操作
                    LoadAndDisplayImage(imageFoldPath.ElementAt(currentIndex), pictureBox2);
                    PerformMeasurement(pictureBox2);
                    break;
                case "相机2":
                    // 执行测量操作
                    PerformMeasurement(pictureBox4);
                    break;
                case "相机3":
                    // 执行测量操作
                    PerformMeasurement(pictureBox6);
                    break;
                case "相机4":
                    // 执行测量操作
                    PerformMeasurement(pictureBox8);
                    break;
                case "相机5":
                    // 执行测量操作
                    PerformMeasurement(pictureBox10);
                    break;
                case "相机6":
                    // 执行测量操作
                    PerformMeasurement(pictureBox12);
                    break;
            }
           
        }
        /// <summary>
        /// 相机测量方法逻辑
        /// </summary>
        private void PerformMeasurement(PictureBox pictureBoxImage)
        {           
            //测量图片的方法
            if (pictureBoxImage.Image != null)
            {
                byte[] byteArray = new byte[1];
                Bitmap bitmap = new Bitmap(pictureBoxImage.Image);
                ProcessFrameAsync(byteArray, bitmap);
                // 执行测量逻辑
     
            }
            else
            {
                MessageBox.Show("请先选择图片！");
            }
        }
        /// <summary>
        /// 加载参数配置
        /// </summary>
        private void LoadBinarizationParameters()
        {
            try
            {
                // 读取二值化参数
                string binarizeModeString = ini.ReadValue("Cameras1", "BinarizeMode");
                method = (BinarizationMethod)Enum.Parse(typeof(BinarizationMethod), binarizeModeString);

                string thresholdMinString = ini.ReadValue("Cameras1", "BinarizeMin", "128");
                threshold = int.Parse(thresholdMinString);

                string maxValueString = ini.ReadValue("Cameras1", "BinarizeMax", "255");
                maxValue = int.Parse(maxValueString);

                string blockSizeString = ini.ReadValue("Cameras1", "BlokSize", "3");
                blockSize = int.Parse(blockSizeString);

                string constantString = ini.ReadValue("Cameras1", "Const", "5");
                constant = int.Parse(constantString);

                Log.WriteInfo("二值化参数加载成功");
            }
            catch (Exception ex)
            {
                Log.WriteErrors("加载二值化参数失败：" + ex.Message);
            }
        }

        # region 系统监控函数
        private bool CheckDiskSpace()
        {
            try
            {
                // 指定要检测的磁盘分区
                string driveLetter = "D:";
                DriveInfo driveInfo = new DriveInfo(driveLetter);

                // 获取磁盘的总容量和剩余可用容量
                long totalSize = driveInfo.TotalSize; // 总容量（字节）
                long availableFreeSpace = driveInfo.AvailableFreeSpace; // 剩余可用容量（字节）

                // 计算剩余容量百分比
                double availablePercentage = (double)availableFreeSpace / totalSize * 100;

                // 输出结果
                Log.WriteInfo($"磁盘 {driveLetter} 的总容量为：{totalSize / (1024.0 * 1024 * 1024):F2} GB");
                Log.WriteInfo($"剩余可用容量为：{availableFreeSpace / (1024.0 * 1024 * 1024):F2} GB");
                Log.WriteInfo($"剩余容量百分比：{availablePercentage:F2}%");

                // 检查剩余容量是否小于 25%
                return availablePercentage >= 25.0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"检测磁盘空间时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 发生异常时，认为条件不满足
            }
        }
        #endregion
        #region 取流帧率控制
        /// <summary>
        /// 取流速度事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private async void cNumericUpDown1_ValueChanged(object sender, double value)
        {
            // 更新帧率
            camerFrameRate = 53 - (int)value;

            // 异步写入到 INI 文件
            await WriteFrameRateToIniAsync(value);
        }

        private async Task WriteFrameRateToIniAsync(double value)
        {
            await Task.Run(() =>
            {
                // 将帧率值写入到 INI 文件
                iniSetting.WriteValue("Config", "FrameRate", value.ToString());
            });
        }
        #endregion
        /// <summary>
        /// UI界面
        /// </summary>
        /// <param name="currentPictureBox"></param>
        /// <param name="otherPictureBoxes"></param>
        /// <param name="zoomWidth"></param>
        /// <param name="zoomHeight"></param>
        /// <param name="normalX"></param>
        /// <param name="normalY"></param>
        /// <param name="normalWidth"></param>
        /// <param name="normalHeight"></param>
        /// <param name="zoomX"></param>
        /// <param name="zoomY"></param>
        #region  窗口双击事件UI变化
        private void TogglePictureBoxZoom(PictureBox currentPictureBox,
                                   List<PictureBox> otherPictureBoxes,
                                   int zoomWidth, int zoomHeight,
                                   int normalX, int normalY,
                                   int normalWidth, int normalHeight, int zoomX = 12, int zoomY = 31)
        {
            // 检查当前PictureBox是否已经放大
            if (Convert.ToInt32(currentPictureBox.Tag) == 0)
            {
                // 隐藏其他PictureBox
                foreach (var pictureBox in otherPictureBoxes)
                {
                    pictureBox.Visible = false;
                }

                // 放大当前PictureBox
                currentPictureBox.Location = new System.Drawing.Point(zoomX, zoomY);
                currentPictureBox.Width = zoomWidth;
                currentPictureBox.Height = zoomHeight;
                currentPictureBox.Tag = 1; // 标记为已放大
            }
            else
            {
                // 恢复显示所有PictureBox
                foreach (var pictureBox in otherPictureBoxes)
                {
                    pictureBox.Visible = true;
                }

                // 恢复当前PictureBox的原始大小和位置
                currentPictureBox.Location = new System.Drawing.Point(normalX, normalY);
                currentPictureBox.Width = normalWidth;
                currentPictureBox.Height = normalHeight;
                currentPictureBox.Tag = 0; // 标记为未放大
            }
        }
        /// <summary>
        /// 相机1显示画面双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                // 定义其他PictureBox的集合
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6,
            pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12
        };

                // 调用通用方法
                TogglePictureBoxZoom(pictureBox1, otherPictureBoxes, 1500, 610, 12, 31, 250, 250);
            }
        }
        /// <summary>
        /// 相机2显示画面双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox3, pictureBox4, pictureBox5, pictureBox6,
            pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox2, otherPictureBoxes, 1500, 610, 12, 287, 250, 250);
            }
        }
        /// <summary>
        /// 相机3显示画面双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox4, pictureBox5, pictureBox6,
            pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox3, otherPictureBoxes, 1500, 610, 271, 31, 250, 250);
            }
        }
        /// <summary>
        /// 相机4显示画面双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox5, pictureBox6,
            pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox4, otherPictureBoxes, 1500, 610, 271, 287, 250, 250);
            }
        }
        /// <summary>
        /// 相机5显示画面双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox6,
            pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox5, otherPictureBoxes, 1500, 610, 527, 31, 250, 250);
            }
        }
        /// <summary>
        /// 相机6显示画面双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
            pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox6, otherPictureBoxes, 1500, 610, 527, 287, 250, 250);
            }
        }     
        private void pictureBox7_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
            pictureBox6, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox7, otherPictureBoxes, 1500, 610, 783, 30, 250, 250);
            }
        }

        private void pictureBox8_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
            pictureBox6, pictureBox7, pictureBox9, pictureBox10, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox8, otherPictureBoxes, 1500, 610, 783, 286, 250, 250);
            }
        }

        private void pictureBox9_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
            pictureBox6, pictureBox7, pictureBox8, pictureBox10, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox9, otherPictureBoxes, 1500, 610, 1039, 29, 250, 250);
            }
        }

        private void pictureBox10_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
            pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox11, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox10, otherPictureBoxes, 1500, 610, 1039, 285, 250, 250);
            }
        }

        private void pictureBox11_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
            pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox12
        };

                TogglePictureBoxZoom(pictureBox11, otherPictureBoxes, 1500, 610, 1295, 29, 250, 250);
            }
        }

        private void pictureBox12_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
            {
                List<PictureBox> otherPictureBoxes = new List<PictureBox>
        {
            pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
            pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11
        };

                TogglePictureBoxZoom(pictureBox12, otherPictureBoxes, 1500, 610, 1295, 285, 250, 250);
            }
        }
        #endregion

        #region 相机上下文菜单strip显示
        /// <summary>
        /// 相机1上下文菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Right)
            {
                System.Drawing.Point screenPoint = Cursor.Position;
                CMScamera1.Show(screenPoint);

            }
        }
        /// <summary>
        /// 相机2上下文菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Right)
            {
                System.Drawing.Point screenPoint = Cursor.Position;
                CMScamera2.Show(screenPoint);

            }
        }
        /// <summary>
        /// 相机3上下文菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Right)
            {
                if (Mouse_e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point screenPoint = Cursor.Position;
                    CMScamera3.Show(screenPoint);

                }
            }
        }
        /// <summary>
        /// 相机4上下文菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Right)
            {
                if (Mouse_e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point screenPoint = Cursor.Position;
                    CMScamera4.Show(screenPoint);

                }
            }
        }
        /// <summary>
        /// 相机5上下文菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureBox5_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Right)
            {
                if (Mouse_e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point screenPoint = Cursor.Position;
                    CMScamera5.Show(screenPoint);

                }
            }
        }
        /// <summary>
        /// 相机6上下文菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void pictureBox6_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Right)
            {
                if (Mouse_e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point screenPoint = Cursor.Position;
                    CMScamera6.Show(screenPoint);

                }
            }
        }
        #endregion

       
    }
}
