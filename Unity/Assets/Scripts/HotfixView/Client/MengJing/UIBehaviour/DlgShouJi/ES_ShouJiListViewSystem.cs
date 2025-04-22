using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIShouJiItemComponent))]
    [EntitySystemOf(typeof(ES_ShouJiList))]
    [FriendOfAttribute(typeof(ES_ShouJiList))]
    public static partial class ES_ShouJiListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ShouJiList self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BtnItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.UpdateToggleGroupInfo();

            self.Button_Open = new GameObject[3];
            self.Button_Open[2] = self.E_Img_Chest_3_OpenImage.gameObject;
            self.Button_Open[1] = self.E_Img_Chest_2_OpenImage.gameObject;
            self.Button_Open[0] = self.E_Img_Chest_1_OpenImage.gameObject;

            self.Button_Close = new GameObject[3];
            self.Button_Close[2] = self.E_Img_Chest_3_CloseImage.gameObject;
            self.Button_Close[1] = self.E_Img_Chest_2_CloseImage.gameObject;
            self.Button_Close[0] = self.E_Img_Chest_1_CloseImage.gameObject;

            self.Button_Close[2].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData, 3).Coroutine(); });
            self.Button_Close[2].GetComponent<EventTrigger>()
                    .RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData, 3); });

            self.Button_Close[1].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData, 2).Coroutine(); });
            self.Button_Close[1].GetComponent<EventTrigger>()
                    .RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData, 2); });

            self.Button_Close[0].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData, 1).Coroutine(); });
            self.Button_Close[0].GetComponent<EventTrigger>()
                    .RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData, 1); });

            self.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_ShouJiList self)
        {
            self.Button_Open = null;
            self.Button_Close = null;
            self.UIShouJiItemComponents.Clear();
            self.UIShouJiItemComponents = null;
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_ShouJiList self, int index)
        {
            self.OnUpdateUI(index);
        }

        private static async ETTask BeginDrag(this ES_ShouJiList self, PointerEventData pdata, int index)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CountryTips);
            DlgCountryTips dlgCountryTips = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCountryTips>();

            Vector2 localPoint;
            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            ShouJiConfig shouJiConfig = ShouJiConfigCategory.Instance.Get(self.ChapterId);
            string rewards = "";
            if (index == 3) rewards = shouJiConfig.RewardList_3;
            if (index == 2) rewards = shouJiConfig.RewardList_2;
            if (index == 1) rewards = shouJiConfig.RewardList_1;
            dlgCountryTips.OnUpdateUI(rewards, new Vector3(localPoint.x, localPoint.y, 0f));
        }

        private static void EndDrag(this ES_ShouJiList self, PointerEventData pdata, int index)
        {
            self.OnBtn_Reward_Type(index);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CountryTips);
        }

        private static void OnBtn_Reward_Type(this ES_ShouJiList self, int index)
        {
            ShouJiConfig shouJiConfig = ShouJiConfigCategory.Instance.Get(self.ChapterId);
            ShouJiChapterInfo shouJiChapterInfo = self.Root().GetComponent<ShoujiComponentC>().GetShouJiChapterInfo(self.ChapterId);
            if (shouJiChapterInfo == null)
            {
                return;
            }

            if ((shouJiChapterInfo.RewardInfo & 1 << index) > 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("奖励已领取！");
                return;
            }

            if (index == 1 && shouJiChapterInfo.StarNum < shouJiConfig.ProList1_StartNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("条件不足！");
                return;
            }

            if (index == 2 && shouJiChapterInfo.StarNum < shouJiConfig.ProList2_StartNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("条件不足！");
                return;
            }

            if (index == 3 && shouJiChapterInfo.StarNum < shouJiConfig.ProList3_StartNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("条件不足！");
                return;
            }

            ShoujiNetHelper.ShoujiReward(self.Root(), self.ChapterId, index).Coroutine();
        }

        private static void OnUpdateUI(this ES_ShouJiList self, int index)
        {
            List<ShouJiConfig> shouJiConfigs = ShouJiConfigCategory.Instance.GetAll().Values.ToList();
            ShouJiConfig shouJiConfig = shouJiConfigs[index];
            self.ChapterId = shouJiConfig.Id;

            self.UpdateStarInfo(shouJiConfig);

            List<ShouJiItemConfig> itemList = new();

            int itemId = shouJiConfig.ItemListID;
            while (itemId != 0)
            {
                ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(itemId);
                itemList.Add(shouJiItemConfig);
                itemId = shouJiItemConfig.NextID;
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < itemList.Count; i++)
            {
                if (i >= self.UIShouJiItemComponents.Count)
                {
                    string path = ABPathHelper.GetUGUIPath("Item/UIShouJiItem");
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    var bundleGameObject = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject,
                        self.E_ScrollViewScrollRect.transform.Find("Viewport/Content").gameObject.transform);
                    self.UIShouJiItemComponents.Add(self.AddChild<UIShouJiItemComponent, GameObject>(gameObject));
                }

                UIShouJiItemComponent uiShouJiItemComponent = self.UIShouJiItemComponents[i];
                uiShouJiItemComponent.GameObject.SetActive(true);
                uiShouJiItemComponent.OnUpdateUI(shouJiConfig.Id, itemList[i]);
            }

            for (int i = itemList.Count; i < self.UIShouJiItemComponents.Count; i++)
            {
                UIShouJiItemComponent uiShouJiItemComponent = self.UIShouJiItemComponents[i];
                uiShouJiItemComponent.GameObject.SetActive(false);
            }
        }

        private static void UpdateToggleGroupInfo(this ES_ShouJiList self)
        {
            List<ShouJiConfig> shouJiConfigs = ShouJiConfigCategory.Instance.GetAll().Values.ToList();
            ShoujiComponentC shoujiComponent = self.Root().GetComponent<ShoujiComponentC>();

            for (int i = 0; i < shouJiConfigs.Count; i++)
            {
                if (i < self.E_BtnItemTypeSetToggleGroup.transform.childCount)
                {
                    Transform transform = self.E_BtnItemTypeSetToggleGroup.transform.GetChild(i).Find("StarText");
                    int starNum = shoujiComponent.GetChapterStar(shouJiConfigs[i].Id);
                    
                    transform.GetComponent<Text>().text = $"({starNum}/{shouJiConfigs[i].ProList3_StartNum})";
                }
            }
        }

        private static void UpdateStarInfo(this ES_ShouJiList self, ShouJiConfig shouJiConfig)
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
            self.E_Text_Attribute1Text.text = ItemViewHelp.GetAttributeDesc(shoujiComponent.GetChapterPro(shouJiConfig.Id, 1));
            self.E_Text_Attribute2Text.text = ItemViewHelp.GetAttributeDesc(shoujiComponent.GetChapterPro(shouJiConfig.Id, 2));
            self.E_Text_Attribute3Text.text = ItemViewHelp.GetAttributeDesc(shoujiComponent.GetChapterPro(shouJiConfig.Id, 3));

            // ShouJiChapterInfo shouJiChapterInfo = shoujiComponent.GetShouJiChapterInfo(self.ChapterId);
            // if (shouJiChapterInfo == null)
            // {
            //     return;
            // }
            //
            // CommonViewHelper.SetImageGray(self.Root(), self.Button_Close[0], shouJiChapterInfo.StarNum < shouJiConfig.ProList1_StartNum);
            // CommonViewHelper.SetImageGray(self.Root(), self.Button_Close[1], shouJiChapterInfo.StarNum < shouJiConfig.ProList2_StartNum);
            // CommonViewHelper.SetImageGray(self.Root(), self.Button_Close[2], shouJiChapterInfo.StarNum < shouJiConfig.ProList3_StartNum);
        }
    }
}