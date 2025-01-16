using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RankShowItem))]
    [EntitySystemOf(typeof(Scroll_Item_RankShowItem))]
    public static partial class Scroll_Item_RankShowItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RankShowItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RankShowItem self)
        {
            self.DestroyWidget();
        }

        private static async ETTask OnButtonWatch(this Scroll_Item_RankShowItem self)
        {
            F2C_WatchPlayerResponse response = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.RankingInfo.UserId, 0);

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Watch);
            DlgWatch dlgWatch = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>();
            dlgWatch.OnUpdateUI(response);
        }

        public static void Refresh(this Scroll_Item_RankShowItem self, int rank, RankingInfo rankingInfo)
        {
            self.E_Button_WatchEquipButton.AddListenerAsync(self.OnButtonWatch);

            self.RankingInfo = rankingInfo;

            self.E_Text_CombatText.text = rankingInfo.Combat.ToString();
            using (zstring.Block())
            {
                self.E_Text_LevelText.text = zstring.Format("等级：{0}", rankingInfo.PlayerLv.ToString());
            }

            self.E_Text_NameText.text = rankingInfo.PlayerName;
            self.E_Text_RankText.text = rank.ToString();
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.E_ImageHeadIconImage.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, rankingInfo.Occ.ToString()));

            if (rank >= 4)
            {
                self.EG_RankShowSetRectTransform.gameObject.SetActive(false);
                self.E_Text_RankText.gameObject.SetActive(true);
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