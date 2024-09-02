using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemTreasureOpenHandler: MessageLocationHandler<Unit, C2M_ItemTreasureOpenRequest, M2C_ItemTreasureOpenResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemTreasureOpenRequest request, M2C_ItemTreasureOpenResponse response)
        {
            ItemInfo useBagInfo = unit.GetComponent<BagComponentS>().GetItemByLoc(ItemLocType.ItemLocBag, request.OperateBagID);
            if (useBagInfo == null)
            {
                response.Error = ErrorCode.ERR_ItemUseError;
                return;
            }

            if (useBagInfo.HideProLists.Count > 0)
            {
                response.ReardItem = new RewardItem() { ItemID = useBagInfo.HideProLists[0].HideID, ItemNum = (int)useBagInfo.HideProLists[0].HideValue };
                return;
            }

            //40006@TaskMove_6@10010071;1
            string rewardItemStr = useBagInfo.ItemPar.Split('@')[2];
            List<RewardItem> rewardItems = ItemHelper.GetRewardItems(rewardItemStr);

            response.ReardItem = rewardItems[0];
            useBagInfo.HideProLists.Clear();
            useBagInfo.HideProLists.Add(new HideProList() { HideID = rewardItems[0].ItemID, HideValue = rewardItems[0].ItemNum });
            await ETTask.CompletedTask;
        }
    }
}