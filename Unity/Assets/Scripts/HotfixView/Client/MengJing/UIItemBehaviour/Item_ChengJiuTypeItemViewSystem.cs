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

            self.AddUIScrollItems(ref self.ScrollItemChengJiuTypeItemItems, self.ShowChapter.Count);
            self.E_ChengJiuTypeItemItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChapter.Count);

            if (self.ScrollItemChengJiuTypeItemItems.Count > 0)
            {
                self.ScrollItemChengJiuTypeItemItems[0].OnClickButtoin();
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
            for (int i = 0; i < self.ScrollItemChengJiuTypeItemItems.Count; i++)
            {
                if (self.ScrollItemChengJiuTypeItemItems[i].uiTransform != null)
                {
                    self.ScrollItemChengJiuTypeItemItems[i].SetSelected(-1);
                }
            }
        }

        public static void OnClickTaskTypeItem(this Scroll_Item_ChengJiuTypeItem self, int chapterid)
        {
            for (int i = 0; i < self.ScrollItemChengJiuTypeItemItems.Count; i++)
            {
                if (self.ScrollItemChengJiuTypeItemItems[i].uiTransform != null)
                {
                    self.ScrollItemChengJiuTypeItemItems[i].SetSelected(chapterid);
                }
            }

            self.ClickTaskSubTypeHandler(self.ChengJiuTypeId, chapterid);
        }

        private static void OnChengJiuTypeItemItemsRefresh(this Scroll_Item_ChengJiuTypeItem self, Transform transform, int index)
        {
            Scroll_Item_ChengJiuTypeItemItem scrollItemChengJiuTypeItemItem = self.ScrollItemChengJiuTypeItemItems[index].BindTrans(transform);
            scrollItemChengJiuTypeItemItem.SetClickSubTypeHandler((int chapterid) => { self.OnClickTaskTypeItem(chapterid); });
            scrollItemChengJiuTypeItemItem.OnUpdateData(self.ChengJiuTypeId, self.ShowChapter[index]);
        }
    }
}