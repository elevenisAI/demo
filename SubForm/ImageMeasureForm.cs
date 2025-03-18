using log;
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

namespace demo.SubForm
{
    public partial class ImageMeasureForm : Form
    {
        public string imageMeasureCamera;
        public string imageMeasureVideo;
        public OpenFileDialog openFileDialog;
        /// <summary>
        /// 测量请求事件，通知主窗口
        /// </summary>
        public event EventHandler MeasureRequested;
        public event EventHandler MeasureFoldRequested;//图片文件夹测量
        public event EventHandler AutoMeasureRequested;//自动测量按钮请求事件
        public event EventHandler CloseWindowEvent;//手动测量标志位事件，更新父窗口标志
        public event EventHandler StopAutoMeasure;//停止自动测量
        public event EventHandler NextImageRequested;//下一张
        public event EventHandler PreviousImageRequested;//上一张
        public event EventHandler CurrentImageRequested;//测量当前
        public event EventHandler ContinueAutoMeasure;//继续自动测量
        /// <summary>
        /// 测量图片工具读取图片路径事件
        /// </summary>
        public event EventHandler<string> ImagePathSelected;
        public event EventHandler<string> ImageFolderPathSelected;
        public ImageMeasureForm()
        {            
            InitializeComponent();
            InitializeOpenFileDialog();
            imageMeasureCamera = this.CB_CameraSelect.Text;
            // 设置子窗口启动位置为屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        /// <summary>
        /// 文件选择过滤器
        /// </summary>
        private void InitializeOpenFileDialog()
        {
            openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp", // 设置文件过滤器，只显示图片文件
                Title = "选择一张图片", // 对话框标题
                Multiselect = false // 只允许选择一个文件
            };
        }
        /// <summary>
        /// 图片选择事件，负责将选择图片路径传递给主界面，子界面只负责获取图片路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_ImageSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) // 显示文件对话框并检查用户是否点击了“确定”
            {
                string selectedImagePath = openFileDialog.FileName; // 获取选中的文件路径
                this.TB_imagePath.Text = selectedImagePath;
                string selectedFileName = Path.GetFileName(selectedImagePath); // 提取文件名
                this.TB_CurrentImage.Text = selectedFileName; 
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    // 触发事件，将图片路径传递给订阅者
                    ImagePathSelected?.Invoke(this, selectedImagePath);
                }
                else
                {
                    Log.WriteWarns("所选图片错误！");
                    return;
                }

            }
        }
        /// <summary>
        /// 相机选择的combox改变索引事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CB_CameraSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageMeasureCamera = this.CB_CameraSelect.Text;
        }

        private void BT_measureFormImage_Click(object sender, EventArgs e)
        {
            // 触发测量请求事件
            MainForm.isManualMeasure = true;
            MeasureRequested?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// 文件夹选择按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_ImageFileSelect_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "请选择一个文件夹"; // 设置对话框的描述信息
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = folderDialog.SelectedPath; // 获取选中的文件夹路径
                    this.TB_SelectedFolderPath.Text = selectedFolderPath;
                    if (!string.IsNullOrEmpty(selectedFolderPath))
                    {
                        // 触发事件，将文件夹路径传递给订阅者
                        ImageFolderPathSelected?.Invoke(this, selectedFolderPath);
                    }
                    else
                    {
                        Log.WriteWarns("所选文件夹错误");
                        return;
                    }
                }
            }

        }

        private void BT_measureFromFile_Click(object sender, EventArgs e)
        {
            MainForm.isManualMeasure = true;
            MeasureFoldRequested?.Invoke(this, EventArgs.Empty);
        }

        private void BT_AutoMeasure_Click(object sender, EventArgs e)
        {
            MainForm.isAutoMeasuring = true;
            MainForm.isManualMeasure = true;
            AutoMeasureRequested?.Invoke(this, EventArgs.Empty);


        }

        private void ImageMeasureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.isAutoMeasuring = false;
            CloseWindowEvent?.Invoke(this, EventArgs.Empty);
        }

        private void BT_measureContinue_Click(object sender, EventArgs e)
        {
            MainForm.isAutoMeasuring = true;
            ContinueAutoMeasure?.Invoke(this, EventArgs.Empty);
        }

        private void BT_Stop_Click(object sender, EventArgs e)
        {
            MainForm.isAutoMeasuring = false;
        }

        private void BT_NextImage_Click(object sender, EventArgs e)
        {
            NextImageRequested?.Invoke(this, EventArgs.Empty);
        }

        private void BT_BeforeImage_Click(object sender, EventArgs e)
        {
            PreviousImageRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
