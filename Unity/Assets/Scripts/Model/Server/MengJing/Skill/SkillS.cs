using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
    [ChildOf(typeof(SkillManagerComponentS))]
    public class SkillS:Entity,IAwake,IDestroy
    {
        public List<long> HurtIds { get; set; }= new List<long>();
        public Dictionary<long, long> LastHurtTimes{ get; set; }=  new Dictionary<long, long>();
        public Dictionary<int, float> TianfuProAdd;

        //1 正在执行   2完成使命
        public SkillState SkillState;

        public SkillConfig SkillConf { get; set; }

        public List<long> OnlyOnceBuffUnitID = new List<long>();

        public long SkillBeginTime{ get; set; }
        public long SkillEndTime{ get; set; }
        /// <summary>
        /// 记录是否触发过技能伤害
        /// </summary>
        public bool IsExcuteHurt{ get; set; }
        public long SkillExcuteHurtTime{ get; set; }
        public long SkillTriggerInvelTime{ get; set; }      //技能伤害触发间隔时间
        public long SkillTriggerLastTime{ get; set; }
        public long SkillFirstHurtTime{ get; set; }

        /// <summary>
        /// 持续伤害
        /// </summary>
        public long DamgeChiXuLastTime{ get; set; }

        public int SkillExcuteNum{ get; set; }

        public float3 NowPosition { get; set; } = 0f;             //当前技能的坐标点
        public float3 TargetPosition { get; set; } = 0f;

        public List<SkillParValue_HpUpAct> SkillParValueHpUpAct = new List<SkillParValue_HpUpAct>();        //目标血量处理高或者低 提升自身伤害

        //攻击目标临时增加/降低伤害
        public float ActTargetTemporaryAddPro { get; set; }

        //自身增加/降低伤害
        public float ActTargetAddPro { get; set; } = 0f;

        /// <summary>
        /// 伤害增加系数
        /// </summary>
        public float HurtAddPro { get; set; } = 0f;

        /// <summary>
        /// 来自哪个Unit
        /// </summary>
        public Unit TheUnitFrom { get; set; }

        public Unit TheUnitTarget { get; set; }

        public List<Shape> ICheckShape  { get; set; }

        public SkillInfo SkillInfo{ get; set; }

        public bool Return{ get; set; }
        public Unit BulletUnit{ get; set; }
        
        public int isChonFeng{ get; set; }
        public float SpeedAddValue { get; set; }= 0f;

        public long MoveTime{ get; set; } = 0;
        public int IsStop{ get; set; } = 0;
        
        public List<long> ComboTimeList { get; set; } = new List<long>();

        public int TriggeSkillId { get; set; }

    }
}