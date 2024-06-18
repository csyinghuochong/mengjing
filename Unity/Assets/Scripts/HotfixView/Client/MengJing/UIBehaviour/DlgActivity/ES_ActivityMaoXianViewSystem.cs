﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ActivityMaoXian))]
    [FriendOfAttribute(typeof (ES_ActivityMaoXian))]
    public static partial class ES_ActivityMaoXianSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityMaoXian self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonRightButton.AddListener(() => { self.OnButtonActivty(1); });
            self.E_ButtonLeftButton.AddListener(() => { self.OnButtonActivty(-1); });

            self.E_Btn_GoToSupportButton.AddListener(self.OnBtn_GoToSupport);
            self.E_Btn_GetRewardButton.AddListenerAsync(self.OnBtn_GetReward);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivityMaoXian self)
        {
            self.DestroyWidget();
        }

        public static void OnBtn_GoToSupport(this ES_ActivityMaoXian self)
        {
            FlyTipComponent.Instance.SpawnFlyTipDi("氪金界面暂未开放");
            // UIHelper.Create(self.ZoneScene(), UIType.UIRecharge).Coroutine();
        }

        public static async ETTask OnBtn_GetReward(this ES_ActivityMaoXian self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.CurActivityId);
            int rechargeNum = unit.GetMaoXianExp();
            int needNumber = int.Parse(activityConfig.Par_2);
            if (rechargeNum < needNumber)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("冒险家积分不足！");
                return;
            }

            if (activityComponent.ActivityReceiveIds.Contains(self.CurActivityId))
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("当前奖励已领取！");
                return;
            }

            int errorCode = await ActivityNetHelper.ActivityReceive(self.Root(), activityConfig.ActivityType, activityConfig.Id);
            if (errorCode != ErrorCode.ERR_Success)
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
            self.E_ImageProgressImage.transform.localScale = new Vector3(value, 1f, 1f);
            self.E_Text_ProgressText.text = $"{rechargeNum}/{needNumber}";
            self.E_Btn_GetRewardButton.gameObject.SetActive(!activityComponent.ActivityReceiveIds.Contains(self.CurActivityId));
            self.E_ImageReceivedImage.gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(self.CurActivityId));

            self.ES_RewardList.Refresh(activityConfig.Par_3);

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