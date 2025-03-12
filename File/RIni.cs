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
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, defaultValue, temp, 1024, FilePath);
            return temp.ToString();
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
            string[] lines = File.ReadAllLines(FilePath);
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
            WritePrivateProfileString(section, key, value, FilePath);
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