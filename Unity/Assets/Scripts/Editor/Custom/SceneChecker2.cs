using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.IO;

namespace ET.Client
{
    public class SceneChecker2 : EditorWindow
    {
        [MenuItem("Tools/检测场景 1.移除丢失预制件的节点 2.移除脚本引用丢失的脚本组")]
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

                // 1. 移除丢失预制件的节点
                RemoveMissingPrefabs();

                // 2. 移除脚本引用丢失的脚本组
                RemoveMissingScriptReferences();

                // 保存场景更改
                EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
            }

            Log.Debug("所有场景检查完成！");
        }

        private static void RemoveMissingPrefabs()
        {
            GameObject[] allGameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject go in allGameObjects)
            {
                if (PrefabUtility.GetPrefabAssetType(go) == PrefabAssetType.MissingAsset)
                {
                    string objectPath = GetFullPath(go);
                    Log.Debug($"检测到丢失预制件，移除: {objectPath}");
                    UnityEngine.Object.DestroyImmediate(go);
                }
            }
        }

        private static void RemoveMissingScriptReferences()
        {
            GameObject[] allGameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject go in allGameObjects)
            {
                Component[] components = go.GetComponents<Component>();
                List<Component> componentsToRemove = new List<Component>();

                foreach (Component component in components)
                {
                    if (component == null)
                    {
                        string objectPath = GetFullPath(go);
                        Log.Debug($"检测到丢失的脚本引用，移除: {objectPath}");
                        componentsToRemove.Add(component);
                    }
                }

                foreach (var componentToRemove in componentsToRemove)
                {
                    DestroyImmediate(componentToRemove);
                }
            }
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