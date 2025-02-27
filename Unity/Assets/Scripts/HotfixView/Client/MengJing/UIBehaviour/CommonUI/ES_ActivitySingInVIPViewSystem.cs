using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivitySingInItem))]
    [EntitySystemOf(typeof(ES_ActivitySingInVIP))]
    [FriendOf(typeof(ES_ActivitySingInVIP))]
    public static partial class ES_ActivitySingInVIPSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivitySingInVIP self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Reward1EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(ConfigData.TotalSignRewards_VIP.ToList()[0].Key, pdata as PointerEventData).Coroutine(); });
            self.E_Reward2EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(ConfigData.TotalSignRewards_VIP.ToList()[1].Key, pdata as PointerEventData).Coroutine(); });
            self.E_Reward3EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(ConfigData.TotalSignRewards_VIP.ToList()[2].Key, pdata as PointerEventData).Coroutine(); });
            self.E_Reward4EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(ConfigData.TotalSignRewards_VIP.ToList()[3].Key, pdata as PointerEventData).Coroutine(); });

            self.E_ActivitySingInItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnActivitySingInItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivitySingInVIP self)
        {
            self.DestroyWidget();
        }

        private static void OnInitUI(this ES_ActivitySingInVIP self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            int curDay = activityComponent.TotalSignNumber_VIP;
            long serverNow = TimeHelper.ServerNow();
            bool isSign = CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime_VIP);
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            self.ShowActivityConfigs.Clear();
            foreach (ActivityConfig config in activityConfigs)
            {
                if (config.ActivityType == (int)ActivityEnum.Type_25)
                {
                    self.ShowActivityConfigs.Add(config);
                }
            }

            if (activityComponent.TotalSignNumber_VIP < self.ShowActivityConfigs.Count && !isSign)
            {
                curDay++;
            }

            self.CurDay = curDay;

            self.AddUIScrollItems(ref self.ScrollItemActivitySingInItems, self.ShowActivityConfigs.Count);
            self.E_ActivitySingInItemsLoopVerticalScrollRect.SetVisible(true, self.ShowActivityConfigs.Count);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            string[] itemInfo = ConfigData.TotalSignRewards_VIP.ToList()[0].Value.Split(';');
            self.E_Reward1EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
            self.E_Reward1EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
            itemInfo = ConfigData.TotalSignRewards_VIP.ToList()[1].Value.Split(';');
            self.E_Reward2EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
            self.E_Reward2EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
            itemInfo = ConfigData.TotalSignRewards_VIP.ToList()[2].Value.Split(';');
            self.E_Reward3EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
            self.E_Reward3EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
            itemInfo = ConfigData.TotalSignRewards_VIP.ToList()[3].Value.Split(';');
            self.E_Reward4EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
            self.E_Reward4EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];

            self.UpdateProgress();
        }

        private static void OnActivitySingInItemsRefresh(this ES_ActivitySingInVIP self, Transform transform, int index)
        {
            Scroll_Item_ActivitySingInItem scrollItemActivitySingInItem = self.ScrollItemActivitySingInItems[index].BindTrans(transform);
            scrollItemActivitySingInItem.OnUpdateUI(self.ShowActivityConfigs[index],
                (activityId) => { self.OnClickSignItem(activityId).Coroutine(); });
            scrollItemActivitySingInItem.SetSignState(self.CurDay);
        }

        private static async ETTask OnClickSignItem(this ES_ActivitySingInVIP self, int activityId)
        {
            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityId);

            // if (self.ScrollItemActivitySingInItems != null)
            // {
            //     foreach (Scroll_Item_ActivitySingInItem item in self.ScrollItemActivitySingInItems.Values)
            //     {
            //         if (item.uiTransform == null)
            //         {
            //             continue;
            //         }
            //
            //         item.SetSelected(ActivityConfig.Id);
            //     }
            // }

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeSign) == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("今日未充值，未达领取条件！");
                return;
            }

            if (self.CurDay < int.Parse(activityConfig.Par_1))
            {
                FlyTipComponent.Instance.ShowFlyTip("未到领取时间！");
                return;
            }

            if (activityComponent.ActivityReceiveIds.Contains(activityId))
            {
                FlyTipComponent.Instance.ShowFlyTip("奖励已领取！");
                return;
            }

            int error = await ActivityNetHelper.ActivityReceive(self.Root(), (int)ActivityEnum.Type_25, activityId);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            activityComponent.TotalSignNumber_VIP++;
            activityComponent.LastSignTime_VIP = TimeHelper.ServerNow();
            activityComponent.ActivityReceiveIds.Add(activityId);

            foreach (Scroll_Item_ActivitySingInItem item in self.ScrollItemActivitySingInItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                item.UpdateLingQu();
            }

            self.UpdateProgress();
        }

        private static async ETTask EndDrag(this ES_ActivitySingInVIP self, int day, PointerEventData pdata)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (activityComponent.TotalSignRewardsList_VIP.Contains(day))
            {
                FlyTipComponent.Instance.ShowFlyTip("已领取");
                return;
            }

            if (activityComponent.TotalSignNumber_VIP < day)
            {
                FlyTipComponent.Instance.ShowFlyTip("未达到领取条件");
                return;
            }

            int error = await ActivityNetHelper.ActivityTotalSignReceive(self.Root(), 1, day);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.UpdateProgress();
        }

        private static void UpdateProgress(this ES_ActivitySingInVIP self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            using (zstring.Block())
            {
                self.E_AlreadySingInDayText.text = zstring.Format("{0}天", activityComponent.TotalSignNumber_VIP);
            }

            if (self.ShowActivityConfigs.Count > 0)
            {
                self.E_RewardProgressImage.fillAmount = (float)activityComponent.TotalSignNumber_VIP / self.ShowActivityConfigs.Count;
            }
            else
            {
                self.E_RewardProgressImage.fillAmount = 0;
            }

            self.E_Reward1EventTrigger.transform.Find("LingQu").gameObject
                    .SetActive(activityComponent.TotalSignRewardsList.Contains(ConfigData.TotalSignRewards_VIP.ToList()[0].Key));
            self.E_Reward2EventTrigger.transform.Find("LingQu").gameObject
                    .SetActive(activityComponent.TotalSignRewardsList.Contains(ConfigData.TotalSignRewards_VIP.ToList()[1].Key));
            self.E_Reward3EventTrigger.transform.Find("LingQu").gameObject
                    .SetActive(activityComponent.TotalSignRewardsList.Contains(ConfigData.TotalSignRewards_VIP.ToList()[2].Key));
            self.E_Reward4EventTrigger.transform.Find("LingQu").gameObject
                    .SetActive(activityComponent.TotalSignRewardsList.Contains(ConfigData.TotalSignRewards_VIP.ToList()[3].Key));
        }
    }
}