﻿using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.SceneManagement;
using System.Reflection;

namespace ET.Client
{
    public class SceneTextureReferenceFinder : MonoBehaviour
    {
        private static readonly string scenesPath = "Assets/Bundles/Scenes";
        private static readonly string outputPath = "Assets/场景中引用的贴图.txt";

        [MenuItem("Tools/检测场景中引用的贴图")]
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
                List<(Texture texture, long size, int count)> texturesInScene = new List<(Texture, long, int)>();
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
                                var existingTexture = texturesInScene.FirstOrDefault(t => t.texture == texture);
                                if (existingTexture.texture != null)
                                {
                                    // 如果贴图已存在，则增加引用计数
                                    texturesInScene.Remove(existingTexture);
                                    texturesInScene.Add((existingTexture.texture, existingTexture.size, existingTexture.count + 1));
                                }
                                else
                                {
                                    // 如果是新贴图，则添加到列表
                                    long textureSize = GetTextureFileSize(texture);
                                    if (textureSize > 0)
                                    {
                                        texturesInScene.Add((texture, textureSize, 1));
                                    }
                                }
                            }
                        }
                    }
                }

                if (texturesInScene.Any())
                {
                    // 按大小、引用次数和路径名排序
                    texturesInScene = texturesInScene
                            .OrderByDescending(t => t.size)
                            .ThenByDescending(t => t.count)
                            .ThenBy(t => AssetDatabase.GetAssetPath(t.texture))
                            .ToList();

                    // 收集输出信息
                    result.Add($"{sceneName}:");

                    foreach (var (texture, size, count) in texturesInScene)
                    {
                        string path = AssetDatabase.GetAssetPath(texture);
                        string sizeFormatted = FormatBytes(size);
                        string countFormatted = count.ToString();

                        result.Add(string.Format("  大小：{0,-" + 15 + "} 尺寸：{1,-" + 12 + "} 引用：{2,-" + 10 + "} {3}",
                            sizeFormatted,
                            texture.width + "x" + texture.height,
                            countFormatted,
                            path));
                    }

                    result.Add("");
                }
                else
                {
                    result.Add($"{sceneName}: 没有引用的贴图.");
                }
            }

            // 写入到文件
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