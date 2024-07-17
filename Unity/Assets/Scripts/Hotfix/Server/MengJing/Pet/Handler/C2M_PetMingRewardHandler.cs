namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMingRewardHandler : MessageLocationHandler<Unit, C2M_PetMingRewardRequest, M2C_PetMingRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMingRewardRequest request, M2C_PetMingRewardResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}
