using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    
    [ChildOf(typeof(EffectViewComponent))]
    public class Effect : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// Buff当前状态
        /// </summary>
        public BuffState EffectState { get; set; }

        public EffectConfig EffectConfig { get; set; }

        /// <summary>
        /// Buff数据
        /// </summary>
        public EffectData EffectData { get; set; }

        private EntityRef<Unit> theUnitBelongto;

        /// <summary>
        /// 寄生于哪个Unit，并不代表当前Buff实际寄居者，需要通过GetBuffTarget来获取，因为它赋值于Buff链起源的地方，具体值取决于那个起源Buff
        /// </summary>
        public Unit TheUnitBelongto { get => this.theUnitBelongto; set => this.theUnitBelongto = value; }

        /// <summary>
        /// 最多持续到什么时候
        /// </summary>
        public long EffectEndTime;
        
        public long EffectBeginTime { get; set; }

        public float HideObjTime;          //隐藏物体间隔时间    

        public GameObject EffectObj { get; set; }
        public string EffectPath;
        
        public float3 EffectPosition;
        public float EffectAngle;
    }
}

