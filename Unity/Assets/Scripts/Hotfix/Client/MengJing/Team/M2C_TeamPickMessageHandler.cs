namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamPickMessageHandler : MessageHandler<Scene, M2C_TeamPickMessage>
    {
        protected override async ETTask Run(Scene root, M2C_TeamPickMessage message)
        {
            EventSystem.Instance.Publish(root, new TeamPickNotice() { M2CTeamPickMessage = message });
            await ETTask.CompletedTask;
        }
    }
}