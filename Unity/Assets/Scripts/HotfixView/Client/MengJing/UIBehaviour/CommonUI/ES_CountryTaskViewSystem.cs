using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CountryTaskItem))]
    [EntitySystemOf(typeof (ES_CountryTask))]
    [FriendOfAttribute(typeof (ES_CountryTask))]
    public static partial class ES_CountryTaskSystem
    {
        [EntitySystem]
        private static void Awake(this ES_CountryTask self, Transform transform)
        {
            self.uiTransform = transform;

            self.Button_Open = new GameObject[4];
            self.Button_Open[0] = self.E_Button_Open_1Image.gameObject;
            self.Button_Open[1] = self.E_Button_Open_2Image.gameObject;
            self.Button_Open[2] = self.E_Button_Open_3Image.gameObject;
            self.Button_Open[3] = self.E_Button_Open_4Image.gameObject;

            self.Text_Huoyue = new GameObject[4];
            self.Text_Huoyue[0] = self.E_Text_Huoyue1Text.gameObject;
            self.Text_Huoyue[1] = self.E_Text_Huoyue2Text.gameObject;
            self.Text_Huoyue[2] = self.E_Text_Huoyue3Text.gameObject;
            self.Text_Huoyue[3] = self.E_Text_Huoyue4Text.gameObject;

            self.Button_Reward = new GameObject[4];
            self.Button_Reward[3] = self.E_Button_4Button.gameObject;
            self.Button_Reward[2] = self.E_Button_3Button.gameObject;
            self.Button_Reward[1] = self.E_Button_2Button.gameObject;
            self.Button_Reward[0] = self.E_Button_1Button.gameObject;

            self.Button_Reward[3].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData, 4).Coroutine(); });
            self.Button_Reward[3].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(pdata as PointerEventData, 4); });

            self.Button_Reward[2].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData, 3).Coroutine(); });
            self.Button_Reward[2].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(pdata as PointerEventData, 3); });

            self.Button_Reward[1].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData, 2).Coroutine(); });
            self.Button_Reward[1].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(pdata as PointerEventData, 2); });

            self.Button_Reward[0].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData, 1).Coroutine(); });
            self.Button_Reward[0].GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(pdata as PointerEventData, 1); });

            self.E_CountryTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCountryTaskItemsRefresh);
            self.E_Button_1Button.AddListener(self.OnButton_1Button);
            self.E_Button_2Button.AddListener(self.OnButton_2Button);
            self.E_Button_3Button.AddListener(self.OnButton_3Button);
            self.E_Button_4Button.AddListener(self.OnButton_4Button);
        }

        [EntitySystem]
        private static void Destroy(this ES_CountryTask self)
        {
            self.DestroyWidget();
        }

        public static async ETTask BeginDrag(this ES_CountryTask self, PointerEventData pdata, int index)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CountryTips);

            Vector2 localPoint;
            RectTransform canvas = self.uiTransform.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            HuoYueRewardConfig huoYueRewardConfig = HuoYueRewardConfigCategory.Instance.Get(index);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCountryTips>()
                    .OnUpdateUI(huoYueRewardConfig.RewardItems, new Vector3(localPoint.x, localPoint.y, 0f));
        }

        public static void EndDrag(this ES_CountryTask self, PointerEventData pdata, int index)
        {
            self.OnBtn_Reward_Type(index).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CountryTips);
        }

        public static async ETTask OnBtn_Reward_Type(this ES_CountryTask self, int index)
        {
            long haveHuoyue = self.Root().GetComponent<TaskComponentC>().GetHuoYueDu();
            HuoYueRewardConfig huoYueRewardConfig = HuoYueRewardConfigCategory.Instance.Get(index);
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            if (haveHuoyue < huoYueRewardConfig.NeedPoint)
            {
                FlyTipComponent.Instance.ShowFlyTip("活跃度不足！");
                return;
            }

            if (taskComponent.ReceiveHuoYueIds.Contains(index))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取过该奖励！");
                return;
            }

            if (!self.Root().GetComponent<BagComponentC>().CheckAddItemData(huoYueRewardConfig.RewardItems))
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int maxPiLao = unit.GetMaxPiLao();
            long nowPiLao = self.Root().GetComponent<UserInfoComponentC>().UserInfo.PiLao;

            if (maxPiLao < nowPiLao + 10)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "领取", "是否领取?\n领取后会有体力溢出!", async () =>
                {
                    int errorcode = await TaskClientNetHelper.TaskHuoYueRewardRequest(self.Root(), index);
                    if (errorcode != ErrorCode.ERR_Success)
                    {
                        await TaskClientNetHelper.RequestTaskInit(self.Root());
                    }

                    self.UpdateHuoYueReward();
                }).Coroutine();
            }
            else
            {
                int errorcode = await TaskClientNetHelper.TaskHuoYueRewardRequest(self.Root(), index);
                if (errorcode != ErrorCode.ERR_Success)
                {
                    await TaskClientNetHelper.RequestTaskInit(self.Root());
                }

                self.UpdateHuoYueReward();
            }
        }

        public static void OnTaskCountryUpdate(this ES_CountryTask self)
        {
            self.UpdateTaskCountrys();
        }

        private static void OnCountryTaskItemsRefresh(this ES_CountryTask self, Transform transform, int index)
        {
            foreach (Scroll_Item_CountryTaskItem item in self.ScrollItemCountryTaskItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CountryTaskItem scrollItemCountryTaskItem = self.ScrollItemCountryTaskItems[index].BindTrans(transform);
            scrollItemCountryTaskItem.OnUpdateData(self.ShowTaskPros[index]);
        }

        public static void UpdateTaskCountrys(this ES_CountryTask self)
        {
            List<TaskPro> taskPros = self.Root().GetComponent<TaskComponentC>().RoleTaskList;

            taskPros.Sort(delegate(TaskPro a, TaskPro b)
            {
                int commita = a.taskStatus == (int)TaskStatuEnum.Commited? 1 : 0;
                int commitb = b.taskStatus == (int)TaskStatuEnum.Commited? 1 : 0;
                int completea = a.taskStatus == (int)TaskStatuEnum.Completed? 1 : 0;
                int completeb = b.taskStatus == (int)TaskStatuEnum.Completed? 1 : 0;

                if (commita == commitb)
                    return completeb - completea; //可以领取的在前
                else
                    return commitb - commita; //已经完成的在前
            });

            self.ShowTaskPros.Clear();
            for (int i = 0; i < taskPros.Count; i++)
            {
                TaskConfig taskConfig = TaskConfigCategory.Instance.Get(taskPros[i].taskID);
                if (taskConfig.TaskType != TaskTypeEnum.Country)
                {
                    continue;
                }

                self.ShowTaskPros.Add(taskPros[i]);
            }


            self.AddUIScrollItems(ref self.ScrollItemCountryTaskItems, self.ShowTaskPros.Count);
            self.E_CountryTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPros.Count);

            long haveHuoyue = self.Root().GetComponent<TaskComponentC>().GetHuoYueDu();
            int totalHuoyue = HuoYueRewardConfigCategory.Instance.Get(4).NeedPoint;
            self.E_Text_DayHuoYueText.text = haveHuoyue.ToString();
            self.E_Image_progressvalueImage.fillAmount = haveHuoyue * 1f / totalHuoyue;
        }

        public static void UpdateHuoYueReward(this ES_CountryTask self)
        {
            List<int> getids = self.Root().GetComponent<TaskComponentC>().ReceiveHuoYueIds;

            for (int i = 0; i < self.Button_Open.Length; i++)
            {
                self.Button_Reward[i].SetActive(!getids.Contains(i + 1));
                self.Button_Open[i].SetActive(getids.Contains(i + 1));
                using (zstring.Block())
                {
                    self.Text_Huoyue[i].GetComponent<Text>().text =
                            zstring.Format("{0}活跃度", HuoYueRewardConfigCategory.Instance.Get(i + 1).NeedPoint);
                }
            }
        }

        public static void OnUpdateUI(this ES_CountryTask self)
        {
            self.UpdateTaskCountrys();
            self.UpdateHuoYueReward();
        }
        public static void OnButton_1Button(this ES_CountryTask self)
        {
        }
        public static void OnButton_2Button(this ES_CountryTask self)
        {
        }
        public static void OnButton_3Button(this ES_CountryTask self)
        {
        }
        public static void OnButton_4Button(this ES_CountryTask self)
        {
        }
    }
}
