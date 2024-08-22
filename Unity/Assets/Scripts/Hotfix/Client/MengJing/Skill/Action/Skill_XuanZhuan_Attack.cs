using Unity.Mathematics;

namespace ET.Client
{
    
    public class Skill_XuanZhuan_Attack : Skill_Action_Common
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
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < skils.SkillExcuteHurtTime)
            {
                return;
            }

            string[] paraminfos = skils.SkillConf.GameObjectParameter.Split(';');
            int angle = skils.SkillInfo.TargetAngle;
            int speed = paraminfos.Length > 1 ? int.Parse(paraminfos[0]) : 0;   //每秒转多少角度
            int number = paraminfos.Length > 1 ? int.Parse(paraminfos[1]) : 1;
            //两条线的间隔
            int delta = 0;
            int starAngle = angle;
            if (number > 1)
            {
                delta = (int)math.floor(360f / number);
                starAngle = angle - 180;
            }
            long passTime = (serverNow - skils.SkillInfo.SkillBeginTime);
            int addrangle = (int)(passTime * speed * 0.001f);

            for (int i = 0; i < skils.EffectInstanceId.Count; i++)
            {
                EventSystem.Instance.Publish(skils.Root(), new SkillEffectMove()
                {
                    Postion = skils.TargetPosition,
                    Unit = skils.TheUnitFrom,
                    Angle = starAngle + i * delta + addrangle,
                    EffectInstanceId = skils.EffectInstanceId[i]
                });
                
            }

            skils.TheUnitFrom.Rotation = quaternion.Euler(0, math.radians(angle + addrangle), 0);
            skils.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skils)
        {
            skils.EndSkillEffect();
        }
    }
}
