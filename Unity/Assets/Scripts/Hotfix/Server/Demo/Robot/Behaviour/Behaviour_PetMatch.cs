using System;
using ET.Server;
using ET.Client;

namespace ET
{
    //战场
    public class Behaviour_PetMatch : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_PetMatch;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Scene root = aiComponent.Root();
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
   
            Console.WriteLine("Behaviour_PetMatch");
            while (true)
            {
                await PetMatchNetHelper.RequestPetMatch(root);
                
                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(TimeHelper.Minute * 10, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    Console.WriteLine("Behaviour_PetMatch.Exit: IsCancel");
                    return;
                }
               
            }
        }
    }
}
