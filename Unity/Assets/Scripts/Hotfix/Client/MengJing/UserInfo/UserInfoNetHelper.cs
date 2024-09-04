namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    public static class UserInfoNetHelper
    {
        public static async ETTask<int> RequestUserInfoInit(Scene root)
        {
            M2C_UserInfoInitResponse response =
                    (M2C_UserInfoInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(C2M_UserInfoInitRequest.Create());

            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().AddChild<UserInfo>();
            userInfo.FromMessage(response.UserInfoProto);
            root.GetComponent<UserInfoComponentC>().UserInfo = userInfo;
            root.GetComponent<ReddotComponentC>().ReddontList = response.ReddontList;
            root.GetComponent<ShoujiComponentC>().TreasureInfo = response.TreasureInfo;
            root.GetComponent<ShoujiComponentC>().ShouJiChapterInfos = response.ShouJiChapterInfos;
            root.GetComponent<TitleComponentC>().TitleList = response.TitleList;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask RequestFreshUnit(Scene root)
        {
            C2M_RefreshUnitRequest refreshUnitRequest = C2M_RefreshUnitRequest.Create();
            root.GetComponent<ClientSenderCompnent>().Send(refreshUnitRequest);
            await ETTask.CompletedTask;
        }

        public static async ETTask<R2C_WorldLvResponse> WorldLv(Scene root)
        {
            C2R_WorldLvRequest request = C2R_WorldLvRequest.Create();
            R2C_WorldLvResponse response = (R2C_WorldLvResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ExpToGoldResponse> ExpToGold(Scene root, int operateType)
        {
            C2M_ExpToGoldRequest request = C2M_ExpToGoldRequest.Create();
            request.OperateType = operateType;

            M2C_ExpToGoldResponse response = (M2C_ExpToGoldResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<C2C_GMCommonResponse> GMCommon(Scene root, string context)
        {
            C2C_GMCommonRequest request = C2C_GMCommonRequest.Create();
            request.Account = root.GetComponent<PlayerComponent>().Account;
            request.Context = context;

            C2C_GMCommonResponse response = (C2C_GMCommonResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<C2C_GMInfoResponse> GMInfo(Scene root)
        {
            C2C_GMInfoRequest request = C2C_GMInfoRequest.Create();
            request.Account = root.GetComponent<PlayerComponent>().Account;

            C2C_GMInfoResponse response = (C2C_GMInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<G2C_Reload> Reload(Scene root, string loadValue)
        {
            C2G_Reload request = C2G_Reload.Create();
            request.Account = root.GetComponent<PlayerComponent>().Account;
            request.LoadValue = loadValue;

            G2C_Reload response = await root.GetComponent<ClientSenderCompnent>().Call(request) as G2C_Reload;
            return response;
        }

        public static async ETTask<int> ExpToGoldRequest(Scene root, int operateType)
        {
            C2M_ExpToGoldRequest request = C2M_ExpToGoldRequest.Create();
            request.OperateType = 2;

            M2C_ExpToGoldResponse response = (M2C_ExpToGoldResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_BuChangeResponse> BuChangeRequest(Scene root, long buChangId)
        {
            C2M_BuChangeRequest request = C2M_BuChangeRequest.Create();
            request.BuChangId = buChangId;

            M2C_BuChangeResponse response = (M2C_BuChangeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> HorseRideRequest(Scene root)
        {
            C2M_HorseRideRequest request = C2M_HorseRideRequest.Create();

            M2C_HorseRideResponse response = (M2C_HorseRideResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> ReddotReadRequest(Scene root, int reddotType)
        {
            C2M_ReddotReadRequest request = C2M_ReddotReadRequest.Create();
            request.ReddotType = reddotType;

            M2C_ReddotReadResponse response = (M2C_ReddotReadResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            root.GetComponent<ReddotComponentC>().RemoveReddont(reddotType);

            return response.Error;
        }

        public static async ETTask<int> OneChallengeRequest(Scene root, int operatate, long otherId)
        {
            C2M_OneChallengeRequest request = C2M_OneChallengeRequest.Create();
            request.Operatate = operatate;
            request.OtherId = otherId;
            M2C_OneChallengeResponse response = (M2C_OneChallengeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_UnitInfoResponse> UnitInfoRequest(Scene root, long unitID)
        {
            C2M_UnitInfoRequest request = C2M_UnitInfoRequest.Create();
            request.UnitID = unitID;

            M2C_UnitInfoResponse response = (M2C_UnitInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_RechargeResponse> RechargeRequest(Scene root, string riskControlInfo, int rechargeNumber, long payType)
        {
            C2M_RechargeRequest request = new() { RiskControlInfo = riskControlInfo, RechargeNumber = rechargeNumber, PayType = payType };

            M2C_RechargeResponse response = (M2C_RechargeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}