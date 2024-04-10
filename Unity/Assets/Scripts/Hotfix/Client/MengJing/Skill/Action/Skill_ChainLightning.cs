namespace ET.Client
{
    
    public class Skill_ChainLightning : Skill_Action_Common
    {
        public override void OnExecute(SkillC skils)
        {
            skils.BaseOnUpdate();
        }
    }
}
