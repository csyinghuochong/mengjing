using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 回旋子弹
    /// </summary>
    public class Skill_Boomerang : SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            skillS.Return = false;
        }

        public override void OnExecute(SkillS skillS)
        {
            int angle = skillS.SkillInfo.TargetAngle;
            float3 sourcePoint = skillS.TheUnitFrom.Position;
            quaternion rotation = quaternion.Euler(0, math.radians(angle), 0);
            float3 TargetPoint = sourcePoint + math.mul(rotation, new float3(0, 0, 1)) * skillS.SkillConf.SkillLiveTime *
                    (float)skillS.SkillConf.SkillMoveSpeed * 0.001f;
            skillS.BulletUnit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.TheUnitFrom.Id, skillS.SkillConf.Id, 0,
                skillS.NowPosition, new CreateMonsterInfo());
            skillS.TargetPosition = TargetPoint;
            skillS.BulletUnit.BulletMoveToAsync(TargetPoint).Coroutine();

            OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            //this.BaseOnUpdate();
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }

            skillS.UpdateCheckPoint(skillS.BulletUnit.Position);
            skillS.ExcuteSkillAction();
            if (!skillS.Return)
            {
                skillS.Return = PositionHelper.Distance2D(skillS.BulletUnit.Position, skillS.TargetPosition) < 0.5f;
                skillS.HurtIds.Clear();
            }

            if (skillS.Return)
            {
                skillS.BulletUnit.BulletMoveToAsync(skillS.TheUnitFrom.Position).Coroutine();
                if (PositionHelper.Distance2D(skillS.BulletUnit.Position, skillS.TheUnitFrom.Position) < 1f)
                {
                    skillS.SetSkillState(SkillState.Finished);
                }
            }

            //防止不销毁
            if (serverNow > skillS.SkillEndTime + TimeHelper.Minute)
            {
                skillS.SetSkillState(SkillState.Finished);
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            //移除Unity
            if (skillS.BulletUnit != null && !skillS.BulletUnit.IsDisposed)
            {
                skillS.BulletUnit.GetParent<UnitComponent>().Remove(skillS.BulletUnit.Id);
            }

            skillS.Clear();
        }
    }
}