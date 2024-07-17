namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2U_UnionInviteReplyHandler : MessageLocationHandler<Scene, M2U_UnionInviteReplyMessage>
    {
        protected override async ETTask Run(Scene scene, M2U_UnionInviteReplyMessage request)
        {
            Log.Debug($"M2U_UnionInviteReplyMessage : {request}");
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.UnionOperate, request.UnionId))
            {
                await scene.GetComponent<UnionSceneComponent>().OnJoinUinon(request.UnionId, request.UnitID, 1);
            }
            await ETTask.CompletedTask;
        }
    }
}
