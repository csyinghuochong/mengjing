using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
    [ChildOf(typeof(Unit))]
    public class SkillS:Entity,IAwake,IDestroy
    {
        public List<long> HurtIds = new List<long>();
        public Dictionary<long, long> LastHurtTimes = new Dictionary<long, long>();
        public Dictionary<int, float> TianfuProAdd;

        //1 正在执行   2完成使命
        public SkillState SkillState;

        public SkillConfig SkillConf;

        public long SkillBeginTime;    
        public long SkillEndTime;
        /// <summary>
        /// 记录是否触发过技能伤害
        /// </summary>
        public bool IsExcuteHurt;
        public long SkillExcuteHurtTime;
        public long SkillTriggerInvelTime;      //技能伤害触发间隔时间
        public long SkillTriggerLastTime;
        public long SkillFirstHurtTime;

        /// <summary>
        /// 持续伤害
        /// </summary>
        public long DamgeChiXuLastTime;

        public int SkillExcuteNum;

        public float3 NowPosition;             //当前技能的坐标点
        public float3 TargetPosition;

        public List<SkillParValue_HpUpAct> SkillParValueHpUpAct = new List<SkillParValue_HpUpAct>();        //目标血量处理高或者低 提升自身伤害

        //攻击目标临时增加/降低伤害
        public float ActTargetTemporaryAddPro { get; set; }

        //自身增加/降低伤害
        public float ActTargetAddPro = 0f;

        /// <summary>
        /// 伤害增加系数
        /// </summary>
        public float HurtAddPro = 0f;

        /// <summary>
        /// 来自哪个Unit
        /// </summary>
        public Unit TheUnitFrom { get; set; }

        public Unit TheUnitTarget { get; set; }

        public List<Shape> ICheckShape;

        public SkillInfo SkillInfo{ get; set; }

    }
}