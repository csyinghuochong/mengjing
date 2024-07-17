namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_AreneInfoHandler: MessageHandler<Scene, M2C_AreneInfoResult>
    {
        protected override async ETTask Run(Scene root, M2C_AreneInfoResult message)
        {
            EventSystem.Instance.Publish(root, new AreneInfo() { M2CAreneInfoResult = message });

            await ETTask.CompletedTask;
        }
    }
}