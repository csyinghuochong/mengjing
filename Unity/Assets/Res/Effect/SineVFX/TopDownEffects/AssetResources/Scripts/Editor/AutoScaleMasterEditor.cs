using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AutoScaleMaster))]
public class AutoScaleMasterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AutoScaleMaster autoScaleMasterScript = (AutoScaleMaster)target;

        if (GUILayout.Button("Auto Adjust Scaling and Rate"))
        {
            autoScaleMasterScript.AutoScaleAndRateFixInEditor();
        }
    }
}
