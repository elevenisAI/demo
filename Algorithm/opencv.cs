using demo.SubForm;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Algorithm
{
    public static class opencvAlgorithm
    {
        public enum BinarizationMethod
        {
            固定阈值二值化,
            自动阈值二值化,
            自适应均值阈值二值化,
            自适应高斯阈值二值化
        }
        public static Mat Binarize(Mat inputImage, BinarizationMethod method, int threshold = 240, int maxValue = 255, int blockSize = 11, int constant = 2)
        {
            Mat grayImage = new Mat();
            Mat binaryImage = new Mat();

            // 将输入图像转换为灰度图
            Cv2.CvtColor(inputImage, grayImage, ColorConversionCodes.BGR2GRAY);

            switch (method)
            {
                case BinarizationMethod.固定阈值二值化:
                    // 固定阈值二值化
                    Cv2.Threshold(grayImage, binaryImage, threshold, maxValue, ThresholdTypes.Binary);
                    break;

                case BinarizationMethod.自动阈值二值化:
                    // Otsu 自动阈值二值化
                    Cv2.Threshold(grayImage, binaryImage, 0, maxValue, ThresholdTypes.Binary | ThresholdTypes.Otsu);
                    break;

                case BinarizationMethod.自适应均值阈值二值化:
                    // 自适应均值阈值二值化
                    Cv2.AdaptiveThreshold(grayImage, binaryImage, maxValue, AdaptiveThresholdTypes.MeanC, ThresholdTypes.Binary, blockSize, constant);
                    break;

                case BinarizationMethod.自适应高斯阈值二值化:
                    // 自适应高斯阈值二值化
                    Cv2.AdaptiveThreshold(grayImage, binaryImage, maxValue, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, blockSize, constant);
                    break;

                default:
                    throw new ArgumentException("Invalid binarization method.");
            }

            // 释放灰度图资源
            grayImage.Dispose();

            return binaryImage;
        }

        public static List<Rect> DetectROIAreas(Mat grayMat)
        {
            List<Rect> roiRects = new List<Rect>();

            // 创建一个用于存储阈值处理结果的Mat对象
            Mat threshMat = new Mat();

            // 对灰度图进行阈值处理，灰度值大于128的区域设为255，其余设为0
            Cv2.Threshold(grayMat, threshMat, 128, 255, ThresholdTypes.Binary);

            // 查找轮廓
            Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(threshMat, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            // 遍历轮廓并计算边界矩形
            foreach (Point[] contour in contours)
            {
                // 计算轮廓的边界矩形
                Rect rect = Cv2.BoundingRect(contour);

                // 可选：过滤掉面积过小的轮廓（避免噪声干扰）
                if (rect.Height*rect.Width > 500) // 示例：过滤掉面积小于100的轮廓
                {
                    roiRects.Add(rect);
                }
            }

            // 释放阈值处理后的Mat对象
            threshMat.Dispose();

            return roiRects;
        }
    }
}
