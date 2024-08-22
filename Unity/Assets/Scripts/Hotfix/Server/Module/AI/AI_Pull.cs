using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    public class AI_Pull : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return (aiComponent.TargetPoint.Count == 0) ? 1 : 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            float limitDis = 0.5f;

            for (int i = 0; i < 10000; i++)
            {
                if (aiComponent.TargetPoint.Count == 0)
                {
                    break;
                }

                float3 targetPosition = aiComponent.TargetPoint[0];
                float distance = math.distance(unit.Position, targetPosition);

                List<float3> points = new List<float3>();
                unit.GetComponent<PathfindingComponent>().Find(unit.Position, targetPosition,points);
                if (distance >= limitDis && points.Count >= 2 )
                {
                    float3 dir = unit.Position - targetPosition;
                    float ange = math.radians(math.atan2(dir.x, dir.z));
                    float addg = unit.Id % 10 * (unit.Id % 2 == 0 ? 2 : -2);
                    quaternion rotation = quaternion.Euler(0, math.radians(ange + addg), 0);
                    float3 ttt = targetPosition + math.mul(rotation, math.forward()) * (limitDis);
                    unit.FindPathMoveToAsync(ttt).Coroutine();
                }
                
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(200, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }
}
