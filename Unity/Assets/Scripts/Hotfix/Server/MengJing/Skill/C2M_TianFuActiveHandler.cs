namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TianFuActiveHandler : MessageLocationHandler<Unit, C2M_TianFuActiveRequest, M2C_TianFuActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TianFuActiveRequest request, M2C_TianFuActiveResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}