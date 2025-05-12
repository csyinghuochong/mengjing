using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetChouKaStartHandler: MessageLocationHandler<Unit, C2M_PetChouKaStartRequest, M2C_PetChouKaStartResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetChouKaStartRequest request, M2C_PetChouKaStartResponse response)
        {
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt(NumericType.PetChouKaRewardItemId) == 0)
            {
                if (!unit.GetComponent<BagComponentS>().OnCostItemData(GlobalValueConfigCategory.Instance.Get(137).Value))
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }

                List<RewardItem> droplist = new List<RewardItem>();
                DropHelper.DropIDToDropItem_2(GlobalValueConfigCategory.Instance.PetChouKaDropId, droplist);
                numericComponent.ApplyValue(NumericType.PetChouKaRewardItemId, droplist[0].ItemID);
                numericComponent.ApplyValue(NumericType.PetChouKaRewardItemNum, droplist[0].ItemNum);
            }

            await ETTask.CompletedTask;
        }
    }
}