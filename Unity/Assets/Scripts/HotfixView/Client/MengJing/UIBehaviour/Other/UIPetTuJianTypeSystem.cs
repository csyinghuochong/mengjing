using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIPetTuJianItem))]
    [FriendOf(typeof(UIPetTuJianType))]
    [EntitySystemOf(typeof(UIPetTuJianType))]
    public static partial class UIPetTuJianTypeSystem
    {
        [EntitySystem]
        private static void Awake(this UIPetTuJianType self, GameObject gameObject1, GameObject gameObject2)
        {
            self.GameObject = gameObject1;
            self.UIChengJiuShowChapterItemListNode = gameObject2;
            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            self.ImageButton = rc.Get<GameObject>("ImageButton");
            self.TaskTypeName = rc.Get<GameObject>("TaskTypeName");

            self.ImageButton.GetComponent<Button>().AddListener(self.OnImageButton);
        }

        public static void Init(this UIPetTuJianType self, int type, Action<int> onTypeAction, Action<int> onChapterAction)
        {
            List<string> ChengJiuTypeText = new() { "普通宠物", "神宠" };

            self.ChengJiuType = type;
            self.OnTypeAction = onTypeAction;
            self.OnChapterAction = onChapterAction;
            self.TaskTypeName.GetComponent<Text>().text = ChengJiuTypeText[type];
        }

        public static void OnImageButton(this UIPetTuJianType self)
        {
            self.OnTypeAction?.Invoke(self.ChengJiuType);
        }

        public static void OnChapter(this UIPetTuJianType self, int chapter)
        {
            self.OnChapterAction?.Invoke(chapter);
        }

        public static void SetSelected(this UIPetTuJianType self, int type)
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
                foreach (PetConfig petConfig in PetConfigCategory.Instance.GetAll().Values)
                {
                    if (self.ChengJiuType == 0 && petConfig.PetType == 0)
                    {
                        showChapter.Add(petConfig.Id);
                    }

                    if (self.ChengJiuType == 1 && petConfig.PetType == 1)
                    {
                        showChapter.Add(petConfig.Id);
                    }
                }

                int num = 0;
                for (int i = 0; i < showChapter.Count; i++)
                {
                    UIPetTuJianItem item = null;
                    if (i < self.UIPetTuJianItems.Count)
                    {
                        item = self.UIPetTuJianItems[i];
                        item.Init(showChapter[i], self.OnChapter);
                    }
                    else
                    {
                        GameObject go = UnityEngine.Object.Instantiate(temp, self.UIChengJiuShowChapterItemListNode.transform);
                        item = self.AddChild<UIPetTuJianItem, GameObject>(go);
                        item.Init(showChapter[i], self.OnChapter);
                        self.UIPetTuJianItems.Add(item);
                    }

                    item.GameObject.SetActive(true);

                    num++;
                }

                for (int i = num; i < self.UIPetTuJianItems.Count; i++)
                {
                    UIPetTuJianItem ui = self.UIPetTuJianItems[i];
                    ui.GameObject.SetActive(false);
                }
            }
        }

        public static void SelectFirst(this UIPetTuJianType self)
        {
            // 默认点第一个
            if (self.UIPetTuJianItems.Count > 0)
            {
                UIPetTuJianItem ui = self.UIPetTuJianItems[0];
                ui.OnIma_Di();
            }
        }
    }
}