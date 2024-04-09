using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ChengJiuShowItem))]
    [FriendOf(typeof (Scroll_Item_ChengJiuTypeItem))]
    [EntitySystemOf(typeof (ES_ChengJiuShow))]
    [FriendOfAttribute(typeof (ES_ChengJiuShow))]
    public static partial class ES_ChengJiuShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChengJiuShow self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ChengJiuTypeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChengJiuTypeItemsRefresh);
            self.E_ChengJiuShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChengJiuShowItemsRefresh);

            self.InitChengJiuList();
        }

        [EntitySystem]
        private static void Destroy(this ES_ChengJiuShow self)
        {
            self.DestroyWidget();
        }

        private static void OnChengJiuTypeItemsRefresh(this ES_ChengJiuShow self, Transform transform, int index)
        {
            Scroll_Item_ChengJiuTypeItem scrollItemChengJiuTypeItem = self.ScrollItemChengJiuTypeItems[index].BindTrans(transform);

            scrollItemChengJiuTypeItem.OnUpdateData(self.ShowType[index]);
            scrollItemChengJiuTypeItem.SetClickSubTypeHandler((int typeid, int chapterId) => { self.OnClickTypeItem(typeid, chapterId); });
        }

        private static void OnChengJiuShowItemsRefresh(this ES_ChengJiuShow self, Transform transform, int index)
        {
            Scroll_Item_ChengJiuShowItem scrollItemChengJiuShowItem = self.ScrollItemChengJiuShowItems[index].BindTrans(transform);

            scrollItemChengJiuShowItem.OnUpdateData(self.ShowTask[index]);
        }

        public static void InitChengJiuList(this ES_ChengJiuShow self)
        {
            self.ShowType.Clear();
            self.ShowType.Add((int)ChengJiuTypeEnum.GuanKa);
            self.ShowType.Add((int)ChengJiuTypeEnum.TanSuo);
            self.ShowType.Add((int)ChengJiuTypeEnum.ShouJi);

            self.AddUIScrollItems(ref self.ScrollItemChengJiuTypeItems, self.ShowType.Count);
            self.E_ChengJiuTypeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowType.Count);

            if (self.ScrollItemChengJiuTypeItems.Count > 0)
            {
                self.ScrollItemChengJiuTypeItems[0].OnClickTypeButton();
            }
        }

        public static void OnClickTypeItem(this ES_ChengJiuShow self, int typeid, int chapterId)
        {
            self.ChengTypeId = typeid;

            for (int i = 0; i < self.ScrollItemChengJiuTypeItems.Count; i++)
            {
                if (self.ScrollItemChengJiuTypeItems[i].uiTransform == null)
                {
                    continue;
                }

                if (self.ChengTypeId == self.ScrollItemChengJiuTypeItems[i].ChengJiuTypeId)
                {
                    continue;
                }

                self.ScrollItemChengJiuTypeItems[i].UnSelectedAll();
            }

            self.OnUpdateChapterTask(self.ChengTypeId, chapterId);
        }

        public static void OnUpdateChapterTask(this ES_ChengJiuShow self, int typeid, int chapterId)
        {
            self.ShowTask.Clear();
            self.ShowTask.AddRange(self.Root().GetComponent<ChengJiuComponentC>().GetTasksByChapter(typeid, chapterId));

            self.AddUIScrollItems(ref self.ScrollItemChengJiuShowItems, self.ShowTask.Count);
            self.E_ChengJiuShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTask.Count);
        }
    }
}