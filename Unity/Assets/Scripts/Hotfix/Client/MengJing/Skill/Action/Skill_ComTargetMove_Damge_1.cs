using Unity.Mathematics;

namespace ET.Client
{
    //指定目标攻击
    public class Skill_ComTargetMove_Damge_1 : SkillHandlerC
    {
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);
            float3 nowPosition = new float3(theUnitFrom.Position.x,
                theUnitFrom.Position.y + SkillHelp.GetCenterHigh(theUnitFrom.Type, theUnitFrom.ConfigId),
                theUnitFrom.Position.z);
            skils.NowPosition = nowPosition;

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
            long serverNow = TimeHelper.ServerNow();
            float passTime = (serverNow - skils.SkillInfo.SkillBeginTime) * 0.001f;
            if (passTime < skils.SkillConf.SkillDelayTime)
            {
                return;
            }

            Unit targetUnit = skils.TheUnitFrom.GetParent<UnitComponent>().Get(skils.SkillInfo.TargetID);
            if (targetUnit != null)
            {
                float3 targetPosition = new float3(targetUnit.Position.x,
                    targetUnit.Position.y + SkillHelp.GetCenterHigh(targetUnit.Type, targetUnit.ConfigId),
                    targetUnit.Position.z);
                skils.TargetPosition = targetPosition;
            }

            float3 dir = (skils.TargetPosition - skils.NowPosition).normalize();
            float effectAngle = math.degrees(math.atan2(dir.x, dir.z));
            if (skils.EffectInstanceId.Count == 0)
            {
                //Vector3 newestPositon = this.TheUnitFrom.Position;
                //newestPositon.y = this.TheUnitFrom.Position.y + SkillHelp.GetCenterHigh(this.TheUnitFrom.Type, this.TheUnitFrom.ConfigId);
                //float effectAngle = 0;
                //if (Vector3.Distance(newestPositon, this.NowPosition) > 0.2f)
                //{
                //    // 位置预测
                //    Vector3 dire = newestPositon - this.NowPosition;
                //    this.NowPosition += dire * 4.2f;

                //    // 角度,后面更新位置的时候也可以更新一下角度,这样看起来箭不是斜着射过去的，因为目标是移动的，箭的角度不变
                //    Vector3 dire2 = (this.TargetPosition - this.NowPosition).normalized;
                //    effectAngle = Mathf.Atan2(dire2.x, dire2.z) * 180 / 3.141592653589793f;
                //}
                //this.PlaySkillEffects(this.NowPosition, effectAngle);
                skils.PlaySkillEffects(skils.NowPosition, effectAngle);
            }

            float dis = PositionHelper.Distance2D(skils.TargetPosition, skils.NowPosition);
            float move = (float)skils.SkillConf.SkillMoveSpeed * TimeInfo.Instance.DeltaTime ; //Time.deltaTime

            move = math.min(dis, move);
            skils.NowPosition = skils.NowPosition + (move * dir);

            if (skils.EffectId != 0)
            {
                EventSystem.Instance.Publish(skils.Root(), new SkillEffectMove()
                {
                    EffectInstanceId = skils.EffectInstanceId[0],
                    Unit = skils.TheUnitFrom,
                    Postion = skils.NowPosition,
                    Angle = effectAngle
                });
            }

            dis = PositionHelper.Distance2D(skils.NowPosition, skils.TargetPosition);
            if (dis < 0.5f || passTime > 20f)
            {
                skils.SetSkillState(SkillState.Finished);
            }
        }

        public override void OnFinished(SkillC skils)
        {
            skils.EndSkillEffect();
        }
    }
}