using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankRewardItem))]
    [EntitySystemOf(typeof (ES_RankPetReward))]
    [FriendOfAttribute(typeof (ES_RankPetReward))]
    public static partial class ES_RankPetRewardSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankPetReward self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);
            self.E_CloseButton.AddListener(() => { self.uiTransform.gameObject.SetActive(false); });

            self.OnInitUI();
            self.ShowLastRewardPlayer().Coroutine();    
        }

        [EntitySystem]
        private static void Destroy(this ES_RankPetReward self)
        {
            self.DestroyWidget();
        }

        private static async ETTask ShowLastRewardPlayer(this ES_RankPetReward self)
        {
            R2C_RankLastRewardResponse rewardResponse = await PetNetHelper.RequestLastReward(self.Root(), 2);
            if (rewardResponse == null)
            {
                return;    
            }
            Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[0];
            scrollItemRankRewardItem.ShowLastRewardPlayer(rewardResponse.LastRewardList.FirstOrDefault());
        }
        
        public static void OnInitUI(this ES_RankPetReward self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(2);

            self.AddUIScrollItems(ref self.ScrollItemRankRewardItems, self.ShowRankRewardConfigs.Count);
            self.E_RankRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        private static void OnRankShowItemsRefresh(this ES_RankPetReward self, Transform transform, int index)
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
