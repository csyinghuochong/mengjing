using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ActivityChouKaHandler : MessageLocationHandler<Unit, C2M_ActivityChouKaRequest, M2C_ActivityChouKaResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ActivityChouKaRequest request, M2C_ActivityChouKaResponse response)
        {
            Log.Error($"C2M_ActivityChouKaRequest活动作弊:{unit.Zone()}  {unit.Id}");
            if (unit.Zone()!=0)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            if (!bagComponent.CheckCostItem(ConfigData.ChouKaCostItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            unit.GetComponent<NumericComponentS>().ApplyChange( NumericType.V1ChouKaNumber, 1);

            int dropId = ConfigData.ChouKaDropId[0];
            dropId = ConfigData.ServerInfoList[unit.Zone()].ChouKaDropId;

            List<RewardItem> rewardItems = new List<RewardItem>();  
            DropHelper.DropIDToDropItem_2(dropId, rewardItems);
            bagComponent.OnCostItemData(ConfigData.ChouKaCostItem);
            bagComponent.OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.ActivityChouKa}_{TimeHelper.ServerNow()}");

            await ETTask.CompletedTask;
        }
    }
}
