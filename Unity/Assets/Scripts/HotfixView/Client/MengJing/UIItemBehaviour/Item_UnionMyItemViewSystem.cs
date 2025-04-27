using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_UnionMyItem))]
    [EntitySystemOf(typeof (Scroll_Item_UnionMyItem))]
    public static partial class Scroll_Item_UnionMyItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_UnionMyItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_UnionMyItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnOpenMenu(this Scroll_Item_UnionMyItem self)
        {
            List<int> vs = new List<int>() { MenuOperation.Watch };

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            
            UnionPlayerInfo mainPlayerInfo = UnionHelper.GetUnionPlayerInfo(self.UnionInfo.UnionPlayerList, userInfoComponent.UserInfo.UserId);
            if (mainPlayerInfo == null)
            {
                return;
            }

            int aiderNumber = 0;
            int elderNumber = 0;
            for (int i = 0; i < self.UnionInfo.UnionPlayerList.Count; i++)
            {
                if (self.UnionInfo.UnionPlayerList[i].Position == 2) //副会长
                {
                    aiderNumber++;
                }

                if (self.UnionInfo.UnionPlayerList[i].Position == 3) //长老
                {
                    elderNumber++;
                }
            }

            if (mainPlayerInfo.UserID != self.CurPlayerInfo.UserID)
            {
                vs.Add(MenuOperation.AddFriend);

                if (mainPlayerInfo.UserID == self.UnionInfo.LeaderId)
                {
                    if (mainPlayerInfo.UserID != self.CurPlayerInfo.UserID)
                    {
                        vs.Add(MenuOperation.KickUnion);
                        vs.Add(MenuOperation.UnionTrans);
                    }
                }

                if (mainPlayerInfo.Position == 1) //会长可以任命副会长和长老
                {
                    if (aiderNumber < 1 && (self.CurPlayerInfo.Position == 0 || self.CurPlayerInfo.Position > 2)
                        && self.CurPlayerInfo.Position != 2)
                    {
                        vs.Add(MenuOperation.UnionAider);
                    }
                }

                if (mainPlayerInfo.Position == 1 || mainPlayerInfo.Position == 2) //副会长可以任命长老
                {
                    if (elderNumber < 2 && (self.CurPlayerInfo.Position == 0 || self.CurPlayerInfo.Position > mainPlayerInfo.Position)
                        && self.CurPlayerInfo.Position != 3)
                    {
                        vs.Add(MenuOperation.UnionElde);
                    }
                }

                if (mainPlayerInfo.Position == 1 && self.CurPlayerInfo.Position != 0)
                {
                    vs.Add(MenuOperation.UnionDismiss);
                }
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WatchMenu);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatchMenu>().OnUpdateUI_2(vs, self.CurPlayerInfo.UserID);
        }

        public static void OnUpdateUI(this Scroll_Item_UnionMyItem self, UnionInfo unionInfo, UnionPlayerInfo unionPlayerInfo)
        {
            self.E_ImageButtonButton.AddListenerAsync(self.OnOpenMenu);

            self.UnionInfo = unionInfo;
            self.CurPlayerInfo = unionPlayerInfo;
            self.E_Text_NameText.text = unionPlayerInfo.PlayerName;
            self.E_Text_LevelText.text = unionPlayerInfo.PlayerLevel.ToString();
            self.E_Text_PositionText.text = UnionData.UnionPosition[unionPlayerInfo.Position];
        }
    }
}