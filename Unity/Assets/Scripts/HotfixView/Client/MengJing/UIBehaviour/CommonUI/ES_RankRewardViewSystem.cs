using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RankReward))]
    [FriendOfAttribute(typeof (ES_RankReward))]
    public static partial class ES_RankRewardSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankReward self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RankRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankShowItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_RankReward self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_RankReward self)
        {
            long instanceid = self.InstanceId;
            var path = ABPathHelper.GetUGUIPath("Main/Rank/UIRankRewardItem");
            var bundleGameObject = ResourcesComponent.Instance.LoadAsset<GameObject>(path);

            List<RankRewardConfig> rankRewardConfigs = RankHelper.GetTypeRankRewards(1);
            for (int i = 0; i < rankRewardConfigs.Count; i++)
            {
                GameObject go = GameObject.Instantiate(bundleGameObject);
                UICommonHelper.SetParent(go, self.RewardListNode);
                self.AddChild<UIRankRewardItemComponent, GameObject>(go, true).OnUpdateUI(rankRewardConfigs[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemRankRewardItems, self.ShowRankingInfos.Count);
            self.E_RankShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankingInfos.Count);
        }

        private static void OnRankShowItemsRefresh(this ES_RankReward self, Transform transform, int index)
        {
            Scroll_Item_RankRewardItem scrollItemRankRewardItem = self.ScrollItemRankRewardItems[index].BindTrans(transform);
            scrollItemRankRewardItem.Refresh(index + 1, self.ShowRankingInfos[index]);
        }
    }
}