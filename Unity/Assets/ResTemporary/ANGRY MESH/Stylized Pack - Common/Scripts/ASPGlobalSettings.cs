// ASP Global Settings - ANGRY MESH - contact@angrymesh.com

using System.Collections.Generic;
using UnityEngine;

namespace ANGRYMESH.StylizedPack
{
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    [RequireComponent(typeof(MeshRenderer))]
    public class ASPGlobalSettings : MonoBehaviour 
    {
        [Header("Global Tint Settings")]
        public bool EnableGlobalTintColor = true;
        float GlobalTintNoiseToggle = 0.0f;

        [Range(0.001f, 10.0f)] public float GlobalTintNoiseUVScale = 1.0f;
        [Range(0.0f, 1.0f)] public float GlobalTintNoiseIntensity = 1.0f;
        [Range(0.001f, 10.0f)] public float GlobalTintNoiseContrast = 1.0f;
        public Texture2D GlobalTintNoiseTexture = null;

        [Header("Global Tree Settings")]
        [Range(0.0f, 2.0f)] public float GlobalTreeSSSIntensity = 1.0f;
        [Range(0.0f, 2.0f)] public float GlobalTreeSSSAoInfluence = 1.0f;
        [Range(0.0f, 10000.0f)] public float GlobalTreeSSSDistance = 5000.0f;
        [Range(0.0f, 2.0f)] public float GlobalTreeAO = 1.0f;

        void Update () {

            // Update GlobalTintNoiseToggle based on EnableGlobalTintColor
            GlobalTintNoiseToggle = EnableGlobalTintColor ? 1.0f : 0.0f;

            // Send information to shaders
            Shader.SetGlobalFloat ("ASP_GlobalTintNoiseToggle", GlobalTintNoiseToggle);
            Shader.SetGlobalFloat ("ASP_GlobalTintNoiseUVScale", GlobalTintNoiseUVScale);
            Shader.SetGlobalFloat ("ASP_GlobalTintNoiseIntensity", GlobalTintNoiseIntensity);
            Shader.SetGlobalFloat ("ASP_GlobalTintNoiseContrast", GlobalTintNoiseContrast);
            Shader.SetGlobalTexture ("ASP_GlobalTintNoiseTexture", GlobalTintNoiseTexture);

            Shader.SetGlobalFloat("ASP_GlobalTreeSSSIntensity", GlobalTreeSSSIntensity);
            Shader.SetGlobalFloat("ASP_GlobalTreeSSSAOInfluence", GlobalTreeSSSAoInfluence);
            Shader.SetGlobalFloat("ASP_GlobalTreeSSSDistance", GlobalTreeSSSDistance);
            Shader.SetGlobalFloat("ASP_GlobalTreeAO", GlobalTreeAO);
        }
    }
}
