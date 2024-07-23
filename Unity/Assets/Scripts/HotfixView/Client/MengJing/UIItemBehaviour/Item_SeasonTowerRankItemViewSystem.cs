namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_SeasonTowerRankItem))]
    public static partial class Scroll_Item_SeasonTowerRankItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SeasonTowerRankItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SeasonTowerRankItem self)
        {
            self.DestroyWidget();
        }

        public static void UpdateInfo(this Scroll_Item_SeasonTowerRankItem self, int rank, RankSeasonTowerInfo info)
        {
            self.E_NuTextText.text = rank.ToString();
            self.E_NameTextText.text = info.PlayerName;
            using (zstring.Block())
            {
                self.E_LayerTextText.text = zstring.Format("{0}层", info.FubenId % 250000);
                self.E_TimeTextText.text = zstring.Format("{0}小时{1}分{2}秒", info.TotalTime / 3600000, info.TotalTime % 3600000 / 60000,
                    info.TotalTime % 3600000 % 60000 / 1000);
            }

            if (rank >= 4)
            {
                self.EG_RankShowSetRectTransform.gameObject.SetActive(false);
            }
            else
            {
                self.EG_RankShowSetRectTransform.gameObject.SetActive(true);
                CommonViewHelper.HideChildren(self.EG_RankShowSetRectTransform);
                self.E_NuTextText.gameObject.SetActive(false);
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