using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankItem))]
    [EntitySystemOf(typeof(ES_TrialRank))]
    [FriendOfAttribute(typeof(ES_TrialRank))]
    public static partial class ES_TrialRankSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TrialRank self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_RankItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRankItemsRefresh);
            self.E_Button_RewardButton.AddListenerAsync(self.OnButton_RewardButton);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.E_HeadIcomImage1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "1"));
            self.E_HeadIcomImage2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "2"));
            self.E_HeadIcomImage3Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "3"));

            self.ShowRewardTime().Coroutine();
            self.OnUpdateUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_TrialRank self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_TrialRank self, int index)
        {
            self.CurrentItemType = index;
            self.OnUpdateUI(index + 1).Coroutine();
        }

        private static void OnRankItemsRefresh(this ES_TrialRank self, Transform transform, int index)
        {
            foreach (Scroll_Item_RankItem item in self.ScrollItemRankItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RankItem scrollItemRankShowItem = self.ScrollItemRankItems[index].BindTrans(transform);
            scrollItemRankShowItem.OnInitData(index + 1, self.ShowRankingTrialInfos[index]);
        }

        public static async ETTask ShowRewardTime(this ES_TrialRank self)
        {
            long instanceid = self.InstanceId;
            self.OnTimer();
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();

            while (true)
            {
                await timerComponent.WaitAsync(1000);
                if (instanceid != self.InstanceId)
                {
                    break;
                }

                self.OnTimer();
            }
        }

        public static void OnTimer(this ES_TrialRank self)
        {
            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);

            int today = (int)dateTime.DayOfWeek == 0 ? 7 : (int)dateTime.DayOfWeek;
            long opentime = 7 * TimeHelper.OneDay;
            long curTime = today * TimeHelper.OneDay + dateTime.Hour * TimeHelper.Hour + dateTime.Minute * TimeHelper.Minute +
                    dateTime.Second * TimeHelper.Second;

            long leftTime = opentime - curTime;
            if (leftTime < 0)
            {
                self.E_Text_RewardTimeText.text = string.Empty;
            }
            else
            {
                using (zstring.Block())
                {
                    self.E_Text_RewardTimeText.text = zstring.Format("奖励发放时间: {0}", TimeHelper.ShowLeftTime(leftTime));
                }
            }
        }

        public static async ETTask OnButton_RewardButton(this ES_TrialRank self)
        {
            self.EG_RightRectTransform.gameObject.SetActive(false);
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TrialReward);
            DlgTrialReward dlgTrialReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTrialReward>();
            dlgTrialReward.OnInitUI();
            dlgTrialReward.ClickOnClose = self.OpenShow;
        }

        public static void OpenShow(this ES_TrialRank self)
        {
            self.EG_RightRectTransform.gameObject.SetActive(true);
        }

        public static async ETTask OnUpdateUI(this ES_TrialRank self, int type = 0)
        {
            long instanceid = self.InstanceId;
            R2C_RankTrialListResponse response = await RankNetHelper.RankTrialList(self.Root());

            // 测试数据
            // response.RankList.Add(new RankingTrialInfo()
            // {
            //     FubenId = 1,
            //     Hurt = 1000,
            //     Occ = 1,
            //     PlayerLv = 10,
            //     PlayerName = "测试玩家1"
            // });
            // response.RankList.Add(new RankingTrialInfo()
            // {
            //     FubenId = 1,
            //     Hurt = 2000,
            //     Occ = 1,
            //     PlayerLv = 10,
            //     PlayerName = "测试玩家2"
            // });
            // response.RankList.Add(new RankingTrialInfo()
            // {
            //     FubenId = 1,
            //     Hurt = 1000,
            //     Occ = 2,
            //     PlayerLv = 10,
            //     PlayerName = "测试玩家3"
            // });
            // response.RankList.Add(new RankingTrialInfo()
            // {
            //     FubenId = 1,
            //     Hurt = 4000,
            //     Occ = 3,
            //     PlayerLv = 40,
            //     PlayerName = "测试玩家4"
            // });

            if (instanceid != self.InstanceId)
            {
                return;
            }

            long selfId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            int myRank = -1;
            int rank = 1;
            self.ShowRankingTrialInfos.Clear();

            for (int i = 0; i < response.RankList.Count; i++)
            {
                if (type != 0 && response.RankList[i].Occ != type)
                {
                    continue;
                }

                self.ShowRankingTrialInfos.Add(response.RankList[i]);

                if (selfId == response.RankList[i].UserId)
                {
                    myRank = rank;
                }

                rank++;
            }

            using (zstring.Block())
            {
                self.E_Text_MyRankText.text = myRank == -1 ? "我的排名: 未上榜" : zstring.Format("我的排名: {0}", myRank);
            }

            self.AddUIScrollItems(ref self.ScrollItemRankItems, self.ShowRankingTrialInfos.Count);
            self.E_RankItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankingTrialInfos.Count);
        }
    }
}
