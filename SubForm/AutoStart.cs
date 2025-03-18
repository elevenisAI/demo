using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using demo.Helps;
using demo.log4net;
using log;
using Microsoft.Win32;
using RexHelps;

namespace demo.SubForm
{
    public partial class AutoStart : Form
    {
        public static RIni mRini = new RIni(Application.StartupPath + "\\Config.ini");
        private Form parentForm; // 父窗口的引用
        public AutoStart(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            // 设置子窗口启动位置为屏幕中心
            this.StartPosition = FormStartPosition.CenterScreen;
        }
      
        private void AutoStart_Load(object sender, EventArgs e)
        {
            CboxAutoStart.Checked = bool.Parse(mRini.ReadValue("Config", "mAutoRun", "true"));
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
            RStartSet.SetMeStart(CboxAutoStart.Checked);
            mRini.WriteValue("Config", "mAutoRun", CboxAutoStart.Checked.ToString());
            Log.WriteInfo("自动启动模式更改");
            if (CboxAutoStart.Checked)
            {
                
            }
        }
    
        private void BTEsc_Click(object sender, EventArgs e)
        {
            Close();
        }
    
    }
}
