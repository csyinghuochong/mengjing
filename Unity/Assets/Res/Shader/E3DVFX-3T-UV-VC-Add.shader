// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "E3D/Effect/E3DVFX-3T-UV-VC-Add"
{
    Properties
    {
        [HDR]_BaseColor("BaseColor", Color) = (1,1,1,0)
        _BaseMap("BaseMap", 2D) = "white" {}
        _MaskMap("MaskMap", 2D) = "white" {}
        _DetailMap("DetailMap", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay+0" "IsEmissive"="true" }
        Cull Off
        ZWrite Off
        Blend One One

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);
            TEXTURE2D(_MaskMap);
            SAMPLER(sampler_MaskMap);
            TEXTURE2D(_DetailMap);
            SAMPLER(sampler_DetailMap);
            float4 _BaseColor;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionHCS = TransformObjectToHClip(input.positionOS);
                output.uv = input.uv;
                output.color = input.color;
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                float2 uv_BaseMap = input.uv;
                float2 uv_MaskMap = input.uv;
                float2 uv_DetailMap = input.uv;

                half4 baseColor = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, uv_BaseMap);
                half4 maskColor = SAMPLE_TEXTURE2D(_MaskMap, sampler_MaskMap, uv_MaskMap);
                half4 detailColor = SAMPLE_TEXTURE2D(_DetailMap, sampler_DetailMap, uv_DetailMap);

                half4 finalColor = baseColor * maskColor * detailColor * _BaseColor * input.color * input.color.a;

                return half4(finalColor.rgb, 1.0);
            }
            ENDHLSL
        }
    }
    CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16400
146;570;1293;521;1622.803;133.6719;1.951419;True;False
Node;AmplifyShaderEditor.SamplerNode;4;-740.7324,304.8581;Float;True;Property;_DetailMap;DetailMap;4;0;Create;True;0;0;False;0;None;0b9a37e1a12bbbf4a81e33967736eb9c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;6;-401.6464,349.4316;Float;False;Property;_BaseColor;BaseColor;0;1;[HDR];Create;True;0;0;False;0;1,1,1,0;0.6415823,0.1617646,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;3;-739.4657,114.9313;Float;True;Property;_MaskMap;MaskMap;3;0;Create;True;0;0;False;0;None;12ba37043dc223644bdf40f98314aa4a;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;7;-387.229,532.7782;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;2;-748.2686,-74.7831;Float;True;Property;_BaseMap;BaseMap;2;0;Create;True;0;0;False;0;None;84508b93f15f2b64386ec07486afc7a3;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;178.9884,32.50277;Float;False;6;6;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;1;543.0701,6.851983;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;E3D/Effect/E3DVFX-3T-UV-VC-Add;False;False;False;False;True;True;True;True;True;True;True;True;False;False;False;False;False;False;False;False;False;Off;2;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Transparent;;Overlay;All;True;True;True;True;True;True;True;False;False;False;False;False;False;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;4;1;False;-1;1;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;2;0
WireConnection;5;1;3;0
WireConnection;5;2;4;0
WireConnection;5;3;6;0
WireConnection;5;4;7;0
WireConnection;5;5;7;4
WireConnection;1;2;5;0
ASEEND*/
//CHKSM=177E43CD4956B126ABDEDBBEA9DB19FD933FD278