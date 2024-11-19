namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetBarUpgradeHandler : MessageLocationHandler<Unit, C2M_PetBarUpgradeRequest, M2C_PetBarUpgradeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetBarUpgradeRequest request, M2C_PetBarUpgradeResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}