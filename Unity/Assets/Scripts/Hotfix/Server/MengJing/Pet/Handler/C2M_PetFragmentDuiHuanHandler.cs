namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFragmentDuiHuanHandler: MessageLocationHandler<Unit, C2M_PetFragmentDuiHuan, M2C_PetFragmentDuiHuan>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFragmentDuiHuan request, M2C_PetFragmentDuiHuan response)
        {

            if (!PetHelper.IsShenShouFull(unit.GetComponent<PetComponentS>().RolePetInfos))
            {
                Log.Error($"C2M_PetFragmentDuiHuan 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (unit.GetComponent<BagComponentS>().GetItemNumber(10000136) < 1)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError ;
                return;
            }

            unit.GetComponent<BagComponentS>().OnCostItemData("10000136;1", ItemLocType.ItemLocBag);
            unit.GetComponent<BagComponentS>().OnAddItemData($"10000165;1", $"{ItemGetWay.DuiHuan}_{TimeHelper.ServerNow()}");
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            await ETTask.CompletedTask;
        }
    }
}

