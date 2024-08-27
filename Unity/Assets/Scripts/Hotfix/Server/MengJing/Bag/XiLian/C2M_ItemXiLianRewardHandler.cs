namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemXiLianRewardHandler : MessageLocationHandler<Unit, C2M_ItemXiLianRewardRequest, M2C_ItemXiLianRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemXiLianRewardRequest request, M2C_ItemXiLianRewardResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();

            if (userInfoComponent.UserInfo.XiuLianRewardIds.Contains(request.XiLianId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            EquipXiLianConfig equipXiLianConfig = EquipXiLianConfigCategory.Instance.Get(request.XiLianId);
            string[] rewarditems = equipXiLianConfig.RewardList.Split('@');
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < rewarditems.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            userInfoComponent.UserInfo.XiuLianRewardIds.Add(request.XiLianId);
            unit.GetComponent<BagComponentS>().OnAddItemData(equipXiLianConfig.RewardList, $"{ItemGetWay.XiLianLevel}_{TimeHelper.ServerNow()}");
            await ETTask.CompletedTask;
        }
    }
}
