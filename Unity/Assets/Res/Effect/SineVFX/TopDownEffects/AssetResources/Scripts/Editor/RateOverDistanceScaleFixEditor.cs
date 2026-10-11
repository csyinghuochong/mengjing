using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RateOverDistanceScaleFix))]
public class RateOverDistanceScaleFixEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RateOverDistanceScaleFix rateScript = (RateOverDistanceScaleFix)target;

        if (GUILayout.Button("Auto Adjust Rate"))
        {
            rateScript.AutoAdjustParticleSystemRateOverDistanceInEditor();
        }
    }
}
