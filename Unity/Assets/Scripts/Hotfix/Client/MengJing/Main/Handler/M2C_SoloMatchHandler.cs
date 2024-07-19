namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SoloMatchHandler: MessageHandler<Scene, M2C_SoloMatchResult>
    {
        protected override async ETTask Run(Scene root, M2C_SoloMatchResult message)
        {
            HintHelp.ShowHint(root, "to do : M2C_SoloMatchResult");
            
            EnterMapHelper.RequestTransfer(
                root, SceneTypeEnum.Solo, 2000010, 0, message.FubenId.ToString()
            ).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}