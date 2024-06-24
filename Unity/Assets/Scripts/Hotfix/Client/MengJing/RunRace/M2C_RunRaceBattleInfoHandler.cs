namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_RunRaceBattleInfoHandler : MessageHandler<Scene, M2C_RunRaceBattleInfo>
    {
        protected override async ETTask Run(Scene root, M2C_RunRaceBattleInfo message)
        {
            root.GetComponent<BattleMessageComponent>().M2C_RunRaceBattleInfo = message;
            EventSystem.Instance.Publish(root, new RunRaceBattleInfo() { M2C_RunRaceBattleInfo = message });
            await ETTask.CompletedTask;
        }
    }
}
