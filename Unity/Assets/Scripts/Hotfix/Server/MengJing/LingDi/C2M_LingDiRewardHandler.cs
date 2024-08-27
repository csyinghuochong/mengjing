namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_LingDiRewardHandler : MessageLocationHandler<Unit, C2M_LingDiRewardRequest, M2C_LingDiRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_LingDiRewardRequest request, M2C_LingDiRewardResponse response)
        {
            int lingdiLv = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Ling_DiLv);
            int rolelv = unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;

            LingDiRewardConfig config = LingDiRewardConfigCategory.Instance.Get(request.RewardId);

            if (lingdiLv < config.CountryLvlimit)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }
            if (unit.GetComponent<BagComponentS>().IsBagFullByLoc(ItemLocType.ItemLocBag))
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (!unit.GetComponent<BagComponentS>().OnCostItemData($"{config.BuyItemID};{config.BuyPrice}"))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            unit.GetComponent<BagComponentS>().OnAddItemData($"{config.ItemID};1", $"{ItemGetWay.LingDiReward}_{TimeHelper.ServerNow()}");
            await ETTask.CompletedTask;
        }
    }
}
