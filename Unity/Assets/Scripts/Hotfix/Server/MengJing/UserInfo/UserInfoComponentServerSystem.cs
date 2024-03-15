using System;

namespace ET.Server
{
    [FriendOf(typeof (UserInfoComponentServer))]
    [EntitySystemOf(typeof (UserInfoComponentServer))]
    public static partial class UserInfoComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this UserInfoComponentServer self)
        {
        }

        [EntitySystem]
        private static void Destroy(this UserInfoComponentServer self)
        {
        }

        public static void UpdateRoleMoneyAdd(this UserInfoComponentServer self, int Type, string value, bool notice, int getWay,
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
        public static void UpdateRoleMoneySub(this UserInfoComponentServer self, int Type, string value, bool notice = true,
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

        public static void UpdateRoleData(this UserInfoComponentServer self, int Type, string value, bool notice = true)
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
                    // long maxHp = unit.GetComponent<NumericComponentServer>().GetAsLong((int)NumericType.Now_MaxHp);
                    // unit.GetComponent<NumericComponentServer>().ApplyValue(NumericType.Now_Hp, maxHp, false);
                    // unit.GetComponent<NumericComponentServer>().ApplyChange(null, NumericType.PointRemain, int.Parse(value) * 10, 0);
                    // unit.GetComponent<TaskComponent>().OnUpdateLevel(self.UserInfo.Lv);
                    // unit.GetComponent<ChengJiuComponent>().OnUpdateLevel(self.UserInfo.Lv);
                    // unit.GetComponent<HeroDataComponent>().CheckSeasonOpen(true);
                    // self.UpdateRoleData(UserDataType.Sp, value, notice);
                    // Function_Fight.GetInstance().UnitUpdateProperty_Base(unit, true, true);
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
        
        public static int GetDayItemUse(this UserInfoComponentServer self, int mysteryId)
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

        public static bool IsRobot(this UserInfoComponentServer self)
        {
            return self.UserInfo.RobotId > 0;
        }

        public static int GetUserLv(this UserInfoComponentServer self)
        {
            return self.UserInfo.Lv;
        }

        public static long GetPiLao(this UserInfoComponentServer self)
        {
            return self.UserInfo.PiLao;
        }

        public static int GetCombat(this UserInfoComponentServer self)
        {
            return self.UserInfo.Combat;
        }

        public static int GetOcc(this UserInfoComponentServer self)
        {
            return self.UserInfo.Occ;
        }

        public static int GetRobotId(this UserInfoComponentServer self)
        {
            return self.UserInfo.RobotId;
        }

        public static string GetName(this UserInfoComponentServer self)
        {
            return self.UserInfo.Name;
        }

        public static int GetOccTwo(this UserInfoComponentServer self)
        {
            return self.UserInfo.OccTwo;
        }

        public static void SetOccTwo(this UserInfoComponentServer self, int  occTwo)
        {
            self.UserInfo.OccTwo = 0;
        }

        public static int GetJiaYuanLv(this UserInfoComponentServer self)
        {
            return self.UserInfo.JiaYuanLv;
        }

        public static void OnCleanBossCD(this UserInfoComponentServer self)
        {
            for (int i = 0; i < self.UserInfo.MonsterRevives.Count; i++)
            {
                self.UserInfo.MonsterRevives[i].Value = "0";
            }
        }
        
        public static void OnHorseActive(this UserInfoComponentServer self, int horseId, bool active)
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

        public static int GetCrateDay(this UserInfoComponentServer self)
        {
            return 1;
        }

        public static long GetReviveTime(this UserInfoComponentServer self, int monsterId)
        {
            return 0;

        }

        public static void OnDayItemUse(this UserInfoComponentServer self, int itemId)
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
        
        public static long GetSceneFubenTimes(this UserInfoComponentServer self, int sceneId)
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
        
        public static void AddSceneFubenTimes(this UserInfoComponentServer self, int sceneId)
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
        
        public static int GetMonsterKillNumber(this UserInfoComponentServer self, int monsterId)
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
        
        public static void OnAddRevive(this UserInfoComponentServer self, int monsterId, long reviveTime)
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

        public static void OnAddFirstWinSelf(this UserInfoComponentServer self, Unit boss, int difficulty)
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
        
    }
}