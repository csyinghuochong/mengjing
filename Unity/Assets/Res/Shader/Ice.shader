// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Hovl/Particles/Ice"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _BaseColor("Base Color", Color) = (0.02352941, 0.2055747, 1, 1)
        _UpColor("Up Color", Color) = (0.4575472, 0.7381514, 1, 1)
        _ColorPosition("Color Position", Range(0, 1)) = 0.35
        _Emission("Emission", Float) = 1
        _FresnelColor("Fresnel Color", Color) = (1, 1, 1, 1)
        _FresnelPower("Fresnel Power", Float) = 6
        _FresnelScale("Fresnel Scale", Float) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent" "Queue"="Transparent"
        }
        LOD 200

        Pass
        {
            Name "ForwardLit"
            Tags
            {
                "LightMode"="UniversalForward"
            }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float3 normalOS : NORMAL;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
            };

            CBUFFER_START(UnityPerMaterial)
                TEXTURE2D(_MainTex);
                SAMPLER(sampler_MainTex);
                float4 _BaseColor;
                float4 _UpColor;
                float _ColorPosition;
                float _Emission;
                float4 _FresnelColor;
                float _FresnelPower;
                float _FresnelScale;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                UNITY_SETUP_INSTANCE_ID(input);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

                float3 worldPos = TransformObjectToWorld(input.positionOS.xyz);
                float3 worldNormal = TransformObjectToWorldNormal(input.normalOS);

                output.positionHCS = TransformWorldToHClip(worldPos);
                output.uv = input.uv;
                output.worldPos = worldPos;
                output.worldNormal = worldNormal;

                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(input);

                float4 baseColor = lerp(_BaseColor, _UpColor, saturate(input.worldNormal.y + _ColorPosition));
                float3 viewDir = normalize(GetWorldSpaceViewDir(input.worldPos));
                float fresnelFactor = pow(1.0 - saturate(dot(normalize(input.worldNormal), viewDir)), _FresnelPower) *
                    _FresnelScale;
                float4 fresnelColor = fresnelFactor * _FresnelColor;
                float4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                float4 finalColor = texColor * (baseColor + fresnelColor);

                finalColor.rgb *= _Emission;

                return finalColor;
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Lit"
}
/*ASEBEGIN
Version=16800
472;260;1307;708;2207.37;806.9595;2.601362;True;False
Node;AmplifyShaderEditor.RangedFloatNode;12;-1419.196,89.45203;Float;False;Property;_ColorPosition;Color Position;3;0;Create;True;0;0;False;0;0.35;0.35;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;36;-1128.806,-59.0783;Float;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;19;-1134.528,358.6681;Float;False;Property;_FresnelPower;Fresnel Power;6;0;Create;True;0;0;False;0;6;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;18;-1128.18,282.2344;Float;False;Property;_FresnelScale;Fresnel Scale;7;0;Create;True;0;0;False;0;1;6;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;13;-1138.538,93.74537;Float;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;-1;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;14;-909.3104,5.574037;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FresnelNode;1;-946.2626,238.8452;Float;False;Standard;WorldNormal;ViewDir;False;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;3;False;3;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;49;-695.7538,153.8804;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;50;-732.5668,7.386911;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;4;-852.0582,-352.2737;Float;False;Property;_Color;Color;1;0;Create;True;0;0;False;0;0.02352941,0.2055747,1,1;0.02352941,0.2055747,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;10;-841.7653,-185.6277;Float;False;Property;_UpColor;Up Color;2;0;Create;True;0;0;False;0;0.4575472,0.7381514,1,1;0.4575472,0.7381514,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;9;-525.8378,-36.47785;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;3;-690.6082,240.8396;Float;False;Property;_FresnelColor;Fresnel Color;5;1;[HDR];Create;True;0;0;False;0;1,1,1,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;48;-530.2949,77.13261;Float;False;2;0;FLOAT;1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;38;-894.3182,-559.7097;Float;True;Property;_MainTex;Main Tex;0;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2;-351.351,157.6775;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;37;-343.9689,-58.87302;Float;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.VertexColorNode;23;-658.9435,426.0627;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;51;-142.5839,237.4695;Float;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;6;-157.4875,-6.303779;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;21;28.31375,172.1849;Float;False;Property;_Emission;Emission;4;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;15.77605,-9.707672;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;20;200.7058,77.83524;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;17;381.9216,-22.00584;Float;False;True;2;Float;;0;0;Lambert;Hovl/Particles/Ice;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;13;0;12;0
WireConnection;14;0;36;2
WireConnection;14;1;13;0
WireConnection;1;2;18;0
WireConnection;1;3;19;0
WireConnection;49;0;1;0
WireConnection;50;0;14;0
WireConnection;9;0;4;0
WireConnection;9;1;10;0
WireConnection;9;2;50;0
WireConnection;48;1;49;0
WireConnection;2;0;49;0
WireConnection;2;1;3;0
WireConnection;37;0;38;0
WireConnection;37;1;9;0
WireConnection;37;2;48;0
WireConnection;51;0;23;0
WireConnection;6;0;37;0
WireConnection;6;1;2;0
WireConnection;22;0;6;0
WireConnection;22;1;51;0
WireConnection;20;0;22;0
WireConnection;20;1;21;0
WireConnection;17;0;22;0
WireConnection;17;2;20;0
WireConnection;17;9;23;4
ASEEND*/
//CHKSM=35F30C205BEFC5EC96890C7BEDEDA12222E80165