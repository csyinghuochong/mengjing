using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace ET.Client
{
    public static class SceneResourceMover
    {
        private const string ScenesRoot = "Assets/Bundles/Scenes";
        private const string OutputRoot = "Assets/ScenesRes";

        //[MenuItem("Tools/单个场景资源引用到的shader")]
        private static void SingleSceneShaderReference()
        {
            // 打开文件面板让用户选择场景
            string scenePath = EditorUtility.OpenFilePanel("选择场景", ScenesRoot, "unity");

            if (string.IsNullOrEmpty(scenePath))
            {
                Debug.LogWarning("未选择任何场景。");
                return;
            }

            // 将绝对路径转换为相对路径
            if (!scenePath.StartsWith(Application.dataPath))
            {
                Debug.LogError("只能在项目的 Assets 目录下选择场景。");
                return;
            }

            scenePath = "Assets" + scenePath.Substring(Application.dataPath.Length);

            // 获取所有依赖
            string[] dependencies = AssetDatabase.GetDependencies(scenePath, true);
            var movedCount = 0;

            foreach (var assetPath in dependencies)
            {
                if (assetPath == scenePath)
                    continue; // 跳过场景自身

                string fileName = Path.GetFileName(assetPath);

                if (fileName.Contains(".shader"))
                {
                    UnityEngine.Debug.Log(assetPath);
                }
                // 如果目标已存在则跳过
            }
        }

        [MenuItem("Tools/单个场景资源整理[全部移动]")]
        private static void MoveSceneResourcesMenu()
        {
            // 打开文件面板让用户选择场景
            string scenePath = EditorUtility.OpenFilePanel("选择场景", ScenesRoot, "unity");

            if (string.IsNullOrEmpty(scenePath))
            {
                Debug.LogWarning("未选择任何场景。");
                return;
            }

            // 将绝对路径转换为相对路径
            if (!scenePath.StartsWith(Application.dataPath))
            {
                Debug.LogError("只能在项目的 Assets 目录下选择场景。");
                return;
            }

            scenePath = "Assets" + scenePath.Substring(Application.dataPath.Length);

            MoveSceneResources(scenePath);
        }

        private static void MoveSceneResources(string scenePath)
        {
            if (!scenePath.EndsWith(".unity"))
            {
                Debug.LogError("选中的文件不是有效的场景 (.unity)。");
                return;
            }

            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            string targetFolder = $"{OutputRoot}/{sceneName}_2";

            // 确保输出根目录存在
            if (!AssetDatabase.IsValidFolder(OutputRoot))
            {
                AssetDatabase.CreateFolder("Assets", "ScenesRes");
            }

            // 确保目标场景子目录存在
            if (!AssetDatabase.IsValidFolder(targetFolder))
            {
                AssetDatabase.CreateFolder(OutputRoot, sceneName + "_2");
            }

            // 获取所有依赖
            string[] dependencies = AssetDatabase.GetDependencies(scenePath, true);
            var movedCount = 0;

            foreach (var assetPath in dependencies)
            {
                if (assetPath == scenePath)
                    continue; // 跳过场景自身

                if (!IsValidResource(assetPath))
                {
                    continue;
                }

                string fileName = Path.GetFileName(assetPath);
                string destPath = $"{targetFolder}/{fileName}";

                // 如果目标已存在则跳过
                if (AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(destPath) != null)
                {
                    continue;
                }

                var error = AssetDatabase.MoveAsset(assetPath, destPath);
                if (!string.IsNullOrEmpty(error))
                {
                    // Debug.LogError($"移动失败: {assetPath} -> {destPath}\n{error}");
                }
                else
                {
                    movedCount++;
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"已将场景 '{sceneName}' 的 {movedCount} 个资源移动到 '{targetFolder}'。");
        }

        private static bool IsValidResource(string path)
        {
            var type = AssetDatabase.GetMainAssetTypeAtPath(path);
            return type == typeof(Material)
                    || type == typeof(Texture2D)
                    || type == typeof(GameObject);
                    // || (type == typeof(GameObject) && path.EndsWith(".prefab"));
        }
    }
}