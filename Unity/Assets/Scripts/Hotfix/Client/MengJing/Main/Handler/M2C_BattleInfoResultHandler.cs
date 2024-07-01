namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_BattleInfoResultHandler: MessageHandler<Scene, M2C_BattleInfoResult>
    {
        protected override async ETTask Run(Scene root, M2C_BattleInfoResult message)
        {
            EventSystem.Instance.Publish(root, new BattleInfo() { M2CBattleInfoResult = message });

            await ETTask.CompletedTask;
        }
    }
}