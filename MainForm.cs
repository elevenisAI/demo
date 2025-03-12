using System;
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
using RexControl;
using RexHelps;
using Sunny.UI;
using static demo.Algorithm.opencvAlgorithm;


namespace demo
{
    public partial class MainForm : Form

    {
        /// <summary>
        /// 相机设置二值化传值
        /// </summary>
        public BinarizationMethod method;
        public int maxValue;
        public int blockSize;
        public int constant;
        public int threshold;
        /// <summary>
        /// 控制取流频率计数
        /// </summary>
        int id;
        long camerFrameRate = 48;
        /// <summary>
        /// 预览标志位
        /// </summary>
        private bool isPreviewingOne = false; // 用于记录是否正在预览
        /// <summary>
        /// 图片转换算法工具对象
        /// </summary>
        public ImageConversion imageConversion = new ImageConversion();//图片转换算法工具对象
        /// <summary>
        /// 回调函数设置，几个相机几个回调函数
        /// </summary>
        private static fRealDataCallBackEx2 m_RealDataCallBackEx2;
        /// <summary>
        /// 相机管理类单例
        /// </summary>
        private CameraManager Instance;//相机管理类单例
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
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            // 初始化 PerformanceCounter 来监控私有字节
            privateBytesCounter = new PerformanceCounter("Process", "Private Bytes", Process.GetCurrentProcess().ProcessName);
            m_RealDataCallBackEx2 = new fRealDataCallBackEx2(RealDataCallBack);//设置回调
        }
   

        private void MainForm_Load(object sender, EventArgs e)
        {
            Log.LoadConfig("D:\\cSharp\\y\\demo\\log4net.config");
            Log.InitializeRichTextBox(this.RichTextBoxLog);
            ShowTime();
        }
        /// <summary>
        /// 开机自启动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开机自启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoStart autoForm = new AutoStart();
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
        #region  窗口双击事件
        /// <summary>
        /// 相机1显示画面双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left)
                if (Convert.ToInt32(pictureBox1.Tag) == 0)
                {
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                    pictureBox1.Width = 1365;
                    pictureBox1.Height = 620;
                    pictureBox1.Tag = 1;
                }
                else
                {
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox1.Width = 445;
                    pictureBox1.Height = 305;
                    pictureBox1.Tag = 0;
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
                if (Convert.ToInt32(pictureBox2.Tag) == 0)
                {
                    pictureBox1.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                    pictureBox2.Location = new System.Drawing.Point(12, 31);
                    pictureBox2.Width = 1365;
                    pictureBox2.Height = 620;
                    pictureBox2.Tag = 1;
                }
                else
                {
                    pictureBox1.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox2.Location = new System.Drawing.Point(474, 31);
                    pictureBox2.Width = 445;
                    pictureBox2.Height = 305;
                    pictureBox2.Tag = 0;
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
                if (Convert.ToInt32(pictureBox3.Tag) == 0)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                    pictureBox3.Location = new System.Drawing.Point(12, 31);
                    pictureBox3.Width = 1365;
                    pictureBox3.Height = 620;
                    pictureBox3.Tag = 1;
                }
                else
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox3.Location = new System.Drawing.Point(938, 29);
                    pictureBox3.Width = 445;
                    pictureBox3.Height = 305;
                    pictureBox3.Tag = 0;
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
                if (Convert.ToInt32(pictureBox4.Tag) == 0)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Visible = false;
                    pictureBox4.Location = new System.Drawing.Point(12, 31);
                    pictureBox4.Width = 1365;
                    pictureBox4.Height = 620;
                    pictureBox4.Tag = 1;
                }
                else
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox4.Location = new System.Drawing.Point(12, 342);
                    pictureBox4.Width = 445;
                    pictureBox4.Height = 305;
                    pictureBox4.Tag = 0;
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
                if (Convert.ToInt32(pictureBox5.Tag) == 0)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox6.Visible = false;
                    pictureBox5.Location = new System.Drawing.Point(12, 31);
                    pictureBox5.Width = 1365;
                    pictureBox5.Height = 620;
                    pictureBox5.Tag = 1;
                }
                else
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox5.Location = new System.Drawing.Point(474, 342);
                    pictureBox5.Width = 445;
                    pictureBox5.Height = 305;
                    pictureBox5.Tag = 0;
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
                if (Convert.ToInt32(pictureBox6.Tag) == 0)
                {
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox5.Visible = false;
                    pictureBox6.Location = new System.Drawing.Point(12, 31);
                    pictureBox6.Width = 1365;
                    pictureBox6.Height = 620;
                    pictureBox6.Tag = 1;
                }
                else
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox6.Location = new System.Drawing.Point(938, 342);
                    pictureBox6.Width = 445;
                    pictureBox6.Height = 305;
                    pictureBox6.Tag = 0;
                }
        }

        #endregion
        #region 相机上下文菜单
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
        #region 上下文菜单相机设置窗口
        private void CameraSetForm_OnBinarizationParametersChanged(BinarizationMethod method, int threshold, int maxValue, int blockSize, int constant) 
        {
            this.method = method;
            this.threshold = threshold;
            this.maxValue = maxValue;
            this.blockSize = blockSize;
            this.constant = constant;
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
            if(id % camerFrameRate == 0)
            {
                if (!isPreviewingOne) return; // 如果未在预览，直接返回
                byte[] frameData = new byte[(int)dwBufSize];
                Marshal.Copy(pBuffer, frameData, 0, (int)dwBufSize);
                await ProcessFrameAsync(frameData);
            }
            
        }
        #endregion
        private async Task ProcessFrameAsync(byte[] frameData)
        {
            if (!isPreviewingOne || frameData == null) return;

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

        private void UpdatePictureBox(PictureBox pictureBox , Bitmap bitmap)
        {
            if (pictureBox.InvokeRequired)
            {
                pictureBox.Invoke(new Action(() =>
                {
                    UpdatePictureBox(pictureBox,bitmap);
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
        {
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
                    string ip = "192.168.1.101";
                    ushort port = 37777;
                    string name = "admin";
                    string password = "yyyy2025";

                    Camera camera = new Camera(ip, port, name, password, 1);
                    bool loginSuccess = await Task.Run(() => camera.Login());

                    if (loginSuccess)
                    {
                        CameraManager.Instance.AddCamera(camera);
                        Log.WriteInfo("IP：" + ip + "登陆成功");
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
        /// 取流速度事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void cNumericUpDown1_ValueChanged(object sender, double value)
        {
            this.camerFrameRate = 53-(int)value;
        }
    }
}
