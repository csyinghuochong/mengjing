using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponent_S))]
    public class C2M_TaskGetRequestHandler : MessageLocationHandler<Unit, C2M_TaskGetRequest, M2C_TaskGetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskGetRequest request, M2C_TaskGetResponse response)
        {
            if (!TaskConfigCategory.Instance.Contain(request.TaskId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(request.TaskId);
            if (taskConfig.TaskType == TaskTypeEnum.Daily)
            {
                TaskComponent_S taskComponent = unit.GetComponent<TaskComponent_S>();
                if (taskComponent.GetTaskList(TaskTypeEnum.Daily).Count > 0)
                {
                    response.Error = ErrorCode.ERR_TaskCanNotGet;
                    return;
                }

                //获取当前任务是否已达上限
                if (unit.GetComponent<NumericComponent_S>().GetAsInt(NumericType.DailyTaskNumber) >= GlobalValueConfigCategory.Instance.Get(58).Value2)
                {
                    response.Error = ErrorCode.ERR_ShangJinNumFull;
                    return;
                }

                NumericComponent_S numericComponent = unit.GetComponent<NumericComponent_S>();
                int dailyTask = numericComponent.GetAsInt(NumericType.DailyTaskID);
                if (dailyTask == 0)
                {
                    response.Error = ErrorCode.ERR_TaskCanNotGet;
                    return;
                }
                response.TaskPro = taskComponent.OnGetDailyTask(dailyTask);
            }
            else if (taskConfig.TaskType == TaskTypeEnum.Union)
            {
                TaskComponent_S taskComponent = unit.GetComponent<TaskComponent_S>();
                if (taskComponent.GetTaskList(TaskTypeEnum.Union).Count > 0)
                {
                    response.Error = ErrorCode.ERR_TaskNoComplete;
                    return;
                }

                //获取当前任务是否已达上限
                int uniontask = unit.GetComponent<NumericComponent_S>().GetAsInt(NumericType.UnionTaskNumber);
                if (uniontask >= GlobalValueConfigCategory.Instance.Get(108).Value2)
                {
                    response.Error = ErrorCode.ERR_TaskLimited;
                    return;
                }

                NumericComponent_S numericComponent = unit.GetComponent<NumericComponent_S>();
                int unionTaskId = numericComponent.GetAsInt(NumericType.UnionTaskId);
                if (unionTaskId == 0)
                {
                    response.Error = ErrorCode.ERR_TaskCanNotGet;
                    return;
                }
                response.TaskPro = taskComponent.OnGetDailyTask(unionTaskId);
            }
            else if (taskConfig.TaskType == TaskTypeEnum.Treasure
                || taskConfig.TaskType == TaskTypeEnum.Ring)
            {
                if (unit.GetComponent<TaskComponent_S>().GetTaskList(taskConfig.TaskType).Count > 1)
                {
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }
                (TaskPro taskPro, int error) = unit.GetComponent<TaskComponent_S>().OnAcceptedTask(request.TaskId);
                response.Error = error;
                response.TaskPro = taskPro;
            }
            else
            {
                (TaskPro taskPro, int error) = unit.GetComponent<TaskComponent_S>().OnAcceptedTask(request.TaskId);
                response.Error = error;
                response.TaskPro = taskPro;
            }
            await ETTask.CompletedTask;
        }
    }
}
