using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    public static class AIData
    {
        //己方位置
        [StaticField]
        public static readonly List<float3> Formation_1 = new List<float3>()
        {
            //前排
            new float3(-1.88f, 0f, -9.11f),
            new float3(1.17f, 0f, -9.11f),
            new float3(4.28f, 0f, -9.11f),
            //中排
            new float3(-1.88f, 0f, -12.16f),
            new float3(1.17f, 0f, -12.16f),
            new float3(4.28f, 0f, -12.16f),
            //后排
            new float3(-1.88f, 0f, -15.33f),
            new float3(1.17f, 0f, -15.33f),
            new float3(4.28f, 0f, -15.33f),

        };

        //对方位置
        [StaticField]
        public static readonly List<float3> Formation_2 = new List<float3>()
        {
            //前排
            new float3(-1.88f, 0f, 9.87f),
            new float3(1.17f, 0f, 9.87f),
            new float3(4.28f, 0f, 9.87f),
            //中排
            new float3(-1.88f, 0f, 13.09f),
            new float3(1.17f, 0f, 13.09f),
            new float3(4.28f, 0f, 13.09f),
            //后排
            new float3(-1.88f, 0f,16.14f),
            new float3(1.17f, 0f, 16.14f),
            new float3(4.28f, 0f, 16.14f),
        };


        /// <summary>
        /// 每个格子对应的搜索顺序
        /// </summary>
        [StaticField]
        public static readonly List<int>[] PetPositionAttack = new List<int>[]
        {
            /*
            new List<int>(){ 0, 3, 6, 1, 4, 7, 2, 5, 8 },
            new List<int>(){ 1, 4, 7, 0, 3, 6, 2, 5, 8 },
            new List<int>(){ 2, 5, 8, 1, 4, 7, 0, 3, 6 },
            new List<int>(){ 0, 3, 6, 1, 4, 7, 2, 5, 8 },
            new List<int>(){ 1, 4, 7, 0, 3, 6, 2, 5, 8 },
            new List<int>(){ 2, 5, 8, 1, 4, 7, 0, 3, 6 },
            new List<int>(){ 0, 3, 6, 1, 4, 7, 2, 5, 8 },
            new List<int>(){ 1, 4, 7, 0, 3, 6, 2, 5, 8 },
            new List<int>(){ 2, 5, 8, 1, 4, 7, 0, 3, 6 }
            */

            new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7, 8 },
            new List<int>(){ 1, 0, 2, 4, 3, 5, 7, 6, 8 },
            new List<int>(){ 2, 1, 0, 5, 4, 3, 8, 7, 6 },
            new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7, 8 },
            new List<int>(){ 1, 0, 2, 4, 3, 5, 7, 6, 8 },
            new List<int>(){ 2, 1, 0, 5, 4, 3, 8, 7, 6 },
            new List<int>(){ 0, 1, 2, 3, 4, 5, 6, 7, 8 },
            new List<int>(){ 1, 0, 2, 4, 3, 5, 7, 6, 8 },
            new List<int>(){ 2, 1, 0, 5, 4, 3, 8, 7, 6 }

        };
        
    }
}