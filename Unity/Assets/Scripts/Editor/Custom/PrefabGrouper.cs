using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ET.Client
{
    public class PrefabGrouperWindow : EditorWindow
    {
        private const string ScenesRoot = "Assets/Bundles/Scenes";
        private bool processAllScenes = true;
        private string singleScenePath;
        private List<string> allScenePaths;

        [MenuItem("Tools/场景预制体分组")]
        public static void ShowWindow() => GetWindow<PrefabGrouperWindow>("Prefab Grouper");

        private void OnEnable()
        {
            allScenePaths = AssetDatabase
                    .FindAssets("t:Scene", new[] { ScenesRoot })
                    .Select(AssetDatabase.GUIDToAssetPath)
                    .ToList();
        }

        private void OnGUI()
        {
            GUILayout.Label("场景预制体分组", EditorStyles.boldLabel);
            processAllScenes = EditorGUILayout.ToggleLeft("处理所有场景 (" + ScenesRoot + ")", processAllScenes);

            if (!processAllScenes)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("选择单个场景:");
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.TextField(singleScenePath);
                if (GUILayout.Button("浏览", GUILayout.Width(60)))
                {
                    string path = EditorUtility.OpenFilePanel("选择场景", ScenesRoot, "unity");
                    if (!string.IsNullOrEmpty(path) && path.StartsWith(Application.dataPath))
                    {
                        singleScenePath = "Assets" + path.Substring(Application.dataPath.Length);
                    }
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.Space(20);
            if (GUILayout.Button("开始处理", GUILayout.Height(30)))
            {
                if (processAllScenes)
                {
                    ProcessScenes(allScenePaths);
                }
                else if (!string.IsNullOrEmpty(singleScenePath))
                {
                    ProcessScenes(new List<string> { singleScenePath });
                }
                else
                {
                    EditorUtility.DisplayDialog("错误", "请先选择场景文件", "确定");
                }
            }
        }

        private void ProcessScenes(List<string> scenePaths)
        {
            int count = scenePaths.Count;

            for (int i = 0; i < count; i++)
            {
                var scenePath = scenePaths[i];
                if (EditorUtility.DisplayCancelableProgressBar("分组预制体",
                        $"处理场景 ({i + 1}/{count}): {Path.GetFileName(scenePath)}",
                        (float)i / count))
                {
                    break;
                }

                var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
                GroupPrefabsInScene(scene);
                EditorSceneManager.SaveScene(scene);
            }

            EditorUtility.ClearProgressBar();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("完成", $"共处理 {count} 个场景。", "OK");
        }

        private void GroupPrefabsInScene(UnityEngine.SceneManagement.Scene scene)
        {
            // 1. 找/建 AdditiveHide
            GameObject additiveHide = GameObject.Find("AdditiveHide") ?? new GameObject("AdditiveHide");
            SceneManager.MoveGameObjectToScene(additiveHide, scene);

            // 2. 找/建 pool
            Transform poolT = additiveHide.transform.Find("pool");
            GameObject pool = poolT != null ? poolT.gameObject : new GameObject("pool");
            if (pool.transform.parent == null)
                pool.transform.SetParent(additiveHide.transform, false);

            // 3. 收集所有预制体实例（包括 AdditiveHide 下的内容）
            Dictionary<string, List<GameObject>> prefabGroups = new();

            foreach (var rootGO in scene.GetRootGameObjects())
            {
                CollectPrefabInstances(rootGO.transform, prefabGroups);
            }

            // 4. 为每种预制体创建组并移动
            foreach (var kvp in prefabGroups)
            {
                string assetPath = kvp.Key;
                var instances = kvp.Value;
                if (instances.Count == 0) continue;

                string groupName = Path.GetFileNameWithoutExtension(assetPath);
                Transform groupT = pool.transform.Find(groupName);
                GameObject groupGO;

                if (groupT != null)
                {
                    groupGO = groupT.gameObject;
                }
                else
                {
                    groupGO = new GameObject(groupName);
                    SceneManager.MoveGameObjectToScene(groupGO, scene);
                    groupGO.transform.SetParent(pool.transform, false);
                }

                foreach (var inst in instances)
                {
                    // 已经在目标组下的就不要动了
                    if (inst.transform.parent != groupGO.transform)
                    {
                        inst.transform.SetParent(groupGO.transform, true);
                        Debug.Log($"移动实例: {inst.name} → {groupName}");
                    }
                }
            }
        }

        private void CollectPrefabInstances(Transform current, Dictionary<string, List<GameObject>> groups)
        {
            if (PrefabUtility.IsPartOfPrefabInstance(current.gameObject))
            {
                GameObject root = PrefabUtility.GetNearestPrefabInstanceRoot(current.gameObject);

                if (root.transform == current)
                {
                    string path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(root);
                    if (!string.IsNullOrEmpty(path))
                    {
                        if (!groups.TryGetValue(path, out var list))
                            groups[path] = list = new List<GameObject>();

                        list.Add(root);
                        return; // 不递归进入这个 prefab 内部
                    }
                }
            }

            foreach (Transform child in current)
            {
                CollectPrefabInstances(child, groups);
            }
        }
    }
}