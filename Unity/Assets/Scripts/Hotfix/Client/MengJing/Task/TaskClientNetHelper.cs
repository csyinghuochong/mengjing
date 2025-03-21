using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(TaskComponentC))]
    public static class TaskClientNetHelper
    {
        public static async ETTask<int> RequestTaskInit(Scene root)
        {
            Log.Debug($"C2M_TaskInitRequest: client0");
            M2C_TaskInitResponse response = (M2C_TaskInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(C2M_TaskInitRequest.Create());

            TaskComponentC taskComponentC = root.GetComponent<TaskComponentC>();
            taskComponentC.RoleTaskList = response.RoleTaskList;
            taskComponentC.RoleComoleteTaskList = response.RoleComoleteTaskList;
            taskComponentC.ReceiveHuoYueIds = response.ReceiveHuoYueIds;
            taskComponentC.ReceiveGrowUpRewardIds = response.ReceiveGrowUpRewardIds;
            return response.Error;
        }

        public static async ETTask<int> UnionOrderTaskRequest(Scene root, int operate)
        {
            C2M_UnionOrderOperateRequest request = C2M_UnionOrderOperateRequest.Create();   
            request.OperateType = operate;  
            M2C_UnionOrderOperateResponse response = (M2C_UnionOrderOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestTaskTrack(Scene root, int taskId, int trackStatus)
        {
            C2M_TaskTrackRequest request = C2M_TaskTrackRequest.Create();
            request.TaskId = taskId;
            request.TrackStatus = trackStatus;

            M2C_TaskTrackResponse response = (M2C_TaskTrackResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            TaskComponentC taskComponentC = root.GetComponent<TaskComponentC>();
            for (int i = 0; i < taskComponentC.RoleTaskList.Count; i++)
            {
                if (taskComponentC.RoleTaskList[i].taskID == taskId)
                {
                    taskComponentC.RoleTaskList[i].TrackStatus = trackStatus;
                }
            }

            EventSystem.Instance.Publish(root, new TaskTrace());
            return response.Error;
        }

        public static async ETTask<int> RequestCommitTask(Scene root, int taskid, long banginfoId)
        {
            TaskComponentC taskComponentC = root.GetComponent<TaskComponentC>();
            TaskPro taskPro = taskComponentC.GetTaskById(taskid);
            if (taskPro == null || taskPro.taskStatus != (int)TaskStatuEnum.Completed)
            {
                return ErrorCode.Pre_Condition_Error;
            }

            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
            List<RewardItem> rewardItems = TaskHelper.GetTaskRewards(taskid, taskConfig);
            if (root.GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < rewardItems.Count)
            {
                return ErrorCode.ERR_BagIsFull;
            }

            C2M_TaskCommitRequest request = C2M_TaskCommitRequest.Create();
            request.TaskId = taskid;
            request.BagInfoID = banginfoId;

            M2C_TaskCommitResponse response = (M2C_TaskCommitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }
            
            taskComponentC.RoleTaskList= response.RoleTaskList;
            taskComponentC.RoleComoleteTaskList = response.RoleComoleteTaskList;
            EventSystem.Instance.Publish(root, new TaskComplete() { TaskConfigId = taskid });
            return response.Error;
        }

        public static async ETTask<int> RequestGetTask(Scene root, int taskId)
        {
            C2M_TaskGetRequest request = C2M_TaskGetRequest.Create();
            request.TaskId = taskId;

            M2C_TaskGetResponse response = (M2C_TaskGetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            TaskComponentC taskComponentC = root.GetComponent<TaskComponentC>();
            taskComponentC.RoleTaskList.Add(response.TaskPro);
            EventSystem.Instance.Publish(root, new TaskGet() { TaskConfigId = taskId });
            return response.Error;
        }

        public static async ETTask<int> RequestGiveUpTask(Scene root, int taskId)
        {
            C2M_TaskGiveUpRequest request = C2M_TaskGiveUpRequest.Create();
            request.TaskId = taskId;

            M2C_TaskGiveUpResponse response = (M2C_TaskGiveUpResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            TaskComponentC taskComponentC = root.GetComponent<TaskComponentC>();
            for (int i = taskComponentC.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (taskComponentC.RoleTaskList[i].taskID == taskId)
                {
                    taskComponentC.RoleTaskList.RemoveAt(i);
                    break;
                }
            }

            EventSystem.Instance.Publish(root, new TaskGiveUp());
            return response.Error;
        }

        public static async ETTask<M2C_WelfareTaskRewardResponse> WelfareTaskReward(Scene root, int day)
        {
            C2M_WelfareTaskRewardRequest request = C2M_WelfareTaskRewardRequest.Create();
            request.day = day;

            M2C_WelfareTaskRewardResponse response = (M2C_WelfareTaskRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                root.GetComponent<UserInfoComponentC>().UserInfo.WelfareTaskRewards.Add(day);
            }

            return response;
        }

        public static async ETTask<int> TaskGrowUpRewardRequest(Scene root, int growUpId)
        {
            C2M_TaskGrowUpRewardRequest request = C2M_TaskGrowUpRewardRequest.Create();
            request.GrowUpRewardId = growUpId;
            M2C_TaskGrowUpRewardResponse response = (M2C_TaskGrowUpRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == ErrorCode.ERR_Success)
            {
                TaskComponentC taskComponent = root.GetComponent<TaskComponentC>();
                taskComponent.ReceiveGrowUpRewardIds.Add(growUpId);
            }
            return response.Error;
        }

        public static async ETTask<int> TaskHuoYueRewardRequest(Scene root, int huoYueId)
        {
            C2M_TaskHuoYueRewardRequest request = C2M_TaskHuoYueRewardRequest.Create();
            request.HuoYueId = huoYueId;

            M2C_TaskHuoYueRewardResponse response = (M2C_TaskHuoYueRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == ErrorCode.ERR_Success)
            {
                TaskComponentC taskComponent = root.GetComponent<TaskComponentC>();
                taskComponent.ReceiveHuoYueIds.Add(huoYueId);
            }

            return response.Error;
        }

        //对话完成
        public static async ETTask SendTaskNotice(Scene root, int taskId)
        {
            TaskComponentC taskComponent = root.GetComponent<TaskComponentC>();
            for (int k = 0; k < taskComponent.RoleTaskList.Count; k++)
            {
                if (taskComponent.RoleTaskList[k].taskID == taskId)
                {
                    taskComponent.RoleTaskList[k].taskTargetNum_1 = 1;
                    taskComponent.RoleTaskList[k].taskStatus = (int)TaskStatuEnum.Completed;
                }
            }

            C2M_TaskNoticeRequest request = C2M_TaskNoticeRequest.Create();
            request.TaskId = taskId;

            M2C_TaskNoticeResponse response = (M2C_TaskNoticeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            EventSystem.Instance.Publish(root, new TaskUpdate());
        }
    }
}