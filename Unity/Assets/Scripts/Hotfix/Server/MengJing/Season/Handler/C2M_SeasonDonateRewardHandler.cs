namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SeasonDonateRewardHandler : MessageLocationHandler<Unit, C2M_SeasonDonateRewardRequest, M2C_SeasonDonateRewardResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_SeasonDonateRewardRequest request, M2C_SeasonDonateRewardResponse response)
        {
            NumericComponentS numericComponentS = unit.GetComponent<NumericComponentS>();
            int donatetime =  numericComponentS.GetAsInt(NumericType.CommonSeasonDonateTimes);

            if (!ConfigData.CommonSeasonDonateReward.ContainsKey(request.Times))
            {
                return;
            }

            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            if(userInfoComponentS.UserInfo.SeasonDonateRewardIds.Contains(request.Times))
            {
                return;
            }

            string[] rewards = ConfigData.CommonSeasonDonateReward[request.Times].Split('@');
            BagComponentS bagComponentS = unit.GetComponent<BagComponentS>();

            if (bagComponentS.GetBagLeftCell(ItemLocType.ItemLocBag) < rewards.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            
            if  ( !bagComponentS.OnAddItemData( ConfigData.CommonSeasonDonateReward[request.Times],  $"{ItemGetWay.Season}_{TimeHelper.ServerNow()}") )
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            userInfoComponentS.UserInfo.SeasonDonateRewardIds.Add(request.Times);
            response.SeasonDonateRewardIds .AddRange(userInfoComponentS.UserInfo.SeasonDonateRewardIds);
            await ETTask.CompletedTask;
        }
    }
}
