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

            ActorId gateServerId = UnitCacheHelper.GetGateServerId(scene.Zone());
            T2G_GateUnitInfoRequest T2G_GateUnitInfoRequest = T2G_GateUnitInfoRequest.Create();
            T2G_GateUnitInfoRequest.UserID = dBUnionInfo.UnionInfo.LeaderId;
            G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
                  (gateServerId, T2G_GateUnitInfoRequest);
            if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
            {
                M2C_UnionApplyResult m2C_HorseNoticeInfo = M2C_UnionApplyResult.Create();
                MapMessageHelper.SendToClient(scene.Root(), g2M_UpdateUnitResponse.SessionInstanceId, m2C_HorseNoticeInfo);
            }
            //暂时离线需要通知到map?
            if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.None)
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
