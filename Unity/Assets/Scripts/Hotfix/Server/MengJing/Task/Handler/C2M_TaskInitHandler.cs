using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskInitHandler : MessageLocationHandler<Unit, C2M_TaskInitRequest, M2C_TaskInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskInitRequest request, M2C_TaskInitResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();

            for (int i = 0; i < taskComponent.RoleTaskList.Count; i++)
            {
                if(TaskConfigCategory.Instance.Get(taskComponent.RoleTaskList[i].taskID).TaskType != (int)TaskTypeEnum.Main )
                {
                    taskComponent.RoleTaskList[i].TrackStatus = 0;
                }
            }

            response.RoleTaskList .AddRange(taskComponent.RoleTaskList); 
            response.RoleComoleteTaskList .AddRange(taskComponent.RoleComoleteTaskList); 
            response.ReceiveHuoYueIds .AddRange(taskComponent.ReceiveHuoYueIds); 
            response.ReceiveGrowUpRewardIds.AddRange(taskComponent.ReceiveGrowUpRewardIds); 
            Console.WriteLine($"C2M_TaskInitRequest:  {taskComponent.RoleTaskList.Count}");
            await ETTask.CompletedTask;
        }
    }
}