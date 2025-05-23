using System;

namespace ET
{
    [EnableClass]
    public class NoMemoryCheck: Attribute
    {
    }
    
    [ComponentOf(typeof(Unit))]
    /// <summary>
    /// 同一块地图可能有多种寻路数据，玩家可以随时切换，怪物也可能跟玩家的寻路不一样，寻路组件应该挂在Unit上
    /// </summary>
    public class ET6PathfindingComponent: Entity, IAwake<int>, IDestroy
    {
        
        [StaticField]
        public static int FindRandomNavPosMaxRadius = 15000;  // 随机找寻路点的最大半径

        [StaticField]
        public static float[] extents = {15, 10, 15};

        public string Name;

        public long NavMesh;

        [NoMemoryCheck]
        public float[] StartPos = new float[3];

        [NoMemoryCheck]
        public float[] EndPos = new float[3];

        //[NoMemoryCheck]
        //public float[] Result = new float[Recast.MAX_POLYS * 3];
    }
    
}