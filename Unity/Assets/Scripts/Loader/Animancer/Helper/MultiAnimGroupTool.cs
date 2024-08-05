using System;
using System.IO;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace ET
{
    public class MultiAnimGroupTool : EditorWindow
    {
        private string folderPath = string.Empty;

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
            EditorGUILayout.LabelField("Folder Path", GUILayout.Width(80));
            folderPath = EditorGUILayout.TextField(folderPath);

            if (GUILayout.Button("Browse", GUILayout.Width(75)))
            {
                string selectedFolder = EditorUtility.OpenFolderPanel("Select Folder", "Assets", "");
                if (!string.IsNullOrEmpty(selectedFolder))
                {
                    if (selectedFolder.StartsWith(Application.dataPath))
                    {
                        folderPath = "Assets" + selectedFolder.Substring(Application.dataPath.Length);
                    }
                    else
                    {
                        Log.Error("Selected folder is not within the Unity project.");
                    }
                }
            }

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Generate"))
            {
                GenerateOrUpdateAnimationStateData();
            }
        }

        private void GenerateOrUpdateAnimationStateData()
        {
            if (string.IsNullOrEmpty(folderPath) || !folderPath.StartsWith("Assets"))
            {
                Log.Error("请输入正确的文件路径");
                return;
            }

            string[] prefabPaths = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);

            foreach (string prefabPath in prefabPaths)
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                Animator animator = prefab.GetComponent<Animator>();

                if (animator != null)
                {
                    AnimatorController animatorController = animator.runtimeAnimatorController as AnimatorController;
                    if (animatorController != null)
                    {
                        string assetName = animatorController.name;
                        string assetPath = $"Assets/Res/AnimGroup/{assetName}.asset";

                        AnimGroup stateData = AssetDatabase.LoadAssetAtPath<AnimGroup>(assetPath);

                        if (stateData == null)
                        {
                            stateData = ScriptableObject.CreateInstance<AnimGroup>();
                            AssetDatabase.CreateAsset(stateData, assetPath);
                        }

                        var states = animatorController.layers[0].stateMachine.states;
                        stateData.Animations = new MotionTransition[states.Length];

                        for (int i = 0; i < states.Length; i++)
                        {
                            var state = states[i].state;
                            stateData.Animations[i] = new MotionTransition()
                            {
                                StateName = state.name,
                                Clip = state.motion as AnimationClip
                            };
                        }

                        EditorUtility.SetDirty(stateData);
                        AssetDatabase.SaveAssets();

                        Log.Debug("AnimGroup generated at " + assetPath);
                    }
                }
            }
        }
    }
}