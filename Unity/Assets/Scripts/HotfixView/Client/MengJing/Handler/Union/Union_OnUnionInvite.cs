namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Union_OnUnionInvite : AEvent<Scene, UnionInvite>
    {
        protected override async ETTask Run(Scene scene, UnionInvite args)
        {
            M2C_UnionInviteMessage message = args.M2C_UnionInviteMessage;
            PopupTipHelp.OpenPopupTip(scene, "公会邀请", $"玩家{message.PlayerName}邀请你加入{message.UnionName}，是否接受?", () =>
            {
                if (scene.IsDisposed)
                {
                    return;
                }

                UnionNetHelper.UnionInviteReplyRequest(scene, message.UnionId, 1);
            }, null).Coroutine();

            await ETTask.CompletedTask;
        }
    }
}
