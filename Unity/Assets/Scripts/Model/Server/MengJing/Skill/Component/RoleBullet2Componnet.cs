using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class RoleBullet2Componnet : Entity, IAwake, IDestroy
    {
        public long BeginTime;
        public long PassTime;
        public long DelayTime;
        public long BuffEndTime;
        public float StartAngle;
        public float Angle;
        public float Radius;
        public float DamageRange;
        public long Timer;
        public long MasterId;
        public BuffState BuffState;
        public EntityRef<Unit> TheUnitBelongto;
        public long InterValTimeSum;
        public float3 StartPosition;
        public EntityRef<SkillS> SkillS;
        public List<long> HurtIds = new List<long>();
    }
}