using Unity.Mathematics;

namespace ET.Client
{

    public class Skill_Pull_Monster_2 : SkillHandlerC
    {
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);
           
            if (skils.SkillConf.SkillMoveSpeed == 0f)
            {
                skils.NowPosition = skils.TargetPosition;
            }
            else
            {
                skils.NowPosition = theUnitFrom.Position;
                quaternion rotation = quaternion.Euler(0, math.radians(skils.SkillInfo.TargetAngle), 0); //按照Z轴旋转30度的Quaterion
                float3 movePosition = math.mul(rotation, new float3(0, 0, 1)) * (skils.SkillConf.SkillLiveTime * (float)(skils.SkillConf.SkillMoveSpeed) * 0.001f);
                skils.TargetPosition = skils.NowPosition + movePosition;
            }

            this.OnExecute(skils);
        }

        public override void OnExecute(SkillC skils)
        {
            skils.PlaySkillEffects(skils.NowPosition);
            skils.OnShowSkillIndicator(skils.SkillInfo);
            this.OnUpdate(skils);
        }

        public override void OnUpdate(SkillC skils)
        {
            long serverNow = TimeHelper.ServerNow();
            float passTime = (serverNow - skils.SkillInfo.SkillBeginTime) * 0.001f;
            if (passTime < skils.SkillConf.SkillDelayTime)
            {
                return;
            }

            float3 dir = (skils.TargetPosition - skils.NowPosition).normalize();
            float dis = PositionHelper.Distance2D(skils.TargetPosition, skils.NowPosition);
            float move = (float)skils.SkillConf.SkillMoveSpeed * TimeInfo.Instance.DeltaTime;
            move = math.min(dis, move);

            float3 nowPosition = skils.NowPosition + (move * dir);

            skils.NowPosition = new float3(nowPosition.x, skils.TargetPosition.y + 0.5f, nowPosition.z);

            EventSystem.Instance.Publish(skils.Root(), new SkillEffectMove()
            {
                EffectInstanceId = skils.EffectInstanceId[0],
                Unit = skils.TheUnitFrom,
                Postion = skils.NowPosition,
                Angle = -1
            });

            dis = PositionHelper.Distance2D(skils.NowPosition, skils.TargetPosition);
            if (skils.SkillConf.SkillMoveSpeed > 0f &&  dis < 0.5f  )
            {
                skils.SetSkillState(SkillState.Finished);
            }
            skils.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skils)
        {
            skils.EndSkillEffect();
        }
    }
}
