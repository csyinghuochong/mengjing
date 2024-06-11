namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentC))]
    public static class UserInfoNetHelper
    {
        public static async ETTask<int> RequestUserInfoInit(Scene root)
        {
            M2C_UserInfoInitResponse response =
                    (M2C_UserInfoInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_UserInfoInitRequest());

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
    }
}