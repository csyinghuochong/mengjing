using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankRewardItem))]
    [EntitySystemOf(typeof (ES_RankReward))]
    [FriendOfAttribute(typeof (ES_RankReward))]
    public static partial class ES_RankRewardSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankReward self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);
            self.E_CloseButton.AddListener(() => { self.uiTransform.gameObject.SetActive(false); });

            self.OnInitUI();
            self.ShowLastRewardPlayer().Coroutine();    
        }

        [EntitySystem]
        private static void Destroy(this ES_RankReward self)
        {
            self.DestroyWidget();
        }

        private static async ETTask ShowLastRewardPlayer(this ES_RankReward self)
        {
             R2C_RankLastRewardResponse rewardResponse = await PetNetHelper.RequestLastReward(self.Root(), 1);
             if (rewardResponse == null)
             {
                 return;    
             }
             Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[0];
             scrollItemRankRewardItem.ShowLastRewardPlayer(rewardResponse.LastRewardList.FirstOrDefault());
        }

        public static void OnInitUI(this ES_RankReward self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(1);

            self.AddUIScrollItems(ref self.ScrollItemRankRewardItems, self.ShowRankRewardConfigs.Count);
            self.E_RankRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        private static void OnRankShowItemsRefresh(this ES_RankReward self, Transform transform, int index)
        {
            foreach (Scroll_Item_RankRewardItem item in self.ScrollItemRankRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[index].BindTrans(transform);
            scrollItemRankRewardItem.OnUpdateUI(self.ShowRankRewardConfigs[index]);
        }
    }
}
