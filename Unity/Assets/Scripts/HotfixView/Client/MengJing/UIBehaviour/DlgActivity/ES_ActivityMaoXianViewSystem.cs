using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_ActivityMaoXian))]
    [FriendOfAttribute(typeof(ES_ActivityMaoXian))]
    public static partial class ES_ActivityMaoXianSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityMaoXian self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonRightButton.AddListener(() => { self.OnButtonActivty(1); });
            self.E_ButtonLeftButton.AddListener(() => { self.OnButtonActivty(-1); });

            self.E_Btn_GoToSupportButton.AddListener(self.OnBtn_GoToSupportButton);
            self.E_Btn_GetRewardButton.AddListenerAsync(self.OnBtn_GetRewardButton);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivityMaoXian self)
        {
            self.DestroyWidget();
        }

        public static void OnBtn_GoToSupportButton(this ES_ActivityMaoXian self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
        }

        public static async ETTask OnBtn_GetRewardButton(this ES_ActivityMaoXian self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.CurActivityId);
            int rechargeNum = unit.GetMaoXianExp();
            int needNumber = int.Parse(activityConfig.Par_2);
            if (rechargeNum < needNumber)
            {
                FlyTipComponent.Instance.ShowFlyTip("冒险家积分不足！");
                return;
            }

            if (activityComponent.ActivityReceiveIds.Contains(self.CurActivityId))
            {
                FlyTipComponent.Instance.ShowFlyTip("当前奖励已领取！");
                return;
            }


            M2C_ActivityReceiveResponse response =  await ActivityNetHelper.ActivityReceive(self.Root(), activityConfig.ActivityType, activityConfig.Id);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.E_Btn_GetRewardButton.gameObject.SetActive(!activityComponent.ActivityReceiveIds.Contains(self.CurActivityId));
            self.E_ImageReceivedImage.gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(self.CurActivityId));

            self.OnUpdateUI(activityComponent.GetCurActivityId(rechargeNum));
        }

        public static void OnInitUI(this ES_ActivityMaoXian self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int rechargeNum = unit.GetMaoXianExp();
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            self.OnUpdateUI(activityComponent.GetCurActivityId(rechargeNum));
        }

        public static void OnButtonActivty(this ES_ActivityMaoXian self, int index)
        {
            int curId = self.CurActivityId;

            curId += index;

            self.OnUpdateUI(curId);
        }

        public static void OnUpdateUI(this ES_ActivityMaoXian self, int maoxianId)
        {
            if (maoxianId == 0)
            {
                return;
            }

            self.CurActivityId = maoxianId;
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(maoxianId);
            self.E_Text_TitleText.text = activityConfig.Par_4;

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            int rechargeNum = unit.GetMaoXianExp();
            int needNumber = int.Parse(activityConfig.Par_2);
            float value = rechargeNum * 1f / needNumber;
            value = Mathf.Clamp01(value);
            self.E_ImageProgressImage.fillAmount = value;
            using (zstring.Block())
            {
                self.E_Text_ProgressText.text = zstring.Format("{0}/{1}", rechargeNum, needNumber);
            }

            self.E_Btn_GetRewardButton.gameObject.SetActive(!activityComponent.ActivityReceiveIds.Contains(self.CurActivityId));
            self.E_ImageReceivedImage.gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(self.CurActivityId));

            self.ES_RewardList.Refresh(activityConfig.Par_3);
            self.ES_RewardList.ShowUIEffect( 41100001 );
            self.ES_RewardList.ShowReceived(activityComponent.ActivityReceiveIds.Contains(self.CurActivityId));
            int selId = activityComponent.GetCurActivityId(rechargeNum);
            int maxId = ActivityHelper.GetMaxActivityId(101);
            int minId = ActivityHelper.GetMinActivityId(101);
            self.E_ButtonLeftButton.gameObject.SetActive(self.CurActivityId > minId);

            int addNum = 4;
            int chaValue = 30007 - selId;
            if (chaValue >= 0)
            {
                if (addNum < chaValue)
                {
                    addNum = chaValue;
                }
            }

            self.E_ButtonRightButton.gameObject.SetActive(self.CurActivityId < (selId + addNum) && self.CurActivityId < maxId);
        }
    }
}
