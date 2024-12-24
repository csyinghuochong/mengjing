using Unity.Mathematics;

namespace ET.Client
{
    
    //伏击 快速移动到目标的背后,对目标立即造成200%伤害,并眩晕1秒
    
    public class Skill_Ambushing : SkillHandlerC
    {
        public override void OnInit(SkillC skils, Unit theUnitFrom)
        {
            skils.BaseOnInit(skils.SkillInfo, theUnitFrom);
            skils.SkillExcuteHurtTime += 100;
        }

        public override void OnExecute(SkillC skils)
        {
            //更新位置
            Unit target = skils.TheUnitFrom.GetParent<UnitComponent>().Get(skils.SkillInfo.TargetID);
            if (target != null)
            {
                float3 dir = target.Position - skils.TheUnitFrom.Position;
                float ange = math.degrees(math.atan2(dir.x, dir.z));
                skils.TheUnitFrom.Rotation = quaternion.Euler(0, math.radians(ange), 0);
            }
            
            skils.PlaySkillEffects(skils.TheUnitFrom.Position);
            skils.OnShowSkillIndicator(skils.SkillInfo);
        }

        public override void OnUpdate(SkillC skils)
        {
            long serverNow = TimeHelper.ServerNow();
            if (skils.IsExcuteHurt && serverNow >= skils.SkillExcuteHurtTime)
            {
                 this.OnExecute(skils);
            }

            skils.BaseOnUpdate();
        }

        public override void OnFinished(SkillC skils)
        {

        }
    }
}
