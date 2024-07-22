
namespace ET.Client.Handler
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TaskUpdateHandler: MessageHandler<Scene, M2C_TaskUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_TaskUpdate message)
        {
            root.GetComponent<TaskComponentC>()?.OnRecvTaskUpdate( message );
            await ETTask.CompletedTask;
        }
    }
}