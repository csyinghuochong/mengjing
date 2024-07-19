namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_HappyInfoHandler: MessageHandler<Scene, M2C_HappyInfoResult>
    {
        protected override async ETTask Run(Scene root, M2C_HappyInfoResult message)
        {
            HintHelp.ShowHint(root, "to do : M2C_HappyInfoResult");
            root.GetComponent<BattleMessageComponent>().M2C_HappyInfoResult = message;

            EventSystem.Instance.Publish(root, new HappyInfo() { M2CHappyInfoResult = message });
            await ETTask.CompletedTask;
        }
    }
}