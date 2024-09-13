using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    public struct MoveStart
    {
        public Unit Unit;
        public List<float3> targes;
    }

    public struct MoveStop
    {
        public Unit Unit;
    }
}