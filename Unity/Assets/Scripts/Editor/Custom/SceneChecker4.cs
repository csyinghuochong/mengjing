using UnityEditor;
using UnityEngine;
using System.IO;

namespace ET.Client
{
    public class SceneChecker4 : EditorWindow
    {
        
        [MenuItem("Custom/统计场景顶点数")]
        static void CalculateVertices()
        {
            int totalVertices = 0;
            var renderers = FindObjectsOfType<Renderer>(true); // 包含隐藏对象

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