using System.Collections.Generic;

namespace ET.Server
{
    
    
    public struct RefreshMonster
    {
        public int MonsterId;
        public float PositionX;
        public float PositionY;
        public float PositionZ;
        public long NextTime;
        public float Range;
        public int Number;
        public long Interval;    //-1只刷新一次
        public int Rotation;
    }

    [ComponentOf(typeof(Scene))]
    public class YeWaiRefreshComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
        public int SceneId { get; set; }
        public int RandomTime;
        public List<RefreshMonster> RefreshMonsters = new List<RefreshMonster>();

        public bool LogTest;
    }
    
}