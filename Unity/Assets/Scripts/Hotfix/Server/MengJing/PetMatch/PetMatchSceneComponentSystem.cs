using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{

    [EntitySystemOf(typeof(PetMatchSceneComponent))]
    [FriendOf(typeof(PetMatchSceneComponent))]
    public static partial class PetMatchSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.PetMatchSceneComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.PetMatchSceneComponent self)
        {

        }

        public static async ETTask UpdateSoloRank(this PetMatchSceneComponent self, long unitid, int rankid)
        {
            //R2M_RankUpdateMessage r2M_RankUpdateMessage = R2M_RankUpdateMessage.Create();
            //r2M_RankUpdateMessage.RankType = 5;  //宠物匹配赛排名
            //r2M_RankUpdateMessage.RankId = rankid;
            //self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitid, r2M_RankUpdateMessage);
            await ETTask.CompletedTask;
        }

        private static async ETTask G2RobotMessage(this PetMatchSceneComponent self, int noticeType)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(10000, 30000));
            ActorId robotSceneId = UnitCacheHelper.GetRobotServerId();
            G2Robot_MessageRequest G2Robot_MessageRequest = G2Robot_MessageRequest.Create();
            G2Robot_MessageRequest.Zone = self.Zone();
            G2Robot_MessageRequest.MessageType = noticeType;
            G2Robot_MessageRequest.Message = string.Empty;
            self.Root().GetComponent<MessageSender>().Send(robotSceneId, G2Robot_MessageRequest);
        }

        public static async ETTask OnSoloBegin(this PetMatchSceneComponent self)
        {
            //通知机器人
            self.PetMatchOpen = true;
            if (ServerHelper.GetServeOpenDay(self.Zone()) > 0)
            {
                self.G2RobotMessage(NoticeType.PetMatchOpen).Coroutine();
            }
     
            Console.WriteLine($"OnSoloBegin: {self.Zone()}");

            //清除之前的排名坐骑  确认是否需要保存。。
            DBRankInfo dBRankInfo = await UnitCacheHelper.GetComponent<DBRankInfo>(self.Root(), self.Zone());
            if (dBRankInfo != null && dBRankInfo.petMatchInfo.Count > 0)
            {
                //self.UpdateSoloRank(dBRankInfo.rankSoloInfo[0].UserId, 0).Coroutine();
            }

            int trigger = 0;

            DateTime dateTime = TimeHelper.DateTimeNow();
            long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            long closeTime = FunctionHelp.GetCloseTime(1074);
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
        
        public static async ETTask RecordSoloRank(this PetMatchSceneComponent self)
        {
            List<string> sololist = new List<string>();
            // List<SoloPlayerResultInfo> soloPlayerList = self.GetSoloResult();
            //
            // for (int i = 0; i < soloPlayerList.Count; i++)
            // {
            //     long combat = 0;
            //     self.PlayerCombatList.TryGetValue(soloPlayerList[i].UnitId, out combat);
            //
            //     UserInfoComponentS userInfoComponent =
            //             await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(self.Root(), soloPlayerList[i].UnitId);
            //     UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
            //     if (userInfoComponent == null)
            //     {
            //         continue;
            //     }
            //
            //     OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(soloPlayerList[i].Occ);
            //     string occName = occupationConfig.OccupationName;
            //     
            //     if (unionInfoCache.OccTwo > 0)
            //     {
            //         occName = OccupationTwoConfigCategory.Instance.Get(unionInfoCache.OccTwo).OccupationName;
            //     }
            //
            //     string soloInfo =
            //             $"玩家: {soloPlayerList[i].Name}  击杀:{soloPlayerList[i].WinNum} 等级:{unionInfoCache.Lv} 职业:{occName}  战力:{combat}";
            //     sololist.Add(soloInfo);
            // }
            //
            // ServerLogHelper.WriteLogList(sololist, $"../Logs/WJ_Solo/Rank_{self.Zone()}.txt", false);
            await ETTask.CompletedTask;
        }
        
         private static async ETTask SendPetReward(this PetMatchSceneComponent self)
        {
            int zone = self.Zone();
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(1000, 10000));
            DateTime dateTime = TimeHelper.DateTimeNow();
            if (!RankHelper.HaveReward(2, (int)dateTime.DayOfWeek))
            {
                return;
            }

           
            self.MatchList.Sort(delegate(PetMatchPlayerInfo a, PetMatchPlayerInfo b) { return (int)(b.Score - a.Score); });
            List<PetMatchPlayerInfo> rankList = self.RankList;
            
            for (int i = 0; i < rankList.Count; i++)
            {
                if (rankList[i].RobotId > 0)
                {
                    continue;
                }

                RankRewardConfig rankRewardConfig = RankHelper.GetRankReward(i+1, 8);
                if (rankRewardConfig == null)
                {
                    continue;
                }
                
                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Status = 0;
                mailInfo.Context = $"恭喜您获得宠物战排行榜第{i + 1}名奖励";
                mailInfo.Title = "宠物战排行榜奖励";
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

                await MailHelp.SendUserMail(self.Root(), rankList[i].UnitId, mailInfo, ItemGetWay.RankReward);
            }
        }
        
        public static async ETTask OnSoloOver(this PetMatchSceneComponent self)
        {
            Log.Warning($"OnSoloOver: {self.Zone()}");
            self.PetMatchOpen = true;
            self.RecordSoloRank().Coroutine();
            self.SendPetReward().Coroutine();
            
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

                scene.GetComponent<PetMeleeDungeonComponent>().KickOutPlayer();
                await self.Root().GetComponent<TimerComponent>().WaitAsync(60000 + RandomHelper.RandomNumber(0, 1000));
                TransferHelper.NoticeFubenCenter(scene, 2).Coroutine();
                scene.Dispose();
            }
            
            if (ServerHelper.GetServeOpenDay(self.Zone()) > 0)
            {
                self.G2RobotMessage(NoticeType.PetMatchClose).Coroutine();
            }
            
            self.MatchList.Clear();
            self.RankList.Clear();
        }
        
        public static void OnRecvUnitLeave(this PetMatchSceneComponent self, long userId)
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
        
        public static int OnAddSoloDateList(this ET.Server.PetMatchSceneComponent self, PetMatchPlayerInfo petMatchPlayerInfo)
        {
            int joinNum = 0;
            if (self.WinTimesList.ContainsKey(petMatchPlayerInfo.UnitId))
            {
                joinNum += self.WinTimesList[petMatchPlayerInfo.UnitId];
            }
            if (self.FailTimesList.ContainsKey(petMatchPlayerInfo.UnitId))
            {
                joinNum += self.FailTimesList[petMatchPlayerInfo.UnitId];
            }

             //获取次数
            if (joinNum >= 500)
            {
                return ErrorCode.ERR_SoloNumMax;
            }

            for (int i = self.MatchList.Count - 1; i>=0; i--)
            {
                if (self.MatchList[i].UnitId == petMatchPlayerInfo.UnitId)
                {
                    self.MatchList.RemoveAt(i);
                }
            }

            long score = -1;
            for (int i = self.RankList.Count - 1; i>=0; i--)
            {
                if (self.RankList[i].UnitId == petMatchPlayerInfo.UnitId)
                {
                    score = self.RankList[i].Score;
                }
            }

            if (score < 0)
            {
                self.RankList.Add( petMatchPlayerInfo );
            }
            else
            {
                petMatchPlayerInfo.Score = score;
            }
            self.MatchList.Add( petMatchPlayerInfo );

            return ErrorCode.ERR_Success;
        }
        
           //匹配监测机制
        public static async ETTask CheckMatch(this PetMatchSceneComponent self, int time)
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
            self.MatchList.Sort(delegate(PetMatchPlayerInfo a, PetMatchPlayerInfo b) { return (int)(b.Score - a.Score); });
            
            Dictionary<long, long> fubenids = new Dictionary<long, long>();

            //通知玩家
            List<PetMatchPlayerInfo> playerlist = new List<PetMatchPlayerInfo>();
            for (int i = self.MatchList.Count - 1; i >= 0; i--)
            {
                //两两匹配  i和t进行匹配
                int t = i - 1;
                if (t < 0)
                {
                    break;
                }

                //获取对应玩家数据
                PetMatchPlayerInfo soloPlayerInfo_i = self.MatchList[i];
                PetMatchPlayerInfo soloPlayerInfo_t = self.MatchList[t];

                if (soloPlayerInfo_i.RobotId > 0 && soloPlayerInfo_t.RobotId > 0)
                {
                    continue;
                }

                //30,秒内 低战力/高战力>=0.8 60秒 低战力/高战力>= 0.6 90秒 低战力/高战力>=0)
                long passTime = (long)((serverTime - soloPlayerInfo_i.MatchTime) / 1000);
                
                // float range = 1f; //战力调整系数
                // if (passTime < 30)
                // {
                //     range = 0.7f;
                // }
                // else if (passTime < 60)
                // {
                //     range = 0.4f;
                // }
                // else
                // {
                //     range = 0f;
                // }
                //这里还需要添加判断2个目标是否掉线

                //float maxValue = math.max((float)soloPlayerInfo_i.Score, (float)soloPlayerInfo_t.Score);
                //float minValue = math.min((float)soloPlayerInfo_i.Score, (float)soloPlayerInfo_t.Score);

                //获取双方战力进行匹配
                //if (minValue / maxValue >= range)
                {
                   
                }
                
                //匹配成功
                self.MatchList.RemoveAt(i);
                self.MatchList.RemoveAt(t);
                
              
                //存入匹配缓存数据,方便下面发送消息
                playerlist.Add(soloPlayerInfo_i);
                playerlist.Add(soloPlayerInfo_t);

                //把匹配的结果和要进入的副本ID存入缓存
                long fubenId = self.GetSoloInstanceId(soloPlayerInfo_i.UnitId, soloPlayerInfo_t.UnitId);
                
                fubenids[soloPlayerInfo_i.UnitId] = fubenId;
                fubenids[soloPlayerInfo_t.UnitId] = fubenId;
                
                i--;
            }

            //对缓存的匹配数据进行发送消息
            for (int i = 0; i < playerlist.Count; i++)
            {
                M2C_PetMatchResult M2C_PetMatchResult = M2C_PetMatchResult.Create();
                M2C_PetMatchResult.Result = 1;
                M2C_PetMatchResult.FubenId = fubenids[playerlist[i].UnitId];

                //循环给每个要进入的玩家发送进入副本的消息
                //发送消息获取对应的玩家数据
                //给对应玩家发送进入地图的消息
                MapMessageHelper.SendToClient(self.Root(), playerlist[i].UnitId, M2C_PetMatchResult);

                //匹配成功的要移除匹配列表
                self.MatchList = self.MatchList.Where(p => p.UnitId != playerlist[i].UnitId).ToList();
            }
            
            await ETTask.CompletedTask;
        }

        
        public static long GetSoloInstanceId(this PetMatchSceneComponent self, long unitID_1, long unitID_2)
        {
            //动态创建副本
            int sceneId = 2900001;
            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            //创建新的副本场景,并给副本场景附加对应组件
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "PetMatch" + unitID_1.ToString());
            fubnescene.AddComponent<PetMeleeDungeonComponent>(); 
            //TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)MapTypeEnum.PetMatch, sceneId, 0);
            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(sceneId).MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            return fubenid;
        }

        public static void OnUpdateScore(this PetMatchSceneComponent self , long unitid, int resultEnum)
        {
            if (resultEnum == CombatResultEnum.Win)
            {
                if (!self.WinTimesList.ContainsKey(unitid))
                {
                    self.WinTimesList[unitid] = 0;
                }

                self.WinTimesList[unitid]++;
            }
            if (resultEnum == CombatResultEnum.Fail)
            {
                if (!self.FailTimesList.ContainsKey(unitid))
                {
                    self.FailTimesList[unitid] = 0;
                }
                self.FailTimesList[unitid]++;
            }

            for (int i = 0; i < self.RankList.Count; i++)
            {
                int wintimes = 0;
                self.WinTimesList.TryGetValue(self.RankList[i].UnitId, out wintimes);
                self.RankList[i].Score = wintimes;
            }
            
            self.RankList.Sort(delegate(PetMatchPlayerInfo a, PetMatchPlayerInfo b) { return (int)(b.Score - a.Score); });
        }

        public static List<PetMatchPlayerInfo> GetSoloResult(this PetMatchSceneComponent self)
        {
            //返回坏存
            
            //进行排序
            //更新 胜负次数 排名
            return self.RankList;
        }
    }
}