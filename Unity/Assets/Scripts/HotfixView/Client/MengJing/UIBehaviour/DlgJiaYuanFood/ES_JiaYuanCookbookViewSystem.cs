using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanCookbookItem))]
    [EntitySystemOf(typeof (ES_JiaYuanCookbook))]
    [FriendOfAttribute(typeof (ES_JiaYuanCookbook))]
    public static partial class ES_JiaYuanCookbookSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanCookbook self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_JiaYuanCookbookItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanCookbookItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanCookbook self)
        {
            self.DestroyWidget();
        }

        private static void OnJiaYuanCookbookItemsRefresh(this ES_JiaYuanCookbook self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanCookbookItem item in self.ScrollItemJiaYuanCookbookItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanCookbookItem scrollItemJiaYuanCookbookItem = self.ScrollItemJiaYuanCookbookItems[index].BindTrans(transform);
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            scrollItemJiaYuanCookbookItem.OnUpdateUI(self.ShowFoods[index], jiaYuanComponentC.LearnMakeIds_7.Contains(self.ShowFoods[index]));
        }

        public static void OnUpdateUI(this ES_JiaYuanCookbook self)
        {
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            List<int> foodlist = ItemConfigCategory.Instance.FoodList;
            List<int> allfoods = new List<int>();
            allfoods.AddRange(jiaYuanComponentC.LearnMakeIds_7);
            for (int i = 0; i < foodlist.Count; i++)
            {
                if (!allfoods.Contains(foodlist[i]))
                {
                    allfoods.Add(foodlist[i]);
                }
            }

            for (int i = allfoods.Count - 1; i >= 0; i--)
            {
                int makeid = EquipMakeConfigCategory.Instance.GetMakeId(allfoods[i]);
                if (makeid == 0)
                {
                    allfoods.RemoveAt(i);
                }
            }

            self.ShowFoods.Clear();
            self.ShowFoods.AddRange(allfoods);

            self.AddUIScrollItems(ref self.ScrollItemJiaYuanCookbookItems, self.ShowFoods.Count);
            self.E_JiaYuanCookbookItemsLoopVerticalScrollRect.SetVisible(true, self.ShowFoods.Count);
        }
    }
}
