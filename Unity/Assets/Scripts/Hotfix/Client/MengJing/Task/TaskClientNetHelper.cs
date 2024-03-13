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
    }
}