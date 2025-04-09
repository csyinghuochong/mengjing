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

            string targetinfo = target != null ? target.GetAIPriorityParams() : string.Empty;

           //不是优先级最高的怪物
           if (target !=null && !target.IsDisposed && !aiConfig.NodeParams.Contains(targetinfo))
           {
                //寻找优先级最高的怪物
                Unit nearest = GetTargetHelpS.GetNearestEnemyAIPriority(unit, aiComponent.ActRange, aiConfig.NodeParams, false);
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