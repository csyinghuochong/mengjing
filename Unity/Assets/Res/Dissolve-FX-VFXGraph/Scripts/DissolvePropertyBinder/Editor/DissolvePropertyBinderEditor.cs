using UnityEngine;
using UnityEditor;

namespace INab.Dissolve
{
    [CustomEditor(typeof(DissolverVFX))]
    [CanEditMultipleObjects]
    public class DissolverVFXEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawDefaultInspector();

            DissolverVFX dissolverVFX = (DissolverVFX)target;
            if (GUILayout.Button("Properties: Material -> Visual Graph"))
            {
                dissolverVFX.CopyProperties();
            }


            serializedObject.ApplyModifiedProperties();
        }
    }


}