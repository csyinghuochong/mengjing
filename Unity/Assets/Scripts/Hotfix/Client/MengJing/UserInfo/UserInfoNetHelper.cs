namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentC))]
    public static class UserInfoNetHelper
    {
        public static async ETTask<int> RequestUserInfoInit(Scene root)
        {
            M2C_UserInfoInitResponse response =
                    (M2C_UserInfoInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(C2M_UserInfoInitRequest.Create());

            root.GetComponent<UserInfoComponentC>().UserInfo = response.UserInfo;
            root.GetComponent<ReddotComponentC>().ReddontList = response.ReddontList;
            root.GetComponent<ShoujiComponentC>().TreasureInfo = response.TreasureInfo;
            root.GetComponent<ShoujiComponentC>().ShouJiChapterInfos = response.ShouJiChapterInfos;
            root.GetComponent<TitleComponentC>().TitleList = response.TitleList;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<R2C_WorldLvResponse> WorldLv(Scene root)
        {
            C2R_WorldLvRequest request = new();
            R2C_WorldLvResponse response = (R2C_WorldLvResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_ExpToGoldResponse> ExpToGold(Scene root, int operateType)
        {
            C2M_ExpToGoldRequest request = new() { OperateType = operateType };
            M2C_ExpToGoldResponse response = (M2C_ExpToGoldResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<C2C_GMCommonResponse> GMCommon(Scene root, string context)
        {
            C2C_GMCommonRequest request = new() { Account = root.GetComponent<PlayerComponent>().Account, Context = context };
            C2C_GMCommonResponse response = (C2C_GMCommonResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<C2C_GMInfoResponse> GMInfo(Scene root)
        {
            C2C_GMInfoRequest request = new() { Account = root.GetComponent<PlayerComponent>().Account };
            C2C_GMInfoResponse response = (C2C_GMInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<G2C_Reload> Reload(Scene root, string loadValue)
        {
            C2G_Reload request = new() { Account = root.GetComponent<PlayerComponent>().Account, LoadValue = loadValue };
            G2C_Reload response = await root.GetComponent<ClientSenderCompnent>().Call(request) as G2C_Reload;
            return response;
        }

        public static async ETTask<int> ExpToGoldRequest(Scene root, int operateType)
        {
            C2M_ExpToGoldRequest request = new() { OperateType = 2 };
            M2C_ExpToGoldResponse response = (M2C_ExpToGoldResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_BuChangeResponse> BuChangeRequest(Scene root, long buChangId)
        {
            C2M_BuChangeRequest request = new() { BuChangId = buChangId };
            M2C_BuChangeResponse response = (M2C_BuChangeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> HorseRideRequest(Scene root)
        {
            C2M_HorseRideRequest request = new();
            M2C_HorseRideResponse response = (M2C_HorseRideResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }
    }
}