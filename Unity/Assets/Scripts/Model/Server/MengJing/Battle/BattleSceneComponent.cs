using System.Collections.Generic;

namespace ET.Server
{
    
    public class BattleInfo : Entity, IAwake
    {
        public int SceneId = 0;
        public long FubenId = 0;
        public int PlayerNumber = 0;
        public long ProgressId = 0;
        public long FubenInstanceId = 0;

        public List<long> Camp1Player = new List<long>();
        public List<long> Camp2Player = new List<long>();
    }
    
    [ComponentOf(typeof(Scene))]
    public class BattleSceneComponent: Entity, IAwake, IDestroy
    {
        public bool BattleOpen;
        public List<BattleInfo> BattleInfos = new List<BattleInfo>();
    }
    
}
