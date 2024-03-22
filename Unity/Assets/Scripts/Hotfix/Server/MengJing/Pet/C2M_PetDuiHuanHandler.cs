using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetDuiHuanHandler: MessageLocationHandler<Unit, C2M_PetDuiHuanRequest, M2C_PetDuiHuanResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetDuiHuanRequest request, M2C_PetDuiHuanResponse response)
        {
            PetComponent_S petComponent = unit.GetComponent<PetComponent_S>();
            int userLv = unit.GetComponent<UserInfoComponent_S>().GetUserLv();
            int petexpendNumber = unit.GetComponent<NumericComponent_S>().GetAsInt(NumericType.PetExtendNumber);
            if (PetHelper.GetBagPetNum(petComponent.GetAllPets()) >= PetHelper.GetPetMaxNumber( userLv, petexpendNumber))
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            
            int configId = request.OperateId;
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(configId);
            string[] configInfo = globalValueConfig.Value.Split('@');
            if(configInfo.Length < 2)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            BagComponent_S bagComponent = unit.GetComponent<BagComponent_S>();
            if (!bagComponent.OnCostItemData(configInfo[0]))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }
            response.RolePetInfo = petComponent.OnAddPet(ItemGetWay.PetEggDuiHuan, int.Parse(configInfo[1]));
            unit.GetComponent<DataCollationComponent>().OnPetDuiHuan();
            
            await ETTask.CompletedTask;
        }
    }
}

