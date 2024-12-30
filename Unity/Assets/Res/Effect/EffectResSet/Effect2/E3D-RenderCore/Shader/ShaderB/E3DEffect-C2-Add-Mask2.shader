// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// 注意：手动更改此数据可能会妨碍您在 Shader Forge 中打开它
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:True,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:6,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.2306556,fgcg:0.1892301,fgcb:0.7352941,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:40,x:32027,y:32574,varname:node_40,prsc:2|emission-9942-OUT;n:type:ShaderForge.SFN_Tex2d,id:217,x:30936,y:32166,ptovrint:True,ptlb:Base-RGBA,ptin:_BaseRGBA,varname:_BaseRGBA,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7953-OUT;n:type:ShaderForge.SFN_Multiply,id:218,x:31485,y:32528,varname:node_218,prsc:2|A-2950-OUT,B-6096-OUT;n:type:ShaderForge.SFN_Slider,id:6096,x:30871,y:32674,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:_Alpha,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:6.74703,max:10;n:type:ShaderForge.SFN_VertexColor,id:4009,x:31459,y:32782,varname:node_4009,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9942,x:31757,y:32715,varname:node_9942,prsc:2|A-218-OUT,B-4009-A,C-6505-RGB;n:type:ShaderForge.SFN_Tex2d,id:5290,x:30938,y:32389,ptovrint:False,ptlb:Shape-RGB,ptin:_ShapeRGB,varname:_ShapeRGB,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5417-OUT;n:type:ShaderForge.SFN_Multiply,id:2950,x:31204,y:32302,varname:node_2950,prsc:2|A-217-RGB,B-5290-RGB,C-217-A,D-5290-A;n:type:ShaderForge.SFN_Color,id:6505,x:31466,y:33003,ptovrint:False,ptlb:BaseColor,ptin:_BaseColor,varname:_BaseColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:7953,x:30603,y:32164,ptovrint:False,ptlb:2uvBase,ptin:_2uvBase,varname:node_7953,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2924-UVOUT,B-3786-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2924,x:30285,y:32162,varname:node_2924,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:3786,x:30290,y:32414,varname:node_3786,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_SwitchProperty,id:5417,x:30604,y:32387,ptovrint:False,ptlb:2uvShape,ptin:_2uvShape,varname:node_5417,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2924-UVOUT,B-3786-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:9603,x:32163,y:32919,ptovrint:False,ptlb:node_3153_copy,ptin:_node_3153_copy,varname:_node_3153_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:217-5290-6096-6505-7953-5417;pass:END;sub:END;*/

Shader "E3DEffect/C2/Add-Mask2" {
    Properties {
        _BaseRGBA ("Base-RGBA", 2D) = "white" {}
        _ShapeRGB ("Shape-RGB", 2D) = "white" {}
        _Alpha ("Alpha", Range(0, 10)) = 6.74703
        _BaseColor ("BaseColor", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _2uvBase ("2uvBase", Float ) = 0
        [MaterialToggle] _2uvShape ("2uvShape", Float ) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcColor
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _BaseRGBA; uniform float4 _BaseRGBA_ST;
            uniform float _Alpha;
            uniform sampler2D _ShapeRGB; uniform float4 _ShapeRGB_ST;
            uniform float4 _BaseColor;
            uniform fixed _2uvBase;
            uniform fixed _2uvShape;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float2 _2uvBase_var = lerp( i.uv0, i.uv1, _2uvBase );
                float4 _BaseRGBA_var = tex2D(_BaseRGBA,TRANSFORM_TEX(_2uvBase_var, _BaseRGBA));
                float2 _2uvShape_var = lerp( i.uv0, i.uv1, _2uvShape );
                float4 _ShapeRGB_var = tex2D(_ShapeRGB,TRANSFORM_TEX(_2uvShape_var, _ShapeRGB));
                float3 emissive = (((_BaseRGBA_var.rgb*_ShapeRGB_var.rgb*_BaseRGBA_var.a*_ShapeRGB_var.a)*_Alpha)*i.vertexColor.a*_BaseColor.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
