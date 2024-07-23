namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class A2C_DisconnectHandler: MessageHandler<Scene, A2C_Disconnect>
    {
        protected override async ETTask Run(Scene root, A2C_Disconnect message)
        {
            Log.Warning("A2C_Disconnect");
            await ETTask.CompletedTask;
        }
    }
}