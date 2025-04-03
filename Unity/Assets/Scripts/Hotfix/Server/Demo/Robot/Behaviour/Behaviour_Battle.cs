using System;
using ET.Client;

namespace ET
{
    //战场
    public class Behaviour_Battle : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_Battle;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Scene root = aiComponent.Root();
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            
            await RobotHelper.WearEquip(root);
            //Console.WriteLine("Behaviour_Battle.Execute");
            while (true)
            {
                int sceneId = BattleHelper.GetBattFubenId(root.GetComponent<UserInfoComponentC>().UserInfo.Lv);
                
                //Console.WriteLine($"GetBattFubenId   {root.GetComponent<UserInfoComponentC>().UserInfo.Lv}   {sceneId}");
                int errorCode = await EnterMapHelper.RequestTransfer(root, MapTypeEnum.Battle, sceneId);
                if (errorCode != 0)
                {
                    Console.WriteLine($"Behaviour_Battle: errorCode {errorCode}");
                }
                
                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(20000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    //Console.WriteLine("Behaviour_Battle.Exit: IsCancel");
                    return;
                }
            }
        }
    }
}
