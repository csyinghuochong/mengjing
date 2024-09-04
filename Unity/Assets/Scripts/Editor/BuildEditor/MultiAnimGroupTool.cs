using System;
using System.IO;
using Animancer;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace ET
{
    public class MultiAnimGroupTool : EditorWindow
    {
        private string prefabFolderPath = "Assets/Bundles/Unit";
        private string assetBaseFolderPath = "Assets/Res/AnimGroup";

        [MenuItem("Tools/Animancer/Generate Multi AnimGroup")]
        private static void ShowWindow()
        {
            var window = GetWindow<MultiAnimGroupTool>("Generate Multi AnimGroup");
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Prefab Folder Path", GUILayout.Width(150));
            prefabFolderPath = EditorGUILayout.TextField(prefabFolderPath, GUILayout.Width(300));

            if (GUILayout.Button("Browse", GUILayout.Width(75)))
            {
                string selectedFolder = EditorUtility.OpenFolderPanel("Select Folder", prefabFolderPath, "");
                if (!string.IsNullOrEmpty(selectedFolder))
                {
                    if (selectedFolder.StartsWith(Application.dataPath))
                    {
                        prefabFolderPath = "Assets" + selectedFolder.Substring(Application.dataPath.Length);
                    }
                    else
                    {
                        Debug.LogError("Selected folder is not within the Unity project.");
                    }
                }
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Asset Base Folder Path", GUILayout.Width(150));
            assetBaseFolderPath = EditorGUILayout.TextField(assetBaseFolderPath, GUILayout.Width(300));

            if (GUILayout.Button("Browse", GUILayout.Width(75)))
            {
                string selectedFolder = EditorUtility.OpenFolderPanel("Select Folder", assetBaseFolderPath, "");
                if (!string.IsNullOrEmpty(selectedFolder))
                {
                    if (selectedFolder.StartsWith(Application.dataPath))
                    {
                        assetBaseFolderPath = "Assets" + selectedFolder.Substring(Application.dataPath.Length);
                    }
                    else
                    {
                        Debug.LogError("Selected folder is not within the Unity project.");
                    }
                }
            }

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Generate Animation State Data"))
            {
                GenerateOrUpdateAnimationStateData();
            }
        }

        private void GenerateOrUpdateAnimationStateData()
        {
            if (string.IsNullOrEmpty(prefabFolderPath) || !prefabFolderPath.StartsWith("Assets"))
            {
                Log.Error("请输入正确的文件路径");
                return;
            }

            if (string.IsNullOrEmpty(assetBaseFolderPath) || !assetBaseFolderPath.StartsWith("Assets"))
            {
                Log.Error("请输入正确的文件路径");
                return;
            }

            string[] prefabPaths = Directory.GetFiles(prefabFolderPath, "*.prefab", SearchOption.AllDirectories);

            foreach (string prefabPath in prefabPaths)
            {
                if (prefabPath.Contains("Unit\\Parts\\"))
                {
                    continue;
                }

                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                Animator animator = prefab.GetComponent<Animator>();

                if (animator != null)
                {
                    AnimatorController animatorController = animator.runtimeAnimatorController as AnimatorController;

                    if (animatorController != null)
                    {
                        string relativePath = Path.GetDirectoryName(prefabPath).Substring(prefabFolderPath.Length);
                        string assetFolderPath = (assetBaseFolderPath + relativePath).Replace('\\', '/');

                        if (!AssetDatabase.IsValidFolder(assetFolderPath))
                        {
                            string[] folders = assetFolderPath.Split('/');
                            string currentPath = "";
                            for (int i = 0; i < folders.Length; i++)
                            {
                                string folder = folders[i];
                                if (string.IsNullOrEmpty(folder)) continue;

                                if (i == 0)
                                {
                                    currentPath = folder;
                                }
                                else
                                {
                                    string parentPath = currentPath;
                                    currentPath = $"{parentPath}/{folder}";
                                    if (!AssetDatabase.IsValidFolder(currentPath))
                                    {
                                        AssetDatabase.CreateFolder(parentPath, folder);
                                    }
                                }
                            }
                        }

                        string assetName = animatorController.name;
                        string assetPath = Path.Combine(assetFolderPath, $"{assetName}.asset");

                        AnimGroup animGroup = AssetDatabase.LoadAssetAtPath<AnimGroup>(assetPath);

                        if (animGroup == null)
                        {
                            animGroup = ScriptableObject.CreateInstance<AnimGroup>();
                            AssetDatabase.CreateAsset(animGroup, assetPath);
                        }

                        var states = animatorController.layers[0].stateMachine.states;
                        animGroup.AnimInfos = new AnimInfo[states.Length];

                        for (int i = 0; i < states.Length; i++)
                        {
                            var state = states[i].state;
                            animGroup.AnimInfos[i] = new AnimInfo()
                            {
                                StateName = state.name,
                                AnimationClip = state.motion as AnimationClip,
                                NextStateName = GetNextStateName(state)
                            };
                        }

                        EditorUtility.SetDirty(animGroup);
                        AssetDatabase.SaveAssets();

                        Log.Debug(prefabPath + " AnimGroup generated at " + assetPath);

                        // 添加组件和引用
                        AnimancerComponent animancerComponent = prefab.GetComponent<AnimancerComponent>();
                        if (animancerComponent == null)
                        {
                            prefab.AddComponent<AnimancerComponent>();
                        }

                        AnimData animData = prefab.GetComponent<AnimData>();
                        if (animData == null)
                        {
                            animData = prefab.AddComponent<AnimData>();
                        }

                        animData.AnimGroup = animGroup;
                        EditorUtility.SetDirty(prefab);
                        PrefabUtility.SavePrefabAsset(prefab);
                    }
                }
            }
        }

        private string GetNextStateName(AnimatorState state)
        {
            foreach (var transition in state.transitions)
            {
                if (transition.conditions.Length == 0 && transition.hasExitTime)
                {
                    return transition.destinationState.name;
                }
            }

            return null;
        }
    }
}