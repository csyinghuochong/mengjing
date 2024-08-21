namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_OneChallengeHandle : MessageHandler<Scene, M2C_OneChallenge>
    {
        protected override async ETTask Run(Scene root, M2C_OneChallenge message)
        {
            EventSystem.Instance.Publish(root, new UIOneChallenge() { m2C_OneChallenge = message });

            await ETTask.CompletedTask;
        }
    }
}