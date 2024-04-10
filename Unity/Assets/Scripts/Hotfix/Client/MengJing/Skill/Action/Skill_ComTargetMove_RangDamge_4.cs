namespace ET.Client
{
    //全地图随机子弹
    public class Skill_ComTargetMove_RangDamge_4 : SkillHandlerC
    {
        
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);

            this.OnExecute(skils);
        }

        public override void OnExecute(SkillC skils)
        {
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