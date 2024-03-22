using System;


namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetOpenCangKuHandler : MessageLocationHandler<Unit, C2M_PetOpenCangKu, M2C_PetOpenCangKu>
    {
        protected override async ETTask Run(Unit unit, C2M_PetOpenCangKu request, M2C_PetOpenCangKu response)
        {
            string costitem = ConfigData.PetOpenCangKu[request.OpenIndex - 1];
            if (!unit.GetComponent<BagComponent_S>().CheckCostItem(costitem))
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }
            if (unit.GetComponent<PetComponent_S>().PetCangKuOpen.Contains(request.OpenIndex - 1)) 
            {
                response.Error = ErrorCode.ERR_CangKu_Already;
                return;
            }

            unit.GetComponent<PetComponent_S>().PetCangKuOpen.Add(request.OpenIndex - 1);
            unit.GetComponent<BagComponent_S>().OnCostItemData(costitem);

            await ETTask.CompletedTask;
        }
    }
}
