using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UITypeButtonComponent))]
    [FriendOf(typeof(UITypeViewComponent))]
    [EntitySystemOf(typeof(UITypeViewComponent))]
    public static partial class UITypeViewComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UITypeViewComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            self.TypeButtonComponents.Clear();
        }

        public static async ETTask OnInitUI(this UITypeViewComponent self, int page = 0, int subPage = 0)
        {
            long instanceid = self.InstanceId;
            GameObject bundleObj = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(self.TypeButtonAsset);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            for (int i = 0; i < self.TypeButtonInfos.Count; i++)
            {
                GameObject taskTypeItem = UnityEngine.Object.Instantiate(bundleObj);
                CommonViewHelper.SetParent(taskTypeItem, self.GameObject);

                UITypeButtonComponent uIItemComponent = self.AddChild<UITypeButtonComponent, GameObject>(taskTypeItem);
                uIItemComponent.TypeItemAsset = self.TypeButtonItemAsset;
                uIItemComponent.OnUpdateData(self.TypeButtonInfos[i], subPage);
                uIItemComponent.SetClickTypeHandler((int typeid) => { self.OnClickType(typeid); });
                uIItemComponent.SetClickTypeItemHandler((int typeid, int chapterId) => { self.OnClickTypeItem(typeid, chapterId); });

                self.TypeButtonComponents.Add(uIItemComponent);
            }

            self.TypeButtonComponents[page].OnClickTypeButton();
        }

        public static void OnClickType(this UITypeViewComponent self, int typeid)
        {
            if (!self.CanClick)
            {
                return;
            }
            
            for (int i = 0; i < self.TypeButtonComponents.Count; i++)
            {
                self.TypeButtonComponents[i].SetSelected(typeid).Coroutine();
            }
        }

        public static void OnClickTypeItem(this UITypeViewComponent self, int typeid, int chapterId)
        {
            self.ClickTypeItemHandler(typeid, chapterId);
        }
    }

    [FriendOf(typeof(UITypeButtonItemComponent))]
    [FriendOf(typeof(UITypeButtonComponent))]
    [EntitySystemOf(typeof(UITypeButtonComponent))]
    public static partial class UITypeButtonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UITypeButtonComponent self, GameObject gameObject)
        {
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
            self.GameObject = gameObject;
            self.UIPointTaskDate = rc.Get<GameObject>("UIPointTaskDate");
            self.ImageButton = rc.Get<GameObject>("ImageButton");
            
            self.ImageSelect_1 = rc.Get<GameObject>("ImageSelect_1");
            self.TaskTypeName_1 =  rc.Get<GameObject>("TaskTypeName_1");  
            self.ImageSelect_0 = rc.Get<GameObject>("ImageSelect_0");
            self.TaskTypeName_0 =  rc.Get<GameObject>("TaskTypeName_0");  
            
            self.ImageButton.GetComponent<Button>().onClick.AddListener(self.OnClickTypeButton);

            self.TypeItemUIList.Clear();
            self.bSelected = false;
        }

        public static async ETTask SetSelected(this UITypeButtonComponent self, int typeid)
        {
            if (self.TypeId != typeid)
            {
                self.bSelected = false;
            }

            if (self.TypeId == typeid)
            {
                self.bSelected = !self.bSelected;
            }

            for (int i = 0; i < self.TypeItemUIList.Count; i++)
            {
                UITypeButtonItemComponent ui = self.TypeItemUIList[i];
                ui.GameObject.SetActive(false);
            }
            
            self.ImageSelect_0.SetActive(!self.bSelected);
            self.ImageSelect_1.SetActive(self.bSelected);

            if (!self.bSelected)
            {
                self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(self.Height, self.Spacing);
                self.GameObject.transform.parent.gameObject.SetActive(false);
                self.GameObject.transform.parent.gameObject.SetActive(true);
                self.ImageButton.transform.localScale = Vector3.one;
                return;
            }

            self.ImageButton.transform.localScale = new Vector3(1f, -1f, 1f);
            long instanceid = self.InstanceId;
            GameObject bundleObj = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(self.TypeItemAsset);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            List<TypeButtonItem> TypeButtonItems = self.TypeButtonInfo.typeButtonItems;
            for (int i = 0; i < TypeButtonItems.Count; i++)
            {
                UITypeButtonItemComponent ui_1 = null;
                if (i < self.TypeItemUIList.Count)
                {
                    ui_1 = self.TypeItemUIList[i];
                    ui_1.GameObject.SetActive(true);
                }
                else
                {
                    GameObject taskTypeItem = UnityEngine.Object.Instantiate(bundleObj);
                    CommonViewHelper.SetParent(taskTypeItem, self.UIPointTaskDate);
                    taskTypeItem.transform.localPosition = new Vector3(0f, i * self.Spacing * -1, 0f);

                    ui_1 = self.AddChild<UITypeButtonItemComponent, GameObject>(taskTypeItem);
                    ui_1.SetClickSubTypeHandler((int chapterid) => { self.OnClickTaskTypeItem(chapterid); });
                    self.TypeItemUIList.Add(ui_1);
                }

                ui_1.OnUpdateData(TypeButtonItems[i]);
            }

            self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(self.Height, self.Spacing + self.Spacing * TypeButtonItems.Count);
            self.GameObject.transform.parent.gameObject.SetActive(false);
            self.GameObject.transform.parent.gameObject.SetActive(true);
            if (TypeButtonItems.Count > 0)
            {
                UITypeButtonItemComponent ui = self.TypeItemUIList[self.SubPage];
                ui.OnClickButtoin();
                self.SubPage = 0;
            }
        }

        public static void OnUpdateData(this UITypeButtonComponent self, TypeButtonInfo typeinfo, int subPage = 0)
        {
            self.SubPage = subPage;
            self.TypeId = typeinfo.TypeId;
            self.TypeButtonInfo = typeinfo;

            self.TaskTypeName_1.GetComponent<Text>().text = typeinfo.TypeName;
            self.TaskTypeName_0.GetComponent<Text>().text = typeinfo.TypeName;
        }

        public static void SetClickTypeHandler(this UITypeButtonComponent self, Action<int> action)
        {
            self.ClickTypeHandler = action;
        }

        public static void SetClickTypeItemHandler(this UITypeButtonComponent self, Action<int, int> action)
        {
            self.ClickTypeItemHandler = action;
        }

        public static void OnClickTypeButton(this UITypeButtonComponent self)
        {
            self.ClickTypeHandler(self.TypeId);
        }

        public static void OnClickTaskTypeItem(this UITypeButtonComponent self, int chapterid)
        {
            if (!self.GetParent<UITypeViewComponent>().CanClick)
            {
                return;
            }

            for (int i = 0; i < self.TypeItemUIList.Count; i++)
            {
                UITypeButtonItemComponent ui = self.TypeItemUIList[i];
                ui.SetSelected(chapterid);
            }

            self.ClickTypeItemHandler(self.TypeId, chapterid);
        }
    }

    [FriendOf(typeof(UITypeButtonItemComponent))]
    [EntitySystemOf(typeof(UITypeButtonItemComponent))]
    public static partial class UITypeButtonItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UITypeButtonItemComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.Lab_TaskName = rc.Get<GameObject>("Lab_TaskName");
            self.Ima_Di = rc.Get<GameObject>("Ima_Di");
            self.Ima_SelectStatus = rc.Get<GameObject>("Ima_SelectStatus");
            self.Ima_Di.GetComponent<Button>().onClick.AddListener(() => { self.OnClickButtoin(); });
        }

        public static void SetSelected(this UITypeButtonItemComponent self, int subTypeid)
        {
            self.Ima_SelectStatus.SetActive(subTypeid == self.SubTypeId);
        }

        public static void SetClickSubTypeHandler(this UITypeButtonItemComponent self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnUpdateData(this UITypeButtonItemComponent self, TypeButtonItem typeItem)
        {
            self.SubTypeId = typeItem.SubTypeId;
            self.Lab_TaskName.GetComponent<Text>().text = typeItem.ItemName;
        }

        public static void OnClickButtoin(this UITypeButtonItemComponent self)
        {
            self.ClickHandler(self.SubTypeId);
        }
    }
}