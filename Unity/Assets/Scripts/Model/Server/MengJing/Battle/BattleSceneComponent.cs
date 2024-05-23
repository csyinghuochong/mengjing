using System.Collections.Generic;

namespace ET.Server
{
    
    [ChildOf]
    public class BattleInfo : Entity, IAwake
    {
        public int SceneId { get; set; } = 0;
        public long FubenId { get; set; }= 0;
        public int PlayerNumber { get; set; }= 0;
        public long ProgressId { get; set; }= 0;
        public long FubenInstanceId { get; set; }= 0;
        
        public ActorId ActorId { get; set; };

        public List<long> Camp1Player{ get; set; } = new List<long>();
        public List<long> Camp2Player{ get; set; } = new List<long>();
    }
    
    [ComponentOf(typeof(Scene))]
    public class BattleSceneComponent: Entity, IAwake, IDestroy
    {
        public bool BattleOpen;
        public List<BattleInfo> BattleInfos { get; set; } = new List<BattleInfo>();
    }
    
}
