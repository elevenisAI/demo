using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.ImageTools
{
    public class ImageConversion
    {
        byte[] buffer;
        public Mat BitmapToMat(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteArray = ms.ToArray();
                Mat mat = Cv2.ImDecode(byteArray, ImreadModes.AnyColor);
                return mat;
            }
        }

        public Bitmap MatToBitmap(Mat mat)
        {

            var buffer = new byte[mat.Rows * mat.Cols * mat.Channels()];
            using (MemoryStream ms = new MemoryStream())
            {
                // 调用 Cv2.ImEncode，指定编码格式为 JPEG
                bool success = Cv2.ImEncode(".jpg", mat,out buffer);

                // 检查 byteArray 是否为空或长度为 0
                if (!success)
                {
                    throw new InvalidOperationException("无法将 Mat 转换为字节数组。");
                }

                // 使用 MemoryStream 从字节数组中创建流，并加载为 Image 对象
                Image image = Image.FromStream(new MemoryStream(buffer));

                // 将 Image 转换为 Bitmap 并返回
                return new Bitmap(image);
            }
        }


    }
}
