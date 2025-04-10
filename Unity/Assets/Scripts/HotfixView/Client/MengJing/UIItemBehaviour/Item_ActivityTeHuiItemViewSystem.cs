using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RewardItem))]
    [FriendOf(typeof(Scroll_Item_ActivityTeHuiItem))]
    [EntitySystemOf(typeof(Scroll_Item_ActivityTeHuiItem))]
    public static partial class Scroll_Item_ActivityTeHuiItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ActivityTeHuiItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ActivityTeHuiItem self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;

            self.DestroyWidget();
        }

        public static async ETTask OnButtonBuy(this Scroll_Item_ActivityTeHuiItem self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (activityComponent.ActivityReceiveIds.Contains(self.ActivityConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经购买过该礼包！");
                return;
            }

            M2C_ActivityReceiveResponse response =
                    await ActivityNetHelper.ActivityReceive(self.Root(), self.ActivityConfig.ActivityType, self.ActivityConfig.Id);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.E_TipText.text = "每个账号每日限定(1/1)";
            
            self.E_ImageReceivedImage.gameObject.SetActive(true);
            self.E_ButtonBuyButton.gameObject.SetActive(false);
        }

        public static void OnUpdateUI(this Scroll_Item_ActivityTeHuiItem self, int activityId, bool received)
        {
            self.E_ButtonBuyButton.AddListenerAsync(self.OnButtonBuy);

            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityId);
            self.ActivityConfig = activityConfig;

            self.E_TextTypeText.text = activityConfig.Par_4;

            //显示图标
            string ItemIcon = activityConfig.Icon;
            if (!string.IsNullOrEmpty(ItemIcon))
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_ImageBoxImage.sprite = sp;
            }

            self.E_TipText.text = received ? "每个账号每日限定(1/1)" : "每个账号每日限定(0/1)";

            List<ItemInfo> ShowBagInfos = new List<ItemInfo>();
            if (!CommonHelp.IfNull(activityConfig.Par_3))
            {
                string[] items = activityConfig.Par_3.Split('@');
                foreach (string item in items)
                {
                    if (CommonHelp.IfNull(item))
                    {
                        continue;
                    }

                    string[] it = item.Split(';');
                    ItemInfo bagInfo = new ItemInfo();
                    bagInfo.ItemID = int.Parse(it[0]);
                    bagInfo.ItemNum = int.Parse(it[1]);
                    ShowBagInfos.Add(bagInfo);
                }
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < ShowBagInfos.Count; i++)
            {
                if (!self.ScrollItemRewardItems.ContainsKey(i))
                {
                    Scroll_Item_RewardItem item = self.AddChild<Scroll_Item_RewardItem>();
                    string path = "Assets/Bundles/UI/Item/Item_RewardItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_RewardItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemRewardItems.Add(i, item);
                }

                Scroll_Item_RewardItem scrollItemRewardItem = self.ScrollItemRewardItems[i];
                scrollItemRewardItem.uiTransform.gameObject.SetActive(true);
                scrollItemRewardItem.UpdateItem(ShowBagInfos[i]);
                scrollItemRewardItem.ShowUIEffect(41100001);
            }

            if (self.ScrollItemRewardItems.Count > ShowBagInfos.Count)
            {
                for (int i = self.ScrollItemRewardItems.Count; i < self.ScrollItemRewardItems.Count; i++)
                {
                    Scroll_Item_RewardItem scrollItemRewardItem = self.ScrollItemRewardItems[i];
                    scrollItemRewardItem.uiTransform.gameObject.SetActive(false);
                }
            }
            
            self.E_ImageReceivedImage.gameObject.SetActive(received);
            self.E_ButtonBuyButton.gameObject.SetActive(!received);
            self.E_TextPriceText.text = activityConfig.Par_2.Split(';')[1];
        }
    }
}