using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
            
            self.DestroyWidget();
        }

        private static void OnTypeSet(this ES_ActivitySingIn self, int page)
        {
            if (page == 0)
            {
                self.SingInActivityType = ActivityEnum.Type_23;
                self.LeiJiSingInActivityType = ActivityEnum.Type_26;
            }
            else
            {
                self.SingInActivityType = ActivityEnum.Type_25;
                self.LeiJiSingInActivityType = ActivityEnum.Type_27;
            }
            self.OnInitUI();
        }

        private static void OnInitUI(this ES_ActivitySingIn self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            int curDay = self.SingInActivityType == ActivityEnum.Type_23 ? activityComponent.TotalSignNumber : activityComponent.TotalSignNumber_VIP;
            long serverNow = TimeHelper.ServerNow();
            bool isSign = CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(self.SingInActivityType == ActivityEnum.Type_23 ? activityComponent.LastSignTime : activityComponent.LastSignTime_VIP);
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            self.ShowActivityConfigs.Clear();
            foreach (ActivityConfig config in activityConfigs)
            {
                if (config.ActivityType == self.SingInActivityType)
                {
                    self.ShowActivityConfigs.Add(config);
                }
            }

            int TotalSignNumber = self.SingInActivityType == ActivityEnum.Type_23  ? activityComponent.TotalSignNumber : activityComponent.TotalSignNumber_VIP;
            if (TotalSignNumber < self.ShowActivityConfigs.Count && !isSign)
            {
                curDay++;
            }

            self.CurDay = curDay;

            
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowActivityConfigs.Count; i++)
            {
                if (!self.ScrollItemActivitySingInItems.ContainsKey(i))
                {
                    Scroll_Item_ActivitySingInItem item = self.AddChild<Scroll_Item_ActivitySingInItem>();
                    string path = "Assets/Bundles/UI/Item/Item_ActivitySingInItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_ActivitySingInItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemActivitySingInItems.Add(i, item);
                }

                Scroll_Item_ActivitySingInItem scrollItemActivitySingInItem = self.ScrollItemActivitySingInItems[i];
                scrollItemActivitySingInItem.uiTransform.gameObject.SetActive(true);
                scrollItemActivitySingInItem.OnUpdateUI(self.ShowActivityConfigs[i], (activityId) => { self.OnClickSignItem(activityId).Coroutine(); });
                scrollItemActivitySingInItem.SetSignState(self.CurDay);
            }

            if (self.ScrollItemActivitySingInItems.Count > self.ShowActivityConfigs.Count)
            {
                for (int i = self.ShowActivityConfigs.Count; i < self.ScrollItemActivitySingInItems.Count; i++)
                {
                    Scroll_Item_ActivitySingInItem scrollItemActivitySingInItem = self.ScrollItemActivitySingInItems[i];
                    scrollItemActivitySingInItem.uiTransform.gameObject.SetActive(false);
                }
            }

            List<ActivityConfig> list = ActivityConfigCategory.Instance.GetByType(self.LeiJiSingInActivityType);
            self.E_Reward1EventTrigger.triggers.Clear();
            self.E_Reward1EventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointerDown(list[0].Id, pdata as PointerEventData); });
            self.E_Reward1EventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.OnPointerUp(list[0].Id, pdata as PointerEventData).Coroutine(); });
            self.E_Reward2EventTrigger.triggers.Clear();
            self.E_Reward2EventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointerDown(list[1].Id, pdata as PointerEventData); });
            self.E_Reward2EventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.OnPointerUp(list[1].Id, pdata as PointerEventData).Coroutine(); });
            self.E_Reward3EventTrigger.triggers.Clear();
            self.E_Reward3EventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointerDown(list[2].Id, pdata as PointerEventData); });
            self.E_Reward3EventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.OnPointerUp(list[2].Id, pdata as PointerEventData).Coroutine(); });
            self.E_Reward4EventTrigger.triggers.Clear();
            self.E_Reward4EventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointerDown(list[3].Id, pdata as PointerEventData); });
            self.E_Reward4EventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.OnPointerUp(list[3].Id, pdata as PointerEventData).Coroutine(); });
            using (zstring.Block())
            {
                string[] itemInfo = list[0].Par_2.Split(';');
                self.E_Reward1EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
                self.E_Reward1EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
                self.E_Reward1EventTrigger.transform.Find("Text").GetComponent<Text>().text = zstring.Format("累计签到{0}天", list[0].Par_1);

                itemInfo = list[1].Par_2.Split(';');
                self.E_Reward2EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
                self.E_Reward2EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
                self.E_Reward2EventTrigger.transform.Find("Text").GetComponent<Text>().text = zstring.Format("累计签到{0}天", list[1].Par_1);

                itemInfo = list[2].Par_2.Split(';');
                self.E_Reward3EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
                self.E_Reward3EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
                self.E_Reward3EventTrigger.transform.Find("Text").GetComponent<Text>().text = zstring.Format("累计签到{0}天", list[2].Par_1);

                itemInfo = list[3].Par_2.Split(';');
                self.E_Reward4EventTrigger.transform.Find("ItemIcon").GetComponent<Image>().sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfo[0]));
                self.E_Reward4EventTrigger.transform.Find("ItemNum").GetComponent<Text>().text = itemInfo[1];
                self.E_Reward4EventTrigger.transform.Find("Text").GetComponent<Text>().text = zstring.Format("累计签到{0}天", list[3].Par_1);
            }

            self.UpdateProgress();
        }

        private static async ETTask OnClickSignItem(this ES_ActivitySingIn self, int activityId)
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

            if (self.SingInActivityType == ActivityEnum.Type_25)
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeSign) == 0)
                {
                    FlyTipComponent.Instance.ShowFlyTip("今日未充值，未达领取条件！");
                    return;
                }
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

            M2C_ActivityReceiveResponse response = await ActivityNetHelper.ActivityReceive(self.Root(), self.SingInActivityType, activityId);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (self.SingInActivityType == ActivityEnum.Type_23)
            {
                activityComponent.TotalSignNumber++;
                activityComponent.LastSignTime = TimeHelper.ServerNow();
                activityComponent.ActivityReceiveIds.Add(activityId);
            }
            if (self.SingInActivityType == ActivityEnum.Type_25)
            {
                activityComponent.TotalSignNumber_VIP++;
                activityComponent.LastSignTime_VIP = TimeHelper.ServerNow();
                activityComponent.ActivityReceiveIds.Add(activityId);
            }

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

        private static async ETTask ShowTip(this ES_ActivitySingIn self, int activityId)
        {
            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityId);
            
            long instanceId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(self.Time);
            if (self.IsDisposed || self.InstanceId != instanceId || self.IsClick)
            {
                return;
            }
            
            string[] itemInfo = activityConfig.Par_2.Split(';');
            int itemId = int.Parse(itemInfo[0]);    
            int itemNum = int.Parse(itemInfo[1]);
            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = new ItemInfo() { ItemID = itemId, ItemNum = itemNum },
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new List<ItemInfo>(),
                    CurrentHouse = -1
                });

            self.IsClick = true;
        }
        
        private static void OnPointerDown(this ES_ActivitySingIn self, int activityId, PointerEventData pdata)
        {
            self.ClickTime = TimeHelper.ServerNow();
            self.IsClick = false;
            
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (!activityComponent.ActivityReceiveIds.Contains(activityId))
            {
                self.ShowTip(activityId).Coroutine();
            }
        }

        private static async ETTask OnPointerUp(this ES_ActivitySingIn self, int activityId, PointerEventData pdata)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= self.Time && !self.IsClick)
            {
                self.IsClick = true;
                ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
                ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(activityId);

                if (activityComponent.ActivityReceiveIds.Contains(activityId))
                {
                    FlyTipComponent.Instance.ShowFlyTip("已领取");
                    return;
                }

                int TotalSignNumber = self.LeiJiSingInActivityType == ActivityEnum.Type_26 ? activityComponent.TotalSignNumber : activityComponent.TotalSignNumber_VIP;
                if (TotalSignNumber < int.Parse(activityConfig.Par_1))
                {
                    FlyTipComponent.Instance.ShowFlyTip("未达到领取条件");
                    return;
                }

                M2C_ActivityReceiveResponse response = await ActivityNetHelper.ActivityReceive(self.Root(), self.LeiJiSingInActivityType, activityId);
                if (response == null || response.Error != ErrorCode.ERR_Success)
                {
                    return;
                }

                self.UpdateProgress();
            }
            self.IsClick = true;
        }

        private static void UpdateProgress(this ES_ActivitySingIn self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            int TotalSignNumber = self.LeiJiSingInActivityType == ActivityEnum.Type_26 ? activityComponent.TotalSignNumber : activityComponent.TotalSignNumber_VIP;
            using (zstring.Block())
            {
                self.E_AlreadySingInDayText.text = zstring.Format("{0}天", TotalSignNumber);
            }

            if (self.ShowActivityConfigs.Count > 0)
            {
                self.E_RewardProgressImage.fillAmount = (float)TotalSignNumber / self.ShowActivityConfigs.Count;
            }
            else
            {
                self.E_RewardProgressImage.fillAmount = 0;
            }

            List<ActivityConfig> list = ActivityConfigCategory.Instance.GetByType(self.LeiJiSingInActivityType);
            self.E_Reward1EventTrigger.transform.Find("LingQu").gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(list[0].Id));
            self.E_Reward2EventTrigger.transform.Find("LingQu").gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(list[1].Id));
            self.E_Reward3EventTrigger.transform.Find("LingQu").gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(list[2].Id));
            self.E_Reward4EventTrigger.transform.Find("LingQu").gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(list[3].Id));
        }
    }
}