using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetBarSetHandler : MessageLocationHandler<Unit, C2M_PetBarSetRequest, M2C_PetBarSetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetBarSetRequest request, M2C_PetBarSetResponse response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();

            if (request.PetBarList == null || request.PetBarList.Count < 3)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            // 先切换回英雄
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetFightIndex, 0);
            unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, ConfigData.PlayerHideBuff);
            unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, ConfigData.PetMianShangBuff);

            // List<long> petids = petComponent.GetNowPetFightList().Select(x => x.PetId).ToList();
            TransferHelper.RemoveFightPetList(unit);
            petComponent.SetNowPetFightList(request.PetBarList); //通过布阵界面设置出战宠物
            TransferHelper.CreateFightPetList(unit);

            await ETTask.CompletedTask;
        }
    }
}