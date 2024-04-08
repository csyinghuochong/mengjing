using Unity.Mathematics;

namespace ET.Server
{
    
    [ChildOf(typeof(BuffManagerComponentS))]
    public class BuffS:Entity,IAwake,  IDestroy
    {
        /// <summary>
        /// Buff当前状态
        /// </summary>
        public BuffState BuffState { get; set; }

        /// <summary>
        /// 最多持续到什么时候
        /// </summary>
        public long BuffEndTime { get; set; }

        /// <summary>
        /// Buff数据
        /// </summary>
        public BuffData BuffData{ get; set; }

        public SkillBuffConfig mBuffConfig{ get; set; }
        public SkillConfig mSkillConf{ get; set; }
        public SkillS mSkillHandler { get; set; }

        /// <summary>
        /// 来自哪个Unit
        /// </summary>
        public Unit TheUnitFrom { get; set; }

        /// <summary>
        /// 寄生于哪个Unit，并不代表当前Buff实际寄居者，需要通过GetBuffTarget来获取，因为它赋值于Buff链起源的地方，具体值取决于那个起源Buff
        /// </summary>
        public Unit TheUnitBelongto { get; set; }

        public bool IsTrigger{ get; set; }
        public long DelayTime{ get; set; }
        public long BeginTime{ get; set; }
        public long PassTime{ get; set; }

        public float3 StartPosition{ get; set; }
        public float3 TargetPosition{ get; set; }

        public long InterValTime{ get; set; }
        public long InterValTimeBegin{ get; set; }

        public float NowBuffValue{ get; set; }
    }
    
}