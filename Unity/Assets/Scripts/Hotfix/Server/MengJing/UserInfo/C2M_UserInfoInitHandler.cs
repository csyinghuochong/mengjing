namespace ET.Server
{
    [FriendOf(typeof (UserInfoComponentS))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UserInfoInitHandler: MessageLocationHandler<Unit, C2M_UserInfoInitRequest, M2C_UserInfoInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UserInfoInitRequest request, M2C_UserInfoInitResponse response)
        {
            response.UserInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            await ETTask.CompletedTask;
        }
    }
}