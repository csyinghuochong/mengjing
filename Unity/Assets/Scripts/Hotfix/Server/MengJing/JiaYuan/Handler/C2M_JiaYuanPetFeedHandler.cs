using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPetFeedHandler : MessageLocationHandler<Unit, C2M_JiaYuanPetFeedRequest, M2C_JiaYuanPetFeedResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPetFeedRequest request, M2C_JiaYuanPetFeedResponse response)
        {
            if (request.BagInfoIDs.Count < 1)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            List<int> ItemIdList = new List<int> ();
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            for (int i = request.BagInfoIDs.Count - 1; i >= 0; i--)
            {
                ItemInfo useBagInfo = bagComponent.GetItemByLoc(ItemLocType.ItemLocBag, request.BagInfoIDs[i]);
                if (useBagInfo == null)
                {
                    request.BagInfoIDs.RemoveAt(i);
                    continue;
                }
                ItemIdList.Add(useBagInfo.ItemID);
            }

            if (ItemIdList.Count == 0)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            //计算心情值
            int moodvalue = 0;
            for (int i = 0; i < ItemIdList.Count; i++)
            {
                ItemConfig nowItemCof = ItemConfigCategory.Instance.Get(ItemIdList[i]);
                if (nowItemCof.ItemType == 2)
                {
                    moodvalue += RandomHelper.RandomNumber(2,12);
                }

                if (nowItemCof.ItemType == 1 && nowItemCof.ItemQuality > 1)
                {
                    moodvalue += RandomHelper.RandomNumber(10, 25);
                }

                if (nowItemCof.ItemType == 1 && nowItemCof.ItemQuality == 1)
                {
                    moodvalue += RandomHelper.RandomNumber(5, 15);
                }
            }
            unit.GetComponent<JiaYuanComponentS>().UpdatePetMood(request.PetId, moodvalue);

            //消耗道具
            for (int i = request.BagInfoIDs.Count - 1; i >= 0; i--)
            {
                bagComponent.OnCostItemData(request.BagInfoIDs[i], 1);
            }
            response.MoodAdd = moodvalue;
            response.JiaYuanPetList .AddRange( unit.GetComponent<JiaYuanComponentS>().JiaYuanPetList_2);
            await ETTask.CompletedTask;
        }
    }
}
