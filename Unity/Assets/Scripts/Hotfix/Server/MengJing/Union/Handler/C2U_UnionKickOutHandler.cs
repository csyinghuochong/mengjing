using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionKickOutHandler : MessageHandler<Scene, C2U_UnionKickOutRequest, U2C_UnionKickOutResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionKickOutRequest request, U2C_UnionKickOutResponse response)
        {
            DBUnionInfo dBUnionInfo =await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                return;
            }
            bool have = false;
            for (int i = dBUnionInfo.UnionInfo.UnionPlayerList.Count -1; i >= 0; i--)
            {
                if (dBUnionInfo.UnionInfo.UnionPlayerList[i].UserID == request.UserId)
                {
                    have = true;
                    dBUnionInfo.UnionInfo.UnionPlayerList.RemoveAt(i);
                }
            }

            if (!have)
            {
                return;
            }

            UnitCacheHelper.SaveComponentCache(scene.Root(),  dBUnionInfo).Coroutine();
            //通知玩家
            ActorId gateServerId = UnitCacheHelper.GetGateServerId(scene.Zone());
            G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
               (gateServerId, new T2G_GateUnitInfoRequest()
               {
                   UserID = request.UserId
               });
            if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
            {
                U2M_UnionKickOutRequest r2M_RechargeRequest = new U2M_UnionKickOutRequest() { UserId = request.UserId };
                M2U_UnionKickOutResponse m2G_RechargeResponse = (M2U_UnionKickOutResponse)await scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(request.UserId, r2M_RechargeRequest);
            }
            else
            {
                NumericComponentS numericComponent = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene.Root(), request.UserId);
                numericComponent.ApplyValue(NumericType.UnionId_0, 0, false);
                await UnitCacheHelper.SaveComponentCache(scene.Root(), numericComponent);
                
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), request.UserId);
                userInfoComponent.UserInfo.UnionName = string.Empty;
                await UnitCacheHelper.SaveComponentCache(scene.Root(), userInfoComponent);
            }
        }
    }
}
