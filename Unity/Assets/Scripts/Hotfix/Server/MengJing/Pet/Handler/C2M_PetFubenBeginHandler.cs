namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFubenBeginHandler: MessageLocationHandler<Unit, C2M_PetFubenBeginRequest, M2C_PetFubenBeginResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFubenBeginRequest request, M2C_PetFubenBeginResponse response)
        {

            
            await ETTask.CompletedTask;
        }
    }
}

