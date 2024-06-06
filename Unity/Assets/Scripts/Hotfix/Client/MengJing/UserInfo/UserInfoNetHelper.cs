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
    }
}