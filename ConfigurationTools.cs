﻿using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace TCPConsole {
    internal class ConfigurationTools {
        private Hashtable keyPairs = new Hashtable();
        private String iniFilePath;
        private struct SectionPair {
            public String Section;
            public String Key;
        }
        /// <summary>
        /// 在给定的路径上打开INI文件并枚举IniParser中的值。
        /// </summary>
        /// <param name="iniPath">Full path to INI file.</param>
        public ConfigurationTools(String iniPath) {
            TextReader iniFile = null;
            String strLine = null;
            String currentRoot = null;
            String[] keyPair = null;
            iniFilePath = iniPath;
            if (File.Exists(iniPath)) {
                try {
                    iniFile = new StreamReader(iniPath);
                    strLine = iniFile.ReadLine();
                    while (strLine != null) {
                        strLine = strLine.Trim().ToUpper();
                        if (strLine != "") {
                            if (strLine.StartsWith("[") && strLine.EndsWith("]")) {
                                currentRoot = strLine.Substring(1, strLine.Length - 2);
                            } else {
                                keyPair = strLine.Split(new char[] { '=' }, 2);
                                SectionPair sectionPair;
                                String value = null;
                                if (currentRoot == null)
                                    currentRoot = "ROOT";
                                sectionPair.Section = currentRoot;
                                sectionPair.Key = keyPair[0];
                                if (keyPair.Length > 1)
                                    value = keyPair[1];
                                keyPairs.Add(sectionPair, value);
                            }
                        }
                        strLine = iniFile.ReadLine();
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } finally {
                    if (iniFile != null)
                        iniFile.Close();
                }
            } else
                MessageBox.Show("Unable to locate " + iniPath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 返回给定section的值，key对。
        /// </summary>
        /// <param name="sectionName">Section name</param>
        /// <param name="settingName">Key name</param>
        public String GetSetting(String sectionName, String settingName) {
            SectionPair sectionPair;
            sectionPair.Section = sectionName.ToUpper();
            sectionPair.Key = settingName.ToUpper();
            return (String)keyPairs[sectionPair];
        }
        /// <summary>
        /// 列出给定的Section的所有行
        /// </summary>
        /// <param name="sectionName">Section to enum.</param>
        public String[] EnumSection(String sectionName) {
            ArrayList tmpArray = new ArrayList();
            foreach (SectionPair pair in keyPairs.Keys) {
                if (pair.Section == sectionName.ToUpper())
                    tmpArray.Add(pair.Key);
            }
            return (String[])tmpArray.ToArray(typeof(String));
        }
        /// <summary>
        /// 向要保存的表添加或替换设置。
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        /// <param name="settingValue">Value of key.</param>
        public void AddSetting(String sectionName, String settingName, String settingValue) {
            SectionPair sectionPair;
            sectionPair.Section = sectionName.ToUpper();
            sectionPair.Key = settingName.ToUpper();
            if (keyPairs.ContainsKey(sectionPair))
                keyPairs.Remove(sectionPair);
            keyPairs.Add(sectionPair, settingValue);
        }
        /// <summary>
        /// 用空值添加或替换要保存的表的设置。
        /// </summary>
        /// <param name="sectionName">Section</param>
        /// <param name="settingName">Key</param>
        public void AddSetting(String sectionName, String settingName) {
            AddSetting(sectionName, settingName, null);
        }
        /// <summary>
        /// 删除设置
        /// </summary>
        /// <param name="sectionName">指定Section</param>
        /// <param name="settingName">添加的Key</param>
        public void DeleteSetting(String sectionName, String settingName) {
            SectionPair sectionPair;
            sectionPair.Section = sectionName.ToUpper();
            sectionPair.Key = settingName.ToUpper();
            if (keyPairs.ContainsKey(sectionPair))
                keyPairs.Remove(sectionPair);
        }
        /// <summary>
        /// 保存设置到新文件。
        /// </summary>
        /// <param name="newFilePath">新的文件路径。</param>
        public void SaveSettings(String newFilePath) {
            ArrayList sections = new ArrayList();
            String tmpValue = "";
            String strToSave = "";
            foreach (SectionPair sectionPair in keyPairs.Keys) {
                if (!sections.Contains(sectionPair.Section))
                    sections.Add(sectionPair.Section);
            }
            foreach (String section in sections) {
                strToSave += ("[" + section + "]\r\n");
                foreach (SectionPair sectionPair in keyPairs.Keys) {
                    if (sectionPair.Section == section) {
                        tmpValue = (String)keyPairs[sectionPair];
                        if (tmpValue != null)
                            tmpValue = "=" + tmpValue;
                        strToSave += (sectionPair.Key + tmpValue + "\r\n");
                    }
                }
                strToSave += "\r\n";
            }
            try {
                TextWriter tw = new StreamWriter(newFilePath);
                tw.Write(strToSave);
                tw.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 将设置保存回ini文件。
        /// </summary>
        public void SaveSettings() {
            SaveSettings(iniFilePath);
        }
    }
}
