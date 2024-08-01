namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamDungeonBoxRewardHandler : MessageHandler<Scene, M2C_TeamDungeonBoxRewardResult>
    {
        protected override async ETTask Run(Scene root, M2C_TeamDungeonBoxRewardResult message)
        {
            EventSystem.Instance.Publish(root, new TeamDungeonBoxReward() { M2CTeamDungeonBoxRewardResult = message });

            await ETTask.CompletedTask;
        }
    }
}