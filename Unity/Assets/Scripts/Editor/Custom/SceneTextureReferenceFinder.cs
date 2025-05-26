using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ET.Client
{
    public class SceneTextureReferenceFinder : MonoBehaviour
    {
        private static readonly string scenesPath = "Assets/Bundles/Scenes";
        private static readonly string outputPath = "Assets/场景中引用的贴图.txt";

        private class TextureInfo
        {
            public HashSet<string> scenes = new HashSet<string>();  // 引用的场景集合
            public long size;                                     // 贴图存储大小
            public int totalReferences;                            // 总引用次数（所有场景）
            public Dictionary<string, int> sceneReferences = new Dictionary<string, int>(); // 各场景的引用次数
        }

        [MenuItem("Tools/检测场景中引用的贴图【单个】")]
        public static void FindTextureReferencesSingle()
        {
            Log.Debug("查找开始！");

            string outputPath = "Assets/场景中引用的贴图单个场景.txt";
            // 1. 收集所有场景的贴图信息
            var renderers = GameObject.FindObjectsOfType<Renderer>();
            Dictionary<Texture, int> currentSceneTextures = new Dictionary<Texture, int>();
            foreach (var renderer in renderers)
            {
                var materials = renderer.sharedMaterials;
                foreach (var material in materials)
                {
                    if (material == null) continue;
                    foreach (var textureName in material.GetTexturePropertyNames())
                    {
                        Texture texture = material.GetTexture(textureName);
                        if (texture == null)
                        {
                            continue;
                        }
                        if (!currentSceneTextures.ContainsKey(texture))
                        {
                            currentSceneTextures.Add(texture, 0);
                        }

                        // 更新场景引用信息
                        currentSceneTextures[texture]++;
                    }
                }
            }

            // 2. 生成按场景组织的输出
            List<string> result = new List<string>();
            foreach (var sceneEntry in currentSceneTextures)
            {
                Texture texture = sceneEntry.Key;
                string path = AssetDatabase.GetAssetPath(texture);
             
                string totalSceneRefs = sceneEntry.Value.ToString();

                result.Add(
                    $"引用：{totalSceneRefs,-10} " +
                    $"{path}"
                );
               
            }
            result.Add(""); // 空行分隔场景
            // 3. 写入文件
            File.WriteAllLines(outputPath, result);
            AssetDatabase.Refresh();

            Log.Debug($"查找结束！ 文件保存在 {outputPath}");
        }


        [MenuItem("Tools/检测场景中引用的贴图【全部】")]
        public static void FindTextureReferencesAll()
        {
            Log.Debug("查找开始！");

            // 全局字典存储贴图信息
            Dictionary<Texture, TextureInfo> textureInfoDict = new Dictionary<Texture, TextureInfo>();
            // 记录每个场景包含的贴图（去重后）
            Dictionary<string, HashSet<Texture>> sceneTextures = new Dictionary<string, HashSet<Texture>>();

            // 1. 收集所有场景的贴图信息
            string[] sceneGuids = AssetDatabase.FindAssets("t:Scene", new[] { scenesPath });
            foreach (string sceneGuid in sceneGuids)
            {
                string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);
                string sceneName = Path.GetFileNameWithoutExtension(scenePath);
                EditorSceneManager.OpenScene(scenePath);

                HashSet<Texture> currentSceneTextures = new HashSet<Texture>();
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
                            if (texture != null)
                            {
                                currentSceneTextures.Add(texture);

                                if (!textureInfoDict.TryGetValue(texture, out TextureInfo info))
                                {
                                    info = new TextureInfo
                                    {
                                        size = GetTextureFileSize(texture),
                                        scenes = new HashSet<string>(),
                                        sceneReferences = new Dictionary<string, int>(),
                                        totalReferences = 0
                                    };
                                    textureInfoDict[texture] = info;
                                }

                                // 更新场景引用信息
                                info.scenes.Add(sceneName);
                                if (info.sceneReferences.ContainsKey(sceneName))
                                {
                                    info.sceneReferences[sceneName]++;
                                }
                                else
                                {
                                    info.sceneReferences[sceneName] = 1;
                                }
                                info.totalReferences++;
                            }
                        }
                    }
                }

                sceneTextures[sceneName] = currentSceneTextures;
            }

            // 2. 生成按场景组织的输出
            List<string> result = new List<string>();
            foreach (var sceneEntry in sceneTextures)
            {
                string sceneName = sceneEntry.Key;
                var textures = sceneEntry.Value;

                // 提取当前场景的贴图信息
                var sceneTextureInfos = new List<(Texture texture, TextureInfo info)>();
                foreach (var texture in textures)
                {
                    if (textureInfoDict.TryGetValue(texture, out TextureInfo info))
                    {
                        sceneTextureInfos.Add((texture, info));
                    }
                }

                // 排序：按贴图大小 > 当前场景引用次数 > 路径
                sceneTextureInfos = sceneTextureInfos
                    .OrderByDescending(t => t.info.size)
                    .ThenByDescending(t => t.info.sceneReferences[sceneName])
                    .ThenBy(t => AssetDatabase.GetAssetPath(t.texture))
                    .ToList();

                result.Add($"{sceneName}:");

                if (sceneTextureInfos.Count == 0)
                {
                    result.Add("   没有引用的贴图.");
                }
                else
                {
                    foreach (var (texture, info) in sceneTextureInfos)
                    {
                        string path = AssetDatabase.GetAssetPath(texture);
                        string sizeFormatted = FormatBytes(info.size);
                        string dimensions = $"{texture.width}x{texture.height}";
                        string sceneRefCount = info.sceneReferences[sceneName].ToString();
                        string totalSceneRefs = info.scenes.Count.ToString();

                        result.Add(
                            $"  大小：{sizeFormatted,-10} " +
                            $"尺寸：{dimensions,-12} " +
                            $"引用：{sceneRefCount,-3} " +
                            $"场景：{totalSceneRefs,-3} " +
                            $"{path}"
                        );
                    }
                }
                result.Add(""); // 空行分隔场景
            }

            // 3. 写入文件
            File.WriteAllLines(outputPath, result);
            AssetDatabase.Refresh();

            Log.Debug($"查找结束！ 文件保存在 {outputPath}");
        }

        // 获取Texture的存储内存大小
        private static long GetTextureFileSize(Texture texture)
        {
            long fileSize = 0;

            Type textureUtilType = typeof(TextureImporter).Assembly.GetType("UnityEditor.TextureUtil");
            MethodInfo getStorageMemorySizeLongMethod =
                    textureUtilType.GetMethod("GetStorageMemorySizeLong", BindingFlags.Static | BindingFlags.Public);
            fileSize = (long)getStorageMemorySizeLongMethod.Invoke(null, new object[] { texture });

            return fileSize;
        }

        // 获取Texture的运行时内存大小
        private static long GetTextureRuntimeMemorySize(Texture texture)
        {
            long memorySize = 0;

            Type textureUtilType = typeof(TextureImporter).Assembly.GetType("UnityEditor.TextureUtil");
            MethodInfo getRuntimeMemorySizeLongMethod =
                    textureUtilType.GetMethod("GetRuntimeMemorySizeLong", BindingFlags.Static | BindingFlags.Public);
            memorySize = (long)getRuntimeMemorySizeLongMethod.Invoke(null, new object[] { texture });

            return memorySize;
        }

        private static string FormatBytes(long bytes)
        {
            if (bytes >= 1073741824)
                return $"{bytes / 1073741824f:0.00} GB";
            if (bytes >= 1048576)
                return $"{bytes / 1048576f:0.00} MB";
            if (bytes >= 1024)
            {
                float sizeInMB = bytes / 1048576f;
                float sizeInKB = bytes / 1024f;
                // return $"{sizeInKB:0.00} KB / {sizeInMB:0.00} MB ";
                return $"{sizeInKB:0.00} KB";
            }

            return $"{bytes} B";
        }
    }
}