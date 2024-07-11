namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class HappyDungeonComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
        public M2C_HappyInfoResult M2C_HappyInfoResult = M2C_HappyInfoResult.Create();
    }
    
}