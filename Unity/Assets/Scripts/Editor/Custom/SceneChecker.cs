using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.IO;

namespace ET.Client
{
    public class SceneChecker : EditorWindow
    {
        
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="srcDir">起始文件夹</param>
        /// <param name="tgtDir">目标文件夹</param>
        public static void CopyDirectory(string srcDir, string tgtDir)
        {
            File.Copy(srcDir, tgtDir , true);
        }
        
        // [MenuItem("Asset / ), false, 1]
        [MenuItem("Assets/Custom/Copy  Dependencies", false, 1)]//路径
        public static void CopyDependencies()
        {
            string fontPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            UnityEngine.Debug.Log("fontPath: " + fontPath);
            UnityEngine.Debug.Log("CopyDependencies: Begin");
            string dataPath = Application.dataPath;
            string[] dependPathList = AssetDatabase.GetDependencies(new string[] { fontPath });
            foreach (string path in dependPathList)
            {
                string[] fileInfo = path.Split('/');
                string formPath = path.Replace("Assets", Application.dataPath);
                string toPath = "F:/TempFile/" + fileInfo[fileInfo.Length - 1];
                CopyDirectory(formPath, toPath);

                string formPathMeta = path.Replace("Assets", Application.dataPath) + ".meta"; 
                string toPathMata = "F:/TempFile/" + fileInfo[fileInfo.Length - 1] + ".meta";

                CopyDirectory(formPathMeta, toPathMata);
            }

            //dataPath: H:/GitWeiJing/Unity/Assets
            //Assets/Res/Models/RoleModelSet/RoleFaShi/Animtor/Girl_Act_1.fbx
            UnityEngine.Debug.Log("dataPath: " + dataPath);
            UnityEngine.Debug.Log("CopyDependencies: End");
        }
        
        
        [MenuItem("Tools/检测场景 包含AdditiveHide节点")]
        public static void CheckScenesForAdditiveHideAndListAllNodes()
        {
            string scenesDirectory = "Assets/Bundles/Scenes";
            string[] sceneFiles = Directory.GetFiles(scenesDirectory, "*.unity", SearchOption.AllDirectories);

            Log.Debug("场景检查开始！");

            foreach (string scenePath in sceneFiles)
            {
                SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
                if (sceneAsset == null)
                {
                    Log.Warning($"无法加载场景: {scenePath}");
                    continue;
                }

                EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

                GameObject additiveHideObject = GameObject.Find("AdditiveHide");
                if (additiveHideObject != null)
                {
                    string objectPath = GetFullPath(additiveHideObject);
                    Log.Debug($"场景 '{sceneAsset.name}' 包含 'AdditiveHide' 物体，路径为: {objectPath}");
                }
                else
                {
                    Log.Debug($"场景 '{sceneAsset.name}' 中不存在 'AdditiveHide' 物体.");
                }
            }

            Log.Debug("所有场景检查完成！");
        }

        private static string GetFullPath(GameObject obj)
        {
            string path = obj.name;
            Transform current = obj.transform;

            while (current.parent != null)
            {
                current = current.parent;
                path = current.name + "/" + path;
            }

            return path;
        }
    }
}