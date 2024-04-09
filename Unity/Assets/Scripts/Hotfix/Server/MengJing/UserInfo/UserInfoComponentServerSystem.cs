using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof (UserInfoComponentS))]
    [EntitySystemOf(typeof (UserInfoComponentS))]
    public static partial class UserInfoComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this UserInfoComponentS self)
        {
        }

        [EntitySystem]
        private static void Destroy(this UserInfoComponentS self)
        {
        }

        public static void OnInit(this UserInfoComponentS self, string account, long id, long accountId, CreateRoleInfo createRoleInfo)
        {
             self.Account = account;
             self.UserInfo = new UserInfo();
            UserInfo userInfo = self.UserInfo;
            userInfo.Sp = 1;
            userInfo.UserId = id;
            userInfo.BaoShiDu = 100;
            userInfo.JiaYuanLv = 10001;
            userInfo.JiaYuanFund = 10000;
            userInfo.AccInfoID = accountId;
            userInfo.Name = "";
            userInfo.ServerMailIdCur = -1;
            userInfo.PiLao = int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);        //初始化疲劳
            userInfo.Vitality = int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);
            userInfo.MakeList.AddRange(ComHelp.StringArrToIntList(GlobalValueConfigCategory.Instance.Get(18).Value.Split(';')));
            userInfo.CreateTime = TimeHelper.ServerNow();
            userInfo.RobotId = createRoleInfo.RobotId;

            if (createRoleInfo.RobotId > 0)
            {
                int robotId = createRoleInfo.RobotId;
                RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
                userInfo.Lv = robotConfig.Behaviour == 1 ?  RandomHelper.RandomNumber(10, 19) : robotConfig.Level;
                userInfo.Occ = robotConfig.Behaviour == 1 ?  RandomHelper.RandomNumber(1, 3) : robotConfig.Occ;
                userInfo.Gold = 100000;
                userInfo.RobotId = robotId;
                //userInfo.OccTwo = robotConfig.OccTwo;
            }
            else
            {
                userInfo.Lv = 1;
                userInfo.Gold = 0;
                userInfo.SeasonLevel = 1;
                userInfo.Occ = createRoleInfo.PlayerOcc;
                userInfo.Name = createRoleInfo.PlayerName;
            }
        }

        public static void UpdateRoleMoneyAdd(this UserInfoComponentS self, int Type, string value, bool notice, int getWay,
        string paramsifo = "")
        {
            Unit unit = self.GetParent<Unit>();
            long gold = long.Parse(value);
            if (gold < 0)
            {
                // Log.Warning($"增加货币出错:{Type}  {unit.Id} {getWay} {self.UserInfo.Name}  {value}", true);
            }
            else
            {
                if (getWay != ItemGetWay.PickItem || gold > 1000)
                {
                    // LogHelper.LogWarning($"增加货币:{Type} {unit.Id} {getWay} {self.UserInfo.Name}  {value}", true);
                }
            }

            if (gold > 100000 || gold < -100000)
            {
                // Log.Warning($"增加货币[大额]:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }
            else if (gold > 1000000 || gold < -1000000)
            {
                // Log.Warning($"增加货币[超额]:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }

            // if (self.UserInfo.AccInfoID == 2216719689042690056
            //     || self.UserInfo.AccInfoID == 7330971014316759846
            //     || self.RemoteAddress.Contains("36.148.134.236")
            //     || self.DeviceName.Equals("OPPO PCLM10_1920:1080"))
            // {
            //     Log.Warning($"增加货币[作弊]:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            // }

            if (gold > 0 && getWay == ItemGetWay.PaiMaiSell)
            {
                // unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.PaiMaiGetGoldNumber_217, 0, (int)gold);
            }

            if (Type == UserDataType.Diamond && !self.UserInfo.DiamondGetWay.Contains(getWay))
            {
                self.UserInfo.DiamondGetWay.Add(getWay);
            }

            if (Type == UserDataType.Diamond)
            {
                // Log.Warning($"增加钻石:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }

            if (Type == UserDataType.UnionExp || Type == UserDataType.UnionGold)
            {
                // self.SendUnionOperate(getWay, Type, gold).Coroutine();
            }

            self.UpdateRoleData(Type, value, notice);
        }

        //扣金币
        public static void UpdateRoleMoneySub(this UserInfoComponentS self, int Type, string value, bool notice = true,
        int getWay = ItemGetWay.System,
        string paramsifo = "")
        {
            Unit unit = self.GetParent<Unit>();
            long gold = long.Parse(value);
            if (gold > 0)
            {
                // LogHelper.LogWarning($"扣除货币出错:{Type} {unit.Id} {getWay} {self.UserInfo.Name}  {value}", true);
            }
            else
            {
                // LogHelper.LogWarning($"扣除货币:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }

            if (gold > 100000 || gold < -100000)
            {
                // LogHelper.LogWarning($"扣除货币[大额]:{Type} {unit.Id} {getWay} {self.UserInfo.Name} {value}", true);
            }

            // unit.GetComponent<DataCollationComponent>().UpdateRoleMoneySub(Type, getWay, gold);
            self.UpdateRoleData(Type, value, notice);
        }

        public static void UpdateRoleData(this UserInfoComponentS self, int Type, string value, bool notice = true)
        {
            Unit unit = self.GetParent<Unit>();
            string saveValue = "";
            long longValue = 0;
            switch (Type)
            {
                //case UserDataType.UnionExp:
                //    int addexp = int.Parse(value);
                //    self.SendUnionOperate(1, addexp).Coroutine();
                //    return;
                //case UserDataType.UnionGold:
                //    self.SendUnionOperate(5, int.Parse(value)).Coroutine();
                //    return;
                case UserDataType.JiaYuanExp:
                    self.UserInfo.JiaYuanExp += int.Parse(value);
                    saveValue = self.UserInfo.JiaYuanExp.ToString();
                    break;
                case UserDataType.JiaYuanFund:
                    self.UserInfo.JiaYuanFund += int.Parse(value);
                    saveValue = self.UserInfo.JiaYuanFund.ToString();
                    break;
                case UserDataType.UnionContri:
                    self.UserInfo.UnionZiJin += int.Parse(value);
                    saveValue = self.UserInfo.UnionZiJin.ToString();
                    break;
                case UserDataType.SeasonCoin:
                    self.UserInfo.SeasonCoin += int.Parse(value);
                    saveValue = self.UserInfo.SeasonCoin.ToString();
                    break;
                case UserDataType.SeasonExp:
                    self.UserInfo.SeasonExp += int.Parse(value);
                    SeasonLevelConfig seasonLevelConfig = SeasonLevelConfigCategory.Instance.Get(self.UserInfo.SeasonLevel);
                    if (self.UserInfo.SeasonExp >= seasonLevelConfig.UpExp &&
                        SeasonLevelConfigCategory.Instance.Contain(self.UserInfo.SeasonLevel + 1))
                    {
                        self.UserInfo.SeasonExp -= seasonLevelConfig.UpExp;
                        self.UpdateRoleData(UserDataType.SeasonLevel, "1");
                    }

                    saveValue = self.UserInfo.SeasonExp.ToString();
                    longValue = self.UserInfo.SeasonExp;
                    break;
                case UserDataType.SeasonLevel:
                    self.UserInfo.SeasonLevel += int.Parse(value);
                    saveValue = self.UserInfo.SeasonLevel.ToString();
                    break;
                case UserDataType.JiaYuanLv:
                    self.UserInfo.JiaYuanLv += int.Parse(value);
                    saveValue = self.UserInfo.JiaYuanLv.ToString();
                    // unit.GetComponent<TaskComponent>().TriggerTaskEvent(TaskTargetType.JiaYuanLevel_22, 0, self.UserInfo.JiaYuanLv - 10000);
                    // unit.GetComponent<TaskComponent>().TriggerTaskCountryEvent(TaskTargetType.JiaYuanLevel_22, 0, self.UserInfo.JiaYuanLv - 10000);
                    // unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.JiaYuanLevel_404, 0, self.UserInfo.JiaYuanLv - 10000);
                    break;
                case UserDataType.FangRong:
                    // LingDiHelp.OnAddLingDiExp(unit, int.Parse(value), notice);
                    break;
                //名字应该在改名的协议处理
                case UserDataType.Name:
                    self.UserInfo.Name = value;
                    saveValue = self.UserInfo.Name;
                    break;
                case UserDataType.Exp:
                    // self.Role_AddExp(long.Parse(value), notice);
                    //saveValue = self.UserInfo.Exp.ToString();
                    longValue = self.UserInfo.Exp;
                    break;
                case UserDataType.Lv:
                    self.UserInfo.Lv += int.Parse(value);
                    saveValue = self.UserInfo.Lv.ToString();
                    long maxHp = unit.GetComponent<NumericComponentS>().GetAsLong((int)NumericType.Now_MaxHp);
                    unit.GetComponent<NumericComponentS>().Set(NumericType.Now_Hp, maxHp);
                    unit.GetComponent<NumericComponentS>().Set(NumericType.PointRemain, int.Parse(value) * 10);
                    // unit.GetComponent<TaskComponent>().OnUpdateLevel(self.UserInfo.Lv);
                    // unit.GetComponent<ChengJiuComponent>().OnUpdateLevel(self.UserInfo.Lv);
                    // unit.GetComponent<HeroDataComponent>().CheckSeasonOpen(true);
                    self.UpdateRoleData(UserDataType.Sp, value, notice);
                    // Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                    break;
                case UserDataType.Sp:
                    self.UserInfo.Sp += int.Parse(value);
                    saveValue = self.UserInfo.Sp.ToString();
                    break;
                case UserDataType.Gold:
                    self.UserInfo.Gold += long.Parse(value);
                    saveValue = self.UserInfo.Gold.ToString();
                    // unit.GetComponent<ChengJiuComponent>().OnGetGold(int.Parse(value));
                    // unit.GetComponent<TaskComponent>().OnCostCoin(int.Parse(value));
                    break;
                case UserDataType.RongYu:
                    self.UserInfo.RongYu += long.Parse(value);
                    saveValue = self.UserInfo.RongYu.ToString();
                    break;
                case UserDataType.Diamond:
                    long addDiamond = long.Parse(value);
                    self.UserInfo.Diamond += addDiamond;
                    self.UserInfo.Diamond = Math.Max(self.UserInfo.Diamond, 0);
                    saveValue = self.UserInfo.Diamond.ToString();
                    if (addDiamond < 0)
                    {
                        // unit.GetComponent<ChengJiuComponent>().OnCostDiamond(addDiamond);
                        // unit.GetComponent<NumericComponent>().ApplyChange(null, NumericType.V1DayCostDiamond, addDiamond * -1, 0);
                    }

                    break;
                case UserDataType.Occ:
                    break;
                case UserDataType.InvestMent:
                    // unit.GetComponent<NumericComponent>().ApplyChange(null, NumericType.InvestMent, long.Parse(value), 0);
                    // unit.GetComponent<NumericComponent>().ApplyChange(null, NumericType.InvestTotal, long.Parse(value), 0);
                    break;
                case UserDataType.JueXingExp:
                    // unit.GetComponent<NumericComponent>().ApplyChange(null, NumericType.JueXingExp, long.Parse(value), 0);
                    break;
                case UserDataType.MaoXianExp:
                    // unit.GetComponent<NumericComponent>().ApplyChange(null, NumericType.MaoXianExp, long.Parse(value), 0);
                    break;
                case UserDataType.Recharge:
                    // RechargeHelp.SendDiamondToUnit(unit, int.Parse(value), "道具");
                    break;
                case UserDataType.PiLao:
                    if (value == "0")
                    {
                        return;
                    }

                    // int maxValue = unit.IsYueKaStates()? int.Parse(GlobalValueConfigCategory.Instance.Get(26).Value)
                    //         : int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);
                    // long newValue = long.Parse(value) + self.UserInfo.PiLao;
                    // newValue = Math.Min(Math.Max(0, newValue), maxValue);
                    // self.UserInfo.PiLao = newValue;
                    // saveValue = self.UserInfo.PiLao.ToString();
                    break;
                case UserDataType.BaoShiDu:
                    long addValue = long.Parse(value);
                    // newValue = self.UserInfo.BaoShiDu + (int)addValue;
                    // newValue = Math.Min(Math.Max(0, newValue), ComHelp.GetMaxBaoShiDu());
                    // self.UserInfo.BaoShiDu = (int)newValue;
                    // saveValue = self.UserInfo.BaoShiDu.ToString();
                    // unit.GetComponent<BuffManagerComponent>()?.InitBaoShiBuff();
                    break;
                case UserDataType.HuoYue:
                    break;
                case UserDataType.DungeonTimes:
                    // unit.GetComponent<NumericComponent>().ApplyValue(NumericType.TeamDungeonTimes, unit.GetTeamDungeonTimes() - 1);
                    // unit.GetComponent<NumericComponent>().ApplyValue(NumericType.TeamDungeonXieZhu, unit.GetTeamDungeonXieZhu() - 1);
                    self.UserInfo.DayFubenTimes.Clear();
                    break;
                case UserDataType.UnionName:
                    self.UserInfo.UnionName = value;
                    saveValue = self.UserInfo.UnionName;
                    break;
                case UserDataType.DemonName:
                    self.UserInfo.DemonName = value;
                    saveValue = self.UserInfo.DemonName;
                    break;
                case UserDataType.StallName:
                    self.UserInfo.StallName = value;
                    saveValue = self.UserInfo.StallName;
                    break;
                case UserDataType.Combat:
                    self.UserInfo.Combat = int.Parse(value);
                    saveValue = self.UserInfo.Combat.ToString();
                    // unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.CombatToValue_211, 0, self.UserInfo.Combat);
                    // unit.GetComponent<TaskComponent>().TriggerTaskEvent(TaskTargetType.CombatToValue_133, 0, self.UserInfo.Combat);
                    break;
                case UserDataType.Vitality:
                    // NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
                    // int skillNumber = 1 + numericComponent.GetAsInt(NumericType.MakeType_2) > 0? 1 : 0;
                    // maxValue = unit.GetMaxHuoLi(skillNumber);
                    // addValue = long.Parse(value);
                    // newValue = self.UserInfo.Vitality + (int)addValue;
                    // newValue = Math.Min(Math.Max(0, newValue), maxValue);
                    // self.UserInfo.Vitality = (int)newValue;
                    saveValue = self.UserInfo.Vitality.ToString();
                    break;
                case UserDataType.BuffSkill:
                    longValue = long.Parse(value);
                    break;
                default:
                    saveValue = value;
                    break;
            }

            //发送更新值
            if (notice)
            {
                M2C_RoleDataUpdate m2C_RoleDataUpdate1 = self.m2C_RoleDataUpdate;
                m2C_RoleDataUpdate1.UpdateType = (int)Type;
                m2C_RoleDataUpdate1.UpdateTypeValue = saveValue;
                m2C_RoleDataUpdate1.UpdateValueLong = longValue;
                MapMessageHelper.SendToClient(self.GetParent<Unit>(), m2C_RoleDataUpdate1);
            }
        }
        
        public static int GetDayItemUse(this UserInfoComponentS self, int mysteryId)
        {
            for (int i = 0; i < self.UserInfo.DayItemUse.Count; i++)
            {
                if (self.UserInfo.DayItemUse[i].KeyId == mysteryId)
                {
                    return (int)self.UserInfo.DayItemUse[i].Value;
                }
            }
            return 0;
        }

        public static bool IsRobot(this UserInfoComponentS self)
        {
            return self.UserInfo.RobotId > 0;
        }

        public static int GetUserLv(this UserInfoComponentS self)
        {
            return self.UserInfo.Lv;
        }

        public static List<int> GetPetExploreRewardIds(this UserInfoComponentS self)
        {
            return self.UserInfo.PetExploreRewardIds;
        }

        public static int GetSp(this UserInfoComponentS self)
        {
            return self.UserInfo.Sp;
        }

        public static void SetUserLv(this UserInfoComponentS self, int lv)
        {
            self.UserInfo.Lv = lv;
        }

        public static long GetPiLao(this UserInfoComponentS self)
        {
            return self.UserInfo.PiLao;
        }

        public static long GetGold(this UserInfoComponentS self)
        {
            return self.UserInfo.Gold;
        }

        public static long GetDiamond(this UserInfoComponentS self)
        {
            return self.UserInfo.Diamond;
        }

        public static string GetUnionName(this UserInfoComponentS self)
        {
            return self.UserInfo.UnionName;
        }
        
        public static int GetVitality(this UserInfoComponentS self)
        {
            return self.UserInfo.Vitality;
        }
        
        public static long GetJiaYuanFund(this UserInfoComponentS self)
        {
            return self.UserInfo.JiaYuanFund;
        }
        
        public static int GetCombat(this UserInfoComponentS self)
        {
            return self.UserInfo.Combat;
        }

        public static int GetOcc(this UserInfoComponentS self)
        {
            return self.UserInfo.Occ;
        }
        
        public static int GetRobotId(this UserInfoComponentS self)
        {
            return self.UserInfo.RobotId;
        }

        public static string GetName(this UserInfoComponentS self)
        {
            return self.UserInfo.Name;
        }

        public static int GetOccTwo(this UserInfoComponentS self)
        {
            return self.UserInfo.OccTwo;
        }

        public static void SetOccTwo(this UserInfoComponentS self, int  occTwo)
        {
            self.UserInfo.OccTwo = 0;
        }

        public static int GetJiaYuanLv(this UserInfoComponentS self)
        {
            return self.UserInfo.JiaYuanLv;
        }

        public static void OnCleanBossCD(this UserInfoComponentS self)
        {
            for (int i = 0; i < self.UserInfo.MonsterRevives.Count; i++)
            {
                self.UserInfo.MonsterRevives[i].Value = "0";
            }
        }
        
        public static void OnHorseActive(this UserInfoComponentS self, int horseId, bool active)
        {
            if (active && !self.UserInfo.HorseIds.Contains(horseId))
            {
                self.UserInfo.HorseIds.Add(horseId);
            }
            if (!active && self.UserInfo.HorseIds.Contains(horseId))
            {
                self.UserInfo.HorseIds.Remove(horseId);
            }
        }

        public static int GetCrateDay(this UserInfoComponentS self)
        {
            return 1;
        }

        public static long GetReviveTime(this UserInfoComponentS self, int monsterId)
        {
            return 0;

        }

        public static void OnDayItemUse(this UserInfoComponentS self, int itemId)
        {
            for (int i = 0; i < self.UserInfo.DayItemUse.Count; i++)
            {
                if (self.UserInfo.DayItemUse[i].KeyId == itemId)
                {
                    self.UserInfo.DayItemUse[i].Value += 1;
                    return;
                }
            }
            self.UserInfo.DayItemUse.Add(new KeyValuePairInt() { KeyId = itemId, Value = 1 });
        }
        
        public static long GetSceneFubenTimes(this UserInfoComponentS self, int sceneId)
        {
            for (int i = 0; i < self.UserInfo.DayFubenTimes.Count; i++)
            {
                if (self.UserInfo.DayFubenTimes[i].KeyId == sceneId)
                {
                    return self.UserInfo.DayFubenTimes[i].Value;
                }
            }
            return 0;
        }
        
        public static void AddSceneFubenTimes(this UserInfoComponentS self, int sceneId)
        {
            for (int i = 0; i < self.UserInfo.DayFubenTimes.Count; i++)
            {
                if (self.UserInfo.DayFubenTimes[i].KeyId == sceneId)
                {
                    self.UserInfo.DayFubenTimes[i].Value++;
                    return;
                }
            }
            self.UserInfo.DayFubenTimes.Add(new KeyValuePairInt() { KeyId = sceneId, Value = 1 });
        }
        
        public static int GetMonsterKillNumber(this UserInfoComponentS self, int monsterId)
        {
            for (int i = 0; i < self.UserInfo.MonsterRevives.Count; i++)
            {
                KeyValuePair keyValuePair = self.UserInfo.MonsterRevives[i];
                if (keyValuePair.KeyId != monsterId)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(keyValuePair.Value2))
                {
                    return int.Parse(keyValuePair.Value2);
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }
        
        public static void OnAddRevive(this UserInfoComponentS self, int monsterId, long reviveTime)
        {
            bool have = false;  
            for (int i = 0; i < self.UserInfo.MonsterRevives.Count; i++)
            {
                KeyValuePair keyValuePair = self.UserInfo.MonsterRevives[i];
                if (keyValuePair.KeyId != monsterId)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(keyValuePair.Value2))
                {
                    keyValuePair.Value2 = "1";
                }

                keyValuePair.Value = reviveTime.ToString();
                keyValuePair.Value2 = (int.Parse(keyValuePair.Value2) + 1).ToString();  
                have = true;
                break;
            }
            if (!have)
            {
                self.UserInfo.MonsterRevives.Add(new KeyValuePair() { KeyId = monsterId, Value = reviveTime.ToString(), Value2 = "1" });
            }

            //M2C_UpdateUserInfoMessage m2C_UpdateUserInfo = new M2C_UpdateUserInfoMessage();
            //m2C_UpdateUserInfo.UserInfo = self.UserInfo;
            //MessageHelper.SendToClient( self.GetParent<Unit>(), m2C_UpdateUserInfo );
        }

        public static void OnAddFirstWinSelf(this UserInfoComponentS self, Unit boss, int difficulty)
        {
            if (difficulty == 0)
            {
                difficulty = 1;
            }
            int firstwinid = FirstWinHelper.GetFirstWinID(boss.ConfigId, difficulty);
            if (firstwinid == 0)
            {
                return;
            }

            bool have = false;
            for (int i = 0; i < self.UserInfo.FirstWinSelf.Count; i++)
            {
                KeyValuePair keyValuePair = self.UserInfo.FirstWinSelf[i];
                if (keyValuePair.KeyId != firstwinid)
                {
                    continue;
                }
                //keyValuePair.Value  击杀难度
                //keyValuePair.Value2 领取难度
                if (keyValuePair.Value.Contains(difficulty.ToString()))
                {
                    return;
                }

                keyValuePair.Value += $"_{difficulty}";
                have = true;
                break;
            }
            if (!have)
            {
                self.UserInfo.FirstWinSelf.Add( new KeyValuePair() {  KeyId = firstwinid, Value = difficulty.ToString(), Value2 = "" } );
            }

            //M2C_FirstWinSelfUpdateMessage m2C_FirstWinSelfUpdateMessage = new M2C_FirstWinSelfUpdateMessage() { FirstWinInfos = self.UserInfo.FirstWinSelf  };
            //MessageHelper.SendToClient( self.GetParent<Unit>(), m2C_FirstWinSelfUpdateMessage);
        }


         public static int GetRandomMonsterId(this UserInfoComponentS self)
         {
             List<KeyValuePairInt> dayMonster = self.UserInfo.DayMonsters;
             List<DayMonsters> dayMonsterConfig = GlobalValueConfigCategory.Instance.DayMonsterList;

             for (int i = 0; i < dayMonsterConfig.Count; i++)
             {
                 if (RandomHelper.RandFloat01() > dayMonsterConfig[i].GaiLv)
                 {
                     continue;
                 }

                 KeyValuePairInt keyValuePairInt = null;
                 for (int d = 0; d < dayMonster.Count; d++)
                 {
                     if (dayMonster[d].KeyId != dayMonsterConfig[i].MonsterId)
                     {
                         continue;
                     }
                     keyValuePairInt = dayMonster[d];
                 }
                 if (keyValuePairInt == null)
                 {
                     keyValuePairInt = new KeyValuePairInt() { KeyId = dayMonsterConfig[i].MonsterId, Value = 0 };
                     dayMonster.Add(keyValuePairInt);
                 }
                 if (keyValuePairInt.Value < dayMonsterConfig[i].TotalNumber)
                 {
                     keyValuePairInt.Value++;
                     return dayMonsterConfig[i].MonsterId;
                 }
             }

             return 0;
         }

         public static bool IsCheskOpen(this UserInfoComponentS self, int fubenId, int monsterId)
         {
             List<KeyValuePair> chestList = self.UserInfo.OpenChestList;
             for (int i = 0; i < chestList.Count; i++)
             {
                 if (chestList[i].KeyId == fubenId)
                 {
                     return chestList[i].Value.Contains(monsterId.ToString());
                 }
             }
             return false;
         }
         
         public static void AddFubenTimes(this UserInfoComponentS self, int sceneId, int times)
         {
             for (int i = 0; i < self.UserInfo.DayFubenTimes.Count; i++)
             {
                 if (self.UserInfo.DayFubenTimes[i].KeyId == sceneId)
                 {
                     long curTimes = self.UserInfo.DayFubenTimes[i].Value -= times;
                     if (curTimes < 0)
                     {
                         curTimes = 0;
                     }
                     self.UserInfo.DayFubenTimes[i].Value = curTimes;
                     break;
                 }
             }
         }
         
         public static int GetStoreBuy(this UserInfoComponentS self, int mysteryId)
         {
             for (int i = 0; i < self.UserInfo.BuyStoreItems.Count; i++)
             {
                 if (self.UserInfo.BuyStoreItems[i].KeyId == mysteryId)
                 {
                     return (int)self.UserInfo.BuyStoreItems[i].Value;
                 }
             }
             return 0;
         }

         public static void OnStoreBuy(this UserInfoComponentS self, int mysteryId)
         {
             for (int i = 0; i < self.UserInfo.BuyStoreItems.Count; i++)
             {
                 if (self.UserInfo.BuyStoreItems[i].KeyId == mysteryId)
                 {
                     self.UserInfo.BuyStoreItems[i].Value += 1;
                     return;
                 }
             }
             self.UserInfo.BuyStoreItems.Add(new KeyValuePairInt() { KeyId = mysteryId, Value = 1 });
         }
         
         public static int GetRandomJingLingId(this UserInfoComponentS self)
         {
             List<DayJingLing> dayMonsterConfig = GlobalValueConfigCategory.Instance.DayJingLingList;
             List<int> dayMonster = self.UserInfo.DayJingLing;
             for(int i = 0; i < dayMonsterConfig.Count; i++)
             {
                 if (RandomHelper.RandFloat01() > dayMonsterConfig[i].GaiLv)
                 {
                     continue;
                 }
                 if (dayMonster.Count <= i)
                 {
                     for (int d = dayMonster.Count; d < i+1; d++)
                     {
                         dayMonster.Add(0);
                     }
                 }
                 if (dayMonster[i] >= dayMonsterConfig[i].TotalNumber)
                 {
                     continue;
                 }

                 dayMonster[i]++;
                 int randomIndex = RandomHelper.RandomByWeight(dayMonsterConfig[i].Weights);
                 return dayMonsterConfig[i].MonsterId[randomIndex];
             }

             return 0;
         }
    }
}