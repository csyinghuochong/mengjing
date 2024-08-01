namespace ET.Server
{

    [MessageHandler(SceneType.Union)]
    public class C2U_UnionApplyReplyHandler : MessageHandler<Scene, C2U_UnionApplyReplyRequest, U2C_UnionApplyReplyResponse>
    {

        protected override async ETTask Run(Scene scene, C2U_UnionApplyReplyRequest request, U2C_UnionApplyReplyResponse response)
        {
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.UnionOperate, request.UnionId)) 
            {
                int errorcode = await scene.GetComponent<UnionSceneComponent>().OnJoinUinon(request.UnionId, request.UserId, request.ReplyCode);
                response.Error = errorcode;
            }
        }
    }
}
