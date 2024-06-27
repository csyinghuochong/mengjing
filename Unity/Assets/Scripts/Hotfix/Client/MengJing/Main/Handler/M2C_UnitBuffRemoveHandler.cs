namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitBuffRemoveHandler: MessageHandler<Scene, M2C_UnitBuffRemove>
    {
        protected override async ETTask Run(Scene root, M2C_UnitBuffRemove message)
        {
            
            await ETTask.CompletedTask;
        }
    }
}