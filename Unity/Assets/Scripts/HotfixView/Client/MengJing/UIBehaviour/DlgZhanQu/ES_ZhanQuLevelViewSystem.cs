using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ZhanQuLevelItem))]
    [EntitySystemOf(typeof(ES_ZhanQuLevel))]
    [FriendOfAttribute(typeof(ES_ZhanQuLevel))]
    public static partial class ES_ZhanQuLevelSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ZhanQuLevel self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ZhanQuLevelItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnZhanQuLevelItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ZhanQuLevel self)
        {
            self.DestroyWidget();
        }

        private static void OnZhanQuLevelItemsRefresh(this ES_ZhanQuLevel self, Transform transform, int index)
        {
            foreach (Scroll_Item_ZhanQuLevelItem item in self.ScrollItemZhanQuLevelItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ZhanQuLevelItem scrollItemZhanQuLevelItem = self.ScrollItemZhanQuLevelItems[index].BindTrans(transform);
            scrollItemZhanQuLevelItem.OnInitUI(self.ShowActivityConfigs[index]);
        }

        public static void OnInitUI(this ES_ZhanQuLevel self)
        {
            self.ShowActivityConfigs.Clear();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 21)
                {
                    continue;
                }

                self.ShowActivityConfigs.Add(activityConfigs[i]);
            }

            using (zstring.Block())
            {
                self.E_Lab_MyLvText.text = zstring.Format("我的等级：{0}", self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv);
            }

            self.AddUIScrollItems(ref self.ScrollItemZhanQuLevelItems, self.ShowActivityConfigs.Count);
            self.E_ZhanQuLevelItemsLoopVerticalScrollRect.SetVisible(true, self.ShowActivityConfigs.Count);
        }
    }
}
