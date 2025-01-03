using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIChengJiuShowChapterItem))]
    [FriendOf(typeof(UIChengJiuShowType))]
    [EntitySystemOf(typeof(UIChengJiuShowType))]
    public static partial class UIChengJiuShowTypeSystem
    {
        [EntitySystem]
        private static void Awake(this UIChengJiuShowType self, GameObject gameObject1, GameObject gameObject2)
        {
            self.GameObject = gameObject1;
            self.UIChengJiuShowChapterItemListNode = gameObject2;
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            self.ImageButton = rc.Get<GameObject>("ImageButton");
            self.TaskTypeName = rc.Get<GameObject>("TaskTypeName");

            self.ImageButton.GetComponent<Button>().AddListener(self.OnImageButton);
        }

        public static void Init(this UIChengJiuShowType self, int type, Action<int> onTypeAction, Action<int, int> onChapterAction)
        {
            self.ChengJiuType = type;
            self.OnTypeAction = onTypeAction;
            self.OnChapterAction = onChapterAction;
            self.TaskTypeName.GetComponent<Text>().text = ChengJiuData.ChengJiuTypeText[type];
        }

        public static void OnImageButton(this UIChengJiuShowType self)
        {
            self.OnTypeAction?.Invoke(self.ChengJiuType);
        }

        public static void OnChapter(this UIChengJiuShowType self, int type, int chapter)
        {
            foreach (UIChengJiuShowChapterItem item in self.UIChengJiuShowChapterItems)
            {
                item.SetSelected(chapter);
            }

            self.OnChapterAction?.Invoke(type, chapter);
        }

        public static void SetSelected(this UIChengJiuShowType self, int type)
        {
            bool value = type == self.ChengJiuType && !self.UIChengJiuShowChapterItemListNode.gameObject.activeSelf;

            self.UIChengJiuShowChapterItemListNode.SetActive(value);

            GameObject Checkmark = self.GameObject.GetComponent<ReferenceCollector>().Get<GameObject>("Checkmark");
            Checkmark.transform.localScale = value ? new Vector3(1, -1, 1) : new Vector3(1, 1, 1);
            
            if (value)
            {
                GameObject temp = self.UIChengJiuShowChapterItemListNode.transform.GetChild(0).gameObject;
                temp.SetActive(false);
                List<int> showChapter = new List<int>();
                showChapter.AddRange(self.Root().GetComponent<ChengJiuComponentC>().GetChaptersByType(self.ChengJiuType));

                int num = 0;
                for (int i = 0; i < showChapter.Count; i++)
                {
                    UIChengJiuShowChapterItem item = null;
                    if (i < self.UIChengJiuShowChapterItems.Count)
                    {
                        item = self.UIChengJiuShowChapterItems[i];
                        item.Init(self.ChengJiuType, showChapter[i], self.OnChapter);
                    }
                    else
                    {
                        GameObject go = UnityEngine.Object.Instantiate(temp, self.UIChengJiuShowChapterItemListNode.transform);
                        item = self.AddChild<UIChengJiuShowChapterItem, GameObject>(go);
                        item.Init(self.ChengJiuType, showChapter[i], self.OnChapter);
                        self.UIChengJiuShowChapterItems.Add(item);
                    }

                    item.GameObject.SetActive(true);

                    num++;
                }

                for (int i = num; i < self.UIChengJiuShowChapterItems.Count; i++)
                {
                    UIChengJiuShowChapterItem ui = self.UIChengJiuShowChapterItems[i];
                    ui.GameObject.SetActive(false);
                }

                // 默认点第一个
                if (self.UIChengJiuShowChapterItems.Count > 0)
                {
                    UIChengJiuShowChapterItem ui = self.UIChengJiuShowChapterItems[0];
                    ui.OnIma_Di();
                }
            }
        }
    }
}