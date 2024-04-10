namespace ET.Client
{
    
    public class Skill_Action_Common : SkillHandlerC
    {
     
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);
            this.OnExecute();

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

        public override void OnFinished()
        {
            if (this.TheUnitFrom.MainHero && this.SkillConf.SkillType == 1 && SkillHelp.havePassiveSkillType(this.SkillConf.PassiveSkillType, 1))
            {
                EventType.DataUpdate.Instance.DataType = DataType.SkillFinish;
                EventType.DataUpdate.Instance.DataParamString = this.SkillConf.Id.ToString();
                EventSystem.Instance.PublishClass(EventType.DataUpdate.Instance);
            }

            this.EndSkillEffect();
            this.SkillInfo = null;
        }
    }
}
