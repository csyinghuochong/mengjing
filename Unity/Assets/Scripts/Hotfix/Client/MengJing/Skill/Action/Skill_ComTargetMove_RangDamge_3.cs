namespace ET.Client
{

    /// <summary>
    /// 多条裂地斩
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_3 : SkillHandlerC
    {
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);

            this.OnExecute(skils);
        }

        public override void OnExecute(SkillC skils)
        {
            string[] paraminfos = skils.SkillConf.GameObjectParameter.Split(';');
            int angle = skils.SkillInfo.TargetAngle;
            int range = paraminfos.Length > 1 ? int.Parse(paraminfos[0]) : 0;
            int number = paraminfos.Length > 1 ? int.Parse(paraminfos[1]) : 1;
            int delta = number > 1 ? range / (number - 1) : 0;
            int starAngle = angle - (int)(range * 0.5f);

            for (int i = 0; i < number; i++)
            {
                skils.PlaySkillEffects(skils.TargetPosition, starAngle + i * delta);
                SkillInfo skillInfo = CommonHelp.DeepCopy<SkillInfo>(skils.SkillInfo);
                skillInfo.TargetAngle = starAngle + i * delta;
                skils.OnShowSkillIndicator(skillInfo);
            }

            this.OnUpdate(skils);
        }

        public override void OnUpdate(SkillC skils)
        {
            skils.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skils)
        {
            skils.EndSkillEffect();
        }
    }
}