// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33447,y:32408,varname:node_4795,prsc:2|emission-2393-OUT,alpha-8875-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:33217,y:32445,varname:node_2393,prsc:2|A-8032-RGB,B-2053-RGB,C-797-RGB,D-8035-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32964,y:32708,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32964,y:32866,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:5483,x:32181,y:32339,ptovrint:False,ptlb:Noise 01,ptin:_Noise01,varname:node_5483,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d9a770fddc0276740b642075488dc8ac,ntxv:0,isnm:False|UVIN-1025-OUT;n:type:ShaderForge.SFN_Tex2d,id:5692,x:32181,y:32526,ptovrint:False,ptlb:Noise 02,ptin:_Noise02,varname:node_5692,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3699-OUT;n:type:ShaderForge.SFN_Panner,id:8047,x:31610,y:32306,varname:node_8047,prsc:2,spu:0,spv:-0.5|UVIN-9195-UVOUT,DIST-5841-OUT;n:type:ShaderForge.SFN_TexCoord,id:9195,x:31286,y:32180,varname:node_9195,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:6642,x:32488,y:32413,varname:node_6642,prsc:2|A-5483-R,B-5692-R,C-7104-R,D-3098-R,E-9958-OUT;n:type:ShaderForge.SFN_Slider,id:8035,x:32807,y:33039,ptovrint:False,ptlb:Final Power,ptin:_FinalPower,varname:node_8035,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:25;n:type:ShaderForge.SFN_Panner,id:5059,x:31610,y:32509,varname:node_5059,prsc:2,spu:0,spv:0.5|UVIN-9195-UVOUT,DIST-5841-OUT;n:type:ShaderForge.SFN_Append,id:8822,x:31895,y:32200,varname:node_8822,prsc:2|A-9195-U,B-1806-OUT;n:type:ShaderForge.SFN_Subtract,id:1806,x:31603,y:32044,varname:node_1806,prsc:2|A-9195-V,B-2678-Z;n:type:ShaderForge.SFN_TexCoord,id:2678,x:31115,y:32076,varname:node_2678,prsc:2,uv:0,uaff:True;n:type:ShaderForge.SFN_Tex2dAsset,id:8632,x:31947,y:31998,ptovrint:False,ptlb:Gradient Mask,ptin:_GradientMask,varname:node_8632,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7104,x:32167,y:32173,varname:node_7104,prsc:2,ntxv:0,isnm:False|UVIN-8822-OUT,TEX-8632-TEX;n:type:ShaderForge.SFN_Tex2d,id:3098,x:32167,y:32029,varname:node_3098,prsc:2,ntxv:0,isnm:False|TEX-8632-TEX;n:type:ShaderForge.SFN_Add,id:1025,x:31934,y:32428,varname:node_1025,prsc:2|A-8047-UVOUT,B-1158-OUT;n:type:ShaderForge.SFN_Add,id:3699,x:31934,y:32595,varname:node_3699,prsc:2|A-5059-UVOUT,B-1158-OUT;n:type:ShaderForge.SFN_Tex2d,id:2425,x:31679,y:32784,ptovrint:False,ptlb:Distortion Noise,ptin:_DistortionNoise,varname:node_2425,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:08cbf484153642245abfa42a429bccc9,ntxv:0,isnm:False|UVIN-2263-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1158,x:31858,y:32908,varname:node_1158,prsc:2|A-2425-R,B-984-OUT;n:type:ShaderForge.SFN_Slider,id:984,x:31468,y:32999,ptovrint:False,ptlb:Distortion Power,ptin:_DistortionPower,varname:node_984,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Panner,id:2263,x:31521,y:32724,varname:node_2263,prsc:2,spu:0,spv:0.25|UVIN-9195-UVOUT,DIST-5841-OUT;n:type:ShaderForge.SFN_Slider,id:9958,x:32074,y:32723,ptovrint:False,ptlb:Mask Power,ptin:_MaskPower,varname:node_9958,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Append,id:7407,x:32698,y:32469,varname:node_7407,prsc:2|A-6642-OUT,B-3232-OUT;n:type:ShaderForge.SFN_Vector1,id:3232,x:32488,y:32547,varname:node_3232,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:8032,x:32860,y:32469,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_8032,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7407-OUT;n:type:ShaderForge.SFN_Multiply,id:1651,x:33246,y:33059,varname:node_1651,prsc:2|A-6642-OUT,B-9741-OUT;n:type:ShaderForge.SFN_Slider,id:9741,x:32900,y:33165,ptovrint:False,ptlb:Opacity Boost,ptin:_OpacityBoost,varname:node_9741,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Clamp01,id:8875,x:33402,y:33059,varname:node_8875,prsc:2|IN-1651-OUT;n:type:ShaderForge.SFN_Time,id:5350,x:30878,y:32419,varname:node_5350,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:8349,x:30878,y:32268,ptovrint:False,ptlb:X_Speed,ptin:_X_Speed,varname:node_4397,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5841,x:31075,y:32314,varname:node_5841,prsc:2|A-8349-OUT,B-5350-T;proporder:797-5483-5692-2425-8632-984-9958-8035-8032-9741-8349;pass:END;sub:END;*/

Shader "Sine VFX/StartWaveAlphaBlended" {
    Properties {
        [HDR]_TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _Noise01 ("Noise 01", 2D) = "white" {}
        _Noise02 ("Noise 02", 2D) = "white" {}
        _DistortionNoise ("Distortion Noise", 2D) = "white" {}
        _GradientMask ("Gradient Mask", 2D) = "white" {}
        _DistortionPower ("Distortion Power", Range(0, 1)) = 0.1
        _MaskPower ("Mask Power", Range(0, 4)) = 1
        _FinalPower ("Final Power", Range(0, 25)) = 0
        _Ramp ("Ramp", 2D) = "white" {}
        _OpacityBoost ("Opacity Boost", Range(0, 4)) = 1
        _X_Speed ("X_Speed", Float ) = 1
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
            uniform float _X_Speed;
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
                float4 node_5350 = _Time;
                float node_5841 = (_X_Speed*node_5350.g);
                float2 node_2263 = (i.uv0+node_5841*float2(0,0.25));
                float4 _DistortionNoise_var = tex2D(_DistortionNoise,TRANSFORM_TEX(node_2263, _DistortionNoise));
                float node_1158 = (_DistortionNoise_var.r*_DistortionPower);
                float2 node_1025 = ((i.uv0+node_5841*float2(0,-0.5))+node_1158);
                float4 _Noise01_var = tex2D(_Noise01,TRANSFORM_TEX(node_1025, _Noise01));
                float2 node_3699 = ((i.uv0+node_5841*float2(0,0.5))+node_1158);
                float4 _Noise02_var = tex2D(_Noise02,TRANSFORM_TEX(node_3699, _Noise02));
                float2 node_8822 = float2(i.uv0.r,(i.uv0.g-i.uv0.b));
                float4 node_7104 = tex2D(_GradientMask,TRANSFORM_TEX(node_8822, _GradientMask));
                float4 node_3098 = tex2D(_GradientMask,TRANSFORM_TEX(i.uv0, _GradientMask));
                float node_6642 = (_Noise01_var.r*_Noise02_var.r*node_7104.r*node_3098.r*_MaskPower);
                float2 node_7407 = float2(node_6642,0.0);
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_7407, _Ramp));
                float3 emissive = (_Ramp_var.rgb*i.vertexColor.rgb*_TintColor.rgb*_FinalPower);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate((node_6642*_OpacityBoost)));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.5,0.5,0.5,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
