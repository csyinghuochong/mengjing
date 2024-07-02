namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SyncMiJingDamageHandler: MessageHandler<Scene, M2C_SyncMiJingDamage>
    {
        protected override async ETTask Run(Scene root, M2C_SyncMiJingDamage message)
        {
            EventSystem.Instance.Publish(root, new SyncMiJingDamage() { M2C_SyncMiJingDamage = message });

            await ETTask.CompletedTask;
        }
    }
}