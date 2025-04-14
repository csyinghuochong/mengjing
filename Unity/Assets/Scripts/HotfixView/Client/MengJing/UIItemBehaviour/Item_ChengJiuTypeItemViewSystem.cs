using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ChengJiuTypeItemItem))]
    [FriendOf(typeof (Scroll_Item_ChengJiuTypeItem))]
    [EntitySystemOf(typeof (Scroll_Item_ChengJiuTypeItem))]
    public static partial class Scroll_Item_ChengJiuTypeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ChengJiuTypeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ChengJiuTypeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnToggleValueChanged(this Scroll_Item_ChengJiuTypeItem self, bool value)
        {
            self.Selected = value;

            self.ShowChapter.Clear();
            self.ShowChapter.AddRange(self.Root().GetComponent<ChengJiuComponentC>().GetChaptersByType(self.ChengJiuTypeId));

            // 设置高度
            self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 70f + 176 * self.ShowChapter.Count);
            self.E_ChengJiuTypeItemItemsLoopVerticalScrollRect.transform.GetComponent<RectTransform>().sizeDelta =
                    new Vector2(700, 176 * self.ShowChapter.Count);
            // 刷新一下父物体
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.uiTransform.parent.GetComponent<RectTransform>());

            self.AddUIScrollItems(ref self.ScrollItemChengJiuTypeItemItems, self.ShowChapter.Count);
            self.E_ChengJiuTypeItemItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChapter.Count);

            if (self.ScrollItemChengJiuTypeItemItems.Count > 0)
            {
                Scroll_Item_ChengJiuTypeItemItem scrollItemChengJiuTypeItemItem = self.ScrollItemChengJiuTypeItemItems[0];
                scrollItemChengJiuTypeItemItem.OnClickButtoin();
            }
        }

        public static void OnUpdateData(this Scroll_Item_ChengJiuTypeItem self, int typeId)
        {
            self.ChengJiuTypeId = typeId;

            self.E_ChengJiuTypeItemItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChengJiuTypeItemItemsRefresh);
            self.E_ImageButtonButton.AddListener(self.OnClickTypeButton);

            self.E_TaskTypeNameText.text = ChengJiuData.ChengJiuTypeText[typeId];
        }

        public static void SetClickSubTypeHandler(this Scroll_Item_ChengJiuTypeItem self, Action<int, int> action)
        {
            self.ClickTaskSubTypeHandler = action;
        }

        public static void OnClickTypeButton(this Scroll_Item_ChengJiuTypeItem self)
        {
            self.OnToggleValueChanged(!self.Selected);
        }

        public static void UnSelectedAll(this Scroll_Item_ChengJiuTypeItem self)
        {
            if (self.ScrollItemChengJiuTypeItemItems == null)
            {
                return;
            }

            for (int i = 0; i < self.ScrollItemChengJiuTypeItemItems.Count; i++)
            {
                Scroll_Item_ChengJiuTypeItemItem scrollItemChengJiuTypeItemItem = self.ScrollItemChengJiuTypeItemItems[i];
                if (scrollItemChengJiuTypeItemItem.uiTransform != null)
                {
                    scrollItemChengJiuTypeItemItem.SetSelected(-1);
                }
            }

            // 设置高度
            self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 70f);
            self.E_ChengJiuTypeItemItemsLoopVerticalScrollRect.transform.GetComponent<RectTransform>().sizeDelta =
                    new Vector2(700, 0);
            // 刷新一下父物体
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.uiTransform.parent.GetComponent<RectTransform>());
        }

        public static void OnClickTaskTypeItem(this Scroll_Item_ChengJiuTypeItem self, int chapterid)
        {
            for (int i = 0; i < self.ScrollItemChengJiuTypeItemItems.Count; i++)
            {
                Scroll_Item_ChengJiuTypeItemItem scrollItemChengJiuTypeItemItem = self.ScrollItemChengJiuTypeItemItems[i];
                if (scrollItemChengJiuTypeItemItem.uiTransform != null)
                {
                    scrollItemChengJiuTypeItemItem.SetSelected(chapterid);
                }
            }

            self.ClickTaskSubTypeHandler(self.ChengJiuTypeId, chapterid);
        }

        private static void OnChengJiuTypeItemItemsRefresh(this Scroll_Item_ChengJiuTypeItem self, Transform transform, int index)
        {
            foreach (Scroll_Item_ChengJiuTypeItemItem item in self.ScrollItemChengJiuTypeItemItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ChengJiuTypeItemItem scrollItemChengJiuTypeItemItem = self.ScrollItemChengJiuTypeItemItems[index].BindTrans(transform);
            scrollItemChengJiuTypeItemItem.SetClickSubTypeHandler((int chapterid) => { self.OnClickTaskTypeItem(chapterid); });
            scrollItemChengJiuTypeItemItem.OnUpdateData(self.ChengJiuTypeId, self.ShowChapter[index]);
        }
    }
}