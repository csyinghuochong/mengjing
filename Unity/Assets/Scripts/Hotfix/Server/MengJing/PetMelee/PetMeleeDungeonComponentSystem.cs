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

            foreach (PetMeleeCardInfo cardInfo in self.PetMeleeCardPool)
            {
                cardInfo.Dispose();
            }

            self.PetMeleeCardPool.Clear();
            self.UsedMainPetList.Clear();
            self.UsedSkillList.Clear();
        }

        public static void SetPlayer(this PetMeleeDungeonComponent self)
        {
            List<Unit> players = FubenHelp.GetUnitList(self.Scene(), UnitType.Player);
            self.Player = players[0];

            self.Player.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetMeleeMoLi, ConfigData.PetMeleeMoLiBase);

            self.DealFirstCards();
        }

        private static PetMeleeCardInfo GetCardByRandom(this PetMeleeDungeonComponent self)
        {
            PetMeleeCardInfo cardInfo = null;

            for (int i = 0; i < 10; i++)
            {
                float random = RandomHelper.RandFloat();

                if (random <= ConfigData.PetMeleeMainPetProb)
                {
                    cardInfo = self.CreateCard(PetMeleeCarType.MainPet);
                }
                else if (random <= ConfigData.PetMeleeMainPetProb + ConfigData.PetMeleeAssistPetProb)
                {
                    cardInfo = self.CreateCard(PetMeleeCarType.AssistPet);
                }
                else
                {
                    cardInfo = self.CreateCard(PetMeleeCarType.Magic);
                }

                if (cardInfo != null)
                {
                    break;
                }
            }

            if (cardInfo == null)
            {
                cardInfo = self.CreateCard(PetMeleeCarType.AssistPet);
            }

            return cardInfo;
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

            for (int i = 0; i < ConfigData.PetMeleeFirstMagicNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.Magic);

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

                    // 主战宠物只能出现一次
                    List<long> cards = new();
                    foreach (long id in petmeleeinfo.MainPetList)
                    {
                        if (self.UsedMainPetList.Contains(id))
                        {
                            continue;
                        }

                        cards.Add(id);
                    }

                    if (cards.Count <= 0)
                    {
                        return null;
                    }

                    int index = RandomHelper.RandomNumber(0, cards.Count);
                    PetMeleeCardInfo cardInfo = PetMeleeCardInfo.Create();
                    cardInfo.Id = IdGenerater.Instance.GenerateId();
                    cardInfo.Type = (int)PetMeleeCarType.MainPet;
                    cardInfo.PetId = cards[index];

                    self.UsedMainPetList.Add(cards[index]);

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
                case PetMeleeCarType.Magic:
                {
                    if (petmeleeinfo.MagicList.Count <= 0)
                    {
                        return null;
                    }

                    // 有些魔法卡只能出现一次
                    List<int> cards = new();
                    foreach (int id in petmeleeinfo.MagicList)
                    {
                        PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(id);
                        // 判断该卡是不是只能出现一次
                        if (petMagicCardConfig.IsOnly == 1 && self.UsedSkillList.Contains(id))
                        {
                            continue;
                        }

                        cards.Add(id);
                    }

                    if (cards.Count <= 0)
                    {
                        return null;
                    }

                    int index = RandomHelper.ReturnRamdomValue_Int(0, cards.Count - 1);
                    PetMeleeCardInfo cardInfo = PetMeleeCardInfo.Create();
                    cardInfo.Id = IdGenerater.Instance.GenerateId();
                    cardInfo.Type = (int)PetMeleeCarType.Magic;
                    cardInfo.ConfigId = cards[index];

                    self.UsedSkillList.Add(cards[index]);

                    return cardInfo;
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

            PetMeleeCardInfo cardInfo = self.GetCardByRandom();

            if (cardInfo == null)
            {
                return;
            }

            if (self.PetMeleeCardInHand.Count >= ConfigData.PetMeleeCarInHandNum)
            {
                self.PetMeleeCardPool.Add(cardInfo);
                return;
            }

            self.PetMeleeCardInHand.Add(cardInfo);

            M2C_PetMeleeDealCards message = M2C_PetMeleeDealCards.Create();
            message.PetMeleeCardList.Add(cardInfo);
            MapMessageHelper.SendToClient(self.Player, message);
        }

        // 用牌
        public static int UseCard(this PetMeleeDungeonComponent self, long cardId, float3 position, long targetUnitId)
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

                Unit pet = UnitFactory.CreateTianTiPet(self.Scene(), self.Player.Id, CampEnum.CampPlayer_1, rolePetInfo, position, 90, -1);

                if (self.GameStart)
                {
                    pet.GetComponent<AIComponent>().Begin();
                }
            }
            else if (useCard.Type == (int)PetMeleeCarType.AssistPet)
            {
                int cost = PetTuJianConfigCategory.Instance.Get(useCard.ConfigId).Cost;

                if (self.Player.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeMoLi) < cost)
                {
                    return ErrorCode.ERR_PetMelee_MoLiNoEnough;
                }
                else
                {
                    self.Player.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetMeleeMoLi, -cost);
                }

                PetComponentS petComponent = self.Player.GetComponent<PetComponentS>();

                List<Unit> allpet = UnitHelper.GetUnitList(self.Scene(), UnitType.Pet);
                if (allpet.Count >= ConfigData.PetMeleeMaxPetsInLine)
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
            else if (useCard.Type == (int)PetMeleeCarType.Magic)
            {
                PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(useCard.ConfigId);
                if (self.Player.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeMoLi) < petMagicCardConfig.Cost)
                {
                    return ErrorCode.ERR_PetMelee_MoLiNoEnough;
                }
                else
                {
                    self.Player.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetMeleeMoLi, -petMagicCardConfig.Cost);
                }

                float3 direction = position - self.Player.Position;
                float ange = math.degrees(math.atan2(direction.x, direction.z));

                // 暂时是让主角使用技能
                C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                cmd.SkillID = petMagicCardConfig.SkillId;
                cmd.TargetAngle = (int)math.floor(ange);
                cmd.TargetDistance = math.distance(position, self.Player.Position);
                cmd.TargetID = targetUnitId;
                self.Player.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, false);
            }

            self.PetMeleeCardInHand.Remove(useCard);
            useCard.Dispose();

            return ErrorCode.ERR_Success;
        }

        public static int DisposeCard(this PetMeleeDungeonComponent self, long cardId)
        {
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

            NumericComponentS numericComponentS = self.Player.GetComponent<NumericComponentS>();
            int num = numericComponentS.GetAsInt(NumericType.PetMeleeMoLi);
            int add = ConfigData.PetMeleeMoLiRPS * (int)(1 + numericComponentS.GetAsFloat(NumericType.PetMeleeMoLiAdd) );
            self.Player.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetMeleeMoLi,
                num +add > ConfigData.PetMeleeMoLiMax ? ConfigData.PetMeleeMoLiMax : num +add );
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
            self.StartTime = TimeInfo.Instance.ServerNow();

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

            if (self.Player == null)
            {
                return;
            }

            self.GameOver = true;

            M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
            m2C_FubenSettlement.BattleResult = combatResult;
            long nowTime = TimeInfo.Instance.ServerNow();
            // 先按通关时间来判断星星
            if (nowTime - self.StartTime <= 60 * 1000)
            {
                // 3星
                m2C_FubenSettlement.StarInfos = new List<int>() { 1, 1, 1 };
            }
            else if (nowTime - self.StartTime <= 120 * 1000)
            {
                // 2星
                m2C_FubenSettlement.StarInfos = new List<int>() { 1, 1, 0 };
            }
            else
            {
                // 1星
                m2C_FubenSettlement.StarInfos = new List<int>() { 1, 0, 0 };
            }

            if (combatResult == CombatResultEnum.Win)
            {
                NumericComponentS numericComponent = self.Player.GetComponent<NumericComponentS>();
                if (self.Scene().GetComponent<MapComponent>().SceneId > numericComponent.GetAsInt(NumericType.PetMeleeDungeonId))
                {
                    self.Player.GetComponent<NumericComponentS>()
                            .ApplyValue(NumericType.PetMeleeDungeonId, self.Scene().GetComponent<MapComponent>().SceneId);
                }

                int sceneId = self.Scene().GetComponent<MapComponent>().SceneId;
                // SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
                // m2C_FubenSettlement.ReardList.AddRange(rewardItems);
                // self.Player.GetComponent<BagComponentS>().OnAddItemData(sceneConfig.RewardShow, $"{ItemGetWay.PetMeleeReward}_{TimeHelper.ServerNow()}");

                int star = 0;
                for (int i = 0; i < m2C_FubenSettlement.StarInfos.Count; i++)
                {
                    star += m2C_FubenSettlement.StarInfos[i];
                }

                self.Player.GetComponent<PetComponentS>().OnPassPetMeleeFuben(sceneId, star);
            }

            MapMessageHelper.SendToClient(self.Player, m2C_FubenSettlement);
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