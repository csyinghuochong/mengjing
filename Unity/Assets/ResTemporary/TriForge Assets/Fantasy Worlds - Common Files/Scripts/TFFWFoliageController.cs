using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TriForge
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    public class TFFWFoliageController : MonoBehaviour
    {
        [Header("Global Wind Settings")]
        [Range(0.0f, 2.0f)] public float WindStrength = 0.3f;

        [Header("Tree Color")]
        public bool EnableTreeColorVariance = false;
        [Range(0.0f, 1.0f)] public float ColorVarianceIntensity = 0.1f;
        [Range(-1.0f, 1.0f)] public float ColorVarianceBiasShift = 0.1f;
        [Range(-1.0f, 1.0f)] public float ColorVarianceMin = -0.15f;
        [Range(-1.0f, 1.0f)] public float ColorVarianceMax = 0.15f;
        [Range(0.0f, 1.0f)] public float BrightnessVariance = 0.0f;
        public float ColorVarianceMaskScale = 100.0f;

        [Header("Grass Color")]
        public bool EnableGrassColorVariance = false;
        [Range(0.0f, 1.0f)] public float GrassVarianceIntensity = 0.1f;
        [Range(-1.0f, 1.0f)] public float GrassVarianceBiasShift = 0.1f;
        [Range(-1.0f, 1.0f)] public float GrassVarianceMin = -0.15f;
        [Range(-1.0f, 1.0f)] public float GrassVarianceMax = 0.15f;
        [Range(0.0f, 10.0f)] public float GrassBrightnessVariance = 0.0f;
        [Range(0.0f, 1.0f)]public float GrassVarianceRootInfluence = 0.0f;
        public float GrassVarianceMaskScale = 100.0f;

        [Header("Grass Settings")]
        public bool EnableGrassWind = true;
        [Range(0.0f, 1.0f)] public float GrassWindRotationMapInfluence = 0.6f;
        [Range(0.0f, 3.0f)] public float GrassWindStrength = 0.5f;
        [Range(0.0f, 15.0f)] public float GrassFadeDistance = 1.0f;

        private Vector3 WindDirection;

        void Update()
        {
            //Global Wind Controls
            WindDirection = transform.right.normalized;
            Shader.SetGlobalVector("TF_WIND_DIRECTION", WindDirection);
            Shader.SetGlobalFloat("TF_WIND_STRENGTH", WindStrength);

            //Tree Color Controls
            Shader.SetGlobalInt("TF_ColorVarianceEnable", EnableTreeColorVariance ? 1 : 0);
            Shader.SetGlobalFloat("TF_ColorVarianceMin", ColorVarianceMin);
            Shader.SetGlobalFloat("TF_ColorVarianceMax", ColorVarianceMax);
            Shader.SetGlobalFloat("TF_ColorVarianceIntensity", ColorVarianceIntensity);
            Shader.SetGlobalFloat("TF_ColorVarianceBiasShift", ColorVarianceBiasShift);
            Shader.SetGlobalFloat("TF_ColorVarianceMaskScale", ColorVarianceMaskScale);
            Shader.SetGlobalFloat("TF_BrightnessVariance", BrightnessVariance);

            //Grass Color Controls
            Shader.SetGlobalInt("TF_GrassVarianceEnable", EnableGrassColorVariance ? 1 : 0);
            Shader.SetGlobalFloat("TF_GrassVarianceMin", GrassVarianceMin);
            Shader.SetGlobalFloat("TF_GrassVarianceMax", GrassVarianceMax);
            Shader.SetGlobalFloat("TF_GrassVarianceIntensity", GrassVarianceIntensity);
            Shader.SetGlobalFloat("TF_GrassVarianceBiasShift", GrassVarianceBiasShift);
            Shader.SetGlobalFloat("TF_GrassVarianceMaskScale", GrassVarianceMaskScale);
            Shader.SetGlobalFloat("TF_GrassBrightnessVariance", GrassBrightnessVariance);
            Shader.SetGlobalFloat("TF_GrassVarianceRootInfluence", GrassVarianceRootInfluence);

            //Grass Controls
            Shader.SetGlobalInt("TF_EnableGrassWind", EnableGrassWind ? 1 : 0);
            Shader.SetGlobalFloat("TF_ROTATION_MAP_INFLUENCE", GrassWindRotationMapInfluence);
            Shader.SetGlobalFloat("TF_GRASS_WIND_STRENGTH", GrassWindStrength);
            Shader.SetGlobalFloat("TF_GrassFadeDistance", GrassFadeDistance);
        }
    }
}