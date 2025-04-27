using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

namespace ET.Client
{
    public class SceneChecker4 : EditorWindow
    {
        
        [MenuItem("Tools/检测场景顶点数")]
        static void CalculateVertices()
        {
            int totalVertices = 0;
            var renderers = FindObjectsOfType<Renderer>(true); // 包含隐藏对象

            List<KeyValuePair> bigname = new List<KeyValuePair>();

            int vertextdebug = 100;
            
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
                                bigname.Add( new KeyValuePair(){ KeyId = 1, Value = meshFilter.sharedMesh.vertexCount.ToString(), Value2 = renderer.gameObject.name } );
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
                                bigname.Add( new KeyValuePair(){ KeyId = 1, Value = skinnedMeshRenderer.sharedMesh.vertexCount.ToString(), Value2 = renderer.gameObject.name } );
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

            var biglist  = bigname.OrderByDescending(p => p.KeyId);
            foreach (var VARIABLE in biglist)
            {
                if ((int.Parse(VARIABLE.Value)>100 && VARIABLE.KeyId >= 1000) 
                    || (int.Parse(VARIABLE.Value)>1000 && VARIABLE.KeyId >= 30) 
                    ||  (int.Parse(VARIABLE.Value)>2000 && VARIABLE.KeyId >= 15) 
                    ||  (int.Parse(VARIABLE.Value)>5000 &&   VARIABLE.KeyId >= 5)
                    ||  (int.Parse(VARIABLE.Value)>10000 &&   VARIABLE.KeyId >= 2))
                {
                    Log.Error($"统计场景顶点数>5000:  {VARIABLE.Value2}  数量:{VARIABLE.KeyId}  顶点：{VARIABLE.Value}   总顶点数：{VARIABLE.KeyId * int.Parse(VARIABLE.Value)}");
                }
            }

            EditorUtility.DisplayDialog("顶点统计", 
                $"场景顶点总数: {totalVertices}", "确定");
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
                        && !file.Contains(@"Amazing Assets")
                        && !file.Contains(@"HighlightPlus")
                        && !file.Contains(@"SoftMask"))
                    {
                        string prefabpath = file;
                        string[] pathlist = file.Split('\\');
                        string destinationFile = @"Assets\\Res\\Shader\\" + pathlist[pathlist.Length - 1];
                        bool moveret = FileHelper.MoveFile(prefabpath, destinationFile);
                        FileHelper.MoveFile(prefabpath + ".meta", destinationFile + ".meta");
                    
                        shaderPaths += file + "\n";
                    
                        Debug.Log($"移动shader：{prefabpath}   ====>   {destinationFile}");
                    }
                }
            }
        
            ClipBoard.Copy(shaderPaths);
        }

        
    }
}