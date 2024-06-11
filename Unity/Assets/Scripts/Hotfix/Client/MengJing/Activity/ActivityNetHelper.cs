namespace ET.Client
{
    public static class ActivityNetHelper
    {
        public static async ETTask<int> RequestActivityInfo(Scene root)
        {
            Log.Debug($"C2A_ActivityInfoRequest: client0");
            C2A_ActivityInfoRequest request = new();
            A2C_ActivityInfoResponse response = (A2C_ActivityInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            Log.Debug($"C2M_BagInitHandler: client1");
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> ActivityReceive(Scene root, int activityType, int activityId)
        {
            C2M_ActivityReceiveRequest request = new() { ActivityType = activityType, ActivityId = activityId };
            M2C_ActivityReceiveResponse response = (M2C_ActivityReceiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            ActivityComponentC activityComponent = root.GetComponent<ActivityComponentC>();

            if (activityType == 31)
            {
                activityComponent.LastLoginTime = TimeHelper.ServerNow();
            }

            if (response.Error == ErrorCode.ERR_Success)
            {
                activityComponent.ActivityReceiveIds.Add(activityId);
            }

            return response.Error;
        }

        public static async ETTask<M2C_WelfareDrawResponse> WelfareDraw(Scene root)
        {
            C2M_WelfareDrawRequest request = new();
            M2C_WelfareDrawResponse response = (M2C_WelfareDrawResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}