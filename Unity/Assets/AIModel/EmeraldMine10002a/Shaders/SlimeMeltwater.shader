Shader "EmeraldMine10002a/SlimeMeltwater"
{
    Properties
    {
        _BaseColor("Water and gel colour",Color)=(.10,.42,.53,.75)
        [HDR]_EmissionColor("Quiet interior light",Color)=(.015,.075,.105,1)
        _Smoothness("Wet sheen",Range(0,1))=.88
        _RippleStrength("Small ripples",Range(0,.25))=.055
        _FlowSpeed("Slow flow",Range(0,1))=.18
    }
    SubShader
    {
        Tags {"RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent"}
        Pass
        {
            Name "ForwardLit"
            Tags {"LightMode"="UniversalForward"}
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Back
            HLSLPROGRAM
            #pragma target 3.0
            #pragma vertex Vert
            #pragma fragment Frag
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile_fragment _ _SHADOWS_SOFT
            #pragma multi_compile_fog
            #pragma multi_compile_instancing
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            CBUFFER_START(UnityPerMaterial)
                half4 _BaseColor,_EmissionColor;
                half _Smoothness,_RippleStrength,_FlowSpeed;
            CBUFFER_END
            struct A {float4 positionOS:POSITION;float3 normalOS:NORMAL;float2 uv:TEXCOORD0;half4 color:COLOR;UNITY_VERTEX_INPUT_INSTANCE_ID};
            struct V {float4 positionCS:SV_POSITION;float3 positionWS:TEXCOORD0;half3 normalWS:TEXCOORD1;float2 uv:TEXCOORD2;half4 color:COLOR;half fog:TEXCOORD3;UNITY_VERTEX_INPUT_INSTANCE_ID UNITY_VERTEX_OUTPUT_STEREO};
            V Vert(A v)
            {
                V o=(V)0;UNITY_SETUP_INSTANCE_ID(v);UNITY_TRANSFER_INSTANCE_ID(v,o);UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                VertexPositionInputs p=GetVertexPositionInputs(v.positionOS.xyz);o.positionCS=p.positionCS;o.positionWS=p.positionWS;o.normalWS=TransformObjectToWorldNormal(v.normalOS);o.uv=v.uv;o.color=v.color;o.fog=ComputeFogFactor(p.positionCS.z);return o;
            }
            half4 Frag(V i):SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(i);UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
                float time=_Time.y*_FlowSpeed;float2 p=i.positionWS.xz;
                half broad=sin(p.x*.77+sin(p.y*.41)+time)*sin(p.y*.86-time*.7);
                half veins=pow(saturate(sin(p.x*2.1+p.y*.6+time)*sin(p.y*1.9-p.x*.48-time)),9);
                half rings=pow(saturate(sin(length(i.uv-.5)*58-time*2)),18);
                half3 normal=normalize(i.normalWS+half3(cos(p.x*1.8+time),0,sin(p.y*1.6-time))*_RippleStrength*.25);
                SurfaceData s=(SurfaceData)0;s.albedo=_BaseColor.rgb*(.90+broad*.06);s.metallic=.04;s.smoothness=_Smoothness;s.occlusion=1;s.alpha=1;s.normalTS=half3(0,0,1);s.emission=_EmissionColor.rgb+(veins*.075+rings*.04)*_BaseColor.rgb;
                InputData d=(InputData)0;d.positionWS=i.positionWS;d.normalWS=normal;d.viewDirectionWS=GetWorldSpaceNormalizeViewDir(i.positionWS);d.shadowCoord=TransformWorldToShadowCoord(i.positionWS);d.bakedGI=SampleSH(normal);d.normalizedScreenSpaceUV=GetNormalizedScreenSpaceUV(i.positionCS);d.vertexLighting=VertexLighting(i.positionWS,normal);d.shadowMask=1;
                half4 col=UniversalFragmentPBR(d,s);col.rgb=MixFog(col.rgb,i.fog);col.a=saturate(_BaseColor.a*i.color.a);return col;
            }
            ENDHLSL
        }
    }
    Fallback Off
}
