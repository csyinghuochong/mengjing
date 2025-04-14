using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankShowItem))]
    [FriendOf(typeof(ES_RankReward))]
    [EntitySystemOf(typeof(ES_RankShow))]
    [FriendOfAttribute(typeof(ES_RankShow))]
    public static partial class ES_RankShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankShow self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_RankShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);
            self.E_RankRewardButton.AddListener(() => {self.ES_RankReward.uiTransform.gameObject.SetActive(true);});

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.E_HeadIcomImage1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "1"));
            self.E_HeadIcomImage2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "2"));
            self.E_HeadIcomImage3Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "3"));

            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<GameObject>("Assets/Bundles/UI/Item/Item_RankShowItem");
            GameObject gameObject = UnityEngine.Object.Instantiate(prefab, self.EG_MyRankShowRectTransform);
            self.MyRankShowItem = self.AddChild<Scroll_Item_RankShowItem>();
            self.MyRankShowItem.BindTrans(gameObject.transform);
            self.EG_MyRankShowRectTransform.gameObject.SetActive(false);
            self.ES_RankReward.uiTransform.gameObject.SetActive(false);

            self.OnUpdateUI().Coroutine();
        }

        public static void OnShowWindow(this ES_RankShow self)
        {
            self.ES_RankReward.uiTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_RankShow self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_RankShow self, int index)
        {
            self.CurrentItemType = index;
            self.OnUpdateUI(index + 1).Coroutine();
        }

        private static void OnRankShowItemsRefresh(this ES_RankShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_RankShowItem item in self.ScrollItemRankShowItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RankShowItem scrollItemRankShowItem = self.ScrollItemRankShowItems[index].BindTrans(transform);
            scrollItemRankShowItem.Refresh(index + 1, self.ShowRankingInfos[index]);
        }

        private static async ETTask OnUpdateUI(this ES_RankShow self, int type = 0)
        {
            self.EG_Rank_1RectTransform.gameObject.SetActive(false);
            self.EG_Rank_2RectTransform.gameObject.SetActive(false);
            self.EG_Rank_3RectTransform.gameObject.SetActive(false);

            long instanceid = self.InstanceId;

            R2C_RankListResponse response = await RankNetHelper.RankList(self.Root());
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

                if (rank == 1)
                {
                    self.EG_Rank_1RectTransform.gameObject.SetActive(true);
                    self.EG_Rank_1RectTransform.Find("CombatTxt").GetComponent<Text>().text = response.RankList[i].Combat.ToString();
                    self.ES_ModelShow_1.SetCameraPosition(new Vector3(0f, 60f, 150f));
                    self.ES_ModelShow_1.ShowPlayerModel(new ItemInfo(), response.RankList[i].Occ, 0, new List<int>(), false);
                    self.EG_Rank_1RectTransform.Find("NameTxt").GetComponent<Text>().text = response.RankList[i].PlayerName;
                    using (zstring.Block())
                    {
                        self.EG_Rank_1RectTransform.Find("LvTxt").GetComponent<Text>().text = zstring.Format("等级:{0}", response.RankList[i].PlayerLv);
                    }
                }

                if (rank == 2)
                {
                    self.EG_Rank_2RectTransform.gameObject.SetActive(true);
                    self.EG_Rank_2RectTransform.Find("CombatTxt").GetComponent<Text>().text = response.RankList[i].Combat.ToString();
                    self.ES_ModelShow_2.SetCameraPosition(new Vector3(0f, 60f, 150f));
                    self.ES_ModelShow_2.ShowPlayerModel(new ItemInfo(), response.RankList[i].Occ, 0, new List<int>(), false);
                    self.EG_Rank_2RectTransform.Find("NameTxt").GetComponent<Text>().text = response.RankList[i].PlayerName;
                    using (zstring.Block())
                    {
                        self.EG_Rank_2RectTransform.Find("LvTxt").GetComponent<Text>().text = zstring.Format("等级:{0}", response.RankList[i].PlayerLv);
                    }
                }

                if (rank == 3)
                {
                    self.EG_Rank_3RectTransform.gameObject.SetActive(true);
                    self.EG_Rank_3RectTransform.Find("CombatTxt").GetComponent<Text>().text = response.RankList[i].Combat.ToString();
                    self.ES_ModelShow_3.SetCameraPosition(new Vector3(0f, 60f, 150f));
                    self.ES_ModelShow_3.ShowPlayerModel(new ItemInfo(), response.RankList[i].Occ, 0, new List<int>(), false);
                    self.EG_Rank_3RectTransform.Find("NameTxt").GetComponent<Text>().text = response.RankList[i].PlayerName;
                    using (zstring.Block())
                    {
                        self.EG_Rank_3RectTransform.Find("LvTxt").GetComponent<Text>().text = zstring.Format("等级:{0}", response.RankList[i].PlayerLv);
                    }
                }

                rank++;
            }

            if (myRank != -1)
            {
                self.MyRankShowItem.Refresh(myRank, response.RankList.Find(r => r.UserId == selfId));
                self.EG_MyRankShowRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.EG_MyRankShowRectTransform.gameObject.SetActive(false);
            }
            // using (zstring.Block())
            // {
            //     self.E_Text_MyRankText.text = myRank == -1 ? "我的排名: 未上榜" : zstring.Format("我的排名: {0}", myRank);
            // }

            self.AddUIScrollItems(ref self.ScrollItemRankShowItems, self.ShowRankingInfos.Count);
            self.E_RankShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankingInfos.Count, true);

            await ETTask.CompletedTask;
        }
    }
}