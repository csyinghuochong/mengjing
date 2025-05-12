using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(UserInfoComponentS))]
    [EntitySystemOf(typeof(UserInfoComponentS))]
    public static partial class UserInfoComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this UserInfoComponentS self)
        {
        }

        [EntitySystem]
        private static void Destroy(this UserInfoComponentS self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this UserInfoComponentS self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                UserInfo userInfo = entity as UserInfo;

                self.UserInfo = userInfo;
            }
        }
        
        public static void DeserializeDB(this UserInfoComponentS self)
        {
            self.UserInfo = self.ChildrenDB[0] as UserInfo;
        }
        
        public static void Check(this UserInfoComponentS self, int sceond)
        {
            self.TodayOnLine+=sceond;
            self.LingDiOnLine+=sceond;

            //领地和家园都是一小时刷新一次经验
            if (self.LingDiOnLine > 600)
            {
                self.LingDiOnLine = 0;
                //self.OnRongyuChanChu(1, true);
                self.OnJiaYuanExp(1f, true);
            }

            if (self.UpdateRankTime > 0)
            {
                self.UpdateRankTime = 0;
                self.UploadCombat().Coroutine();
            }
        }

        public static void OnJiaYuanExp(this UserInfoComponentS self, float hour, bool notice)
        {
            JiaYuanConfig jiaYuanConfig = JiaYuanConfigCategory.Instance.Get(self.UserInfo.JiaYuanLv);
            //self.UserInfo.JiaYuanExp += jiaYuanConfig.JiaYuanAddExp;
            int addexp = (int)math.floor(hour * jiaYuanConfig.JiaYuanAddExp);
            self.UpdateRoleMoneyAdd(UserDataType.JiaYuanExp, $"{addexp}", notice, ItemGetWay.JiaYuanExchange);
        }

        public static void OnInit(this UserInfoComponentS self, string account, long id, long accountId, CreateRoleInfo createRoleInfo)
        {
            self.Account = account;
            self.UserInfo = self.AddChild<UserInfo>();
            UserInfo userInfo = self.UserInfo;
            userInfo.Sp = 1;
            userInfo.UserId = id;
            userInfo.BaoShiDu = 100;
            userInfo.JiaYuanLv = 10001;
            userInfo.JiaYuanFund = 10000;
            userInfo.AccInfoID = accountId;
            userInfo.Name = createRoleInfo.PlayerName;
            userInfo.ServerMailIdCur = -1;
            userInfo.PiLao = GlobalValueConfigCategory.Instance.MaxPiLao; //初始化疲劳
            userInfo.Vitality = GlobalValueConfigCategory.Instance.MaxPiLao;
            userInfo.MakeList.AddRange(CommonHelp.StringArrToIntList(GlobalValueConfigCategory.Instance.Get(18).Value.Split(';')));
            userInfo.CreateTime = TimeHelper.ServerNow();
            userInfo.RobotId = createRoleInfo.RobotId;
            userInfo.SeasonLevel = 1;
            if (createRoleInfo.RobotId > 0)
            {
                int robotId = createRoleInfo.RobotId;
                RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
                userInfo.Lv = robotConfig.Behaviour == 1 ? RandomHelper.RandomNumber(10, 19) : robotConfig.Level;
                userInfo.Occ = robotConfig.Behaviour == 1 ? RandomHelper.RandomNumber(1, 3) : robotConfig.Occ;
                userInfo.Gold = 100000;
                userInfo.RobotId = robotId;
                //userInfo.OccTwo = robotConfig.OccTwo;
            }
            else
            {
                userInfo.Lv = 1;
                userInfo.Gold = 0;
                userInfo.Occ = createRoleInfo.PlayerOcc;
                userInfo.Name = createRoleInfo.PlayerName;
            }
        }

        public static void CheckData(this UserInfoComponentS self)
        {
            if (self.UserInfo.JiaYuanLv <= 0)
            {
                self.UserInfo.JiaYuanLv = 10001;
            }

            if (self.UserInfo.SeasonLevel == 0)
            {
                self.UserInfo.SeasonLevel = 1;
            }

            if (self.UserInfo.CreateTime == 0)
            {
                self.UserInfo.CreateTime = TimeHelper.ServerNow();
            }

            if (self.UserInfo.Lv < 20 && self.UserInfo.BaoShiDu < 100)
            {
                self.UserInfo.BaoShiDu = 100;
            }

            int maxTowerId = 0;
            if (self.UserInfo.TowerRewardIds.Count > 0)
            {
                maxTowerId = self.UserInfo.TowerRewardIds[self.UserInfo.TowerRewardIds.Count - 1];
            }

            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.TrialDungeonId) < maxTowerId)
            {
                numericComponent.ApplyValue(NumericType.TrialDungeonId, maxTowerId, false);
            }

            if (numericComponent.GetAsInt(NumericType.UpdateActivty) == 0)
            {
                self.GetParent<Unit>().GetComponent<ActivityComponentS>().ClearJieRiActivty();
                numericComponent.ApplyValue(NumericType.UpdateActivty, 1, false);
            }

            DataCollationComponent dataCollationComponent = self.GetParent<Unit>().GetComponent<DataCollationComponent>();
            int recharge = numericComponent.GetAsInt(NumericType.RechargeNumber);
            if (recharge != 0 && dataCollationComponent.ChouKaTimes > (recharge * 2) && dataCollationComponent.ChouKaTimes > 100)
            {
                Log.Warning(
                    $"抽卡次数异常:{self.Zone()} {self.UserInfo.Name}   充值:{numericComponent.GetAsInt(NumericType.RechargeNumber)}  抽卡:{dataCollationComponent.ChouKaTimes}");
            }

            if (self.UserInfo.UserId == 2308831070960812032)
            {
                //self.UserInfo.UnionName = "";
                //self.GetParent<Unit>().GetComponent<NumericComponent>().ApplyValue(NumericType.UnionLeader, 0, false);
                //self.GetParent<Unit>().GetComponent<NumericComponent>().ApplyValue(NumericType.UnionId_0, 0, false);
            }

            if (self.UserInfo.UnionKeJiList.Count < UnionKeJiConfigCategory.Instance.UnionQiangHuaList.Count)
            {
                int curNumber = self.UserInfo.UnionKeJiList.Count;
                int maxNumber = UnionKeJiConfigCategory.Instance.UnionQiangHuaList.Count;
                for (int keji = curNumber; keji < maxNumber; keji++)
                {
                    self.UserInfo.UnionKeJiList.Add(UnionKeJiConfigCategory.Instance.GetFristId(keji));
                }
            }

            //
            if (self.UserInfo.RobotId > 0)
            {
                self.UserInfo.Gold = math.max(self.UserInfo.Gold, 100000000);
                self.UserInfo.Diamond = math.max(self.UserInfo.Diamond, 100000);
            }
        }

        public static void OnLogin(this UserInfoComponentS self, string remoteIp, string deviceName, long currentTime)
        {
            self.RemoteAddress = remoteIp;
            self.DeviceName = deviceName;
            
            self.UpdateRankTime = TimeHelper.ServerNow();
            self.UserName = self.UserInfo.Name;
            self.ShouLieSendTime = 0;
            self.CheckData();
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
                BroadCastHelper.SendUnionOperate(self.Root(), unit.GetUnionId(),  getWay, Type, gold,self.UserInfo.Name).Coroutine();
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

        public static void UpdateRoleDataBroadcast(this UserInfoComponentS self, int Type, string value)
        {
            Unit unit = self.GetParent<Unit>();
            M2C_RoleDataBroadcast m2C_BroadcastRoleData = self.m2C_RoleDataBroadcast;
            m2C_BroadcastRoleData.UnitId = unit.Id;
            m2C_BroadcastRoleData.UpdateType = (int)Type;
            m2C_BroadcastRoleData.UpdateTypeValue = value;
            MapMessageHelper.Broadcast(unit, m2C_BroadcastRoleData);
        }

        //增加经验
        public static void Role_AddExp(this UserInfoComponentS self, long addValue, bool notice)
        {
            Scene scene = self.Scene();
            ServerInfo serverInfo = ConfigData.ServerInfoList[scene.Zone()];
            if (serverInfo == null)
            {
                Log.Warning($"ServerInfo==null: {scene.GetComponent<MapComponent>().MapType} {self.Id}");
                return;
            }

         

            float expAdd = CommonHelp.GetExpAdd(self.UserInfo.Lv, serverInfo);

            ExpConfig xiulianconf1 = ExpConfigCategory.Instance.Get(self.UserInfo.Lv);
            long upNeedExp = xiulianconf1.UpExp;

            //等级达到上限,则无法获得经验. 经验最多200%
            if (addValue > 0 && self.UserInfo.Lv >= GlobalValueConfigCategory.Instance.MaxLevel)
            {
                long maxExp = upNeedExp * 2;
                if (self.UserInfo.Exp > maxExp)
                {
                    self.UpdateRoleData(UserDataType.Message, "当前经验超过200%，请前往主城经验老头处用多余的经验兑换奖励喔!");
                    return;
                }
            }

            self.UserInfo.Exp = self.UserInfo.Exp + (int)(addValue * (1.0f + expAdd));

            //判定是否升级
            if (self.UserInfo.Lv >= serverInfo.WorldLv)
            {
                return;
            }

            if (self.UserInfo.Exp >= upNeedExp)
            {
                self.UserInfo.Exp -= upNeedExp;
                self.UpdateRoleData(UserDataType.Lv, "1", notice);
            }
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
                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.JiaYuanLevel_22, 0, self.UserInfo.JiaYuanLv - 10000);
                    unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.JiaYuanLevel_404, 0, self.UserInfo.JiaYuanLv - 10000);
                    break;
                case UserDataType.FangRong:
                    CommonHelperS.OnAddLingDiExp(unit, int.Parse(value), notice);
                    break;
                //名字应该在改名的协议处理
                case UserDataType.Name:
                    self.UserInfo.Name = value;
                    saveValue = self.UserInfo.Name;
                    break;
                case UserDataType.Exp:
                    self.Role_AddExp(long.Parse(value), notice);
                    saveValue = self.UserInfo.Exp.ToString();
                    longValue = self.UserInfo.Exp;
                    break;
                case UserDataType.Lv:
                    self.UserInfo.Lv += int.Parse(value);
                    saveValue = self.UserInfo.Lv.ToString();
                    long maxHp = unit.GetComponent<NumericComponentS>().GetAsLong((int)NumericType.Now_MaxHp);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Hp, maxHp);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PointRemain, int.Parse(value) * 10);
                    unit.GetComponent<TaskComponentS>().OnUpdateLevel(self.UserInfo.Lv);
                    unit.GetComponent<ChengJiuComponentS>().OnUpdateLevel(self.UserInfo.Lv);
                    unit.GetComponent<HeroDataComponentS>().CheckSeasonOpen(true);
                    self.UpdateRoleData(UserDataType.Sp, value, notice);
                    self.UpdateRoleData(UserDataType.TalentPoints, value, notice);
                    Function_Fight.UnitUpdateProperty_Base(unit, true, true);
                    break;
                case UserDataType.Sp:
                    self.UserInfo.Sp += int.Parse(value);
                    saveValue = self.UserInfo.Sp.ToString();
                    break;
                case UserDataType.Gold:
                    self.UserInfo.Gold += long.Parse(value);
                    saveValue = self.UserInfo.Gold.ToString();
                    unit.GetComponent<ChengJiuComponentS>().OnGetGold(int.Parse(value));
                    unit.GetComponent<TaskComponentS>().OnCostCoin(int.Parse(value));
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
                        unit.GetComponent<ChengJiuComponentS>().OnCostDiamond(addDiamond);
                        unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.V1DayCostDiamond, addDiamond * -1);
                    }

                    break;
                case UserDataType.Occ:
                    break;
                case UserDataType.InvestMent:
                    unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.InvestMent, long.Parse(value));
                    unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.InvestTotal, long.Parse(value));
                    break;
                case UserDataType.JueXingExp:
                    unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.JueXingExp, long.Parse(value));
                    break;
                case UserDataType.MaoXianExp:
                    unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.MaoXianExp, long.Parse(value));
                    break;
                case UserDataType.Recharge:
                    RechargeHelp.SendDiamondToUnit(unit, int.Parse(value), "道具");
                    break;
                case UserDataType.PiLao:
                    if (value == "0")
                    {
                        return;
                    }

                    int maxValue = unit.IsYueKaStates() ? GlobalValueConfigCategory.Instance.MaxPiLaoYuKaUser : GlobalValueConfigCategory.Instance.MaxPiLao;
                    long newValue = long.Parse(value) + self.UserInfo.PiLao;
                    newValue = Math.Min(Math.Max(0, newValue), maxValue);
                    self.UserInfo.PiLao = newValue;
                    saveValue = self.UserInfo.PiLao.ToString();
                    break;
                case UserDataType.BaoShiDu:
                    long addValue = long.Parse(value);
                    newValue = self.UserInfo.BaoShiDu + (int)addValue;
                    newValue = Math.Min(Math.Max(0, newValue), CommonHelp.GetMaxBaoShiDu());
                    self.UserInfo.BaoShiDu = (int)newValue;
                    saveValue = self.UserInfo.BaoShiDu.ToString();
                    unit.GetComponent<BuffManagerComponentS>()?.InitBaoShiBuff();
                    break;
                case UserDataType.HuoYue:
                    break;
                case UserDataType.DungeonTimes:
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonTimes, unit.GetTeamDungeonTimes() - 1);
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamDungeonXieZhu, unit.GetTeamDungeonXieZhu() - 1);
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
                    unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.CombatToValue_211, 0, self.UserInfo.Combat);
                    unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.CombatToValue_133, 0, self.UserInfo.Combat);
                    break;
                case UserDataType.Vitality:
                    NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
                    int skillNumber = 1 + numericComponent.GetAsInt(NumericType.MakeType_2) > 0 ? 1 : 0;
                    maxValue = unit.GetMaxHuoLi(skillNumber);
                    addValue = long.Parse(value);
                    newValue = self.UserInfo.Vitality + (int)addValue;
                    newValue = Math.Min(Math.Max(0, newValue), maxValue);
                    self.UserInfo.Vitality = (int)newValue;
                    saveValue = self.UserInfo.Vitality.ToString();
                    break;
                case UserDataType.BuffSkill:
                    longValue = long.Parse(value);
                    break;
                case UserDataType.TalentPoints:
                    self.UserInfo.TalentPoints += int.Parse(value);
                    saveValue = self.UserInfo.TalentPoints.ToString();
                    break;
                default:
                    saveValue = value;
                    break;
            }

            //发送更新值
            if (notice)
            {
                M2C_RoleDataUpdate m2C_RoleDataUpdate1 = M2C_RoleDataUpdate.Create();
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

        public static string GetGameSettingValue(this UserInfoComponentS self, GameSettingEnum gameSettingEnum)
        {
            for (int i = 0; i < self.UserInfo.GameSettingInfos.Count; i++)
            {
                if (self.UserInfo.GameSettingInfos[i].KeyId == (int)gameSettingEnum)
                    return self.UserInfo.GameSettingInfos[i].Value;
            }

            switch (gameSettingEnum)
            {
                case GameSettingEnum.Music:
                    return "1";
                case GameSettingEnum.Sound:
                    return "0";
                // 0 固定 1移动
                case GameSettingEnum.YanGan:
                    return "0";
                case GameSettingEnum.FenBianlLv:
                    return "1";
                default:
                    return "0";
            }
        }

        public static void UpdateRankInfo(this UserInfoComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            if (unit.IsRobot())
            {
                return;
            }

            self.UpdateRankTime = TimeHelper.ServerNow();
        }

        public static void SetUserLv(this UserInfoComponentS self, int lv)
        {
            self.UserInfo.Lv = lv;
        }

        /// <summary>
        /// 0 6 12 20点各刷新30点体力
        /// </summary>
        /// <param name="self"></param>
        /// <param name="notice"></param>
        public static void OnHourUpdate(this UserInfoComponentS self, int hour, bool notice)
        {
            if (hour == 0)
            {
                self.RecoverPiLao(30 + self.GetAddPiLao(self.UserInfo.MakeList.Count), notice);
            }

            if (hour == 12)
            {
                self.RecoverPiLao(30, notice);
            }

            if (hour == 6 || hour == 20)
            {
                self.RecoverPiLao(50, notice);
            }

            self.GetParent<Unit>().GetComponent<JiaYuanComponentS>().OnHourUpdate(hour, notice);
            ServerLogHelper.CheckZuoBi(self.GetParent<Unit>());
            //LogHelper.CheckBlackRoom(self.GetParent<Unit>());
        }

        public static void OnZeroClockUpdate(this UserInfoComponentS self, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            int skillNumber = 1 + numericComponent.GetAsInt(NumericType.MakeType_2) > 0 ? 1 : 0;
            int updatevalue = unit.GetMaxHuoLi(skillNumber) - self.UserInfo.Vitality;
            self.UpdateRoleData(UserDataType.Vitality, updatevalue.ToString(), notice);
            //updatevalue = ComHelp.GetMaxBaoShiDu() - self.UserInfo.BaoShiDu;
            //self.UpdateRoleData(UserDataType.BaoShiDu, updatevalue.ToString(), notice);
            self.ClearDayData();
            self.TodayOnLine = 0;
            self.ShouLieKill = 0;
            
            if (notice)
            {
                MapMessageHelper.SendToClient( unit, M2C_ZeroClock.Create() );
            }
        }

        public static void ClearDayData(this UserInfoComponentS self)
        {
            self.UserInfo.DayFubenTimes.Clear();
            self.UserInfo.ChouKaRewardIds.Clear();
            self.UserInfo.MysteryItems.Clear();
            self.UserInfo.DayItemUse.Clear();
            self.UserInfo.DayMonsters.Clear();
            self.UserInfo.DayJingLing.Clear();
            self.UserInfo.PetExploreRewardIds.Clear();
            self.UserInfo.PetHeXinExploreRewardIds.Clear();
            self.UserInfo.ItemXiLianNumRewardIds.Clear();
        }

        /// <summary>
        /// 体力
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillNumber"></param>
        /// <returns></returns>
        public static int GetAddPiLao(this UserInfoComponentS self, int skillNumber)
        {
            return 0;
        }

        public static void RecoverPiLao(this UserInfoComponentS self, int addValue, bool notice)
        {
            Unit unit = self.GetParent<Unit>();
            long recoverPiLao = self.GetParent<Unit>().GetMaxPiLao() - self.UserInfo.PiLao;
            recoverPiLao = Math.Min(recoverPiLao, addValue);

            //Log.Warning($"[增加疲劳] {unit.DomainZone()}  {unit.Id}   {0}  {recoverPiLao}");
            self.UpdateRoleData(UserDataType.PiLao, recoverPiLao.ToString(), notice);
        }

        public static int GetMaxPiLao(this Unit self)
        {
            return self.IsYueKaStates() ? GlobalValueConfigCategory.Instance.MaxPiLaoYuKaUser : GlobalValueConfigCategory.Instance.MaxPiLao;
        }

        public static bool IsYueKaStates(this Unit self)
        {
            return self.GetComponent<NumericComponentS>().GetAsInt(NumericType.YueKaRemainTimes) > 0;
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

        public static void ClearFubenTimes(this UserInfoComponentS self, int sceneId)
        {
            for (int i = 0; i < self.UserInfo.DayFubenTimes.Count; i++)
            {
                if (self.UserInfo.DayFubenTimes[i].KeyId == sceneId)
                {
                    self.UserInfo.DayFubenTimes[i].Value = 0;
                    break;
                }
            }
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

        public static void SetOccTwo(this UserInfoComponentS self, int occTwo)
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
            return  TimeHelper.DateDiff_Time(TimeHelper.ServerNow(), self.UserInfo.CreateTime);
        }

        public static long GetReviveTime(this UserInfoComponentS self, int monsterId)
        {
            for (int i = 0; i < self.UserInfo.MonsterRevives.Count; i++)
            {
                if (self.UserInfo.MonsterRevives[i].KeyId == monsterId)
                {
                    return long.Parse(self.UserInfo.MonsterRevives[i].Value);
                }
            }

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

        public static int OnGetFirstWinSelf(this UserInfoComponentS self, int firstwinid, int difficulty)
        {
            KeyValuePair keyValuePair1 = null;
            for (int i = 0; i < self.UserInfo.FirstWinSelf.Count; i++)
            {
                if (self.UserInfo.FirstWinSelf[i].KeyId != firstwinid)
                {
                    continue;
                }

                keyValuePair1 = self.UserInfo.FirstWinSelf[i];
                break;
            }

            if (keyValuePair1 == null)
            {
                return ErrorCode.ERR_NetWorkError;
            }

            if (keyValuePair1.Value2.Contains(difficulty.ToString()))
            {
                return ErrorCode.ERR_AlreadyReceived;
            }

            if (string.IsNullOrEmpty(keyValuePair1.Value2))
            {
                keyValuePair1.Value2 = difficulty.ToString();
            }
            else
            {
                keyValuePair1.Value2 += $"_{difficulty}";
            }

            return ErrorCode.ERR_Success;
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

            self.NoticeUpdateUserInfo();
        }

        private static void NoticeUpdateUserInfo(this UserInfoComponentS self)
        {
            M2C_UpdateUserInfoMessage m2C_UpdateUserInfo = M2C_UpdateUserInfoMessage.Create();
            m2C_UpdateUserInfo.UserInfo = self.UserInfo.ToMessage();
            MapMessageHelper.SendToClient( self.GetParent<Unit>(), m2C_UpdateUserInfo );
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
                self.UserInfo.FirstWinSelf.Add(new KeyValuePair() { KeyId = firstwinid, Value = difficulty.ToString(), Value2 = "" });
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

        public static int GetMysteryBuy(this UserInfoComponentS self, int mysteryId)
        {
            for (int i = 0; i < self.UserInfo.MysteryItems.Count; i++)
            {
                if (self.UserInfo.MysteryItems[i].KeyId == mysteryId)
                {
                    return (int)self.UserInfo.MysteryItems[i].Value;
                }
            }

            return 0;
        }

        public static void OnMysteryBuy(this UserInfoComponentS self, int mysteryId)
        {
            for (int i = 0; i < self.UserInfo.MysteryItems.Count; i++)
            {
                if (self.UserInfo.MysteryItems[i].KeyId == mysteryId)
                {
                    self.UserInfo.MysteryItems[i].Value += 1;
                    return;
                }
            }

            self.UserInfo.MysteryItems.Add(new KeyValuePairInt() { KeyId = mysteryId, Value = 1 });
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
            for (int i = 0; i < dayMonsterConfig.Count; i++)
            {
                if (RandomHelper.RandFloat01() > dayMonsterConfig[i].GaiLv)
                {
                    continue;
                }

                if (dayMonster.Count <= i)
                {
                    for (int d = dayMonster.Count; d < i + 1; d++)
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
        
        public static void OnResetSeason(this UserInfoComponentS self, bool notice)
        {
            self.UserInfo.SeasonLevel = 1;
            self.UserInfo.SeasonExp = 0;
            self.UserInfo.SeasonCoin = 0;
            self.UserInfo.OpenJingHeIds.Clear();
            self.UserInfo.SeasonDonateRewardIds.Clear();
        }

        public static void ClearMakeListByType(this UserInfoComponentS self, int makeType)
        {
            if (makeType == 0)
            {
                return;
            }

            for (int i = self.UserInfo.MakeList.Count - 1; i >= 0; i--)
            {
                int makeId = self.UserInfo.MakeList[i];
                if (makeId == 0)
                {
                    self.UserInfo.MakeList.RemoveAt(i);
                    continue;
                }

                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeId);
                if (equipMakeConfig.ProficiencyType == makeType)
                {
                    self.UserInfo.MakeList.RemoveAt(i);
                }
            }
        }

        public static void OnShowLieKill(this UserInfoComponentS self)
        {
            self.ShouLieKill++;

            if (self.ShouLieUpLoadTimer == 0)
            {
                self.ShouLieUpLoadTimer = self.Root().GetComponent<TimerComponent>()
                        .NewOnceTimer(TimeHelper.ServerNow() + 5 * TimeHelper.Second, TimerInvokeType.ShouLieUpLoadTimer, self);
            }
            else
            {
                self.UpdateShowLie().Coroutine();
            }
        }

        public static async ETTask UpdateShowLie(this UserInfoComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            if (!ConfigData.IsShowLieOpen || unit.IsRobot())
            {
                return;
            }

            self.ShouLieSendTime = TimeHelper.ServerNow();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.ShouLieUpLoadTimer);
            RankShouLieInfo rankPetInfo = RankShouLieInfo.Create();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            rankPetInfo.UnitID = userInfoComponent.UserInfo.UserId;
            rankPetInfo.PlayerName = userInfoComponent.UserInfo.Name;
            rankPetInfo.Occ = userInfoComponent.UserInfo.Occ;
            rankPetInfo.KillNumber = self.ShouLieKill;
            ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());
            M2R_RankShowLieRequest M2R_RankShowLieRequest = M2R_RankShowLieRequest.Create();
            M2R_RankShowLieRequest.RankingInfo = rankPetInfo;
            R2M_RankShowLieResponse Response = (R2M_RankShowLieResponse)await self.Root().GetComponent<MessageSender>()
                    .Call(mapInstanceId, M2R_RankShowLieRequest);
        }

        public static void OnAddChests(this UserInfoComponentS self, int fubenId, int monsterId)
        {
            bool have = false;
            List<KeyValuePair> chestList = self.UserInfo.OpenChestList;
            for (int i = 0; i < chestList.Count; i++)
            {
                if (chestList[i].KeyId == fubenId)
                {
                    chestList[i].Value += ($"_{monsterId}");
                    have = true;
                }
            }

            if (!have)
            {
                self.UserInfo.OpenChestList.Add(new KeyValuePair() { KeyId = fubenId, Value = monsterId.ToString() });
            }
        }

        /// <summary>
        /// 杀怪经验
        /// </summary>
        /// <param name="self"></param>
        /// <param name="beKill"></param>
        public static void OnKillUnit(this UserInfoComponentS self, Unit beKill, int sceneType, int sceneId)
        {
            Unit main = self.GetParent<Unit>();
            if (beKill.Type != UnitType.Monster)
            {
                return;
            }

            bool showlieopen = ConfigData.IsShowLieOpen;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(beKill.ConfigId);
            if (showlieopen && (monsterConfig.Lv >= 60 || Math.Abs(self.UserInfo.Lv - monsterConfig.Lv) <= 9))
            {
                self.OnShowLieKill();
                main.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.ShowLieMonster_1201, 0, 1);
            }

            if (sceneType == MapTypeEnum.LocalDungeon && monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_55)
            {
                self.OnAddChests(sceneId, beKill.ConfigId);
            }

            if (SeasonHelper.GetOpenSeason(self.UserInfo.Lv) != null && beKill.IsBoss() && monsterConfig.Lv >= 40)
            {
                int seasonExp = RandomHelper.RandomNumber(1, 6);
                self.UpdateRoleData(UserDataType.SeasonExp, seasonExp.ToString());
            }

            NumericComponentS numericComponent = main.GetComponent<NumericComponentS>();
            numericComponent.ApplyChange(NumericType.KillMonsterNumber, 1);

            int tiliKillNumber = numericComponent.GetAsInt(NumericType.TiLiKillNumber);
            if (sceneType == MapTypeEnum.LocalDungeon && !showlieopen && self.UserInfo.PiLao > 0)
            {
                if (tiliKillNumber >= 4)
                {
                    numericComponent.ApplyValue(NumericType.TiLiKillNumber, 0, false);

                    numericComponent.ApplyChange(NumericType.CostTiLi, 1);
                    self.UpdateRoleData(UserDataType.PiLao, "-1", true);
                }
                else
                {
                    numericComponent.ApplyChange(NumericType.TiLiKillNumber, 1);
                }
            }

            bool drop = true;
            if (SceneConfigHelper.IsSingleFuben(sceneType))
            {
                drop = self.UserInfo.PiLao > 0 || beKill.IsBoss() || showlieopen;
            }

            if (drop)
            {
                MonsterConfig mCof = MonsterConfigCategory.Instance.Get(beKill.ConfigId);
                float expcoefficient = 1f;
                if (sceneType == MapTypeEnum.LocalDungeon && beKill.IsBoss())
                {
                    int killNumber = main.GetComponent<UserInfoComponentS>().GetMonsterKillNumber(mCof.Id);
                    int chpaterid = DungeonConfigCategory.Instance.GetChapterByDungeon(sceneId);
                    BossDevelopment bossDevelopment = ConfigHelper.GetBossDevelopmentByKill(chpaterid, killNumber);
                    expcoefficient *= bossDevelopment.ExpAdd;
                }

                if ((sceneType == MapTypeEnum.LocalDungeon && self.UserInfo.PiLao > 0)
                    || sceneType != MapTypeEnum.LocalDungeon)
                {
                    if (numericComponent.GetAsInt(NumericType.JueXingExp) < 5000)
                    {
                        numericComponent.ApplyChange(NumericType.JueXingExp, 1);
                    }
                }

                int addexp = (int)(expcoefficient * mCof.Exp);
                self.UpdateRoleData(UserDataType.Exp, addexp.ToString());
            }

            // 纪录击败的Boss
            if (beKill.IsBoss() && ConfigData.DefeatedBossIds.ContainsKey(beKill.ConfigId))
            {
                if (!self.UserInfo.DefeatedBossIds.Contains(beKill.ConfigId))
                {
                    self.UserInfo.DefeatedBossIds.Add(beKill.ConfigId);
                }
            }
        }

        public static async ETTask UploadCombat(this UserInfoComponentS self)
        {
            Unit unit = self.GetParent<Unit>();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());
            RankingInfo rankPetInfo = RankingInfo.Create();

            rankPetInfo.UserId = self.UserInfo.UserId;
            rankPetInfo.PlayerName = self.UserInfo.Name;
            rankPetInfo.PlayerLv = self.UserInfo.Lv;
            rankPetInfo.Combat = self.UserInfo.Combat;
            rankPetInfo.Occ = self.UserInfo.Occ;
            M2R_RankUpdateRequest M2R_RankUpdateRequest = M2R_RankUpdateRequest.Create();
            M2R_RankUpdateRequest.CampId = numericComponent.GetAsInt(NumericType.AcvitiyCamp);
            M2R_RankUpdateRequest.RankingInfo = rankPetInfo;
            R2M_RankUpdateResponse Response =
                    (R2M_RankUpdateResponse)await unit.Root().GetComponent<MessageSender>().Call(mapInstanceId, M2R_RankUpdateRequest);
            if (unit.IsDisposed)
            {
                return;
            }

            numericComponent.ApplyValue(NumericType.CombatRankID, Response.RankId);
            numericComponent.ApplyValue(NumericType.OccCombatRankID, Response.OccRankId);
            numericComponent.ApplyValue(NumericType.PetTianTiRankID, Response.PetRankId);
            numericComponent.ApplyValue(NumericType.SoloRankId, Response.SoloRankId);
        }

        public static void OnMakeItem(this UserInfoComponentS self, int makeId)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeId);
            List<KeyValuePairInt> makeList = self.UserInfo.MakeIdList;

            bool have = false;
            long endTime = TimeHelper.ServerNow() + equipMakeConfig.MakeTime * 1000;
            for (int i = 0; i < makeList.Count; i++)
            {
                if (makeList[i].KeyId == makeId)
                {
                    makeList[i].Value = endTime;
                    have = true;
                }
            }

            if (!have)
            {
                self.UserInfo.MakeIdList.Add(new KeyValuePairInt() { KeyId = makeId, Value = endTime });
            }
        }
    }
}