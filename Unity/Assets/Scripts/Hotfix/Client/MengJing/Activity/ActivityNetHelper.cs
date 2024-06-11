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

        public static async ETTask<M2C_WelfareInvestResponse> WelfareInvest(Scene root, int day)
        {
            C2M_WelfareInvestRequest reuqest = new() { Index = day };
            M2C_WelfareInvestResponse response = (M2C_WelfareInvestResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            if (response.Error == ErrorCode.ERR_Success)
            {
                root.GetComponent<UserInfoComponentC>().UserInfo.WelfareInvestList.Add(day);
            }

            return response;
        }

        public static async ETTask<M2C_WelfareInvestRewardResponse> WelfareInvestReward(Scene root)
        {
            C2M_WelfareInvestRewardRequest request = new();
            M2C_WelfareInvestRewardResponse response = (M2C_WelfareInvestRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_WelfareDraw2Response> WelfareDraw2(Scene root)
        {
            C2M_WelfareDraw2Request request = new();
            M2C_WelfareDraw2Response response = (M2C_WelfareDraw2Response)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_WelfareDraw2RewardResponse> WelfareDraw2Reward(Scene root)
        {
            C2M_WelfareDraw2RewardRequest reques = new();
            M2C_WelfareDraw2RewardResponse response = (M2C_WelfareDraw2RewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(reques);
            return response;
        }
    }
}