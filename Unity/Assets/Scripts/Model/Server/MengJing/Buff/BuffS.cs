using Unity.Mathematics;

namespace ET.Server
{
    
    [ChildOf(typeof(BuffManagerComponentS))]
    public class BuffS:Entity,IAwake,  IDestroy
    {
        /// <summary>
        /// Buff当前状态
        /// </summary>
        public BuffState BuffState;

        /// <summary>
        /// 最多持续到什么时候
        /// </summary>
        public long BuffEndTime;

        /// <summary>
        /// Buff数据
        /// </summary>
        public BuffData BuffData;

        public SkillBuffConfig mBuffConfig;
        public SkillConfig mSkillConf;
        public SkillS mSkillHandler { get; set; }

        /// <summary>
        /// 来自哪个Unit
        /// </summary>
        public Unit TheUnitFrom { get; set; }

        /// <summary>
        /// 寄生于哪个Unit，并不代表当前Buff实际寄居者，需要通过GetBuffTarget来获取，因为它赋值于Buff链起源的地方，具体值取决于那个起源Buff
        /// </summary>
        public Unit TheUnitBelongto { get; set; }

        public bool IsTrigger;
        public long DelayTime;
        public long BeginTime;
        public long PassTime;

        public float3 StartPosition;
        public float3 TargetPosition;

        public long InterValTime;
        public long InterValTimeBegin;

        public float NowBuffValue;
    }
    
}