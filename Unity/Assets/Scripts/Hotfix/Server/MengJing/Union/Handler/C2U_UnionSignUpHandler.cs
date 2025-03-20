namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionSignUpHandler : MessageHandler<Scene, C2U_UnionSignUpRequest, U2C_UnionSignUpResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionSignUpRequest request, U2C_UnionSignUpResponse response)
        {
            UnionSceneComponent unionSceneComponent = scene.GetComponent<UnionSceneComponent>();
            DBUnionInfo dBUnionInfo = await unionSceneComponent.GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }

            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.UnionOperate, request.UnionId))
            {
                
                
            }

            await ETTask.CompletedTask;
        }
    }
}
