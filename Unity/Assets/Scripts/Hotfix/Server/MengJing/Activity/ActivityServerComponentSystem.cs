using System;
using System.Linq;
using System.Collections.Generic;

namespace ET.Server
{

    [EntitySystemOf(typeof(ActivityServerComponent))]
    [FriendOf(typeof(ActivityServerComponent))]
    [FriendOf(typeof(DBDayActivityInfo))]
    public static partial class ActivityServerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ActivityServerComponent self)
        {
            self.MapIdList.Clear();
            self.MapIdList.Add(UnitCacheHelper.GetGateServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetPaiMaiServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetRankServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetFubenCenterId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetArenaServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetBattleServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetUnionServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetSoloServerId(self.Zone()));
            self.MapIdList.Add(UnitCacheHelper.GetDbCacheId(self.Zone()));
            self.InitDayActivity().Coroutine();
            self.InitFunctionButton();
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Server.ActivityServerComponent self)
        {

        }
        
        public static void OnCheck(this ActivityServerComponent self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
  
            if (self.DBDayActivityInfo.LastHour != dateTime.Hour)
            {
                self.DBDayActivityInfo.LastHour = dateTime.Hour;
                self.NoticeActivityUpdate_Hour(dateTime).Coroutine();
            }

            self.SaveDB();
            self.CheckPetMine();
        }
        
        public static void InitPetMineExtend(this ActivityServerComponent self)
        {
            List<MineBattleConfig> mineBattleConfig = MineBattleConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < mineBattleConfig.Count; i++)
            {
                int totalNumber = ConfigHelper.PetMiningList()[mineBattleConfig[i].Id].Count;

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
                    self.DBDayActivityInfo.PetMingHexinList.Add(new KeyValuePairInt() 
                    {
                        KeyId = mineBattleConfig[i].Id,
                        Value = hexinlist[hexin]
                    });
                }
            }
        }
        
        
        public static void CheckPetMine(this ActivityServerComponent self)
        {
            self.CheckIndex++;
            if (self.CheckIndex >= 1)
            {
                int openDay = ServerHelper.GetOpenServerDay( false, self.Zone() );

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

                    float coffi = ComHelp.GetMineCoefficient(openDay, petMingPlayers[i].MineType, petMingPlayers[i].Postion, self.DBDayActivityInfo.PetMingHexinList);

                    MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(petMingPlayers[i].MineType);
                    int chanchu = (int)(mineBattleConfig.GoldOutPut * coffi * (self.CheckIndex / 60f));

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
                self.CheckIndex = 0;
            }
        }
        
        
        public static async ETTask InitDayActivity(this ActivityServerComponent self)
        {
            int zone = self.Zone();
            ActorId dbCacheId = UnitCacheHelper.GetDbCacheId(zone);
            await  self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(1000,2000));
            DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB()<>(zone);
            
            List<DBDayActivityInfo> dbDayActivityInfos = await dbComponent.Query<DBDayActivityInfo>(zone, d => d.Id == zone);
            if (dbDayActivityInfos == null || dbDayActivityInfos.Count == 0)
            {
                self.DBDayActivityInfo = self.AddComponentWithId<DBDayActivityInfo>(zone);
            }
            else
            {
                self.DBDayActivityInfo = dbDayActivityInfos[0];
            }
            int openServerDay = ServerHelper.GetOpenServerDay(zone);
            Log.Debug($"InitDayActivity: {zone}  {openServerDay}");
            self.DBDayActivityInfo.MysteryItemInfos =  MysteryShopHelper.InitMysteryItemInfos( openServerDay);

            if (self.DBDayActivityInfo.PetMingHexinList.Count == 0)
            {
                self.InitPetMineExtend();
            }
            self.SaveDB();

            //每日活动
            self.Timer =  self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Minute, TimerType.ActivitySceneTimer, self);
        }
    }
}
