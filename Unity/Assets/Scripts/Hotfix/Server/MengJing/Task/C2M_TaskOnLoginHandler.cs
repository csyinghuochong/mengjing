using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponent_S))]
    public class C2M_TaskOnLoginHandler : MessageLocationHandler<Unit, C2M_TaskOnLoginRequest, M2C_TaskOnLoginResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskOnLoginRequest request, M2C_TaskOnLoginResponse response)
        {
            TaskComponent_S taskComponent = unit.GetComponent<TaskComponent_S>();
            taskComponent.OnLogin();
            await ETTask.CompletedTask;
        }
    }
}
