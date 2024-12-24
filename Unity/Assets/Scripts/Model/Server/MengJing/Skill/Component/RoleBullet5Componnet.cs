namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class RoleBullet5Componnet : Entity, IAwake, IDestroy
    {
        public long PassTime;
        public long BuffEndTime;
        public long BeginTime;
        public long DelayTime;
        public float DamageRange;
        public long Masterid;
        public EntityRef<SkillS> SkillS;
        public BuffState BuffState;
        public long Timer;
    }
}