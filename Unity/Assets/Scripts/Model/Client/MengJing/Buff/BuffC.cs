using Unity.Mathematics;

namespace ET.Client
{
    
    
    [ChildOf(typeof(BuffManagerComponentC))]
    public class BuffC : Entity, IAwake
    {
        /// <summary>
        /// Buff当前状态
        /// </summary>
        public BuffState BuffState { get; set;}

        /// <summary>
        /// 最多持续到什么时候
        /// </summary>
        public long BuffEndTime;

        public long BuffBeginTime;

        /// <summary>
        /// Buff数据
        /// </summary>
        public BuffData BuffData { get; set; }

        public EffectData EffectData { get; set; }

        /// <summary>
        /// 寄生于哪个Unit，并不代表当前Buff实际寄居者，需要通过GetBuffTarget来获取，因为它赋值于Buff链起源的地方，具体值取决于那个起源Buff
        /// </summary>
        public Unit TheUnitBelongto { get; set; }

        /// <summary>
        /// 执行的时间
        /// </summary>
        public float PassTime;
        public float3 StartPosition;

        public SkillConfig mSkillConf;
        public EffectConfig mEffectConf;
        public SkillBuffConfig mSkillBuffConf{ get; set; }
        
        public float mDelayTime{ get; set; }
        public bool IsDelayPlay{ get; set; }
        public long EffectInstanceId{ get; set; }
        public float mAngle{ get; set; }
        public float startAngle{ get; set; }
        public float mRadius{ get; set; }
    }
    
}