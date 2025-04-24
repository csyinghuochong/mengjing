// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:1,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-9039-OUT,alpha-5496-OUT;n:type:ShaderForge.SFN_Multiply,id:9039,x:32455,y:32751,varname:node_9039,prsc:2|A-9782-RGB,B-3391-RGB,C-8433-RGB,D-7878-OUT;n:type:ShaderForge.SFN_VertexColor,id:3391,x:32076,y:32849,varname:node_3391,prsc:2;n:type:ShaderForge.SFN_Color,id:8433,x:32076,y:33007,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7573,x:31293,y:32480,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_5483,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d9a770fddc0276740b642075488dc8ac,ntxv:0,isnm:False|UVIN-5689-OUT;n:type:ShaderForge.SFN_Tex2d,id:7800,x:31293,y:32667,ptovrint:False,ptlb:Noise 02,ptin:_Noise02,varname:node_5692,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5560-OUT;n:type:ShaderForge.SFN_Panner,id:7785,x:30435,y:32502,varname:node_7785,prsc:2,spu:0,spv:0.5|UVIN-7376-UVOUT,DIST-8618-OUT;n:type:ShaderForge.SFN_TexCoord,id:7376,x:30086,y:32499,varname:node_7376,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:7013,x:31600,y:32554,varname:node_7013,prsc:2|A-7573-R,B-7800-R,C-5871-R,D-4875-R,E-7182-OUT;n:type:ShaderForge.SFN_Slider,id:7878,x:31919,y:33180,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_8035,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:25;n:type:ShaderForge.SFN_Panner,id:5190,x:30435,y:32705,varname:node_5190,prsc:2,spu:0,spv:0.5|UVIN-7376-UVOUT,DIST-8618-OUT;n:type:ShaderForge.SFN_Append,id:257,x:30706,y:32350,varname:node_257,prsc:2|A-7376-U,B-1403-OUT;n:type:ShaderForge.SFN_Subtract,id:1403,x:30428,y:32240,varname:node_1403,prsc:2|A-7376-V,B-347-Z;n:type:ShaderForge.SFN_TexCoord,id:347,x:30047,y:32245,varname:node_347,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Tex2dAsset,id:5027,x:31001,y:32139,ptovrint:False,ptlb:Gradient Mask,ptin:_GradientMask,varname:node_8632,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5871,x:31279,y:32314,varname:node_7104,prsc:2,ntxv:0,isnm:False|UVIN-257-OUT,TEX-5027-TEX;n:type:ShaderForge.SFN_Tex2d,id:4875,x:31279,y:32170,varname:node_3098,prsc:2,ntxv:0,isnm:False|TEX-5027-TEX;n:type:ShaderForge.SFN_Add,id:5689,x:30988,y:32569,varname:node_5689,prsc:2|A-7785-UVOUT,B-3285-OUT;n:type:ShaderForge.SFN_Add,id:5560,x:30988,y:32736,varname:node_5560,prsc:2|A-5190-UVOUT,B-3285-OUT;n:type:ShaderForge.SFN_Tex2d,id:1040,x:30679,y:32956,ptovrint:False,ptlb:Distortion Noise,ptin:_DistortionNoise,varname:node_2425,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:08cbf484153642245abfa42a429bccc9,ntxv:0,isnm:False|UVIN-5111-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3285,x:30890,y:33005,varname:node_3285,prsc:2|A-1040-R,B-6528-OUT;n:type:ShaderForge.SFN_Slider,id:6528,x:30522,y:33140,ptovrint:False,ptlb:Distortion Power,ptin:_DistortionPower,varname:node_984,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Panner,id:5111,x:30453,y:32893,varname:node_5111,prsc:2,spu:0,spv:0.2|UVIN-7376-UVOUT,DIST-8618-OUT;n:type:ShaderForge.SFN_Slider,id:7182,x:31186,y:32864,ptovrint:False,ptlb:Mask Power,ptin:_MaskPower,varname:node_9958,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Append,id:6265,x:31810,y:32610,varname:node_6265,prsc:2|A-7013-OUT,B-7545-OUT;n:type:ShaderForge.SFN_Vector1,id:7545,x:31600,y:32688,varname:node_7545,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:9782,x:31972,y:32610,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_8032,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6265-OUT;n:type:ShaderForge.SFN_Multiply,id:6475,x:32806,y:33082,varname:node_6475,prsc:2|A-7013-OUT,B-180-OUT;n:type:ShaderForge.SFN_Slider,id:180,x:32460,y:33188,ptovrint:False,ptlb:Opacity Boost,ptin:_OpacityBoost,varname:node_9741,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Clamp01,id:5496,x:32962,y:33082,varname:node_5496,prsc:2|IN-6475-OUT;n:type:ShaderForge.SFN_Time,id:9080,x:29841,y:32648,varname:node_9080,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:2315,x:29861,y:32579,ptovrint:False,ptlb:X_Speed_copy_copy,ptin:_X_Speed_copy_copy,varname:_X_Speed_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:8618,x:30048,y:32648,varname:node_8618,prsc:2|A-2315-OUT,B-9080-T;proporder:8433-7573-7800-7878-5027-7182-9782-180-1040-6528-2315;pass:END;sub:END;*/

