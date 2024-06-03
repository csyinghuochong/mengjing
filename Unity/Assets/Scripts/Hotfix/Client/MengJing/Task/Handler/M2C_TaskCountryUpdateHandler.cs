
namespace ET.Client.Handler
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_TaskCountryUpdateHandler: MessageHandler<Scene, M2C_TaskCountryUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_TaskCountryUpdate message)
        {
            root.GetComponent<TaskComponentC>().OnRecvTaskCountryUpdate( message );
            await ETTask.CompletedTask;
        }
    }
}