namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionSignUpHandler : MessageHandler<Scene, C2U_UnionSignUpRequest, U2C_UnionSignUpResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionSignUpRequest request, U2C_UnionSignUpResponse response)
        {
            UnionSceneComponent rankComponent = scene.GetComponent<UnionSceneComponent>();
            if (!rankComponent.DBUnionManager.SignupUnions.Contains(request.UnionId))
            {
                rankComponent.DBUnionManager.SignupUnions.Add(request.UnionId);
            }

            await ETTask.CompletedTask;
        }
    }
}
