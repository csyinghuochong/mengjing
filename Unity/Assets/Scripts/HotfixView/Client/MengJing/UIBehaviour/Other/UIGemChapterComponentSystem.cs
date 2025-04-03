using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MakeItem))]
    [FriendOf(typeof(UIGemChapterComponent))]
    [EntitySystemOf(typeof(UIGemChapterComponent))]
    public static partial class UIGemChapterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIGemChapterComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            self.MakeListUI.Clear();

            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
            self.Button_Click = rc.Get<GameObject>("Button_Click");
            self.Checkmark = rc.Get<GameObject>("Checkmark");
            self.ItemNode = rc.Get<GameObject>("ItemNode");
            self.Text_Name = rc.Get<GameObject>("Text_Name");

            self.Button_Click.GetComponent<Button>().AddListener(() =>
            {
                if (!self.IsExpand)
                {
                    self.Expand();
                }
                else
                {
                    self.Collapse();
                }
            });
        }

        public static void Expand(this UIGemChapterComponent self)
        {
            self.IsExpand = true;
            self.ItemNode.transform.gameObject.SetActive(true);
            self.Checkmark.transform.localScale = new Vector3(1, -1, 1);
            self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, self.Height);
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.ItemNode.transform.parent.parent.GetComponent<RectTransform>());
        }

        public static void Collapse(this UIGemChapterComponent self)
        {
            self.IsExpand = false;
            self.ItemNode.transform.gameObject.SetActive(false);
            self.Checkmark.transform.localScale = new Vector3(1, 1, 1);
            self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 100f);
            LayoutRebuilder.ForceRebuildLayoutImmediate(self.ItemNode.transform.parent.parent.GetComponent<RectTransform>());
        }

        public static void OnInitUI(this UIGemChapterComponent self, int chaptet, List<int> makeList)
        {
            self.IsExpand = true;
            int row = (makeList.Count / 5);
            row += (makeList.Count % 5 > 0 ? 1 : 0);
            self.Height = 100f + row * 170f;
            self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, self.Height);

            var path = ABPathHelper.GetUGUIPath("Item/Item_MakeItem");
            var bundleGameObject = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);

            for (int i = 0; i < makeList.Count; i++)
            {
                GameObject itemSpace = UnityEngine.Object.Instantiate(bundleGameObject, self.ItemNode.transform);
                itemSpace.SetActive(true);
                Scroll_Item_MakeItem ui_2 = self.AddChild<Scroll_Item_MakeItem>();
                ui_2.uiTransform = itemSpace.transform;
                ui_2.SetClickAction((int itemid) => { self.OnClickMakeItem(itemid); });
                ui_2.OnUpdateUI(makeList[i]);
                self.MakeListUI.Add(ui_2);
            }

            if (chaptet == 0)
            {
                self.Text_Name.GetComponent<Text>().text = "攻击宝石";
                Scroll_Item_MakeItem item = self.MakeListUI[0];
                self.OnClickMakeItem(item.MakeID);
            }
            else if (chaptet == 1)
            {
                self.Text_Name.GetComponent<Text>().text = "生命宝石";
            }
            else if (chaptet == 2)
            {
                self.Text_Name.GetComponent<Text>().text = "物防宝石";
            }
            else
            {
                self.Text_Name.GetComponent<Text>().text = "魔防宝石";
            }
        }

        public static void SetClickAction(this UIGemChapterComponent self, Action<int> action)
        {
            self.ActionClick = action;
        }

        public static void OnClickMakeItem(this UIGemChapterComponent self, int makeid)
        {
            self.OnSelectMakeItem(makeid);
            self.ActionClick(makeid);
        }

        public static void OnSelectMakeItem(this UIGemChapterComponent self, int makeid)
        {
            //设置选中框
            for (int k = 0; k < self.MakeListUI.Count; k++)
            {
                Scroll_Item_MakeItem item = self.MakeListUI[k];
                item.E_Image_SelectImage.gameObject.SetActive(makeid == item.MakeID);
            }
        }
    }
}