using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    public static class HappyData
    {
        /// <summary>
        /// 喜从天降道具刷新时间
        /// </summary>
        [StaticField]
        public static long ItemFreshTime = (int)(TimeHelper.Minute * 2f);

        /// <summary>
        /// 2000010场景。 所有格子的位置。 
        /// </summary>
        [StaticField]
        public static List<float3> PositionList = new List<float3>()
        {
            new float3(22.73f, 0.00f, -4.37f),
            new float3(22.73f, 0.00f, -7.37f),
            new float3(22.73f, 0.00f, -10.37f),
            new float3(22.73f, 0.00f, -13.37f),
            new float3(19.78f, 0.00f, -4.37f),
            new float3(19.78f, 0.00f, -4.37f),
            new float3(19.78f, 0.00f, -7.37f),
            new float3(19.78f, 0.00f, -10.37f),
            new float3(19.78f, 0.00f, -13.37f),
        };
    }
}