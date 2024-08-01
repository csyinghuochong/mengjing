namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamInviteHandler : MessageHandler<Scene, M2C_TeamInviteResult>
    {
        protected override async ETTask Run(Scene root, M2C_TeamInviteResult message)
        {
            EventSystem.Instance.Publish(root, new RecvTeamInvite() { m2C_TeamInviteResult = message });
            await ETTask.CompletedTask;
        }
    }
}