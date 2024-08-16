namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionApplyListItem))]
    [EntitySystemOf(typeof(Scroll_Item_UnionApplyListItem))]
    public static partial class Scroll_Item_UnionApplyListItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_UnionApplyListItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_UnionApplyListItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonReply(this Scroll_Item_UnionApplyListItem self, int replyCode)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0));

            U2C_UnionApplyReplyResponse response =
                    await UnionNetHelper.UnionApplyReplyRequest(self.Root(), replyCode, self.UnionPlayerInfo.UserID, unionId);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnionApplyList>().OnUnionApplyReply(self.UnionPlayerInfo.UserID);
        }

        public static void OnUpdateUI(this Scroll_Item_UnionApplyListItem self, UnionPlayerInfo unionPlayerInfo)
        {
            self.E_ButtonAgreeButton.AddListener(() => { self.OnButtonReply(1).Coroutine(); });
            self.E_ButtonRefuseButton.AddListener(() => { self.OnButtonReply(0).Coroutine(); });

            self.UnionPlayerInfo = unionPlayerInfo;
            self.E_Text_CombatText.text = unionPlayerInfo.Combat.ToString();
            self.E_Text_NameText.text = unionPlayerInfo.PlayerName;
            self.E_Text_LevelText.text = unionPlayerInfo.PlayerLevel.ToString();

            if (unionPlayerInfo.OccTwo != 0)
            {
                self.E_Text_OccText.text = OccupationTwoConfigCategory.Instance.Get(unionPlayerInfo.OccTwo).OccupationName;
            }
            else
            {
                self.E_Text_OccText.text = OccupationConfigCategory.Instance.Get(unionPlayerInfo.Occ).OccupationName;
            }
        }
    }
}