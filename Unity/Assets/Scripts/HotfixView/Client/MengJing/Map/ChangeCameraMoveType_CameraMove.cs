namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class ChangeCameraMoveType_CameraMove : AEvent<Scene, ChangeCameraMoveType>
    {
        protected override async ETTask Run(Scene scene, ChangeCameraMoveType args)
        {
            MJCameraComponent cameraComponent = scene.CurrentScene().GetComponent<MJCameraComponent>();

            if (args.CameraType == (int)CameraMoveType.Pull)
            {
                cameraComponent.SetPullCamera();
            }
            else if (args.CameraType == (int)CameraMoveType.Rollback)
            {
                cameraComponent.SetRollbackCamera();
            }

            await ETTask.CompletedTask;
        }
    }
}