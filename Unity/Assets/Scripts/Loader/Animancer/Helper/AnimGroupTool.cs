using System;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace ET
{
    public class AnimGroupTool : EditorWindow
    {
        private AnimatorController animatorController;
        private string assetName = "New AnimGroup";

        [MenuItem("Tools/Generate or Update AnimGroup")]
        private static void ShowWindow()
        {
            var window = GetWindow<AnimGroupTool>("Generate AnimGroup");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Generate AnimGroup", EditorStyles.boldLabel);

            EditorGUI.BeginChangeCheck();
            animatorController =
                    (AnimatorController)EditorGUILayout.ObjectField("Animator Controller", animatorController, typeof(AnimatorController), false);
            if (EditorGUI.EndChangeCheck() && animatorController != null)
            {
                assetName = animatorController.name;
            }

            assetName = EditorGUILayout.TextField("生成Asset的名字", assetName);

            if (GUILayout.Button("Generate or Update"))
            {
                GenerateOrUpdateAnimationStateData();
            }
        }

        private void GenerateOrUpdateAnimationStateData()
        {
            if (this.animatorController == null)
            {
                Log.Error("请选择AnimatorController");
                return;
            }

            if (string.IsNullOrEmpty(this.assetName))
            {
                Log.Error("请输入生成asset的名字");
                return;
            }

            string path = $"Assets/Res/AnimGroup/{this.assetName}.asset";
            AnimGroup animGroup = AssetDatabase.LoadAssetAtPath<AnimGroup>(path);

            if (animGroup == null)
            {
                // 如果不存在，则创建一个新的 ScriptableObject
                animGroup = ScriptableObject.CreateInstance<AnimGroup>();
                AssetDatabase.CreateAsset(animGroup, path);
            }

            // 更新并填充 ScriptableObject
            var states = animatorController.layers[0].stateMachine.states;
            animGroup.Animations = new MotionTransition[states.Length];

            for (int i = 0; i < states.Length; i++)
            {
                var state = states[i].state;
                animGroup.Animations[i] = new MotionTransition()
                {
                    StateName = state.name,
                    Clip = state.motion as AnimationClip
                };
            }

            // 保存 ScriptableObject
            EditorUtility.SetDirty(animGroup);
            AssetDatabase.SaveAssets();

            Log.Debug("AnimGroup generated at " + path);
        }
    }
}