Shader "E3DEffect/AirDistort/AutoNoise-Mask"
{
    Properties
    {
        _DistortMap("DistortMap", 2D) = "white" {}
        _Speed("Speed", Range(0, 1)) = 0.1
        _Distrot("Distrot", Range(0, 0.1)) = 0.255728
        _DistortOffset("DistortOffset", Range(-2, 2)) = -0.8
        _MaskMap("MaskMap", 2D) = "white" {}
        _Alpha("Alpha", Range(0, 5)) = 2
        _Tiling("Tiling", Range(0, 5)) = 0
        [HideInInspector] _texcoord("", 2D) = "white" {}
        [HideInInspector] __dirty("", Int) = 1
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Overlay+0" "IsEmissive" = "true" }
        Pass
        {
            Tags { "LightMode" = "Unlit" }

            Cull Back
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            
            CGPROGRAM
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "UnityShaderVariables.cginc"

            #pragma target 3.0
            #pragma vertex vert
            #pragma fragment frag

            // Properties
            sampler2D _DistortMap;
            float _Speed;
            float _Distrot;
            float _DistortOffset;
            sampler2D _MaskMap;
            float4 _MaskMap_ST;
            float _Alpha;
            float _Tiling;

            // Structure to hold the input for vertex and fragment shaders
            struct Attributes
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            // Vertex Shader
            Varyings vert(Attributes v)
            {
                Varyings o;
                o.position = TransformObjectToHClip(v.position.xyz);
                o.uv = v.uv * _Tiling;
                o.color = v.color;
                return o;
            }

            // Fragment Shader
            half4 frag(Varyings i) : SV_Target
            {
                // Time-based animation for distortion
                //float2 panner = _Time.y * float2(0.24, 0.24);
                //float2 uvDistort = i.uv + panner;

                // Sample the distort map
                //half4 distortColor = tex2D(_DistortMap, uvDistort);

                // Mask logic and applying alpha
                //float2 uvMask = i.uv * _MaskMap_ST.xy + _MaskMap_ST.zw;
                //half4 maskColor = tex2D(_MaskMap, uvMask);
                //half maskAlpha = clamp(maskColor.a * i.color.a * _Alpha, 0.0, 1.0);

                // Apply distortion based on mask and distortion offset
                //float2 distortedUV = lerp(i.uv, uvDistort * _DistortOffset, saturate(maskAlpha * _Distrot));

                // Sample the screen color from the grabbed texture
                //half4 screenColor =   tex2D(_GrabTexture, distortedUV);   20250625

                // Set the emission (for unlit effect)
                //half4 finalColor = screenColor;
                //finalColor.a = maskAlpha;

                half4 finalColor =   half4(0,0,0,0);
                return finalColor;
            }

            ENDCG
        }
    }

    FallBack "Universal Forward"
}