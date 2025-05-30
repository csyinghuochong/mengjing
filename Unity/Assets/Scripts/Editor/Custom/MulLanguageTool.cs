using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine.UI;

namespace ET.Client
{
    public class MulLanguageTool : Editor
    {
        [MenuItem("Tools/多语言工具/_提示:Edit运行，读取I2Languages.asset；真机运行，读取资源包中I2_XXX.csv")]
        static void Tip()
        {
        }
    }

    public class MulLanguageTool_1 : Editor
    {
        private static string UIPrefabPath = Application.dataPath + "/Bundles/UI";
        private static string ScriptPath = Application.dataPath + "/Scripts";
        private static string OutPath = Application.dataPath + "/Editor/I2Localization/I2_AllSource.csv";

        private static List<string> Localization = new List<string>();
        private static Dictionary<string, string> ExistingChineseMap = new Dictionary<string, string>();
        private static List<string> NewRows = new List<string>();
        private static int CurrentMaxKey = 10000;

        [MenuItem("Tools/多语言工具/1.从UI和脚本中提取出中文到I2_AllSource.csv")]
        static void ExportChinese()
        {
            Localization.Clear();
            ExistingChineseMap.Clear();
            NewRows.Clear();
            CurrentMaxKey = 10000;

            LoadExistingCsv();

            LoadDiectoryPrefab(new DirectoryInfo(UIPrefabPath));
            LoadDiectoryCS(new DirectoryInfo(ScriptPath));

            SaveToCsv();
            AssetDatabase.Refresh();
        }

        static void LoadExistingCsv()
        {
            if (!File.Exists(OutPath)) return;

            var lines = File.ReadAllLines(OutPath);
            foreach (var line in lines.Skip(1)) // Skip header
            {
                var fields = ParseCsvLine(line);
                if (fields.Length >= 4)
                {
                    string key = fields[0];
                    string chinese = NormalizeChinese(fields[3]);

                    if (!ExistingChineseMap.ContainsKey(chinese))
                    {
                        ExistingChineseMap[chinese] = key;

                        if (int.TryParse(key, out int intKey))
                        {
                            CurrentMaxKey = Mathf.Max(CurrentMaxKey, intKey);
                        }
                    }
                }
            }
        }

        static void SaveToCsv()
        {
            List<string> allLines = new List<string>();
            if (File.Exists(OutPath))
            {
                allLines = File.ReadAllLines(OutPath).ToList();
            }
            else
            {
                allLines.Add("Key,Type,Desc,Chinese,English");
            }

            allLines.AddRange(NewRows);
            File.WriteAllLines(OutPath, allLines, Encoding.UTF8);
        }

        static void AddLocalization(string text)
        {
            string normalized = NormalizeChinese(text);
            if (ExistingChineseMap.ContainsKey(normalized) || Localization.Contains(normalized) || string.IsNullOrEmpty(normalized)) return;

            Localization.Add(normalized);
            CurrentMaxKey++;

            string escapedText = text.Replace("\r", "").Replace("\n", "\\n");
            string line = $"{CurrentMaxKey},Text,,{EscapeCsv(escapedText)},null";
            NewRows.Add(line);
        }

        static string NormalizeChinese(string raw)
        {
            return raw.Trim()
                    .Replace("\\n", "") // 如果原CSV中是转义的 \n
                    .Replace("\n", "")
                    .Replace("\r", "")
                    .Replace(" ", ""); // 可选：移除空格
        }

        static string EscapeCsv(string text)
        {
            if (text.Contains(",") || text.Contains("\"") || text.Contains("\n") || text.Contains("\r"))
            {
                text = text.Replace("\"", "\"\"");
                return $"\"{text}\"";
            }

            return text;
        }

        static string[] ParseCsvLine(string line)
        {
            var pattern = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
            return Regex.Split(line, pattern).Select(s =>
            {
                string cleaned = s.Trim();
                if (cleaned.StartsWith("\"") && cleaned.EndsWith("\""))
                {
                    cleaned = cleaned.Substring(1, cleaned.Length - 2).Replace("\"\"", "\"");
                }

                return cleaned;
            }).ToArray();
        }

        static void LoadDiectoryPrefab(DirectoryInfo dictoryInfo)
        {
            if (!dictoryInfo.Exists) return;

            FileInfo[] fileInfos = dictoryInfo.GetFiles("*.prefab", SearchOption.AllDirectories);
            foreach (FileInfo file in fileInfos)
            {
                string path = file.FullName;
                int index = Application.dataPath.Length - 6;
                string assetPath = path.Substring(index);
                GameObject prefab = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
                if (prefab == null) continue;

                GameObject instance = GameObject.Instantiate(prefab) as GameObject;
                SearchPrefabString(file.FullName, instance.transform);
                GameObject.DestroyImmediate(instance);
            }
        }

