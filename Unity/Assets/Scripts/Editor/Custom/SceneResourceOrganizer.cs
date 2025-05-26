using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace ET.Client
{
    public class SceneResourceOrganizer : EditorWindow
    {
        private const string ScenesRoot = "Assets/Bundles/Scenes";
        private const string OutputRoot = "Assets/ScenesRes";

        private bool processAllScenes = true;
        private string singleScenePath;
        private List<string> allScenePaths;

        //[MenuItem("Tools/场景资源整理[公用不移动]")] 
        public static void ShowWindow() => GetWindow<SceneResourceOrganizer>("场景资源整理工具");

        private void OnEnable()
        {
            // 缓存所有场景路径
            allScenePaths = GetAllScenePaths();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("处理模式:", EditorStyles.boldLabel);
            processAllScenes = EditorGUILayout.ToggleLeft("处理所有场景", processAllScenes);

            if (!processAllScenes)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("选择单个场景:");
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.TextField(singleScenePath);
                if (GUILayout.Button("浏览", GUILayout.Width(60)))
                {
                    SelectSingleScene();
                }
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.Space(20);
            if (GUILayout.Button("开始处理", GUILayout.Height(30)))
            {
                if (processAllScenes)
                    ProcessScenes(allScenePaths);
                else if (!string.IsNullOrEmpty(singleScenePath))
                    ProcessScenes(new[] { singleScenePath });
                else
                    EditorUtility.DisplayDialog("错误", "请先选择场景文件", "确定");
            }
        }

        private void SelectSingleScene()
        {
            string path = EditorUtility.OpenFilePanel("选择场景", ScenesRoot, "unity");
            if (string.IsNullOrEmpty(path)) return;
            singleScenePath = path.StartsWith(Application.dataPath) ? "Assets" + path.Substring(Application.dataPath.Length) : path;
        }

        private static List<string> GetAllScenePaths()
        {
            var guids = AssetDatabase.FindAssets("t:Scene", new[] { ScenesRoot });
            var paths = new List<string>(guids.Length);
            foreach (var guid in guids)
            {
                paths.Add(AssetDatabase.GUIDToAssetPath(guid));
            }
            return paths;
        }

        private static void ProcessScenes(IEnumerable<string> scenes)
        {
            // 收集全局资源使用
            var globalUsage = AnalyzeGlobalDependencies(GetAllScenePaths());
            int totalProcessed = 0, movedCount = 0;

            foreach (var scene in scenes)
            {
                var deps = AssetDatabase.GetDependencies(scene);
                foreach (var dep in deps)
                {
                    if (!IsValidResource(dep) || !globalUsage.ContainsKey(dep))
                        continue;

                    totalProcessed++;
                    if (globalUsage[dep].Count == 1 && globalUsage[dep].Contains(scene))
                    {
                        if (TryMoveResource(dep, scene))
                            movedCount++;
                    }
                }
            }

            RefreshAssets();
            EditorUtility.DisplayDialog("完成", $"资源整理完成!\n处理资源总数: {totalProcessed}\n移动独立资源: {movedCount}", "确定");
        }

        private static Dictionary<string, HashSet<string>> AnalyzeGlobalDependencies(List<string> allScenes)
        {
            var usage = new Dictionary<string, HashSet<string>>();
            int count = allScenes.Count;

            try
            {
                for (int i = 0; i < count; i++)
                {
                    string scenePath = allScenes[i];
                    if (EditorUtility.DisplayCancelableProgressBar("分析全局引用", $"扫描场景 ({i+1}/{count}): {Path.GetFileName(scenePath)}", (float)i / count))
                        break;

                    foreach (var dep in AssetDatabase.GetDependencies(scenePath))
                    {
                        if (!IsValidResource(dep)) continue;
                        if (!usage.TryGetValue(dep, out var set))
                        {
                            set = new HashSet<string>();
                            usage[dep] = set;
                        }
                        set.Add(scenePath);
                    }
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }

            return usage;
        }

        private static bool TryMoveResource(string assetPath, string scenePath)
        {
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            string targetFolder = Path.Combine(OutputRoot, sceneName);
            if (!AssetDatabase.IsValidFolder(targetFolder))
                AssetDatabase.CreateFolder(OutputRoot, sceneName);

            string destination = Path.Combine(targetFolder, Path.GetFileName(assetPath));
            if (assetPath == destination) return false;

            string error = AssetDatabase.MoveAsset(assetPath, destination);
            if (!string.IsNullOrEmpty(error))
                Debug.LogWarning($"[SceneResourceOrganizer] 移动失败: {error}");
            return string.IsNullOrEmpty(error);
        }

        private static bool IsValidResource(string path)
        {
            var type = AssetDatabase.GetMainAssetTypeAtPath(path);
            return type == typeof(Material)
                || type == typeof(Texture2D)
                || (type == typeof(GameObject) && path.EndsWith(".prefab"));
        }

        private static void RefreshAssets()
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
