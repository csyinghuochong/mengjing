using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_SettingTitleItem))]
    [EntitySystemOf(typeof (ES_SettingTitle))]
    [FriendOfAttribute(typeof (ES_SettingTitle))]
    public static partial class ES_SettingTitleSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SettingTitle self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_SettingTitleItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSettingTitleItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_SettingTitle self)
        {
            self.DestroyWidget();
        }

        private static void OnSettingTitleItemsRefresh(this ES_SettingTitle self, Transform transform, int index)
        {
            TitleComponentC titleComponent = self.Root().GetComponent<TitleComponentC>();

            foreach (Scroll_Item_SettingTitleItem item in self.ScrollItemSettingTitleItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_SettingTitleItem scrollItemSettingTitleItem = self.ScrollItemSettingTitleItems[index].BindTrans(transform);
            scrollItemSettingTitleItem.OnInitUI(self.ShowTitleConfigs[index].Id, titleComponent.IsHaveTitle(self.ShowTitleConfigs[index].Id));
        }

        public static void OnInitUI(this ES_SettingTitle self)
        {
            self.ShowTitleConfigs.Clear();
            self.ShowTitleConfigs.AddRange(TitleConfigCategory.Instance.GetAll().Values.ToList());

            self.AddUIScrollItems(ref self.ScrollItemSettingTitleItems, self.ShowTitleConfigs.Count);
            self.E_SettingTitleItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTitleConfigs.Count);
        }

        public static void OnUpdateUI(this ES_SettingTitle self)
        {
            if (self.ScrollItemSettingTitleItems != null)
            {
                foreach (Scroll_Item_SettingTitleItem item in self.ScrollItemSettingTitleItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.OnUpdateUI();
                }
            }
        }
    }
}
