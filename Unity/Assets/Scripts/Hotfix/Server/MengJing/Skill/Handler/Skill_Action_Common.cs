namespace ET.Server
{

    //技能通用类型
    public class Skill_Action_Common : SkillHandlerS
    {
        
        public override void OnInit(SkillS skillS, SkillInfo skillInfo, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            skillS.OnUpdate();
        }
        
        public override void OnUpdate(SkillS skillS)
        {
            skillS.BaseOnUpdate();
            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }

        public override void Check_Map(SkillS skillS)
        {
            
        }
    }
}
