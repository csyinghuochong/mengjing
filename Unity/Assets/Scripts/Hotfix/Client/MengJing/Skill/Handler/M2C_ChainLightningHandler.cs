namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_ChainLightningHandler : MessageHandler<Scene, M2C_ChainLightning>
    {
        protected override async ETTask Run(Scene root, M2C_ChainLightning message)
        {
            EventSystem.Instance.Publish(root, new SkillChainLight() { M2C_ChainLightning = message });

            await ETTask.CompletedTask;
        }
    }
}