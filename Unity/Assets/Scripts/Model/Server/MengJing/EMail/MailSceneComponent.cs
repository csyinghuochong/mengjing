namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class MailSceneComponent: Entity, IAwake
    {
        public long Timer;

        public DBServerMailInfo dBServerMailInfo { get; set; } = null;
    }
    
}

