using System.Collections.Generic;
using System.Numerics;

namespace ET.Client
{


    [ChildOf(typeof(SkillManagerComponentC))]
    public abstract class SkillC :Entity,IAwake,IDestroy
    {
        public Vector3 NowPosition;
        public SkillState SkillState;

        public SkillConfig SkillConf;
        public int EffectId;

        public bool IsExcuteHurt;
        public long SkillExcuteHurtTime;

        public List<long> EffectInstanceId = new List<long>();

        /// <summary>
        /// 来自哪个Unit
        /// </summary>
        public Unit TheUnitFrom { get; set; }

        public SkillInfo SkillInfo;
        public Vector3 TargetPosition;
        
    }
}