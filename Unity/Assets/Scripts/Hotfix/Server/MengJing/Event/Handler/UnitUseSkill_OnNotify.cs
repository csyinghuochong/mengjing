using Unity.Mathematics;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class UnitUseSkill_OnNotify : AEvent<Scene, UnitUseSkill>
    {
        protected override async ETTask Run(Scene scene, UnitUseSkill args)
        {
            Unit unit = args.UnitDefend;
            C2M_SkillCmd skillcmd = args.skillcmd;

            unit.Rotation = quaternion.Euler(0, math.radians(skillcmd.TargetAngle), 0);
            SkillConfig weaponSkillConfig = SkillConfigCategory.Instance.Get(skillcmd.WeaponSkillID);
            if (!unit.GetComponent<MoveComponent>().IsArrived())  /// &&  weaponSkillConfig.IfStopMove == 0
            {
                unit.Stop(weaponSkillConfig.Id);
            }
            
            await ETTask.CompletedTask;
        }
    }
}