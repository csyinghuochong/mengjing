namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamDungeonSettlementHandler : MessageHandler<Scene, M2C_TeamDungeonSettlement>
    {
        protected override async ETTask Run(Scene root, M2C_TeamDungeonSettlement message)
        {
            EventSystem.Instance.Publish(root, new TeamDungeonSettlement() { m2C_FubenSettlement = message });

            await ETTask.CompletedTask;
        }
    }
}