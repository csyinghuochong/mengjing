using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Invoke(TimerInvokeType.PetMeleeDungeonBattleTimer)]
    public class PetMeleeDungeonBattleTimer : ATimer<PetMeleeDungeonComponent>
    {
        protected override void Run(PetMeleeDungeonComponent self)
        {
            try
            {
                self.SetGameOver(CombatResultEnum.Fail);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }

    [Invoke(TimerInvokeType.PetMeleeDungeonDealCardTimer)]
    public class PetMeleeDungeonDealCardTimer : ATimer<PetMeleeDungeonComponent>
    {
        protected override void Run(PetMeleeDungeonComponent self)
        {
            try
            {
                self.DealCards();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }

    [Invoke(TimerInvokeType.PetMeleeDungeonRestoreTimer)]
    public class PetMeleeDungeonRestoreTimer : ATimer<PetMeleeDungeonComponent>
    {
        protected override void Run(PetMeleeDungeonComponent self)
        {
            try
            {
                self.Restore();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }

    [EntitySystemOf(typeof(PetMeleeDungeonComponent))]
    [FriendOf(typeof(PetMeleeDungeonComponent))]
    public static partial class PetMeleeDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PetMeleeDungeonComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this PetMeleeDungeonComponent self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.PetMeleeDungeonBattleTimer);
            timerComponent.Remove(ref self.PetMeleeDungeonDealCardTimer);
            timerComponent.Remove(ref self.PetMeleeDungeonRestoreTimer);

            foreach (PetMeleeCarInfo carInfo in self.PetMeleeCarInfos)
            {
                carInfo.Dispose();
            }

            self.PetMeleeCarInfos.Clear();
            self.PetMeleeCarInfos = null;

            foreach (PetMeleeCarInfo carInfo in self.PetMeleeCarInfoPool)
            {
                carInfo.Dispose();
            }

            self.PetMeleeCarInfoPool.Clear();
            self.PetMeleeCarInfoPool = null;
        }

        public static void SetPlayer(this PetMeleeDungeonComponent self)
        {
            List<Unit> players = FubenHelp.GetUnitList(self.Scene(), UnitType.Player);
            self.Player = players[0];

            // 设置初始魔力值

            // 发放初始卡牌
        }

        public static void DealCards(this PetMeleeDungeonComponent self)
        {
            // 发牌
            if (self.GameOver)
            {
                return;
            }
        }

        public static bool UseCard(this PetMeleeDungeonComponent self, PetMeleeCarInfo carInfo)
        {
            // 用牌
            if (self.GameOver)
            {
                return false;
            }

            return false;
        }

        public static void Restore(this PetMeleeDungeonComponent self)
        {
            // 恢复魔力
            if (self.GameOver)
            {
                return;
            }
        }

        public static bool IsGameStart(this PetMeleeDungeonComponent self)
        {
            return self.GameStart;
        }

        public static bool IsGameOver(this PetMeleeDungeonComponent self)
        {
            return self.GameOver;
        }

        public static void SetGameStart(this PetMeleeDungeonComponent self)
        {
            self.GameStart = true;

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            self.PetMeleeDungeonBattleTimer = timerComponent.NewOnceTimer(TimeInfo.Instance.ServerNow() + ConfigData.PetMeleeBattleMaxTime,
                TimerInvokeType.PetMeleeDungeonBattleTimer, self);
            self.PetMeleeDungeonDealCardTimer =
                    timerComponent.NewRepeatedTimer(ConfigData.PetMeleeCardRefreshInterval, TimerInvokeType.PetMeleeDungeonDealCardTimer, self);
            self.PetMeleeDungeonRestoreTimer = timerComponent.NewRepeatedTimer(1000, TimerInvokeType.PetMeleeDungeonRestoreTimer, self);

            List<Unit> allPet = UnitHelper.GetUnitList(self.Scene(), UnitType.Pet);
            for (int i = 0; i < allPet.Count; i++)
            {
                allPet[i].GetComponent<AIComponent>().Begin();
            }

            self.GenerateFuben();
        }

        public static void SetGameOver(this PetMeleeDungeonComponent self, int combatResult)
        {
            if (self.GameOver)
            {
                return;
            }

            self.GameOver = true;

            M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
            m2C_FubenSettlement.BattleResult = combatResult;
            // 奖励。。。

            if (self.Player != null)
            {
                MapMessageHelper.SendToClient(self.Player, m2C_FubenSettlement);
            }
        }

        private static void GenerateFuben(this PetMeleeDungeonComponent self)
        {
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();

            FubenHelp.CreateMonsterList(self.Scene(), SceneConfigCategory.Instance.Get(mapComponent.SceneId).CreateMonsterPosi);
        }

        public static void OnKillEvent(this PetMeleeDungeonComponent self, Unit defend)
        {
            if (self.GameOver)
            {
                return;
            }

            if (defend.Type == UnitType.Monster)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(defend.ConfigId);
                if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_62)
                {
                    self.Scene().RemoveComponent<YeWaiRefreshComponent>();

                    int battleCamp = defend.GetComponent<NumericComponentS>().GetAsInt(NumericType.BattleCamp);
                    self.SetGameOver(battleCamp == 1 ? CombatResultEnum.Fail : CombatResultEnum.Win);
                }
            }
        }
    }
}