using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class ArenaInfo : Entity, IAwake
    {
        public long FubenId { get; set; } = 0;
        public long FubenInstanceId { get; set; } = 0;
        public int SceneId { get; set; } = 0;

        public Dictionary<long, ArenaPlayerStatu> PlayerList { get; set; } = new Dictionary<long, ArenaPlayerStatu>();
    }

    public struct ArenaPlayerStatu
    {
        public int States;   //0关闭之后离开  1关闭之后离开  2 结束时还在
        public int KillNumber;
        public int RankId;
        public long UnitId;
    }
    
    [ComponentOf(typeof(Scene))]
    public class ArenaSceneComponent:        Entity, IAwake, IDestroy
    {
        public long Timer;

        public int AreneSceneStatu;

        public bool CanEnter;
    }
}

