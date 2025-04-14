using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectRewardItem))]
    [FriendOf(typeof(DlgSelectReward))]
    public static class DlgSelectRewardSystem
    {
        public static void RegisterUIEvent(this DlgSelectReward self)
        {
            self.View.E_SelectRewardItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSelectRewardItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SelectReward); });
        }

        public static void ShowWindow(this DlgSelectReward self, Entity contextData = null)
        {
        }

        private static void OnSelectRewardItemsRefresh(this DlgSelectReward self, Transform transform, int index)
        {
            foreach (Scroll_Item_SelectRewardItem item in self.ScrollItemSelectRewardItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_SelectRewardItem scrollItemSelectRewardItem = self.ScrollItemSelectRewardItems[index].BindTrans(transform);
            string[] item1 = self.Items[index].Split(';');
            ItemInfo bagInfoNew = new ItemInfo();
            bagInfoNew.ItemID = int.Parse(item1[0]);
            bagInfoNew.ItemNum = int.Parse(item1[1]);
            scrollItemSelectRewardItem.ES_CommonItem.UpdateItem(bagInfoNew, ItemOperateEnum.None);
            scrollItemSelectRewardItem.E_GetBtnButton.AddListener(() => { self.OnGetBtn(index).Coroutine(); });
        }

        public static void UpdateInfo(this DlgSelectReward self, int key, int type)
        {
            self.Key = key;
            self.Type = type;

            string[] occItems;
            switch (type)
            {
                case 0:
                    self.View.E_TitleTextText.text = "等级领取";
                    occItems = ConfigData.LeavlRewardItem[key].Split('&');
                    break;
                case 1:
                    self.View.E_TitleTextText.text = "击败怪物领取";
                    occItems = ConfigData.KillMonsterReward[key].Split('&');
                    break;
                default:
                    return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string[] items;
            if (occItems.Length == 3)
            {
                items = occItems[userInfoComponent.UserInfo.Occ - 1].Split('@');
            }
            else
            {
                items = occItems[0].Split('@');
            }

            self.Items = items;

            self.AddUIScrollItems(ref self.ScrollItemSelectRewardItems, self.Items.Length);
            self.View.E_SelectRewardItemsLoopVerticalScrollRect.SetVisible(true, self.Items.Length);
        }

        public static async ETTask OnGetBtn(this DlgSelectReward self, int index)
        {
            switch (self.Type)
            {
                case 0:
                {
                    long instanceid = self.InstanceId;
                    await ActivityNetHelper.LeavlRewardRequest(self.Root(), self.Key, index);
                    if (instanceid != self.InstanceId)
                    {
                        return;
                    }

                    self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().UpdateLvReward();
                    break;
                }
                case 1:
                {
                    long instanceid = self.InstanceId;
                    await ActivityNetHelper.KillMonsterRewardRequest(self.Root(), self.Key, index);
                    if (instanceid != self.InstanceId)
                    {
                        return;
                    }

                    self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().UpdateKillMonsterReward();
                    break;
                }
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SelectReward);
        }
    }
}
