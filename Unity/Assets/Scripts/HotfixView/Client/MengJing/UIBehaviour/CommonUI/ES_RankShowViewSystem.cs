using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RankShow))]
    [FriendOfAttribute(typeof (ES_RankShow))]
    public static partial class ES_RankShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankShow self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_RankShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.E_HeadIcomImage1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "1"));
            self.E_HeadIcomImage2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "2"));
            self.E_HeadIcomImage3Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "3"));

            self.OnUpdateUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_RankShow self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_RankShow self, int index)
        {
            UICommonHelper.SetToggleShow(self.E_TypeWarriorToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.E_TypeMagicianToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.E_TypeHunterToggle.gameObject, index == 2);

            self.CurrentItemType = index;
            self.OnUpdateUI(index + 1).Coroutine();
        }

        private static void OnRankShowItemsRefresh(this ES_RankShow self, Transform transform, int index)
        {
            Scroll_Item_RankShowItem scrollItemRankShowItem = self.ScrollItemRankShowItems[index].BindTrans(transform);
            scrollItemRankShowItem.Refresh(index + 1, self.ShowRankingInfos[index]);
        }

        private static async ETTask OnUpdateUI(this ES_RankShow self, int type = 0)
        {
            long instanceid = self.InstanceId;
            // C2R_RankListRequest request = new();
            // R2C_RankListResponse response = (R2C_RankListResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            // 测试数据
            R2C_RankListResponse response = new();
            response.RankList.Add(new RankingInfo() { Combat = 1000, Occ = 1, PlayerName = "排行榜测试角色1", PlayerLv = 10 });
            response.RankList.Add(new RankingInfo() { Combat = 2000, Occ = 2, PlayerName = "排行榜测试角色2", PlayerLv = 20 });
            response.RankList.Add(new RankingInfo() { Combat = 3000, Occ = 3, PlayerName = "排行榜测试角色3", PlayerLv = 30 });
            response.RankList.Add(new RankingInfo() { Combat = 4000, Occ = 1, PlayerName = "排行榜测试角色4", PlayerLv = 40 });
            response.RankList.Add(new RankingInfo() { Combat = 5000, Occ = 2, PlayerName = "排行榜测试角色5", PlayerLv = 50 });

            if (instanceid != self.InstanceId)
            {
                return;
            }

            long selfId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            int myRank = -1;
            int rank = 1;
            self.ShowRankingInfos.Clear();

            for (int i = 0; i < response.RankList.Count; i++)
            {
                if (type != 0 && response.RankList[i].Occ != type)
                {
                    continue;
                }

                self.ShowRankingInfos.Add(response.RankList[i]);

                if (selfId == response.RankList[i].UserId)
                {
                    myRank = rank;
                }

                rank++;
            }

            self.E_Text_MyRankText.text = myRank == -1? "我的排名: 未上榜" : $"我的排名: {myRank}";

            self.AddUIScrollItems(ref self.ScrollItemRankShowItems, self.ShowRankingInfos.Count);
            self.E_RankShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankingInfos.Count);

            await ETTask.CompletedTask;
        }
    }
}