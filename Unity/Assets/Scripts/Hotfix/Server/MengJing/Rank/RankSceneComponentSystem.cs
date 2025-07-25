using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof (RankSceneComponent))]
    [FriendOf(typeof (RankSceneComponent))]
    public static partial class RankSceneComponentSystem
    {
        
        [Invoke(TimerInvokeType.RankeTimer)]
        public class RankeTimer: ATimer<RankSceneComponent>
        {
            protected override void Run(RankSceneComponent self)
            {
                try
                {
                    self.SaveDB().Coroutine();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this RankSceneComponent self)
        {
            self.InitServerInfo().Coroutine();
            self.InitDBRankInfo().Coroutine();

            //self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Minute * 30 + RandomHelper.RandomNumber(1000, 10000),
           //     TimerInvokeType.RankeTimer, self);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(RandomHelper.RandomNumber(1000, 10000),
                TimerInvokeType.RankeTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this RankSceneComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static async ETTask InitServerInfo(this RankSceneComponent self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second);
            DBServerInfo dBServerInfo = await UnitCacheHelper.GetComponent<DBServerInfo>(self.Root(), self.Id);
            
            if (dBServerInfo == null)
            {
                dBServerInfo = self.AddComponent<DBServerInfo>();
            }

            if (dBServerInfo.ServerInfo == null)
            {
                dBServerInfo.ServerInfo  = ServerInfo.Create();
            }

            //初始化参数
            self.DBServerInfo = dBServerInfo;
            self.UpdateExchangeGold(ServerHelper.GetServeOpenDay(  self.Zone()));
            //上午重启不刷新世界等级
            DateTime dateTime = TimeHelper.DateTimeNow();
            if (self.DBServerInfo.ServerInfo.WorldLv == 0 || dateTime.Hour >= 12)
            {
                self.UpdateWorldLv();
            }

            self.BroadcastWorldLv().Coroutine();
        }


        public static void UpdateWorldLv(this RankSceneComponent self)
        {
            //第二天并且超过12点才刷新
            int openserverDay = ServerHelper.GetServeOpenDay( self.Zone());
            int worldLv = CommonHelperS.GetWorldLv(openserverDay);
            self.DBServerInfo.ServerInfo.WorldLv = worldLv;
            Log.Debug($"UpdateWorldLv: {self.Zone()} {worldLv}");
        }

        public static async ETTask BroadcastWorldLv(this RankSceneComponent self)
        {
            //延迟刷新，以免有些服务器还没启动
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(5000, 10000));

            A2A_BroadcastProcessRequest A2A_BroadcastRequest = A2A_BroadcastProcessRequest.Create();
            A2A_BroadcastRequest.LoadType = 2;
            A2A_BroadcastRequest.LoadValue = self.Zone().ToString();
            A2A_BroadcastRequest.ServerInfo = self.DBServerInfo.ServerInfo;
            BroadCastHelper.BroadcastProcess(self.Root(), A2A_BroadcastRequest ).Coroutine();
        }

        public static void ClearRankingTrial(this RankSceneComponent self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            if (self.Zone() == 1 && dateTime.Year == 2023 && dateTime.Month == 12 && dateTime.Day == 30)
            {
                self.DBRankInfo.rankingTrial.Clear();
                Log.Warning("self.DBRankInfo.rankingTrial.Clear");
            }
        }

        public static void OnHour12Update(this RankSceneComponent self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();

            self.UpdateWorldLv();
            self.BroadcastWorldLv().Coroutine();
        }

        public static void OnZeroClockUpdate(this RankSceneComponent self)
        {
            //更新服务器拍卖行数据
            //TimeHelper. self.OpenServiceTime
            self.UpdateExchangeGold(ServerHelper.GetServeOpenDay( self.Zone()));
            self.SendCombatReward().Coroutine();
            self.SendPetReward().Coroutine();
            self.SendTrialReward().Coroutine();
            self.SendSeasonTowerReward().Coroutine();
            self.BroadcastWorldLv().Coroutine();

            self.DBRankInfo.rankShowLie.Clear();
            self.DBRankInfo.rankUnionRace.Clear();
            self.DBRankInfo.rankRunRace.Clear();
            self.DBRankInfo.rankingDemon.Clear();
        }

        //更新兑换金币
        public static void UpdateExchangeGold(this RankSceneComponent self, int dayTime)
        {
            int duihuan_baseGold = 1500; //基础兑换值
            float duihuanPro = 0.05f;
            //最多计算20天后的物价
            if (dayTime > 30)
            {
                dayTime = 30;
            }

            //计算物价
            int duihuanDay = dayTime;
            if (duihuanDay >= 30)
            {
                duihuanDay = 30;
            }

            duihuanPro = duihuanPro * duihuanDay;
            /*
            if (dayTime > 0 && dayTime <= 7)
            {
                duihuanPro = duihuanPro * dayTime;
            }

            //计算物价
            if (dayTime > 7 && dayTime <= 18)
            {
                duihuanPro = 7 * 0.05f + (dayTime - 7) * 0.1f;
            }

            //计算物价
            if (dayTime > 18)
            {
                duihuanPro = 7 * 0.15f + 11 * 0.1f + (dayTime - 18) * 0.05f;
            }
            */

            int nowDuiHuanGold = (int)(duihuan_baseGold + duihuan_baseGold * duihuanPro);

            //随机值5%浮动
            Random random = new Random();
            float duihuan_randomValue = random.Next(10);
            duihuan_randomValue = duihuan_randomValue / 100f;
            if (duihuan_randomValue >= 0.1f)
            {
                duihuan_randomValue = 0.1f;
            }

            int duihuan_nowGold = (int)((float)nowDuiHuanGold * (0.95f + duihuan_randomValue));

            Log.Info("今日货币兑换值:" + duihuan_nowGold + " dayTime = " + dayTime);
            //最低不能低于昨天的兑换值
            if (duihuan_nowGold >= self.DBServerInfo.ServerInfo.ExChangeGold)
            {
                if (duihuan_nowGold < 500)
                {
                    duihuan_nowGold = 500;
                }

                self.DBServerInfo.ServerInfo.ExChangeGold = duihuan_nowGold;
                Log.Info("更新货币兑换值:" + self.DBServerInfo.ServerInfo.ExChangeGold);
            }

            self.DBServerInfo.ServerInfo.ChouKaDropId =
                    ConfigData.ChouKaDropId[RandomHelper.RandomNumber(0, ConfigData.ChouKaDropId.Count)];
        }

        public static async ETTask InitDBRankInfo(this RankSceneComponent self)
        {
           
            await self.Root().GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second);
            DBRankInfo dBRankInfo = await UnitCacheHelper.GetComponent<DBRankInfo>(self.Root(), self.Id);
                    
            if (dBRankInfo == null)
            {
                dBRankInfo = self.AddComponent<DBRankInfo>();
            }
            self.DBRankInfo = dBRankInfo;
            self.DBRankInfo.rankRunRace.Clear();
            self.DBRankInfo.rankingDemon.Clear();

            for (int i = 0; i < self.DBRankInfo.rankingPets.Count; i++)
            {
                RankPetInfo rankPetInfo = self.DBRankInfo.rankingPets[i];
                
                for (int pet = 0; pet < rankPetInfo.PetConfigId.Count; pet++)
                {
                    if (!PetConfigCategory.Instance.Contain(rankPetInfo.PetConfigId[pet]))
                    {
                        rankPetInfo.PetConfigId[pet] = 310101;
                    }
                }
            }

            self.UpdateRankPetList();
        }

        public static async ETTask UpdateCombat(this RankSceneComponent self)
        {
            Log.Debug($"UpdateCombatUpdateCombat: {self.Zone()}");
            self.Scene().RemoveComponent<UnitComponent>();
            self.Scene().AddComponent<UnitComponent>();
            List<RankingInfo> rankingInfoList = new List<RankingInfo>();
            for (int i = self.DBRankInfo.rankingCombats.Count - 1; i >= 0; i--)
            {
                rankingInfoList.Add(self.DBRankInfo.rankingCombats[i]);
            }

            for (int i = rankingInfoList.Count - 1; i >= 0; i--)
            {
                RankingInfo rankingInfo = rankingInfoList[i];
                Unit unit = await UnitCacheHelper.GetUnitCache(self.Scene(), rankingInfo.UserId);
                Function_Fight.UnitUpdateProperty_Base(unit, false, false);

                RankingInfo rankPetInfo = RankingInfo.Create();
                UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                rankPetInfo.UserId = userInfoComponent.UserInfo.UserId;
                rankPetInfo.PlayerName = userInfoComponent.UserInfo.Name;
                rankPetInfo.PlayerLv = userInfoComponent.UserInfo.Lv;
                rankPetInfo.Combat = userInfoComponent.UserInfo.Combat;
                rankPetInfo.Occ = userInfoComponent.UserInfo.Occ;

                self.OnRecvRankUpdate(unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.AcvitiyCamp), rankPetInfo);
                unit.GetParent<UnitComponent>().Remove(unit.Id);
            }
        }

        public static async ETTask SaveDB(this RankSceneComponent self)
        {
            await UnitCacheHelper.SaveComponent(self.Root(), self.Zone(), self.DBRankInfo);
            await UnitCacheHelper.SaveComponent(self.Root(), self.Zone(), self.DBServerInfo);
        }

        /// <summary>
        /// 通知所有排名变化的玩家
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rankingInfo"></param>
        public static void UpdateRankList(this RankSceneComponent self, RankingInfo rankingInfo)
        {
            int oldRankIndex = -1;
            Dictionary<long, int> oldRankList = new Dictionary<long, int>();
            for (int i = 0; i < self.DBRankInfo.rankingCombats.Count; i++)
            {
                RankingInfo rankingInfoTemp = self.DBRankInfo.rankingCombats[i];
                if (oldRankList.ContainsKey(rankingInfoTemp.UserId))
                {
                    Log.Error($"oldRankList.ContainsKey(rankingInfoTemp.UserId): {rankingInfoTemp.UserId}");
                }
                else
                {
                    oldRankList.Add(rankingInfoTemp.UserId, i);
                }

                if (rankingInfoTemp.UserId == rankingInfo.UserId)
                {
                    oldRankIndex = i;
                }
            }

            if (oldRankIndex == -1)
            {
                self.DBRankInfo.rankingCombats.Add(rankingInfo);
            }
            else
            {
                self.DBRankInfo.rankingCombats[oldRankIndex] = rankingInfo;
            }

            self.DBRankInfo.rankingCombats.Sort(delegate(RankingInfo a, RankingInfo b) { return (int)b.Combat - (int)a.Combat; });

            if (self.DBRankInfo.rankingCombats.Count > 500)
            {
                self.DBRankInfo.rankingCombats.RemoveAt(self.DBRankInfo.rankingCombats.Count - 1);
            }

            List<long> updateRankList = new List<long>();
            for (int i = 0; i < self.DBRankInfo.rankingCombats.Count; i++)
            {
                RankingInfo rankingInfoTemp = self.DBRankInfo.rankingCombats[i];
                if (!oldRankList.ContainsKey(rankingInfoTemp.UserId) || oldRankList[rankingInfoTemp.UserId] != i)
                {
                    updateRankList.Add(rankingInfoTemp.UserId);
                }
            }

            for (int i = 0; i < updateRankList.Count; i++)
            {
                self.UpdateRankNo1(updateRankList[i], rankingInfo.Occ).Coroutine();
            }
            
            
            self.SaveDB().Coroutine();
        }

        /// <summary>
        /// 第一名有变化则通知
        /// </summary>
        /// <param name="self"></param>
        /// <param name="rankingInfo"></param>
        public static void UpdateRankList_Old(this RankSceneComponent self, RankingInfo rankingInfo)
        {
            bool have = false;

            long oldNo1 = 0;
            long newNo1 = 0;

            for (int i = 0; i < self.DBRankInfo.rankingCombats.Count; i++)
            {
                RankingInfo rankingInfoTemp = self.DBRankInfo.rankingCombats[i];
                if (i == 0)
                {
                    oldNo1 = rankingInfoTemp.UserId;
                }

                if (rankingInfoTemp.UserId == rankingInfo.UserId)
                {
                    self.DBRankInfo.rankingCombats[i] = rankingInfo;
                    have = true;
                    break;
                }
            }

            if (!have)
            {
                if (self.DBRankInfo.rankingCombats.Count < 500)
                {
                    self.DBRankInfo.rankingCombats.Add(rankingInfo);
                }
                else
                {
                    if (self.DBRankInfo.rankingCombats.LastOrDefault().Combat < rankingInfo.Combat)
                    {
                        self.DBRankInfo.rankingCombats[self.DBRankInfo.rankingCombats.Count - 1] = rankingInfo;
                    }
                }
            }

            self.DBRankInfo.rankingCombats.Sort(delegate(RankingInfo a, RankingInfo b) { return (int)b.Combat - (int)a.Combat; });

            newNo1 = self.DBRankInfo.rankingCombats[0].UserId;
            if (oldNo1 == newNo1)
            {
                //self.UpdateRankNo1(newNo1).Coroutine();
            }
            else
            {
                //self.UpdateRankNo1(oldNo1).Coroutine();
                //self.UpdateRankNo1(newNo1).Coroutine();
            }
        }

        /// <summary>
        /// 通知排行榜第一刷新
        /// </summary>
        public static async ETTask UpdateRankNo1(this RankSceneComponent self, long userId, int occ)
        {
            int zone = self.Zone();
            if (ServerHelper.GetServeOpenDay( zone) < 3)
            {
                return;
            }

            int rankId = self.GetCombatRank(userId);
            if (rankId <= 0)
            {
                return;
            }

            //通知玩家
            R2M_RankUpdateMessage r2M_RankUpdateMessage = R2M_RankUpdateMessage.Create();
            r2M_RankUpdateMessage.RankType = 1;
            r2M_RankUpdateMessage.RankId = rankId;
            r2M_RankUpdateMessage.OccRankId = self.GetOccCombatRank(userId, occ);
            self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(userId, r2M_RankUpdateMessage);
            await ETTask.CompletedTask;
        }

        public static int GetTrialRank(this RankSceneComponent self, long userId)
        {
            for (int i = 0; i < self.DBRankInfo.rankingTrial.Count; i++)
            {
                if (self.DBRankInfo.rankingTrial[i].KeyId == userId)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        public static int GetSeasonTowerRank(this RankSceneComponent self, long userId)
        {
            for (int i = 0; i < self.DBRankInfo.rankSeasonTower.Count; i++)
            {
                if (self.DBRankInfo.rankSeasonTower[i].KeyId == userId)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        public static int GetPetRank(this RankSceneComponent self, long userId)
        {
            for (int i = 0; i < self.DBRankInfo.rankingPets.Count; i++)
            {
                RankPetInfo rankPetInfo = self.DBRankInfo.rankingPets[i];
                if (rankPetInfo.UserId == userId)
                {
                    return rankPetInfo.RankId;
                }
            }

            return 0;
        }

        public static int GetCombatRank(this RankSceneComponent self, long usrerId)
        {
            for (int i = 0; i < self.DBRankInfo.rankingCombats.Count; i++)
            {
                if (self.DBRankInfo.rankingCombats[i].UserId == usrerId)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        public static int GetOccCombatRank(this RankSceneComponent self, long usrerId, int occ)
        {
            int ocRank = 0;
            for (int i = 0; i < self.DBRankInfo.rankingCombats.Count; i++)
            {
                RankingInfo rankingInfo = self.DBRankInfo.rankingCombats[i];
                if (rankingInfo.Occ == occ)
                {
                    ocRank++;
                }

                if (rankingInfo.UserId == usrerId)
                {
                    return ocRank;
                }
            }

            return ocRank;
        }

        public static void UpdateCampRankList(this RankSceneComponent self, int campId, RankingInfo rankingInfo)
        {
            if (campId == 0)
            {
                return;
            }

            //清除在其他阵营的排名
            List<RankingInfo> rankList = campId == 1? self.DBRankInfo.rankingCamp2 : self.DBRankInfo.rankingCamp1;
            for (int i = rankList.Count - 1; i >= 0; i--)
            {
                if (rankList[i].UserId == rankingInfo.UserId)
                {
                    rankList.RemoveAt(i);
                    break;
                }
            }

            bool have = false;
            rankList = campId == 1? self.DBRankInfo.rankingCamp1 : self.DBRankInfo.rankingCamp2;
            for (int i = 0; i < rankList.Count; i++)
            {
                if (rankList[i].UserId == rankingInfo.UserId)
                {
                    rankList[i] = rankingInfo;
                    have = true;
                    break;
                }
            }

            if (!have)
            {
                if (rankList.Count < CommonHelp.CampRankNumber)
                {
                    rankList.Add(rankingInfo);
                }
                else
                {
                    if (rankList.LastOrDefault().Combat < rankingInfo.Combat)
                    {
                        rankList[rankList.Count - 1] = rankingInfo;
                    }
                }
            }

            rankList.Sort(delegate(RankingInfo a, RankingInfo b) { return (int)b.Combat - (int)a.Combat; });
        }

        public static void UpdateWorldLevel(this RankSceneComponent self, RankingInfo rankingInfo)
        {
            ServerInfo serverInfo = self.DBServerInfo.ServerInfo;
            //if (rankingInfo.PlayerLv < serverInfo.WorldLv)
            //{
            //    return;
            //}
            if (serverInfo.RankingInfo == null)
            {
                serverInfo.RankingInfo = rankingInfo;
                self.BroadcastWorldLv().Coroutine();
                return;
            }

            if (serverInfo.RankingInfo.PlayerLv < rankingInfo.PlayerLv)
            {
                serverInfo.RankingInfo = rankingInfo;
                self.BroadcastWorldLv().Coroutine();
            }
        }

        public static void OnRecvRankUpdate(this RankSceneComponent self, int campId, RankingInfo rankingInfo)
        {
            self.UpdateWorldLevel(rankingInfo);
            self.UpdateRankList(rankingInfo);
            self.UpdateCampRankList(campId, rankingInfo);
        }

        public static void UpdateRankPetList(this RankSceneComponent self)
        {
            //读机器人配置表
            if (self.DBRankInfo.rankingPets.Count > 0)
            {
                return;
            }

            List<int> allPet = new List<int>()
            {
                310101,
                310102,
                310103,
                310104,
                310105,
                310106,
                310107,
            };
            for (int i = 0; i < CommonHelp.PetRankNumber; i++)
            {
                int[] indexs = RandomHelper.GetRandoms(3, 0, allPet.Count);
                List<int> pets = new List<int>();
                int combat = 0;
                for (int p = 0; p < indexs.Length; p++)
                {
                    pets.Add(allPet[p]);
                    combat += RandomHelper.RandomNumber(500, 700);
                }

                RankPetInfo RankPetInfo = RankPetInfo.Create();
                RankPetInfo.UserId = IdGenerater.Instance.GenerateId();
                RankPetInfo.TeamName = "机器人:" + (i + 1) + "的队伍";
                RankPetInfo.RankId = i + 1;
                RankPetInfo.PlayerName = "机器人:" + (i + 1);
                RankPetInfo.PetUId = new List<long>() { 0, 0, 0 };
                RankPetInfo.PetConfigId = pets;
                RankPetInfo.Combat = combat;
                self.DBRankInfo.rankingPets.Add(RankPetInfo);
            }
        }

        public static void OnRecvPetRank(this RankSceneComponent self, M2R_PetRankUpdateRequest m2R_PetRankUpdateRequest)
        {
            RankPetInfo enemyRankPetInfo = null;
            RankPetInfo selfRankPetInfo = null;

            for (int i = 0; i < self.DBRankInfo.rankingPets.Count; i++)
            {
                RankPetInfo rankPetInfo = self.DBRankInfo.rankingPets[i];
                if (rankPetInfo.UserId == m2R_PetRankUpdateRequest.RankPetInfo.UserId)
                {
                    selfRankPetInfo = rankPetInfo;
                }

                if (rankPetInfo.UserId == m2R_PetRankUpdateRequest.EnemyId)
                {
                    enemyRankPetInfo = rankPetInfo;
                }
            }

            //没找到对方或者高于对方排名，不更新排名
            if (enemyRankPetInfo != null)
            {
                if (selfRankPetInfo != null)
                {
                    if (selfRankPetInfo.RankId > enemyRankPetInfo.RankId)
                    {
                        int selfRank = selfRankPetInfo.RankId;
                        selfRankPetInfo.RankId = enemyRankPetInfo.RankId;
                        enemyRankPetInfo.RankId = selfRank;
                    }
                }
                else
                {
                    m2R_PetRankUpdateRequest.RankPetInfo.RankId = enemyRankPetInfo.RankId;
                    self.DBRankInfo.rankingPets.Remove(enemyRankPetInfo);
                    self.DBRankInfo.rankingPets.Add(m2R_PetRankUpdateRequest.RankPetInfo);
                }
            }

            self.DBRankInfo.rankingPets.Sort(delegate(RankPetInfo a, RankPetInfo b) { return a.RankId - b.RankId; });
            for (int i = 0; i < self.DBRankInfo.rankingPets.Count; i++)
            {
                self.DBRankInfo.rankingPets[i].RankId = i + 1;
            }
        }

        public static List<RankPetInfo> GetRankPetList(this RankSceneComponent self, int rankNumber)
        {
            List<RankPetInfo> rankPetInfos = new List<RankPetInfo>();
            List<int> indexList = new List<int>();

            //前四名只找1-10名
            if (rankNumber >= 1 && rankNumber <= 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i != (rankNumber - 1))
                    {
                        indexList.Add(i);
                    }
                }

                int index = RandomHelper.RandomNumber(3, 10);
                indexList.Add(index);
                indexList.Add(index + 1);
            }
            else
            {
                int randomNumber = 0;

                while (indexList.Count < 4)
                {
                    if (randomNumber > 200)
                    {
                        Log.Warning($"randomNumber > 200:  {randomNumber}");
                        Log.Console($"randomNumber > 200:  {randomNumber}");
                        break;
                    }

                    int index = 0;
                    if (rankNumber == 0) //没上榜就找排行榜最后十名
                        index = RandomHelper.RandomNumber(self.DBRankInfo.rankingPets.Count - 10, self.DBRankInfo.rankingPets.Count);
                    else if (rankNumber > 10) //大于10名找比自己排行前十名的
                        index = RandomHelper.RandomNumber(rankNumber - 11, rankNumber - 1);
                    else // 4<rankNumber<=10 ,前面取俩个，后面取一个
                    {
                        if (indexList.Count < 2)
                        {
                            index = RandomHelper.RandomNumber(0, rankNumber - 1);
                        }
                        else
                        {
                            index = RandomHelper.RandomNumber(rankNumber, 11);
                        }
                    }

                    if (!indexList.Contains(index))
                    {
                        indexList.Add(index);
                    }

                    randomNumber++;
                }
            }

            indexList.Sort();

            for (int i = 0; i < indexList.Count; i++)
            {
                RankPetInfo rankPetInfo = self.DBRankInfo.rankingPets[indexList[i]];
                if (rankPetInfo.Combat == 0)
                {
                    rankPetInfo.Combat = RandomHelper.RandomNumber(500 , 700) * rankPetInfo.PetConfigId.Count;
                }

                rankPetInfos.Add(rankPetInfo);
            }

            return rankPetInfos;
        }

        public static void OnDeleteRole(this RankSceneComponent self, List<RankPetInfo> rankingInfos, long userId)
        {
            for (int i = rankingInfos.Count - 1; i >= 0; i--)
            {
                if (rankingInfos[i].UserId == userId)
                {
                    rankingInfos.RemoveAt(i);
                    break;
                }
            }
        }

        public static void OnDeleteRole(this RankSceneComponent self, List<RankingInfo> rankingInfos, long userId)
        {
            for (int i = rankingInfos.Count - 1; i >= 0; i--)
            {
                if (rankingInfos[i].UserId == userId)
                {
                    rankingInfos.RemoveAt(i);
                    break;
                }
            }
        }

        public static void OnShowLieBegin(this RankSceneComponent self)
        {
            self.DBRankInfo.rankShowLie.Clear();
            self.BroadcastShowLie("1").Coroutine();
        }

        public static async ETTask BroadcastShowLie(this RankSceneComponent self, string loadvalue)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second * 10);
            ServerHelper.GetServerList(VersionMode.Beta);

            int firstserver = 0;
            for (int i = 0; i < ConfigData.ServerItems.Count; i++)
            {
                if (ConfigData.ServerItems[i].Show == 1)
                {
                    firstserver = ConfigData.ServerItems[i].ServerId;
                    break;
                }
            }

            if (firstserver == self.Zone())
            {
                Log.Debug($"BroadcastShowLie:  {self.Zone()}");
                Log.Console($"BroadcastShowLie:  {self.Zone()} {loadvalue}");
                
                A2A_BroadcastProcessRequest A2A_BroadcastRequest = A2A_BroadcastProcessRequest.Create();
                A2A_BroadcastRequest.LoadType = 1;
                A2A_BroadcastRequest.LoadValue = loadvalue;
                BroadCastHelper.BroadcastProcess(self.Root(), A2A_BroadcastRequest ).Coroutine();
            }
        }

        public static async ETTask OnDemonOver(this RankSceneComponent self)
        {
            int zone = self.Zone();

            Log.Warning($"发放恶魔排行榜奖励： {zone}");
            long serverTime = TimeHelper.ServerNow();
            List<RankingInfo> rankingInfos = self.DBRankInfo.rankingDemon;
            ActorId mailServerId = UnitCacheHelper.GetMailServerId(self.Zone());
            for (int i = 0; i < rankingInfos.Count; i++)
            {
                RankRewardConfig rankRewardConfig = RankHelper.GetRankReward(i + 1, 5);
                if (rankRewardConfig == null)
                {
                    continue;
                }

                MailInfo mailInfo = MailInfo.Create();

                Log.Warning($"发放恶魔排行榜奖励2： {rankingInfos[i].UserId}");

                mailInfo.Status = 0;
                mailInfo.Context = $"恭喜您获得恶魔排行榜第{i + 1}名奖励";
                mailInfo.Title = "恶魔排行榜奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();

                string[] needList = rankRewardConfig.RewardItems.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }

                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    BagInfo BagInfo = BagInfo.Create();
                    BagInfo.ItemID = itemId;
                    BagInfo.ItemNum = itemNum;
                    BagInfo.GetWay = $"{ItemGetWay.Demon}_{serverTime}";
                    mailInfo.ItemList.Add(new () { });
                }

                MailHelp.SendUserMail( self.Root(),  rankingInfos[i].UserId, mailInfo, ItemGetWay.Demon).Coroutine();
                await ETTask.CompletedTask;
            }
        }

        //公会战结束
        public static async ETTask OnUnionRaceOver(this RankSceneComponent self)
        {
            int zone = self.Zone();

            Log.Warning($"发放公会战排行榜奖励： {zone}");
            long serverTime = TimeHelper.ServerNow();
            List<RankShouLieInfo> rankingInfos = self.DBRankInfo.rankUnionRace;
            ActorId mailServerId = StartSceneConfigCategory.Instance.GetBySceneName(self.Zone(), "EMail").ActorId;
            for (int i = 0; i < rankingInfos.Count; i++)
            {
                RankRewardConfig rankRewardConfig = RankHelper.GetRankReward(i + 1, 4);
                if (rankRewardConfig == null)
                {
                    continue;
                }

                MailInfo mailInfo = MailInfo.Create();

                Log.Warning($"发放公会战排行榜奖励2： {rankingInfos[i].UnitID}");

                mailInfo.Status = 0;
                mailInfo.Context = $"恭喜您获得公会战排行榜第{i + 1}名奖励";
                mailInfo.Title = "公会战排行榜奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();

                string[] needList = rankRewardConfig.RewardItems.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }

                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    ItemInfoProto BagInfo = ItemInfoProto.Create();
                    BagInfo.ItemID = itemId;
                    BagInfo.ItemNum = itemNum;
                    BagInfo.GetWay = $"{ItemGetWay.ShowLie}_{serverTime}";
                    mailInfo.ItemList.Add(BagInfo);
                }

                await MailHelp.SendUserMail(self.Root(), rankingInfos[i].UnitID, mailInfo, ItemGetWay.ShowLie);
            }
        }

        //发送狩猎排行奖励
        public static async ETTask OnShowLieOver(this RankSceneComponent self)
        {
            int zone = self.Zone();
            self.BroadcastShowLie("0").Coroutine();

            Log.Console($"发放狩猎排行榜奖励： {zone}");
            Log.Debug($"发放狩猎排行榜奖励： {zone}");
            long serverTime = TimeHelper.ServerNow();
            List<RankShouLieInfo> rankingInfos = self.DBRankInfo.rankShowLie;
            ActorId mailServerId = StartSceneConfigCategory.Instance.GetBySceneName(self.Zone(), "EMail").ActorId;
            for (int i = 0; i < rankingInfos.Count; i++)
            {
                RankRewardConfig rankRewardConfig = RankHelper.GetRankReward(i + 1, 3);
                if (rankRewardConfig == null)
                {
                    continue;
                }

                MailInfo mailInfo = MailInfo.Create();

                mailInfo.Status = 0;
                mailInfo.Context = $"恭喜您获得狩猎排行榜第{i + 1}名奖励";
                mailInfo.Title = "狩猎排行榜奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();
                Log.Debug(
                    $"发放狩猎排行榜奖励：zone. {zone} rankid.{i + 1}  unitid.{rankingInfos[i].UnitID}  {rankingInfos[i].PlayerName}  {rankingInfos[i].KillNumber}");
                string[] needList = rankRewardConfig.RewardItems.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }

                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    mailInfo.ItemList.Add(ItemHelper.GetBagInfo(itemId, itemNum, ItemGetWay.RankReward));
                }

                await MailHelp.SendUserMail(self.Root(), rankingInfos[i].UnitID, mailInfo, ItemGetWay.RankReward);
            }
        }

        /// <summary>
        /// 发送试炼副本奖励
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask SendTrialReward(this RankSceneComponent self)
        {
            int zone = self.Zone();
            await self.Root().GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second * 10);
            DateTime dateTime = TimeHelper.DateTimeNow();
            if ((int)dateTime.DayOfWeek != 1)
            {
                return;
            }

            Log.Debug($"发放试炼排行榜奖励： {zone}");
            Log.Console($"发放试炼排行榜奖励： {zone}");
            long serverTime = TimeHelper.ServerNow();
            List<KeyValuePairLong> rankingInfos = self.DBRankInfo.rankingTrial;
            ActorId mailServerId = StartSceneConfigCategory.Instance.GetBySceneName(self.Zone(), "EMail").ActorId;
            for (int i = 0; i < rankingInfos.Count; i++)
            {
                RankRewardConfig rankRewardConfig = RankHelper.GetRankReward(i + 1, 6);
                if (rankRewardConfig == null)
                {
                    continue;
                }

                MailInfo mailInfo = MailInfo.Create();

                mailInfo.Status = 0;
                mailInfo.Context = $"恭喜您获得试炼排行榜第{i + 1}名奖励";
                mailInfo.Title = "排行榜奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();

                if (i <= 10)
                {
                    Log.Warning($"试炼奖励: {self.Zone()} {rankingInfos[i].KeyId}");
                }

                string[] needList = rankRewardConfig.RewardItems.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }

                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    mailInfo.ItemList.Add(ItemHelper.GetBagInfo(itemId, itemNum, ItemGetWay.RankReward));
                }

                await MailHelp.SendUserMail(self.Root(), rankingInfos[i].KeyId, mailInfo, ItemGetWay.RankReward);
            }

            self.DBRankInfo.rankingTrial.Clear();
        }

        public static async ETTask SendSeasonTowerReward(this RankSceneComponent self)
        {
            int zone = self.Zone();
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(5000, 10000));
            DateTime dateTime = TimeHelper.DateTimeNow();
            if (dateTime.DayOfWeek != DayOfWeek.Monday)
            {
                return;
            }

            Log.Debug($"发放赛季之塔排行榜奖励： {zone}");
            long serverTime = TimeHelper.ServerNow();
            List<KeyValuePairLong> rankingInfos = self.DBRankInfo.rankSeasonTower;
            ActorId mailServerId = StartSceneConfigCategory.Instance.GetBySceneName(self.Zone(), "EMail").ActorId;
            for (int i = 0; i < rankingInfos.Count; i++)
            {
                RankRewardConfig rankRewardConfig = RankHelper.GetRankReward(i + 1, 7);
                if (rankRewardConfig == null)
                {
                    continue;
                }

                MailInfo mailInfo = MailInfo.Create();

                mailInfo.Status = 0;
                mailInfo.Context = $"恭喜您获得赛季之塔第{i + 1}名奖励";
                mailInfo.Title = "赛季之塔奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();

                if (i <= 10)
                {
                    Log.Warning($"赛季之塔奖励: {self.Zone()} {rankingInfos[i].KeyId}");
                }

                string[] needList = rankRewardConfig.RewardItems.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }

                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    mailInfo.ItemList.Add(  ItemHelper.GetBagInfo(itemId, itemNum, ItemGetWay.RankReward) );
                }

                await MailHelp.SendUserMail(self.Root(), rankingInfos[i].KeyId, mailInfo, ItemGetWay.RankReward);
            }

            self.DBRankInfo.rankSeasonTower.Clear();
            await ETTask.CompletedTask;
        }

        /// <summary>
        /// 发送战力排行奖励
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask SendCombatReward(this RankSceneComponent self)
        {
            int zone = self.Zone();
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(5000, 10000));
            DateTime dateTime = TimeHelper.DateTimeNow();
            if (!RankHelper.HaveReward(1, (int)dateTime.DayOfWeek))
            {
                return;
            }
            
            Log.Debug($"发放战力排行榜奖励： {zone}");

            self.DBRankInfo.LastRewardCombatIds.Count();
            List<RankingInfo> rankingInfos = self.DBRankInfo.rankingCombats;

            for (int i = 0; i < rankingInfos.Count; i++)
            {
                RankRewardConfig rankRewardConfig = RankHelper.GetRankReward(i + 1, 1);
                if (rankRewardConfig == null)
                {
                    continue;
                }
                
                MailInfo mailInfo = MailInfo.Create();

                mailInfo.Status = 0;
                mailInfo.Context = $"恭喜您获得排行榜第{i + 1}名奖励";
                mailInfo.Title = "排行榜奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();

                long userId = rankingInfos[i].UserId;
                if (i <= 10)
                {
                    Log.Warning($"战力奖励: {self.Zone()} {userId}");
                }
                if (i == 0)
                {
                    self.DBRankInfo.LastRewardCombatIds.Add(userId);
                }

                string[] needList = rankRewardConfig.RewardItems.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }

                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    mailInfo.ItemList.Add(   ItemHelper.GetBagInfo(itemId, itemNum, ItemGetWay.RankReward) );
                }

                await MailHelp.SendUserMail(self.Root(), userId, mailInfo, ItemGetWay.RankReward);
            }
        }

        public static async ETTask SendPetReward(this RankSceneComponent self)
        {
            int zone = self.Zone();
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(1000, 10000));
            DateTime dateTime = TimeHelper.DateTimeNow();
            if (!RankHelper.HaveReward(2, (int)dateTime.DayOfWeek))
            {
                return;
            }

            Log.Debug($"发放宠物排行榜奖励： {zone}");
            
            self.DBRankInfo.LastRewardPetIds.Clear();
            List<RankPetInfo> rankingInfos = self.DBRankInfo.rankingPets;
            for (int i = 0; i < rankingInfos.Count; i++)
            {
                bool havePetUId = false;
                for (int k = 0; k < rankingInfos[i].PetUId.Count; k++)
                {
                    if (rankingInfos[i].PetUId[k] > 0)
                    {
                        havePetUId = true;
                        break;
                    }
                }

                if (!havePetUId)
                {
                    continue;
                }

                RankRewardConfig rankRewardConfig = RankHelper.GetRankReward(i + 1, 2);
                if (rankRewardConfig == null)
                {
                    continue;
                }

                if (i == 0)
                {
                    self.DBRankInfo.LastRewardPetIds.Add(rankingInfos[i].UserId);
                }

                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Status = 0;
                mailInfo.Context = $"恭喜您获得排行榜第{i + 1}名奖励";
                mailInfo.Title = "排行榜奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();

                string[] needList = rankRewardConfig.RewardItems.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }

                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    mailInfo.ItemList.Add(   ItemHelper.GetBagInfo(itemId, itemNum, ItemGetWay.RankReward) );
                }

                await MailHelp.SendUserMail(self.Root(), rankingInfos[i].UserId, mailInfo, ItemGetWay.RankReward);
            }
        }
    }
}