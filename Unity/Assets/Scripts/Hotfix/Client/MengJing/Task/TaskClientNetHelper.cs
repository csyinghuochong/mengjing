using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponent_C))]
    [FriendOf(typeof(TaskComponent_C))]
    public static class TaskClientNetHelper
    {
        public static async ETTask<int> RequestTaskInit(Scene root)
        {
            Log.Debug($"C2M_TaskInitRequest: client0");
            M2C_TaskInitResponse response = (M2C_TaskInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_TaskInitRequest());

            TaskComponent_C taskComponentC = root.GetComponent<TaskComponent_C>();
            taskComponentC.RoleTaskList = response.RoleTaskList;       
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestTaskTrack(Scene root, int taskId, int trackStatus)
        {
            C2M_TaskTrackRequest request = new () { TaskId = taskId, TrackStatus = trackStatus };
            M2C_TaskTrackResponse response = (M2C_TaskTrackResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            TaskComponent_C taskComponentC = root.GetComponent<TaskComponent_C>();
            for (int i = 0; i < taskComponentC.RoleTaskList.Count; i++)
            {
                if (taskComponentC.RoleTaskList[i].taskID == taskId)
                {
                    taskComponentC.RoleTaskList[i].TrackStatus = trackStatus;
                }
            }
            
            EventSystem.Instance.Publish(root,new DataUpdate_TaskTrace());
            return response.Error;
        }

        public static async ETTask<int> RequestCommitTask(Scene root, int taskid, long banginfoId)
        {
            TaskComponent_C taskComponentC = root.GetComponent<TaskComponent_C>();
            TaskPro taskPro = taskComponentC.GetTaskById(taskid);
            if (taskPro == null || taskPro.taskStatus != (int)TaskStatuEnum.Completed)
            {
                return ErrorCode.Pre_Condition_Error;
            }
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
            List<RewardItem> rewardItems = TaskHelper.GetTaskRewards(taskid, taskConfig);
            if (root.GetComponent<BagComponent_C>().GetBagLeftCell() < rewardItems.Count)
            {
                return ErrorCode.ERR_BagIsFull;
            }
            
            C2M_TaskCommitRequest request = new() { TaskId = taskid, BagInfoID = banginfoId };
            M2C_TaskCommitResponse response = (M2C_TaskCommitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }
                
            for (int i = taskComponentC.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (taskComponentC.RoleTaskList[i].taskID == taskid)
                {
                    taskComponentC.RoleTaskList.RemoveAt(i);
                    break;
                }
            }
            taskComponentC.RoleComoleteTaskList = response.RoleComoleteTaskList;
            EventSystem.Instance.Publish(root,new DataUpdate_TaskComplete());
            return response.Error;
        }


        public static async ETTask<int> RequestGetTask(Scene root, int taskId)
        {
            C2M_TaskGetRequest request = new () { TaskId = taskId };
            M2C_TaskGetResponse response = (M2C_TaskGetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }
            
            TaskComponent_C taskComponentC = root.GetComponent<TaskComponent_C>();
            taskComponentC.RoleTaskList.Add(response.TaskPro);
            EventSystem.Instance.Publish(root,new DataUpdate_TaskGet());
            return response.Error;
        }

        public static async ETTask<int> RequestGiveUpTask(Scene root, int taskId)
        {
            C2M_TaskGiveUpRequest request = new() { TaskId = taskId };
            M2C_TaskGiveUpResponse response = (M2C_TaskGiveUpResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            TaskComponent_C taskComponentC = root.GetComponent<TaskComponent_C>();
            for (int i = taskComponentC.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (taskComponentC.RoleTaskList[i].taskID == taskId)
                {
                    taskComponentC.RoleTaskList.RemoveAt(i);
                    break;
                }
            }
            
            EventSystem.Instance.Publish(root,new DataUpdate_TaskGet());
            return response.Error;
        }
    }
}