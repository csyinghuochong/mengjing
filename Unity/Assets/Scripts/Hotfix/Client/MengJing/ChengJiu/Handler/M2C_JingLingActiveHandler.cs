namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_JingLingActiveHandler : MessageHandler<Scene, M2C_JingLingActiveMessage>
    {
        protected override async ETTask Run(Scene root, M2C_JingLingActiveMessage message)
        {
            ChengJiuComponentC chengJiuComponentC = root.GetComponent<ChengJiuComponentC>();
            chengJiuComponentC.UpdateJingLingList(message.JingLingList);

            EventSystem.Instance.Publish(root, new JingLingActive());

            await ETTask.CompletedTask;
        }
    }
}