namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class TrialDungeonComponent : Entity, IAwake
    {
        public long BeginTime;
        public long HurtValue;
    }
}
