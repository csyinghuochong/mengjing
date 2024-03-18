using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentClient))]
    [FriendOf(typeof(TaskComponentClient))]
    public static class TaskClientNetHelper
    {
        public static async ETTask<int> RequestTaskInit(Scene root)
        {
            Log.Debug($"C2M_TaskInitRequest: client0");
            M2C_TaskInitResponse response = (M2C_TaskInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_TaskInitRequest());

            TaskComponentClient taskComponentClient = root.GetComponent<TaskComponentClient>();
            taskComponentClient.RoleTaskList = response.RoleTaskList;       
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> RequestTaskTrack(Scene root, int taskId, int trackStatus)
        {
            C2M_TaskTrackRequest request = new () { TaskId = taskId, TrackStatus = trackStatus };
            M2C_TaskTrackResponse response = (M2C_TaskTrackResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            TaskComponentClient taskComponentClient = root.GetComponent<TaskComponentClient>();
            for (int i = 0; i < taskComponentClient.RoleTaskList.Count; i++)
            {
                if (taskComponentClient.RoleTaskList[i].taskID == taskId)
                {
                    taskComponentClient.RoleTaskList[i].TrackStatus = trackStatus;
                }
            }
            
            EventSystem.Instance.Publish(root,new DataUpdate_TaskTrace());
            return response.Error;
        }

        public static async ETTask<int> RequestCommitTask(Scene root, int taskid, long banginfoId)
        {
            TaskComponentClient taskComponentClient = root.GetComponent<TaskComponentClient>();
            TaskPro taskPro = taskComponentClient.GetTaskById(taskid);
            if (taskPro == null || taskPro.taskStatus != (int)TaskStatuEnum.Completed)
            {
                return ErrorCode.Pre_Condition_Error;
            }
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskid);
            List<RewardItem> rewardItems = TaskHelper.GetTaskRewards(taskid, taskConfig);
            if (root.GetComponent<BagComponentClient>().GetBagLeftCell() < rewardItems.Count)
            {
                return ErrorCode.ERR_BagIsFull;
            }
            
            C2M_TaskCommitRequest request = new() { TaskId = taskid, BagInfoID = banginfoId };
            M2C_TaskCommitResponse response = (M2C_TaskCommitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }
                
            for (int i = taskComponentClient.RoleTaskList.Count - 1; i >= 0; i--)
            {
                if (taskComponentClient.RoleTaskList[i].taskID == taskid)
                {
                    taskComponentClient.RoleTaskList.RemoveAt(i);
                    break;
                }
            }
            taskComponentClient.RoleComoleteTaskList = response.RoleComoleteTaskList;
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
            
            TaskComponentClient taskComponentClient = root.GetComponent<TaskComponentClient>();
            taskComponentClient.RoleTaskList.Add(response.TaskPro);
            EventSystem.Instance.Publish(root,new DataUpdate_TaskGet());
            return response.Error;
        }
    }
}