namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class DemonDungeonComponent: Entity, IAwake, IDestroy
    {
        public bool IsOver;

        public M2C_RankDemonMessage M2C_RankDemonMessage = M2C_RankDemonMessage.Create();
    }
    
}

