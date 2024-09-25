/*
 * This file is subject to the terms and conditions defined in
 * file 'README.md', which is part of this source code package.
 */

/*
Texture2D tex, 
Texture2D defaultTex,  
bool useDefaultTex, 
SamplerState texSS, 
float4 uv, 
float2 screenSize, 
float iterations, 
float kernel,  
out float4 color
*/


void KawaseBlur_float(Texture2D tex, Texture2D defaultTex,  bool useDefaultTex, SamplerState texSS, float4 uv, float2 screenSize, float iterations, float kernel,  out float4 color)
{

    

    //distance from current pixel
    float d = 0.0;

    //current weight
    float cw = 0.0;

    float totalWeight = 0.0;

    float px = 1 / screenSize.x;
    float py = 1 / screenSize.y;

    float2 offset =  float2(0,0);

	

    color = float4(0,0,0,1);

	offset = float2(0, 0);
	if (useDefaultTex)
	{
		//color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);


		offset = float2(-1 * iterations, -1 * iterations);
		color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);
		offset = float2(1 * iterations, 1 * iterations);
		color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);
		offset = float2(-1 * iterations, 1 * iterations);
		color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);
		offset = float2(1 * iterations, -1 * iterations);
		color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);


	}
	else
	{
		//color += tex.Sample(texSS, float2(uv.x, uv.y) * offset);
		offset = float2(-1, -1);
		color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);
		offset = float2(-1, 1);
		color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);
		offset = float2(1, 1);
		color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);
		offset = float2(1, -1);
		color += defaultTex.Sample(texSS, float2(uv.x, uv.y) * offset);
	}

	color = color/4.0;

}



