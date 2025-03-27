using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetZhuangJiaUpHandler : MessageLocationHandler<Unit, C2M_PetZhuangJiaUpRequest, M2C_PetZhuangJiaUpResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetZhuangJiaUpRequest request, M2C_PetZhuangJiaUpResponse response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            if (request.Position < 0 || request.Position >= petComponent.PetZhuangJiaList.Count)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            int id = petComponent.PetZhuangJiaList[request.Position];
            PetZhuangJiaConfig petZhuangJiaConfig = PetZhuangJiaConfigCategory.Instance.Get(id);
            if (petZhuangJiaConfig.NextID == 0)
            {
                response.Error = ErrorCode.ERR_LevelMax;
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (!bagComponent.CheckCostItem(petZhuangJiaConfig.CostItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            bagComponent.OnCostItemData(petZhuangJiaConfig.CostItem);
            petComponent.PetZhuangJiaList[request.Position] = petZhuangJiaConfig.NextID;

            //刷新属性
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            for (int i = petComponent.RolePetInfos.Count - 1; i >= 0; i--)
            {
                petComponent.UpdatePetAttribute(petComponent.RolePetInfos[i], false);
            }

            await ETTask.CompletedTask;
        }
    }
}