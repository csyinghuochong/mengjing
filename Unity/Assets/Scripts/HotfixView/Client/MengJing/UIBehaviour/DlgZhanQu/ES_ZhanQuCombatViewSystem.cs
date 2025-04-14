using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ZhanQuCombatItem))]
    [EntitySystemOf(typeof(ES_ZhanQuCombat))]
    [FriendOfAttribute(typeof(ES_ZhanQuCombat))]
    public static partial class ES_ZhanQuCombatSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ZhanQuCombat self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ZhanQuCombatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnZhanQuCombatItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ZhanQuCombat self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_ZhanQuCombat self)
        {
            self.ShowActivityConfigs.Clear();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 22)
                {
                    continue;
                }

                self.ShowActivityConfigs.Add(activityConfigs[i]);
            }

            using (zstring.Block())
            {
                self.E_MyCombatText.GetComponent<Text>().text =
                        zstring.Format("我的战力：{0}", self.Root().GetComponent<UserInfoComponentC>().UserInfo.Combat);
            }

            self.AddUIScrollItems(ref self.ScrollItemZhanQuCombatItems, self.ShowActivityConfigs.Count);
            self.E_ZhanQuCombatItemsLoopVerticalScrollRect.SetVisible(true, self.ShowActivityConfigs.Count);
        }

        private static void OnZhanQuCombatItemsRefresh(this ES_ZhanQuCombat self, Transform transform, int index)
        {
            foreach (Scroll_Item_ZhanQuCombatItem item in self.ScrollItemZhanQuCombatItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ZhanQuCombatItem scrollItemZhanQuCombatItem = self.ScrollItemZhanQuCombatItems[index].BindTrans(transform);
            scrollItemZhanQuCombatItem.OnInitUI(self.ShowActivityConfigs[index]);
        }
    }
}
