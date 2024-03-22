
using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentServer))]
    public class C2M_JingLingDropHandler : MessageLocationHandler<Unit, C2M_JingLingDropRequest, M2C_JingLingDropResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingLingDropRequest request, M2C_JingLingDropResponse response)
        {
            await ETTask.CompletedTask;
            ChengJiuComponentServer chengJiuComponent = unit.GetComponent<ChengJiuComponentServer>();
            int jinglingid = chengJiuComponent.JingLingId;
            if (jinglingid == 0 || chengJiuComponent.RandomDrop == 1)
            {
                return;
            }
            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jinglingid);
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
            if (unit.GetComponent<BagComponentServer>().GetBagLeftCell() < droplist.Count)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            unit.GetComponent<BagComponentServer>().OnAddItemData(droplist, string.Empty, $"{ItemGetWay.JingLing}_{TimeHelper.ServerNow()}", false);
            chengJiuComponent.RandomDrop = 1;
        }
    }
}
