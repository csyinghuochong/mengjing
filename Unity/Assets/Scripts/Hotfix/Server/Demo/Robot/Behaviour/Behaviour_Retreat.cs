using System;
using ET.Client;
using Unity.Mathematics;

namespace ET
{

    public class Behaviour_Retreat : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_Retreat;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            //WriteLine("Behaviour_Retreat.Execute");
            Scene root = aiComponent.Root();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            float3 targetPosition = aiComponent.TargetPosition;
            while (true)
            {
                if (unit.IsDisposed)
                {
                    return;
                }

                if (math.distance(unit.Position, targetPosition) > 1f)
                {
                    unit.MoveToAsync(targetPosition).Coroutine();
                }
                else
                {
                    aiComponent.TargetID = 0;
                    aiComponent.ChangeBehaviour(BehaviourType.Behaviour_Target);
                }
                
                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(1000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    //Console.WriteLine("Behaviour_Retreat.Exit: IsCancel");
                    return;
                }
            }
        }
    }
}
