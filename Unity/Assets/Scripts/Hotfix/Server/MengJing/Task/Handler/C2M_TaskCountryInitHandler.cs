using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskCountryInitHandler : MessageLocationHandler<Unit, C2M_TaskCountryInitRequest, M2C_TaskCountryInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskCountryInitRequest request, M2C_TaskCountryInitResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            response.TaskCountryList .AddRange(taskComponent.TaskCountryList); 
            response.ReceiveHuoYueIds .AddRange(taskComponent.ReceiveHuoYueIds); 
            await ETTask.CompletedTask;
        }
    }
}
