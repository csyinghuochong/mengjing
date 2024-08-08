namespace ET.Server
{

    [MessageHandler(SceneType.LoginCenter)]
    public class M2L_SerialReardHandler : MessageHandler<Scene, M2L_SerialReardRequest, L2M_SerialReardResponse>
    {
        protected override async ETTask Run(Scene scene, M2L_SerialReardRequest request, L2M_SerialReardResponse response)
        {
            AccountCenterComponent accountCenterComponent = scene.GetComponent<AccountCenterComponent>();
            response.Error = accountCenterComponent.GetSerialReward(request.SerialNumber);
            response.Message = accountCenterComponent.GetSerialKeyId(request.SerialNumber).ToString();
            
            await ETTask.CompletedTask;
        }
    }
}