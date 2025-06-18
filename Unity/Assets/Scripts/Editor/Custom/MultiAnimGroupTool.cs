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
                Debug.LogError("请输入正确的文件路径");
                return;
            }

            if (string.IsNullOrEmpty(assetBaseFolderPath) || !assetBaseFolderPath.StartsWith("Assets"))
            {
                Debug.LogError("请输入正确的文件路径");
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
                
                // 创建临时实例来修改
                GameObject tempInstance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                
                try
                {
                    ProcessPrefabInstance(prefabPath, tempInstance);
                    
                    // 应用修改到原始预制件
                    PrefabUtility.ApplyPrefabInstance(tempInstance, InteractionMode.AutomatedAction);
                }
                catch (Exception e)
                {
                    Debug.LogError($"处理预制件 {prefabPath} 时出错: {e.Message}\n{e.StackTrace}");
                }
                finally
                {
                    // 销毁临时实例
                    DestroyImmediate(tempInstance);
                }
            }
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private void ProcessPrefabInstance(string prefabPath, GameObject instance)
        {
            Animator[] animators = instance.GetComponentsInChildren<Animator>(true);

            foreach (Animator animator in animators)
            {
                if (!animator.enabled)
                {
                    // 使用 Undo 安全删除组件
                    AnimancerComponent animancerComponent = animator.gameObject.GetComponent<AnimancerComponent>();
                    if (animancerComponent != null)
                    {
                        Undo.DestroyObjectImmediate(animancerComponent);
                    }

                    AnimData animData = animator.gameObject.GetComponent<AnimData>();
                    if (animData != null)
                    {
                        Undo.DestroyObjectImmediate(animData);
                    }
                    continue;
                }

                AnimatorController animatorController = animator.runtimeAnimatorController as AnimatorController;

                if (animatorController != null)
                {
                    string relativePath = Path.GetDirectoryName(prefabPath).Substring(prefabFolderPath.Length);
                    string assetFolderPath = (assetBaseFolderPath + relativePath).Replace('\\', '/');

                    // 确保文件夹路径存在
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
                    string assetPath = Path.Combine(assetFolderPath, $"{assetName}.asset").Replace('\\', '/');

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
                            Speed = state.speed,
                            NextStateName = GetNextStateName(state)
                        };
                    }

                    EditorUtility.SetDirty(animGroup);

                    Debug.Log(prefabPath + " AnimGroup generated at " + assetPath);

                    // 使用 Undo 安全添加/获取组件
                    AnimancerComponent animancerComponent = animator.gameObject.GetComponent<AnimancerComponent>();
                    if (animancerComponent == null)
                    {
                        animancerComponent = Undo.AddComponent<AnimancerComponent>(animator.gameObject);
                    }

                    AnimData animData = animator.gameObject.GetComponent<AnimData>();
                    if (animData == null)
                    {
                        animData = Undo.AddComponent<AnimData>(animator.gameObject);
                    }

                    // 记录对象修改
                    Undo.RecordObject(animData, "Assign AnimGroup");
                    animData.AnimGroup = animGroup;
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