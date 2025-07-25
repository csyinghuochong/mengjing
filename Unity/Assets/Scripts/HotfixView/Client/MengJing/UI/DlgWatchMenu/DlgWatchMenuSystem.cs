using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public enum MenuEnumType
    {
        Main = 1,
        Team = 2,
        Union = 3,
        Chat = 4,
    }

    public static class MenuOperation
    {
        public const int Watch = 1;
        public const int InviteTeam = 2;
        public const int AddFriend = 3;
        public const int KickTeam = 4;
        public const int LeaveTeam = 5;
        public const int ApplyTeam = 6;
        public const int InviteUnion = 7;
        public const int KickUnion = 8;
        public const int BlackAdd = 9;
        public const int BlackRemove = 10;
        public const int UnionTrans = 11;
        public const int UnionAider = 12;
        public const int UnionElde = 13;
        public const int UnionDismiss = 14;
        public const int OneChallenge = 15;
        public const int JinYan = 16;
    }

    [FriendOf(typeof(DlgWatchMenuViewComponent))]
    [FriendOf(typeof(DlgWatchMenu))]
    public static class DlgWatchMenuSystem
    {
        public static void RegisterUIEvent(this DlgWatchMenu self)
        {
            self.View.E_ImageBgButton.AddListener(self.OnClickImageBg);
            self.View.E_Button_InviteUnionButton.AddListener(self.OnButton_InviteUnion);
            self.View.E_Button_KickUnionButton.AddListener(self.OnButton_KickUnion);
            self.View.E_Button_LeaveTeamButton.AddListener(self.OnButton_KickOut);
            self.View.E_Button_AddFriendButton.AddListenerAsync(self.OnButton_AddFriend);
            self.View.E_Button_WatchButton.AddListenerAsync(self.OnClickButton_Watch);
            self.View.E_Button_InviteTeamButton.AddListenerAsync(self.OnButton_InviteTeam);
            self.View.E_Button_ApplyTeamButton.AddListener(self.OnButton_ApplyTeam);
            self.View.E_Button_BlackRemoveButton.AddListenerAsync(self.OnButton_BlackRemove);
            self.View.E_Button_BlackAddButton.AddListenerAsync(self.OnButton_BlackAdd);
            self.View.E_Button_UnionTransferButton.AddListener(self.OnButton_UnionTransfer);
            self.View.E_Button_UnionAiderButton.AddListener(() => { self.OnButton_UnionOperate(2).Coroutine(); });
            self.View.E_Button_UnionElderButton.AddListener(() => { self.OnButton_UnionOperate(3).Coroutine(); });
            self.View.E_Button_UnionDismissButton.AddListener(() => { self.OnButton_UnionOperate(0).Coroutine(); });
            self.View.E_Button_OneChallengeButton.AddListenerAsync(self.OnButton_OneChallenge);
            self.View.E_Button_ServerBlackButton.AddListenerAsync(self.OnButton_ServerBlack);
            self.View.E_Button_JinYanButton.AddListenerAsync(self.OnButton_JinYan);
        }

        public static void ShowWindow(this DlgWatchMenu self, Entity contextData = null)
        {
        }

        public static void OnClickImageBg(this DlgWatchMenu self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_WatchMenu);
        }

        public static void OnButton_Leave(this DlgWatchMenu self)
        {
            bool isLeader = self.Root().GetComponent<TeamComponentC>().IsTeamLeader();

            PopupTipHelp.OpenPopupTip(self.Root(), "我的队伍", isLeader ? "是否离开队伍" : "是否离开队伍？",
                () =>
                {
                    TeamNetHelper.SendLeaveRequest(self.Root()).Coroutine();
                    self.OnClickImageBg();
                }).Coroutine();
        }

        public static void OnButton_InviteUnion(this DlgWatchMenu self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;

            Unit watchUnit = unit.GetParent<UnitComponent>().Get(self.UserId);
            string playName = watchUnit.GetComponent<UnitInfoComponent>().MasterName;
            PopupTipHelp.OpenPopupTip(self.Root(), "邀请加入", $"邀请玩家{playName}加入{userInfo.UnionName}公会?",
                () => { UnionNetHelper.UnionInviteRequest(self.Root(), self.UserId); }, null).Coroutine();
        }

        public static void OnButton_KickUnion(this DlgWatchMenu self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "踢出公会", "确定将该玩家踢出公会?", () => { self.RequestKickUnion().Coroutine(); }, null).Coroutine();
        }

        public static async ETTask OnButton_JinYan(this DlgWatchMenu self)
        {
            if (self.UserId == 0)
            {
                return;
            }

            await ChatNetHelper.ChatJinYanRequest(self.Root(), self.UserId, self.UserName,
                self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId);
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_ServerBlack(this DlgWatchMenu self)
        {
            int zone = self.Root().GetComponent<PlayerInfoComponent>().ServerItem.ServerId;
            if (string.IsNullOrEmpty(self.UserName))
            {
                self.OnClickImageBg();
                return;
            }

            for (int i = 1; i <= 5; i++)
            {
                await ChatNetHelper.ChatJinYanRequest(self.Root(), self.UserId, self.UserName, i + 100000);
            }

            await UserInfoNetHelper.GMCommon(self.Root(), $"black {zone} {self.UserName}");

            self.OnClickImageBg();
        }

        public static async ETTask OnButton_OneChallenge(this DlgWatchMenu self)
        {
            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            if (!battleMessageComponent.OneChallengeTime.ContainsKey(self.UserId))
            {
                battleMessageComponent.OneChallengeTime.Add(self.UserId, TimeHelper.ServerNow());
            }
            else
            {
                if (TimeHelper.ServerNow() - battleMessageComponent.OneChallengeTime[self.UserId] < TimeHelper.Minute)
                {
                    FlyTipComponent.Instance.ShowFlyTip("一分钟内不能向该玩家再次发起挑战！");
                    return;
                }

                battleMessageComponent.OneChallengeTime[self.UserId] = TimeHelper.ServerNow();
            }

            await UserInfoNetHelper.OneChallengeRequest(self.Root(), 1, self.UserId);

            self.OnClickImageBg();

            await ETTask.CompletedTask;
        }

        public static async ETTask OnButton_UnionOperate(this DlgWatchMenu self, int postion)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            await UnionNetHelper.UnionOperatate(self.Root(), unit.GetUnionId(), 3, $"{self.UserId}_{postion}");

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnion>().OnUpdateMyUnion();
            self.OnClickImageBg();
        }

        public static void OnButton_UnionTransfer(this DlgWatchMenu self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "转移会长", "是否转移会长？", () => { self.RequestUnionTransfer().Coroutine(); }, null).Coroutine();
        }

        public static async ETTask RequestUnionTransfer(this DlgWatchMenu self)
        {
            await UnionNetHelper.UnionTransferRequest(self.Root(), self.UserId);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnion>().OnUpdateMyUnion();
            self.OnClickImageBg();
        }

        public static async ETTask RequestKickUnion(this DlgWatchMenu self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);

            await UnionNetHelper.UnionKickOutRequest(self.Root(), unionId, self.UserId);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnion>().OnUpdateMyUnion();

            self.OnClickImageBg();
        }

        public static void OnButton_KickOut(this DlgWatchMenu self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "我的队伍", "是否踢出队伍？",
                () =>
                {
                    TeamNetHelper.TeamKickOutRequest(self.Root(), self.UserId).Coroutine();
                    self.OnClickImageBg();
                }).Coroutine();
        }

        public static async ETTask OnButton_AddFriend(this DlgWatchMenu self)
        {
            await FriendNetHelper.RequestFriendApply(self.Root(), self.UserId);
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_BlackAdd(this DlgWatchMenu self)
        {
            await FriendNetHelper.RequestAddBlack(self.Root(), self.UserId);
            await FriendNetHelper.RequestFriendInfo(self.Root());
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_BlackRemove(this DlgWatchMenu self)
        {
            await FriendNetHelper.RequestRemoveBlack(self.Root(), self.UserId);
            await FriendNetHelper.RequestFriendInfo(self.Root());
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_InviteTeam(this DlgWatchMenu self)
        {
            await TeamNetHelper.TeamInviteRequest(self.Root(), self.UserId, UnitHelper.GetSelfTeamPlayerInfo(self.Root()));

            self.OnClickImageBg();
        }

        public static void OnButton_ApplyTeam(this DlgWatchMenu self)
        {
            TeamNetHelper.TeamDungeonApplyRequest(self.Root(), self.TeamId, 0, 0, 0, false, MapTypeEnum.DragonDungeon).Coroutine();

            self.OnClickImageBg();
        }

        public static async ETTask OnClickButton_Watch(this DlgWatchMenu self)
        {
            F2C_WatchPlayerResponse response = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.UserId, 0);

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Watch);
            DlgWatch dlgWatch = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>();
            dlgWatch.OnUpdateUI(response);
            self.OnClickImageBg();
        }

        /// <summary>
        /// 公会菜单
        /// </summary>
        /// <param name="self"></param>
        /// <param name="menuList"></param>
        /// <param name="userId"></param>
        public static void OnUpdateUI_2(this DlgWatchMenu self, List<int> menuList, long userId)
        {
            self.UserId = userId;
            self.View.E_Button_ApplyTeamButton.gameObject.SetActive(menuList.Contains(MenuOperation.ApplyTeam));
            self.View.E_Button_LeaveTeamButton.gameObject.SetActive(menuList.Contains(MenuOperation.LeaveTeam));
            self.View.E_Button_KickTeamButton.gameObject.SetActive(menuList.Contains(MenuOperation.KickTeam));
            self.View.E_Button_AddFriendButton.gameObject.SetActive(menuList.Contains(MenuOperation.AddFriend));
            self.View.E_Button_InviteTeamButton.gameObject.SetActive(menuList.Contains(MenuOperation.InviteTeam));
            self.View.E_Button_WatchButton.gameObject.SetActive(menuList.Contains(MenuOperation.Watch));
            self.View.E_Button_InviteUnionButton.gameObject.SetActive(menuList.Contains(MenuOperation.InviteUnion));
            self.View.E_Button_KickUnionButton.gameObject.SetActive(menuList.Contains(MenuOperation.KickUnion));
            self.View.E_Button_BlackRemoveButton.gameObject.SetActive(menuList.Contains(MenuOperation.BlackRemove));
            self.View.E_Button_BlackAddButton.gameObject.SetActive(menuList.Contains(MenuOperation.BlackAdd));
            self.View.E_Button_UnionTransferButton.gameObject.SetActive(menuList.Contains(MenuOperation.UnionTrans));
            self.View.E_Button_UnionAiderButton.gameObject.SetActive(menuList.Contains(MenuOperation.UnionAider));
            self.View.E_Button_UnionElderButton.gameObject.SetActive(menuList.Contains(MenuOperation.UnionElde));
            self.View.E_Button_UnionDismissButton.gameObject.SetActive(menuList.Contains(MenuOperation.UnionDismiss));
            
            self.View.E_Button_OneChallengeButton.gameObject.SetActive(false); 
            self.View.E_Button_ServerBlackButton.gameObject.SetActive(false);
            self.View.E_Button_JinYanButton.gameObject.SetActive(false);

            self.OnUpdatePos();
            self.OnUpdateDi();
        }

        public static void OnUpdateDi(this DlgWatchMenu self)
        {
            int number = 0;
            for (int i = 0; i < self.View.EG_PositionSetRectTransform.transform.childCount; i++)
            {
                if (self.View.EG_PositionSetRectTransform.transform.GetChild(i).gameObject.activeSelf)
                {
                    number++;
                }
            }

            self.View.E_ImageDiImage.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(220, number * 70f);
        }

        public static void OnUpdatePos(this DlgWatchMenu self)
        {
            Vector2 localPoint;
            RectTransform canvas = self.View.uiTransform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, Input.mousePosition, uiCamera, out localPoint);
            self.View.EG_PositionSetRectTransform.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
            self.View.E_ImageDiImage.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
            self.View.E_ImageDiImage.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 0f);
        }

        public static async ETTask OnUpdateUI_1(this DlgWatchMenu self, MenuEnumType menuEnumType, long userId, string userName, bool jinyan)
        {
            self.OnUpdatePos();

            self.UserId = userId;
            self.UserName = userName;
            for (int i = 0; i < self.View.EG_PositionSetRectTransform.transform.childCount; i++)
            {
                self.View.EG_PositionSetRectTransform.transform.GetChild(i).gameObject.SetActive(false);
            }

            F2C_WatchPlayerResponse f2CWatchPlayerResponse = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.UserId, 2);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            Unit watchUnit = unit.GetParent<UnitComponent>().Get(userId);
            long myunionid = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);
            long wathunion = watchUnit != null ? watchUnit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0) : 0;

            self.TeamId = f2CWatchPlayerResponse.TeamId;
            int friendType = self.Root().GetComponent<FriendComponent>().GetFriendType(userId);
            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            long myUserId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            bool isLeader = teamInfo != null && teamInfo.PlayerList[0].UserID == myUserId;

            self.View.E_Button_ApplyTeamButton.gameObject.SetActive(false); // 申请入队
            self.View.E_Button_LeaveTeamButton.gameObject.SetActive(false); // 离开队伍
            self.View.E_Button_KickTeamButton.gameObject.SetActive(false); // 踢出队伍
            self.View.E_Button_AddFriendButton.gameObject.SetActive(false); // 添加好友
            self.View.E_Button_InviteTeamButton.gameObject.SetActive(false); // 邀请组队
            self.View.E_Button_WatchButton.gameObject.SetActive(false); // 观察

            self.View.E_Button_ApplyTeamButton.gameObject.SetActive(teamInfo == null && userId != myUserId && f2CWatchPlayerResponse.TeamId != 0);
            self.View.E_Button_LeaveTeamButton.gameObject.SetActive(teamInfo != null && userId == myUserId);
            self.View.E_Button_KickTeamButton.gameObject.SetActive(isLeader && userId != myUserId && f2CWatchPlayerResponse.TeamId == myUserId);
            self.View.E_Button_AddFriendButton.gameObject.SetActive(friendType == 0);
            self.View.E_Button_BlackAddButton.gameObject.SetActive(friendType == 0);
            self.View.E_Button_BlackRemoveButton.gameObject.SetActive(friendType == 2);
            self.View.E_Button_InviteTeamButton.gameObject.SetActive(userId != myUserId && (isLeader || teamInfo == null) && f2CWatchPlayerResponse.TeamId == 0);
            self.View.E_Button_WatchButton.gameObject.SetActive(true);
            self.View.E_Button_KickUnionButton.gameObject.SetActive(false);
            self.View.E_Button_InviteUnionButton.gameObject.SetActive(myunionid > 0 && wathunion == 0);

            switch (menuEnumType)
            {
                case MenuEnumType.Main:
                case MenuEnumType.Chat:
                    PlayerInfoComponent accountInfoInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
                    MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
                    self.View.E_Button_OneChallengeButton.gameObject.SetActive(false); ///mapComponent.MapType == MapTypeEnum.MainCityScene);
                    self.View.E_Button_ServerBlackButton.gameObject.SetActive(false);
                    self.View.E_Button_JinYanButton.gameObject.SetActive(false);///jinyan);
                    break;
                case MenuEnumType.Team:
                    break;
            }

            self.OnUpdateDi();

            await ETTask.CompletedTask;
        }
    }
}