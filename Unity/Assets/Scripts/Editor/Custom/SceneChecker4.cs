using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ET.Client
{
    public class SceneChecker4 : EditorWindow
    {
        [MenuItem("Tools/检测场景顶点数【全部】")]
        static void CalculateVerticesAll()
        {
            // 1. 收集所有场景的贴图信息
            string scenesPath = "Assets/Bundles/Scenes";
            string outputPath = "Assets/检测场景顶点数.txt";
            string[] sceneGuids = AssetDatabase.FindAssets("t:Scene", new[] { scenesPath });

            List<string> alldingdianshu = new List<string>();

            foreach (string sceneGuid in sceneGuids)
            {
                string scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);
                string sceneName = Path.GetFileNameWithoutExtension(scenePath);
                EditorSceneManager.OpenScene(scenePath);


                int totalVertices = 0;
                var renderers = FindObjectsOfType<Renderer>(true); // 包含隐藏对象

                List<KeyValuePair> bigname = new List<KeyValuePair>();

                int vertextdebug = 0;
                foreach (var renderer in renderers)
                {
                    if (renderer is MeshRenderer meshRenderer)
                    {
                        var meshFilter = meshRenderer.GetComponent<MeshFilter>();
                        if (meshFilter != null && meshFilter.sharedMesh != null)
                        {
                            if (meshFilter.sharedMesh.vertexCount > vertextdebug)
                            {
                                //Log.Debug($"统计场景顶点数:  vertexCount: {meshFilter.sharedMesh.vertexCount}   {renderer.gameObject.name}");


                                KeyValuePair keyValuePair = bigname.FirstOrDefault(p => p.Value2.Equals(renderer.gameObject.name));
                                if (keyValuePair == null || keyValuePair.Value2 == String.Empty)
                                {
                                    bigname.Add(new KeyValuePair() { KeyId = 1, Value = meshFilter.sharedMesh.vertexCount.ToString(), Value2 = renderer.gameObject.name });
                                }
                                else
                                {
                                    keyValuePair.KeyId++;
                                }
                            }

                            totalVertices += meshFilter.sharedMesh.vertexCount;
                        }
                    }
                    else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
                    {
                        if (skinnedMeshRenderer.sharedMesh != null)
                        {
                            if (skinnedMeshRenderer.sharedMesh.vertexCount > vertextdebug)
                            {
                                //Log.Debug($"统计场景顶点数:  vertexCount: {skinnedMeshRenderer.sharedMesh.vertexCount}  {renderer.gameObject.name}");
                                KeyValuePair keyValuePair = bigname.FirstOrDefault(p => p.Value2.Equals(renderer.gameObject.name));
                                if (keyValuePair == null || keyValuePair.Value2 == String.Empty)
                                {
                                    bigname.Add(new KeyValuePair() { KeyId = 1, Value = skinnedMeshRenderer.sharedMesh.vertexCount.ToString(), Value2 = renderer.gameObject.name });
                                }
                                else
                                {
                                    keyValuePair.KeyId++;
                                }
                            }

                            totalVertices += skinnedMeshRenderer.sharedMesh.vertexCount;
                        }
                    }
                }

                List<string> result = new List<string>();
                var biglist = bigname.OrderByDescending(p => p.KeyId * int.Parse(p.Value));
                foreach (var VARIABLE in biglist)
                {
                    //if ((int.Parse(VARIABLE.Value)>100 && VARIABLE.KeyId >= 200) 
                    //    || (int.Parse(VARIABLE.Value)>1000 && VARIABLE.KeyId >= 30) 
                    //    ||  (int.Parse(VARIABLE.Value)>2000 && VARIABLE.KeyId >= 15) 
                    //    ||  (int.Parse(VARIABLE.Value)>5000 &&   VARIABLE.KeyId >= 5)
                    //    ||  (int.Parse(VARIABLE.Value)>10000 &&   VARIABLE.KeyId >= 2))
                    {
                        result.Add($"统计场景顶点数:  {VARIABLE.Value2}  数量:{VARIABLE.KeyId}  顶点：{VARIABLE.Value}   总顶点数：{VARIABLE.KeyId * int.Parse(VARIABLE.Value)}");
                       
                    }
                }
                alldingdianshu.Add(sceneName);
                alldingdianshu.AddRange(result);
                result.Add(""); // 空行分隔场景
            }

            // EditorUtility.DisplayDialog("顶点统计", 
            //     $"场景顶点总数: {totalVertices}", "确定");
            File.WriteAllLines(outputPath, alldingdianshu);
            AssetDatabase.Refresh();
            Log.Debug($"查找结束！ 文件保存在 {outputPath}");
        }
        
        [MenuItem("Tools/检测场景顶点数【单个】")]
        static List<string> CalculateVerticesSingle()
        {
            int totalVertices = 0;
            var renderers = FindObjectsOfType<Renderer>(true); // 包含隐藏对象

            List<KeyValuePair> bigname = new List<KeyValuePair>();

            int vertextdebug = 0;

            string outputPath = "Assets/检测场景顶点数单个场景.txt";

            foreach (var renderer in renderers)
            {
                if (renderer is MeshRenderer meshRenderer)
                {
                    var meshFilter = meshRenderer.GetComponent<MeshFilter>();
                    if (meshFilter != null && meshFilter.sharedMesh != null)
                    {
                        if (meshFilter.sharedMesh.vertexCount > vertextdebug)
                        {
                            //Log.Debug($"统计场景顶点数:  vertexCount: {meshFilter.sharedMesh.vertexCount}   {renderer.gameObject.name}");


                            KeyValuePair keyValuePair = bigname.FirstOrDefault(p => p.Value2.Equals(renderer.gameObject.name));
                            if (keyValuePair == null || keyValuePair.Value2 == String.Empty)
                            {
                                bigname.Add(new KeyValuePair() { KeyId = 1, Value = meshFilter.sharedMesh.vertexCount.ToString(), Value2 = renderer.gameObject.name });
                            }
                            else
                            {
                                keyValuePair.KeyId++;
                            }
                        }

                        totalVertices += meshFilter.sharedMesh.vertexCount;
                    }
                }
                else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
                {
                    if (skinnedMeshRenderer.sharedMesh != null)
                    {
                        if (skinnedMeshRenderer.sharedMesh.vertexCount > vertextdebug)
                        {
                            //Log.Debug($"统计场景顶点数:  vertexCount: {skinnedMeshRenderer.sharedMesh.vertexCount}  {renderer.gameObject.name}");
                            KeyValuePair keyValuePair = bigname.FirstOrDefault(p => p.Value2.Equals(renderer.gameObject.name));
                            if (keyValuePair == null || keyValuePair.Value2 == String.Empty)
                            {
                                bigname.Add(new KeyValuePair() { KeyId = 1, Value = skinnedMeshRenderer.sharedMesh.vertexCount.ToString(), Value2 = renderer.gameObject.name });
                            }
                            else
                            {
                                keyValuePair.KeyId++;
                            }
                        }

                        totalVertices += skinnedMeshRenderer.sharedMesh.vertexCount;
                    }
                }
            }

            List<string> result = new List<string>();
            var biglist = bigname.OrderByDescending(p => p.KeyId * int.Parse(p.Value));
            foreach (var VARIABLE in biglist)
            {
                //if ((int.Parse(VARIABLE.Value)>100 && VARIABLE.KeyId >= 200) 
                //    || (int.Parse(VARIABLE.Value)>1000 && VARIABLE.KeyId >= 30) 
                //    ||  (int.Parse(VARIABLE.Value)>2000 && VARIABLE.KeyId >= 15) 
                //    ||  (int.Parse(VARIABLE.Value)>5000 &&   VARIABLE.KeyId >= 5)
                //    ||  (int.Parse(VARIABLE.Value)>10000 &&   VARIABLE.KeyId >= 2))
                {
                    result.Add($"统计场景顶点数:  {VARIABLE.Value2}  数量:{VARIABLE.KeyId}  顶点：{VARIABLE.Value}   总顶点数：{VARIABLE.KeyId * int.Parse(VARIABLE.Value)}");
                    result.Add(""); // 空行分隔场景
                }
            }

            EditorUtility.DisplayDialog("顶点统计", 
                 $"场景顶点总数: {totalVertices}", "确定");
            File.WriteAllLines(outputPath, result);
            AssetDatabase.Refresh();

            Log.Debug($"查找结束！ 文件保存在 {outputPath}");
            return result;
        }

        [MenuItem("GameObject/检测对象顶点数", false, -3)]
        static void CalculateVerticesSelect()
        {
            if (Selection.gameObjects.Length == 0)
            {
                return;
            }
            int totalVertices = 0;
            var renderers = Selection.gameObjects[0].GetComponentsInChildren<Renderer>(true); // 包含隐藏对象

            foreach (var renderer in renderers)
            {
                if (renderer is MeshRenderer meshRenderer)
                {
                    var meshFilter = meshRenderer.GetComponent<MeshFilter>();
                    if (meshFilter != null && meshFilter.sharedMesh != null)
                    {
         
                        totalVertices += meshFilter.sharedMesh.vertexCount;
                    }
                }
                else if (renderer is SkinnedMeshRenderer skinnedMeshRenderer)
                {
                    if (skinnedMeshRenderer.sharedMesh != null)
                    {
                        totalVertices += skinnedMeshRenderer.sharedMesh.vertexCount;
                    }
                }
            }
            UnityEngine.Debug.Log($"顶点数:  {totalVertices}");
        }
        
        [MenuItem("Custom/获取全部Shader路径")]
        static void FindAllShaders()
        {
            string shaderPaths = "";

            string projectPath = Application.dataPath.Replace("/Assets", "");

            string[] allFiles = Directory.GetFiles(projectPath, "*.*", SearchOption.AllDirectories);

            foreach (string file in allFiles)
            {
                if (!file.EndsWith(".shader"))
                {
                    continue;
                }

                //H:/GitMengJing2022/Unity\Library\PackageCache\com.unity.render-pipelines.universal@14.0.11\Shaders\XR\XROcclusionMesh.shader

                if (!file.Contains("nity\\Library\\PackageCache"))
                {
                    if (!file.Contains(@"Assets\Res\Shader")
                        && !file.Contains(@"Unity\Packages")
                        && !file.Contains(@"Amazing Assets")
                        && !file.Contains(@"HighlightPlus")
                        && !file.Contains(@"UnityChanShader")
                        && !file.Contains(@"Stylized Grass Shader")
                        && !file.Contains(@"StylizedGrassShader")
                        && !file.Contains(@"Suntail Village")
                        && !file.Contains(@"SoftMask"))
                    {
                        string prefabpath = file;
                        string[] pathlist = file.Split('\\');
                        string destinationFile = @"Assets\\Res\\Shader\\" + pathlist[pathlist.Length - 1];
                        //bool moveret = FileHelper.MoveFile(prefabpath, destinationFile);
                        //FileHelper.MoveFile(prefabpath + ".meta", destinationFile + ".meta");

                        shaderPaths += file + "\n";

                        //Debug.Log($"移动shader：{prefabpath}   ====>   {destinationFile}");
                    }
              }
           }

            ClipBoard.Copy(shaderPaths);
        }


    }
}