        static void LoadDiectoryCS(DirectoryInfo dictoryInfo)
        {
            if (!dictoryInfo.Exists) return;

            FileInfo[] fileInfos = dictoryInfo.GetFiles("*.cs", SearchOption.AllDirectories);
            Regex reg = new Regex("\"(.*?)\"", RegexOptions.Compiled);
            Regex chineseCharRegex = new Regex("[\u4e00-\u9fa5]", RegexOptions.Compiled);

            foreach (FileInfo file in fileInfos)
            {
                string text = File.ReadAllText(file.FullName);
                MatchCollection matches = reg.Matches(text);

                foreach (Match match in matches)
                {
                    string content = match.Groups[1].Value;
                    if (chineseCharRegex.IsMatch(content))
                    {
                        AddLocalization(content);
                    }
                }
            }
        }

        static void SearchPrefabString(string path, Transform root)
        {
            foreach (Transform child in root)
            {
                Text label = child.GetComponent<Text>();
                Regex chineseCharRegex = new Regex("[\u4e00-\u9fa5]", RegexOptions.Compiled);
                if (label != null)
                {
                    string text = label.text;
                    if (chineseCharRegex.IsMatch(text))
                    {
                        AddLocalization(text);
                    }
                }

                if (child.childCount > 0)
                    SearchPrefabString(path, child);
            }
        }
    }

    public class MulLanguageTool_2 : Editor
    {
        public static string UII2SourceResPath = "Assets/Editor/I2Localization"; //这是编辑器下的数据 平台运行时 是不需要的
        public static string UII2SourceResName = "AllSource";
        public static string UII2TargetLanguageResPath = "Assets/Bundles/Text";
        static LanguageSourceData m_LanguageSourceData;

        [MenuItem("Tools/多语言工具/2.从I2_AllSource.csv导入配置到I2Languages.asset")]
        static void ImportAllCsv()
        {
            var editorAsset = LocalizationManager.GetEditorAsset(true);
            m_LanguageSourceData = editorAsset?.SourceData;

            if (m_LanguageSourceData == null)
            {
                Log.Error($"没有找到多语言编辑器下的源数据 请检查 {I2LocalizeHelper.I2GlobalSourcesEditorPath}");
                return;
            }

            var path = GetSourceResPath();

            try
            {
                var content = LocalizationReader.ReadCSVfile(path, Encoding.UTF8);
                var sError =
                        m_LanguageSourceData.Import_CSV(string.Empty, content, eSpreadsheetUpdateMode.Replace, ',');
                if (!string.IsNullOrEmpty(sError))
                    Log.Error($"导入全数据时发生错误 请检查 {sError} {path}");
            }
            catch (Exception e)
            {
                Log.Error($"导入全数据时发生错误 请检查 {path}");
                Debug.LogError(e);
                return;
            }

            Log.Debug($"导入全数据完成 {path}");
        }

