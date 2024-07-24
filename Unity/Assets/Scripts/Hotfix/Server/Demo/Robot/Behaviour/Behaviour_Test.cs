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

                // 副本（需要切场景）类型的玩法除外... 所有协议都要测试到， 可以按照移植顺序或者自定义
                // 尽量模拟真实玩家的行为测试所有外围系统协议
                // 功能函数写在system，收发协议写在helper

                Console.WriteLine("检测背包有可鉴定装备 直接鉴定");
                await RobotHelper.JianDing(root);

                Console.WriteLine("检测背包有可替换的装备 直接穿戴");
                await RobotHelper.WearEquip(root);

                Console.WriteLine("检测背包有可以镶嵌的宝石 直接镶嵌");
                await RobotHelper.XiangQianGem(root);

                Console.WriteLine("背包宝石合成");
                await RobotHelper.GemHeCheng(root);

                Console.WriteLine("出售背包中低品质装备和宝石");
                await BagClientNetHelper.RequestOneSell(root, ItemLocType.ItemLocBag);

                Console.WriteLine("回收道具");
                await RobotHelper.HuiShou(root);

                Console.WriteLine("强化");
                await RobotHelper.QiangHua(root);

                Console.WriteLine("整理背包");
                await BagClientNetHelper.RequestSortByLoc(root, ItemLocType.ItemLocBag);

                Console.WriteLine("属性加点");
                await RobotHelper.AddPoint(root);

                Console.WriteLine("抽卡");
                await BagClientNetHelper.ChouKa(root, 1001, 1);

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