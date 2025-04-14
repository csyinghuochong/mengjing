using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChengJiuShowItem))]
    [FriendOf(typeof(Scroll_Item_ChengJiuTypeItem))]
    [EntitySystemOf(typeof(ES_ChengJiuShow))]
    [FriendOfAttribute(typeof(ES_ChengJiuShow))]
    public static partial class ES_ChengJiuShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChengJiuShow self, Transform transform)
        {
            self.uiTransform = transform;

            ReferenceCollector rc = transform.GetComponent<ReferenceCollector>();
            self.LeftContent = rc.Get<GameObject>("LeftContent");
            self.UIChengJiuShowType = rc.Get<GameObject>("UIChengJiuShowType");
            self.UIChengJiuShowChapterItemListNode = rc.Get<GameObject>("UIChengJiuShowChapterItemListNode");

            self.UIChengJiuShowType.SetActive(false);
            self.UIChengJiuShowChapterItemListNode.SetActive(false);

            self.E_ChengJiuShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChengJiuShowItemsRefresh);

            self.InitChengJiuList();
        }

        [EntitySystem]
        private static void Destroy(this ES_ChengJiuShow self)
        {
            self.DestroyWidget();
        }

        private static void OnChengJiuShowItemsRefresh(this ES_ChengJiuShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_ChengJiuShowItem item in self.ScrollItemChengJiuShowItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ChengJiuShowItem scrollItemChengJiuShowItem = self.ScrollItemChengJiuShowItems[index].BindTrans(transform);
            scrollItemChengJiuShowItem.OnUpdateData(self.ShowTask[index]);
        }

        public static void InitChengJiuList(this ES_ChengJiuShow self)
        {
            List<int> showType = new List<int>();
            showType.Add((int)ChengJiuTypeEnum.GuanKa);
            showType.Add((int)ChengJiuTypeEnum.TanSuo);
            showType.Add((int)ChengJiuTypeEnum.ShouJi);

            foreach (int type in showType)
            {
                GameObject go1 = UnityEngine.Object.Instantiate(self.UIChengJiuShowType, self.LeftContent.transform);
                GameObject go2 = UnityEngine.Object.Instantiate(self.UIChengJiuShowChapterItemListNode, self.LeftContent.transform);
                UIChengJiuShowType uiChengJiuShowType = self.AddChild<UIChengJiuShowType, GameObject, GameObject>(go1, go2);
                go1.SetActive(true);
                uiChengJiuShowType.Init(type, self.OnType, self.OnChapter);

                self.UIChengJiuShowTypes.Add(uiChengJiuShowType);
            }

            UIChengJiuShowType ui = self.UIChengJiuShowTypes[0];
            ui.OnImageButton();
        }

        public static void OnType(this ES_ChengJiuShow self, int type)
        {
            foreach (UIChengJiuShowType uiChengJiuShowType in self.UIChengJiuShowTypes)
            {
                uiChengJiuShowType.SetSelected(type);
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(self.LeftContent.GetComponent<RectTransform>());
        }

        public static void OnChapter(this ES_ChengJiuShow self, int type, int chapter)
        {
            self.ShowTask.Clear();
            self.ShowTask.AddRange(self.Root().GetComponent<ChengJiuComponentC>().GetTasksByChapter(type, chapter));

            self.AddUIScrollItems(ref self.ScrollItemChengJiuShowItems, self.ShowTask.Count);
            self.E_ChengJiuShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTask.Count, true);
        }
    }
}
