namespace ET.Client
{

    /// <summary>
    /// 立即对目标释放一个燃烧种子造成120%伤害,并持续燃烧对附近单位每秒造成70%伤害,持续5秒
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_7: SkillHandlerC
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