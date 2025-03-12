using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSDKCS;



namespace demo.Cameras
{
    public class CameraManager
    {
        private static CameraManager instance;
        private static List<Camera> cameras = new List<Camera>();

        private CameraManager()
        {
            // 私有构造函数，防止外部实例化
        }
        public static CameraManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CameraManager();
                }
                return instance;
            }
        }

        public void AddCamera(Camera camera)
        {
            cameras.Add(camera);
        }

        public void RemoveCamera(Camera camera)
        {
            cameras.Remove(camera);
        }

        public Camera GetCamera(int index)
        {
            if (index >= 0 && index < cameras.Count)
            {
                return cameras[index];
            }
            return null;
        }
        public Camera GetCamera(string ip)
        {
            if (cameras.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var camera in cameras)
                {
                    if (camera.ip == ip)
                    {
                        return camera;
                    }
                }
            }
            return null;

        }
    }
}
