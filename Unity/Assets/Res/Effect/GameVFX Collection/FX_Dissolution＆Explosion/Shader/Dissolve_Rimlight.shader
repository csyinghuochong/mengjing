// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-2239-OUT,emission-6174-OUT,clip-1902-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32297,y:32763,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9560,x:32261,y:32536,ptovrint:False,ptlb:TEX,ptin:_TEX,varname:node_9560,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2239,x:32538,y:32616,varname:node_2239,prsc:2|A-9560-RGB,B-1304-RGB;n:type:ShaderForge.SFN_Color,id:4536,x:32063,y:32883,ptovrint:False,ptlb:dis_color,ptin:_dis_color,varname:node_4536,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_If,id:4363,x:32444,y:33214,varname:node_4363,prsc:2|A-9834-OUT,B-2866-OUT,GT-1214-OUT,EQ-7448-OUT,LT-7448-OUT;n:type:ShaderForge.SFN_Multiply,id:6174,x:32312,y:32918,varname:node_6174,prsc:2|A-4536-RGB,B-6264-OUT,C-4363-OUT;n:type:ShaderForge.SFN_Slider,id:6264,x:31876,y:33070,ptovrint:False,ptlb:dis_light,ptin:_dis_light,varname:node_6264,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Relay,id:9834,x:32206,y:33148,varname:node_9834,prsc:2|IN-1902-OUT;n:type:ShaderForge.SFN_Slider,id:2866,x:32032,y:33250,ptovrint:False,ptlb:range,ptin:_range,varname:node_2866,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.04314768,max:1;n:type:ShaderForge.SFN_Vector1,id:1214,x:32257,y:33351,varname:node_1214,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7448,x:32257,y:33425,varname:node_7448,prsc:2,v1:1;n:type:ShaderForge.SFN_Divide,id:1902,x:31990,y:33420,varname:node_1902,prsc:2|A-721-R,B-9001-OUT;n:type:ShaderForge.SFN_Tex2d,id:721,x:31690,y:33327,ptovrint:False,ptlb:dissolve,ptin:_dissolve,varname:node_721,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e01e4acd3521d2b449a08d960b5f1bfa,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:9001,x:31576,y:33549,ptovrint:False,ptlb:dissolve_Slider,ptin:_dissolve_Slider,varname:node_9001,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;proporder:1304-9560-721-9001-4536-6264-2866;pass:END;sub:END;*/

Shader "Shader Forge/Dissolve_Rimlight" {
    Properties {
        [HDR]_Color ("Color", Color) = (1,1,1,1)
        _TEX ("TEX", 2D) = "white" {}
        _dissolve ("dissolve", 2D) = "white" {}
        _dissolve_Slider ("dissolve_Slider", Range(0, 2)) = 0
        [HDR]_dis_color ("dis_color", Color) = (0.5,0.5,0.5,1)
        _dis_light ("dis_light", Range(0, 3)) = 1
        _range ("range", Range(0, 1)) = 0.04314768
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _TEX; uniform float4 _TEX_ST;
            uniform float4 _dis_color;
            uniform float _dis_light;
            uniform float _range;
            uniform sampler2D _dissolve; uniform float4 _dissolve_ST;
            uniform float _dissolve_Slider;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _dissolve_var = tex2D(_dissolve,TRANSFORM_TEX(i.uv0, _dissolve));
                float node_1902 = (_dissolve_var.r/_dissolve_Slider);
                clip(node_1902 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _TEX_var = tex2D(_TEX,TRANSFORM_TEX(i.uv0, _TEX));
                float3 diffuseColor = (_TEX_var.rgb*_Color.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_4363_if_leA = step(node_1902,_range);
                float node_4363_if_leB = step(_range,node_1902);
                float node_7448 = 1.0;
                float3 emissive = (_dis_color.rgb*_dis_light*lerp((node_4363_if_leA*node_7448)+(node_4363_if_leB*0.0),node_7448,node_4363_if_leA*node_4363_if_leB));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color;
            uniform sampler2D _TEX; uniform float4 _TEX_ST;
            uniform float4 _dis_color;
            uniform float _dis_light;
            uniform float _range;
            uniform sampler2D _dissolve; uniform float4 _dissolve_ST;
            uniform float _dissolve_Slider;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _dissolve_var = tex2D(_dissolve,TRANSFORM_TEX(i.uv0, _dissolve));
                float node_1902 = (_dissolve_var.r/_dissolve_Slider);
                clip(node_1902 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _TEX_var = tex2D(_TEX,TRANSFORM_TEX(i.uv0, _TEX));
                float3 diffuseColor = (_TEX_var.rgb*_Color.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
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
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _dissolve; uniform float4 _dissolve_ST;
            uniform float _dissolve_Slider;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _dissolve_var = tex2D(_dissolve,TRANSFORM_TEX(i.uv0, _dissolve));
                float node_1902 = (_dissolve_var.r/_dissolve_Slider);
                clip(node_1902 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
