namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_RankDemonHandler: MessageHandler<Scene, M2C_RankDemonMessage>
    {
        protected override async ETTask Run(Scene root, M2C_RankDemonMessage message)
        {
            EventSystem.Instance.Publish(root, new RankDemonInfo() { M2CRankDemonMessage = message });

            await ETTask.CompletedTask;
        }
    }
}