using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_ModelShow))]
    [EntitySystemOf(typeof(ES_TeamItem))]
    [FriendOfAttribute(typeof(ES_TeamItem))]
    public static partial class ES_TeamItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TeamItem self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_TeamItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_TeamItem self, int index)
        {
            // self.ES_ModelShow.SetRootPosition(new Vector3(index * 1000, 0, 0));
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 55f, 115f));

            self.ES_ModelShow.ClickHandler = () => { self.OnClickTeamItem().Coroutine(); };
            if (self.TeamPlayerInfo != null)
            {
                ItemInfo bagInfoNew = new ItemInfo();
                bagInfoNew.ItemID = self.TeamPlayerInfo.WeaponId;
                self.ES_ModelShow.ShowPlayerModel(bagInfoNew, self.TeamPlayerInfo.Occ, 0, self.TeamPlayerInfo.FashionIds);
            }
        }

        public static async ETTask OnClickTeamItem(this ES_TeamItem self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WatchMenu);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatchMenu>()
                    .OnUpdateUI_1(MenuEnumType.Team, self.TeamPlayerInfo.UserID, string.Empty, true).Coroutine();
        }

        public static void OnUpdateItem(this ES_TeamItem self, TeamPlayerInfo teamPlayerInfo)
        {
            self.EG_RootShowSetRectTransform.gameObject.SetActive(false);
            self.TeamPlayerInfo = teamPlayerInfo;

            if (teamPlayerInfo == null)
            {
                self.E_Text_Wait_2Text.gameObject.SetActive(true);
                self.ES_ModelShow.uiTransform.gameObject.SetActive(false);
                self.E_TextLevelText.gameObject.SetActive(false);
                self.E_TextNameText.gameObject.SetActive(false);
                self.E_TextCombatText.gameObject.SetActive(false);
                self.E_TextOccText.gameObject.SetActive(false);
                self.E_Image_Add.gameObject.SetActive(true);
            }
            else
            {
                self.E_Text_Wait_2Text.gameObject.SetActive(false);
                self.ES_ModelShow.uiTransform.gameObject.SetActive(true);
                self.E_TextLevelText.gameObject.SetActive(true);
                self.E_TextNameText.gameObject.SetActive(true);
                self.E_TextCombatText.gameObject.SetActive(true);
                self.E_TextOccText.gameObject.SetActive(true);
                self.E_Image_Add.gameObject.SetActive(false);
                using (zstring.Block())
                {
                    self.E_TextLevelText.text = zstring.Format("{0} 级", teamPlayerInfo.PlayerLv);
                    self.E_TextNameText.text = teamPlayerInfo.PlayerName;
                    self.E_TextCombatText.text = zstring.Format("战力: {0}", teamPlayerInfo.Combat);
                }

                self.E_TextOccText.gameObject.SetActive(teamPlayerInfo.Occ != 0 || teamPlayerInfo.OccTwo != 0);
                if (teamPlayerInfo.Occ != 0)
                {
                    self.E_TextOccText.text = OccupationConfigCategory.Instance.Get(teamPlayerInfo.Occ).OccupationName;
                }

                if (teamPlayerInfo.OccTwo != 0)
                {
                    self.E_TextOccText.text = OccupationTwoConfigCategory.Instance.Get(teamPlayerInfo.OccTwo).OccupationName;
                }

                //机器人显示
                if (teamPlayerInfo.RobotId > 0)
                {
                    self.EG_RootShowSetRectTransform.gameObject.SetActive(true);
                }
            }

            if (teamPlayerInfo != null && self.ES_ModelShow != null)
            {
                ItemInfo bagInfoNew = new ItemInfo();
                bagInfoNew.ItemID = teamPlayerInfo.WeaponId;
                self.ES_ModelShow.ShowPlayerModel(bagInfoNew, self.TeamPlayerInfo.Occ, 0, teamPlayerInfo.FashionIds);
            }
        }
    }
}
