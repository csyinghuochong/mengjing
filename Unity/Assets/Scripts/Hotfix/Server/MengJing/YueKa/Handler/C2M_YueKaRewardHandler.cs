namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_YueKaRewardHandler : MessageLocationHandler<Unit, C2M_YueKaRewardRequest, M2C_YueKaRewardResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_YueKaRewardRequest request, M2C_YueKaRewardResponse response)
        {
            if (!unit.IsYueKaStates())
            {
                return;
            }
            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.YueKaAward) == 1)
            {
                return;
            }
            string reward = GlobalValueConfigCategory.Instance.Get(28).Value;
            int itemNumber = reward.Split('@').Length;
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < itemNumber)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            int remainTimes = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.YueKaRemainTimes);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.YueKaAward, 1);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.YueKaRemainTimes, remainTimes -1);
          
            unit.GetComponent<BagComponentS>().OnAddItemData(reward, $"{ItemGetWay.YueKaReward}_{TimeHelper.ServerNow()}");
            await ETTask.CompletedTask;
        }
    }
}
