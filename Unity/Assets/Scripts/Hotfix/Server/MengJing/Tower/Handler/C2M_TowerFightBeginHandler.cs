namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TowerFightBeginHandler : MessageLocationHandler<Unit, C2M_TowerFightBeginRequest, M2C_TowerFightBeginResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TowerFightBeginRequest request, M2C_TowerFightBeginResponse response)
        {
            unit.Scene().GetComponent<TowerComponent>()?.BeginTower();
            await ETTask.CompletedTask;
        }
    }
}
