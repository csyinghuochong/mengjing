using UnityEngine;

namespace ET.Client
{
    
    [ChildOf(typeof(EffectViewComponent))]
    public class Effect : Entity, IAwake
    {
        /// <summary>
        /// Buff当前状态
        /// </summary>
        public BuffState EffectState;

        public EffectConfig EffectConfig;

        /// <summary>
        /// Buff数据
        /// </summary>
        public EffectData EffectData;

        /// <summary>
        /// 寄生于哪个Unit，并不代表当前Buff实际寄居者，需要通过GetBuffTarget来获取，因为它赋值于Buff链起源的地方，具体值取决于那个起源Buff
        /// </summary>
        public Unit TheUnitBelongto { get; set; }

        /// <summary>
        /// 最多持续到什么时候
        /// </summary>
        public long EffectEndTime;


        public float HideObjTime;          //隐藏物体间隔时间    

        public GameObject EffectObj;
        public string EffectPath;
    }
}

