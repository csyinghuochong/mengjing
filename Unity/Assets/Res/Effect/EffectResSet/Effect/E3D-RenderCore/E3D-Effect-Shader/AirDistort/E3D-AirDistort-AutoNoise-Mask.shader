// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
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

            // Using texture sampling and distortion logic
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
                float2 panner = _Time.y * float2(0.24, 0.24);
                float2 uvDistort = i.uv + panner;

                // Sample the distort map
                half4 distortColor = tex2D(_DistortMap, uvDistort);

                // Mask logic and applying alpha
                float2 uvMask = i.uv * _MaskMap_ST.xy + _MaskMap_ST.zw;
                half4 maskColor = tex2D(_MaskMap, uvMask);
                half maskAlpha = clamp(maskColor.a * i.color.a * _Alpha, 0.0, 1.0);

                // Apply distortion based on mask and distortion offset
                float2 distortedUV = lerp(i.uv, uvDistort * _DistortOffset, saturate(maskAlpha * _Distrot));

                // Sample the screen color from the grabbed texture
                half4 screenColor = tex2D(_GrabTexture, distortedUV);

                // Set the emission (for unlit effect)
                half4 finalColor = screenColor;
                finalColor.a = maskAlpha;

                return finalColor;
            }

            ENDCG
        }
    }

    FallBack "Universal Forward"
}
/*ASEBEGIN
Version=16400
65;445;1183;582;2731.28;161.6893;1.563111;True;False
Node;AmplifyShaderEditor.RangedFloatNode;43;-2967.753,323.4588;Float;False;Property;_Speed;Speed;2;0;Create;True;0;0;False;0;0.1;0.07;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;26;-2534.627,158.5554;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;36;-2538.066,283.9578;Float;False;Constant;_Vector0;Vector 0;6;0;Create;True;0;0;False;0;0.24,0.24;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;38;-2551.046,547.5404;Float;False;Constant;_Vector1;Vector 1;6;0;Create;True;0;0;False;0;-0.24,0.1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;40;-2544.218,430.6106;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;39;-2219.027,474.9849;Float;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;-2194.185,202.9295;Float;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;32;-1978.533,184.4194;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;44;-2154.18,-5.830811;Float;False;Property;_Tiling;Tiling;7;0;Create;True;0;0;False;0;0;1;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;4;-1634.437,-739.0858;Float;True;Property;_MaskMap;MaskMap;5;0;Create;True;0;0;False;0;None;ad0c8b6a37a4a9a45b626a4e408b968c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;6;-1543.762,-436.5042;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;41;-2010.154,468.3369;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;37;-1751.02,415.6652;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;27;-1757.099,167.093;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;14;-1610.229,-221.2127;Float;False;Property;_Alpha;Alpha;6;0;Create;True;0;0;False;0;2;3.44;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-1120.335,-554.6775;Float;False;3;3;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-754.2572,-555.1882;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;34;-1397.357,499.8414;Float;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;False;0;None;226eb2b35b741624e88de8f5cec0e4d6;True;0;False;white;Auto;False;Instance;9;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;9;-1429.191,25.16702;Float;True;Property;_DistortMap;DistortMap;1;0;Create;True;0;0;False;0;None;7abc32cbcbe367844ac624c77a525a2d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;18;-998.3362,121.8688;Float;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;20;-994.6725,356.9884;Float;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;3;-778.4739,596.5288;Float;False;Property;_Distrot;Distrot;3;0;Create;True;0;0;False;0;0.255728;0.1;0;0.1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;15;-592.5397,-348.1727;Float;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;-92.49423,320.6691;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;19;-1351.505,378.2209;Float;False;Property;_DistortOffset;DistortOffset;4;0;Create;True;0;0;False;0;-0.8;-1.14;-2;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;17;-738.3473,195.3049;Float;True;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;7;-1096.233,-82.74902;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;23;188.9498,284.9368;Float;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;-473.3196,298.6065;Float;True;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;8;-698.6367,-36.88651;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.LerpOp;2;357.8701,12.93179;Float;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScreenColorNode;1;639.412,-35.76579;Float;False;Global;_GrabScreen0;Grab Screen 0;0;0;Create;True;0;0;False;0;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1069.36,-303.1503;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;E3DEffect/AirDistort/AutoNoise-Mask;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;2;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;Transparent;;Overlay;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;26;0;43;0
WireConnection;40;0;43;0
WireConnection;39;0;40;0
WireConnection;39;1;38;0
WireConnection;31;0;26;0
WireConnection;31;1;36;0
WireConnection;32;0;31;0
WireConnection;41;0;39;0
WireConnection;37;0;44;0
WireConnection;37;1;41;0
WireConnection;27;0;44;0
WireConnection;27;1;32;0
WireConnection;5;0;4;0
WireConnection;5;1;4;4
WireConnection;5;2;6;4
WireConnection;16;0;5;0
WireConnection;16;1;14;0
WireConnection;34;1;37;0
WireConnection;9;1;27;0
WireConnection;18;0;9;1
WireConnection;18;1;34;1
WireConnection;20;0;9;2
WireConnection;20;1;34;1
WireConnection;15;0;16;0
WireConnection;22;0;15;0
WireConnection;22;1;3;0
WireConnection;17;0;18;0
WireConnection;17;1;20;0
WireConnection;23;0;22;0
WireConnection;42;0;17;0
WireConnection;42;1;19;0
WireConnection;8;0;7;1
WireConnection;8;1;7;2
WireConnection;2;0;8;0
WireConnection;2;1;42;0
WireConnection;2;2;23;0
WireConnection;1;0;2;0
WireConnection;0;2;1;0
WireConnection;0;9;15;0
ASEEND*/
//CHKSM=EA8E74102709322FC10E163B982D9E5BF71902A4