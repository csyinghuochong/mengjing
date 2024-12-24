
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 指定目标攻击
    /// </summary>
    public class Skill_ComTargetMove_Damge_1 : SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            float3 nowPosition = new float3(theUnitFrom.Position.x,
                theUnitFrom.Position.y + SkillHelp.GetCenterHigh(theUnitFrom.Type, theUnitFrom.ConfigId),
                theUnitFrom.Position.z);
            skillS.NowPosition = nowPosition;
            skillS.TheUnitTarget = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(skillS.SkillInfo.TargetID);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }

            if (skillS.TheUnitTarget != null && !skillS.TheUnitTarget.IsDisposed)
            {
                float3 targetPosition = new float3(skillS.TheUnitTarget.Position.x,
                    skillS.TheUnitTarget.Position.y + SkillHelp.GetCenterHigh(skillS.TheUnitTarget.Type, skillS.TheUnitTarget.ConfigId),
                    skillS.TheUnitTarget.Position.z);
                skillS.TargetPosition = targetPosition;
            }
            else
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }
            
            float3 dir = (skillS.TargetPosition - skillS.NowPosition).normalize();
            float dis = PositionHelper.Distance2D(skillS.NowPosition, skillS.TargetPosition);
            float move = (float)skillS.SkillConf.SkillMoveSpeed * 0.1f;            //服务器0.1秒一帧
            move = math.min(dis, move);
            skillS.NowPosition = skillS.NowPosition + move * dir;
          
            //获取目标与自身的距离是否小于0.5f,小于触发将伤害,销毁自身
            dis = PositionHelper.Distance2D(skillS.NowPosition, skillS.TargetPosition);
            if (dis > 0.5f)
            {
                return;
            }

            float damgeRange = (float)skillS.SkillConf.DamgeRange[0];
            if (skillS.SkillConf.SkillTargetType == (int)SkillTargetType.TargetOnly
            || skillS.SkillConf.SkillTargetType == (int)SkillTargetType.MulTarget
            ||  damgeRange == 0f)
            {
                skillS.OnCollisionUnit( skillS.TheUnitTarget);
            }
            else
            {
                skillS.UpdateCheckPoint(skillS.NowPosition);
                skillS.ExcuteSkillAction();
            }
            skillS.SetSkillState(SkillState.Finished);
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
