namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_RankRunRaceHandler: MessageHandler<Scene, M2C_RankRunRaceMessage>
    {
        protected override async ETTask Run(Scene root, M2C_RankRunRaceMessage message)
        {
            EventSystem.Instance.Publish(root, new RunRaceInfo() { M2CRankRunRaceMessage = message });
            await ETTask.CompletedTask;
        }
    }
}