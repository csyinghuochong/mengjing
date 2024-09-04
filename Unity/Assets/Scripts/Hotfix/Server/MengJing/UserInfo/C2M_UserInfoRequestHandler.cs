namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UserInfoRequestHandler : MessageLocationHandler<Unit, C2M_UserInfoInitRequest, M2C_UserInfoInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UserInfoInitRequest request, M2C_UserInfoInitResponse response)
        {
            unit.GetComponent<ShoujiComponentS>().UpdateShouJIStar();

            response.UserInfoProto = unit.GetComponent<UserInfoComponentS>().UserInfo.ToMessage();
            response.ReddontList .AddRange( unit.GetComponent<ReddotComponentS>().ReddontList);
            response.TreasureInfo .AddRange(unit.GetComponent<ShoujiComponentS>().TreasureInfo); 
            response.ShouJiChapterInfos .AddRange( unit.GetComponent<ShoujiComponentS>().ShouJiChapterInfos);
            response.TitleList .AddRange(unit.GetComponent<TitleComponentS>().TitleList); 
            
            await ETTask.CompletedTask;
        }
    }
}
