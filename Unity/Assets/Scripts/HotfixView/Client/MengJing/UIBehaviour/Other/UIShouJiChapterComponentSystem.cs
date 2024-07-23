using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIShouJiChapterComponent))]
    [EntitySystemOf(typeof(UIShouJiChapterComponent))]
    public static partial class UIShouJiChapterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIShouJiChapterComponent self, GameObject go)
        {
            self.GameObject = go;

            self.ImageProgress = go.Get<GameObject>("ImageProgress");
            self.ItemNode = go.Get<GameObject>("ItemNode");
            self.Text_Attribute3 = go.Get<GameObject>("Text_Attribute3");
            self.Text_Attribute2 = go.Get<GameObject>("Text_Attribute2");
            self.Text_Attribute1 = go.Get<GameObject>("Text_Attribute1");
            self.Text_Star3 = go.Get<GameObject>("Text_Star3");
            self.Text_Star2 = go.Get<GameObject>("Text_Star2");
            self.Text_Star1 = go.Get<GameObject>("Text_Star1");
            self.Text_StarNum = go.Get<GameObject>("Text_StarNum");
            self.Text_Name = go.Get<GameObject>("Text_Name");

            self.Button_Open = new GameObject[3];
            self.Button_Open[2] = go.Get<GameObject>("Img_Chest_3_Open");
            self.Button_Open[1] = go.Get<GameObject>("Img_Chest_2_Open");
            self.Button_Open[0] = go.Get<GameObject>("Img_Chest_1_Open");

            self.Button_Close = new GameObject[3];
            self.Button_Close[2] = go.Get<GameObject>("Img_Chest_3_Close");
            self.Button_Close[1] = go.Get<GameObject>("Img_Chest_2_Close");
            self.Button_Close[0] = go.Get<GameObject>("Img_Chest_1_Close");

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
        }

        public static async ETTask BeginDrag(this UIShouJiChapterComponent self, PointerEventData pdata, int index)
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

        public static void EndDrag(this UIShouJiChapterComponent self, PointerEventData pdata, int index)
        {
            self.OnBtn_Reward_Type(index);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CountryTips);
        }

        public static void OnBtn_Reward_Type(this UIShouJiChapterComponent self, int index)
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

        public static void UpdateStarInfo(this UIShouJiChapterComponent self, ShouJiConfig shouJiConfig)
        {
            ShoujiComponentC shoujiComponent = self.Root().GetComponent<ShoujiComponentC>();
            int starNum = shoujiComponent.GetChapterStar(shouJiConfig.Id);
            float progress = starNum * 1f / shouJiConfig.ProList3_StartNum;
            progress = Mathf.Min(1f, progress);

            self.ImageProgress.GetComponent<Image>().fillAmount = progress;
            self.Text_Name.GetComponent<Text>().text = shouJiConfig.ChapterDes;
            using (zstring.Block())
            {
                self.Text_StarNum.GetComponent<Text>().text = zstring.Format("{0}/{1}", starNum, shouJiConfig.ProList3_StartNum);
            }

            self.Text_Star1.GetComponent<Text>().text = shouJiConfig.ProList1_StartNum.ToString();
            self.Text_Star2.GetComponent<Text>().text = shouJiConfig.ProList2_StartNum.ToString();
            self.Text_Star3.GetComponent<Text>().text = shouJiConfig.ProList3_StartNum.ToString();
            self.Text_Attribute1.GetComponent<Text>().text = ItemViewHelp.GetAttributeDesc(shoujiComponent.GetChapterPro(shouJiConfig.Id, 1));
            self.Text_Attribute2.GetComponent<Text>().text = ItemViewHelp.GetAttributeDesc(shoujiComponent.GetChapterPro(shouJiConfig.Id, 2));
            self.Text_Attribute3.GetComponent<Text>().text = ItemViewHelp.GetAttributeDesc(shoujiComponent.GetChapterPro(shouJiConfig.Id, 3));
        }

        public static async ETTask OnInitUI(this UIShouJiChapterComponent self, ShouJiConfig shouJiConfig)
        {
            self.ChapterId = shouJiConfig.Id;
            self.UpdateStarInfo(shouJiConfig);
            var path = ABPathHelper.GetUGUIPath("Item/UIShouJiItem");
            var bundleGameObject = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            int itemNum = 0;
            int itemId = shouJiConfig.ItemListID;
            long instanceId = self.InstanceId;

            int testId = itemId;
            while (testId != 0)
            {
                itemNum++;
                ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(testId);
                testId = shouJiItemConfig.NextID;
            }

            int row = (itemNum / 7);
            row += (itemNum % 7 > 0 ? 1 : 0);
            self.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1600f, 200 + row * 270f);

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (itemId != 0)
            {
                if (itemNum % 7 == 0)
                {
                    await timerComponent.WaitFrameAsync();
                }

                if (instanceId != self.InstanceId)
                {
                    return;
                }

                GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
                CommonViewHelper.SetParent(go, self.ItemNode);
                ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(itemId);
                self.AddChild<UIShouJiItemComponent, GameObject>(go).OnUpdateUI(shouJiConfig.Id, shouJiItemConfig);
                itemId = shouJiItemConfig.NextID;
            }
        }
    }
}