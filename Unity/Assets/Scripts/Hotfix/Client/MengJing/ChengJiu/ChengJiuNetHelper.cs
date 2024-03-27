namespace ET.Client
{
    
    public static class ChengJiuNetHelper
    {
    
        public static async ETTask ReceivedReward(Scene root, int rewardId)
        {
            M2C_ChengJiuRewardResponse r2C_Bag = (M2C_ChengJiuRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_ChengJiuRewardRequest() {  RewardId = rewardId });
            if (r2C_Bag.Error != 0)
            {
                return;
            }

            root.GetComponent<ChengJiuComponentC>().AlreadReceivedId.Add(rewardId);
        }
        
        
        public static async ETTask GetChengJiuList(Scene root)
        {
            M2C_ChengJiuListResponse r2C_Respose = (M2C_ChengJiuListResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_ChengJiuListRequest());
            if (r2C_Respose.Error != ErrorCode.ERR_Success)
            {
                return;
            }
            root.GetComponent<ChengJiuComponentC>().OnGetChengJiuList(r2C_Respose);
            //HintHelp.GetInstance().DataUpdate(DataType.ChengJiuUpdate);
        }
        
        
    }
}