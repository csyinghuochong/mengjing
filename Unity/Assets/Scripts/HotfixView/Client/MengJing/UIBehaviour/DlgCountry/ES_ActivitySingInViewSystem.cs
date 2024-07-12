using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ActivitySingInItem))]
    [EntitySystemOf(typeof (ES_ActivitySingIn))]
    [FriendOfAttribute(typeof (ES_ActivitySingIn))]
    public static partial class ES_ActivitySingInSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivitySingIn self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_ComButton.AddListenerAsync(self.OnBtn_Com_Sign);
            self.E_Btn_Com2Button.AddListenerAsync(self.OnBtn_Com_Sign2);
            self.E_ActivitySingInItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnActivitySingInItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivitySingIn self)
        {
            self.DestroyWidget();
        }

        private static void OnActivitySingInItemsRefresh(this ES_ActivitySingIn self, Transform transform, int index)
        {
            Scroll_Item_ActivitySingInItem scrollItemActivitySingInItem = self.ScrollItemActivitySingInItems[index].BindTrans(transform);
            scrollItemActivitySingInItem.OnUpdateUI(self.ShowActivityConfigs[index], (int activityId) => { self.OnClickSignItem(activityId); });
            scrollItemActivitySingInItem.SetSignState(self.CurDay, self.IsSign);
        }

        public static void OnInitUI(this ES_ActivitySingIn self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            int curDay = 0;
            long serverNow = TimeHelper.ServerNow();
            bool isSign = CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime);
            curDay = activityComponent.TotalSignNumber;
            if (activityComponent.TotalSignNumber < 30 && !isSign)
            {
                curDay++;
            }

            self.CurDay = curDay;
            self.IsSign = isSign;
            self.ShowActivityConfigs.Clear();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 23)
                {
                    continue;
                }

                self.ShowActivityConfigs.Add(activityConfigs[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemActivitySingInItems, self.ShowActivityConfigs.Count);
            self.E_ActivitySingInItemsLoopVerticalScrollRect.SetVisible(true, self.ShowActivityConfigs.Count);

            self.E_Img_lingQuImage.gameObject.SetActive(isSign);
            self.E_Btn_ComButton.gameObject.SetActive(!isSign);
            Scroll_Item_ActivitySingInItem scrollItemActivitySingInItem = self.ScrollItemActivitySingInItems[curDay - 1];
            scrollItemActivitySingInItem.OnImage_ItemButton();
            self.ActivityId = scrollItemActivitySingInItem.ActivityConfig.Id;

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.E_Img_lingQu2Image.gameObject.SetActive(unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeSign) == 2);
        }

        public static void OnClickSignItem(this ES_ActivitySingIn self, int activityId)
        {
            ActivityConfig ActivityConfig = null;
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 23)
                {
                    continue;
                }

                if (activityConfigs[i].Id == activityId)
                {
                    ActivityConfig = activityConfigs[i];
                }
            }

            if (self.ScrollItemActivitySingInItems != null)
            {
                foreach (Scroll_Item_ActivitySingInItem item in self.ScrollItemActivitySingInItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(ActivityConfig.Id);
                }
            }

            self.ES_RewardList.Refresh(ActivityConfig.Par_3);

            self.ES_RewardList_2.Refresh(ActivityConfig.Par_2);

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            long serverNow = TimeHelper.ServerNow();
            bool isSign = CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime);
            bool ifShow = int.Parse(ActivityConfig.Par_1) <= activityComponent.TotalSignNumber || isSign ||
                    activityComponent.ActivityReceiveIds.Contains(activityId);
            self.E_Img_lingQuImage.gameObject.SetActive(ifShow);
            self.E_Btn_ComButton.gameObject.SetActive(!ifShow);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.E_Btn_Com2Button.gameObject.SetActive(unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeSign) != 2);
        }

        public static async ETTask OnBtn_Com_Sign2(this ES_ActivitySingIn self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeSign) != 1)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("不满足领取条件");
                return;
            }

            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.ActivityId);
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell() < ItemHelper.GetNeedCell(activityConfig.Par_2))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("不满足领取条件");
                return;
            }

            await ActivityNetHelper.ActivityRechargeSignRequest(self.Root(), 23, self.ActivityId);
            self.E_Btn_Com2Button.gameObject.SetActive(false);
            self.E_Img_lingQu2Image.gameObject.SetActive(true);
        }

        public static async ETTask OnBtn_Com_Sign(this ES_ActivitySingIn self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (activityComponent.TotalSignNumber == 30)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("已领完全部奖励！");
                return;
            }

            long serverNow = TimeHelper.ServerNow();
            if (CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("当日奖励已领取！");
                return;
            }

            if (activityComponent.ActivityReceiveIds.Contains(self.ActivityId))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("当日奖励已领取！");
                return;
            }

            int error = await ActivityNetHelper.ActivityReceive(self.Root(), 23, self.ActivityId);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            activityComponent.TotalSignNumber++;
            activityComponent.LastSignTime = serverNow;
            activityComponent.ActivityReceiveIds.Add(self.ActivityId);

            self.OnClickSignItem(self.ActivityId);
        }
    }
}