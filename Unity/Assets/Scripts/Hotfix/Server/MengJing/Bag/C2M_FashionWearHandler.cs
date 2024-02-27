namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_FashionWearHandler: MessageLocationHandler<Unit, C2M_FashionWearRequest, M2C_FashionWearResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FashionWearRequest request, M2C_FashionWearResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
    
}