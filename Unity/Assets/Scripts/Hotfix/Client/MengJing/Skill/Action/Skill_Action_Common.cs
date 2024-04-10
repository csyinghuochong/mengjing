namespace ET.Client
{
    
    public class Skill_Action_Common : SkillHandlerC
    {
     
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);
            this.OnExecute(skils);

            if (theUnitFrom.MainHero && skils.SkillConf.SkillType == 1 && SkillHelp.havePassiveSkillType(skils.SkillConf.PassiveSkillType, 1))
            {
                EventSystem.Instance.Publish(skils.Root(), new SkillBeging()
                {
                    SkillId =  skils.SkillConf.Id
                });
            }
        }

        public override void OnExecute(SkillC skils)
        {
            skils.PlaySkillEffects(skils.TargetPosition);
            skils.OnShowSkillIndicator(skils.SkillInfo);
            this.OnUpdate(skils);
        }

        public override void OnUpdate(SkillC skils)
        {
            skils.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skils)
        {
            if (skils.TheUnitFrom.MainHero && skils.SkillConf.SkillType == 1 && SkillHelp.havePassiveSkillType(skils.SkillConf.PassiveSkillType, 1))
            {
                EventSystem.Instance.Publish(skils.Root(), new SkillFinish()
                {
                    SkillId =  skils.SkillConf.Id
                });
            }

            skils.EndSkillEffect();
            skils.SkillInfo = null;
        }
    }
}
