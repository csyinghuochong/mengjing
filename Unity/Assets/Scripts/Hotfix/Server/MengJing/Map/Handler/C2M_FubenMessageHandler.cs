namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_FubenMessageHandler : MessageLocationHandler<Unit, C2M_FubenMessageRequest, M2C_FubenMessageResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FubenMessageRequest request, M2C_FubenMessageResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}
