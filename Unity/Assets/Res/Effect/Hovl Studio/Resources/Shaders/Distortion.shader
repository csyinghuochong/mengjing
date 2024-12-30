Shader "Hovl/Particles/Distortion"
{
    Properties
    {
        _NormalMap("Normal Map", 2D) = "bump" {}
        _DistortionPower("Distortion power", Float) = 0.05
        _InvFade("Soft Particles Factor", Range(0.01, 3.0)) = 1.0
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "PreviewType" = "Plane" }

        Pass
        {
            Tags { "LightMode" = "UniversalForward" }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Input.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            TEXTURE2D(_NormalMap);
            SAMPLER(sampler_NormalMap);
            TEXTURE2D(_CameraDepthTexture);
            SAMPLER(sampler_CameraDepthTexture);

            float4 _NormalMap_ST;
            float _DistortionPower;
            float _InvFade;

            struct Attributes
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct Varyings
            {
                float4 position : SV_POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                float2 texcoord2 : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                float3 worldPos : TEXCOORD3;
            };

            Varyings vert(Attributes v)
            {
                Varyings o;
                o.position = TransformObjectToHClip(v.vertex);
                o.color = v.color;
                o.texcoord = v.texcoord;
                o.texcoord2 = TRANSFORM_TEX(v.texcoord, _NormalMap);
                o.projPos = ComputeScreenPos(o.position);
                o.worldPos = TransformObjectToWorld(v.vertex).xyz;
                return o;
            }

            float LinearEyeDepth(float z)
            {
                return 1.0 / (z * _ZBufferParams.x + _ZBufferParams.y);
            }

            half4 frag(Varyings i) : SV_Target
            {
                // Sample depth from the camera depth texture
                float sceneZ = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, sampler_CameraDepthTexture, i.projPos.xy).r;
                sceneZ = LinearEyeDepth(sceneZ); // Convert to linear depth
                
                // Calculate particle depth
                float partZ = LinearEyeDepth(i.projPos.z / i.projPos.w);
                
                // Calculate fade based on depth difference
                float fade = saturate(_InvFade * (sceneZ - partZ));
                i.color.a *= fade;

                // Sample normal map and apply distortion
                float3 normal = UnpackNormal(SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, i.texcoord2));
                float2 distortion = normal.xy * _DistortionPower;

                // Apply distortion to screen position
                i.projPos.xy += distortion;

                // Sample the distorted screen position
                half4 col = SAMPLE_TEXTURE2D(_CameraDepthTexture, sampler_CameraDepthTexture, i.projPos.xy);
                col.a *= i.color.a;

                return col;
            }
            ENDHLSL
        }
    }
}