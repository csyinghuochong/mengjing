namespace ET.Client
{
    public static class ActivityNetHelper
    {
        public static async ETTask<int> RequestActivityInfo(Scene root)
        {
            // Log.Debug($"C2A_ActivityInfoRequest: client0");
            C2M_ActivityInfoRequest request = C2M_ActivityInfoRequest.Create();
            M2C_ActivityInfoResponse response = (M2C_ActivityInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            ActivityComponentC activityComponentC = root.GetComponent<ActivityComponentC>();
            activityComponentC.LastSignTime = response.LastSignTime;
            activityComponentC.TotalSignNumber = response.TotalSignNumber;
            activityComponentC.LastSignTime_VIP = response.LastSignTime_VIP;
            activityComponentC.TotalSignNumber_VIP = response.TotalSignNumber_VIP;
            activityComponentC.LastLoginTime = response.LastLoginTime;
            activityComponentC.DayTeHui = response.DayTeHui;
            activityComponentC.ActivityReceiveIds = response.ReceiveIds;
            activityComponentC.QuTokenRecvive = response.QuTokenRecvive;
           
            ActivityV1Info activityV1Info = activityComponentC.AddChild<ActivityV1Info>();
            activityV1Info.FromMessage(response.ActivityV1InfoProto);
            activityComponentC.ActivityV1Info = activityV1Info;
            
            //activityComponentC.ZhanQuReceiveIds = response.ZhanQuReceiveIds;
            //activityComponentC.ZhanQuReceiveNumbers = response.ZhanQuReceiveNumbers;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestZhanQuInfo(Scene root)
        {
            C2M_ZhanQuInfoRequest request = C2M_ZhanQuInfoRequest.Create();
            M2C_ZhanQuInfoResponse response = (M2C_ZhanQuInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            ActivityComponentC activityComponentC = root.GetComponent<ActivityComponentC>();
            activityComponentC.ZhanQuReceiveIds = response.ReceiveIds;
            activityComponentC.ZhanQuReceiveNumbers = response.ReceiveNum;
            return response.Error;   
        }

        public static async ETTask<M2C_ActivityReceiveResponse> ActivityReceive(Scene root, int activityType, int activityId, int index = 0)
        {
            C2M_ActivityReceiveRequest request = C2M_ActivityReceiveRequest.Create();
            request.ActivityType = activityType;
            request.ActivityId = activityId;
            request.ReceiveIndex = index;

            M2C_ActivityReceiveResponse response = (M2C_ActivityReceiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            if (activityType == (int)ActivityEnum.Type_31)
            {
                activityComponent.LastLoginTime = TimeHelper.ServerNow();
            }

            if (response.Error == ErrorCode.ERR_Success)
            {
                activityComponent.ActivityReceiveIds.Add(activityId);
            }

            return response;
        }

        public static async ETTask<M2C_WelfareDrawResponse> WelfareDraw(Scene root)
        {
            C2M_WelfareDrawRequest request = C2M_WelfareDrawRequest.Create();

            M2C_WelfareDrawResponse response = (M2C_WelfareDrawResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_WelfareInvestResponse> WelfareInvest(Scene root, int day)
        {
            C2M_WelfareInvestRequest reuqest = C2M_WelfareInvestRequest.Create();
            reuqest.Index = day;

            M2C_WelfareInvestResponse response = (M2C_WelfareInvestResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<UserInfoComponentC>().UserInfo.WelfareInvestList.Add(day);
            }

            return response;
        }

        public static async ETTask<M2C_WelfareInvestRewardResponse> WelfareInvestReward(Scene root)
        {
            C2M_WelfareInvestRewardRequest request = C2M_WelfareInvestRewardRequest.Create();

            M2C_WelfareInvestRewardResponse response = (M2C_WelfareInvestRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_WelfareDraw2Response> WelfareDraw2(Scene root)
        {
            C2M_WelfareDraw2Request request = C2M_WelfareDraw2Request.Create();

            M2C_WelfareDraw2Response response = (M2C_WelfareDraw2Response)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_WelfareDraw2RewardResponse> WelfareDraw2Reward(Scene root)
        {
            C2M_WelfareDraw2RewardRequest reques = C2M_WelfareDraw2RewardRequest.Create();

            M2C_WelfareDraw2RewardResponse response = (M2C_WelfareDraw2RewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(reques);
            return response;
        }

        public static async ETTask<M2C_RechargeRewardResponse> RechargeReward(Scene root, int rechargeNumber)
        {
            C2M_RechargeRewardRequest request = C2M_RechargeRewardRequest.Create();
            request.RechargeNumber = rechargeNumber;

            M2C_RechargeRewardResponse response = (M2C_RechargeRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> ZhanQuReceive(Scene root, int activityType, int activityId)
        {
            if (activityType != 21 && activityType != 22)
            {
                return ErrorCode.ERR_Error;
            }

            C2M_ZhanQuReceiveRequest request = C2M_ZhanQuReceiveRequest.Create();
            request.ActivityType = activityType;
            request.ActivityId = activityId;

            M2C_ZhanQuReceiveResponse response = (M2C_ZhanQuReceiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            bool have = false;
            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();
            activityComponent.ZhanQuReceiveIds.Add(activityId);
            for (int i = 0; i < activityComponent.ZhanQuReceiveNumbers.Count; i++)
            {
                if (activityComponent.ZhanQuReceiveNumbers[i].ActivityId == activityId)
                {
                    have = true;
                    activityComponent.ZhanQuReceiveNumbers[i].ReceiveNum++;
                }
            }

            if (!have)
            {
                ZhanQuReceiveNumber zhanQuReceiveNumber = ZhanQuReceiveNumber.Create();
                zhanQuReceiveNumber.ActivityId = activityId;
                zhanQuReceiveNumber.ReceiveNum = 1;

                activityComponent.ZhanQuReceiveNumbers.Add(zhanQuReceiveNumber);
            }

            return response.Error;
        }

        public static async ETTask FirstWinSelfReward(Scene root, int firstWinId, int difficulty)
        {
            C2M_FirstWinSelfRewardRequest request = C2M_FirstWinSelfRewardRequest.Create();
            request.FirstWinId = firstWinId;
            request.Difficulty = difficulty;

            M2C_FirstWinSelfRewardResponse response = (M2C_FirstWinSelfRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            root.GetComponent<UserInfoComponentC>().UserInfo.FirstWinSelf = response.FirstWinInfos;
        }

        public static async ETTask<A2C_CommonSeasonBossInfoResponse> GetCommonSeasonBossInfo(Scene root)
        {
            C2A_CommonSeasonBossInfoRequest request = C2A_CommonSeasonBossInfoRequest.Create();

            A2C_CommonSeasonBossInfoResponse response = (A2C_CommonSeasonBossInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<A2C_FirstWinInfoResponse> FirstWinInfo(Scene root)
        {
            C2A_FirstWinInfoRequest request = C2A_FirstWinInfoRequest.Create();

            A2C_FirstWinInfoResponse response = (A2C_FirstWinInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> PaiMaiAuctionPrice(Scene root, long price)
        {
            C2M_PaiMaiAuctionPriceRequest request = C2M_PaiMaiAuctionPriceRequest.Create();
            request.Price = price;

            M2C_PaiMaiAuctionPriceResponse response = (M2C_PaiMaiAuctionPriceResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> PaiMaiAuctionJoin(Scene root)
        {
            C2M_PaiMaiAuctionJoinRequest request = C2M_PaiMaiAuctionJoinRequest.Create();

            M2C_PaiMaiAuctionJoinResponse response = (M2C_PaiMaiAuctionJoinResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<P2C_PaiMaiAuctionInfoResponse> PaiMaiAuctionInfo(Scene root, long unitId)
        {
            C2P_PaiMaiAuctionInfoRequest request = C2P_PaiMaiAuctionInfoRequest.Create();
            request.UnitId = unitId;

            P2C_PaiMaiAuctionInfoResponse response = (P2C_PaiMaiAuctionInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_HongBaoOpenResponse> HongBaoOpen(Scene root)
        {
            C2M_HongBaoOpenRequest request = C2M_HongBaoOpenRequest.Create();

            M2C_HongBaoOpenResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_HongBaoOpenResponse;
            return response;
        }

        public static async ETTask<int> SeasonLevelReward(Scene root, int seasonLevel)
        {
            C2M_SeasonLevelRewardRequest request = C2M_SeasonLevelRewardRequest.Create();
            request.SeasonLevel = seasonLevel;

            M2C_SeasonLevelRewardResponse response = (M2C_SeasonLevelRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> YueKaReward(Scene root)
        {
            C2M_YueKaRewardRequest request = C2M_YueKaRewardRequest.Create();

            M2C_YueKaRewardResponse response = (M2C_YueKaRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> YueKaOpen(Scene root)
        {
            C2M_YueKaOpenRequest request = C2M_YueKaOpenRequest.Create();

            M2C_YueKaOpenResponse response = (M2C_YueKaOpenResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_SingleRechargeRewardResponse> SingleRechargeReward(Scene root, int rewardId)
        {
            C2M_SingleRechargeRewardRequest request = C2M_SingleRechargeRewardRequest.Create();
            request.RewardId = rewardId;

            M2C_SingleRechargeRewardResponse response =
                    (M2C_SingleRechargeRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> SoloMatch(Scene root)
        {
            C2M_SoloMatchRequest request = C2M_SoloMatchRequest.Create();

            M2C_SoloMatchResponse response = (M2C_SoloMatchResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<S2C_SoloMyInfoResponse> SoloMyInfo(Scene root)
        {
            C2S_SoloMyInfoRequest request = C2S_SoloMyInfoRequest.Create();

            S2C_SoloMyInfoResponse response = (S2C_SoloMyInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> RequstBattleEnter(Scene root)
        {
            int sceneId = BattleHelper.GetBattFubenId(root.GetComponent<UserInfoComponentC>().UserInfo.Lv);
            if (sceneId == 0)
            {
                return ErrorCode.ERR_LevelNoEnough;
            }

            bool intime = FunctionHelp.IsInTime(1025);
            if (!intime)
            {
                return ErrorCode.ERR_AlreadyFinish;
            }

            int errorCode = await EnterMapHelper.RequestTransfer(root, MapTypeEnum.Battle, sceneId);
            return errorCode;
        }

        public static async ETTask<int> DonationRequest(Scene root, int price)
        {
            C2M_DonationRequest request = C2M_DonationRequest.Create();
            request.Price = price;

            M2C_DonationResponse response = (M2C_DonationResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<Popularize2C_ListResponse> Popularize_ListRequest(Scene root)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();

            C2Popularize_ListRequest request = C2Popularize_ListRequest.Create();
            request.ActorId = userInfoComponent.UserInfo.UserId;

            Popularize2C_ListResponse response = (Popularize2C_ListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> ShareSucessRequest(Scene root, int shareType)
        {
            C2M_ShareSucessRequest request = C2M_ShareSucessRequest.Create();
            request.ShareType = shareType;

            M2C_ShareSucessResponse response = (M2C_ShareSucessResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> Popularize_RewardRequest(Scene root)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2Popularize_RewardRequest request = C2Popularize_RewardRequest.Create();
            request.ActorId = userInfoComponent.UserInfo.UserId;

            Popularize2C_RewardResponse response = (Popularize2C_RewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> Popularize_PlayerRequest(Scene root, long popularizeId)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2Popularize_PlayerRequest request = C2Popularize_PlayerRequest.Create();
            request.ActorId = userInfoComponent.UserInfo.UserId;
            request.PopularizeId = popularizeId;

            Popularize2C_PlayerResponse response = (Popularize2C_PlayerResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_SerialReardResponse> SerialReardRequest(Scene root, string serialNumber)
        {
            C2M_SerialReardRequest request = C2M_SerialReardRequest.Create();
            request.SerialNumber = serialNumber;

            M2C_SerialReardResponse response = (M2C_SerialReardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> ActivityRechargeSignRequest(Scene root, int activityType, int activityId)
        {
            C2M_ActivityRechargeSignRequest request = C2M_ActivityRechargeSignRequest.Create();
            request.ActivityType = activityType;
            request.ActivityId = activityId;

            M2C_ActivityRechargeSignResponse response =
                    (M2C_ActivityRechargeSignResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> LeavlRewardRequest(Scene root, int lvKey, int index)
        {
            C2M_LeavlRewardRequest request = C2M_LeavlRewardRequest.Create();
            request.LvKey = lvKey;
            request.Index = index;

            M2C_LeavlRewardResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_LeavlRewardResponse;
            return response.Error;
        }

        public static async ETTask<int> KillMonsterRewardRequest(Scene root, int key, int index)
        {
            C2M_KillMonsterRewardRequest request = C2M_KillMonsterRewardRequest.Create();
            request.Key = key;
            request.Index = index;

            M2C_KillMonsterRewardResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_KillMonsterRewardResponse;
            return response.Error;
        }

        public static async ETTask<int> TrialDungeonBeginRequest(Scene root)
        {
            C2M_TrialDungeonBeginRequest request = C2M_TrialDungeonBeginRequest.Create();

            M2C_TrialDungeonBeginResponse response = (M2C_TrialDungeonBeginResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> DungeonHappyMoveRequest(Scene root, int operatateType)
        {
            C2M_DungeonHappyMoveRequest request = C2M_DungeonHappyMoveRequest.Create();
            request.OperatateType = operatateType;

            M2C_DungeonHappyMoveResponse response = (M2C_DungeonHappyMoveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> TowerFightBeginRequest(Scene root)
        {
            C2M_TowerFightBeginRequest request = C2M_TowerFightBeginRequest.Create();

            M2C_TowerFightBeginResponse response = (M2C_TowerFightBeginResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> TowerExitRequest(Scene root)
        {
            C2M_TowerExitRequest request = C2M_TowerExitRequest.Create();

            M2C_TowerExitResponse response = (M2C_TowerExitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RandomTowerBeginRequest(Scene root, int randomNumber)
        {
            C2M_RandomTowerBeginRequest request = C2M_RandomTowerBeginRequest.Create();
            request.RandomNumber = randomNumber;

            M2C_RandomTowerBeginResponse response = (M2C_RandomTowerBeginResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> HappyMoveRequest(Scene root, int operatateType)
        {
            C2M_HappyMoveRequest request = C2M_HappyMoveRequest.Create();
            request.OperatateType = operatateType;

            M2C_HappyMoveResponse response = (M2C_HappyMoveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }
        
        public static async ETTask<M2C_SingleHappyOperateResponse> SingleHappyOperateRequest(Scene root, int operatateType)
        {
            C2M_SingleHappyOperateRequest request = C2M_SingleHappyOperateRequest.Create();
            request.OperatateType = operatateType;

            M2C_SingleHappyOperateResponse response = (M2C_SingleHappyOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<R2C_RankRunRaceResponse> RankRunRaceRequest(Scene root)
        {
            C2R_RankRunRaceRequest request = C2R_RankRunRaceRequest.Create();

            R2C_RankRunRaceResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_RankRunRaceResponse;
            return response;
        }

        public static async ETTask<R2C_RankDemonResponse> RankDemonRequest(Scene root)
        {
            C2R_RankDemonRequest request = C2R_RankDemonRequest.Create();

            R2C_RankDemonResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_RankDemonResponse;
            return response;
        }

        public static async ETTask<int> TurtleSupportRequest(Scene root, int supportId)
        {
            C2M_TurtleSupportRequest request = C2M_TurtleSupportRequest.Create();
            request.SupportId = supportId;

            M2C_TurtleSupportResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_TurtleSupportResponse;
            return response.Error;
        }

        public static async ETTask<M2C_TurtleRecordResponse> TurtleRecordRequest(Scene root)
        {
            C2M_TurtleRecordRequest request = C2M_TurtleRecordRequest.Create();

            M2C_TurtleRecordResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_TurtleRecordResponse;
            return response;
        }

        public static async ETTask<int> TowerOfSealNextRequest(Scene root, int diceResult, int costType)
        {
            C2M_TowerOfSealNextRequest request = C2M_TowerOfSealNextRequest.Create();
            request.DiceResult = diceResult;
            request.CostType = costType;

            M2C_TowerOfSealNextResponse response = (M2C_TowerOfSealNextResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_BattleSummonRecord> BattleSummonRecord(Scene root)
        {
            C2M_BattleSummonRecord request = C2M_BattleSummonRecord.Create();

            M2C_BattleSummonRecord response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_BattleSummonRecord;
            return response;
        }
        
        public static async ETTask<M2C_SeasonDonateResponse> SeasonDonateRequest(Scene root)
        {
            C2M_SeasonDonateRequest request = C2M_SeasonDonateRequest.Create();
           
            M2C_SeasonDonateResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_SeasonDonateResponse;
            return response;
        }

        public static async ETTask<M2C_BattleSummonResponse> BattleSummonRequest(Scene root, int summonId)
        {
            C2M_BattleSummonRequest request = C2M_BattleSummonRequest.Create();
            request.SummonId = summonId;

            M2C_BattleSummonResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_BattleSummonResponse;
            return response;
        }
    }
}