namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_FashionActiveHandler: MessageLocationHandler<Unit, C2M_FashionActiveRequest, M2C_FashionActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FashionActiveRequest request, M2C_FashionActiveResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
    
}

