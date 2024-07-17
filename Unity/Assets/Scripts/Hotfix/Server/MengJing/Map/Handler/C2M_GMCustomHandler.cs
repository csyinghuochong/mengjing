namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GMCustomHandler : MessageLocationHandler<Unit, C2M_GMCustomRequest, M2C_GMCustomResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GMCustomRequest request, M2C_GMCustomResponse response)
        {

            await ETTask.CompletedTask;
        }
    }
}