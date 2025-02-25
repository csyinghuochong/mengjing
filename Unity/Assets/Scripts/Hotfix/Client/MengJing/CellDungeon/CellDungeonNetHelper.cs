namespace ET.Client
{
    public static class CellDungeonNetHelper
    {
        public static async ETTask<int> RequestGetFubenReward(Scene root, RewardItem rewardItem)
        {
            Actor_GetFubenRewardRequest request = Actor_GetFubenRewardRequest.Create();
            request.RewardItem = rewardItem;
            Actor_GetFubenRewardReponse response = (Actor_GetFubenRewardReponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }
        
        public static async ETTask<M2C_DamageValueListResponse> RequestDamageValueList(Scene root)
        {
            C2M_DamageValueListRequest request = C2M_DamageValueListRequest.Create();
            M2C_DamageValueListResponse response = (M2C_DamageValueListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}