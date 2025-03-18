using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ImageEnumerator
{
    // 支持的图片文件扩展名
    private static readonly string[] ImageExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

    /// <summary>
    /// 遍历文件夹内所有图片文件的路径
    /// </summary>
    /// <param name="folderPath">文件夹路径</param>
    /// <returns>图片文件路径列表</returns>
    public static IEnumerable<string> EnumerateImagesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
            throw new DirectoryNotFoundException("指定的文件夹不存在。");

        return Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
            .Where(filePath => ImageExtensions.Any(ext => filePath.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }
}