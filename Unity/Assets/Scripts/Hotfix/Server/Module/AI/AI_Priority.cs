using Unity.Mathematics;
using System;

namespace ET.Server
{
    public class AI_Priority : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            UnitComponent unitComponent = unit.GetParent<UnitComponent>();
            Unit target = unitComponent.Get(aiComponent.TargetID);
            if (target == null || target.IsDisposed)
            {
                aiComponent.TargetID = 0;
            }

            if (target !=null && !target.IsDisposed && target.IsTowerMonster())
            {
                Unit nearest = GetTargetHelpS.GetNearestEnemyExcludeSonType(unit, aiComponent.ActRange, true);
                aiComponent.TargetID = nearest != null ?  nearest.Id : aiComponent.TargetID;
            }

            if (aiComponent.TargetID == 0)
            {
                Unit nearest = GetTargetHelpS.GetNearestEnemy(unit, aiComponent.ActRange, true);
                aiComponent.TargetID = nearest != null ? nearest.Id : 0;
            }
            
            return aiComponent.TargetID == 0 ? 0 : 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
     
            while (true)
            {
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(1000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }
}