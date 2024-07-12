namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class ArenaDungeonComponent : Entity, IAwake, IDestroy
    {
        public bool ArenaClose = false;
        public BattleInfo ArenaInfo { get; set; }
        public M2C_AreneInfoResult M2C_AreneInfoResult = M2C_AreneInfoResult.Create();
    }
    
}