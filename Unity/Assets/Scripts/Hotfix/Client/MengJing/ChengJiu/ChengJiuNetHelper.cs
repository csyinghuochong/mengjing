namespace ET.Client
{
    public static class ChengJiuNetHelper
    {
        public static async ETTask ReceivedReward(Scene root, int rewardId)
        {
            C2M_ChengJiuRewardRequest request = C2M_ChengJiuRewardRequest.Create();
            request.RewardId = rewardId;

            M2C_ChengJiuRewardResponse r2C_Bag = (M2C_ChengJiuRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (r2C_Bag.Error != 0)
            {
                return;
            }

            root.GetComponent<ChengJiuComponentC>().AlreadReceivedId.Add(rewardId);
        }

        public static async ETTask GetChengJiuList(Scene root)
        {
            M2C_ChengJiuListResponse response =
                    (M2C_ChengJiuListResponse)await root.GetComponent<ClientSenderCompnent>().Call(C2M_ChengJiuListRequest.Create());
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            root.GetComponent<ChengJiuComponentC>().OnGetChengJiuList(response);

            EventSystem.Instance.Publish(root, new ChengJiuUpdate());
        }
    }
}