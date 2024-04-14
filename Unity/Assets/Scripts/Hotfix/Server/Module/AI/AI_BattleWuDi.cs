using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    [AIHandler]
    public class AI_BattleWuDi : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            await ETTask.CompletedTask;
            Unit unit = aiComponent.GetParent<Unit>();
            C2M_SkillCmd cmd = new C2M_SkillCmd();
            cmd.SkillID = aiComponent.AISkillIDList[0];
            cmd.TargetID = 0;
            cmd.TargetDistance = 0;
            cmd.TargetAngle = (int)MathHelper.QuaternionToEulerAngle_Y(unit.Rotation);
            //触发技能
            unit.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, true);
            return;
        }
    }
}
