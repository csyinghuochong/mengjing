using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ChengJiuJinglingItem))]
    [EntitySystemOf(typeof (ES_ChengJiuJingling))]
    [FriendOfAttribute(typeof (ES_ChengJiuJingling))]
    public static partial class ES_ChengJiuJinglingSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChengJiuJingling self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ChengJiuJinglingItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChengJiuJinglingItemsRefresh);
            
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ChengJiuJingling self)
        {
            self.DestroyWidget();
        }

        private static void OnChengJiuJinglingItemsRefresh(this ES_ChengJiuJingling self, Transform transform, int index)
        {
            Scroll_Item_ChengJiuJinglingItem scrollItemChengJiuJinglingItem = self.ScrollItemChengJiuJinglingItems[index].BindTrans(transform);
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            scrollItemChengJiuJinglingItem.OnInitUI(self.ShowJingLing[index].Id,
                chengJiuComponent.JingLingList.Contains(self.ShowJingLing[index].Id));
        }

        public static async ETTask OnInitUI(this ES_ChengJiuJingling self)
        {
            self.ShowJingLing.Clear();
            self.ShowJingLing.AddRange(JingLingConfigCategory.Instance.GetAll().Values.ToList());

            self.AddUIScrollItems(ref self.ScrollItemChengJiuJinglingItems, self.ShowJingLing.Count);
            self.E_ChengJiuJinglingItemsLoopVerticalScrollRect.SetVisible(true, self.ShowJingLing.Count);
        }

        public static void OnUpdateUI(this ES_ChengJiuJingling self)
        {
            for (int i = 0; i < self.ScrollItemChengJiuJinglingItems.Count; i++)
            {
                if (self.ScrollItemChengJiuJinglingItems[i].uiTransform != null)
                {
                    self.ScrollItemChengJiuJinglingItems[i].OnUpdateUI();
                }
            }
        }
    }
}