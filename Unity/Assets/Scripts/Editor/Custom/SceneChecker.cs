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