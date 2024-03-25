using System.Collections.Generic;


namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class SkillManagerComponentS: Entity, IAwake, IDestroy
    {
        public List<SkillHandler> Skills = new List<SkillHandler>();
        public List<SkillInfo> DelaySkillList = new List<SkillInfo>();
        public Dictionary<int, SkillCDItem> SkillCDs = new Dictionary<int, SkillCDItem>();  //技能CD列表
        public Dictionary<int, int> SkillSecond = new Dictionary<int, int>();      
        public long SkillPublicCDTime;      //公共CD
        public int FangunComboNumber;
        public long FangunLastTime;
        public int FangunSkillId;
        public long LastLianJiTime = 0;
        public long Timer;

        public M2C_SkillCmd M2C_SkillCmd = new M2C_SkillCmd();
        public M2C_UnitFinishSkill M2C_UnitFinishSkill = new M2C_UnitFinishSkill();
        public UnitComponent SelfUnitComponent{ set; get; }
        public Unit SelfUnit { set; get; }
    }
}