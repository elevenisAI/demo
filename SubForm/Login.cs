using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using log;
using RexHelps;
using Timer = System.Windows.Forms.Timer;

namespace demo.SubForm
{
    public partial class Login : Form
    {
        public static RIni mRini = new RIni(Application.StartupPath + "\\Permission.ini");
        private Timer timer = new Timer();//关闭窗口计时器
        private MainForm mainForm;
        public Login(MainForm mainForm)
        {
            InitializeComponent();
            timer.Interval = 2000; // 设置计时器间隔为2秒
            timer.Tick += Timer_Tick; // 订阅计时器的Tick事件
            this.mainForm = mainForm;
        }
        public Login()
        {
            InitializeComponent();
            timer.Interval = 2000; // 设置计时器间隔为2秒
            timer.Tick += Timer_Tick; // 订阅计时器的Tick事件  
        }
        /// <summary>
        /// 登录逻辑校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BTenter_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            //从文件中读取用户名和密码
            string storedUsername = await Task.Run(() => mRini.ReadValue("User","Username"));
            string storedPassword = await Task.Run(() => mRini.ReadValue("User", "Password"));
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            // 检查用户名和密码是否匹配
            bool isValid = username == storedUsername && password == storedPassword;
            this.Invoke((MethodInvoker)delegate {
                if (isValid)
                {
                    this.LBtip.Text = txtUsername.Text + " 登陆成功";
                    MainForm.userRole = Helps.Permission.Role.Admin;
                    Log.WriteInfo("Admin权限登录");
                    mainForm.UpdateLoginStatusLabel(txtUsername.Text );
                    // 延时2秒后关闭登录窗口
                    timer.Start();
                    // 这里可以添加登录成功后的操作，如关闭登录窗口，显示主窗口等
                }
                else
                {
                    this.LBtip.Text = "用户名或密码错误";
                }
            });
        }
        /// <summary>
        /// 窗口关闭定时器任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop(); // 停止计时器
            this.Close(); // 关闭登录窗体
        }
        /// <summary>
        /// 密码显示输入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton3_Click(object sender, EventArgs e)
        {
            if(this.uiButton3.Text == "显示输入") 
            {
                this.uiButton3.Text = "隐藏输入";
                this.txtPassword.PasswordChar = '\0';
            }
            else
            {
                this.uiButton3.Text = "显示输入";
                this.txtPassword.PasswordChar = '*';

            }
            
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTesc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 修改密码UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTChangepassword_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = (MouseEventArgs)e;
            if (Mouse_e.Button == MouseButtons.Left) 
            {
                this.uiLabel1.Visible = true;
                this.uiLabel2.Visible = true;
                this.uiLabel3.Visible = true;
                this.txtCurrentPassword.Visible = true;
                this.txtNewPassword.Visible = true;
                this.txtConfirmNewPassword.Visible = true;
                this.BTConfirmTheChanges.Visible = true;
            }
        }
        /// <summary>
        /// 修改密码逻辑
        /// </summary>
        private void ChangePassword()
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmNewPassword = txtConfirmNewPassword.Text;
            // 从文件中读取当前存储的密码
            string storedPassword = mRini.ReadValue("User", "Password");
            //检查输入密码是否正确
            if (storedPassword == currentPassword)
            {
                if (newPassword == confirmNewPassword)
                {
                    // 更新INI文件中的密码
                    mRini.WriteValue("User", "Password", newPassword);
                    Log.WriteWarns("用户修改密码");
                    MessageBox.Show("密码修改成功！");
                    this.uiLabel1.Visible = false;
                    this.uiLabel2.Visible = false;
                    this.uiLabel3.Visible = false;
                    this.txtCurrentPassword.Visible = false;
                    this.txtNewPassword.Visible = false;
                    this.txtConfirmNewPassword.Visible = false;
                    this.BTConfirmTheChanges.Visible = false;
                }
                else
                {
                    MessageBox.Show("新密码和确认密码不匹配！");
                }
            }
            else
            {
                MessageBox.Show("当前密码错误！");
            }

        }

        private void BTConfirmTheChanges_Click(object sender, EventArgs e)
        {
             ChangePassword();
        }

        
    }
    
}
