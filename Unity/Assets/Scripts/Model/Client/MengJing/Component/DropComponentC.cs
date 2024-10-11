namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class DropComponentC : Entity, IAwake
    {
        public long OwnerId;
        public long ProtectTime;
    }
}