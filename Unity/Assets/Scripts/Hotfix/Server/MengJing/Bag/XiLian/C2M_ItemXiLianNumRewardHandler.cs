namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemXiLianNumRewardHandler: MessageLocationHandler<Unit, C2M_ItemXiLianNumReward, M2C_ItemXiLianNumReward>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemXiLianNumReward request, M2C_ItemXiLianNumReward response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponent.UserInfo.ItemXiLianNumRewardIds.Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            if (!ConfigData.ItemXiLianNumReward.Keys.Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.ItemXiLianNumber) < request.RewardId)
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }

            string[] reward = ConfigData.ItemXiLianNumReward[request.RewardId].Split('$');
            string[] items = reward[0].Split('@');
            string[] diamond = reward[1].Split(';')[1].Split(',');
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < items.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            userInfoComponent.UserInfo.ItemXiLianNumRewardIds.Add(request.RewardId);
            int randomZuanshi = RandomHelper.RandomNumber(int.Parse(diamond[0]), int.Parse(diamond[1]));
            unit.GetComponent<BagComponentS>().OnAddItemData(reward[0], $"{ItemGetWay.ItemXiLian}_{TimeHelper.ServerNow()}");
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.Diamond, randomZuanshi.ToString(), true, ItemGetWay.ItemXiLian);
            await ETTask.CompletedTask;
        }
    }
}