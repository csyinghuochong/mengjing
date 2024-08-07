namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionApplyHandler : MessageHandler<Scene, C2U_UnionApplyRequest, U2C_UnionApplyResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionApplyRequest request, U2C_UnionApplyResponse response)
        {
            DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
            if (!dBUnionInfo.UnionInfo.ApplyList.Contains(request.UserId))
            {
                dBUnionInfo.UnionInfo.ApplyList.Add(request.UserId);
            }
            
            A2M_GetUnitInfoRequest a2MGetUnitInfoRequest = A2M_GetUnitInfoRequest.Create();
            M2A_GetUnitInfoResponse m2AGetUnitInfoResponse = await scene.Root().GetComponent<MessageLocationSenderComponent>()
                    .Get(LocationType.Unit).Call(dBUnionInfo.UnionInfo.LeaderId, a2MGetUnitInfoRequest) as M2A_GetUnitInfoResponse;
            if (m2AGetUnitInfoResponse.Error == ErrorCode.ERR_Success &&  m2AGetUnitInfoResponse.PlayerState == 0)
            {
                M2C_UnionApplyResult m2C_HorseNoticeInfo = M2C_UnionApplyResult.Create();
                MapMessageHelper.SendToClient(scene.Root(), dBUnionInfo.UnionInfo.LeaderId, m2C_HorseNoticeInfo);
            }
            else
            {
                ReddotComponentS reddotComponent =
                        await UnitCacheHelper.GetComponentCache<ReddotComponentS>(scene.Root(), dBUnionInfo.UnionInfo.LeaderId);
                if (reddotComponent != null)
                {
                    reddotComponent.AddReddont((int)ReddotType.UnionApply);
                    UnitCacheHelper.SaveComponentCache(scene.Root(), reddotComponent).Coroutine();
                }
            }
            UnitCacheHelper.SaveComponentCache(scene.Root(),  dBUnionInfo).Coroutine();
        }
    }
}
