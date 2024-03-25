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

            return ErrorCode.ERR_Success;
        }
    }
}