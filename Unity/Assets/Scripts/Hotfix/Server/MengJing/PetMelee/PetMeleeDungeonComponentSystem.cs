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
                self.SetGameOver(-1);
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

            foreach (List<PetMeleeCardInfo> cardInfos in self.PetMeleeCardInHand.Values)
            {
                foreach (PetMeleeCardInfo cardInfo in cardInfos)
                {
                    cardInfo.Dispose();
                }
            }

            self.PetMeleeCardInHand.Clear();

            foreach (List<PetMeleeCardInfo> PetMeleeCardInfos in self.PetMeleeCardPool.Values)
            {
                foreach (PetMeleeCardInfo cardInfo in PetMeleeCardInfos)
                {
                    cardInfo.Dispose();
                }
            }

            self.PetMeleeCardPool.Clear();
            self.UsedMainPetList.Clear();
            self.UsedSkillList.Clear();
        }

        private static void InitPlayerData(this PetMeleeDungeonComponent self, long playerId)
        {
            self.PetMeleeCardInHand.Add(playerId, new List<PetMeleeCardInfo>());
            self.PetMeleeCardPool.Add(playerId, new List<PetMeleeCardInfo>());
            self.UsedMainPetList.Add(playerId, new List<long>());
            self.UsedSkillList.Add(playerId, new List<int>());
        }

        public static void SetPlayer(this PetMeleeDungeonComponent self, Unit player)
        {
            self.InitPlayerData(player.Id);

            self.DealFirstCards(player);

            player.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetMeleeMoLi, ConfigData.PetMeleeMoLiBase);
        }

        private static PetMeleeCardInfo GetCardByRandom(this PetMeleeDungeonComponent self, Unit player)
        {
            PetMeleeCardInfo cardInfo = null;

            for (int i = 0; i < 10; i++)
            {
                float random = RandomHelper.RandFloat();

                if (random <= ConfigData.PetMeleeMainPetProb)
                {
                    cardInfo = self.CreateCard(PetMeleeCarType.MainPet, player);
                }
                else if (random <= ConfigData.PetMeleeMainPetProb + ConfigData.PetMeleeAssistPetProb)
                {
                    cardInfo = self.CreateCard(PetMeleeCarType.AssistPet, player);
                }
                else
                {
                    cardInfo = self.CreateCard(PetMeleeCarType.Magic, player);
                }

                if (cardInfo != null)
                {
                    break;
                }
            }

            if (cardInfo == null)
            {
                cardInfo = self.CreateCard(PetMeleeCarType.AssistPet, player);
            }

            return cardInfo;
        }

        // 发放初始卡牌
        private static void DealFirstCards(this PetMeleeDungeonComponent self, Unit player)
        {
            for (int i = 0; i < ConfigData.PetMeleeFirstMainPetNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.MainPet, player);

                if (cardInfo != null)
                {
                    self.PetMeleeCardInHand[player.Id].Add(cardInfo);
                }
            }

            for (int i = 0; i < ConfigData.PetMeleeFirstAssistPetNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.AssistPet, player);

                if (cardInfo != null)
                {
                    self.PetMeleeCardInHand[player.Id].Add(cardInfo);
                }
            }

            for (int i = 0; i < ConfigData.PetMeleeFirstMagicNum; i++)
            {
                PetMeleeCardInfo cardInfo = self.CreateCard(PetMeleeCarType.Magic, player);

                if (cardInfo != null)
                {
                    self.PetMeleeCardInHand[player.Id].Add(cardInfo);
                }
            }
        }

        private static PetMeleeCardInfo CreateCard(this PetMeleeDungeonComponent self, PetMeleeCarType petMeleeCarType, Unit player)
        {
            PetComponentS petcomponent = player.GetComponent<PetComponentS>();
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
                        if (self.UsedMainPetList[player.Id].Contains(id))
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

                    self.UsedMainPetList[player.Id].Add(cards[index]);

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
                        if (petMagicCardConfig.IsOnly == 1 && self.UsedSkillList[player.Id].Contains(id))
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

                    self.UsedSkillList[player.Id].Add(cards[index]);

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

            List<Unit> players = FubenHelp.GetUnitList(self.Scene(), UnitType.Player);
            foreach (Unit player in players)
            {
                self.DealCardsByPlayer(player);
            }
        }

        public static void DealCardsByPlayer(this PetMeleeDungeonComponent self, Unit player)
        {
            if (self.GameOver)
            {
                return;
            }

            PetMeleeCardInfo cardInfo = self.GetCardByRandom(player);

            if (cardInfo == null)
            {
                return;
            }

            if (self.PetMeleeCardInHand[player.Id].Count >= ConfigData.PetMeleeCarInHandNum)
            {
                self.PetMeleeCardPool[player.Id].Add(cardInfo);
                return;
            }

            self.PetMeleeCardInHand[player.Id].Add(cardInfo);

            M2C_PetMeleeDealCards message = M2C_PetMeleeDealCards.Create();
            message.PetMeleeCardList.Add(cardInfo);
            MapMessageHelper.SendToClient(player, message);
        }

        // 用牌
        public static int UseCard(this PetMeleeDungeonComponent self, long cardId, float3 position, long targetUnitId, Unit player)
        {
            if (self.GameOver)
            {
                return ErrorCode.ERR_ModifyData;
            }

            PetMeleeCardInfo useCard = null;
            foreach (PetMeleeCardInfo cardInfo in self.PetMeleeCardInHand[player.Id])
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
                if (player.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeMoLi) < ConfigData.PetMeleeMainPetCost)
                {
                    return ErrorCode.ERR_PetMelee_MoLiNoEnough;
                }
                else
                {
                    player.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetMeleeMoLi, -ConfigData.PetMeleeMainPetCost);
                }

                PetComponentS petComponent = player.GetComponent<PetComponentS>();
                RolePetInfo rolePetInfo = petComponent.GetPetInfo(useCard.PetId);
                if (rolePetInfo == null)
                {
                    return ErrorCode.ERR_Pet_NoExist;
                }

                int petnumber = 0;
                List<Unit> allpet = UnitHelper.GetUnitList(self.Scene(), UnitType.Pet);
                for (int petindex = 0; petindex < allpet.Count; petindex++)
                {
                    if (allpet[petindex].GetMasterId() == player.Id)
                    {
                        petnumber++;
                    }
                }

                if (petnumber >= ConfigData.PetMeleeMaxPetsInLine)
                {
                    return ErrorCode.ERR_PetMelee_PetNumMax;
                }

                // // 不能存在相同的宠物
                // if (unit.GetParent<UnitComponent>().Get(request.PetId) != null)
                // {
                //     response.Error = ErrorCode.ERR_RequestRepeatedly;
                //     return;
                // }

                Unit pet = UnitFactory.CreateTianTiPet(self.Scene(), player.Id, player.GetBattleCamp(), rolePetInfo, position, 90, -1);
                if (self.GameStart)
                {
                    pet.GetComponent<AIComponent>().Begin();
                }
            }
            else if (useCard.Type == (int)PetMeleeCarType.AssistPet)
            {
                int cost = GlobalValueConfigCategory.Instance.PetMeleeCostMoLi;

                if (player.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeMoLi) < cost)
                {
                    return ErrorCode.ERR_PetMelee_MoLiNoEnough;
                }
                else
                {
                    player.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetMeleeMoLi, -cost);
                }

                PetComponentS petComponent = player.GetComponent<PetComponentS>();

                int petnumber = 0;
                List<Unit> allpet = UnitHelper.GetUnitList(self.Scene(), UnitType.Pet);
                for (int petindex = 0; petindex < allpet.Count; petindex++)
                {
                    if (allpet[petindex].GetMasterId() == player.Id)
                    {
                        petnumber++;
                    }
                }

                if (petnumber >= ConfigData.PetMeleeMaxPetsInLine)
                {
                    return ErrorCode.ERR_PetMelee_PetNumMax;
                }

                Unit pet = UnitFactory.CreateTianTiPet(self.Scene(), player.Id, player.GetBattleCamp(),
                    petComponent.GenerateNewPetByPetTuJianConfigId(useCard.ConfigId), position, 90, -1, IdGenerater.Instance.GenerateId());

                if (self.GameStart)
                {
                    pet.GetComponent<AIComponent>().Begin();
                }
            }
            else if (useCard.Type == (int)PetMeleeCarType.Magic)
            {
                PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(useCard.ConfigId);
                if (player.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeMoLi) < petMagicCardConfig.Cost)
                {
                    return ErrorCode.ERR_PetMelee_MoLiNoEnough;
                }
                else
                {
                    player.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetMeleeMoLi, -petMagicCardConfig.Cost);
                }

                float3 direction = position - player.Position;
                float ange = math.degrees(math.atan2(direction.x, direction.z));

                // 暂时是让主角使用技能
                C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                cmd.SkillID = petMagicCardConfig.SkillId;
                cmd.TargetAngle = (int)math.floor(ange);
                cmd.TargetDistance = math.distance(position, player.Position);
                cmd.TargetID = targetUnitId;
                player.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, false);
            }

            self.PetMeleeCardInHand[player.Id].Remove(useCard);
            useCard.Dispose();

            return ErrorCode.ERR_Success;
        }

        public static int DisposeCard(this PetMeleeDungeonComponent self, long cardId, Unit player)
        {
            PetMeleeCardInfo useCard = null;
            foreach (PetMeleeCardInfo cardInfo in self.PetMeleeCardInHand[player.Id])
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

            self.PetMeleeCardInHand[player.Id].Remove(useCard);
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

            List<Unit> players = FubenHelp.GetUnitList(self.Scene(), UnitType.Player);
            foreach (Unit player in players)
            {
                self.RestoreByPlayer(player);
            }
        }

        public static void RestoreByPlayer(this PetMeleeDungeonComponent self, Unit player)
        {
            if (self.GameOver)
            {
                return;
            }

            NumericComponentS numericComponentS = player.GetComponent<NumericComponentS>();
            int num = numericComponentS.GetAsInt(NumericType.PetMeleeMoLi);
            int add = ConfigData.PetMeleeMoLiRPS * (int)(1 + numericComponentS.GetAsFloat(NumericType.PetMeleeMoLiAdd));
            player.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetMeleeMoLi,
                num + add > ConfigData.PetMeleeMoLiMax ? ConfigData.PetMeleeMoLiMax : num + add);
        }

        public static bool IsGameStart(this PetMeleeDungeonComponent self)
        {
            return self.GameStart;
        }

        public static bool IsGameOver(this PetMeleeDungeonComponent self)
        {
            return self.GameOver;
        }

        public static void SetGameStart(this PetMeleeDungeonComponent self, Unit player, int mapType)
        {
            if (!self.BegingPlayers.Contains(player.Id))
            {
                self.BegingPlayers.Add(player.Id);
            }

            if (mapType == 2 && self.BegingPlayers.Count < 2)
            {
                return;
            }

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

        public static void SetGameOver(this PetMeleeDungeonComponent self, int winCamp)
        {
            if (self.GameOver)
            {
                return;
            }

            self.GameOver = true;

            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            for (int playerindex = 0; playerindex < players.Count; playerindex++)
            {
                Unit player = players[playerindex];
                int combatResult = winCamp == player.GetBattleCamp() ? CombatResultEnum.Win : CombatResultEnum.Fail;

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

                MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
                if (mapComponent.MapType == MapTypeEnum.PetMelee &&  combatResult == CombatResultEnum.Win)
                {
                    int sceneId = mapComponent.SceneId;
                    NumericComponentS numericComponent = player.GetComponent<NumericComponentS>();
                    if (sceneId > numericComponent.GetAsInt(NumericType.PetMeleeDungeonId))
                    {
                        player.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetMeleeDungeonId, self.Scene().GetComponent<MapComponent>().SceneId);
                    }
                    
                    int star = 0;
                    for (int i = 0; i < m2C_FubenSettlement.StarInfos.Count; i++)
                    {
                        star += m2C_FubenSettlement.StarInfos[i];
                    }

                    player.GetComponent<PetComponentS>().OnPassPetMeleeFuben(sceneId, star);
                }

                if (mapComponent.MapType == MapTypeEnum.PetMatch)
                {
                    self.Scene().GetParent<PetMatchSceneComponent>().OnUpdateScore(player.Id, combatResult);
                }

                MapMessageHelper.SendToClient(player, m2C_FubenSettlement);
            }
        }

        private static void GenerateFuben(this PetMeleeDungeonComponent self)
        {
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();

            FubenHelp.CreateMonsterList(self.Scene(), SceneConfigCategory.Instance.Get(mapComponent.SceneId).CreateMonsterPosi);
        }

        public static void KickOutPlayer(this PetMeleeDungeonComponent self)
        {
            //Console.WriteLine($"PetMeleeDungeonComponent no handler!!!");
            C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
            actor_Transfer.SceneType = MapTypeEnum.MainCityScene;
            List<EntityRef<Unit>> units = self.Scene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.Type != UnitType.Player)
                {
                    continue;
                }

                if (unit.IsDisposed || unit.IsRobot())
                {
                    continue;
                }
                
                TransferHelper.TransferUnit(units[i], actor_Transfer).Coroutine();
            }
        }

        public static void OnUnitReturn(this PetMeleeDungeonComponent self, long unitid)
        {
            //玩家离开 机器人需要退场
            List<Unit> units = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            if (units.Count != 1)
            {
                return;
            }

            if (!units[0].IsRobot())
            {
                return;
            }

            C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
            actor_Transfer.SceneType = MapTypeEnum.MainCityScene;
            TransferHelper.TransferUnit(units[0], actor_Transfer).Coroutine();
        }

        public static void OnKillEvent(this PetMeleeDungeonComponent self, Unit defend, int mapType)
        {
            if (self.GameOver)
            {
                return;
            }

            if (defend.Type != UnitType.Monster)
            {
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(defend.ConfigId);
            if (monsterConfig.MonsterSonType != MonsterSonTypeEnum.Type_62)
            {
                return;
            }

            self.Scene().RemoveComponent<YeWaiRefreshComponent>();
            int battleCamp = defend.GetBattleCamp();
            self.SetGameOver(battleCamp == CampEnum.CampPlayer_1 ? CampEnum.CampPlayer_2 : CampEnum.CampPlayer_1);
        }
    }
}