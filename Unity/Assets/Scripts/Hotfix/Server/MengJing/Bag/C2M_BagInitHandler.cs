using System;

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

            // 测试。。
            if (bagComponentS.QiangHuaLevel.Count == 0)
            {
                for (int i = 0; i <= 11; i++)
                {
                    bagComponentS.QiangHuaLevel.Add(0);
                    bagComponentS.QiangHuaFails.Add(0);
                }
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