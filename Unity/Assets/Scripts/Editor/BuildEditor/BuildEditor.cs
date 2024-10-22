using System;
using System.IO;
using System.Text;
using I2.Loc;
using UnityEditor;
using UnityEngine;
using YooAsset;

namespace ET
{
    public enum PlatformType
    {
        None,
        Android,
        IOS,
        Windows,
        MacOS,
        Linux
    }

    /// <summary>
    /// ET菜单顺序
    /// </summary>
    public static class ETMenuItemPriority
    {
        public const int BuildTool = 1001;
        public const int ChangeDefine = 1002;
        public const int Compile = 1003;
        public const int Reload = 1004;
        public const int NavMesh = 1005;
        public const int ServerTools = 1006;
    }

    public class BuildEditor : EditorWindow
    {
        private PlatformType activePlatform;
        private PlatformType platformType;
        private BuildOptions buildOptions;

        private GlobalConfig globalConfig;

        [MenuItem("ET/Build Tool", false, ETMenuItemPriority.BuildTool)]
        public static void ShowWindow()
        {
            GetWindow<BuildEditor>(DockDefine.Types);
        }

        private void OnEnable()
        {
            globalConfig = AssetDatabase.LoadAssetAtPath<GlobalConfig>("Assets/Resources/GlobalConfig.asset");

#if UNITY_ANDROID
            activePlatform = PlatformType.Android;
#elif UNITY_IOS
            activePlatform = PlatformType.IOS;
#elif UNITY_STANDALONE_WIN
            activePlatform = PlatformType.Windows;
#elif UNITY_STANDALONE_OSX
            activePlatform = PlatformType.MacOS;
#elif UNITY_STANDALONE_LINUX
            activePlatform = PlatformType.Linux;
#else
            activePlatform = PlatformType.None;
#endif
            platformType = activePlatform;
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("PlatformType ");
            this.platformType = (PlatformType)EditorGUILayout.EnumPopup(platformType);

            EditorGUILayout.LabelField("BuildOptions ");
            this.buildOptions = (BuildOptions)EditorGUILayout.EnumFlagsField(this.buildOptions);

            GUILayout.Space(5);

            if (GUILayout.Button("BuildPackage"))
            {
                if (this.platformType == PlatformType.None)
                {
                    Log.Error("please select platform!");
                    return;
                }

                if (this.globalConfig.CodeMode != CodeMode.Client)
                {
                    Log.Error("build package CodeMode must be CodeMode.Client, please select Client");
                    return;
                }

                if (this.globalConfig.EPlayMode == EPlayMode.EditorSimulateMode)
                {
                    Log.Error("build package EPlayMode must not be EPlayMode.EditorSimulateMode, please select HostPlayMode");
                    return;
                }

                if (platformType != activePlatform)
                {
                    switch (EditorUtility.DisplayDialogComplex("Warning!",
                                $"current platform is {activePlatform}, if change to {platformType}, may be take a long time", "change", "cancel",
                                "no change"))
                    {
                        case 0:
                            activePlatform = platformType;
                            break;
                        case 1:
                            return;
                        case 2:
                            platformType = activePlatform;
                            break;
                    }
                }

                BuildHelper.Build(this.platformType, this.buildOptions);
                return;
            }

            if (GUILayout.Button("ExcelExporterSingle"))
            {
                ExcelFileWindow.ShowWindow();
                return;
            }

            if (GUILayout.Button("ExcelExporter"))
            {
                ToolsEditor.ExcelExporter();
                return;
            }

            if (GUILayout.Button("Proto2CS"))
            {
                ToolsEditor.Proto2CS();
                return;
            }

            if (GUILayout.Button("I2Localization 配置导入"))
            {
                ImportAllCsv();
                return;
            }

            if (GUILayout.Button("I2Localization 配置导出"))
            {
                ExportAllCsv();
                return;
            }

            GUILayout.Space(5);
        }

        public const string UII2SourceResPath = "Assets/Editor/I2Localization"; //这是编辑器下的数据 平台运行时 是不需要的
        public const string UII2SourceResName = "AllSource";
        public const string UII2TargetLanguageResPath = "Assets/Bundles/Text";

        #region 导入

        private void ImportAllCsv()
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

        #endregion

        #region 导出

        private LanguageSourceData m_LanguageSourceData;

        private string GetSourceResPath()
        {
            var projPath = GetProjPath(UII2SourceResPath);
            var path = $"{projPath}/{I2LocalizeHelper.I2ResAssetNamePrefix}{UII2SourceResName}.csv";
            return path;
        }

        public static string GetProjPath(string relativePath = "")
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

        private void ExportAllCsv()
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

        #region 导出方法

        private string Export_CSV(string selectLanguage)
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

        private static void AppendTerm(StringBuilder Builder, int selectLanguageIndex, string Term, TermData termData,
        string specialization, char Separator)
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

        #endregion

        #endregion
    }

    public class ExcelFileWindow : EditorWindow
    {
        private string[] excelFiles;
        private Vector2 scrollPosition;

        public static void ShowWindow()
        {
            ExcelFileWindow window = GetWindow<ExcelFileWindow>("Excel Files");
            var mainEditorWindowPos = EditorWindow.GetWindow<BuildEditor>().position;
            window.position = new Rect(mainEditorWindowPos.xMax, mainEditorWindowPos.y, 400, mainEditorWindowPos.height);
            window.Show();
        }

        private void OnEnable()
        {
            string directoryPath = "../Unity/Assets/Config/Excel/";
            if (Directory.Exists(directoryPath))
            {
                excelFiles = Directory.GetFiles(directoryPath, "*.xlsx", SearchOption.AllDirectories);

                for (int i = 0; i < excelFiles.Length; i++)
                {
                    string relativePath = Path.GetRelativePath(directoryPath, excelFiles[i]);
                    excelFiles[i] = relativePath;
                }
            }
            else
            {
                excelFiles = new string[0];
                Debug.LogWarning($"Directory not found: {directoryPath}");
            }
        }

        private void OnGUI()
        {
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            foreach (var fileName in excelFiles)
            {
                if (GUILayout.Button(fileName))
                {
                    HandleExcelFile(fileName);
                }
            }

            EditorGUILayout.EndScrollView();
        }

        private void HandleExcelFile(string fileName)
        {
            ToolsEditor.ExcelExporter(fileName);
        }
    }
}