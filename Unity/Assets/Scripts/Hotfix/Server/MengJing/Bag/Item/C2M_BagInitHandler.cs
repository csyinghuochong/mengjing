using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_BagInitHandler: MessageLocationHandler<Unit, C2M_BagInitRequest, M2C_BagInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BagInitRequest request, M2C_BagInitResponse response)
        {
            Log.Debug($"C2M_BagInitHandler: server0");
            BagComponentS bagComponentS = unit.GetComponent<BagComponentS>();
            response.BagInfos = bagComponentS.GetAllItems();

          
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.CangKuNumber) == 0)
            {
                numericComponent.Set(NumericType.CangKuNumber, 1);
            }
            if (numericComponent.GetAsInt(NumericType.RechargeNumber) == 0)
            {
                numericComponent.Set(NumericType.RechargeNumber, 648);
            }

            for (int i = bagComponentS.WarehouseAddedCell.Count; i < (int)ItemLocType.ItemLocMax; i++)
            {
                bagComponentS.WarehouseAddedCell.Add(0);
            }

            for (int i = bagComponentS.AdditionalCellNum.Count; i < (int)ItemLocType.ItemLocMax; i++)
            {
                bagComponentS.AdditionalCellNum.Add(0);
            }

            response.QiangHuaLevel = bagComponentS.QiangHuaLevel;
            response.QiangHuaFails = bagComponentS.QiangHuaFails;
            //response.BagAddedCell = bagComponent.BagAddedCell;
            response.WarehouseAddedCell = bagComponentS.WarehouseAddedCell;
            response.FashionActiveIds = bagComponentS.FashionActiveIds;
            response.FashionEquipList = bagComponentS.FashionEquipList;
            response.SeasonJingHePlan = bagComponentS.SeasonJingHePlan;
            response.AdditionalCellNum = bagComponentS.AdditionalCellNum;
            await ETTask.CompletedTask;
        }
    }
}