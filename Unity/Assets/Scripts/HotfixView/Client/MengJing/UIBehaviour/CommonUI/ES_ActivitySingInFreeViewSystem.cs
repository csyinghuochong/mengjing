using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivitySingInItem))]
    [EntitySystemOf(typeof(ES_ActivitySingInFree))]
    [FriendOf(typeof(ES_ActivitySingInFree))]
    public static partial class ES_ActivitySingInFreeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivitySingInFree self, Transform transform)
        {
            self.uiTransform = transform;

            List<ActivityConfig> list = ActivityConfigCategory.Instance.GetByType((int)ActivityEnum.Type_26);
            self.E_Reward1EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(list[0].Id, pdata as PointerEventData).Coroutine(); });
            self.E_Reward2EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(list[1].Id, pdata as PointerEventData).Coroutine(); });
            self.E_Reward3EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(list[2].Id, pdata as PointerEventData).Coroutine(); });
            self.E_Reward4EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(list[3].Id, pdata as PointerEventData).Coroutine(); });

            self.E_ActivitySingInItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnActivitySingInItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivitySingInFree self)
        {
            self.DestroyWidget();
        }

        private static void OnInitUI(this ES_ActivitySingInFree self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            int curDay = activityComponent.TotalSignNumber;
            long serverNow = TimeHelper.ServerNow();
            bool isSign = CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime);
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            self.ShowActivityConfigs.Clear();
            foreach (ActivityConfig config in activityConfigs)
            {
                if (config.ActivityType == (int)ActivityEnum.Type_23)
                {
                    self.ShowActivityConfigs.Add(config);
                }
            }

            if (activityComponent.TotalSignNumber < self.ShowActivityConfigs.Count && !isSign)
            {
                curDay++;
            }

            self.CurDay = curDay;

            self.AddUIScrollItems(ref self.ScrollItemActivitySingInItems, self.ShowActivityConfigs.Count);
            self.E_ActivitySingInItemsLoopVerticalScrollRect.SetVisible(true, self.ShowActivityConfigs.Count);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            List<ActivityConfig> list = ActivityConfigCategory.Instance.GetByType((int)ActivityEnum.Type_26);
            using (zstring.Block())
            {
                string[] itemInfo = list[0].Par_2.Split(';');
                self.E_Reward1EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite =
                        resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
                self.E_Reward1EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
                self.E_Reward1EventTrigger.transform.Find("Text").GetComponent<Text>().text =
                        zstring.Format("累计签到{0}天", list[0].Par_1);

                itemInfo = list[1].Par_2.Split(';');
                self.E_Reward2EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite =
                        resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
                self.E_Reward2EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
                self.E_Reward2EventTrigger.transform.Find("Text").GetComponent<Text>().text =
                        zstring.Format("累计签到{0}天", list[1].Par_1);

                itemInfo = list[2].Par_2.Split(';');
                self.E_Reward3EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite =
                        resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
                self.E_Reward3EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
                self.E_Reward3EventTrigger.transform.Find("Text").GetComponent<Text>().text =
                        zstring.Format("累计签到{0}天", list[2].Par_1);

                itemInfo = list[3].Par_2.Split(';');
                self.E_Reward4EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite =
                        resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
                self.E_Reward4EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
                self.E_Reward4EventTrigger.transform.Find("Text").GetComponent<Text>().text =
                        zstring.Format("累计签到{0}天", list[3].Par_1);
            }

            self.UpdateProgress();
        }

        private static void OnActivitySingInItemsRefresh(this ES_ActivitySingInFree self, Transform transform, int index)
        {
            foreach (Scroll_Item_ActivitySingInItem item in self.ScrollItemActivitySingInItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ActivitySingInItem scrollItemActivitySingInItem = self.ScrollItemActivitySingInItems[index].BindTrans(transform);
            scrollItemActivitySingInItem.OnUpdateUI(self.ShowActivityConfigs[index],
                (activityId) => { self.OnClickSignItem(activityId).Coroutine(); });
            scrollItemActivitySingInItem.SetSignState(self.CurDay);
        }

        private static async ETTask OnClickSignItem(this ES_ActivitySingInFree self, int activityId)
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

            M2C_ActivityReceiveResponse  response = await ActivityNetHelper.ActivityReceive(self.Root(), (int)ActivityEnum.Type_23, activityId);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            activityComponent.TotalSignNumber++;
            activityComponent.LastSignTime = TimeHelper.ServerNow();
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

        private static async ETTask EndDrag(this ES_ActivitySingInFree self, int activityId, PointerEventData pdata)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityId);

            if (activityComponent.ActivityReceiveIds.Contains(activityId))
            {
                FlyTipComponent.Instance.ShowFlyTip("已领取");
                return;
            }

            if (activityComponent.TotalSignNumber < int.Parse(activityConfig.Par_1))
            {
                FlyTipComponent.Instance.ShowFlyTip("未达到领取条件");
                return;
            }

            M2C_ActivityReceiveResponse response = await ActivityNetHelper.ActivityReceive(self.Root(), (int)ActivityEnum.Type_26, activityId);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.UpdateProgress();
        }

        private static void UpdateProgress(this ES_ActivitySingInFree self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            using (zstring.Block())
            {
                self.E_AlreadySingInDayText.text = zstring.Format("{0}天", activityComponent.TotalSignNumber);
            }

            if (self.ShowActivityConfigs.Count > 0)
            {
                self.E_RewardProgressImage.fillAmount = (float)activityComponent.TotalSignNumber / self.ShowActivityConfigs.Count;
            }
            else
            {
                self.E_RewardProgressImage.fillAmount = 0;
            }

            List<ActivityConfig> list = ActivityConfigCategory.Instance.GetByType((int)ActivityEnum.Type_26);
            self.E_Reward1EventTrigger.transform.Find("LingQu").gameObject
                    .SetActive(activityComponent.ActivityReceiveIds.Contains(list[0].Id));
            self.E_Reward2EventTrigger.transform.Find("LingQu").gameObject
                    .SetActive(activityComponent.ActivityReceiveIds.Contains(list[1].Id));
            self.E_Reward3EventTrigger.transform.Find("LingQu").gameObject
                    .SetActive(activityComponent.ActivityReceiveIds.Contains(list[2].Id));
            self.E_Reward4EventTrigger.transform.Find("LingQu").gameObject
                    .SetActive(activityComponent.ActivityReceiveIds.Contains(list[3].Id));
        }
    }
}