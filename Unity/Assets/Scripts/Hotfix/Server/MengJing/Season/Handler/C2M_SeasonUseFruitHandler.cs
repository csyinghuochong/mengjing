using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SeasonUseFruitHandler : MessageLocationHandler<Unit, C2M_SeasonUseFruitRequest, M2C_SeasonUseFruitResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_SeasonUseFruitRequest request, M2C_SeasonUseFruitResponse response)
        {
            long reduceTime = 0;
            List<long> huishouList = request.BagInfoIDs;
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();

            if (request.BagInfoIDs.Count <= 0)
            {
                Log.Error($"C2M_SeasonUseFruitRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
            }
            
           
            ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, huishouList[0]);
            if (bagInfo == null)
            {
                response.Error = ErrorCode.ERR_Parameter;
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemType != ItemTypeEnum.Consume || itemConfig.ItemSubType != 132)
            {
                Log.Error($"C2M_SeasonUseFruitRequest 3");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            reduceTime += long.Parse(itemConfig.ItemUsePar);

            bagComponent.OnCostItemData(request.BagInfoIDs[0], 1);
            unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.SeasonBossRefreshTime, -1 * reduceTime);
            await ETTask.CompletedTask;
        }
    }
}
