using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentS))]
    public class C2M_JingLingDropHandler : MessageLocationHandler<Unit, C2M_JingLingDropRequest, M2C_JingLingDropResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingLingDropRequest request, M2C_JingLingDropResponse response)
        {
            ChengJiuComponentS chengJiuComponent = unit.GetComponent<ChengJiuComponentS>();
            JingLingInfo jingLingInfo = chengJiuComponent.GetFightJingLing();
            if (jingLingInfo == null || chengJiuComponent.RandomDrop == 1)
            {
                return;
            }
            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jingLingInfo.JingLingID);
            if (jingLingConfig.FunctionType!= JingLingFunctionType.RandomDrop)
            {
                return;
            }
            int dropId = int.Parse(jingLingConfig.FunctionValue);
            if (dropId == 0)
            {
                Log.Warning($"C2M_JingLingDropRequest.dropId == 0");
            }
            List<RewardItem> droplist = new List<RewardItem>();
            DropHelper.DropIDToDropItem_2(dropId, droplist);
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < droplist.Count)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            unit.GetComponent<BagComponentS>().OnAddItemData(droplist, string.Empty, $"{ItemGetWay.JingLing}_{TimeHelper.ServerNow()}", false);
            chengJiuComponent.RandomDrop = 1;
            await ETTask.CompletedTask;
        }
    }
}