Shader "Shader Forge/NoiseAlphaBlend" {
    Properties {
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _Noise01 ("Noise 01", 2D) = "white" {}
        _Noise02 ("Noise 02", 2D) = "white" {}
        _FinalPower ("Final Power", Range(0, 25)) = 0
        _GradientMask ("Gradient Mask", 2D) = "white" {}
        _MaskPower ("Mask Power", Range(0, 4)) = 1
        _Ramp ("Ramp", 2D) = "white" {}
        _OpacityBoost ("Opacity Boost", Range(0, 4)) = 1
        _DistortionNoise ("Distortion Noise", 2D) = "white" {}
        _DistortionPower ("Distortion Power", Range(0, 1)) = 0.1
        _X_Speed_copy_copy ("X_Speed_copy_copy", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Front
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 3.0
            uniform float4 _TintColor;
            uniform sampler2D _Noise01; uniform float4 _Noise01_ST;
            uniform sampler2D _Noise02; uniform float4 _Noise02_ST;
            uniform float _FinalPower;
            uniform sampler2D _GradientMask; uniform float4 _GradientMask_ST;
            uniform sampler2D _DistortionNoise; uniform float4 _DistortionNoise_ST;
            uniform float _DistortionPower;
            uniform float _MaskPower;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _OpacityBoost;
            uniform float _X_Speed_copy_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_9080 = _Time;
                float node_8618 = (_X_Speed_copy_copy*node_9080.g);
                float2 node_5111 = (i.uv0+node_8618*float2(0,0.2));
                float4 _DistortionNoise_var = tex2D(_DistortionNoise,TRANSFORM_TEX(node_5111, _DistortionNoise));
                float node_3285 = (_DistortionNoise_var.r*_DistortionPower);
                float2 node_5689 = ((i.uv0+node_8618*float2(0,0.5))+node_3285);
                float4 _Noise01_var = tex2D(_Noise01,TRANSFORM_TEX(node_5689, _Noise01));
                float2 node_5560 = ((i.uv0+node_8618*float2(0,0.5))+node_3285);
                float4 _Noise02_var = tex2D(_Noise02,TRANSFORM_TEX(node_5560, _Noise02));
                float2 node_257 = float2(i.uv0.r,(i.uv0.g-i.uv0.b));
                float4 node_7104 = tex2D(_GradientMask,TRANSFORM_TEX(node_257, _GradientMask));
                float4 node_3098 = tex2D(_GradientMask,TRANSFORM_TEX(i.uv0, _GradientMask));
                float node_7013 = (_Noise01_var.r*_Noise02_var.r*node_7104.r*node_3098.r*_MaskPower);
                float2 node_6265 = float2(node_7013,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_6265, _Ramp));
                float3 emissive = (_Ramp_var.rgb*i.vertexColor.rgb*_TintColor.rgb*_FinalPower);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate((node_7013*_OpacityBoost)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
