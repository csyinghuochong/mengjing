using System;
using ET.Client;

namespace ET
{
    //角斗场
    public class Behaviour_Test : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_Test;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Scene root = aiComponent.Root();
            Log.Debug($"Behaviour_Arena: Execute");
            while (true)
            {
                Console.WriteLine("Behaviour_Test");

                //副本（需要切场景）类型的玩法除外... 所有协议都要测试到， 可以按照移植顺序或者自定义
                //尽量模拟真实玩家的行为测试所有外围系统协议

                // 检测背包有可鉴定装备 直接鉴定.  功能函数写在system，收发协议写在helper
                Console.WriteLine("鉴定");
                await RobotHelper.JianDing(root);

                // 检测背包有可替换的装备 直接穿戴
                Console.WriteLine("穿戴装备");
                await RobotHelper.WearEquip(root);

                //检测背包有可以镶嵌的宝石 直接镶嵌
                Console.WriteLine("镶嵌宝石");
                await RobotHelper.XiangQianGem(root);

                Console.WriteLine("属性加点");
                await RobotHelper.AddPoint(root);

                //抽卡
                Console.WriteLine("抽卡");
                await RobotHelper.ChouKa(root);

                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await root.GetComponent<TimerComponent>().WaitAsync(20000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    Log.Debug("Behaviour_Arena: Exit1");
                    return;
                }
            }
        }
    }
}