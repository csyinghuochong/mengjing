namespace ET.Server
{
    [EntitySystemOf(typeof (TowerComponent))]
    [FriendOf(typeof (TowerComponent))]
    public static partial class TowerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TowerComponent self)
        {
            self.TowerId = 0;
            self.Timer = 0;
        }

        [EntitySystem]
        private static void Destroy(this TowerComponent self)
        {
        }

        public static void OnKillEvent(this TowerComponent self, Unit defend)
        {
            Unit mainunit = UnitHelper.GetUnitList(self.Scene(), UnitType.Player)[0];
            
            if (defend.Id == mainunit.Id)
            {
                self.OnTowerOver("PlayerDie");
                return;
            }

            if (defend.GetBattleCamp() == mainunit.GetBattleCamp())
            {
                return;
            }

            if (FubenHelp.IsAllMonsterDead(self.Scene(), mainunit))
            {
                self.OnTimer();
                return;
            }
        }

        public static void OnEmptyReward(this TowerComponent self)
        {
            Unit mainunit = UnitHelper.GetUnitList(self.Scene(), UnitType.Player)[0];
            M2C_FubenSettlement message = M2C_FubenSettlement.Create();
            message.BattleResult = 2;
            message.RewardExp = 0;
            message.RewardGold = 0;
            MapMessageHelper.SendToClient(mainunit, message);
        }

        public static void OnTowerOver(this TowerComponent self, string way)
        {
            if (self.TowerId == 0)
            {
                return;
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            string[] ids = GlobalValueConfigCategory.Instance.Get(65).Value.Split(';');
            int startTowerId = int.Parse(ids[self.FubenDifficulty - 1]); //起始波
            int endId = self.TowerId; //当前波

            Unit mainunit = UnitHelper.GetUnitList(self.Scene(), UnitType.Player)[0];
            M2C_FubenSettlement message = M2C_FubenSettlement.Create();
            message.BattleResult = 1;
            message.RewardExp = 0;
            message.RewardGold = 0;
            if (endId != 0)
            {
                int cengNum = TowerConfigCategory.Instance.Get(endId).CengNum;
                if (self.TowerId >= 100101 && self.TowerId <= 100199)
                {
                    message.RewardExp = 10000 + cengNum * 3000;
                    message.RewardGold = 1000 + cengNum * 500;
                }

                if (self.TowerId >= 100201 && self.TowerId <= 100299)
                {
                    message.RewardExp = 50000 + cengNum * 5000;
                    message.RewardGold = 2000 + cengNum * 750;
                }

                if (self.TowerId >= 100301 && self.TowerId <= 100399)
                {
                    message.RewardExp = 75000 + cengNum * 7500;
                    message.RewardGold = 3000 + cengNum * 1000;
                }

                int itemNum = (int)(cengNum / 5f);
                mainunit.GetComponent<BagComponentS>().OnAddItemData("1000030;" + itemNum, $"{ItemGetWay.TiaoZhan}_{TimeHelper.ServerNow()}");
            }

            Log.Warning($"挑战奖励:  {mainunit.Id}  {way}");
            MapMessageHelper.SendToClient(mainunit, message);

            UserInfoComponentS userInfoComponent = mainunit.GetComponent<UserInfoComponentS>();
            userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Exp, message.RewardExp.ToString(), true, ItemGetWay.TiaoZhan);
            userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Gold, message.RewardGold.ToString(), true, ItemGetWay.TiaoZhan);
            self.TowerId = 0;
        }

        public static void OnTimer(this TowerComponent self)
        {
            //奖励
            Unit mainunit = UnitHelper.GetUnitList(self.Scene(), UnitType.Player)[0];
            self.TowerId = mainunit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TowerId);
            if (TowerHelper.GetLastTower(self.FubenDifficulty) == self.TowerId)
            {
                self.OnTowerOver("PassAll");
                return;
            }

            self.CreateMonster(self.TowerId + 1).Coroutine();
        }

        public static async ETTask CreateMonster(this TowerComponent self, int towerId)
        {
            long instanceId = self.InstanceId;
            Unit mainunit = UnitHelper.GetUnitList(self.Scene(), UnitType.Player)[0];
            mainunit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TowerId, towerId, true);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(2000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            if (mainunit == null ||mainunit.IsDisposed)
            {
                return;
            }

            Scene scene = self.Scene();
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(towerId);
            self.WaveTime = towerConfig.NextTime * 1000;
            FubenHelp.CreateMonsterList(scene, towerConfig.MonsterSet);
        }

        public static void BeginTower(this TowerComponent self)
        {
            string[] ids = GlobalValueConfigCategory.Instance.Get(65).Value.Split(';');
            int index = self.FubenDifficulty - 1;

            if (index < 0)
            {
                index = 0;
            }

            if (index > 2)
            {
                index = 2;
            }

            self.CreateMonster(int.Parse(ids[index])).Coroutine();
        }
    }
}