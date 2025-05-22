using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_ActivityLogin))]
    [FriendOfAttribute(typeof(ES_ActivityLogin))]
    public static partial class ES_ActivityLoginSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityLogin self, Transform transform)
        {
            self.uiTransform = transform;
            self.OnUpdateUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivityLogin self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_ActivityLogin self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();

            List<ActivityConfig> showConfigs = new();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != (int)ActivityEnum.Type_31)
                {
                    continue;
                }

                showConfigs.Add(activityConfigs[i]);
            }

            bool todayrecv = CommonHelp.GetDayByTime(activityComponent.LastLoginTime) == CommonHelp.GetDayByTime(TimeHelper.ServerNow());


            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < showConfigs.Count; i++)
            {
                ActivityConfig activityConfig = showConfigs[i];
                
                Transform  itemTransform = self.uiTransform.Find($"Right/ActivityLoginItem_{i + 1}");
                    
                itemTransform.Find("Text_Day").GetComponent<Text>().text = (i + 1).ToString();

                string[] items = activityConfig.Par_3.Split('@');
                string[] item = items[0].Split(';');
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(item[0]));
                itemTransform.Find("Img_ItemIcon").GetComponent<Image>().sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
                itemTransform.Find("Text_ItemName").GetComponent<Text>().text = $"{itemConfig.ItemName} x {item[1]}";
                itemTransform.Find("Text_ItemName").GetComponent<Text>().color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);

                bool received = activityComponent.ActivityReceiveIds.Contains(activityConfig.Id);
                itemTransform.Find("Btn_Receive").gameObject.SetActive(!received);
                itemTransform.Find("Img_Received").gameObject.SetActive(received);
                itemTransform.Find("Text_State").GetComponent<Text>().text = received ? "已领取" : "待签到";
                
                bool canReceive = self.CanReceive(activityConfig.Id) && !todayrecv;
                bool allReceive = activityComponent.ActivityReceiveIds.Contains(activityConfig.Id);
                //CommonViewHelper.SetImageGray( self.Root(), itemTransform.Find("Img_Di").gameObject,  !canReceive  );
                CommonViewHelper.SetImageGray( self.Root(), itemTransform.Find("Img_ItemIcon").gameObject,  !canReceive && !allReceive );
                itemTransform.Find("Btn_Receive").GetComponent<Button>().AddListener(() => { self.OnBtn_Receive(activityConfig).Coroutine(); });
            }
        }
        private static async ETTask OnBtn_Receive(this ES_ActivityLogin self, ActivityConfig activityConfig)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (userInfo.Lv < 10)
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("10级才能领取！"));
                return;
            }

            if (!self.CanReceive(activityConfig.Id))
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("未达到领取条件！"));
                return;
            }

            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            if (CommonHelp.GetDayByTime(activityComponent.LastLoginTime) == CommonHelp.GetDayByTime(TimeHelper.ServerNow()))
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("今天的奖励已领取"));
                return;
            }
            
            M2C_ActivityReceiveResponse response =  await ActivityNetHelper.ActivityReceive(self.Root(), activityConfig.ActivityType, activityConfig.Id);
            if (response == null || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }
            self.OnUpdateUI();
            self.Root().GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.WelfareLogin);
        }

        private static bool CanReceive(this ES_ActivityLogin self, int activityId)
        {
            List<int> allIds = new List<int>();
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != (int)ActivityEnum.Type_31)
                {
                    continue;
                }

                if (activityConfigs[i].Id < activityId)
                {
                    allIds.Add(activityConfigs[i].Id);
                }
            }

            for (int i = 0; i < allIds.Count; i++)
            {
                if (!activityComponent.ActivityReceiveIds.Contains(allIds[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}