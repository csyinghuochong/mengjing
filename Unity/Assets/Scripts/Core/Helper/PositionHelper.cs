using Unity.Mathematics;

namespace ET
{
	public static class PositionHelper
	{
		public static float3 RayCastV2ToV3(float2 pos)
		{
            return new float3(pos.x, 0, pos.y);
		}

		public static float3 RayCastXYToV3(float x, float y)
        {
			return new float3(x, 0, y);
		}

		public static float3 RayCastV3ToV3(float3 pos)
		{
			return new float3(pos.x, 0, pos.z);
		}
		
        public static float Distance2D(float3 u1, float3 u2)
        {
	        float xx = (u1.x - u2.x);
	        float zz = (u1.z - u2.z);
            return math.sqrt(xx * xx + zz * zz);
        }
	}
}