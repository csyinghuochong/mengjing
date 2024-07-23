namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TeamApplyItem))]
    [EntitySystemOf(typeof(Scroll_Item_TeamApplyItem))]
    public static partial class Scroll_Item_TeamApplyItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_TeamApplyItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_TeamApplyItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_TeamApplyItem self, TeamPlayerInfo teamPlayerInfo)
        {
            self.E_ButtonAgreeButton.AddListener(() => { self.OnButtonAgree().Coroutine(); });
            self.E_ButtonRefuseButton.AddListener(() => { self.OnButtonRefuse().Coroutine(); });

            self.TeamPlayerInfo = teamPlayerInfo;
            self.E_TextNameText.text = teamPlayerInfo.PlayerName;
            using (zstring.Block())
            {
                self.E_TextCombatText.text = zstring.Format("战力：{0}", teamPlayerInfo.Combat);
                self.E_TextLevelText.text = zstring.Format("等级：{0}", teamPlayerInfo.PlayerLv);
            }

            string occName = "";
            if (teamPlayerInfo.OccTwo != 0)
            {
                OccupationTwoConfig occtwoCof = OccupationTwoConfigCategory.Instance.Get(teamPlayerInfo.OccTwo);
                occName = occtwoCof.OccupationName;
            }
            else
            {
                OccupationConfig occCof = OccupationConfigCategory.Instance.Get(teamPlayerInfo.Occ);
                occName = occCof.OccupationName;
            }

            self.E_TextOccText.text = occName;
            //是否是人机
            if (teamPlayerInfo.RobotId > 0)
            {
                self.EG_RootShowSetRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.EG_RootShowSetRectTransform.gameObject.SetActive(false);
            }
        }

        public static async ETTask OnButtonAgree(this Scroll_Item_TeamApplyItem self)
        {
            await TeamNetHelper.AgreeTeamApply(self.Root(), self.TeamPlayerInfo, 1);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTeamApplyList>().OnUpdateUI();
        }

        public static async ETTask OnButtonRefuse(this Scroll_Item_TeamApplyItem self)
        {
            await TeamNetHelper.AgreeTeamApply(self.Root(), self.TeamPlayerInfo, 0);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTeamApplyList>().OnUpdateUI();
        }
    }
}