using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_SeasonHome))]
    [FriendOfAttribute(typeof(ES_SeasonHome))]
    public static partial class ES_SeasonHomeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SeasonHome self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_GetBtnButton.AddListenerAsync(self.OnGetBtnButton);
            self.E_ShowBtnButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SeasonLordDetail).Coroutine();
            });

            self.UpdateInfo();
            self.UpdateTime().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_SeasonHome self)
        {
            self.DestroyWidget();
        }

        public static void UpdateInfo(this ES_SeasonHome self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            KeyValuePairLong seasonOpenTime = SeasonHelper.GetOpenSeason(userInfo.Lv);
            if (seasonOpenTime == null)
            {
                return;
            }

            DateTime startTime = TimeInfo.Instance.ToDateTime(seasonOpenTime.Value);
            DateTime endTime = TimeInfo.Instance.ToDateTime(seasonOpenTime.Value2);

            // using (zstring.Block())
            // {
            //     self.E_SeasonTimeTextText.text = zstring.Format("赛季时间:{0}.{1}.{2}-{3}.{4}.{5}", startTime.Year, startTime.Month, startTime.Day,
            //         endTime.Year, endTime.Month, endTime.Day);
            // }

            if (seasonOpenTime.KeyId == 0)
            {
                self.E_SeasonTextText.text = "2023第一赛季";
            }

            if (seasonOpenTime.KeyId == 1)
            {
                self.E_SeasonTextText.text = "2023第二赛季";
            }

            int seasonExp = userInfo.SeasonExp;
            SeasonLevelConfig seasonLevelConfig = SeasonLevelConfigCategory.Instance.Get(userInfo.SeasonLevel);

            if (seasonExp > seasonLevelConfig.UpExp)
            {
                seasonExp = seasonLevelConfig.UpExp;
            }

            using (zstring.Block())
            {
                self.E_SeasonExperienceTextText.text = zstring.Format("赛季经验:{0}/{1}", seasonExp, seasonLevelConfig.UpExp);
            }

            self.E_SeasonExperienceImgImage.fillAmount = 1f * seasonExp / seasonLevelConfig.UpExp;

            self.E_SeasonLvTextText.text = userInfo.SeasonLevel.ToString();

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int bossId = ConfigData.SeasonBossId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_MonsterHeadImgImage.sprite = sp;

            int fubenid = numericComponent.GetAsInt(NumericType.SeasonBossFuben);
            if (fubenid == 0)
            {
                self.E_MonsterPositionTextText.text = "未刷新";
            }
            else
            {
                DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(fubenid);
                using (zstring.Block())
                {
                    self.E_MonsterPositionTextText.text = zstring.Format("出现位置:{0}", dungeonConfig.ChapterName);
                }
            }

            self.UpdateSeasonReward();
        }

        public static void UpdateSeasonReward(this ES_SeasonHome self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            int oldReward = numericComponent.GetAsInt(NumericType.SeasonReward);
            int nowReward = oldReward + 1;
            if (nowReward > SeasonLevelConfigCategory.Instance.GetAll().Count)
            {
                nowReward -= 1;
                self.E_AcvityedImgImage.gameObject.SetActive(true);
                self.E_GetBtnButton.gameObject.SetActive(false);
            }
            else
            {
                self.E_AcvityedImgImage.gameObject.SetActive(false);
                self.E_GetBtnButton.gameObject.SetActive(true);
            }

            using (zstring.Block())
            {
                self.E_SeasonRewardTextText.text = zstring.Format("{0}级赛季奖励", nowReward);
            }

            self.ES_RewardList.Refresh(SeasonLevelConfigCategory.Instance.Get(nowReward).Reward, 0.9f);
        }

        public static async ETTask UpdateTime(this ES_SeasonHome self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                long now = TimeHelper.ServerNow();
                long end = numericComponent.GetAsLong(NumericType.SeasonBossRefreshTime);
                if (end - now > 0)
                {
                    DateTime nowTime = TimeInfo.Instance.ToDateTime(now);
                    DateTime endTime = TimeInfo.Instance.ToDateTime(end);
                    TimeSpan ts = endTime - nowTime;
                    using (zstring.Block())
                    {
                        self.E_MonsterRefreshTimeTextText.text = zstring.Format("刷新时间:{0}天{1}小时{2}分", ts.Days, ts.Hours, ts.Minutes);
                    }
                }
                else
                {
                    self.E_MonsterRefreshTimeTextText.text = "赛季领主已刷新!!";
                }

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }

        public static async ETTask OnGetBtnButton(this ES_SeasonHome self)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 5)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;

            int oldReward = numericComponent.GetAsInt(NumericType.SeasonReward);
            int nowReward = oldReward + 1;
            if (nowReward <= SeasonLevelConfigCategory.Instance.GetAll().Count)
            {
                if (nowReward > userInfo.SeasonLevel)
                {
                    FlyTipComponent.Instance.ShowFlyTip("未到领取等级！");
                    return;
                }

                await ActivityNetHelper.SeasonLevelReward(self.Root(), nowReward);
                self.UpdateSeasonReward();
            }
        }
    }
}
