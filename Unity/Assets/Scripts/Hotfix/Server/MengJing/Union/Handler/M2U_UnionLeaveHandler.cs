namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2U_UnionLeaveHandler : MessageHandler<Scene, M2U_UnionLeaveRequest, U2M_UnionLeaveResponse>
    {
        protected override async ETTask Run(Scene scene, M2U_UnionLeaveRequest request, U2M_UnionLeaveResponse response)
        {
            DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }

            if (request.UserId == dBUnionInfo.UnionInfo.LeaderId && dBUnionInfo.UnionInfo.UnionPlayerList.Count > 1)
            {
                response.Error = ErrorCode.ERR_Union_NotRemove;
                return;
            }

            UnionPlayerInfo unionPlayerInfo = null;
            for (int i = dBUnionInfo.UnionInfo.UnionPlayerList.Count - 1; i >= 0; i--)
            {
                if (dBUnionInfo.UnionInfo.UnionPlayerList[i].UserID == request.UserId)
                {
                    unionPlayerInfo = dBUnionInfo.UnionInfo.UnionPlayerList[i];
                    dBUnionInfo.UnionInfo.UnionPlayerList.RemoveAt(i);
                    break;
                }
            }

            if(dBUnionInfo.UnionInfo.UnionPlayerList.Count == 0)
            {
                dBUnionInfo.UnionInfo.LeaderId = 0;
            }
            UnitCacheHelper.SaveComponent(scene.Root(), dBUnionInfo.Id, dBUnionInfo).Coroutine();

            await ETTask.CompletedTask;
        }
    }
}
