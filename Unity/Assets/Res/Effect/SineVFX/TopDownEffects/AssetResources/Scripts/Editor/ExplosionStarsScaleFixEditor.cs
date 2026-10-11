using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ExplosionStarsScaleFix))]
public class ExplosionStarsScaleFixEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ExplosionStarsScaleFix scaleScript = (ExplosionStarsScaleFix)target;

        if (GUILayout.Button("Auto Adjust Scaling"))
        {
            scaleScript.AutoAdjustParticleSystemScalingInEditor();
        }
    }
}
