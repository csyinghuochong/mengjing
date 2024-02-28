namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
    public static class UserInfoHelper
    {
        public static async ETTask<int> RequestUserInfoInit(Scene root)
        {
            M2C_UserInfoInitResponse response =
                    (M2C_UserInfoInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_UserInfoInitRequest());

            root.GetComponent<UserInfoComponentClient>().UserInfo = response.UserInfo;

            return ErrorCode.ERR_Success;
        }
    }
}