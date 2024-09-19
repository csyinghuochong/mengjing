namespace ET.Client
{
    //子弹1
    public class Skill_ComTargetMove_RangDamge_1 : SkillHandlerC
    {

        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);

            this.OnExecute(skils);
        }

        private void PlayBullet_1(SkillC skils)
        {
            string[] paraminfos = skils.SkillConf.GameObjectParameter.Split(';');
            int angle = skils.SkillInfo.TargetAngle;
            int range = paraminfos.Length > 1 ?  int.Parse(paraminfos[0]) : 0;
            int number = paraminfos.Length > 1 ? int.Parse(paraminfos[1]) : 1;
            int delta = number > 1 ?  range / (number - 1) : 0;
            int starAngle = angle - (int)(range * 0.5f);

            for (int i = 0; i < number; i++ )
            {
                SkillInfo skillInfo = CommonHelp.DeepCopy<SkillInfo>(skils.SkillInfo);
                skillInfo.TargetAngle = starAngle + i * delta;
                skils.OnShowSkillIndicator(skillInfo);
            }
        }
        
        public override void OnExecute(SkillC skils)
        {
            this.PlayBullet_1(skils);     //播放特效
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
