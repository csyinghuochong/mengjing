namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_FubenSettlementHandler: MessageHandler<Scene, M2C_FubenSettlement>
    {
        protected override async ETTask Run(Scene root, M2C_FubenSettlement message)
        {
            EventSystem.Instance.Publish(root, new FubenSettlement() { m2C_FubenSettlement = message });
            await ETTask.CompletedTask;
        }
    }
}