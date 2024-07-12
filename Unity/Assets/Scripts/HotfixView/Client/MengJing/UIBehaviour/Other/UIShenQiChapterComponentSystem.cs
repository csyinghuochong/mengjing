using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MakeItem))]
    [FriendOf(typeof(UIShenQiChapterComponent))]
    [EntitySystemOf(typeof(UIShenQiChapterComponent))]
    public static partial class UIShenQiChapterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIShenQiChapterComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            self.MakeListUI.Clear();

            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
            self.ItemNode = rc.Get<GameObject>("ItemNode");
            self.Text_Name = rc.Get<GameObject>("Text_Name");
        }

        public static void OnInitUI(this UIShenQiChapterComponent self, int chaptet, List<int> makeList)
        {
            int row = (makeList.Count / 5);
            row += (makeList.Count % 5 > 0 ? 1 : 0);
            self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 100f + row * 170f);

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
                self.Text_Name.GetComponent<Text>().text = $"生肖";
                Scroll_Item_MakeItem item = self.MakeListUI[0];
                self.OnClickMakeItem(item.MakeID);
            }
            else if (chaptet == 6)
            {
                self.Text_Name.GetComponent<Text>().text = $"传承";
                //self.OnClickMakeItem(self.MakeListUI[0].MakeID);
            }
            else
            {
                self.Text_Name.GetComponent<Text>().text = $"第{chaptet}章";
            }
        }

        public static void SetClickAction(this UIShenQiChapterComponent self, Action<int> action)
        {
            self.ActionClick = action;
        }

        public static void OnClickMakeItem(this UIShenQiChapterComponent self, int makeid)
        {
            self.OnSelectMakeItem(makeid);
            self.ActionClick(makeid);
        }

        public static void OnSelectMakeItem(this UIShenQiChapterComponent self, int makeid)
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