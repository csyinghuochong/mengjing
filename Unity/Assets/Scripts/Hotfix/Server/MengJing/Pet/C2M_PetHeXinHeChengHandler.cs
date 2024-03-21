using System;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetHeXinHeChengHandler : MessageLocationHandler<Unit, C2M_PetHeXinHeChengRequest, M2C_PetHeXinHeChengResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_PetHeXinHeChengRequest request, M2C_PetHeXinHeChengResponse response)
        {
            BagInfo bagInfo_1 = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemPetHeXinBag, request.BagInfoID_1);
            BagInfo bagInfo_2 = unit.GetComponent<BagComponentServer>().GetItemByLoc(ItemLocType.ItemPetHeXinBag, request.BagInfoID_2);
            if (bagInfo_1 == null || bagInfo_2 == null)
            {
                return;
            }
            if (bagInfo_1.ItemID != bagInfo_2.ItemID)
            {
                return;
            }
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo_1.ItemID);
            if (itemConfig.PetHeXinHeChengID==0)
            {
                return;
            }

            using ListComponent<long> costids = new ListComponent<long>() { bagInfo_1.BagInfoID,bagInfo_2.BagInfoID };
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            bagComponent.OnCostItemData(costids, ItemLocType.ItemPetHeXinBag);
            bagComponent.OnAddItemData($"{itemConfig.PetHeXinHeChengID};1", $"{ItemGetWay.PetHeXinHeCheng}_{TimeHelper.ServerNow()}");

            await ETTask.CompletedTask;
        }

    }
}
