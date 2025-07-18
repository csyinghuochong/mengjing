using System;
using ET.Client;
using Unity.Mathematics;
using UnitHelper = ET.Client.UnitHelper;

namespace ET
{
    //战场
    public class Behaviour_Target : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_Target;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(aiComponent.Root());
            TimerComponent timerComponent = aiComponent.Root().GetComponent<TimerComponent>();
            
            float3 targetPosition = aiComponent.TargetPosition;
            while (true)
            {
                if (aiComponent.RobotConfig.Behaviour == 11)
                {
                    long teamid = unit.GetTeamId();
                    if (teamid == unit.Id)
                    {
                        Console.WriteLine($"队长不可能是机器人，逻辑错误！！！: {unit.Id} " );
                        break;
                    }

                    targetPosition = unit.Position;
                    M2C_TeamerPositionResponse response = await TeamNetHelper.TeamerPositionRequest(aiComponent.Root());
                 
                    for (int i = 0; i < response.UnitList.Count; i++)
                    {
                        if (teamid == response.UnitList[i].UnitId)
                        {
                            targetPosition = response.UnitList[i].Position;
                        }
                    }
                }
                
                Unit target = GetTargetHelperc.GetNearestEnemy(unit, 10);
                if (target!=null && aiComponent.HaveHaviour(BehaviourType.Behaviour_ZhuiJi))
                {
                    aiComponent.TargetID = target.Id;
                    aiComponent.ChangeBehaviour(BehaviourType.Behaviour_ZhuiJi);
                    return;
                }
                if (math.distance(unit.Position, targetPosition) > 1f)
                {
                    MoveHelper.MoveToAsync( unit,  targetPosition).Coroutine();
                }
                
                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(1000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    //Console.WriteLine("Behaviour_Target.Exit: IsCancel");
                    return;
                }
            }
        }
    }
}
