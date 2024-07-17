namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPastureListHandler : MessageLocationHandler<Unit, C2M_JiaYuanPastureListRequest, M2C_JiaYuanPastureListResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPastureListRequest request, M2C_JiaYuanPastureListResponse response)
        {
            response.MysteryItemInfos .AddRange(unit.GetComponent<JiaYuanComponentS>().PastureGoods_7); 
            await ETTask.CompletedTask;
        }
    }
}
