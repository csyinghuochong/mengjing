using System;
using System.Collections.Generic;
using Unity.Mathematics;

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

            foreach (PetMeleeCardInfo cardInfo in self.PetMeleeCardInHand)
            {
                cardInfo.Dispose();
            }

            self.PetMeleeCardInHand.Clear();
            self.PetMeleeCardInHand = null;

            foreach (PetMeleeCardInfo cardInfo in self.PetMeleeCardPool)
            {
                cardInfo.Dispose();
            }

            self.PetMeleeCardPool.Clear();
            self.PetMeleeCardPool = null;
        }

        public static void SetPlayer(this PetMeleeDungeonComponent self)
        {
            List<Unit> players = FubenHelp.GetUnitList(self.Scene(), UnitType.Player);
            self.Player = players[0];

            self.Player.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetMeleeMoLi, ConfigData.PetMeleeMoLiBase);

            self.InitCardPool();

            self.DealFirstCards();
        }

        // 初始化牌库
        private static void InitCardPool(this PetMeleeDungeonComponent self)
        {
            int maxNum = ConfigData.PetMeleeCarInHandNum * 5;
            int mainPetCardNum = (int)(maxNum * ConfigData.PetMeleeMainPetProb);
            int assistPetCardNum = (int)(maxNum * ConfigData.PetMeleeAssistPetProb);
            int skillCardNum = (int)(maxNum * ConfigData.PetMeleeSkillProb);

            for (int i = 0; i < mainPetCardNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.MainPet);

                if (cardInfo != null)
                {
                    self.PetMeleeCardPool.Add(cardInfo);
                }
            }

            for (int i = 0; i < assistPetCardNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.AssistPet);

                if (cardInfo != null)
                {
                    self.PetMeleeCardPool.Add(cardInfo);
                }
            }

            for (int i = 0; i < skillCardNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.Skill);

                if (cardInfo != null)
                {
                    self.PetMeleeCardPool.Add(cardInfo);
                }
            }

            for (int i = self.PetMeleeCardPool.Count - 1; i > 0; i--)
            {
                int j = RandomHelper.RandomNumber(0, i + 1);
                (self.PetMeleeCardPool[i], self.PetMeleeCardPool[j]) = (self.PetMeleeCardPool[j], self.PetMeleeCardPool[i]);
            }
        }

        // 发放初始卡牌
        private static void DealFirstCards(this PetMeleeDungeonComponent self)
        {
            for (int i = 0; i < ConfigData.PetMeleeFirstMainPetNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.MainPet);

                if (cardInfo != null)
                {
                    self.PetMeleeCardInHand.Add(cardInfo);
                }
            }

            for (int i = 0; i < ConfigData.PetMeleeFirstAssistPetNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.AssistPet);

                if (cardInfo != null)
                {
                    self.PetMeleeCardInHand.Add(cardInfo);
                }
            }

            for (int i = 0; i < ConfigData.PetMeleeFirstSkillNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.Skill);

                if (cardInfo != null)
                {
                    self.PetMeleeCardInHand.Add(cardInfo);
                }
            }
        }

        private static PetMeleeCardInfo CreateCard(this PetMeleeDungeonComponent self, PetMeleeCarType petMeleeCarType)
        {
            PetComponentS petcomponent = self.Player.GetComponent<PetComponentS>();
            PetMeleeInfo petmeleeinfo = petcomponent.PetMeleeInfoList[petcomponent.PetMeleePlan];

            switch (petMeleeCarType)
            {
                case PetMeleeCarType.MainPet:
                {
                    if (petmeleeinfo.MainPetList.Count <= 0)
                    {
                        return null;
                    }

                    int index = RandomHelper.RandomNumber(0, petmeleeinfo.MainPetList.Count);
                    PetMeleeCardInfo cardInfo = PetMeleeCardInfo.Create();
                    cardInfo.Id = IdGenerater.Instance.GenerateId();
                    cardInfo.Type = (int)PetMeleeCarType.MainPet;
                    cardInfo.PetId = petmeleeinfo.MainPetList[index];
                    return cardInfo;
                }
                case PetMeleeCarType.AssistPet:
                {
                    if (petmeleeinfo.AssistPetList.Count <= 0)
                    {
                        return null;
                    }

                    int index = RandomHelper.RandomNumber(0, petmeleeinfo.AssistPetList.Count);
                    PetMeleeCardInfo cardInfo = PetMeleeCardInfo.Create();
                    cardInfo.Id = IdGenerater.Instance.GenerateId();
                    cardInfo.Type = (int)PetMeleeCarType.AssistPet;
                    cardInfo.ConfigId = petmeleeinfo.AssistPetList[index];
                    return cardInfo;
                }
                case PetMeleeCarType.Skill:
                {
                    if (petmeleeinfo.SkillList.Count <= 0)
                    {
                        return null;
                    }

                    // ...

                    break;
                }
            }

            return null;
        }

        // 发牌
        public static void DealCards(this PetMeleeDungeonComponent self)
        {
            if (self.GameOver)
            {
                return;
            }

            if (self.PetMeleeCardInHand.Count >= ConfigData.PetMeleeCarInHandNum)
            {
                return;
            }

            if (self.PetMeleeCardPool.Count <= 0)
            {
                self.InitCardPool();
            }

            PetMeleeCardInfo cardInfo = self.PetMeleeCardPool[^1];
            self.PetMeleeCardPool.RemoveAt(self.PetMeleeCardPool.Count - 1);
            self.PetMeleeCardInHand.Add(cardInfo);

            M2C_PetMeleeDealCards message = M2C_PetMeleeDealCards.Create();
            message.PetMeleeCardList.Add(cardInfo);
            MapMessageHelper.SendToClient(self.Player, message);
        }

        // 用牌
        public static int UseCard(this PetMeleeDungeonComponent self, long cardId, float3 position)
        {
            if (self.GameOver)
            {
                return ErrorCode.ERR_ModifyData;
            }

            PetMeleeCardInfo useCard = null;
            foreach (PetMeleeCardInfo cardInfo in self.PetMeleeCardInHand)
            {
                if (cardInfo.Id == cardId)
                {
                    useCard = cardInfo;
                    break;
                }
            }

            if (useCard == null)
            {
                return ErrorCode.ERR_ModifyData;
            }

            if (useCard.Type == (int)PetMeleeCarType.MainPet)
            {
                if (self.Player.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeMoLi) < ConfigData.PetMeleeMainPetCost)
                {
                    return ErrorCode.ERR_PetMelee_MoLiNoEnough;
                }
                else
                {
                    self.Player.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetMeleeMoLi, -ConfigData.PetMeleeMainPetCost);
                }

                PetComponentS petComponent = self.Player.GetComponent<PetComponentS>();
                RolePetInfo rolePetInfo = petComponent.GetPetInfo(useCard.PetId);
                if (rolePetInfo == null)
                {
                    return ErrorCode.ERR_Pet_NoExist;
                }

                List<Unit> allpet = UnitHelper.GetUnitList(self.Scene(), UnitType.Pet);
                if (allpet.Count >= ConfigData.PetMeleeMaxPetsInLine)
                {
                    return ErrorCode.ERR_PetMelee_PetNumMax;
                }

                // // 不能存在相同的宠物
                // if (unit.GetParent<UnitComponent>().Get(request.PetId) != null)
                // {
                //     response.Error = ErrorCode.ERR_RequestRepeatedly;
                //     return;
                // }

                Unit pet = UnitFactory.CreateTianTiPet(self.Scene(), self.Player.Id, CampEnum.CampPlayer_1, rolePetInfo, position, 90, -1,
                    IdGenerater.Instance.GenerateId());

                if (self.GameStart)
                {
                    pet.GetComponent<AIComponent>().Begin();
                }
            }
            else if (useCard.Type == (int)PetMeleeCarType.AssistPet)
            {
                if (self.Player.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeMoLi) < ConfigData.PetMeleeAssistPetCost)
                {
                    return ErrorCode.ERR_PetMelee_MoLiNoEnough;
                }
                else
                {
                    self.Player.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetMeleeMoLi, -ConfigData.PetMeleeAssistPetCost);
                }

                PetComponentS petComponent = self.Player.GetComponent<PetComponentS>();

                List<Unit> allpet = UnitHelper.GetUnitList(self.Scene(), UnitType.Pet);
                if (allpet.Count > ConfigData.PetMeleeMaxPetsInLine)
                {
                    return ErrorCode.ERR_PetMelee_PetNumMax;
                }

                Unit pet = UnitFactory.CreateTianTiPet(self.Scene(), self.Player.Id, CampEnum.CampPlayer_1,
                    petComponent.GenerateNewPetByPetTuJianConfigId(useCard.ConfigId), position, 90, -1, IdGenerater.Instance.GenerateId());

                if (self.GameStart)
                {
                    pet.GetComponent<AIComponent>().Begin();
                }
            }
            else if (useCard.Type == (int)PetMeleeCarType.Skill)
            {
                // ...
            }

            self.PetMeleeCardInHand.Remove(useCard);
            useCard.Dispose();

            return ErrorCode.ERR_Success;
        }

        // 恢复魔力
        public static void Restore(this PetMeleeDungeonComponent self)
        {
            if (self.GameOver)
            {
                return;
            }

            int num = self.Player.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeMoLi);
            self.Player.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetMeleeMoLi,
                num + ConfigData.PetMeleeMoLiRPS > ConfigData.PetMeleeMoLiMax ? ConfigData.PetMeleeMoLiMax : num + ConfigData.PetMeleeMoLiRPS);
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