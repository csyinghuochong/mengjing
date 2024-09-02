using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public  class C2M_JiaYuanStoreHandler : MessageLocationHandler<Unit, C2M_JiaYuanStoreRequest, M2C_JiaYuanStoreResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanStoreRequest request, M2C_JiaYuanStoreResponse response)
        {
            int hourseId = request.HorseId;
            if (hourseId >= (int)ItemLocType.ItemLocMax)
            {
                Log.Error($"C2M_JiaYuanStoreRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;    
                return;
            }
            int leftCell = unit.GetComponent<BagComponentS>().GetBagLeftCell(hourseId);
            if (leftCell<= 0)
            {
                response.Error = ErrorCode.ERR_BagIsFull;     //错误码:仓库已满
                return;
            }

            M2C_RoleBagUpdate m2c_bagUpdate = M2C_RoleBagUpdate.Create();

            List <ItemInfo> bagInfos = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag);

            List<ItemInfo> itemList = new List<ItemInfo>();
            
            // 家园种子仓库
            if (hourseId >= ItemLocType.JianYuanWareHouse1 && hourseId <= ItemLocType.JianYuanWareHouse4)
            {
                itemList = ItemHelper.GetSeedList(bagInfos);
            }
            // 家园藏宝图仓库_存藏宝图的
            else if (hourseId == ItemLocType.JianYuanTreasureMapStorage1)
            {
                itemList = ItemHelper.GetTreasureMapList(bagInfos);
            } 
            // 家园藏宝图仓库_存生活材料的
            else if (hourseId == ItemLocType.JianYuanTreasureMapStorage2)
            {
                itemList = ItemHelper.GetTreasureMapList2(bagInfos);
            }
            
            for (int i = 0; i < itemList.Count; i++)
            {
                unit.GetComponent<BagComponentS>().OnChangeItemLoc(itemList[i], hourseId, ItemLocType.ItemLocBag);
                m2c_bagUpdate.BagInfoUpdate.Add(itemList[i].ToMessage());
                leftCell--;
                if (leftCell <= 0)
                {
                    break;
                }
            }
            MapMessageHelper.SendToClient(unit, m2c_bagUpdate);
            await ETTask.CompletedTask;
        }
    }
}
