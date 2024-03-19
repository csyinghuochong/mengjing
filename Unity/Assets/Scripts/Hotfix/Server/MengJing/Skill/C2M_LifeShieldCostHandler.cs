namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentServer))]
    public class C2M_LifeShieldCostHandler : MessageLocationHandler<Unit, C2M_LifeShieldCostRequest, M2C_LifeShieldCostResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_LifeShieldCostRequest request, M2C_LifeShieldCostResponse response)
        {
            await ETTask.CompletedTask;
            
            
        }
    }
}