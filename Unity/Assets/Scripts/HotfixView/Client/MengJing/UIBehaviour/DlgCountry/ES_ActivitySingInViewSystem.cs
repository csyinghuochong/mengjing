using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_ActivitySingInVIP))]
    [FriendOf(typeof(ES_ActivitySingInFree))]
    [FriendOf(typeof(Scroll_Item_ActivitySingInItem))]
    [EntitySystemOf(typeof(ES_ActivitySingIn))]
    [FriendOfAttribute(typeof(ES_ActivitySingIn))]
    public static partial class ES_ActivitySingInSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivitySingIn self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_TypeSetToggleGroup.AddListener(self.OnTypeSet);

            self.E_TypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivitySingIn self)
        {
            self.DestroyWidget();
        }

        private static void OnTypeSet(this ES_ActivitySingIn self, int page)
        {
            CommonViewHelper.HideChildren(self.EG_PanelRootRectTransform);
            if (page == 0)
            {
                self.ES_ActivitySingInFree.uiTransform.gameObject.SetActive(true);
            }
            else
            {
                self.ES_ActivitySingInVip.uiTransform.gameObject.SetActive(true);
            }
        }

        // public static async ETTask OnBtn_Com2Button(this ES_ActivitySingIn self)
        // {
        //     Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
        //     if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeSign) != 1)
        //     {
        //         FlyTipComponent.Instance.ShowFlyTip("不满足领取条件");
        //         return;
        //     }
        //
        //     ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(self.ActivityId);
        //     BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
        //     if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < ItemHelper.GetNeedCell(activityConfig.Par_2))
        //     {
        //         FlyTipComponent.Instance.ShowFlyTip("不满足领取条件");
        //         return;
        //     }
        //
        //     await ActivityNetHelper.ActivityRechargeSignRequest(self.Root(), 23, self.ActivityId);
        //     self.E_Btn_Com2Button.gameObject.SetActive(false);
        //     self.E_Img_lingQu2Image.gameObject.SetActive(true);
        // }
        //
        // public static async ETTask OnBtn_ComButton(this ES_ActivitySingIn self)
        // {
        //     ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
        //     if (activityComponent.TotalSignNumber == 30)
        //     {
        //         FlyTipComponent.Instance.ShowFlyTip("已领完全部奖励！");
        //         return;
        //     }
        //
        //     long serverNow = TimeHelper.ServerNow();
        //     if (CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime))
        //     {
        //         FlyTipComponent.Instance.ShowFlyTip("当日奖励已领取！");
        //         return;
        //     }
        //
        //     if (activityComponent.ActivityReceiveIds.Contains(self.ActivityId))
        //     {
        //         FlyTipComponent.Instance.ShowFlyTip("当日奖励已领取！");
        //         return;
        //     }
        //
        //     int error = await ActivityNetHelper.ActivityReceive(self.Root(), 23, self.ActivityId);
        //     if (error != ErrorCode.ERR_Success)
        //     {
        //         return;
        //     }
        //
        //     activityComponent.TotalSignNumber++;
        //     activityComponent.LastSignTime = serverNow;
        //     activityComponent.ActivityReceiveIds.Add(self.ActivityId);
        //
        //     self.OnClickSignItem(self.ActivityId);
        // }
    }
}