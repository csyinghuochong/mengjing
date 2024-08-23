// URP下的透明效果
Shader "Custom/SimpleAlpha"
{
    Properties
    {
        _FresnelColor("FresnelColor",Color) = (0,0,0,0)
        _Fresnel("Fade(X) Intensity(Y) Top(Z) Offset(W)",Vector) = (4,1,1,0)
    }
    SubShader
    {
        Tags
        {
            //告诉引擎，该Shader只用于 URP 渲染管线
            "RenderPipeline"="UniversalPipeline"
            //渲染类型
            "RenderType"="Transparent"
            //渲染队列
            "Queue"="Transparent"
        }
        Blend One One ZWrite On
        Pass
        {


            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float3 vertexOS : POSITION;
                float3 normalOS : NORMAL;
            };

            struct Varyings
            {
                float3 vertexOS : TEXCOORD0;
                float4 vertexCS : SV_POSITION;
                float3 vertexWS : TEXCOORD1;
                float3 normalWS : TEXCOORD2;
            };

            CBUFFER_START(UnityPerMaterial)
            half4 _FresnelColor;
            half4 _Fresnel;
            float _Offset;
            CBUFFER_END
            
            Varyings vert (Attributes v)
            {
                Varyings o;
                o.vertexOS = v.vertexOS;
                o.vertexWS = TransformObjectToWorld(v.vertexOS);
                o.vertexCS = TransformWorldToHClip(o.vertexWS);
                o.normalWS = TransformObjectToWorldNormal(v.normalOS);
                
                return o;
            }

            half4 frag (Varyings i) : SV_Target
            {
                
                //dot(N,L)
                half3 N = normalize(i.normalWS);
                half3 L = normalize(_WorldSpaceCameraPos - i.vertexWS);
                half NdotL = dot(N,L);
                //菲涅尔效果 1 - dot(N,L)
                half fresnel = 1 - saturate(NdotL);
                //菲涅尔自定义
                half4 fresnel1 = pow(fresnel,_Fresnel.x) * _Fresnel.y * _FresnelColor;
                
                //透明渐变效果
                float alphaMask = saturate(i.vertexOS.y * -1 + i.vertexOS.x * -1 + _Fresnel.w);
                fresnel1 = alphaMask * fresnel1;

                //头部菲涅尔效果和下部菲涅尔效果做出区别
                fresnel1 = lerp(fresnel1,_FresnelColor * alphaMask * fresnel1,alphaMask * _Fresnel.z);
                
                return fresnel1;
            }
            ENDHLSL
        }
    }
}