using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 伏击 快速移动到目标的背后,对目标立即造成200%伤害,并眩晕1秒
    /// </summary>
    public class Skill_Ambushing : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            //先跳过去再触发伤害
            Unit theUnitFrom = skillS.TheUnitFrom;
            Unit targetUnit = theUnitFrom.GetParent<UnitComponent>().Get(skillS.SkillInfo.TargetID);
            float3 targetPos = theUnitFrom.Position;
            
            float3 dir = targetUnit.Position - theUnitFrom.Position;
            float ange = math.degrees(math.atan2(dir.x, dir.z));
              
            quaternion rotation = quaternion.Euler(0, math.radians(ange), 0);
            targetPos = targetUnit.Position + math.mul(rotation, math.forward()) * 1f;
            targetPos = skillS.TheUnitFrom.GetComponent<PathfindingComponent>().GetCanChongJiPath(targetUnit.Position, targetPos, 0.2f);
            skillS.TargetPosition = targetPos;
            this.SyncPostion(skillS);
            skillS.InitSelfBuff();
            
            float3 dir_2 = targetPos - targetUnit.Position;
            float ange_2 = math.degrees(math.atan2(dir_2.x, dir_2.z));
            skillS.UpdateCheckRotation(ange_2);
            
            this.OnUpdate(skillS, 0);
        }

        public void SyncPostion(SkillS skillS)
        {
            skillS.TheUnitFrom.Position = skillS.TargetPosition;
            skillS.TheUnitFrom.Stop(-3);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }

            skillS.BaseOnUpdate();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
