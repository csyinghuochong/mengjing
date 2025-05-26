using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

namespace ET.Client
{
    public class FindTextureReferences : EditorWindow
    {
        private Texture targetTexture;

        [MenuItem("Tools/查找贴图引用")]
        public static void ShowWindow()
        {
            GetWindow<FindTextureReferences>("查找贴图引用");
        }

        private void OnGUI()
        {
            GUILayout.Label("选择贴图", EditorStyles.boldLabel);
            targetTexture = (Texture)EditorGUILayout.ObjectField("目标贴图", targetTexture, typeof(Texture), false);

            if (GUILayout.Button("查找"))
            {
                if (targetTexture == null)
                {
                    EditorUtility.DisplayDialog("错误", "请先选择贴图", "OK");
                    return;
                }

                FindInScenes("Assets/Bundles/Scenes");
            }
        }

        private void FindInScenes(string sceneFolderPath)
        {
            string[] scenePaths = Directory.GetFiles(sceneFolderPath, "*.unity", SearchOption.AllDirectories);

            int totalScenes = scenePaths.Length;
            int currentScene = 0;
            int totalFound = 0;

            foreach (var scenePath in scenePaths)
            {
                currentScene++;
                string sceneName = Path.GetFileName(scenePath);
                int sceneFoundCount = 0;

                EditorUtility.DisplayProgressBar("查找贴图引用", $"正在检查场景：{sceneName}", (float)currentScene / totalScenes);

                var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

                Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();

                foreach (var renderer in renderers)
                {
                    if (renderer == null) continue;

                    Material[] materials = renderer.sharedMaterials;
                    foreach (var material in materials)
                    {
                        if (material == null) continue;

                        foreach (string textureName in material.GetTexturePropertyNames())
                        {
                            Texture tex = material.GetTexture(textureName);
                            if (tex == null) continue;

                            if (tex == targetTexture)
                            {
                                totalFound++;
                                sceneFoundCount++;
                                string fullPath = GetGameObjectPath(renderer.gameObject);

                                Debug.Log(
                                    $"<color=green><b>（{totalFound}）</b></color> " +
                                    $"场景: <color=yellow>{sceneName}</color> | " +
                                    $"物体路径: <color=cyan>{fullPath}</color> | " +
                                    $"材质: <color=magenta>{material.name}</color> | " +
                                    $"纹理属性: <color=orange>{textureName}</color>",
                                    renderer.gameObject
                                );
                            }
                        }
                    }
                }

                if (sceneFoundCount != 0)
                {
                    Debug.Log($"<color=lime>场景 <b>{sceneName}</b> 中找到 <b>{sceneFoundCount}</b> 处引用。</color>");
                }
            }

            EditorUtility.ClearProgressBar();
        }

        private string GetGameObjectPath(GameObject obj)
        {
            string path = obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                path = obj.name + "/" + path;
            }
            return path;
        }
    }
}
