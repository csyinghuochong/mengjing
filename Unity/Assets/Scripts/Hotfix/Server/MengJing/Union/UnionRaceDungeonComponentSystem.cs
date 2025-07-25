using System.Collections.Generic;
using System;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(UnionRaceDungeonComponent))]
    [FriendOf(typeof(UnionRaceDungeonComponent))]
    public static partial class UnionRaceDungeonComponentSystem
    {
        public static void OnJoinUnionRace(this UnionRaceDungeonComponent self, long unionid, long unitid)
        {
            List<long> unitids = null;
            self.UnionRaceUnits.TryGetValue(unionid, out unitids);
            if (unitids == null)
            {
                self.UnionRaceUnits.Add(unionid, new List<long>());
            }

            if (!self.UnionRaceUnits[unionid].Contains(unitid))
            {
                self.UnionRaceUnits[unionid].Add(unitid);
            }
        }

        public static async ETTask<DBUnionInfo> GetDBUnionInfo(this UnionRaceDungeonComponent self, long unionId)
        {
            DBUnionInfo unionInfo = await UnitCacheHelper.GetComponent<DBUnionInfo>(self.Root(), unionId);
            if (unionInfo == null)
            {
                return null;
            }

            return unionInfo;
        }


        public static async ETTask OnUnionRaceBegin(this UnionRaceDungeonComponent self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(0, 1000));
            self.OnCheckWinUnion().Coroutine();
            ///////
            //long chatServerId = DBHelper.GetChatServerId(self.DomainZone());
            //A2A_ServerMessageRResponse g_SendChatRequest = (A2A_ServerMessageRResponse)await ActorMessageSenderComponent.Instance.Call
            //    (chatServerId, new A2A_ServerMessageRequest()
            //    {
            //        MessageType = NoticeType.UnionRace,
            //    });
            DBUnionManager dbUnionManager = await UnitCacheHelper.GetComponent<DBUnionManager>(self.Root(), self.Zone());
            List<UnionPlayerInfo> playerlist = new List<UnionPlayerInfo>();
            for (int i = 0; i < dbUnionManager.SignupUnions.Count; i++)
            {
                DBUnionInfo dBUnionInfo = await self.GetDBUnionInfo(dbUnionManager.SignupUnions[i]);
                if (dBUnionInfo == null)
                {
                    continue;
                }

                playerlist.AddRange(dBUnionInfo.UnionInfo.UnionPlayerList);
            }

            M2C_HorseNoticeInfo m2C_HorseNoticeInfo = M2C_HorseNoticeInfo.Create();
            m2C_HorseNoticeInfo.NoticeType = NoticeType.UnionRace;
            for (int i = 0; i < playerlist.Count; i++)
            {
                self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession)
                        .Send(playerlist[i].UserID, m2C_HorseNoticeInfo);
            }
        }

        public static async ETTask CheckWinUnion(this UnionRaceDungeonComponent self, int minite)
        {
            float3 initPosi = new float3(-68.62f, 0f, -3.05f);
            Dictionary<long, int> map = new Dictionary<long, int>();

            List<Unit> units = UnitHelper.GetAliveUnitList(self.Scene(), UnitType.Player);
            for (int i = 0; i < units.Count; i++)
            {
                if (math.distance(initPosi, units[i].Position) > 20)
                {
                    continue;
                }

                long unionId = units[i].GetUnionId();

                if (!map.ContainsKey(unionId))
                {
                    map.Add(unionId, 0);
                }

                map[unionId] += 1;
            }

            long winunionid = 0;
            int playernumber = 0;
            string unionplayerNumber = $"{self.Zone()} 占领区人数: ";
            foreach ((long unioid, int number) in map)
            {
                if (number > playernumber)
                {
                    winunionid = unioid;
                    playernumber = number;
                }

                unionplayerNumber = unionplayerNumber + $"{unioid}:{playernumber}  ";
            }

            for (int i = 0; i < units.Count; i++)
            {
                if (winunionid == units[i].GetUnionId() && winunionid != 0)
                {
                    units[i].GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionRaceWin, 1, true, false);
                }
                else
                {
                    units[i].GetComponent<NumericComponentS>().ApplyValue(NumericType.UnionRaceWin, 0, true, false);
                }
            }

            if (minite == 0)
            {
                Log.Warning(unionplayerNumber);
                Log.Warning($"胜利公会:  {self.Zone()} {winunionid}");

                self.OnUnionRaceOver(winunionid).Coroutine();
            }

            DBUnionInfo dBUnionInfo = await self.GetDBUnionInfo(winunionid);
            if (dBUnionInfo != null)
            {
                BroadCastHelper.SendBroadMessage(self.Root(), NoticeType.Notice,
                    $"恭喜 <color=#{CommonHelp.QualityReturnColor(2)}>{dBUnionInfo.UnionInfo.UnionName}</color>公会占领了公会争霸赛地图!");
            }
        }



        public static async ETTask OnCheckWinUnion(this UnionRaceDungeonComponent self)
        {
            int minite = (int)((FunctionHelp.GetCloseTime(1044) - FunctionHelp.GetOpenTime(1044)) / 60);
            /////进程9
            Log.Console($"公会争霸赛开始！！:{self.Zone()}  {minite}");
            Log.Warning($"公会争霸赛开始！！:{self.Zone()}  {minite}");
            for (int i = minite - 1; i >= 0; i--)
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(60 * 1000);
                Log.Console($"公会争霸赛检测！！: {self.Zone()}  {i}");

                self.CheckWinUnion(i).Coroutine();
            }

        }

        public static async ETTask OnUnionRaceOver(this UnionRaceDungeonComponent self, long winunionid)
        {
            long serverTime = TimeHelper.ServerNow();

            Log.Console($"公会争霸赛结束！！:{self.Zone()}");
            Log.Warning($"公会争霸赛结束！！: {self.Zone()}");
            int allwinunits = 0;
            int allfailunits = 0;
            foreach ((long unionid, List<long> unitids) in self.UnionRaceUnits)
            {
                for (int i = 0; i < unitids.Count; i++)
                {
                    if (unionid == winunionid)
                    {
                        allwinunits++;
                    }
                    else
                    {
                        allfailunits++;
                    }
                }
            }

            DBUnionManager dbUnionManager = await UnitCacheHelper.GetComponent<DBUnionManager>(self.Root(), self.Zone());
            long allJiangjin = (long)(0.8f * (dbUnionManager.TotalDonation + dbUnionManager.GetBaseJiangJin));
            allwinunits = math.max(allwinunits, 10);
            allfailunits = math.max(allfailunits, 10);

            int winJingJin = (int)(allJiangjin * 0.6f / allwinunits);
            int failJiangJin = (int)(allJiangjin * 0.4f / allfailunits);

            Log.Console("公会战发放奖励");
            Log.Warning(
                $"allwinunits: {allwinunits}   allfailunits: {allfailunits}  winJingJin: {winJingJin} failJiangJin:{failJiangJin} winunionid: {winunionid} allJiangjin:{allJiangjin}");

            ActorId mailServerId = UnitCacheHelper.GetMailServerId(self.Zone());
            foreach ((long unionid, List<long> unitids) in self.UnionRaceUnits)
            {
                for (int i = 0; i < unitids.Count; i++)
                {
                    MailInfo mailInfo = MailInfo.Create();
                    mailInfo.Status = 0;
                    mailInfo.Title = "公会争霸赛奖励";
                    mailInfo.MailId = IdGenerater.Instance.GenerateId();

                    if (unionid == winunionid)
                    {
                        mailInfo.Context = "发送公会争霸赛胜利奖励";
                        Log.Warning($"发送奖励胜利！！: {self.Zone()} {unitids[i]}");
                        ItemInfoProto BagInfo = ItemInfoProto.Create();
                        BagInfo.ItemID = 1;
                        BagInfo.ItemNum = winJingJin;
                        BagInfo.GetWay = $"{ItemGetWay.UnionRace}_{serverTime}";
                        mailInfo.ItemList.Add(BagInfo);
                    }
                    else
                    {
                        mailInfo.Context = "发送公会争霸赛失败奖励";
                        Log.Warning($"发送奖励失败！！: {self.Zone()} {unitids[i]}");
                        ItemInfoProto BagInfo = ItemInfoProto.Create();
                        BagInfo.ItemID = 1;
                        BagInfo.ItemNum = failJiangJin;
                        BagInfo.GetWay = $"{ItemGetWay.UnionRace}_{serverTime}";
                        mailInfo.ItemList.Add(BagInfo);
                    }

                    MailHelp.SendUserMail(self.Root(), unitids[i], mailInfo,ItemGetWay.UnionRace ).Coroutine();
                    // M2E_EMailSendRequest M2E_EMailSendRequest = M2E_EMailSendRequest.Create();
                    // M2E_EMailSendRequest.Id = unitids[i];
                    // M2E_EMailSendRequest.MailInfo = mailInfo;
                    // M2E_EMailSendRequest.GetWay = ItemGetWay.UnionRace;
                    // E2M_EMailSendResponse g_EMailSendResponse = (E2M_EMailSendResponse)await self.Root().GetComponent<MessageSender>()
                    //         .Call(mailServerId, M2E_EMailSendRequest);
                    // if (g_EMailSendResponse.Error != ErrorCode.ERR_Success)
                    // {
                    //     Log.Warning($"公会战发送奖励失败: {unitids[i]}");
                    // }
                }
            }

            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);

            List<Unit> allunits = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            M2C_UnionRaceInfoResult m2C_Battle = M2C_UnionRaceInfoResult.Create();
            m2C_Battle.SceneType = MapTypeEnum.UnionRace;
            for (int i = 0; i < allunits.Count; i++)
            {
                MapMessageHelper.SendToClient(allunits[i], m2C_Battle);
            }

            //通知公会争霸赛地图开始踢人
            await self.Root().GetComponent<TimerComponent>().WaitAsync(TimeHelper.Minute);
            C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
            actor_Transfer.SceneType = MapTypeEnum.MainCityScene;
            List<Unit> units = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            for (int i = 0; i < units.Count; i++)
            {
                TransferHelper.TransferUnit(units[i], actor_Transfer).Coroutine();
            }

            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(1000, 2000));
            TransferHelper.NoticeFubenCenter(self.Scene(), 2).Coroutine();


            dbUnionManager.SignupUnions.Clear();
            dbUnionManager.LastWeakDonation = dbUnionManager.TotalDonation;
            dbUnionManager.TotalDonation = (long)((dbUnionManager.GetBaseJiangJin + dbUnionManager.TotalDonation) * 0.2f);
            dbUnionManager.WinUnionId = winunionid;
            dbUnionManager.UnionRaceTime++;
            self.UnionRaceUnits.Clear();
            UnitCacheHelper.SaveComponent(self.Root(), self.Zone(), dbUnionManager).Coroutine();
        }
        [EntitySystem]
        private static void Awake(this ET.Server.UnionRaceDungeonComponent self)
        {

        }

    }
}