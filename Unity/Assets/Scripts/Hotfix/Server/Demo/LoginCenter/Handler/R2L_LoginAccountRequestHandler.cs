namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class R2L_LoginAccountRequestHandler : MessageHandler<Scene,R2L_LoginAccountRequest,L2R_LoginAccountRequest>
    {
        protected override async ETTask Run(Scene scene, R2L_LoginAccountRequest request, L2R_LoginAccountRequest response)
        {
            long accountId = request.AccountName.GetLongHashCode();
            
            CoroutineLockComponent coroutineLockComponent = scene.GetComponent<CoroutineLockComponent>();
            using (await  coroutineLockComponent.Wait(CoroutineLockType.LoginCenterLock,accountId))
            {
                if (!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accountId))
                {
                    return;
                }

                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone, request.AccountName);
                
                L2G_DisconnectGateUnit l2GDisconnectGateUnit = L2G_DisconnectGateUnit.Create();
                l2GDisconnectGateUnit.AccountName = request.AccountName;
                l2GDisconnectGateUnit.ReLink = request.Relink;
                var g2LDisconnectGateUnit = (G2L_DisconnectGateUnit) await scene.GetComponent<MessageSender>()
                        .Call(gateConfig.ActorId, l2GDisconnectGateUnit);

                response.Error = g2LDisconnectGateUnit.Error;
            }
        }
    }
}