using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;


namespace ET.Server
{

    [EntitySystemOf(typeof(ChengJiuComponentS))]
    [FriendOf(typeof(ChengJiuComponentS))]
    public static partial class ChengJiuComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this ChengJiuComponentS self)
        {

        }

        public static List<PropertyValue> GetJingLingProLists(this ChengJiuComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();

            for (int i = 0; i < self.JingLingList.Count; i++)
            {
                JingLingConfig jinglingCof = JingLingConfigCategory.Instance.Get(self.JingLingList[i].JingLingID);
                
                if (self.JingLingList[i].Progess < jinglingCof.NeedPoint)
                {
                    continue;
                }

                NumericHelp.GetProList(jinglingCof.AddProperty, proList);
            }

            JingLingInfo jingLingInfo = self.GetFightJingLing();
            if (jingLingInfo != null)
            {
                JingLingConfig lifeShieldConfig = JingLingConfigCategory.Instance.Get(jingLingInfo.JingLingID);
                // NumericHelp.GetProList(lifeShieldConfig.AddProperty, proList);
                if (lifeShieldConfig.FunctionType == JingLingFunctionType.AddProperty)
                {
                    NumericHelp.GetProList(lifeShieldConfig.FunctionValue, proList);
                }
            }

           
            return proList;
        }

        public static List<PropertyValue> GetPetTuJianProLists(this ChengJiuComponentS self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();

            for (int i = 0; i < self.PetTuJianActives.Count; i++)
            {
                // if (!PetTuJianConfigCategory.Instance.Contain(self.PetTuJianActives[i]))
                // {
                //     continue;
                // }
                //
                // PetTuJianConfig jinglingCof = PetTuJianConfigCategory.Instance.Get(self.PetTuJianActives[i]);
                // NumericHelp.GetProList(jinglingCof.AddProperty, proList);
            }

            
            return proList;
        }

        public static void CheckData(this ChengJiuComponentS self)
        {
            for (int i = self.ChengJiuProgessList.Count - 1; i >= 0; i--)
            {
                ChengJiuInfo chengJiuInfo = self.ChengJiuProgessList[i];

                if (!ChengJiuConfigCategory.Instance.Contain(chengJiuInfo.ChengJiuID))
                {
                    self.ChengJiuProgessList.RemoveAt(i);
                }
            }
        }

        public static void OnLogin(this ChengJiuComponentS self, int lv)
        {
            self.CheckData();
            self.TriggerEvent(ChengJiuTargetEnum.PlayerLevel_205, 0, lv, false);

            Dictionary<int, JingLingConfig> alljingling = JingLingConfigCategory.Instance.GetAll();
            foreach (var JingLingConfig in alljingling)
            {
                if (self.JingLingList.Where( p=>p.JingLingID == JingLingConfig.Key).Count() > 0)
                {
                    continue;
                }

                JingLingInfo jingLingInfo = JingLingInfo.Create();
                jingLingInfo.JingLingID = JingLingConfig.Key;
                self.JingLingList.Add( jingLingInfo );
            }
        }

        public static void OnZeroClockUpdate(this ChengJiuComponentS self)
        {
            self.RandomDrop = 0;
        }

        //击杀怪物可触发多种类型的成就
        public static void OnKillUnit(this ChengJiuComponentS self, Unit defend)
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
                MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
                if (mapComponent.MapType == MapTypeEnum.PetMelee || mapComponent.MapType == MapTypeEnum.PetMatch)
                {
                    return;
                }
                
                int unitconfigId = defend.ConfigId;
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitconfigId);
                bool isBoss = monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss;
               
                int fubenDifficulty = (int)FubenDifficulty.None;
                if (mapComponent.MapType == (int)MapTypeEnum.CellDungeon)
                {
                    fubenDifficulty = (int)self.Scene().GetComponent<CellDungeonComponentS>().FubenDifficulty;
                }
                if (mapComponent.MapType == (int)MapTypeEnum.LocalDungeon)
                {
                    fubenDifficulty = (int)self.Scene().GetComponent<LocalDungeonComponent>().FubenDifficulty;
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

                List<int> jinglingids = null;
                JingLingConfigCategory.Instance.JingLingActive.TryGetValue(defend.ConfigId, out jinglingids);
                if (jinglingids!=null)
                {
                    foreach (var jinglingid in jinglingids)
                    {
                        self.OnAddJingLingProgess(jinglingid);
                    }
                }
            }
        }
        
        
        public static void OnPassFuben(this ChengJiuComponentS self, int difficulty, int chapterid, int star)
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

        public static void OnChouKaTen(this ChengJiuComponentS self)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalChouKaTen_202, 0, 1);
        }

        public static void OnEquipXiLian(this ChengJiuComponentS self, int times)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalEquipXiLian_203, 0, times);
        }

        public static void OnRevive(this ChengJiuComponentS self)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalRevive_204, 0, 1);
        }

        public static void OnUpdateLevel(this ChengJiuComponentS self, int lv)
        {
            self.TriggerEvent(ChengJiuTargetEnum.PlayerLevel_205, 0, lv);
        }

        public static void OnGetGold(this ChengJiuComponentS self, int coin)
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

        public static void OnGetPet(this ChengJiuComponentS self, RolePetInfo rolePetInfo)
        {
            self.TriggerEvent(ChengJiuTargetEnum.PetIdNumber_301, rolePetInfo.ConfigId, 1);
            self.TriggerEvent(ChengJiuTargetEnum.TotalPetNumber_302, 0, 1);
            self.TriggerEvent(ChengJiuTargetEnum.PetNSkill_305, 0, rolePetInfo.PetSkill.Count);
        }

        public static void OnPetHeCheng(this ChengJiuComponentS self, RolePetInfo rolePetInfo)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalPetHeCheng_303, 0, 1);
            self.TriggerEvent(ChengJiuTargetEnum.PetNSkill_305, 0, rolePetInfo.PetSkill.Count);
        }

        public static void OnPetXiLian(this ChengJiuComponentS self, RolePetInfo rolePetInfo)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalPetXiLian_304, 0, 1);
            self.TriggerEvent(ChengJiuTargetEnum.PetNSkill_305, 0, rolePetInfo.PetSkill.Count);
        }

        public static void OnItemHuiShow(this ChengJiuComponentS self, int itemNumber)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalEquipHuiShou_206, 0, itemNumber);
        }

        public static void OnCostDiamond(this ChengJiuComponentS self, long costNumber)
        {
            self.TriggerEvent(ChengJiuTargetEnum.TotalDiamondCost_207, 0, (int)(costNumber * -1));
        }

        public static void OnSkillShuLianDu(this ChengJiuComponentS self, int shuLianDu)
        {
            self.TriggerEvent(ChengJiuTargetEnum.SkillShuLianDu_208, 0, shuLianDu);
        }

        public static int ReceivedReward(this ChengJiuComponentS self, int rewardId)
        {
            if (self.AlreadReceivedId.Contains(rewardId))
            {
                return ErrorCode.ERR_Success;
            }

            ChengJiuRewardConfig chengJiuRewardConfig = ChengJiuRewardConfigCategory.Instance.Get(rewardId);
            bool success = self.GetParent<Unit>().GetComponent<BagComponentS>().OnAddItemData(chengJiuRewardConfig.RewardItems, $"{ItemGetWay.ChengJiuRward}_{TimeHelper.ServerNow()}");
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

        //出战
        public static void OnFightJingLing(this ChengJiuComponentS self, int jid)
        {
            for (int i = 0; i < self.JingLingList.Count; i++)
            {
                self.JingLingList[i].State = jid == self.JingLingList[i].JingLingID ? 1 : 0;
            }
        }
        
        public static JingLingInfo GetFightJingLing(this ChengJiuComponentS self)
        {
            for (int i = 0; i < self.JingLingList.Count; i++)
            {
                if (self.JingLingList[i].State == 1)
                {
                    return self.JingLingList[i];
                }
            }

            return null;
        }

        public static void OpenAllJingLing(this ChengJiuComponentS self)
        {
            for (int i = 0; i < self.JingLingList.Count; i++)
            {
                JingLingInfo jingLingInfo = self.JingLingList[i];
              
                if (jingLingInfo.IsActive != 0)
                {
                    return;
                }
              
                JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jingLingInfo.JingLingID);
                jingLingInfo.Progess = jingLingConfig.NeedPoint;
                jingLingInfo.IsActive = 1;
            }
        }

        public static void OnActiveJingLing(this ChengJiuComponentS self, int jid)
        {
            for (int i = 0; i < self.JingLingList.Count; i++)
            {
                if (jid == self.JingLingList[i].JingLingID)
                {
                    JingLingInfo jingLingInfo = self.JingLingList[i];

                    if (jingLingInfo.IsActive != 0)
                    {
                        return;
                    }

                    JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jid);
                    if (jingLingInfo.Progess < jingLingConfig.NeedPoint)
                    {
                        return;
                    }

                    jingLingInfo.IsActive = 1;

                    M2C_JingLingActiveMessage m2CJingLingActiveMessage = M2C_JingLingActiveMessage.Create();
                    m2CJingLingActiveMessage.JingLingList = self.JingLingList;
                    MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2CJingLingActiveMessage);

                    return;
                }
            }
        }

        public static void OnAddJingLingProgess(this ChengJiuComponentS self, int jid)
        {
            for (int i = 0; i < self.JingLingList.Count; i++)
            {
                if (jid == self.JingLingList[i].JingLingID)
                {
                    JingLingInfo jingLingInfo = self.JingLingList[i];

                    if (jingLingInfo.IsActive != 0)
                    {
                        return;
                    }

                    JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jid);
                    if (jingLingInfo.Progess >= jingLingConfig.NeedPoint)
                    {
                        return;
                    }

                    if (jingLingConfig.GetWay == 2 && RandomHelper.RandFloat() <= jingLingConfig.ActivePro)
                    {
                        self.JingLingList[i].Progess = jingLingConfig.NeedPoint;
                    }
                    else
                    {
                        self.JingLingList[i].Progess++;
                    }

                    M2C_JingLingActiveMessage m2CJingLingActiveMessage = M2C_JingLingActiveMessage.Create();
                    m2CJingLingActiveMessage.JingLingList = self.JingLingList;
                    MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2CJingLingActiveMessage);

                    return;
                }
            }
        }

        public static void OpenAllPetTuJian(this ChengJiuComponentS self)
        {
             Dictionary<int, PetConfig> allpet = PetConfigCategory.Instance.GetAll();
             foreach (PetConfig petconfig in allpet.Values)
             {
                 self.OnPetTuJianActive( petconfig.Id, false );
             }
        }

        public static void OnPetTuJianActive(this ChengJiuComponentS self, int petId, bool notice)
        {
            if (self.PetTuJianActives.Contains(petId))
            {
                return;
            }
            
            self.PetTuJianActives.Add(petId);

            if (notice)
            {
                M2C_PetTuJianActiveMessage m2CJingLingActiveMessage = M2C_PetTuJianActiveMessage.Create();
                m2CJingLingActiveMessage.PetTuJianActives = self.PetTuJianActives;
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2CJingLingActiveMessage);
            }
        }

        public static void TriggerEvent(this ChengJiuComponentS self, ChengJiuTargetEnum chengJiuTarget, int target_id, int target_value = 1, bool notice = true)
        {
            int chengJiuTargetInt = (int)chengJiuTarget;
            List<int> chengjiuList = ChengJiuConfigCategory.Instance.GetChengJiuTargetData(chengJiuTargetInt);
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

                ChengJiuInfo ChengJiuInfo = ChengJiuInfo.Create();
                ChengJiuInfo.ChengJiuID = chengjiuList[i];
                self.ChengJiuProgessList.Add(ChengJiuInfo);
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

                if (notice && acitiveId > 0 && !self.GetParent<Unit>().GetComponent<UserInfoComponentS>().IsRobot())
                {
                    M2C_ChengJiuActiveMessage M2C_ChengJiuActiveMessage = M2C_ChengJiuActiveMessage.Create();
                    M2C_ChengJiuActiveMessage.ChengJiuId = acitiveId;
                    MapMessageHelper.SendToClient(self.GetParent<Unit>(), M2C_ChengJiuActiveMessage);
                }
            }
        }
    }

}