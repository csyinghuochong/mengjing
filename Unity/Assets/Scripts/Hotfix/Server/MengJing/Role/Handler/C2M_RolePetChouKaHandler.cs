using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_RolePetChouKaHandler : MessageLocationHandler<Unit, C2M_RolePetChouKaRequest, M2C_RolePetChouKaResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_RolePetChouKaRequest request, M2C_RolePetChouKaResponse response)
        {
            if (request.ChouKaType == 1)
            {
                string needItems = GlobalValueConfigCategory.Instance.Get(16).Value;
                bool  sucess = unit.GetComponent<BagComponentS>().OnCostItemData(needItems);
                if (!sucess)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
            }
            else if(request.ChouKaType == 2)
            {
                /*
                int choukaTim = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.PetChouKa);
                if (choukaTim >= 20)
                {
                    reply();
                    return;
                }
                */
                UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
                int needDimanond = GlobalValueConfigCategory.Instance.RolePetChouKa_2;
                if (userInfo.Diamond < needDimanond)
                {
                    response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                    return;
                }
                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, (-1 * needDimanond).ToString(), true,ItemGetWay.PetChouKa);
                unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.PetChouKa, 1);
                unit.GetComponent<DataCollationComponent>().OnPetChouKa(1);
            }

            List<int> petList = new List<int>() { 310102, 310103, 310104 };

            float rand = RandomHelper.RandFloat();
            bool randStatus = false;
            if (rand <= 0.55 && !randStatus)
            {
                petList = new List<int>() { 310102, 310103, 310104 };
                randStatus = true;
            }
            if (rand <= 0.8 && !randStatus)
            {
                petList = new List<int>() { 310102, 310103, 310104 };
                randStatus = true;
            }
            if (rand <= 0.94 && !randStatus)
            {
                petList = new List<int>() { 310102, 310103, 310104 };
                randStatus = true;
            }
            if (rand <= 0.99 && !randStatus)
            {
                petList = new List<int>() { 310102, 310103, 310104};
                randStatus = true;
            }
            if (rand <= 1 && !randStatus)
            {
                petList = new List<int>() { 310102, 310103, 310104};
                randStatus = true;
            }

            int petId = petList[RandomHelper.RandomNumber(0, petList.Count)];
            PetConfig petConfig = PetConfigCategory.Instance.Get(petId);
            List<int> weight = new List<int>(petConfig.SkinPro);
            int index = RandomHelper.RandomByWeight(weight);
            int skinId = petConfig.Skin[index];
            response.RolePetInfo = unit.GetComponent<PetComponentS>().OnAddPet(ItemGetWay.PetExplore, petId, skinId);
            await ETTask.CompletedTask;
        }
    }
}
