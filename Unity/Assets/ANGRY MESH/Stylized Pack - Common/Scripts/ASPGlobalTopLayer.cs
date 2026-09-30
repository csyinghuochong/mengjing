// ASP Global Top Layer - ANGRY MESH - contact@angrymesh.com

using UnityEngine;
using System.Collections.Generic;


namespace ANGRYMESH.StylizedPack
{
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    [RequireComponent(typeof(MeshRenderer))]
    public class ASPGlobalTopLayer : MonoBehaviour
    {
        // Top Layer Parameters for Height
        [Header("Top Layer Height Settings")]
        public float TopLayerHeightStart = -5000.0f;
        public float TopLayerHeightFade = 1.0f;

        // Top Layer Parameters for Trees
        [Header("Top Layer Tree Settings")]
        [Range(0.0f, 1.0f)] public float TopLayerTreeIntensity = 1.0f;
        [Range(0.0f, 2.0f)] public float TopLayerTreeOffset = 1.0f;
        [Range(0.0f, 2.0f)] public float TopLayerTreeContrast = 1.0f;
        [Range(0.0f, 2.0f)] public float TopLayerTreeArrowDirection = 1.0f;
        [Range(0.0f, 2.0f)] public float TopLayerBottomOffset = 1.0f;

        // Top Layer Parameters for Props
        [Header("Top Layer Props Settings")]
        [Range(0.0f, 1.0f)] public float TopLayerPropsIntensity = 1.0f;
        [Range(0.0f, 2.0f)] public float TopLayerPropsOffset = 1.0f;
        [Range(0.0f, 2.0f)] public float TopLayerPropsContrast = 1.0f;


        void Update()
        {

            // Send information to shaders
            Shader.SetGlobalFloat("ASPT_TopLayerHeightStart", TopLayerHeightStart);
            Shader.SetGlobalFloat("ASPT_TopLayerHeightFade", TopLayerHeightFade);

            Shader.SetGlobalFloat("ASPT_TopLayerIntensity", TopLayerTreeIntensity);
            Shader.SetGlobalFloat("ASPT_TopLayerOffset", TopLayerTreeOffset);
            Shader.SetGlobalFloat("ASPT_TopLayerContrast", TopLayerTreeContrast);
            Shader.SetGlobalFloat("ASPT_TopLayerArrowDirection", TopLayerTreeArrowDirection);
            Shader.SetGlobalFloat("ASPT_TopLayerBottomOffset", TopLayerBottomOffset);

            Shader.SetGlobalFloat("ASPP_TopLayerIntensity", TopLayerPropsIntensity);
            Shader.SetGlobalFloat("ASPP_TopLayerOffset", TopLayerPropsOffset);
            Shader.SetGlobalFloat("ASPP_TopLayerContrast", TopLayerPropsContrast);
        }
    }
}