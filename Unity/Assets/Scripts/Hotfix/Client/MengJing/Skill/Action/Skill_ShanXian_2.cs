namespace ET.Client
{
    //闪现(怪物技能)
    public class Skill_ShanXian_2 : SkillHandlerC
    {
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);

            this.OnExecute(skils);
        }

        public override void OnExecute(SkillC skils)
        {
            //更新位置
            if (skils.SkillConf.GameObjectParameter == "0")
            {
                //先跳过去再触发伤害
                skils.PlaySkillEffects(skils.TargetPosition);
            }
            else
            {
                skils.PlaySkillEffects(skils.TheUnitFrom.Position);
            }

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
