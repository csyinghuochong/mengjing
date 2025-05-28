using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.UI;

namespace ET.Client
{
    public class MulLanguageEditor : Editor
    {
        //UIPrefab文件夹目录
        private static string UIPrefabPath = Application.dataPath + "/Bundles/UI";

        //脚本的文件夹目录
        private static string ScriptPath = Application.dataPath + "/Scripts";

        //导出的中文KEY路径
        private static string OutPath = Application.dataPath + "/out.txt";

        private static List<string> Localization = null;
        private static string staticWriteText = "";

        [MenuItem("Tools/导出多语言")]
        static void ExportChinese()
        {
            Localization = new List<string>();
            staticWriteText = "";

            //提取Prefab上的中文
            staticWriteText += "----------------Prefab----------------------\n";
            LoadDiectoryPrefab(new DirectoryInfo(UIPrefabPath));

            //提取CS中的中文
            staticWriteText += "----------------Script----------------------\n";
            LoadDiectoryCS(new DirectoryInfo(ScriptPath));

            //最终把提取的中文生成出来
            string textPath = OutPath;
            if (System.IO.File.Exists(textPath))
            {
                File.Delete(textPath);
            }

            using (StreamWriter writer = new StreamWriter(textPath, false, Encoding.UTF8))
            {
                writer.Write(staticWriteText);
            }

            AssetDatabase.Refresh();
        }

        //递归所有UI Prefab
        static public void LoadDiectoryPrefab(DirectoryInfo dictoryInfo)
        {
            if (!dictoryInfo.Exists) return;
            FileInfo[] fileInfos = dictoryInfo.GetFiles("*.prefab", SearchOption.AllDirectories);
            foreach (FileInfo files in fileInfos)
            {
                string path = files.FullName;
                int index = Application.dataPath.Length - 6; //path.IndexOf("Assets");
                string assetPath = path.Substring(index);
                GameObject prefab = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
                GameObject instance = GameObject.Instantiate(prefab) as GameObject;

                path = files.FullName.Substring(Application.dataPath.Length + 2);
                SearchPrefabString(path, instance.transform);
                GameObject.DestroyImmediate(instance);
            }
        }

        //递归所有C#代码
        static public void LoadDiectoryCS(DirectoryInfo dictoryInfo)
        {
            if (!dictoryInfo.Exists) return;
            FileInfo[] fileInfos = dictoryInfo.GetFiles("*.cs", SearchOption.AllDirectories);
            foreach (FileInfo files in fileInfos)
            {
                string path = files.FullName;
                string text = File.ReadAllText(path);

                //用正则表达式把代码里面两种字符串中间的字符串提取出来。
                // Regex reg = new Regex("(?<=StrUtil.GetText\\s*\\(\\s*\"\\s*)[\\s\\S]*?(?=\\s*\")");
                Regex reg = new Regex("\"(.*?)\"", RegexOptions.Compiled);
                MatchCollection mc = reg.Matches(text);
                Regex chineseCharRegex = new Regex("[\u4e00-\u9fa5]", RegexOptions.Compiled);
                foreach (Match m in mc)
                {
                    string format = m.Groups[1].Value;
                    
                    // 判断是否包含中文字符
                    if (!chineseCharRegex.IsMatch(format))
                    {
                        continue;
                    }

                    if (!Localization.Contains(format) && !string.IsNullOrEmpty(format))
                    {
                        Localization.Add(format);
                        staticWriteText += format + "\n";
                    }
                }
            }
        }

        //提取Prefab上的中文
        static public void SearchPrefabString(string path, Transform root)
        {
            foreach (Transform chind in root)
            {
                //因为这里是写例子，所以我用的是UILabel 
                //这里应该是写你用于图文混排的脚本。
                Text label = chind.GetComponent<Text>();
                Regex chineseCharRegex = new Regex("[\u4e00-\u9fa5]", RegexOptions.Compiled);
                if (label != null)
                {
                    string text = label.text;
                    
                    // 判断是否包含中文字符
                    if (!chineseCharRegex.IsMatch(text))
                    {
                        continue;
                    }
                    
                    if (!Localization.Contains(text) && !string.IsNullOrEmpty(text))
                    {
                        Localization.Add(text);
                        text = text.Replace("\n", @"\n");
                        staticWriteText += path + "   " + text + "\n";
                    }
                }

                if (chind.childCount > 0)
                    SearchPrefabString(path, chind);
            }
        }
    }
}