namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionJingXuanHandler : MessageHandler<Scene, C2U_UnionJingXuanRequest, U2C_UnionJingXuanResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionJingXuanRequest request, U2C_UnionJingXuanResponse response)
        {
            DBUnionInfo dBUnionInfo = await UnitCacheHelper.GetComponent<DBUnionInfo>(scene.Root(), request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }
            if (dBUnionInfo.UnionInfo.JingXuanEndTime == 0)
            {
                response.Error = ErrorCode.ERR_AlreadyFinish;
                return;
            }

            if (request.OperateType == 0 && dBUnionInfo.UnionInfo.JingXuanList.Contains(request.UnitId))
            {
                dBUnionInfo.UnionInfo.JingXuanList.Remove(request.UnitId);
            }
            if (request.OperateType == 1 && !dBUnionInfo.UnionInfo.JingXuanList.Contains(request.UnitId))
            {
                dBUnionInfo.UnionInfo.JingXuanList.Add(request.UnitId);
            }

            if (dBUnionInfo.UnionInfo.LeaderId == request.UnitId)
            {
                dBUnionInfo.UnionInfo.JingXuanList.Clear();
                dBUnionInfo.UnionInfo.JingXuanEndTime = 0;
            }
            response.JingXuanList .AddRange( dBUnionInfo.UnionInfo.JingXuanList);
            response.JingXuanEndTime = dBUnionInfo.UnionInfo.JingXuanEndTime;
            UnitCacheHelper.SaveComponent(scene.Root(), dBUnionInfo.Id, dBUnionInfo).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
