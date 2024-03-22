using System.Collections.Generic;

namespace ET.Server
{

    [EntitySystemOf(typeof(ChengJiuComponent_S))]
    [FriendOf(typeof(ChengJiuComponent_S))]
    public static partial class ChengJiuComponent_SSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ChengJiuComponent_S self)
        {

        }

        public static List<PropertyValue> GetJingLingProLists(this ChengJiuComponent_S self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();

            for (int i = 0; i < self.JingLingList.Count; i++)
            {
                JingLingConfig jinglingCof = JingLingConfigCategory.Instance.Get(self.JingLingList[i]);
                NumericHelp.GetProList(jinglingCof.AddProperty, proList);
            }

            if (self.JingLingId == 0)
            {
                return proList;
            }
            JingLingConfig lifeShieldConfig = JingLingConfigCategory.Instance.Get(self.JingLingId);
            // NumericHelp.GetProList(lifeShieldConfig.AddProperty, proList);
            if (lifeShieldConfig.FunctionType == JingLingFunctionType.AddProperty)
            {
                NumericHelp.GetProList(lifeShieldConfig.FunctionValue, proList);
            }

            return proList;
        }

        public static void OnLogin(this ChengJiuComponent_S self)
        {
            NumericComponent_S numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent_S>();
            if (self.Zone() <= 48 && numericComponent.GetAsLong(NumericType.RechargeNumber) < 400 && self.JingLingList.Contains(10003))
            {
                Log.Warning($"充值小于400有精灵龟: {self.Id}");
                self.JingLingList.Remove(10003);
                self.JingLingId = 0;
                self.JingLingUnitId = 0;
            }

            self.TriggerEvent(ChengJiuTargetEnum.PlayerLevel_205, 0, self.GetParent<Unit>().GetComponent<UserInfoComponent_S>().GetUserLv());
        }

        public static void OnZeroClockUpdate(this ChengJiuComponent_S self)
        {
            self.RandomDrop = 0;
        }

        //击杀怪物可触发多种类型的成就
        public static void OnKillUnit(this ChengJiuComponent_S self, Unit defend)
        {
            if (defend == null || defend.IsDisposed)
                return;

            if (defend.Type == UnitType.Player)
            {
                self.TriggerEvent(ChengJiuTargetEnum.KillPlayerNumber_209, 0, 1);
                //LogHelper.KillPlayerInfo(self.GetParent<Unit>(), defend);
            }
            if (defend.Type == UnitType.Monster)
            {
                int unitconfigId = defend.ConfigId;
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitconfigId);
                bool isBoss = monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss;
                MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
                int fubenDifficulty = (int)FubenDifficulty.None;
                if (mapComponent.SceneType == (int)SceneTypeEnum.CellDungeon)
                {
                    //fubenDifficulty = (int)self.GetParent<Unit>().Root().GetComponent<CellDungeonComponent>().FubenDifficulty;
                }
                if (mapComponent.SceneType == (int)SceneTypeEnum.LocalDungeon)
                {
                    //fubenDifficulty = (int)self.GetParent<Unit>().Root().GetComponent<LocalDungeonComponent>().FubenDifficulty;
                }

                self.TriggerEvent(ChengJiuTargetEnum.KillIDMonster_1, unitconfigId, 1);
                self.TriggerEvent(ChengJiuTargetEnum.KillTotalMonster_2, 0, 1);

                if (isBoss)
                {
                    self.TriggerEvent(ChengJiuTargetEnum.KillTotalBoss_3, 0, 1);
                    self.TriggerEvent(ChengJiuTargetEnum.KillNormalBoss_4, unitconfigId, 1);
                }
                if (fubenDifficulty >= (int)FubenDifficulty.TiaoZhan && isBoss) //挑战
                {
                    self.TriggerEvent(ChengJiuTargetEnum.KillChallengeBoss_5, unitconfigId, 1);
                }
                if (fubenDifficulty == (int)FubenDifficulty.DiYu && isBoss) //地狱
                {
                    self.TriggerEvent(ChengJiuTargetEnum.KillInfernalBoss_6, unitconfigId, 1);
                }
            }
        }

        public static void OnPassFuben(this ChengJiuComponent_S self, int difficulty, int chapterid, int star)
        {
            self.TriggerEvent(ChengJiuTargetEnum.PassNormalFubenID_11, chapterid, 1);
            if ((int)difficulty >= (int)FubenDifficulty.TiaoZhan)  //挑战
            {
                self.TriggerEvent(ChengJiuTargetEnum.PassChallengeFubenID_12, chapterid, 1);
            }
            if ((int)difficulty == (int)FubenDifficulty.DiYu)  //地狱
            {
                self.TriggerEvent(ChengJiuTargetEnum.PassInfernalFubenID_13, chapterid, 1);
            }
            if (star == 3 && (int)difficulty == (int)FubenDifficulty.DiYu)
            {
                self.TriggerEvent(ChengJiuTargetEnum.PerfectPassInfernalFubenID_14, chapterid, 1);
            }
        }

        public static void OnChouKaTen(this ChengJiuComponent_S self)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalChouKaTen_202, 0, 1);
        }

        public static void OnEquipXiLian(this ChengJiuComponent_S self, int times)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalEquipXiLian_203, 0, times);
        }

        public static void OnRevive(this ChengJiuComponent_S self)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalRevive_204, 0, 1);
        }

        public static void OnUpdateLevel(this ChengJiuComponent_S self, int lv)
        {
            self.TriggerEvent(ChengJiuTargetEnum.PlayerLevel_205, 0, lv);
        }

        public static void OnGetGold(this ChengJiuComponent_S self, int coin)
        {
            if (coin < 0)
            {
                self.TriggerEvent(ChengJiuTargetEnum.TotalCostGold_219, 0, coin * -1);
            }
            else
            {
                self.TriggerEvent(ChengJiuTargetEnum.TotalCoinGet_201, 0, coin);
            }
        }

        public static void OnGetPet(this ChengJiuComponent_S self, RolePetInfo rolePetInfo)
        {
            self.TriggerEvent(ChengJiuTargetEnum.PetIdNumber_301, rolePetInfo.ConfigId, 1);
            self.TriggerEvent(ChengJiuTargetEnum.TotalPetNumber_302, 0, 1);
            self.TriggerEvent(ChengJiuTargetEnum.PetNSkill_305, 0, rolePetInfo.PetSkill.Count);
        }

        public static void OnPetHeCheng(this ChengJiuComponent_S self, RolePetInfo rolePetInfo)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalPetHeCheng_303, 0, 1);
            self.TriggerEvent(ChengJiuTargetEnum.PetNSkill_305, 0, rolePetInfo.PetSkill.Count);
        }

        public static void OnPetXiLian(this ChengJiuComponent_S self, RolePetInfo rolePetInfo)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalPetXiLian_304, 0, 1);
            self.TriggerEvent(ChengJiuTargetEnum.PetNSkill_305, 0, rolePetInfo.PetSkill.Count);
        }

        public static void OnItemHuiShow(this ChengJiuComponent_S self, int itemNumber)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalEquipHuiShou_206, 0, itemNumber);
        }

        public static void OnCostDiamond(this ChengJiuComponent_S self, long costNumber)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalDiamondCost_207, 0, (int)(costNumber * -1));
        }

        public static void OnSkillShuLianDu(this ChengJiuComponent_S self, int shuLianDu)
        {
            self.TriggerEvent(ChengJiuTargetEnum.SkillShuLianDu_208, 0, shuLianDu);
        }

        public static int ReceivedReward(this ChengJiuComponent_S self, int rewardId)
        {
            if (self.AlreadReceivedId.Contains(rewardId))
            {
                return ErrorCode.ERR_Success;
            }

            ChengJiuRewardConfig chengJiuRewardConfig = ChengJiuRewardConfigCategory.Instance.Get(rewardId);
            bool success = self.GetParent<Unit>().GetComponent<BagComponent_S>().OnAddItemData(chengJiuRewardConfig.RewardItems, $"{ItemGetWay.ChengJiuRward}_{TimeHelper.ServerNow()}");
            if (success)
            {
                self.AlreadReceivedId.Add(rewardId);
                return ErrorCode.ERR_Success;
            }
            else
            {
                return ErrorCode.ERR_BagIsFull;
            }
        }

        public static void OnActiveJingLing(this ChengJiuComponent_S self, int jid)
        {
            if (self.JingLingList.Contains(jid))
            {
                return;
            }
            self.JingLingList.Add(jid);
        }

        public static void TriggerEvent(this ChengJiuComponent_S self, ChengJiuTargetEnum chengJiuTarget, int target_id, int target_value = 1)
        {
            int chengJiuTargetInt = (int)chengJiuTarget;
            List<int> chengjiuList = null;/// ChengJiuConfigCategory.Instance.GetChengJiuTargetData(chengJiuTargetInt);
            if (chengjiuList == null)
            {
                return;
            }

            for (int i = 0; i < chengjiuList.Count; i++)
            {
                bool exist = false;
                for (int k = 0; k < self.ChengJiuProgessList.Count; k++)
                {
                    if (self.ChengJiuProgessList[k].ChengJiuID == chengjiuList[i])
                    {
                        exist = true;
                    }
                    if (exist)
                    {
                        break;
                    }
                }
                if (exist || self.ChengJiuCompleteList.Contains(chengjiuList[i]))
                {
                    continue;
                }

                self.ChengJiuProgessList.Add(new ChengJiuInfo() { ChengJiuID = chengjiuList[i] });
            }

            for (int i = self.ChengJiuProgessList.Count - 1; i >= 0; i--)
            {
                ChengJiuInfo chengJiuInfo = self.ChengJiuProgessList[i];
                ChengJiuConfig chengJiuConfig = ChengJiuConfigCategory.Instance.Get(chengJiuInfo.ChengJiuID);
                if (chengJiuTargetInt != chengJiuConfig.TargetType)
                {
                    continue;
                }

                switch (chengJiuTarget)
                {
                    case ChengJiuTargetEnum.PlayerLevel_205:
                    case ChengJiuTargetEnum.SkillShuLianDu_208:
                    case ChengJiuTargetEnum.CombatToValue_211:
                    case ChengJiuTargetEnum.ZodiacEquipNumber_215:
                    case ChengJiuTargetEnum.PetNSkill_305:
                    case ChengJiuTargetEnum.PegScoreToValue_307:
                    case ChengJiuTargetEnum.PetArrayScoreToValue_308:
                    case ChengJiuTargetEnum.PetTianTiRank_309:
                    case ChengJiuTargetEnum.ZiZhiToValue_311:
                    case ChengJiuTargetEnum.ZiZhiUpValue_312:
                        if (target_id != chengJiuConfig.TargetID)
                        {
                            continue;
                        }
                        chengJiuInfo.ChengJiuProgess = target_value;
                        break;
                    case ChengJiuTargetEnum.JianDingEqipNumber_212:
                        if (target_id < chengJiuConfig.TargetID)
                        {
                            continue;
                        }
                        chengJiuInfo.ChengJiuProgess += target_value;
                        break;
                    default:
                        if (target_id != chengJiuConfig.TargetID)
                        {
                            continue;
                        }
                        chengJiuInfo.ChengJiuProgess += target_value;
                        break;
                }

                int acitiveId = 0;
                switch (chengJiuTarget)
                {
                    case ChengJiuTargetEnum.PetTianTiRank_309:
                        if (chengJiuInfo.ChengJiuProgess <= chengJiuConfig.TargetValue)
                        {
                            acitiveId = chengJiuInfo.ChengJiuID;
                            self.TotalChengJiuPoint += chengJiuConfig.RewardNum;
                            self.ChengJiuCompleteList.Add(chengJiuInfo.ChengJiuID);
                            self.ChengJiuProgessList.RemoveAt(i);
                        }
                        break;
                    case ChengJiuTargetEnum.ZiZhiUpValue_312:
                        if (chengJiuInfo.ChengJiuProgess > chengJiuConfig.TargetValue)
                        {
                            acitiveId = chengJiuInfo.ChengJiuID;
                            self.TotalChengJiuPoint += chengJiuConfig.RewardNum;
                            self.ChengJiuCompleteList.Add(chengJiuInfo.ChengJiuID);
                            self.ChengJiuProgessList.RemoveAt(i);
                        }
                        break;
                    default:
                        if (chengJiuInfo.ChengJiuProgess >= chengJiuConfig.TargetValue)
                        {
                            acitiveId = chengJiuInfo.ChengJiuID;
                            self.TotalChengJiuPoint += chengJiuConfig.RewardNum;
                            self.ChengJiuCompleteList.Add(chengJiuInfo.ChengJiuID);
                            self.ChengJiuProgessList.RemoveAt(i);
                        }
                        break;
                }

                if (acitiveId > 0 && !self.GetParent<UserInfoComponent_S>().IsRobot())
                {
                    MapMessageHelper.SendToClient(self.GetParent<Unit>(), new M2C_ChengJiuActiveMessage() { ChengJiuId = acitiveId });
                }
            }
        }
    }

}