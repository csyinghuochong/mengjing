namespace ET.Server
{
    [FriendOf(typeof (UserInfoComponentS))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UserInfoInitHandler: MessageLocationHandler<Unit, C2M_UserInfoInitRequest, M2C_UserInfoInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UserInfoInitRequest request, M2C_UserInfoInitResponse response)
        {
            response.UserInfoProto = unit.GetComponent<UserInfoComponentS>().UserInfo.ToMessage();
            response.ReddontList =  unit.GetComponent<ReddotComponentS>().ReddontList;
            response.TreasureInfo = unit.GetComponent<ShoujiComponentS>().TreasureInfo;
            response.ShouJiChapterInfos = unit.GetComponent<ShoujiComponentS>().ShouJiChapterInfos;
            response.TitleList = unit.GetComponent<TitleComponentS>().TitleList;
            await ETTask.CompletedTask;
        }
    }
}