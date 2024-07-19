namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_FriendApplyHandler: MessageHandler<Scene, M2C_FriendApplyResult>
    {
        protected override async ETTask Run(Scene root, M2C_FriendApplyResult message)
        {
            HintHelp.ShowHint(root, "to do : M2C_FriendApplyResult");
            await ETTask.CompletedTask;
        }
    }
}