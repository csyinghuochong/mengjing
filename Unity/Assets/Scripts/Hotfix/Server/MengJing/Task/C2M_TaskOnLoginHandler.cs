using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentServer))]
    public class C2M_TaskOnLoginHandler : MessageLocationHandler<Unit, C2M_TaskOnLoginRequest, M2C_TaskOnLoginResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskOnLoginRequest request, M2C_TaskOnLoginResponse response)
        {
            TaskComponentServer taskComponent = unit.GetComponent<TaskComponentServer>();
            taskComponent.OnLogin();
            await ETTask.CompletedTask;
        }
    }
}
