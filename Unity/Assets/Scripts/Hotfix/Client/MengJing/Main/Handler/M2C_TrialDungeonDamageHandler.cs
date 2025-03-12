namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TrialDungeonDamageHandler: MessageHandler<Scene, M2C_TrialDungeonDamage>
    {
        protected override async ETTask Run(Scene root, M2C_TrialDungeonDamage message)
        {
            EventSystem.Instance.Publish(root, new TrialDungeonDamageInfo() { M2CTrialDungeonDamage = message });

            await ETTask.CompletedTask;
        }
    }
}