using System;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_BagInitHandler: MessageLocationHandler<Unit, C2M_BagInitRequest, M2C_BagInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_BagInitRequest request, M2C_BagInitResponse response)
        {
            Log.Debug($"C2M_BagInitHandler: server0");
            BagComponentServer bagComponentServer = unit.GetComponent<BagComponentServer>();
            response.BagInfos = bagComponentServer.GetAllItems();

            // 测试。。
            for (int i = 0; i <= 11; i++)
            {
                bagComponentServer.QiangHuaLevel.Add(0);
                bagComponentServer.QiangHuaFails.Add(0);
            }

            response.QiangHuaLevel = bagComponentServer.QiangHuaLevel;
            response.QiangHuaFails = bagComponentServer.QiangHuaFails;
            //response.BagAddedCell = bagComponent.BagAddedCell;
            response.WarehouseAddedCell = bagComponentServer.WarehouseAddedCell;
            response.FashionActiveIds = bagComponentServer.FashionActiveIds;
            response.FashionEquipList = bagComponentServer.FashionEquipList;
            response.SeasonJingHePlan = bagComponentServer.SeasonJingHePlan;
            response.AdditionalCellNum = bagComponentServer.AdditionalCellNum;
            await ETTask.CompletedTask;
        }
    }
}