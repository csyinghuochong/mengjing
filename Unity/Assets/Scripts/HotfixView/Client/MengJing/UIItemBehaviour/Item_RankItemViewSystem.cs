using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankItem))]
    [EntitySystemOf(typeof(Scroll_Item_RankItem))]
    public static partial class Scroll_Item_RankItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RankItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RankItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonWatch(this Scroll_Item_RankItem self)
        {
            F2C_WatchPlayerResponse response = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.RankingInfo.UserId, 0);

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Watch);
            DlgWatch dlgWatch = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>();
            dlgWatch.OnUpdateUI(response);
        }

        public static void OnInitData(this Scroll_Item_RankItem self, int rank, RankingTrialInfo rankingInfo)
        {
            self.E_Button_WatchEquipButton.AddListenerAsync(self.OnButtonWatch);

            self.RankingInfo = rankingInfo;

            //试炼之塔排行先按照层树排序,层序一样按照秒伤 试炼排行榜得秒伤处也显示层数和秒伤,
            //比如40层50000秒伤 显示格式为: 40层(50000/秒)
            if (rankingInfo.FubenId == 0)
            {
                rankingInfo.FubenId = 20001;
            }

            using (zstring.Block())
            {
                self.E_Text_CombatText.text = zstring.Format(" {0}层({1}/秒)", rankingInfo.FubenId % 20000, rankingInfo.Hurt);
            }

            self.E_Text_LevelText.text = rankingInfo.PlayerLv.ToString();
            self.E_Text_NameText.text = rankingInfo.PlayerName;
            self.E_Text_RankText.text = rank.ToString();
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.E_ImageHeadIconImage.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, rankingInfo.Occ.ToString()));

            if (rank >= 4)
            {
                self.EG_RankShowSetRectTransform.gameObject.SetActive(false);
            }
            else
            {
                self.EG_RankShowSetRectTransform.gameObject.SetActive(true);
                CommonViewHelper.HideChildren(self.EG_RankShowSetRectTransform);
                self.E_Text_RankText.gameObject.SetActive(false);
                switch (rank)
                {
                    case 1:
                        self.E_Rank_1Image.gameObject.SetActive(true);
                        break;

                    case 2:
                        self.E_Rank_2Image.gameObject.SetActive(true);
                        break;

                    case 3:
                        self.E_Rank_3Image.gameObject.SetActive(true);
                        break;
                }
            }
        }
    }
}