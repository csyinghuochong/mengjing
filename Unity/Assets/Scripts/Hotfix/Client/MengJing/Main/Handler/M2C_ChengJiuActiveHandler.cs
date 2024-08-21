namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_ChengJiuActiveHandler : MessageHandler<Scene, M2C_ChengJiuActiveMessage>
    {
        protected override async ETTask Run(Scene root, M2C_ChengJiuActiveMessage message)
        {
            EventSystem.Instance.Publish(root, new ChengJiuActive() { m2C_ChengJiu = message });

            await ETTask.CompletedTask;
        }
    }
}