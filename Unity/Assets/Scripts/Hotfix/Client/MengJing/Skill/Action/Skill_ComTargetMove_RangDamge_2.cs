namespace ET.Client
{

    //子弹2
    public class Skill_ComTargetMove_RangDamge_2 : SkillHandlerC
    {

        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);

            this.OnExecute(skils);
        }

        public override void OnExecute(SkillC skils)
        {
            skils.OnShowSkillIndicator(skils.SkillInfo);
            this.OnUpdate(skils);
        }

        public override void OnUpdate(SkillC skils)
        {
            skils.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skils)
        {
            
        }
    }
}
