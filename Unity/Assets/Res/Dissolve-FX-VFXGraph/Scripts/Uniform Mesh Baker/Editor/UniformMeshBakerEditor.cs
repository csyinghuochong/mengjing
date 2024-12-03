using UnityEngine;
using UnityEngine.VFX;
using UnityEditor;

namespace INab.Dissolve
{
    [CustomEditor(typeof(UniformMeshBaker))]
    [CanEditMultipleObjects]
    public class UniformMeshBakerEditor : Editor
    {
        SerializedProperty _sampleCount;
        SerializedProperty SampleCountMultiplier;
        SerializedProperty MeshPropertyName;
        SerializedProperty GraphicsBufferName;
        SerializedProperty initializeOnEnable;
        
        void OnEnable()
        {
            _sampleCount = serializedObject.FindProperty("_sampleCount");
            SampleCountMultiplier = serializedObject.FindProperty("SampleCountMultiplier");
            MeshPropertyName = serializedObject.FindProperty("MeshPropertyName");
            GraphicsBufferName = serializedObject.FindProperty("GraphicsBufferName");
            initializeOnEnable = serializedObject.FindProperty("initializeOnEnable");
        }

        override public void OnInspectorGUI()
        {
            using (var verticalLayout = new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField("Sample Count");

                GUI.enabled = false;
                EditorGUILayout.IntField((int)(_sampleCount.intValue * SampleCountMultiplier.floatValue));
                GUI.enabled = true;

            }

            EditorGUILayout.PropertyField(SampleCountMultiplier);
            EditorGUILayout.PropertyField(MeshPropertyName);
            EditorGUILayout.PropertyField(GraphicsBufferName);
            EditorGUILayout.PropertyField(initializeOnEnable);


            //DrawDefaultInspector();
            if (GUILayout.Button("Bake"))
            {
                var uniformBaker = target as UniformMeshBaker;
                uniformBaker.Bake();
            }

            UniformMeshBaker uniformMeshBaker = (UniformMeshBaker)target;

            if (uniformMeshBaker.m_BakedSampling == null)
            {
                EditorGUILayout.LabelField("Mesh with uniform distribution has not been baked. Please hit the bake button.", EditorStyles.helpBox);
            }


            if (uniformMeshBaker.m_Buffer == null)
            {
                if (GUILayout.Button("Set Graphics Buffer"))
                {
                    var uniformBaker = target as UniformMeshBaker;
                    uniformBaker.SetGraphicsBuffer();
                }
                EditorGUILayout.LabelField("VFX graph UniformMeshBuffer needs to be passed to VFX Graph for editor preview. Please click Set Graphics Buffer button or start the game.", EditorStyles.helpBox);
            }
            else
            {
                GUI.enabled = false;
                GUILayout.Button("Set Graphics Buffer");
                GUI.enabled = true;
            }

            serializedObject.ApplyModifiedProperties();

        }
    }
}