using System;

using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskInitHandler : MessageLocationHandler<Unit, C2M_TaskInitRequest, M2C_TaskInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskInitRequest request, M2C_TaskInitResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();

            response.RoleTaskList = taskComponent.RoleTaskList;
            response.RoleComoleteTaskList = taskComponent.RoleComoleteTaskList;
            response.ReceiveHuoYueIds = taskComponent.ReceiveHuoYueIds;
            response.TaskCountryList = taskComponent.TaskCountryList;
         
            await ETTask.CompletedTask;
        }
    }
}