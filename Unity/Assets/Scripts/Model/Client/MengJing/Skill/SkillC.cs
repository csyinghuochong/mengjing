using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;

namespace ET.Client
{


    [ChildOf(typeof(SkillManagerComponentC))]
    public abstract class SkillC :Entity,IAwake,IDestroy
    {
        public float3 NowPosition;
        public SkillState SkillState;

        public SkillConfig SkillConf { get; set; }
        public int EffectId;

        public bool IsExcuteHurt;
        public long SkillExcuteHurtTime;

        public List<long> EffectInstanceId = new List<long>();

        /// <summary>
        /// 来自哪个Unit
        /// </summary>
        public Unit TheUnitFrom { get; set; }

        public SkillInfo SkillInfo;
        public float3 TargetPosition;
        
    }
}