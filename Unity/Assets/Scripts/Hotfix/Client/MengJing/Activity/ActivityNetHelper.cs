namespace ET.Client
{
    public static class ActivityNetHelper
    {
        public static async ETTask<int> RequestActivityInfo(Scene root)
        {
            Log.Debug($"C2A_ActivityInfoRequest: client0");
            C2A_ActivityInfoRequest request = new();
            A2C_ActivityInfoResponse response = (A2C_ActivityInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            Log.Debug($"C2M_BagInitHandler: client1");
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> ActivityReceive(Scene root, int activityType, int activityId, int index = 0)
        {
            C2M_ActivityReceiveRequest request = new() { ActivityType = activityType, ActivityId = activityId, ReceiveIndex = index };
            M2C_ActivityReceiveResponse response = (M2C_ActivityReceiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            if (activityType == 31)
            {
                activityComponent.LastLoginTime = TimeHelper.ServerNow();
            }

            if (response.Error == ErrorCode.ERR_Success)
            {
                activityComponent.ActivityReceiveIds.Add(activityId);
            }

            return response.Error;
        }

        public static async ETTask<M2C_WelfareDrawResponse> WelfareDraw(Scene root)
        {
            C2M_WelfareDrawRequest request = new();
            M2C_WelfareDrawResponse response = (M2C_WelfareDrawResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_WelfareInvestResponse> WelfareInvest(Scene root, int day)
        {
            C2M_WelfareInvestRequest reuqest = new() { Index = day };
            M2C_WelfareInvestResponse response = (M2C_WelfareInvestResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<UserInfoComponentC>().UserInfo.WelfareInvestList.Add(day);
            }

            return response;
        }

        public static async ETTask<M2C_WelfareInvestRewardResponse> WelfareInvestReward(Scene root)
        {
            C2M_WelfareInvestRewardRequest request = new();
            M2C_WelfareInvestRewardResponse response = (M2C_WelfareInvestRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_WelfareDraw2Response> WelfareDraw2(Scene root)
        {
            C2M_WelfareDraw2Request request = new();
            M2C_WelfareDraw2Response response = (M2C_WelfareDraw2Response)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_WelfareDraw2RewardResponse> WelfareDraw2Reward(Scene root)
        {
            C2M_WelfareDraw2RewardRequest reques = new();
            M2C_WelfareDraw2RewardResponse response = (M2C_WelfareDraw2RewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(reques);
            return response;
        }

        public static async ETTask<M2C_RechargeRewardResponse> RechargeReward(Scene root, int rechargeNumber)
        {
            C2M_RechargeRewardRequest request = new() { RechargeNumber = rechargeNumber };
            M2C_RechargeRewardResponse response = (M2C_RechargeRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> ZhanQuReceive(Scene root, int activityType, int activityId)
        {
            if (activityType != 21 && activityType != 22)
            {
                return ErrorCode.ERR_Error;
            }

            C2M_ZhanQuReceiveRequest request = new() { ActivityType = activityType, ActivityId = activityId };
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
                activityComponent.ZhanQuReceiveNumbers.Add(new ZhanQuReceiveNumber() { ActivityId = activityId, ReceiveNum = 1 });
            }

            return response.Error;
        }

        public static async ETTask FirstWinSelfReward(Scene root, int firstWinId, int difficulty)
        {
            C2M_FirstWinSelfRewardRequest request = new() { FirstWinId = firstWinId, Difficulty = difficulty };
            M2C_FirstWinSelfRewardResponse response =
                    (M2C_FirstWinSelfRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            root.GetComponent<UserInfoComponentC>().UserInfo.FirstWinSelf = response.FirstWinInfos;
        }

        public static async ETTask<A2C_FirstWinInfoResponse> FirstWinInfo(Scene root)
        {
            C2A_FirstWinInfoRequest request = new();
            A2C_FirstWinInfoResponse response = (A2C_FirstWinInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> PaiMaiAuctionPrice(Scene root, long price)
        {
            C2M_PaiMaiAuctionPriceRequest request = new() { Price = price };
            M2C_PaiMaiAuctionPriceResponse response = (M2C_PaiMaiAuctionPriceResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> PaiMaiAuctionJoin(Scene root)
        {
            C2M_PaiMaiAuctionJoinRequest request = new();
            M2C_PaiMaiAuctionJoinResponse response = (M2C_PaiMaiAuctionJoinResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<P2C_PaiMaiAuctionInfoResponse> PaiMaiAuctionInfo(Scene root, long unitId)
        {
            C2P_PaiMaiAuctionInfoRequest request = new() { UnitId = unitId };
            P2C_PaiMaiAuctionInfoResponse response = (P2C_PaiMaiAuctionInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_HongBaoOpenResponse> HongBaoOpen(Scene root)
        {
            C2M_HongBaoOpenRequest request = new();
            M2C_HongBaoOpenResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_HongBaoOpenResponse;
            return response;
        }

        public static async ETTask<int> SeasonLevelReward(Scene root, int seasonLevel)
        {
            C2M_SeasonLevelRewardRequest request = new() { SeasonLevel = seasonLevel };
            M2C_SeasonLevelRewardResponse response = (M2C_SeasonLevelRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> YueKaReward(Scene root)
        {
            C2M_YueKaRewardRequest request = new();
            M2C_YueKaRewardResponse response = (M2C_YueKaRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> YueKaOpen(Scene root)
        {
            C2M_YueKaOpenRequest request = new();
            M2C_YueKaOpenResponse response = (M2C_YueKaOpenResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_SingleRechargeRewardResponse> SingleRechargeReward(Scene root, int rewardId)
        {
            C2M_SingleRechargeRewardRequest request = new() { RewardId = rewardId };
            M2C_SingleRechargeRewardResponse response =
                    (M2C_SingleRechargeRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> SoloMatch(Scene root)
        {
            C2M_SoloMatchRequest request = new();
            M2C_SoloMatchResponse response = (M2C_SoloMatchResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<S2C_SoloMyInfoResponse> SoloMyInfo(Scene root)
        {
            C2S_SoloMyInfoRequest request = new();
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

            int errorCode = await EnterMapHelper.RequestTransfer(root, SceneTypeEnum.Battle, sceneId);
            return errorCode;
        }

        public static async ETTask<int> DonationRequest(Scene root, int price)
        {
            C2M_DonationRequest request = new() { Price = price };
            M2C_DonationResponse response = (M2C_DonationResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<Popularize2C_ListResponse> Popularize_ListRequest(Scene root)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2Popularize_ListRequest request = new() { ActorId = userInfoComponent.UserInfo.UserId };
            Popularize2C_ListResponse response = (Popularize2C_ListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> ShareSucessRequest(Scene root, int shareType)
        {
            C2M_ShareSucessRequest request = new() { ShareType = shareType };
            M2C_ShareSucessResponse response = (M2C_ShareSucessResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> Popularize_RewardRequest(Scene root)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2Popularize_RewardRequest request = new() { ActorId = userInfoComponent.UserInfo.UserId };
            Popularize2C_RewardResponse response = (Popularize2C_RewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> Popularize_PlayerRequest(Scene root, long popularizeId)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2Popularize_PlayerRequest request = new() { ActorId = userInfoComponent.UserInfo.UserId, PopularizeId = popularizeId };
            Popularize2C_PlayerResponse response = (Popularize2C_PlayerResponse)await root.GetComponent<SessionComponent>().Session.Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_SerialReardResponse> SerialReardRequest(Scene root, string serialNumber)
        {
            C2M_SerialReardRequest request = new() { SerialNumber = serialNumber };
            M2C_SerialReardResponse response = (M2C_SerialReardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> ActivityRechargeSignRequest(Scene root, int activityType, int activityId)
        {
            C2M_ActivityRechargeSignRequest request = new() { ActivityType = activityType, ActivityId = activityId };
            M2C_ActivityRechargeSignResponse response =
                    (M2C_ActivityRechargeSignResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> LeavlRewardRequest(Scene root, int lvKey, int index)
        {
            C2M_LeavlRewardRequest request = new() { LvKey = lvKey, Index = index };
            M2C_LeavlRewardResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_LeavlRewardResponse;
            return response.Error;
        }

        public static async ETTask<int> KillMonsterRewardRequest(Scene root, int key, int index)
        {
            C2M_KillMonsterRewardRequest request = new() { Key = key, Index = index };
            M2C_KillMonsterRewardResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_KillMonsterRewardResponse;
            return response.Error;
        }

        public static async ETTask<int> TrialDungeonBeginRequest(Scene root)
        {
            C2M_TrialDungeonBeginRequest request = new();
            M2C_TrialDungeonBeginResponse response = (M2C_TrialDungeonBeginResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> DungeonHappyMoveRequest(Scene root, int operatateType)
        {
            C2M_DungeonHappyMoveRequest request = new() { OperatateType = operatateType };
            M2C_DungeonHappyMoveResponse response = (M2C_DungeonHappyMoveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> TowerFightBeginRequest(Scene root)
        {
            C2M_TowerFightBeginRequest request = new();
            M2C_TowerFightBeginResponse response = (M2C_TowerFightBeginResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> TowerExitRequest(Scene root)
        {
            C2M_TowerExitRequest request = new();
            M2C_TowerExitResponse response = (M2C_TowerExitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RandomTowerBeginRequest(Scene root, int randomNumber)
        {
            C2M_RandomTowerBeginRequest request = new() { RandomNumber = randomNumber };
            M2C_RandomTowerBeginResponse response = (M2C_RandomTowerBeginResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> HappyMoveRequest(Scene root, int operatateType)
        {
            C2M_HappyMoveRequest request = new() { OperatateType = operatateType };
            M2C_HappyMoveResponse response = (M2C_HappyMoveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<R2C_RankRunRaceResponse> RankRunRaceRequest(Scene root)
        {
            C2R_RankRunRaceRequest request = new();
            R2C_RankRunRaceResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as R2C_RankRunRaceResponse;
            return response;
        }
    }
}