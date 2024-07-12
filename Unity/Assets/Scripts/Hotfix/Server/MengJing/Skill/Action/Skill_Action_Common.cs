namespace ET.Server
{

    //技能通用类型
    public class Skill_Action_Common : SkillHandlerS
    {
        
        public override void OnInit(SkillS skillS,Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            OnUpdate(skillS, 0);
        }
        
        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            skillS.BaseOnUpdate();
            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
        
    }
}
