namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitStateUpdateHandler: MessageHandler<Scene, M2C_UnitStateUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_UnitStateUpdate message)
        {
           
            await ETTask.CompletedTask;
        }
    }
}