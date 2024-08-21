namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_OneChallengeHandle : MessageHandler<Scene, M2C_OneChallenge>
    {
        protected override async ETTask Run(Scene root, M2C_OneChallenge message)
        {
            // EventType.UIOneChallenge.Instance.ZoneScene = session.ZoneScene();
            // EventType.UIOneChallenge.Instance.m2C_OneChallenge = message;
            // EventSystem.Instance.PublishClass(EventType.UIOneChallenge.Instance);
            await ETTask.CompletedTask;
        }
    }
}