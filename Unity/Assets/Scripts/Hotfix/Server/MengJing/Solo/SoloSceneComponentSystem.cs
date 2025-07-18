using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (SoloSceneComponent))]
    [FriendOf(typeof (SoloSceneComponent))]
    public static partial class SoloSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SoloSceneComponent self)
        {
        }

        //每日零点清理竞技场更新数据
        public static void OnZeroClockUpdate(this SoloSceneComponent self)
        {
        }

        public static async ETTask UpdateSoloRank(this SoloSceneComponent self, long unitid, int rankid)
        {

            R2M_RankUpdateMessage r2M_RankUpdateMessage = R2M_RankUpdateMessage.Create();
            r2M_RankUpdateMessage.RankType = 4;
            r2M_RankUpdateMessage.RankId = rankid;
            self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitid, r2M_RankUpdateMessage);
            await ETTask.CompletedTask;
        }

        public static async ETTask OnSoloBegin(this SoloSceneComponent self)
        {
            //通知机器人
            /*
            if (DBHelper.GetOpenServerDay(self.DomainZone()) > 0)
            {
                long robotSceneId = StartSceneConfigCategory.Instance.GetBySceneName(203, "Robot01").InstanceId;
                MessageHelper.SendActor(robotSceneId, new G2Robot_MessageRequest() { Zone = self.DomainZone(), MessageType = NoticeType.SoloBegin });
            }
            */
            Console.WriteLine($"OnSoloBegin: {self.Zone()}");

            //清除之前的排名坐骑
            DBRankInfo dBRankInfo = await UnitCacheHelper.GetComponent<DBRankInfo>(self.Root(), self.Zone());
            if (dBRankInfo != null && dBRankInfo.rankSoloInfo.Count > 0)
            {
                self.UpdateSoloRank(dBRankInfo.rankSoloInfo[0].UserId, 0).Coroutine();
            }

            int trigger = 0;

            DateTime dateTime = TimeHelper.DateTimeNow();
            long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            long closeTime = FunctionHelp.GetCloseTime(1045);
            long leftTime = closeTime - curTime;
            long instanceid = self.InstanceId;

            //传入定时器,倒计时结束触发OnSoloOver
            for (int i = 0; i < leftTime; i++)
            {
                trigger++;
                await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
                if (instanceid != self.InstanceId)
                {
                    break;
                }

                //每5秒秒进行一次匹配效验
                if (trigger >= 5)
                {
                    trigger = 0;
                    self.CheckMatch(i).Coroutine();
                }
            }
        }

        public static async ETTask RecordSoloRank(this SoloSceneComponent self)
        {
            List<string> sololist = new List<string>();
            List<SoloPlayerResultInfo> soloPlayerList = self.GetSoloResult();
            
            for (int i = 0; i < soloPlayerList.Count; i++)
            {
                long combat = 0;
                self.PlayerCombatList.TryGetValue(soloPlayerList[i].UnitId, out combat);

                UserInfoComponentS userInfoComponent =
                        await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(self.Root(), soloPlayerList[i].UnitId);
                UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
                if (userInfoComponent == null)
                {
                    continue;
                }

                OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(soloPlayerList[i].Occ);
                string occName = occupationConfig.OccupationName;
                

                if (unionInfoCache.OccTwo > 0)
                {
                    occName = OccupationTwoConfigCategory.Instance.Get(unionInfoCache.OccTwo).OccupationName;
                }

                string soloInfo =
                        $"玩家: {soloPlayerList[i].Name}  击杀:{soloPlayerList[i].WinNum} 等级:{unionInfoCache.Lv} 职业:{occName}  战力:{combat}";
                sololist.Add(soloInfo);
            }

            ServerLogHelper.WriteLogList(sololist, $"../Logs/WJ_Solo/Rank_{self.Zone()}.txt", false);
        }
        
        //竞技场结束
        public static async ETTask OnSoloOver(this SoloSceneComponent self)
        {
            Log.Warning($"OnSoloOver: {self.Zone()}");

            self.MatchList.Clear();

            self.RecordSoloRank().Coroutine();

            Dictionary<long, int> dicSort = self.PlayerIntegralList.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);
            List<SoloPlayerResultInfo> soloResultInfoList = new List<SoloPlayerResultInfo>();

            int num = 0;
            long serverTime = TimeHelper.ServerNow();

            RankingInfo rankingInfo = null;
            //发送奖励
            foreach (long unitId in dicSort.Keys)
            {
                if (rankingInfo == null)
                {
                    rankingInfo = RankingInfo.Create();
                    rankingInfo.UserId = unitId;
                }

                num += 1;
                MailInfo mailInfo = MailInfo.Create();

                if (num == 1)
                {
                    mailInfo.ItemList.Add( ItemHelper.GetBagInfo(10000209, 1, ItemGetWay.SoloReward) );
                    mailInfo.ItemList.Add( ItemHelper.GetBagInfo(10010035, 30, ItemGetWay.SoloReward) );
                    mailInfo.ItemList.Add( ItemHelper.GetBagInfo(10010083, 30, ItemGetWay.SoloReward));
                }

                if (num == 2)
                {
                    mailInfo.ItemList.Add( ItemHelper.GetBagInfo(10010035, 20, ItemGetWay.SoloReward)  );
                    mailInfo.ItemList.Add( ItemHelper.GetBagInfo(10010083, 20, ItemGetWay.SoloReward));
                }

                if (num == 3)
                {
                    mailInfo.ItemList.Add( ItemHelper.GetBagInfo(10010035, 15, ItemGetWay.SoloReward) );
                    mailInfo.ItemList.Add(  ItemHelper.GetBagInfo(10010083, 15, ItemGetWay.SoloReward));
                }

                if (num == 4 || num == 5)
                {
                    mailInfo.ItemList.Add ( ItemHelper.GetBagInfo(10010035, 10, ItemGetWay.SoloReward)  );
                    mailInfo.ItemList.Add( ItemHelper.GetBagInfo(10010083, 10, ItemGetWay.SoloReward) );
                }

                if (num >= 6)
                {
                    mailInfo.ItemList.Add( ItemHelper.GetBagInfo(10010035, 5, ItemGetWay.SoloReward)   );
                    mailInfo.ItemList.Add(  ItemHelper.GetBagInfo(10010083, 5, ItemGetWay.SoloReward) );
                }

                mailInfo.Title = "竞技场第" + num + "名";
                mailInfo.Context = "恭喜你获得竞技场第" + num + "名，奖励如下。";
                MailHelp.SendUserMail(self.Root(), unitId, mailInfo, ItemGetWay.SoloReward).Coroutine();

                //只发送前100
                if (num >= 100)
                {
                    break;
                }
            }

            //第一名通知rankserver
            if (rankingInfo != null)
            {
                ActorId mapInstanceId = StartSceneConfigCategory.Instance.GetBySceneName(self.Zone(), "Rank").ActorId;
                S2R_SoloResultRequest S2R_SoloResultRequest = S2R_SoloResultRequest.Create();
                S2R_SoloResultRequest.CampId = -3;
                S2R_SoloResultRequest.RankingInfo = rankingInfo;
                R2S_SoloResultResponse Response = (R2S_SoloResultResponse)await self.Root().GetComponent<MessageSender>().Call(mapInstanceId,S2R_SoloResultRequest);
            }

            ActorId gateServerId = StartSceneConfigCategory.Instance.GetBySceneName(self.Zone(), "Gate1").ActorId;
            if (rankingInfo != null)
            {
                self.UpdateSoloRank(rankingInfo.UserId, 1).Coroutine();
            }

            //销毁所有场景
            List<long> childids = self.Children.Keys.ToList();
            //foreach ((long id, Entity entity) in self.Children)
            for (int i = 0; i < childids.Count; i++)
            {
                Entity entity = self.GetChild<Entity>(childids[i]);
                if (entity == null)
                {
                    continue;
                }

                Scene scene = entity as Scene;
                if (scene == null)
                {
                    continue;
                }

                scene.GetComponent<SoloDungeonComponent>().KickOutPlayer();
                await self.Root().GetComponent<TimerComponent>().WaitAsync(60000 + RandomHelper.RandomNumber(0, 1000));
                TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
            }

            //清理
            self.MatchResult.Clear();
            self.PlayerIntegralList.Clear();
            self.AllPlayerDateList.Clear();
            self.SoloResultInfoList.Clear();
        }

        public static void OnRecvUnitLeave(this SoloSceneComponent self, long userId)
        {
            for (int i = self.MatchList.Count - 1; i >= 0; i--)
            {
                if (self.MatchList[i].UnitId == userId)
                {
                    self.MatchList.RemoveAt(i);
                    Log.Debug($" 退出solo匹配 : {userId} ");
                }
            }
        }

        //加入竞技场匹配列表
        public static int OnJoinMatch(this SoloSceneComponent self, SoloPlayerInfo teamPlayerInfo)
        {
            //判断是否在当前的列表中
            for (int i = 0; i < self.MatchList.Count; i++)
            {
                if (self.MatchList[i].UnitId == teamPlayerInfo.UnitId)
                {
                    return ErrorCode.ERR_SoloExist;
                }
            }

            //获取次数
            if (self.AllPlayerDateList.ContainsKey(teamPlayerInfo.UnitId))
            {
                int joinNum = self.AllPlayerDateList[teamPlayerInfo.UnitId].WinNum + self.AllPlayerDateList[teamPlayerInfo.UnitId].FailNum;
                if (joinNum > 50)
                {
                    return ErrorCode.ERR_SoloNumMax;
                }
            }

            self.MatchList.Add(teamPlayerInfo);
            if (CommonHelperS.IsInnerNet())
            {
                self.MatchList.Add(teamPlayerInfo);
            }

            //添加积分列表
            if (!self.PlayerIntegralList.ContainsKey(teamPlayerInfo.UnitId))
            {
                self.PlayerIntegralList.Add(teamPlayerInfo.UnitId, 0);
            }

            return ErrorCode.ERR_Success;
        }

        //添加玩家缓存
        public static void OnAddSoloDateList(this SoloSceneComponent self, long unitID, string name, int occ)
        {
            if (!self.AllPlayerDateList.ContainsKey(unitID))
            {
                SoloPlayerInfo soloPlayerInfo = SoloPlayerInfo.Create();
                soloPlayerInfo.Name = name;
                soloPlayerInfo.Occ = occ;
                self.AllPlayerDateList.Add(unitID, soloPlayerInfo);
            }
        }

        //匹配监测机制
        public static async ETTask CheckMatch(this SoloSceneComponent self, int time)
        {
            //LogHelper.LogWarning("竞技场开始匹配 time =" + time, true);

            //超时移除
            long serverTime = TimeHelper.ServerNow();
            //匹配超过一定时间移除匹配列表
            //for (int i = self.MatchList.Count - 1; i >= 0; i--)
            //{
            //    if (serverTime - self.MatchList[i].MatchTime > 105*1000)
            //    { 
            //        self.MatchList.RemoveAt(i);
            //        continue;
            //    }
            //}

            //定义了一个比较器进行排序
            self.MatchList.Sort(delegate(SoloPlayerInfo a, SoloPlayerInfo b) { return (int)a.Combat - (int)b.Combat; });

            Dictionary<long, long> fubenids = new Dictionary<long, long>();

            //通知玩家
            List<SoloPlayerInfo> playerlist = new List<SoloPlayerInfo>();
            for (int i = self.MatchList.Count - 1; i >= 0; i--)
            {
                //两两匹配  i和t进行匹配
                int t = i - 1;
                if (t < 0)
                {
                    break;
                }

                //获取对应玩家数据
                SoloPlayerInfo soloPlayerInfo_i = self.MatchList[i];
                SoloPlayerInfo soloPlayerInfo_t = self.MatchList[t];

                //30,秒内 低战力/高战力>=0.8 60秒 低战力/高战力>= 0.6 90秒 低战力/高战力>=0)
                long passTime = (long)((serverTime - soloPlayerInfo_i.MatchTime) / 1000);
                float range = 1f; //战力调整系数
                if (passTime < 30)
                {
                    range = 0.7f;
                }
                else if (passTime < 60)
                {
                    range = 0.4f;
                }
                else
                {
                    range = 0f;
                }
                //这里还需要添加判断2个目标是否掉线

                float maxValue = math.max((float)soloPlayerInfo_i.Combat, (float)soloPlayerInfo_t.Combat);
                float minValue = math.min((float)soloPlayerInfo_i.Combat, (float)soloPlayerInfo_t.Combat);

                //获取双方战力进行匹配
                if (minValue / maxValue >= range)
                {
                    //匹配成功
                    i--;
                    self.MatchList.RemoveAt(t);

                    //存入匹配缓存数据,方便下面发送消息
                    playerlist.Add(soloPlayerInfo_i);
                    playerlist.Add(soloPlayerInfo_t);

                    //把匹配的结果和要进入的副本ID存入缓存
                    long fubenId = self.GetSoloInstanceId(soloPlayerInfo_i.UnitId, soloPlayerInfo_t.UnitId);
                    SoloMatchInfo soloResultInfo = SoloMatchInfo.Create();
                    soloResultInfo.UnitId_1 = soloPlayerInfo_i.UnitId;
                    soloResultInfo.UnitId_2 = soloPlayerInfo_t.UnitId;
                    soloResultInfo.FubenId = fubenId;
    
                    self.MatchResult[fubenId] = soloResultInfo;
                    fubenids[soloPlayerInfo_i.UnitId] = fubenId;
                    fubenids[soloPlayerInfo_t.UnitId] = fubenId;
                    continue;
                }
            }

            //对缓存的匹配数据进行发送消息
            for (int i = 0; i < playerlist.Count; i++)
            {
                self.m2C_SoloMatchResult.Result = 1;
                self.m2C_SoloMatchResult.FubenId = fubenids[playerlist[i].UnitId];

                //循环给每个要进入的玩家发送进入副本的消息
                //发送消息获取对应的玩家数据
                //给对应玩家发送进入地图的消息
                MapMessageHelper.SendToClient(self.Root(), playerlist[i].UnitId, self.m2C_SoloMatchResult);

                //匹配成功的要移除匹配列表
                if (self.MatchList.Contains(playerlist[i]))
                {
                    self.MatchList.Remove(playerlist[i]);
                }
            }
            
            await ETTask.CompletedTask;
        }

        public static long GetSoloInstanceId(this SoloSceneComponent self, long unitID_1, long unitID_2)
        {
            //动态创建副本
            int sceneId = 2000010;
            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            //创建新的副本场景,并给副本场景附加对应组件
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "Solo" + unitID_1.ToString());
            fubnescene.AddComponent<SoloDungeonComponent>();
            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)MapTypeEnum.Solo, sceneId, 0);
            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(sceneId).MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            return fubenid;
        }

        public static List<SoloPlayerResultInfo> GetSoloResult(this SoloSceneComponent self)
        {
            //返回坏存
            long timeCha = TimeHelper.ServerNow() - self.ResultTime;
            if (timeCha >= 10000)
            {
                self.SoloResultInfoList.Clear();
            }

            if (self.SoloResultInfoList.Count >= 1)
            {
                return self.SoloResultInfoList;
            }

            //进行排序
            Dictionary<long, int> dicSort = self.PlayerIntegralList.OrderByDescending(o => o.Value).ToDictionary(p => p.Key, o => o.Value);

            List<SoloPlayerResultInfo> soloResultInfoList = new List<SoloPlayerResultInfo>();

            int num = 0;

            foreach (long unitId in dicSort.Keys)
            {
                SoloPlayerResultInfo soloPlayerRes = SoloPlayerResultInfo.Create();
                soloPlayerRes.Combat = self.PlayerIntegralList[unitId];
                if (self.AllPlayerDateList.ContainsKey(unitId))
                {
                    soloPlayerRes.UnitId = unitId;
                    soloPlayerRes.Name = self.AllPlayerDateList[unitId].Name;
                    soloPlayerRes.Occ = self.AllPlayerDateList[unitId].Occ;
                    soloPlayerRes.WinNum = self.AllPlayerDateList[unitId].WinNum;
                    soloPlayerRes.FailNum = self.AllPlayerDateList[unitId].FailNum;
                }

                soloResultInfoList.Add(soloPlayerRes);

                num += 1;
                //最多显示前5即可
                if (num >= 5)
                {
                    break;
                }
            }

            self.ResultTime = TimeHelper.ServerNow();
            return soloResultInfoList;
        }
    }
}
