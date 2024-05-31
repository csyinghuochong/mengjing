using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UIPaiMaiShopTypeComponent))]
    [EntitySystemOf(typeof (UIPaiMaiShopTypeComponent))]
    public static partial class UIPaiMaiShopTypeComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIPaiMaiShopTypeComponent self, GameObject gameObject)
        {
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.GameObject = gameObject;
            self.UIPointTaskDate = rc.Get<GameObject>("UIPointTaskDate");
            self.UIPaiMaiShopTypeItem = rc.Get<GameObject>("UIPaiMaiShopTypeItem");
            self.UIPaiMaiShopTypeItem.SetActive(false);
            self.TaskTypeName = rc.Get<GameObject>("TaskTypeName");
            self.ImageButton = rc.Get<GameObject>("ImageButton");
            self.ImageButton.GetComponent<Button>().onClick.AddListener(() => { self.OnClickTypeButton(); });

            self.bSelected = false;
        }

        public static async ETTask SetSelected(this UIPaiMaiShopTypeComponent self, int typeid)
        {
            if (self.TypeId != typeid)
            {
                self.bSelected = false;
            }

            if (self.TypeId == typeid && self.bSelected)
            {
                self.bSelected = false;
            }

            if (self.TypeId == typeid && !self.bSelected)
            {
                self.bSelected = true;
            }

            for (int i = 0; i < self.UITaskTypeItemList.Count; i++)
            {
                self.UITaskTypeItemList[i].GameObject.SetActive(false);
            }

            if (!self.bSelected)
            {
                self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500f, 80f);
                self.GameObject.transform.parent.gameObject.SetActive(false);
                self.GameObject.transform.parent.gameObject.SetActive(true);
                return;
            }

            List<int> ids = PaiMaiHelper.GetChaptersByType((PaiMaiTypeEnum)self.TypeId);
            await ETTask.CompletedTask;

            for (int i = 0; i < ids.Count; i++)
            {
                UIPaiMaiShopTypeItemComponent itemComponent = null;
                if (i < self.UITaskTypeItemList.Count)
                {
                    itemComponent = self.UITaskTypeItemList[i];
                    itemComponent.GameObject.SetActive(true);
                }
                else
                {
                    GameObject go = UnityEngine.Object.Instantiate(self.UIPaiMaiShopTypeItem);
                    go.SetActive(true);
                    UICommonHelper.SetParent(go, self.UIPointTaskDate);
                    go.transform.localPosition = new Vector3(0f, i * -80f, 0f);

                    itemComponent = self.AddChild<UIPaiMaiShopTypeItemComponent, GameObject>(go);
                    itemComponent.SetClickSubTypeHandler((int chapterid) => { self.OnClickTaskTypeItem(chapterid); });
                    self.UITaskTypeItemList.Add(itemComponent);
                }

                itemComponent.OnUpdateData(self.TypeId, ids[i]);
            }

            self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500f, 80f + 80f * ids.Count);
            self.GameObject.transform.parent.gameObject.SetActive(false);
            self.GameObject.transform.parent.gameObject.SetActive(true);
            if (ids.Count > 0)
            {
                self.UITaskTypeItemList[0].OnClickButtoin();
            }
        }

        public static void OnUpdateData(this UIPaiMaiShopTypeComponent self, int typeId)
        {
            self.TypeId = typeId;

            self.TaskTypeName.GetComponent<Text>().text = PaiMaiData.PaiMaiTypeText[typeId];
        }

        public static void SetClickTypeHandler(this UIPaiMaiShopTypeComponent self, Action<int> action)
        {
            self.ClickTypeHandler = action;
        }

        public static void SetClickTypeItemHandler(this UIPaiMaiShopTypeComponent self, Action<int, int> action)
        {
            self.ClickTypeItemHandler = action;
        }

        public static void OnClickTypeButton(this UIPaiMaiShopTypeComponent self)
        {
            self.ClickTypeHandler(self.TypeId);
        }

        public static void OnClickTaskTypeItem(this UIPaiMaiShopTypeComponent self, int chapterid)
        {
            for (int i = 0; i < self.UITaskTypeItemList.Count; i++)
            {
                self.UITaskTypeItemList[i].SetSelected(chapterid);
            }

            self.ClickTypeItemHandler(self.TypeId, chapterid);
        }
    }
}