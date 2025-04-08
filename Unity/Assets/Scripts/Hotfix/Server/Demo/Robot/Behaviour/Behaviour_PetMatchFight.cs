using System;
using ET.Server;
using ET.Client;
using Unity.Mathematics;

namespace ET
{
    //战场
    public class Behaviour_PetMatchFight : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_PetMatchFight;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Scene root = aiComponent.Root();
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
   
            Console.WriteLine("Behaviour_PetMatchFight");
            while (true)
            {
                //随机发牌
                M2C_PetMeleeGetMyCards response = await PetNetHelper.PetMeleePetMeleeGetMyCardsRequest(root, MapTypeEnum.PetMatch);
                
                if (response != null && response.PetMeleeCardList.Count > 0)
                {
                    Console.WriteLine("Behaviour_PetMatchFight。  PetMeleePlaceRequest");
                    PetMeleeCardInfo petMeleeCardInfo = response.PetMeleeCardList[RandomHelper.RandomNumber(0, response.PetMeleeCardList.Count)];
                    
                    long cardid =petMeleeCardInfo.Id;
                    await PetNetHelper.PetMeleePlaceRequest(root, cardid, float3.zero, 0, MapTypeEnum.PetMatch);
                }
                else
                {
                    Console.WriteLine("Behaviour_PetMatchFight。 000");
                }
                
                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(TimeHelper.Second * 10, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    Console.WriteLine("Behaviour_PetMatchFight.Exit: IsCancel");
                    return;
                }
            }
        }
    }
}
