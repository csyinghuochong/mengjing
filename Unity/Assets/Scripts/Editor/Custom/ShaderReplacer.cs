using UnityEngine;
using UnityEditor;

namespace ET.Client
{
    public class ShaderReplacer : EditorWindow
    {
        private Shader oldShader;
        private Shader newShader;

        [MenuItem("Tools/Shader替换")]
        public static void ShowWindow()
        {
            GetWindow<ShaderReplacer>("Shader替换");
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();

            oldShader = EditorGUILayout.ObjectField(new GUIContent("Old Shader", "Select the shader you want to replace"), oldShader, typeof(Shader), false) as Shader;

            newShader = EditorGUILayout.ObjectField(new GUIContent("New Shader", "Select the shader to use as replacement"), newShader, typeof(Shader), false) as Shader;

            EditorGUILayout.Space();

            if (GUILayout.Button("替换"))
            {
                if (oldShader == null || newShader == null)
                {
                    EditorUtility.DisplayDialog("Error", "请选择Shader", "OK");
                }
                else
                {
                    ReplaceShadersInMaterials();
                }
            }
        }

        private void ReplaceShadersInMaterials()
        {
            // 查找 Assets 目录下所有 Material 资源
            string[] guids = AssetDatabase.FindAssets("t:Material", new[] { "Assets" });
            int replacedCount = 0;

            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

                if (mat != null && mat.shader == oldShader)
                {
                    Undo.RecordObject(mat, "Replace Shader");
                    mat.shader = newShader;
                    EditorUtility.SetDirty(mat);
                    replacedCount++;
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            UnityEngine.Debug.Log("Shader替换完成");
        }
    }
}