using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChengJiuRewardItem))]
    [EntitySystemOf(typeof(ES_ChengJiuReward))]
    [FriendOfAttribute(typeof(ES_ChengJiuReward))]
    public static partial class ES_ChengJiuRewardSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChengJiuReward self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_LingQuButton.AddListenerAsync(self.OnBtn_LingQuButton);

            self.E_ChengJiuRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChengJiuRewardItemsRefresh);

            self.InitRewardUIList();
        }

        [EntitySystem]
        private static void Destroy(this ES_ChengJiuReward self)
        {
            self.DestroyWidget();
        }

        private static void OnChengJiuRewardItemsRefresh(this ES_ChengJiuReward self, Transform transform, int index)
        {
            foreach (Scroll_Item_ChengJiuRewardItem item in self.ScrollItemChengJiuRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            Scroll_Item_ChengJiuRewardItem scrollItemChengJiuRewardItem = self.ScrollItemChengJiuRewardItems[index].BindTrans(transform);
            scrollItemChengJiuRewardItem.OnInitData(self.ShowChengJiuRewardConfigs[index],
                chengJiuComponent.AlreadReceivedId.Contains(self.ShowChengJiuRewardConfigs[index].Id));
            scrollItemChengJiuRewardItem.SetClickHanlder((int rewardId) => { self.OnClickRewardItem(rewardId); });
        }

        public static void OnUpdateUI(this ES_ChengJiuReward self)
        {
            self.E_Text_TotalPointText.text = self.Root().GetComponent<ChengJiuComponentC>().TotalChengJiuPoint.ToString();
        }

        private static void InitRewardUIList(this ES_ChengJiuReward self)
        {
            List<ChengJiuRewardConfig> rewardConfigs = ChengJiuRewardConfigCategory.Instance.GetAll().Values.ToList();

            self.ShowChengJiuRewardConfigs.Clear();
            for (int i = 0; i < rewardConfigs.Count; i++)
            {
                self.ShowChengJiuRewardConfigs.Add(rewardConfigs[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemChengJiuRewardItems, self.ShowChengJiuRewardConfigs.Count);
            self.E_ChengJiuRewardItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChengJiuRewardConfigs.Count);

            if (self.ScrollItemChengJiuRewardItems.Count > 0)
            {
                Scroll_Item_ChengJiuRewardItem scrollItemChengJiuRewardItem = self.ScrollItemChengJiuRewardItems[0];
                scrollItemChengJiuRewardItem.OnClick_DiButton();
            }
        }

        private static void OnClickRewardItem(this ES_ChengJiuReward self, int rewardId)
        {
            self.RewardId = rewardId;

            for (int i = 0; i < self.ScrollItemChengJiuRewardItems.Count; i++)
            {
                Scroll_Item_ChengJiuRewardItem scrollItemChengJiuRewardItem = self.ScrollItemChengJiuRewardItems[i];
                if (scrollItemChengJiuRewardItem.uiTransform != null)
                {
                    scrollItemChengJiuRewardItem.SetSelected(rewardId);
                }
            }

            self.OnUpdateSlectInfo(rewardId);
            self.OnUdapteItemList(rewardId);
        }

        private static async ETTask OnBtn_LingQuButton(this ES_ChengJiuReward self)
        {
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            ChengJiuRewardConfig chengJiuConfig = ChengJiuRewardConfigCategory.Instance.Get(self.RewardId);
            if (chengJiuComponent.TotalChengJiuPoint < chengJiuConfig.NeedPoint)
            {
                FlyTipComponent.Instance.ShowFlyTip("成就点不足！");
                return;
            }

            if (chengJiuComponent.AlreadReceivedId.Contains(self.RewardId))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取过该奖励！");
                return;
            }

            await ChengJiuNetHelper.ReceivedReward(self.Root(), self.RewardId);
            for (int i = 0; i < self.ScrollItemChengJiuRewardItems.Count; i++)
            {
                Scroll_Item_ChengJiuRewardItem scrollItemChengJiuRewardItem = self.ScrollItemChengJiuRewardItems[i];
                if (scrollItemChengJiuRewardItem.uiTransform != null)
                {
                    scrollItemChengJiuRewardItem.SetSelected(self.RewardId);
                }
            }
        }

        private static void OnUdapteItemList(this ES_ChengJiuReward self, int rewardId)
        {
            ChengJiuRewardConfig chengJiuConfig = ChengJiuRewardConfigCategory.Instance.Get(self.RewardId);
            self.ES_RewardList.Refresh(chengJiuConfig.RewardItems);
        }

        private static void OnUpdateSlectInfo(this ES_ChengJiuReward self, int rewardId)
        {
            ChengJiuRewardConfig chengJiuConfig = ChengJiuRewardConfigCategory.Instance.Get(rewardId);

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ChengJiuIcon, chengJiuConfig.Icon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_RewardIconImage.sprite = sp;

            using (zstring.Block())
            {
                self.E_Text_RewardPointText.text = zstring.Format("{0}成就奖励", chengJiuConfig.NeedPoint);
            }

            self.E_Text_RewardDescText.text = chengJiuConfig.Desc;

            self.E_Text_TotalPointText.text = self.Root().GetComponent<ChengJiuComponentC>().TotalChengJiuPoint.ToString();
        }
    }
}
