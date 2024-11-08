using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.SceneManagement;

namespace ET.Client
{
    public class SceneTextureReferenceFinder : MonoBehaviour
    {
        private static readonly string scenesPath = "Assets/Bundles/Scenes";
        private static readonly string outputPath = "Assets/场景中引用的贴图.txt";

        [MenuItem("Tools/场景中引用的贴图")]
        public static void FindTextureReferences()
        {
            Log.Debug("查找开始！");

            List<string> result = new List<string>();

            // 查找场景文件
            string[] sceneGuids = AssetDatabase.FindAssets("t:Scene", new[] { scenesPath });
            foreach (string sceneGuid in sceneGuids)
            {
                string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);
                string sceneName = Path.GetFileNameWithoutExtension(scenePath);

                // 打开场景
                EditorSceneManager.OpenScene(scenePath);

                // 查找场景中的所有贴图引用及大小
                List<(Texture texture, long size)> texturesInScene = new List<(Texture, long)>();
                var renderers = GameObject.FindObjectsOfType<Renderer>();

                foreach (var renderer in renderers)
                {
                    var materials = renderer.sharedMaterials;
                    foreach (var material in materials)
                    {
                        if (material == null) continue;
                        foreach (var textureName in material.GetTexturePropertyNames())
                        {
                            Texture texture = material.GetTexture(textureName);
                            if (texture != null && texturesInScene.All(t => t.texture != texture))
                            {
                                long textureSize = GetTextureSizeInBytes(texture);
                                if (textureSize > 0)
                                {
                                    texturesInScene.Add((texture, textureSize));
                                }
                            }
                        }
                    }
                }

                // 按大小从大到小排序
                texturesInScene = texturesInScene.OrderByDescending(t => t.size).ToList();

                // 收集输出信息
                result.Add($"{sceneName}:");
                foreach (var (texture, size) in texturesInScene)
                {
                    result.Add($"  {texture.name} - {FormatBytes(size)}");
                    // result.Add($"  {texture.name} - {FormatBytes(size)} - Path: {AssetDatabase.GetAssetPath(texture)}");
                }

                result.Add(""); // 空行分隔场景
            }

            // 写入到文件
            File.WriteAllLines(outputPath, result);
            AssetDatabase.Refresh();

            Log.Debug($"查找结束！ 文件保存在 {outputPath}");
        }

        private static long GetTextureSizeInBytes(Texture texture)
        {
            string path = AssetDatabase.GetAssetPath(texture);

            // 检查路径是否为空
            if (string.IsNullOrEmpty(path))
            {
                Log.Warning($"Texture '{texture.name}' does not have a valid path.");
                return 0;
            }

            FileInfo fileInfo = new FileInfo(path);

            // 检查文件是否存在
            if (!fileInfo.Exists)
            {
                Log.Warning($"Texture file '{path}' for texture '{texture.name}' does not exist.");
                return 0;
            }

            return fileInfo.Length;
        }

        private static string FormatBytes(long bytes)
        {
            if (bytes >= 1073741824)
                return $"{bytes / 1073741824f:0.00} GB";
            if (bytes >= 1048576)
                return $"{bytes / 1048576f:0.00} MB";
            if (bytes >= 1024)
                return $"{bytes / 1024f:0.00} KB";
            return $"{bytes} B";
        }
    }
}