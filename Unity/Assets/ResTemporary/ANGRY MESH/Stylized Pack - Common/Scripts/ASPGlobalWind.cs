 // ASP Global Wind - ANGRY MESH - contact@angrymesh.com

using System.Collections.Generic;
using UnityEngine;

namespace ANGRYMESH.StylizedPack
{
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    [RequireComponent(typeof(MeshRenderer))]
    public class ASPGlobalWind : MonoBehaviour
    {
        public bool EnableGlobalWind = true;
        float WindToggle = 0.0f;

        [Header("Wind Tree Settings")]
        [Range(0.0f, 10.0f)] public float WindTreeAmplitude = 1.0f;
        [Range(0.0f, 10.0f)] public float WindTreeSpeed = 1.0f;
        [Range(0.0f, 10.0f)] public float WindTreeFlexibility = 1.0f;

        [Range(0.0f, 10.0f)] public float WindTreeLeafAmplitude = 1.0f;
        [Range(0.0f, 10.0f)] public float WindTreeLeafSpeed = 1.0f;
        [Range(0.0f, 10.0f)] public float WindTreeLeafTurbulence = 1.0f;
        [Range(0.0f, 10.0f)] public float WindTreeLeafOffset = 1.0f;

        [Header("Wind Grass Settings")]
        [Range(0.0f, 10.0f)] public float WindGrassAmplitude = 1.0f;
        [Range(0.0f, 10.0f)] public float WindGrassSpeed = 1.0f;
        [Range(0.0f, 10.0f)] public float WindGrassTurbulence = 1.0f;
        [Range(0.0f, 10.0f)] public float WindGrassFlexibility = 1.0f;
        [Range(0.0f, 10.0f)] public float WindGrassWavesAmplitude = 1.0f;
        [Range(0.0f, 10.0f)] public float WindGrassWavesSpeed = 1.0f;
        [Range(0.0f, 10.0f)] public float WindGrassWavesScale = 1.0f;

        public Texture2D WindGrassWavesNoiseTexture = null;

        private MeshRenderer meshRenderer;

        // Disable Arrow in play mode
        void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.enabled = !Application.isPlaying;
        }

        void Update()
        {

            // Update WindToggle based on EnableGlobalWind
            WindToggle = EnableGlobalWind ? 1.0f : 0.0f;

            // Send information to shaders
            Shader.SetGlobalVector("ASPW_WindDirection", gameObject.transform.forward);
            Shader.SetGlobalFloat("ASPW_WindToggle", WindToggle);

            Shader.SetGlobalFloat("ASPW_WindTreeAmplitude", WindTreeAmplitude);
            Shader.SetGlobalFloat("ASPW_WindTreeSpeed", WindTreeSpeed);
            Shader.SetGlobalFloat("ASPW_WindTreeFlexibility", WindTreeFlexibility);

            Shader.SetGlobalFloat("ASPW_WindTreeLeafAmplitude", WindTreeLeafAmplitude);
            Shader.SetGlobalFloat("ASPW_WindTreeLeafSpeed", WindTreeLeafSpeed);
            Shader.SetGlobalFloat("ASPW_WindTreeLeafTurbulence", WindTreeLeafTurbulence);
            Shader.SetGlobalFloat("ASPW_WindTreeLeafOffset", WindTreeLeafOffset);

            Shader.SetGlobalFloat("ASPW_WindGrassAmplitude", WindGrassAmplitude);
            Shader.SetGlobalFloat("ASPW_WindGrassSpeed", WindGrassSpeed);
            Shader.SetGlobalFloat("ASPW_WindGrassTurbulence", WindGrassTurbulence);
            Shader.SetGlobalFloat("ASPW_WindGrassFlexibility", WindGrassFlexibility);
            Shader.SetGlobalFloat("ASPW_WindGrassWavesAmplitude", WindGrassWavesAmplitude);
            Shader.SetGlobalFloat("ASPW_WindGrassWavesSpeed", WindGrassWavesSpeed);
            Shader.SetGlobalFloat("ASPW_WindGrassWavesScale", WindGrassWavesScale);

            Shader.SetGlobalTexture("ASPW_WindGrassWavesNoiseTexture", WindGrassWavesNoiseTexture);
        }
    }
}