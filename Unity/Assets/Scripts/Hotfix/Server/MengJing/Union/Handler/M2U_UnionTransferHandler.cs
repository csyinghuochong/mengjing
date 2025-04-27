namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2U_UnionTransferHandler : MessageHandler<Scene, M2U_UnionTransferRequest, U2M_UnionTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2U_UnionTransferRequest request, U2M_UnionTransferResponse response)
        {
            DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }
            UnionPlayerInfo unionPlayerInfo_self = UnionHelper.GetUnionPlayerInfo(dBUnionInfo.UnionInfo.UnionPlayerList, request.UnitID);
            if (unionPlayerInfo_self == null || unionPlayerInfo_self.UserID != dBUnionInfo.UnionInfo.LeaderId)
            {
                response.Error = ErrorCode.ERR_Union_NoLimits;
                return;
            }

            UnionPlayerInfo unionPlayerInfo_new = UnionHelper.GetUnionPlayerInfo(dBUnionInfo.UnionInfo.UnionPlayerList, request.NewLeader);
            if (unionPlayerInfo_new == null)
            {
                response.Error = ErrorCode.ERR_Union_NoPlayer;
                return;
            }

            dBUnionInfo.UnionInfo.LeaderId  = request.NewLeader;
            unionPlayerInfo_new.Position    = 1;
            unionPlayerInfo_self.Position   = 0;
            UnitCacheHelper.SaveComponent(scene.Root(), dBUnionInfo.Id, dBUnionInfo).Coroutine();

           
            BroadCastHelper.NoticeUnionLeader(scene.Root(), request.NewLeader, 1).Coroutine();

            //通知旧会长
            BroadCastHelper.NoticeUnionLeader(scene.Root(), request.UnitID, 0).Coroutine();
            
            await ETTask.CompletedTask;
        }

       
    }
}
