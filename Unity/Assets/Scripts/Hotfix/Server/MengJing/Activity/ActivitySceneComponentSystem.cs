using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [Invoke(TimerInvokeType.ActivityServerTimer)]
    public class ActivityServerTimer : ATimer<ActivitySceneComponent>
    {
        protected override void Run(ActivitySceneComponent self)
        {
            try
            {
                self.OnCheck();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [Invoke(TimerInvokeType.ActivityTipTimer)]
    public class ActivityTipTimer : ATimer<ActivitySceneComponent>
    {
        protected override void Run(ActivitySceneComponent self)
        {
            try
            {
                self.OnCheckFuntionButton().Coroutine();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [EntitySystemOf(typeof(ActivitySceneComponent))]
    [FriendOf(typeof(ActivitySceneComponent))]
    [FriendOf(typeof(DBDayActivityInfo))]
    public static partial class ActivitySceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ActivitySceneComponent self)
        {
            self.MapIdList.Clear();
            Log.Debug($"self.Zone:  {self.Zone()}");

            self.MapIdList.AddRange(UnitCacheHelper.GetGateServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetPaiMaiServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetRankServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetFubenCenterId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetUnionServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetSoloServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetDbCacheId(self.Zone()));
            
            self.InitDayActivity().Coroutine();
            self.InitFunctionButton().Coroutine();
            self.UpdateLastSingleHappyTime();
        }

        [EntitySystem]
        private static void Destroy(this ActivitySceneComponent self)
        {
        }

        public static void OnCheck(this ActivitySceneComponent self)
        {
            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);

            if (self.DBDayActivityInfo.CommonSeasonOpenTime == 0)
            {
                self.CheckSeasonBoss();
            }

            if (self.DBDayActivityInfo.LastHour != dateTime.Hour)
            {
                self.DBDayActivityInfo.LastHour = dateTime.Hour;
                self.CheckSeasonBoss();
                self.NoticeActivityUpdate_Hour(dateTime).Coroutine();
            }

            if (serverTime >= self.NextSingleHappyTime)
            {
                self.UpdateLastSingleHappyTime();
                self.NoticeActivityUpdate_SingleHappy().Coroutine();
            }
            
            self.CheckIndex++;
            if (self.CheckIndex >=  600)
            { 
                self.CheckPetMine(self.CheckIndex);
                self.SaveDB();
                self.CheckIndex = 0;
            }
        }

        private static void UpdateLastSingleHappyTime(this ActivitySceneComponent self)
        {
            DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
            long cursecond = (dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second) * TimeHelper.Second;
            long singlerecover = GlobalValueConfigCategory.Instance.SingleHappyrecoverTime;
            //计算下个恢复时间点
            long leftTime = singlerecover - cursecond % singlerecover;
            self.NextSingleHappyTime = TimeHelper.ServerNow() + leftTime;
        }

        private static void CheckSeasonBoss(this ActivitySceneComponent self)
        {
            KeyValuePairLong cur = SeasonHelper.GetOpenSeason(100);
            if (cur!=null && cur.Value != self.DBDayActivityInfo.CommonSeasonOpenTime)
            {
                Console.WriteLine($"ActivitySceneComponent.CheckSeasonBoss");
                self.DBDayActivityInfo.CommonSeasonOpenTime = cur.Value;
                self.DBDayActivityInfo.CommonSeasonBossExp = 0;
                self.DBDayActivityInfo.CommonSeasonBossLevel = 0;
            }
        }

        private static async ETTask NoticeActivityUpdate_SingleHappy(this ActivitySceneComponent self)
        {
            List<ActorId> actorIds = UnitCacheHelper.GetGateServerId(self.Zone());
            for (int i = 0; i < actorIds.Count; i++)
            {
                A2A_ActivityUpdateRequest A2A_ActivityUpdateRequest = A2A_ActivityUpdateRequest.Create();
                A2A_ActivityUpdateRequest.Hour = 0;
                A2A_ActivityUpdateRequest.FunctionId = 1076;
                A2A_ActivityUpdateResponse m2m_TrasferUnitResponse =
                        (A2A_ActivityUpdateResponse)await self.Root().GetComponent<MessageSender>()
                                .Call(actorIds[i], A2A_ActivityUpdateRequest);
            }
           
        }

        private static async ETTask NoticeActivityUpdate_Hour(this ActivitySceneComponent self, DateTime dateTime)
        {
            await ETTask.CompletedTask;
            DayOfWeek dayOfWeek = dateTime.DayOfWeek;
            //int yeardate = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day;  //20230412
            int hour = dateTime.Hour;
            int openServerDay = ServerHelper.GetServeOpenDay(self.Zone());
            Log.Warning($"NoticeActivityUpdate_Hour: zone: {self.Zone()} openday: {openServerDay}  {hour}");
            for (int i = 0; i < self.MapIdList.Count; i++)
            {
                A2A_ActivityUpdateRequest A2A_ActivityUpdateRequest = A2A_ActivityUpdateRequest.Create();
                A2A_ActivityUpdateRequest.Hour = hour;
                A2A_ActivityUpdateResponse m2m_TrasferUnitResponse =
                        (A2A_ActivityUpdateResponse)await self.Root().GetComponent<MessageSender>()
                                .Call(self.MapIdList[i], A2A_ActivityUpdateRequest);
            }

            if (hour == 0)
            {
                Log.Warning($"神秘商品刷新: {self.Zone()}");
                self.DBDayActivityInfo.MysteryItemInfos = MysteryShopHelper.InitMysteryItemInfos(openServerDay);
                self.DBDayActivityInfo.PetMingHexinList.Clear();

                self.InitPetMineExtend();
                self.InitFunctionButton().Coroutine();
            }

            if (hour == 0 && self.Zone() == 3) //通知中心服
            {
                // long centerid = UnitCacheHelper.GetAccountCenter();
                // A2A_ActivityUpdateResponse m2m_TrasferUnitResponse =
                //         (A2A_ActivityUpdateResponse) await ActorMessageSenderComponent.Instance.Call(centerid,
                //             new A2A_ActivityUpdateRequest() { Hour = 0 });
            }

            if (self.Zone() == 3)
            {
                Log.Warning("刷新机器人！！");
                ///long robotSceneId = StartSceneConfigCategory.Instance.GetBySceneName(203, "Robot01").InstanceId;
                ///MessageHelper.SendActor(robotSceneId, new G2Robot_MessageRequest() { Zone = self.DomainZone(), MessageType = NoticeType.CreateRobot });
            }

            if (ActivityConfigHelper.GuessRewardList().ContainsKey(hour))
            {
                int guessIndex = RandomHelper.RandomNumber(0, ActivityConfigHelper.GuessNumber());
                List<long> playerIds = null;
                self.DBDayActivityInfo.GuessPlayerList.TryGetValue(guessIndex, out playerIds);
                if (playerIds == null)
                {
                    playerIds = new List<long>();
                }

                List<ItemInfoProto> itemList = new List<ItemInfoProto>();
                string[] rewardItem = ActivityConfigHelper.GuessRewardList()[hour].Split('@');
                for (int i = 0; i < rewardItem.Length; i++)
                {
                    string[] itemInfo = rewardItem[i].Split(';');
                    ItemInfoProto BagInfo = ItemInfoProto.Create();
                    BagInfo.ItemID = int.Parse(itemInfo[0]);
                    BagInfo.ItemNum = int.Parse(itemInfo[1]);
                    itemList.Add(BagInfo);
                }

                ActorId mailServerId = UnitCacheHelper.GetMailServerId(self.Zone());
                for (int i = 0; i < playerIds.Count; i++)
                {
                    Log.Warning($"发放竞猜奖励: {self.Zone()}  {guessIndex} {playerIds[i]}");

                    MailInfo mailInfo = MailInfo.Create();
                    mailInfo.Status = 0;
                    mailInfo.Title = "竞猜奖励";
                    mailInfo.MailId = IdGenerater.Instance.GenerateId();
                    mailInfo.ItemList.AddRange(itemList);

                    // E2M_EMailSendResponse g_EMailSendResponse = (E2M_EMailSendResponse) await ActorMessageSenderComponent.Instance.Call(mailServerId,
                    //     new M2E_EMailSendRequest() { Id = playerIds[i], MailInfo = mailInfo, GetWay = ItemGetWay.Activity, });
                }

                if (hour == 0)
                {
                    self.DBDayActivityInfo.GuessRewardList.Clear();
                    self.DBDayActivityInfo.OpenGuessIds.Clear();
                }

                if (self.DBDayActivityInfo.GuessRewardList.ContainsKey(hour))
                {
                    self.DBDayActivityInfo.GuessRewardList[hour] = playerIds;
                    self.DBDayActivityInfo.OpenGuessIds.Add(guessIndex);
                }
                else
                {
                    self.DBDayActivityInfo.GuessRewardList.Add(hour, playerIds);
                    self.DBDayActivityInfo.OpenGuessIds.Add(guessIndex);
                }

                self.DBDayActivityInfo.GuessPlayerList.Clear();
            }
        }

        public static void InitPetMineExtend(this ActivitySceneComponent self)
        {
            List<MineBattleConfig> mineBattleConfig = MineBattleConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < mineBattleConfig.Count; i++)
            {
                int totalNumber = ConfigData.PetMiningList[mineBattleConfig[i].Id].Count;

                int hexinNumber = 1;

                if (mineBattleConfig[i].Id == 10001)
                {
                    hexinNumber = 1;
                }

                if (mineBattleConfig[i].Id == 10002)
                {
                    hexinNumber = 2;
                }

                if (mineBattleConfig[i].Id == 10003)
                {
                    hexinNumber = 5;
                }

                int[] index = RandomHelper.GetRandoms(hexinNumber, 0, totalNumber);
                List<int> hexinlist = new List<int>(index);

                for (int hexin = 0; hexin < hexinlist.Count; hexin++)
                {
                    self.DBDayActivityInfo.PetMingHexinList.Add(new KeyValuePairInt() { KeyId = mineBattleConfig[i].Id, Value = hexinlist[hexin] });
                }
            }
        }

        public static void CheckPetMine(this ActivitySceneComponent self, int checkindex)
        {
            int openDay = ServerHelper.GetServeOpenDay(self.Zone());

            List<PetMingPlayerInfo> petMingPlayers = self.DBDayActivityInfo.PetMingList;

            Dictionary<long, long> playerLimitList = new Dictionary<long, long>();
            for (int i = 0; i < petMingPlayers.Count; i++)
            {
                MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(petMingPlayers[i].MineType);
                int chanchu = mineBattleConfig.ChanChuLimit;

                if (!playerLimitList.ContainsKey(petMingPlayers[i].UnitId))
                {
                    playerLimitList.Add(petMingPlayers[i].UnitId, 0);
                }

                playerLimitList[petMingPlayers[i].UnitId] += chanchu;
            }

            for (int i = 0; i < petMingPlayers.Count; i++)
            {
                long playerLimit = playerLimitList[petMingPlayers[i].UnitId];

                float coffi = CommonHelp.GetMineCoefficient(openDay, petMingPlayers[i].MineType, petMingPlayers[i].Postion,
                    self.DBDayActivityInfo.PetMingHexinList);

                MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(petMingPlayers[i].MineType);
                int chanchu = (int)(mineBattleConfig.GoldOutPut * coffi * (checkindex / 3600f));

                if (!self.DBDayActivityInfo.PetMingChanChu.ContainsKey(petMingPlayers[i].UnitId))
                {
                    self.DBDayActivityInfo.PetMingChanChu.Add(petMingPlayers[i].UnitId, chanchu);
                }
                else
                {
                    long oldValue = self.DBDayActivityInfo.PetMingChanChu[petMingPlayers[i].UnitId];
                    oldValue += chanchu;
                    oldValue = Math.Min(oldValue, playerLimit);

                    self.DBDayActivityInfo.PetMingChanChu[petMingPlayers[i].UnitId] = oldValue;
                }
            }
        }

        public static async ETTask InitDayActivity(this ActivitySceneComponent self)
        {
            int zone = self.Zone();
            ActorId dbCacheId = UnitCacheHelper.GetDbCacheId(zone);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(1000, 2000));
            DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(zone);

            List<DBDayActivityInfo> dbDayActivityInfos = await dbComponent.Query<DBDayActivityInfo>(zone, d => d.Id == zone);
            if (dbDayActivityInfos == null || dbDayActivityInfos.Count == 0)
            {
                self.DBDayActivityInfo = self.AddComponentWithId<DBDayActivityInfo>(zone);
            }
            else
            {
                self.DBDayActivityInfo = dbDayActivityInfos[0];
            }

            int openServerDay = ServerHelper.GetServeOpenDay(zone);
            Log.Debug($"InitDayActivity: {zone}  {openServerDay}");
            self.DBDayActivityInfo.MysteryItemInfos = MysteryShopHelper.InitMysteryItemInfos(openServerDay);

            if (self.DBDayActivityInfo.PetMingHexinList.Count == 0)
            {
                self.InitPetMineExtend();
            }

            self.SaveDB();

            //每日活动
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Second, TimerInvokeType.ActivityServerTimer, self);
        }

        public static async ETTask OnCheckFuntionButton(this ActivitySceneComponent self)
        {
            await ETTask.CompletedTask;
            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);

            if (self.ActivityTimerList.Count > 0)
            {
                int functionId = self.ActivityTimerList[0].FunctionId;
                bool todayopen = FunctionHelp.IsFunctionDayOpen((int)dateTime.DayOfWeek, functionId);
                Log.Warning($"OnCheckFuntionButton: {functionId} {self.ActivityTimerList[0].FunctionType}");

                ActorId sceneserverid = new ActorId();
                switch (functionId)
                {
                    case 1045:
                        sceneserverid = UnitCacheHelper.GetSoloServerId(self.Zone());
                        break;
                    case 1052: //狩猎活动
                        sceneserverid = UnitCacheHelper.GetRankServerId(self.Zone());
                        break;
                    case 1057: //小龟大赛
                        sceneserverid = UnitCacheHelper.MainCityServerId(self.Zone());
                        break;
                    case 1031: //勇士角斗
                    case 1025: //战场活动
                    case 1058: //奔跑比赛
                    case 1059: //恶魔活动
                    case 1055: //喜从天降
                    case 1043: //公会Boss
                    case 1044: //公会争霸
                        sceneserverid = UnitCacheHelper.GetFubenCenterId(self.Zone());
                        break;
                    case 1074://宠物挑战赛
                        sceneserverid = UnitCacheHelper.GetPetMatchServerId(self.Zone());
                        break;
                    default:
                        break;
                }

                if (todayopen)
                {
                    if (sceneserverid.InstanceId == 0)
                    {
                        Log.Error(("sceneserverid == null"));
                    }
                    else
                    {
                        A2A_ActivityUpdateRequest A2A_ActivityUpdateRequest = A2A_ActivityUpdateRequest.Create();
                        A2A_ActivityUpdateRequest.Hour = -1;
                        A2A_ActivityUpdateRequest.FunctionId = functionId;
                        A2A_ActivityUpdateRequest.FunctionType = self.ActivityTimerList[0].FunctionType;
                        A2A_ActivityUpdateResponse m2m_TrasferUnitResponse = (A2A_ActivityUpdateResponse)await self.Root()
                                .GetComponent<MessageSender>().Call(sceneserverid, A2A_ActivityUpdateRequest);
                    }
                }

                if (todayopen && functionId == 1044 && self.ActivityTimerList[0].FunctionType == 2)
                {
                    //1044
                    ActorId rankserverid = UnitCacheHelper.GetRankServerId(self.Zone());

                    A2A_ActivityUpdateRequest A2A_ActivityUpdateRequest = A2A_ActivityUpdateRequest.Create();
                    A2A_ActivityUpdateRequest.Hour = -1;
                    A2A_ActivityUpdateRequest.FunctionId = functionId;
                    A2A_ActivityUpdateRequest.FunctionType = 2;
                    ////公会战结束. 发送奖励
                    A2A_ActivityUpdateResponse m2m_TrasferUnitResponse = (A2A_ActivityUpdateResponse)await self.Root().GetComponent<MessageSender>()
                            .Call(rankserverid, A2A_ActivityUpdateRequest);
                }

                self.ActivityTimerList.RemoveAt(0);
            }

            self.StartActivityTipTimer();
        }

        public static async ETTask InitFunctionButton(this ActivitySceneComponent self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(2000);
            self.ActivityTimerList.Clear();
            Log.Warning("InitFunctionButton");
            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);
            long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;

            ///1025 战场 1031勇士角斗 1043公会boss 1044公会争霸  1045竞技 1052狩猎活动  1055喜从天降  1057小龟大赛  1058奔跑比赛 1059恶魔活动 1074宠物挑战赛
            List<int> functonIds = new List<int>()
            {
                1025,
                1031,
                1043,
                1044,
                1045,
                1052,
                1055,
                1057,
                1058,
                1059,
                1074,
            };
            for (int i = 0; i < functonIds.Count; i++)
            {
                long startTime = FunctionHelp.GetOpenTime(functonIds[i]);
                long endTime = FunctionHelp.GetCloseTime(functonIds[i]);
                bool functionopne = FunctionHelp.IsFunctionDayOpen((int)dateTime.DayOfWeek, functonIds[i]);
                //Log.Console($"InitFunctionButton: {functonIds[i]} {functionopne}");
                if (curTime < startTime)
                {
                    long sTime = serverTime + (startTime - curTime) * 1000;
                    self.ActivityTimerList.Add(new ActivityTimer() { FunctionId = functonIds[i], BeginTime = sTime, FunctionType = 1 });
                }

                if (curTime < endTime)
                {
                    long sTime = serverTime + (endTime - curTime) * 1000;
                    self.ActivityTimerList.Add(new ActivityTimer() { FunctionId = functonIds[i], BeginTime = sTime, FunctionType = 2 });
                }

                bool inTime = functionopne && curTime >= startTime && curTime <= endTime;
                if (inTime)
                {
                    self.ActivityTimerList.Add(new ActivityTimer() { FunctionId = functonIds[i], BeginTime = serverTime, FunctionType = 1 });
                }
            }

            self.ActivityTimerList.Sort(delegate(ActivityTimer a, ActivityTimer b) { return (int)(a.BeginTime - b.BeginTime); });
            self.StartActivityTipTimer();
        }

        public static void StartActivityTipTimer(this ActivitySceneComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.ActivityTimer);
            if (self.ActivityTimerList.Count <= 0)
            {
                return;
            }

            if (self.ActivityTimerList[0].BeginTime <= TimeHelper.ServerNow())
            {
                self.OnCheckFuntionButton().Coroutine();
            }
            else
            {
                self.ActivityTimer = self.Root().GetComponent<TimerComponent>()
                        .NewOnceTimer(self.ActivityTimerList[0].BeginTime, TimerInvokeType.ActivityTipTimer, self);
            }
        }

        public static void SaveDB(this ActivitySceneComponent self)
        {
            self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(self.DBDayActivityInfo).Coroutine();
        }

        public static int OnMysteryBuyRequest(this ActivitySceneComponent self, MysteryItemInfo mysteryInfo)
        {
            for (int i = 0; i < self.DBDayActivityInfo.MysteryItemInfos.Count; i++)
            {
                MysteryItemInfo mysteryItemInfo1 = self.DBDayActivityInfo.MysteryItemInfos[i];

                if (mysteryItemInfo1.ItemID != mysteryInfo.ItemID)
                {
                    continue;
                }

                if (mysteryItemInfo1.ItemNumber < mysteryInfo.ItemNumber)
                {
                    return ErrorCode.ERR_ItemNotEnoughError;
                }

                mysteryItemInfo1.ItemNumber -= mysteryInfo.ItemNumber;
                return ErrorCode.ERR_Success;
            }

            return ErrorCode.ERR_ItemNotEnoughError;
        }
    }
}