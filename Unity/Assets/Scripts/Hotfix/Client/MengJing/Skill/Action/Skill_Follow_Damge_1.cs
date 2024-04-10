
namespace ET.Client
{

    //召唤
    public class Skill_Follow_Damge_1 : Skill_Action_Common
    { 
        public override void OnExecute(SkillC skillC)
        {
            skillC.OnShowSkillIndicator(skillC.SkillInfo);
            this.OnUpdate(skillC);
        }
    }
}
