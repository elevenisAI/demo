using demo.Algorithm;
using demo.Cameras;
using demo.Helps;
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
        BinarizationMethod method_1;
        int thresholdMin_1;
        int maxValue_1;
        int blockSize_1;
        int constant_1;
        public static Dictionary<string,string> ProductConfig { get; set; }
        public static ConfigManager configLoader = new ConfigManager(Path.Combine(Application.StartupPath, "CameraConfig.ini"));
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
        /// 加载时从ini配置文件传递到主界面调用配置参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraSet_Load(object sender, EventArgs e)
        {
            LoadCameraini();
        }
        /// <summary>
        /// 执行按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void BT_finallSave_Click(object sender, EventArgs e)
        {
            switch (CBcamera.Text)
            {
                case "Cameras1":
                    ini.WriteValue("Cameras1", "BinarizeMode", this.CB_BinarizeMode.Text.ToString());
                    ini.WriteValue("Cameras1", "BinarizeMin", this.NB_Binarize.Num.ToString());
                    ini.WriteValue("Cameras1", "BinarizeMax", this.NB_BinarizeM.Num.ToString());
                    ini.WriteValue("Cameras1", "BlokSize", this.ucNumTextBox2.Num.ToString());
                    ini.WriteValue("Cameras1", "Const", this.ucNumTextBox3.Num.ToString());                  
                    break;
            }
        }
        /// <summary>
        /// combox相机选择变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBcamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBcamera.Text == "Cameras1")
            {
                this.CB_BinarizeMode.Text = method_1.ToString();
                this.NB_Binarize.Num = thresholdMin_1;
                this.NB_BinarizeM.Num = maxValue_1;
                this.ucNumTextBox2.Num = blockSize_1;
                this.ucNumTextBox3.Num = constant_1;
            }
        }
        /// <summary>
        /// 从ini文件加载相机配置
        /// </summary>
        public void LoadCameraini()
        {
            CB_BinarizeMode.DataSource = Enum.GetNames(typeof(opencvAlgorithm.BinarizationMethod));//数据绑定
            ProductConfig = ini.ReadSection("Cameras1");
            string binarizeModeString_1 = ProductConfig["BinarizeMode"].ToString();
            //Console.WriteLine($"BinarizeMode: {binarizeModeString}"); // 调试：检查是否乱码
            method_1 = (BinarizationMethod)Enum.Parse(typeof(BinarizationMethod), binarizeModeString_1);
            string threshold_1 = ProductConfig["BinarizeMin"].ToString();
            thresholdMin_1 = int.Parse(threshold_1);
            string maxValueString_1 = ProductConfig["BinarizeMax"].ToString();
            maxValue_1 = int.Parse(maxValueString_1);
            string blockSizeString_1 = ProductConfig["BlokSize"].ToString();
            blockSize_1 = int.Parse(blockSizeString_1);
            string constantString_1 = ProductConfig["Const"].ToString();
            constant_1 = int.Parse(constantString_1);
            OnBinarizationParametersChanged?.Invoke(method_1, maxValue_1, maxValue_1, blockSize_1, constant_1);
        }
    }
  
}
