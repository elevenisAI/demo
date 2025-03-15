using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RexHelps
{
    public class RIni
    {
        public string FilePath;

        public RIni(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("RIni.RIni: 输入的文件路径为空！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ArgumentException("文件路径不能为空！");
            }
            FilePath = input;
        }

        #region "操作"

        #region "读取"

     
        public string ReadValue(string section, string key, string defaultValue = "")
        {
            // 读取文件的所有行
            string[] lines = File.ReadAllLines(FilePath, System.Text.Encoding.UTF8);

            // 用于标记是否进入目标节
            bool inTargetSection = false;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                // 检查是否是节的开始
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    // 提取节名
                    string currentSection = trimmedLine.Trim('[', ']');

                    // 如果是目标节，标记为 true
                    if (currentSection == section)
                    {
                        inTargetSection = true;
                    }
                    else
                    {
                        // 如果不是目标节，标记为 false
                        inTargetSection = false;
                    }
                }
                else if (inTargetSection && trimmedLine.Contains("="))
                {
                    // 如果在目标节中，解析键值对
                    string[] parts = trimmedLine.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        string currentKey = parts[0].Trim();
                        string currentValue = parts[1].Trim();

                        // 如果找到目标键，返回其值
                        if (currentKey == key)
                        {
                            return currentValue;
                        }
                    }
                }
            }

            // 如果未找到目标键，返回默认值
            return defaultValue;
        }

        // 读取所有节
        public string[] ReadSections()
        {
            List<string> sections = new List<string>();
            if (!File.Exists(FilePath))
            {
                return sections.ToArray();
            }

            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    string section = line.Trim('[', ']');
                    sections.Add(section);
                }
            }

            return sections.ToArray();
        }

        // 读取指定节的所有键值对
        public Dictionary<string, string> ReadSection(string section)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            if (!File.Exists(FilePath))
            {
                return keyValuePairs;
            }

            bool inSection = false;
            string[] lines = File.ReadAllLines(FilePath, Encoding.UTF8);
            foreach (string line in lines)
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    inSection = line.Trim('[', ']') == section;
                }

                if (inSection && line.Contains("="))
                {
                    string[] parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2)
                    {
                        keyValuePairs[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }

            return keyValuePairs;
        }

        public Dictionary<string, Dictionary<string, string>> ReadAllSectionsAndKeys()
        {
            var result = new Dictionary<string, Dictionary<string, string>>();

            // 获取所有段的名称
            StringBuilder sectionNames = new StringBuilder(1024);
            GetPrivateProfileSectionNames(sectionNames, 1024, FilePath);
            string[] sections = sectionNames.ToString().Split(new[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var section in sections)
            {
                var keys = new Dictionary<string, string>();

                // 获取当前段的所有键值对
                StringBuilder keyValues = new StringBuilder(1024);
                GetPrivateProfileSection(section, keyValues, 1024, FilePath);
                string[] keyValuePairs = keyValues.ToString().Split(new[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in keyValuePairs)
                {
                    string[] keyValue = pair.Split(new[] { '=' }, 2);
                    if (keyValue.Length == 2)
                    {
                        keys[keyValue[0]] = keyValue[1];
                    }
                }

                result[section] = keys;
            }

            return result;
        }

        #endregion

        #region "写入"
        public void WriteValue(string section, string key, string value)
        {
            // 读取整个文件内容
            string[] lines = File.ReadAllLines(FilePath, Encoding.UTF8);
            List<string> newLines = new List<string>();

            bool sectionFound = false;
            bool keyFound = false;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                // 检查是否是目标节
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    if (trimmedLine.Trim('[', ']') == section)
                    {
                        sectionFound = true;
                    }
                    else
                    {
                        sectionFound = false;
                    }
                }

                // 如果在目标节中，检查是否是目标键
                if (sectionFound && trimmedLine.Contains("="))
                {
                    string[] parts = trimmedLine.Split(new[] { '=' }, 2);
                    if (parts[0].Trim() == key)
                    {
                        newLines.Add($"{key}={value}");
                        keyFound = true;
                        continue;
                    }
                }

                newLines.Add(line);
            }

            // 如果目标键未找到，添加到目标节中
            if (!keyFound)
            {
                if (!sectionFound)
                {
                    newLines.Add($"[{section}]");
                }
                newLines.Add($"{key}={value}");
            }

            // 写入文件
            File.WriteAllLines(FilePath, newLines, Encoding.UTF8);
        }
        #endregion

        #region "删除"
        public void DeleteKey(string section, string key)
        {
            WritePrivateProfileString(section, key, null, FilePath);
        }

        public void DeleteSection(string section)
        {
            WritePrivateProfileString(section, null, null, FilePath);
        }

        public void ClearAllSections()
        {
            DeleteSection(null); // 删除所有段落
        }
        #endregion

        #endregion

        #region "API"
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(string section, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSectionNames(StringBuilder retVal, int size, string filePath);
        #endregion
    }
}