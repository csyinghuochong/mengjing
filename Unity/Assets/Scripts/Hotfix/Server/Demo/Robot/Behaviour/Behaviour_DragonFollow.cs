using System;
using ET.Client;
using Unity.Mathematics;
using UnitHelper = ET.Client.UnitHelper;

namespace ET
{
    
    //地下城 ，跟随队长  .  先用Behaviour_Target
    public class Behaviour_DragonFollow : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_DragonFollow;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            //Console.WriteLine("Behaviour_ZhuiJi.Execute");
            Unit unit = UnitHelper.GetMyUnitFromClientScene(aiComponent.Root());
            TimerComponent timerComponent = aiComponent.Root().GetComponent<TimerComponent>();
            long instanceId = unit.InstanceId;
            while (true)
            {
                if (instanceId != unit.InstanceId)
                {
                    return;
                }
                Unit target = unit.GetParent<UnitComponent>().Get(aiComponent.TargetID);
                if (target != null && math.distance(target.Position, unit.Position) > aiComponent.ActDistance)
                {
                    float3 ttt = new float3(
                        RandomHelper.RandomNumberFloat(aiComponent.ActDistance * -1f, aiComponent.ActDistance), 
                        0, 
                        RandomHelper.RandomNumberFloat(aiComponent.ActDistance * -1f, aiComponent.ActDistance));
                    ttt += target.Position;
                    unit.MoveToAsync(ttt).Coroutine();
                }
                else
                {
                    target = GetTargetHelperc.GetNearestEnemy(unit, 10);
                    aiComponent.TargetID = target!= null ? target.Id : 0;
                }
                if (target == null)
                {
                    aiComponent.TargetID = 0;
                    aiComponent.ChangeBehaviour(BehaviourType.Behaviour_Target);
                    return;
                }
                
                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(1000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    //Console.WriteLine("Behaviour_ZhuiJi.Exit: IsCancel");
                    return;
                }
            }
        }
    }
}
