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
    }
}