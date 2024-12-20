using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.IO;

namespace ET.Client
{
    public class SceneChecker3 : EditorWindow
    {
        [MenuItem("Tools/检测场景 缩放为负数的修改为对应的正值")]
        public static void CheckScenesForNegativeScales()
        {
            string scenesDirectory = "Assets/Bundles/Scenes"; // 场景目录
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

                // 打开场景
                EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

                // 检查并修复负缩放
                FixNegativeScales();

                // 保存场景更改
                EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
            }

            Log.Debug("所有场景检查完成！");
        }

        private static void FixNegativeScales()
        {
            GameObject[] allGameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject go in allGameObjects)
            {
                // 检查并修正物体的缩放
                FixScale(go.transform);
            }
        }

        private static void FixScale(Transform transform)
        {
            Vector3 localScale = transform.localScale;
            bool change = false;

            // 如果任何一个轴的缩放是负数，修改为正数
            if (localScale.x < 0)
            {
                change = true;
                localScale.x = Mathf.Abs(localScale.x);
            }

            if (localScale.y < 0)
            {
                change = true;
                localScale.y = Mathf.Abs(localScale.y);
            }

            if (localScale.z < 0)
            {
                change = true;
                localScale.z = Mathf.Abs(localScale.z);
            }

            if (change)
            {
                // 应用修正后的缩放
                transform.localScale = localScale;
            }
        }
    }
}