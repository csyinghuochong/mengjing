namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TeamUpdateHandler : MessageHandler<Scene, M2C_TeamUpdateResult>
    {
        protected override async ETTask Run(Scene root, M2C_TeamUpdateResult message)
        {
            TeamComponentC teamComponent = root.GetComponent<TeamComponentC>();
            teamComponent.OnRecvTeamUpdate(message);

            EventSystem.Instance.Publish(root, new RecvTeamUpdate());

            await ETTask.CompletedTask;
        }
    }
}