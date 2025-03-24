using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_RankRewardItem))]
    public static partial class Scroll_Item_RankRewardItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RankRewardItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RankRewardItem self)
        {
            self.DestroyWidget();
        }

        public static void ShowLastRewardPlayer(this Scroll_Item_RankRewardItem self, RankingInfo rankingInfo)
        {
            if (rankingInfo == null)
            {
                return;
            }
            
            self.EG_LastNo.gameObject.SetActive(false);
            self.EG_PlayerInfo.gameObject.SetActive(true);
            self.E_PlayerName.text = rankingInfo.PlayerName;
            self.LastRewardPlayerId = rankingInfo.UserId;
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.E_PlayerIcon.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, rankingInfo.Occ.ToString()));
        }

        public static async ETTask OnButtonWatch(this Scroll_Item_RankRewardItem self)
        {
            F2C_WatchPlayerResponse response = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.LastRewardPlayerId, 0);

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Watch);
            DlgWatch dlgWatch = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>();
            dlgWatch.OnUpdateUI(response);
        }
        
        public static void OnUpdateUI(this Scroll_Item_RankRewardItem self, RankRewardConfig rankRewardConfig)
        {
            using (zstring.Block())
            {
                self.E_Text_RankText.text = zstring.Format("{0}-{1}名", rankRewardConfig.NeedPoint[0], rankRewardConfig.NeedPoint[1]);
            }
            self.EG_LastNo.gameObject.SetActive(false);
            self.EG_PlayerInfo.gameObject.SetActive(false);
            self.E_Text_RankText.gameObject.SetActive(true);
           
            self.E_PlayerIcon.GetComponent<Button>().AddListenerAsync(self.OnButtonWatch);
            self.ES_RewardList.Refresh(rankRewardConfig.RewardItems, 0.9f);

            CommonViewHelper.HideChildren(self.EG_RankShowSetRectTransform);
            if (rankRewardConfig.NeedPoint[0] == 1)
            {
                self.E_Rank_1Image.gameObject.SetActive(true);
                self.E_Text_RankText.gameObject.SetActive(false);
                self.EG_LastNo.gameObject.SetActive(true);
            }

            if (rankRewardConfig.NeedPoint[0] == 2)
            {
                self.E_Rank_2Image.gameObject.SetActive(true);
                self.E_Text_RankText.gameObject.SetActive(false);
            }

            if (rankRewardConfig.NeedPoint[0] == 3)
            {
                self.E_Rank_3Image.gameObject.SetActive(true);
                self.E_Text_RankText.gameObject.SetActive(false);
            }
        }
    }
}