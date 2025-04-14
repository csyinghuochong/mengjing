using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RunRaceItem))]
    [EntitySystemOf(typeof(ES_HuntRanking))]
    [FriendOfAttribute(typeof(ES_HuntRanking))]
    public static partial class ES_HuntRankingSystem
    {
        [EntitySystem]
        private static void Awake(this ES_HuntRanking self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RunRaceItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRunRaceItemsRefresh);

            self.E_HeadImage_No1Image.gameObject.SetActive(false);
            self.E_NameText_No1Text.gameObject.SetActive(false);
            self.E_HuntNumText_No1Text.gameObject.SetActive(false);
            self.EG_UIHuntRankingPlayerInfoItemRectTransform.gameObject.SetActive(false);

            self.EndTime = FunctionHelp.GetCloseTime(1052);

            self.ShowHuntingTime().Coroutine();
            self.ShowHuntRewards();
            self.UpdataRanking().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_HuntRanking self)
        {
            self.DestroyWidget();
        }

        private static void OnRunRaceItemsRefresh(this ES_HuntRanking self, Transform transform, int index)
        {
            foreach (Scroll_Item_RunRaceItem item in self.ScrollItemRunRaceItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RunRaceItem scrollItemRunRaceItem = self.ScrollItemRunRaceItems[index].BindTrans(transform);
            scrollItemRunRaceItem.OnUpdate(self.ShowRankRewardConfigs[index]);
        }

        public static async ETTask UpdataRanking(this ES_HuntRanking self)
        {
            long instacnid = self.InstanceId;

            R2C_RankShowLieResponse response = await RankNetHelper.RankShowLie(self.Root());
            if (response.RankList == null || response.RankList.Count < 1)
            {
                return;
            }

            if (instacnid != self.InstanceId)
            {
                return;
            }

            response.RankList.Sort((x, y) => (int)(y.KillNumber - x.KillNumber));

            self.E_HeadImage_No1Image.gameObject.SetActive(true);
            self.E_NameText_No1Text.gameObject.SetActive(true);
            self.E_HuntNumText_No1Text.gameObject.SetActive(true);
            self.E_NameText_No1Text.text = response.RankList[0].PlayerName;
            using (zstring.Block())
            {
                self.E_HuntNumText_No1Text.text = zstring.Format("狩猎数量:{0}", response.RankList[0].KillNumber);
                self.E_HeadImage_No1Image.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, response.RankList[0].Occ.ToString()));

                for (int i = 1; i < response.RankList.Count; i++)
                {
                    GameObject go = UnityEngine.Object.Instantiate(self.EG_UIHuntRankingPlayerInfoItemRectTransform.gameObject);
                    go.SetActive(true);
                    CommonViewHelper.SetParent(go, self.EG_HuntRankingListNodeRectTransform.gameObject);
                    ReferenceCollector rc = go.GetComponent<ReferenceCollector>();
                    rc.Get<GameObject>("NameText").GetComponent<Text>().text = zstring.Format("   {0}    {1}", i + 1, response.RankList[i].PlayerName);
                    rc.Get<GameObject>("HuntNumText").GetComponent<Text>().text = zstring.Format("狩猎数量:{0}", response.RankList[i].KillNumber);
                }
            }
        }

        public static async ETTask ShowHuntingTime(this ES_HuntRanking self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            using (zstring.Block())
            {
                while (!self.IsDisposed)
                {
                    DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                    long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
                    long endTime = self.EndTime - curTime;
                    self.E_HuntingTimeTextText.text = endTime > 0 ? zstring.Format("{0}分{1}秒", endTime / 60, endTime % 60) : "未到活动时间";

                    await timerComponent.WaitAsync(1000);
                    if (self.IsDisposed)
                    {
                        break;
                    }
                }
            }
        }

        public static void ShowHuntRewards(this ES_HuntRanking self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(3);

            self.AddUIScrollItems(ref self.ScrollItemRunRaceItems, self.ShowRankRewardConfigs.Count);
            self.E_RunRaceItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }
    }
}
