using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UIShouJiTreasureItemComponent))]
    [FriendOf(typeof(UIShouJiTreasureTypeComponent))]
    [EntitySystemOf(typeof(ES_ShouJiTreasure))]
    [FriendOfAttribute(typeof(ES_ShouJiTreasure))]
    public static partial class ES_ShouJiTreasureSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ShouJiTreasure self, Transform transform)
        {
            self.uiTransform = transform;

            ReferenceCollector rc = self.uiTransform.GetComponent<ReferenceCollector>();

            self.TypeListNode = rc.Get<GameObject>("TypeListNode");
            self.UIShouJiTreasureType = rc.Get<GameObject>("UIShouJiTreasureType");
            self.UIShouJiTreasureType.SetActive(false);
            self.ItemListNode = rc.Get<GameObject>("ItemListNode");

            self.Button_Open = new GameObject[3];
            self.Button_Open[2] = self.E_Img_Chest_2_OpenImage.gameObject;
            self.Button_Open[1] = self.E_Img_Chest_2_OpenImage.gameObject;
            self.Button_Open[0] = self.E_Img_Chest_1_OpenImage.gameObject;

            self.Button_Close = new GameObject[3];
            self.Button_Close[2] = self.E_Img_Chest_3_CloseImage.gameObject;
            self.Button_Close[1] = self.E_Img_Chest_2_CloseImage.gameObject;
            self.Button_Close[0] = self.E_Img_Chest_1_CloseImage.gameObject;

            // self.Button_Close[2].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
            //     (pdata) => { self.BeginDrag(pdata as PointerEventData, 3).Coroutine(); });
            // self.Button_Close[2].GetComponent<EventTrigger>()
            //         .RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData, 3); });
            //
            // self.Button_Close[1].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
            //     (pdata) => { self.BeginDrag(pdata as PointerEventData, 2).Coroutine(); });
            // self.Button_Close[1].GetComponent<EventTrigger>()
            //         .RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData, 2); });
            //
            // self.Button_Close[0].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
            //     (pdata) => { self.BeginDrag(pdata as PointerEventData, 1).Coroutine(); });
            // self.Button_Close[0].GetComponent<EventTrigger>()
            //         .RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData, 1); });

            self.TreasureTypeList.Clear();
            self.OnInitTypeList();
        }

        [EntitySystem]
        private static void Destroy(this ES_ShouJiTreasure self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
            self.DestroyWidget();
        }

        public static void OnInitTypeList(this ES_ShouJiTreasure self)
        {
            Dictionary<int, List<int>> keyValuePairs = ShouJiItemConfigCategory.Instance.TreasureList;
            foreach (var item in keyValuePairs.Keys)
            {
                GameObject taskTypeItem = GameObject.Instantiate(self.UIShouJiTreasureType);
                taskTypeItem.SetActive(true);
                CommonViewHelper.SetParent(taskTypeItem, self.TypeListNode);

                UIShouJiTreasureTypeComponent uIItemComponent = self.AddChild<UIShouJiTreasureTypeComponent, GameObject>(taskTypeItem);
                uIItemComponent.OnInitData(item);
                uIItemComponent.SetClickHandler((int typeid) => { self.OnClickType(typeid); });

                self.TreasureTypeList.Add(uIItemComponent);
            }

            UIShouJiTreasureTypeComponent uiShouJiTreasureTypeComponent = self.TreasureTypeList[0];
            uiShouJiTreasureTypeComponent.OnClick();
        }

        public static void OnClickType(this ES_ShouJiTreasure self, int chapter)
        {
            for (int i = 0; i < self.TreasureTypeList.Count; i++)
            {
                UIShouJiTreasureTypeComponent uiShouJiTreasureTypeComponent = self.TreasureTypeList[i];
                uiShouJiTreasureTypeComponent.OnSelected(chapter);
            }

            self.OnUpdateTreasureItemList(chapter);
        }

        public static void OnShouJiTreasure(this ES_ShouJiTreasure self)
        {
            int chapterId = 0;
            for (int i = 0; i < self.TreasureTypeList.Count; i++)
            {
                UIShouJiTreasureTypeComponent uiShouJiTreasureTypeComponent = self.TreasureTypeList[i];
                if (uiShouJiTreasureTypeComponent.Ima_SelectStatus.activeSelf)
                {
                    chapterId = uiShouJiTreasureTypeComponent.Chapter;
                }
            }

            self.OnUpdateTreasureItemList(chapterId);
        }

        private static void UpdateStarInfo(this ES_ShouJiTreasure self, ShouJiConfig shouJiConfig)
        {
            ShoujiComponentC shoujiComponent = self.Root().GetComponent<ShoujiComponentC>();
            int starNum = shoujiComponent.GetChapterStar(shouJiConfig.Id);
            float progress = starNum * 1f / shouJiConfig.ProList3_StartNum;
            progress = Mathf.Min(1f, progress);

            self.E_ImageProgressImage.fillAmount = progress;
            self.E_Text_NameText.text = shouJiConfig.ChapterDes;
            using (zstring.Block())
            {
                self.E_Text_StarNumText.text = zstring.Format("{0}/{1}", starNum, shouJiConfig.ProList3_StartNum);
            }

            self.E_Text_Star1Text.text = shouJiConfig.ProList1_StartNum.ToString();
            self.E_Text_Star2Text.text = shouJiConfig.ProList2_StartNum.ToString();
            self.E_Text_Star3Text.text = shouJiConfig.ProList3_StartNum.ToString();

            self.E_Text_Attribute1Text.text = self.GetAttributeDesc(shouJiConfig.ProList1_Type, shouJiConfig.ProList1_Value);
            self.E_Text_Attribute2Text.text = self.GetAttributeDesc(shouJiConfig.ProList2_Type, shouJiConfig.ProList2_Value);
            self.E_Text_Attribute3Text.text = self.GetAttributeDesc(shouJiConfig.ProList3_Type, shouJiConfig.ProList3_Value);
            
            CommonViewHelper.SetImageGray(self.Root(), self.Button_Close[0], starNum < shouJiConfig.ProList1_StartNum);
            CommonViewHelper.SetImageGray(self.Root(), self.Button_Close[1], starNum < shouJiConfig.ProList2_StartNum);
            CommonViewHelper.SetImageGray(self.Root(), self.Button_Close[2], starNum < shouJiConfig.ProList3_StartNum);
        }

        private static string GetAttributeDesc(this ES_ShouJiTreasure self, int[] type, long[] value)
        {
            string attributeStr = string.Empty;
            for (int i = 0; i < type.Length; i++)
            {
                int numericType = type[i];

                if (NumericHelp.GetNumericValueType(numericType) == 2)
                {
                    float fvalue = value[i];
                    string svalue = fvalue.ToString("0.#####");
                    attributeStr += string.Format("{0} {1}% ", ItemViewHelp.GetAttributeName(numericType), svalue);
                }
                else
                {
                    attributeStr += string.Format("提升{0}{1}点", ItemViewHelp.GetAttributeName(numericType), value[i]);
                }

                if (i < type.Length - 1)
                {
                    attributeStr += "\n";
                }
            }

            return attributeStr;
        }

        public static void OnUpdateTreasureItemList(this ES_ShouJiTreasure self, int chapter)
        {
            self.ChapterId = 20000 + chapter;

            ShouJiConfig shouJiConfig = ShouJiConfigCategory.Instance.Get(self.ChapterId);
            self.UpdateStarInfo(shouJiConfig);

            List<int> shouList = ShouJiItemConfigCategory.Instance.TreasureList[chapter];
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < shouList.Count; i++)
            {
                UIShouJiTreasureItemComponent uIShouJiTreasureItem = null;
                if (i < self.TreasureItemList.Count)
                {
                    uIShouJiTreasureItem = self.TreasureItemList[i];
                    uIShouJiTreasureItem.GameObject.SetActive(true);
                }
                else
                {
                    string path = ABPathHelper.GetUGUIPath("Item/UIShouJiTreasureItem");
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    var bundleGameObject = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject taskTypeItem = UnityEngine.Object.Instantiate(bundleGameObject, self.ItemListNode.transform);
                    taskTypeItem.SetActive(true);
                    uIShouJiTreasureItem = self.AddChild<UIShouJiTreasureItemComponent, GameObject>(taskTypeItem);
                    self.TreasureItemList.Add(uIShouJiTreasureItem);
                }

                uIShouJiTreasureItem.OnInitUI(shouList[i]);
            }

            for (int i = shouList.Count; i < self.TreasureItemList.Count; i++)
            {
                UIShouJiTreasureItemComponent uiShouJiTreasureItemComponent = self.TreasureItemList[i];
                uiShouJiTreasureItemComponent.GameObject.SetActive(false);
            }
        }

        public static void UpdateRedDot(this ES_ShouJiTreasure self)
        {
            foreach (UIShouJiTreasureTypeComponent uiShouJiTreasureTypeComponent in self.TreasureTypeList)
            {
                uiShouJiTreasureTypeComponent.UpdateRedDot();
            }

            ShouJiConfig shouJiConfig = ShouJiConfigCategory.Instance.Get(self.ChapterId);
            self.UpdateStarInfo(shouJiConfig);
        }
    }
}