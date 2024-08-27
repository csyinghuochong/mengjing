namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetHeXinExploreRewardHandler: MessageLocationHandler<Unit, C2M_PetHeXinExploreReward, M2C_PetHeXinExploreReward>
    {
        protected override async ETTask Run(Unit unit, C2M_PetHeXinExploreReward request, M2C_PetHeXinExploreReward response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponent.UserInfo.PetHeXinExploreRewardIds.Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            if (!ConfigData.PetHeXinExploreReward.Keys.Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetHeXinExploreNumber) < request.RewardId)
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }

            string[] reward = ConfigData.PetHeXinExploreReward[request.RewardId].Split('$');
            string[] items = reward[0].Split('@');
            string[] diamond = reward[1].Split(';')[1].Split(',');
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < items.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            userInfoComponent.UserInfo.PetHeXinExploreRewardIds.Add(request.RewardId);
            int randomZuanshi = RandomHelper.RandomNumber(int.Parse(diamond[0]), int.Parse(diamond[1]));
            unit.GetComponent<BagComponentS>().OnAddItemData(reward[0], $"{ItemGetWay.PetChouKa}_{TimeHelper.ServerNow()}");
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.Diamond, randomZuanshi.ToString(), true, ItemGetWay.PetChouKa);
            
            await ETTask.CompletedTask;
        }
    }
}