namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetDuiHuanHandler: MessageLocationHandler<Unit, C2M_PetDuiHuanRequest, M2C_PetDuiHuanResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetDuiHuanRequest request, M2C_PetDuiHuanResponse response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            int userLv = unit.GetComponent<UserInfoComponentS>().GetUserLv();
            int petexpendNumber = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetExtendNumber);
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

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
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

