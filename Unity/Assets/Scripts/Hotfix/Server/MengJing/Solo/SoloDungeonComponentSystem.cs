using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (SoloDungeonComponent))]
    [FriendOf(typeof (SoloDungeonComponent))]
    public static partial class SoloDungeonComponentSystem
    {
        
        [Invoke(TimerInvokeType.SoloDungeonTimer)]
        public class SoloDungeonTimer: ATimer<SoloDungeonComponent>
        {
            protected override void Run(SoloDungeonComponent self)
            {
                try
                {
                    self.PlayerCheck();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this SoloDungeonComponent self)
        {
            //记录开场时间设置计时器 没15秒检测一次
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(15000, TimerInvokeType.SoloDungeonTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this SoloDungeonComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void PlayerCheck(this SoloDungeonComponent self)
        {
            List<Unit> playerUnitList = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            if (playerUnitList.Count == 0)
            {
                return;
            }

            if (playerUnitList.Count <= 1)
            {
                if (playerUnitList[0] != null)
                {
                    //场景如果只进了1个人则那1个人获得胜利
                    self.OnKillEvent(playerUnitList[0], null);
                }
            }
        }

        public static void OnKillEvent(this SoloDungeonComponent self, Unit attackUnit, Unit defendUnit)
        {
            //获胜发送奖励
            if (attackUnit != null && defendUnit != null)
            {
                if (attackUnit.Type == UnitType.Player && defendUnit.Type == UnitType.Player)
                {
                    if (!self.SendReward)
                    {
                        self.SendReward = true;
                        //发送输/赢奖励
                        self.SendReward(attackUnit, defendUnit);
                        //增加积分记录
                        self.WinAddIntegral(attackUnit.Id, defendUnit.Id);
                    }
                }
            }

            //场景只有1个人 另外一个人没进去的情况下
            if (attackUnit != null && attackUnit.Type == UnitType.Player && defendUnit == null)
            {
                if (!self.SendReward)
                {
                    self.SendReward = true;
                    //发送输/赢奖励
                    self.SendReward(attackUnit, defendUnit);
                    //增加积分记录
                    self.WinAddIntegral(attackUnit.Id, 0);
                }
            }
        }

        public static void SendReward(this SoloDungeonComponent self, Unit attackUnit, Unit defendUnit)
        {
            self.SendReward = true;
            if (attackUnit != null && attackUnit.Type == UnitType.Player)
            {
                List<RewardItem> rewardList = new List<RewardItem>();
                //获胜奖励
                RewardItem reward = new RewardItem();

                int goldValue = 12500;

                if (attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Lv >= 30)
                {
                    goldValue = 15000;
                }

                if (attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Lv >= 40)
                {
                    goldValue = 17500;
                }

                if (attackUnit.GetComponent<UserInfoComponentS>().UserInfo.Lv >= 50)
                {
                    goldValue = 20000;
                }

                reward.ItemID = 1;
                reward.ItemNum = goldValue;
                rewardList.Add(reward);
                reward = new RewardItem();
                reward.ItemID = 10010035;
                reward.ItemNum = RandomHelper.NextInt(1, 4);
                rewardList.Add(reward);
                M2C_SoloDungeon M2C_SoloDungeon = M2C_SoloDungeon.Create();
                M2C_SoloDungeon.RewardItem = rewardList;
                M2C_SoloDungeon.SoloResult = 1;
                MapMessageHelper.SendToClient(attackUnit, M2C_SoloDungeon);
                attackUnit.GetComponent<BagComponentS>().OnAddItemData(rewardList, string.Empty, $"{ItemGetWay.SoloReward}_{TimeHelper.ServerNow()}");
            }

            if (defendUnit != null && defendUnit.Type == UnitType.Player)
            {
                //失败奖励
                List<RewardItem> rewardListFail = new List<RewardItem>();
                RewardItem rewardFail = new RewardItem();
                rewardFail.ItemID = 1;
                rewardFail.ItemNum = 7500;

                if (defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Lv >= 30)
                {
                    rewardFail.ItemNum = 10000;
                }

                if (defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Lv >= 40)
                {
                    rewardFail.ItemNum = 12500;
                }

                if (defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Lv >= 50)
                {
                    rewardFail.ItemNum = 15000;
                }

                rewardListFail.Add(rewardFail);
                M2C_SoloDungeon M2C_SoloDungeon = M2C_SoloDungeon.Create();
                M2C_SoloDungeon.RewardItem = rewardListFail;
                M2C_SoloDungeon.SoloResult = 0;
                MapMessageHelper.SendToClient(defendUnit, M2C_SoloDungeon);
                defendUnit.GetComponent<BagComponentS>()
                        .OnAddItemData(rewardListFail, string.Empty, $"{ItemGetWay.SoloReward}_{TimeHelper.ServerNow()}");
            }
        }

        /// <summary>
        /// 踢出还在副本的玩家
        /// </summary>
        /// <param name="self"></param>
        public static void KickOutPlayer(this SoloDungeonComponent self)
        {
            C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
            actor_Transfer.SceneType = MapTypeEnum.MainCityScene;
            
            List<EntityRef<Unit>> units = self.Scene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unititem = units[i];
                if (unititem.Type != UnitType.Player)
                {
                    continue;
                }

                if (unititem.IsDisposed || unititem.IsRobot())
                {
                    continue;
                }

                TransferHelper.TransferUnit(units[i], actor_Transfer).Coroutine();
            }
        }

        //胜利者增加积分
        public static void WinAddIntegral(this SoloDungeonComponent self, long winUnitId, long failUnitId)
        {
            Log.Debug($"增加积分 {winUnitId}");
            SoloSceneComponent soloSceneComponent = self.Scene().GetParent<SoloSceneComponent>();
            if (soloSceneComponent.PlayerIntegralList.ContainsKey(winUnitId))
            {
                int value = soloSceneComponent.PlayerIntegralList[winUnitId];
                soloSceneComponent.PlayerIntegralList[winUnitId] += 3; //每次胜利获得3点积分
            }

            //记录战绩和积分
            if (soloSceneComponent.AllPlayerDateList.ContainsKey(winUnitId))
            {
                soloSceneComponent.AllPlayerDateList[winUnitId].WinNum += 1;
                soloSceneComponent.AllPlayerDateList[winUnitId].Combat = soloSceneComponent.PlayerIntegralList[winUnitId];
            }

            if (failUnitId != 0)
            {
                if (soloSceneComponent.AllPlayerDateList.ContainsKey(failUnitId))
                {
                    soloSceneComponent.AllPlayerDateList[failUnitId].FailNum += 1;
                }
            }
        }
    }
}