using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class SkillManagerComponentC: Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 二段技能 原技能
        /// </summary>
        public Dictionary<int, int> SkillSecond = new Dictionary<int, int>();

        public List<SkillInfo> t_Skills { get; set; } = new();
        public List<EntityRef<SkillC>> Skills = new List<EntityRef<SkillC>>();
        public List<SkillCDItem> SkillCDs = new List<SkillCDItem>(); //冷却时间列表

        public long SkillPublicCDTime { get; set; } //技能公共CD
        public int FangunSkillId { get; set; }
        public long FangunLastTime;

        public long SkillMoveTime { get; set; } = 0; //1旋风斩之类的技能. 可以移动但是需要保持技能动作
        public long SkillSingTime { get; set; } = 0; //吟唱， 移动会打断施法动作

        public bool UpdateCD;

        public long Timer;
    }
}