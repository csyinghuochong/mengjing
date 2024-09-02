using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_ShouJiTreasureHandler : MessageLocationHandler<Unit, C2M_ShouJiTreasureRequest, M2C_ShouJiTreasureResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ShouJiTreasureRequest request, M2C_ShouJiTreasureResponse response)
        {
            ShoujiComponentS shoujiComponent = unit.GetComponent<ShoujiComponentS>();
            KeyValuePairInt keyValuePairInt = shoujiComponent.GetTreasureInfo(request.ShouJiId);
            ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(request.ShouJiId);
            if (keyValuePairInt != null && keyValuePairInt.Value > shouJiItemConfig.AcitveNum)
            {
                response.Error = ErrorCode.ERR_ShouJIActived;
                return;
            }

            List<long> huishouList = request.ItemIds;
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            for (int i = 0; i < huishouList.Count; i++)
            {
                ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, huishouList[i]);
                if (bagInfo == null)
                {
                    response.Error = ErrorCode.ERR_ItemUseError;
                    return;
                }
            }

            int curNumber   = keyValuePairInt!=null ? (int)keyValuePairInt.Value : 0;  
            int needNumber  = shouJiItemConfig.AcitveNum - curNumber;
            
            for (int i = 0; i < huishouList.Count; i++)
            {
                ItemInfo bagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, huishouList[i]);
                if (bagInfo == null)
                {
                    continue;
                }

                if (needNumber < bagInfo.ItemNum)
                {
                    curNumber += needNumber;
                    bagComponent.OnCostItemData(huishouList[i], needNumber);
                }
                else
                {
                    needNumber -= bagInfo.ItemNum;
                    curNumber += bagInfo.ItemNum;
                    bagComponent.OnCostItemData(huishouList[i], bagInfo.ItemNum);
                }

                if (curNumber >= needNumber)
                {
                    break;
                }
            }
           
            shoujiComponent.OnShouJiTreasure(request.ShouJiId, curNumber);
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            response.ActiveNum = curNumber;
            await ETTask.CompletedTask;
        }
    }
}
