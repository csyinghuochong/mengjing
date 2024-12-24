
namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class RoleBullet7Componnet : Entity, IAwake, IDestroy
    {
        public long PassTime;
        public long BuffEndTime;
        public long BeginTime;
        public long DelayTime;
        public float DamageRange;
        public long Masterid;
        public BuffState BuffState;
        public long Timer;
        
        private EntityRef<Unit> targetUnit;
        public Unit TargetUnit
        {
            get
            {
                return this.targetUnit;
            }
            set
            {
                this.targetUnit = value;
            }
        }
    }
}