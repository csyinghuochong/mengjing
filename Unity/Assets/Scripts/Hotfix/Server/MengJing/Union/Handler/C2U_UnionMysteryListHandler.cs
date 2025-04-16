namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionMysteryListHandler : MessageHandler<Scene, C2U_UnionMysteryListRequest, U2C_UnionMysteryListResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionMysteryListRequest request, U2C_UnionMysteryListResponse response)
        {
            DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }

            if (CommonHelp.GetDayByTime(dBUnionInfo.MysteryFreshTime) != CommonHelp.GetDayByTime(TimeHelper.ServerNow()))
            {
                int openDay = ServerHelper.GetServeOpenDay( scene.Zone());
                dBUnionInfo.MysteryItemInfos = MysteryShopHelper.InitUnionMysteryItemInfos(openDay); 
                dBUnionInfo.MysteryFreshTime = TimeHelper.ServerNow();
                UnitCacheHelper.SaveComponent(scene.Root(),dBUnionInfo.Id , dBUnionInfo).Coroutine();
            }

            response.MysteryItemInfos .AddRange(dBUnionInfo.MysteryItemInfos); 
        }
    }
}
