using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemQuickPutHandler: MessageLocationHandler<Unit, C2M_ItemQuickPutRequest, M2C_ItemQuickPutResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemQuickPutRequest request, M2C_ItemQuickPutResponse response)
        {
            int hourseId = request.HorseId;
            if (hourseId < (int)ItemLocType.ItemWareHouse1 || hourseId > (int)ItemLocType.ItemWareHouse4)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();

            List<ItemInfo> warehourselist = bagComponent.GetItemByLoc(hourseId);

            List<ItemInfo> bagList = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag);

            for (int w = 0; w < warehourselist.Count; w++)
            {
                ItemInfo warehourseInfo = warehourselist[w];

                for (int b = bagList.Count - 1; b >= 0; b--)
                {
                    ItemInfo bagInfo = bagList[b];

                    if (warehourseInfo.ItemID != bagInfo.ItemID)
                    {
                        continue;
                    }

                    ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                    if ((warehourseInfo.ItemNum + bagInfo.ItemNum) > itemCof.ItemPileSum)
                    {
                        continue;
                    }

                    warehourseInfo.ItemNum = warehourseInfo.ItemNum + bagInfo.ItemNum;
                    m2c_bagUpdate.BagInfoUpdate.Add(warehourseInfo.ToMessage());
                    m2c_bagUpdate.BagInfoDelete.Add(bagInfo.ToMessage());
                    bagList.RemoveAt(b);
                }
            }

            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);

            await ETTask.CompletedTask;
        }
    }
}