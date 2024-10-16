using System.Collections.Generic;

namespace ET.Server
{
    public class RoleBullet1Componnet : Entity, IAwake, IDestroy
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
        public long DamgeChiXuLastTime;
    }
}