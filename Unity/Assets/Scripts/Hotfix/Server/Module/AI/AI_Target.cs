using Unity.Mathematics;

namespace ET.Server
{
    public class AI_Target : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            if (aiComponent.TargetID != 0)
            {
                return 1;
            }
            if (aiComponent.TargetPoint.Count == 0)
            {
                return 1;
            }
            Unit unit = aiComponent.GetParent<Unit>();
            Unit nearest = GetTargetHelpS.GetNearestEnemy(unit, aiComponent.ActRange, true);
            if (nearest!= null  && !aiComponent.IsRetreat)
            {
                aiComponent.TargetZhuiJi = unit.Position;
                aiComponent.TargetID = nearest.Id;
                return 1;
            }
            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();

            while (true)
            {
                if (aiComponent.TargetPoint.Count == 0)
                {
                    return;
                }
                float3 target = aiComponent.TargetPoint[0];
                float distance = math.distance(target, unit.Position);
                if (distance < 0.5f)
                {
                    aiComponent.TargetPoint.RemoveAt(0);
                    continue;
                }
                if (unit.GetComponent<StateComponentS>().CanMove() == ErrorCode.ERR_Success)
                {
                   unit.FindPathMoveToAsync(target).Coroutine();
                }
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(1000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }
}