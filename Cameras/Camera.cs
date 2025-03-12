using NetSDKCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace demo.Cameras
{
    public class Camera
    {
        public IntPtr loginID = IntPtr.Zero;
        public IntPtr playID = IntPtr.Zero;
        public NET_DEVICEINFO_Ex deviceInfo = new NET_DEVICEINFO_Ex();
        public string ip;
        public ushort port;
        public string username;
        public string password;
        public ushort cameraId;
        public Camera(string ip , ushort port ,string username ,string password, ushort cameraId )
        {
            this.ip = ip;
            this.port = port;
            this.username = username;
            this.password = password;   
            this.cameraId = cameraId;
        }
        /// <summary>
        /// 登录相机
        /// </summary>
        /// <returns></returns>
        public bool Login()
        {
            loginID = NETClient.LoginWithHighLevelSecurity(ip, port, username, password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
            return loginID != IntPtr.Zero;
        }
        /// <summary>
        /// 登出相机
        /// </summary>
        /// <returns></returns>
        public bool Logout()
        {
            // 登出相机
            if (loginID != IntPtr.Zero)
            {
                NETClient.Logout(loginID);
                loginID = IntPtr.Zero;
                return true;
            }
            return false;
        }
    }
}
