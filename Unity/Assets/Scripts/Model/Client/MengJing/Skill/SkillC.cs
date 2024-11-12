using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{


    [ChildOf(typeof(SkillManagerComponentC))]
    public class SkillC :Entity,IAwake,IDestroy
    {
        public float3 NowPosition { get; set; }
        public SkillState SkillState { get; set; }

        public SkillConfig SkillConf { get; set; }
        public int EffectId { get; set; }

        public bool IsExcuteHurt { get; set; }
        public long SkillExcuteHurtTime { get; set; }
        
        public long SkillShakeCameraTime { get; set; }
        public bool IsCanShakeCamera { get; set; }

        public List<long> EffectInstanceId  { get; set; }= new List<long>();

        private EntityRef<Unit> theUnitFrom;

        /// <summary>
        /// 来自哪个Unit
        /// </summary>
        public Unit TheUnitFrom { get => this.theUnitFrom; set => this.theUnitFrom = value; }

        public SkillInfo SkillInfo { get; set; }
        public float3 TargetPosition { get; set; }
        
    }
}