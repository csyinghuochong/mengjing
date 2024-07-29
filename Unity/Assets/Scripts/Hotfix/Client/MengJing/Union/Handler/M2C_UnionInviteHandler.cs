namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnionInviteHandler : MessageHandler<Scene, M2C_UnionInviteMessage>
    {
        protected override async ETTask Run(Scene root, M2C_UnionInviteMessage message)
        {
            EventSystem.Instance.Publish(root, new UnionInvite() { M2C_UnionInviteMessage = message });

            await ETTask.CompletedTask;
        }
    }
}