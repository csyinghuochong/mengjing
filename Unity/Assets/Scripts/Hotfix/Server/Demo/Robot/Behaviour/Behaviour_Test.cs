using System;
using System.Collections.Generic;
using System.Numerics;
using ET.Client;
using Unity.Mathematics;

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
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            BagComponentC bagComponent = root.GetComponent<BagComponentC>();
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();

            Log.Debug($"Behaviour_Arena: Execute");
            while (true)
            {
                Console.WriteLine("Behaviour_Test");

                // 副本（需要切场景）类型的玩法除外... 所有协议都要测试到， 可以按照移植顺序或者自定义
                // 尽量模拟真实玩家的行为测试所有外围系统协议
                // 功能函数写在system，收发协议写在helper

                // ！！！有问题的协议！！！
                // 

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

                Console.WriteLine("出售背包中低品质增幅");
                await BagClientNetHelper.RequestOneSell2(root, ItemLocType.ItemLocBag);

                Console.WriteLine("回收道具");
                await RobotHelper.HuiShou(root);

                Console.WriteLine("强化");
                await RobotHelper.QiangHua(root);

                Console.WriteLine("整理背包");
                await BagClientNetHelper.RequestSortByLoc(root, ItemLocType.ItemLocBag);

                Console.WriteLine("人物加点 根据配置按比例");
                await RobotHelper.AddPoint(root);

                Console.WriteLine("合成宠物之核");
                await PetNetHelper.RequestPetHeXinHeChengQuick(root);

                Console.WriteLine("穿戴宠物之核 评分大于3000的 穿戴或替换更好的核心");
                await RobotHelper.RolePetHeXin(root, 3000);

                Console.WriteLine("宠物加点 平均加点");
                await RobotHelper.RolePetJiadian(root);

                Console.WriteLine("出战一只最猛宠物");
                await RobotHelper.PetFight(root);

                Console.WriteLine("宠物融合 融合评分低于4000 且技能数量少于4个");
                await RobotHelper.RolePetHeCheng(root, 4000, 4);

                Console.WriteLine("给最猛的宠物用一个道具");
                await RobotHelper.RolePetXiLian(root);

                Console.WriteLine("开启守护 选评分最高的");
                await RobotHelper.PetShouHu(root);

                Console.WriteLine("改变守护 选评分最高的");
                await RobotHelper.PetShouHuActive(root);

                Console.WriteLine("学习强化一遍技能");
                await RobotHelper.SkillUp(root);

                Console.WriteLine("设置技能位置 根据技能等级排序");
                await RobotHelper.SkillSet(root);

                Console.WriteLine("激活天赋 默认选第一个");
                await RobotHelper.TianFuActive(root);

                Console.WriteLine("熔炼一个装备");
                await RobotHelper.ItemMelting(root);

                Console.WriteLine("锻造一个物品");
                await RobotHelper.MakeEquip(root, 1);
                Console.WriteLine("裁缝一个物品");
                await RobotHelper.MakeEquip(root, 3);
                Console.WriteLine("炼金一个物品");
                await RobotHelper.MakeEquip(root, 3);
                Console.WriteLine("附魔一个物品");
                await RobotHelper.MakeEquip(root, 6);

                Console.WriteLine("生命之魂注入 随机");
                await RobotHelper.LifeShieldCost(root);

                Console.WriteLine("向附近的人发送好友请求");
                await RobotHelper.AddFriend(root);

                Console.WriteLine("同意添加好友请求");
                await RobotHelper.FriendApplyReply(root);

                Console.WriteLine("问候我亲爱的好友们");
                await RobotHelper.SendFriendChat(root, "许久未见，我亲爱的友友。紫禁之巅，今晚8点，是兄弟就来砍！");

                Console.WriteLine("将好友添加到黑名单");
                await RobotHelper.AddFriend(root);
                Console.WriteLine("将好友移出黑名单");
                await RobotHelper.RemoveBlack(root);

                Console.WriteLine("无情删除所有好友");
                await RobotHelper.FriendDelete(root);

                Console.WriteLine("申请加入最弱的工会");
                await RobotHelper.UnionApply(root);

                Console.WriteLine("使用一个精灵");
                await RobotHelper.JingLingUse(root);

                Console.WriteLine("发言，打个招呼");
                await ChatNetHelper.RequestSendChat(root, ChannelEnum.Word, "大家好，我是Robot");
                await ChatNetHelper.RequestSendChat(root, ChannelEnum.Team, "兄弟们好，我是Robot");
                await ChatNetHelper.RequestSendChat(root, ChannelEnum.Union, "家人们好，我是Robot");

                Console.WriteLine("组队 有队伍加入队伍，无队伍自己创建一个");
                await RobotHelper.JoinTeam(root);

                Console.WriteLine("去杂货店老板 买个东西");
                await RobotHelper.Mystery(root);

                Console.WriteLine("去啄啄百货店 买个东西");
                await RobotHelper.Store(root);

                Console.WriteLine("去储物箱 存取东西");
                await RobotHelper.Warehous(root);

                Console.WriteLine("去装备洗炼大师 给自己的装备洗练一下");
                await RobotHelper.RoleXiLian(root);

                Console.WriteLine("去邮箱 领取信件");
                await RobotHelper.GetMail(root);

                Console.WriteLine("去宠物蛋培养 孵化宠物、兑换宠物、抽蛋、抽核心");
                await RobotHelper.PetEgg(root);

                Console.WriteLine("领红包");
                await ActivityNetHelper.HongBaoOpen(root);

                Console.WriteLine("抽卡");
                await BagClientNetHelper.ChouKa(root, 1001, 1);

                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(20000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    Log.Debug("Behaviour_Arena: Exit1");
                    return;
                }
            }
        }
    }
}