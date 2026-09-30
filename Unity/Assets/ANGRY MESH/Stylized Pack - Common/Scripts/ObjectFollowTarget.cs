// Follows the position of the camera assigned to Follow Target while ignoring its rotation. This can be useful when applied to particles simulated in local space, as it prevents them from inheriting the camera's rotation.

using UnityEngine;
using UnityEditor;

namespace ANGRYMESH.StylizedPack
{
    public class ObjectFollowTarget : MonoBehaviour
    {
        public Transform FollowTarget;

        void Update()
        {
            if (FollowTarget != null)
            {
                transform.position = FollowTarget.position;
            }
        }

        public void GetTargetPosition()
        {
            if (FollowTarget != null)
            {
                transform.position = FollowTarget.position;
            }
            else
            {
                Debug.LogWarning("FollowTarget is not set!");
            }
        }
    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(ObjectFollowTarget))]
    public class ObjectFollowTargetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector(); // Draws the default Inspector fields

            EditorGUILayout.HelpBox("Follows the position of the camera assigned to Follow Target while ignoring its rotation. This can be useful when applied to particles simulated in local space, as it prevents them from inheriting the camera's rotation.", MessageType.Info);

            ObjectFollowTarget script = (ObjectFollowTarget)target;
            if (GUILayout.Button("Get Target Position"))
            {
                script.GetTargetPosition(); // Calls the method when the button is pressed
            }
        }
    }
    #endif
}