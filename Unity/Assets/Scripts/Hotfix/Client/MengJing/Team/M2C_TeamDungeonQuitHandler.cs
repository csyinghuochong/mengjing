namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamDungeonQuitHandler : MessageHandler<Scene, M2C_TeamDungeonQuitMessage>
    {
        protected override async ETTask Run(Scene root, M2C_TeamDungeonQuitMessage message)
        {
            EventSystem.Instance.Publish(root, new TeamDungeonQuit() { M2CTeamDungeonQuitMessage = message });

            await ETTask.CompletedTask;
        }
    }
}