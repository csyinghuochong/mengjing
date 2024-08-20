namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_JiaYuanUpdateHandler: MessageHandler<Scene, M2C_JiaYuanUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_JiaYuanUpdate message)
        {
          
            await ETTask.CompletedTask;
        }
    }
}