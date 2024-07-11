namespace ET.Client
{
    
    [ComponentOf(typeof(Unit))]
    public class SingingComponent: Entity, IAwake,IDestroy
    {
        public long Timer;

        public int Type = 0;
        public long PassTime;
        public long TotalTime;
        public long BeginTime;

        public long EffectInstanceId;

        public C2M_SkillCmd c2M_SkillCmd = C2M_SkillCmd.Create();
    }
}