        [MenuItem("Tools/多语言工具/3.从I2Languages.asset导出配置到I2_AllSource.csv和资源包中")]
        static void ExportAllCsv()
        {
            var editorAsset = LocalizationManager.GetEditorAsset(true);
            m_LanguageSourceData = editorAsset?.SourceData;

            if (m_LanguageSourceData == null)
            {
                Log.Error($"没有找到多语言编辑器下的源数据 请检查 {I2LocalizeHelper.I2GlobalSourcesEditorPath}");
                return;
            }

            var path = GetSourceResPath();

            try
            {
                var content = Export_CSV(null);
                File.WriteAllText(path, content, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Log.Error($"导出全数据时发生错误 请检查");
                Debug.LogError(e);
                return;
            }

            Debug.Log($"多语言 全数据 {UII2SourceResName} 导出CSV成功 {path}");

            var projPath = GetProjPath(UII2TargetLanguageResPath);
            if (!Directory.Exists(projPath))
            {
                Directory.CreateDirectory(projPath);
            }

            foreach (var languages in m_LanguageSourceData.mLanguages)
            {
                var targetPath = "";

                try
                {
                    var content = Export_CSV(languages.Name);
                    targetPath = $"{projPath}/{I2LocalizeHelper.I2ResAssetNamePrefix}{languages.Name}.csv";
                    File.WriteAllText(targetPath, content, Encoding.UTF8);
                }
                catch (Exception e)
                {
                    Log.Error($"导出指定数据时发生错误 {languages.Name} 请检查 ");
                    Debug.LogError(e);
                    return;
                }

                Debug.Log($"多语言 指定数据 {languages.Name} 导出CSV成功 {targetPath}");
            }

            Log.Debug($"导出全数据完成 {path}");
        }

        static string GetSourceResPath()
        {
            var projPath = GetProjPath(UII2SourceResPath);
            var path = $"{projPath}/{I2LocalizeHelper.I2ResAssetNamePrefix}{UII2SourceResName}.csv";
            return path;
        }

        static string GetProjPath(string relativePath = "")
        {
            if (relativePath == null)
            {
                relativePath = "";
            }

            relativePath = relativePath.Trim();
            if (!string.IsNullOrEmpty(relativePath))
            {
                if (relativePath.Contains("\\"))
                {
                    relativePath = relativePath.Replace("\\", "/");
                }

                if (!relativePath.StartsWith("/"))
                {
                    relativePath = "/" + relativePath;
                }
            }

            string projFolder = Application.dataPath;
            return projFolder.Substring(0, projFolder.Length - 7) + relativePath;
        }

        static string Export_CSV(string selectLanguage)
        {
            char Separator = ',';
            var Builder = new StringBuilder();

            var languages = m_LanguageSourceData.mLanguages;
            var languagesCount = languages.Count;
            Builder.AppendFormat("Key{0}Type{0}Desc", Separator);
            var currentLanguageIndex = -1;

            for (int i = 0; i < languagesCount; i++)
            {
                var langData = languages[i];

                var currentLanguage = GoogleLanguages.GetCodedLanguage(langData.Name, langData.Code);

                if (!string.IsNullOrEmpty(selectLanguage) && currentLanguage != selectLanguage)
                {
                    continue;
                }

                Builder.Append(Separator);
                if (!langData.IsEnabled())
                    Builder.Append('$');
                AppendString(Builder, currentLanguage, Separator);
                currentLanguageIndex = i;
            }

            if (string.IsNullOrEmpty(selectLanguage))
            {
                currentLanguageIndex = -1;
            }

            Builder.Append("\n");

            var terms = m_LanguageSourceData.mTerms;

            if (string.IsNullOrEmpty(selectLanguage))
            {
                terms.Sort((a, b) => string.CompareOrdinal(a.Term, b.Term));
            }

            foreach (var termData in terms)
            {
                var term = termData.Term;

                foreach (var specialization in termData.GetAllSpecializations())
                    AppendTerm(Builder, currentLanguageIndex, term, termData, specialization, Separator);
            }

            return Builder.ToString();
        }

        static void AppendTerm(StringBuilder Builder, int selectLanguageIndex, string Term, TermData termData, string specialization, char Separator)
        {
            //--[ Key ] --------------				
            AppendString(Builder, Term, Separator);

            if (!string.IsNullOrEmpty(specialization) && specialization != "Any")
                Builder.AppendFormat("[{0}]", specialization);

            //--[ Type and Description ] --------------
            Builder.Append(Separator);
            Builder.Append(termData.TermType.ToString());
            Builder.Append(Separator);
            AppendString(Builder, selectLanguageIndex <= -1 ? termData.Description : "", Separator);

            var startIndex = selectLanguageIndex <= -1 ? 0 : selectLanguageIndex;
            var maxIndex = selectLanguageIndex <= -1 ? termData.Languages.Length : selectLanguageIndex + 1;

            //--[ Languages ] --------------
            for (var i = startIndex; i < maxIndex; ++i)
            {
                Builder.Append(Separator);

                var translation = termData.Languages[i];
                if (!string.IsNullOrEmpty(specialization))
                    translation = termData.GetTranslation(i, specialization);

                AppendTranslation(Builder, translation, Separator, null);
            }

            Builder.Append("\n");
        }

        private static void AppendString(StringBuilder Builder, string Text, char Separator)
        {
            if (string.IsNullOrEmpty(Text))
                return;
            Text = Text.Replace("\\n", "\n");
            if (Text.IndexOfAny((Separator + "\n\"").ToCharArray()) >= 0)
            {
                Text = Text.Replace("\"", "\"\"");
                Builder.AppendFormat("\"{0}\"", Text);
            }
            else
            {
                Builder.Append(Text);
            }
        }

        private static void AppendTranslation(StringBuilder Builder, string Text, char Separator, string tags)
        {
            if (string.IsNullOrEmpty(Text))
                return;
            Text = Text.Replace("\\n", "\n");
            if (Text.IndexOfAny((Separator + "\n\"").ToCharArray()) >= 0)
            {
                Text = Text.Replace("\"", "\"\"");
                Builder.AppendFormat("\"{0}{1}\"", tags, Text);
            }
            else
            {
                Builder.Append(tags);
                Builder.Append(Text);
            }
        }
    }

    public class MulLanguageTool_3 : Editor
    {
        //UIPrefab文件夹目录
        private static string UIPrefabPath = Application.dataPath + "/Bundles/UI";

        //脚本的文件夹目录
        private static string ScriptPath = Application.dataPath + "/Scripts";

        //导出的中文KEY路径
        private static string OutPath = Application.dataPath + "/out.txt";

        private static List<string> Localization = null;
        private static string staticWriteText = "";

        [MenuItem("Tools/多语言工具/3.给UI挂上多语言组件")]
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