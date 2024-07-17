namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_RankRunRaceRewardHandler: MessageHandler<Scene, M2C_RankRunRaceReward>
    {
        protected override async ETTask Run(Scene root, M2C_RankRunRaceReward message)
        {
            EventSystem.Instance.Publish(root, new RunRaceRewardInfo() { M2CRankRunRaceReward = message });
            await ETTask.CompletedTask;
        }
    }
}