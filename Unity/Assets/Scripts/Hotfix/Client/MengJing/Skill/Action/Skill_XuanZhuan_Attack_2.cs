using Unity.Mathematics;

namespace ET.Client
{
    
    public class Skill_XuanZhuan_Attack_2 : Skill_Action_Common
    {
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);

            this.OnExecute(skils);
        }

        public override void OnExecute(SkillC skils)
        {
            int angle = skils.SkillInfo.TargetAngle;
            skils.PlaySkillEffects( skils.TheUnitFrom.Position, angle );

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
            float angle = MathHelper.QuaternionToEulerAngle_Y(skils.TheUnitFrom.Rotation.value);

            for (int i = 0; i < skils.EffectInstanceId.Count; i++)
            {
                EventSystem.Instance.Publish(skils.Root(), new SkillEffectMove()
                {
                    Postion = skils.TargetPosition,
                    Unit = skils.TheUnitFrom,
                    Angle = angle,
                    EffectInstanceId = skils.EffectInstanceId[0],
                });
            }

            skils.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skils)
        {
            skils.EndSkillEffect();
        }
    }
}
