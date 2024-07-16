using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(BagComponentS))]
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_BagInitHandler: MessageLocationHandler<Unit, C2M_BagInitRequest, M2C_BagInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BagInitRequest request, M2C_BagInitResponse response)
        {
            Console.WriteLine($"C2M_BagInitHandler: server0");
            BagComponentS bagComponentS = unit.GetComponent<BagComponentS>();
            response.BagInfos = bagComponentS.GetAllItems();


            for (int i = bagComponentS.WarehouseAddedCell.Count; i < (int)ItemLocType.ItemLocMax; i++)
            {
                bagComponentS.WarehouseAddedCell.Add(0);
            }

            for (int i = bagComponentS.AdditionalCellNum.Count; i < (int)ItemLocType.ItemLocMax; i++)
            {
                bagComponentS.AdditionalCellNum.Add(0);
            }

            response.QiangHuaLevel .AddRange(bagComponentS.QiangHuaLevel); 
            response.QiangHuaFails .AddRange(bagComponentS.QiangHuaFails);
            response.WarehouseAddedCell .AddRange( bagComponentS.WarehouseAddedCell);
            response.FashionActiveIds .AddRange( bagComponentS.FashionActiveIds);
            response.FashionEquipList .AddRange( bagComponentS.FashionEquipList);
            response.AdditionalCellNum .AddRange( bagComponentS.AdditionalCellNum);
            response.SeasonJingHePlan = bagComponentS.SeasonJingHePlan;
            await ETTask.CompletedTask;
        }
    }
}