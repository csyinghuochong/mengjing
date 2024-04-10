namespace ET.Client
{
    //闪现(玩家技能)
    public class Skill_ShanXian_1 : SkillHandlerC
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
                //TheUnitFrom.Position = TargetPosition;
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
            long serverNow = TimeHelper.ServerNow();
            if (skils.SkillConf.GameObjectParameter == "1" && skils.IsExcuteHurt && serverNow >= skils.SkillExcuteHurtTime)
            {
                //先跳过去再触发伤害
                //TheUnitFrom.Position = TargetPosition;
            }
            skils.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skils)
        {

        }
    }
}
