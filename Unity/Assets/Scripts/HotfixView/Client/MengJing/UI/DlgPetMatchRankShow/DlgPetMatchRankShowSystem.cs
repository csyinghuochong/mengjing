using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMatchRankShowItem))]
    [FriendOf(typeof(DlgPetMatchRankShow))]
    public static class DlgPetMatchRankShowSystem
    {
        public static void RegisterUIEvent(this DlgPetMatchRankShow self)
        {
            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMatchRankShow); });
            self.View.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.View.E_PetMatchRankShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.View.E_HeadIcomImage1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "1"));
            self.View.E_HeadIcomImage2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "2"));
            self.View.E_HeadIcomImage3Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "3"));

            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<GameObject>("Assets/Bundles/UI/Item/Item_PetMatchRankShowItem");
            GameObject gameObject = UnityEngine.Object.Instantiate(prefab, self.View.EG_MyRankShowRectTransform);
            self.MyRankShowItem = self.AddChild<Scroll_Item_PetMatchRankShowItem>();
            self.MyRankShowItem.BindTrans(gameObject.transform);
            self.View.EG_MyRankShowRectTransform.gameObject.SetActive(false);

            self.OnUpdateUI().Coroutine();
        }

        public static void ShowWindow(this DlgPetMatchRankShow self, Entity contextData = null)
        {
        }

        private static void OnItemTypeSet(this DlgPetMatchRankShow self, int index)
        {
            self.CurrentItemType = index;
            self.OnUpdateUI(index + 1).Coroutine();
        }

        private static void OnRankShowItemsRefresh(this DlgPetMatchRankShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetMatchRankShowItem item in self.ScrollItemRankShowItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetMatchRankShowItem scrollItemRankShowItem = self.ScrollItemRankShowItems[index].BindTrans(transform);
            scrollItemRankShowItem.Refresh(index + 1, self.ShowRankingInfos[index]);
        }

        private static async ETTask OnUpdateUI(this DlgPetMatchRankShow self, int type = 0)
        {
            self.View.EG_Rank_1RectTransform.gameObject.SetActive(false);
            self.View.EG_Rank_2RectTransform.gameObject.SetActive(false);
            self.View.EG_Rank_3RectTransform.gameObject.SetActive(false);

            long instanceid = self.InstanceId;

            PetMatch2C_RankListResponse response = await PetMatchNetHelper.RequestPetMatchRankList(self.Root());
            
            // 测试
            if (instanceid != self.InstanceId)
            {
                return;
            }

            long selfId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            int myRank = -1;
            int rank = 1;
            self.ShowRankingInfos.Clear();

            for (int i = 0; i < response.PetMatchPlayerInfoList.Count; i++)
            {
                if (type != 0 && response.PetMatchPlayerInfoList[i].Occ != type)
                {
                    continue;
                }

                self.ShowRankingInfos.Add(response.PetMatchPlayerInfoList[i]);

                if (selfId == response.PetMatchPlayerInfoList[i].UnitId)
                {
                    myRank = rank;
                }

                if (rank == 1)
                {
                    self.View.EG_Rank_1RectTransform.gameObject.SetActive(true);
                    self.View.EG_Rank_1RectTransform.Find("CombatTxt").GetComponent<Text>().text =
                            response.PetMatchPlayerInfoList[i].Score.ToString();
                    self.View.ES_ModelShow_1.SetCameraPosition(new Vector3(0f, 60f, 150f));
                    self.View.ES_ModelShow_1.ShowPlayerModel(new ItemInfo(), response.PetMatchPlayerInfoList[i].Occ, 0, new List<int>(), false);
                    self.View.EG_Rank_1RectTransform.Find("NameTxt").GetComponent<Text>().text = response.PetMatchPlayerInfoList[i].Name;
                    // using (zstring.Block())
                    // {
                    //     self.View.EG_Rank_1RectTransform.Find("LvTxt").GetComponent<Text>().text = zstring.Format("等级:{0}", response.PetMatchPlayerInfoList[i].PlayerLv);
                    // }
                }

                if (rank == 2)
                {
                    self.View.EG_Rank_2RectTransform.gameObject.SetActive(true);
                    self.View.EG_Rank_2RectTransform.Find("CombatTxt").GetComponent<Text>().text =
                            response.PetMatchPlayerInfoList[i].Score.ToString();
                    self.View.ES_ModelShow_2.SetCameraPosition(new Vector3(0f, 60f, 150f));
                    self.View.ES_ModelShow_2.ShowPlayerModel(new ItemInfo(), response.PetMatchPlayerInfoList[i].Occ, 0, new List<int>(), false);
                    self.View.EG_Rank_2RectTransform.Find("NameTxt").GetComponent<Text>().text = response.PetMatchPlayerInfoList[i].Name;
                    // using (zstring.Block())
                    // {
                    //     self.View.EG_Rank_2RectTransform.Find("LvTxt").GetComponent<Text>().text = zstring.Format("等级:{0}", response.RankList[i].PlayerLv);
                    // }
                }

                if (rank == 3)
                {
                    self.View.EG_Rank_3RectTransform.gameObject.SetActive(true);
                    self.View.EG_Rank_3RectTransform.Find("CombatTxt").GetComponent<Text>().text =
                            response.PetMatchPlayerInfoList[i].Score.ToString();
                    self.View.ES_ModelShow_3.SetCameraPosition(new Vector3(0f, 60f, 150f));
                    self.View.ES_ModelShow_3.ShowPlayerModel(new ItemInfo(), response.PetMatchPlayerInfoList[i].Occ, 0, new List<int>(), false);
                    self.View.EG_Rank_3RectTransform.Find("NameTxt").GetComponent<Text>().text = response.PetMatchPlayerInfoList[i].Name;
                    // using (zstring.Block())
                    // {
                    //     self.View.EG_Rank_3RectTransform.Find("LvTxt").GetComponent<Text>().text = zstring.Format("等级:{0}", response.RankList[i].PlayerLv);
                    // }
                }

                rank++;
            }

            if (myRank != -1)
            {
                self.MyRankShowItem.Refresh(myRank, response.PetMatchPlayerInfoList.Find(r => r.UnitId == selfId));
                self.View.EG_MyRankShowRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.View.EG_MyRankShowRectTransform.gameObject.SetActive(false);
            }
            // using (zstring.Block())
            // {
            //     self.E_Text_MyRankText.text = myRank == -1 ? "我的排名: 未上榜" : zstring.Format("我的排名: {0}", myRank);
            // }

            self.AddUIScrollItems(ref self.ScrollItemRankShowItems, self.ShowRankingInfos.Count);
            self.View.E_PetMatchRankShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankingInfos.Count, true);

            await ETTask.CompletedTask;
        }
    }
}