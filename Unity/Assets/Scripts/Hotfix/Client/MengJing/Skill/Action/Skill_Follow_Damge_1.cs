namespace ET
{

    //范围轰炸
    [SkillHandler]
    public class Skill_Follow_Damge_1 : Skill_Action_Common
    {
        public override void OnExecute()
        {
            this.OnShowSkillIndicator(this.SkillInfo);
            this.OnUpdate();
        }
    }
}