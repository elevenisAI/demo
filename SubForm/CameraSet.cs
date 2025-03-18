using demo.Algorithm;
using demo.Cameras;
using log;
using Rex.UI;
using RexControl;
using RexHelps;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static demo.Algorithm.opencvAlgorithm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demo.SubForm
{
    public partial class CameraSet : Form
    {
        // 回调委托声明
        public delegate void BinarizationParametersHandler(BinarizationMethod method, int threshold, int maxValue, int blockSize, int constant);
        // 事件声明
        public event BinarizationParametersHandler OnBinarizationParametersChanged;
        private CameraManager Instance;
        public static RIni ini = new RIni(Path.Combine(Application.StartupPath, "CameraConfig.ini"));
        public static Dictionary<string, Dictionary<string, string>> allSections = ini.ReadAllSectionsAndKeys();
        public static ushort id = 1;
        public CameraSet()
        {
            InitializeComponent();
        }

        private void BTModelSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择模型";
            ofd.Filter = "ONNX文件 (*.onnx)|*.onnx";
            if (ofd.ShowDialog() == DialogResult.OK)

            {
                string filePath = ofd.FileName;
                //处理文件
            }
        }
        /// <summary>
        /// 登录按键登录相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BTlogin_Click(object sender, EventArgs e)
        {
            try
            {
                // 禁用按钮，防止重复点击
                string ip = this.TBIP.Text;
                string portText = this.TBPORT.Text;
                ushort port;
                ushort.TryParse(portText, out port);
                string name = this.TBName.Text;
                string password = this.TBpassword.Text;

                Camera camera = new Camera(ip, port, name, password, id);
                bool loginSuccess = await Task.Run(() => camera.Login());

                if (loginSuccess && !(CBcamera.Items.Contains("相机" + ip)))
                {
                    this.Invoke(new Action(() =>
                    {
                        // 检查是否已存在相同相机
                        bool exists = allSections.Any(section => section.Key.StartsWith("Camera") && ini.ReadValue(section.Key, "IP", "") == ip);
                        if (!exists)
                        {
                            id++;
                            CBcamera.Items.Add("相机" + ip);
                            CBcamera.SelectedIndex = CBcamera.Items.Count - 1;
                        }
                        CameraManager.Instance.AddCamera(camera);
                    }));

                    // 异步写入INI文件
                    await Task.Run(() => WriteIniFile(ip, port, name, password));
                }
            }
            catch (Exception ex)
            {
                Log.WriteErrors(ex);
                Log.WriteErrors("检查输入配置是否有误");
            }
            finally
            {
                // 启用按钮
                BTlogin.Enabled = true;
            }
        }
        /// <summary>
        /// 相机信息写入到配置文件
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        private void WriteIniFile(string ip, ushort port, string name, string password)
        {
            ini.WriteValue("Cameras" + id, "IP", ip);
            ini.WriteValue("Cameras" + id, "Port", port.ToString());
            ini.WriteValue("Cameras" + id, "Name", name);
            ini.WriteValue("Cameras" + id, "Password", password);

        }
        private void LoadCameraFromIni()
        {
            CBcamera.Items.Clear(); // 清空相机列表
            // 读取所有节
            string[] sections = ini.ReadSections();
            foreach (string section in sections)
            {
                if (section.StartsWith("Camera"))
                {
                    string ip = ini.ReadValue(section, "IP", "");
                    string portText = ini.ReadValue(section, "Port", "");
                    string name = ini.ReadValue(section, "Name", "");
                    string password = ini.ReadValue(section, "Password", "");

                    ushort port;
                    if (ushort.TryParse(portText, out port))
                    {
                        // 添加到相机列表
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            CBcamera.Items.Add($"相机{section.Substring(7)} - {ip}:{port}");
                            this.CBcamera.SelectedIndex = this.CBcamera.Items.Count - 1;
                            TBIP.Text = ip;
                            TBPORT.Text = portText;
                            TBName.Text = name;
                            TBpassword.Text = password;

                        });
                    }
                    else
                    {
                        // 处理端口解析失败的情况
                        MessageBox.Show($"端口解析失败: {portText}");
                    }
                }
            }
        }

        private void CameraSet_Load(object sender, EventArgs e)
        {
            LoadCameraFromIni();
            CB_BinarizeMode.DataSource = Enum.GetNames(typeof(opencvAlgorithm.BinarizationMethod));//数据绑定

        }

        private void BT_Save_Click(object sender, EventArgs e)
        { // 获取参数
            BinarizationMethod method = (BinarizationMethod)CB_BinarizeMode.SelectedIndex;
            int threshold = (int)NB_Binarize.Num;
            int maxValue = (int)NB_BinarizeM.Num;
            int blockSize = (int)ucNumTextBox2.Num;
            int constant = (int)ucNumTextBox3.Num;
            // 触发事件
            OnBinarizationParametersChanged?.Invoke(method, threshold, maxValue, blockSize, constant);
        }
    }
  
}
