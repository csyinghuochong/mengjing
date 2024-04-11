using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

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

    [FriendOf(typeof (DlgWatchMenuViewComponent))]
    [FriendOf(typeof (DlgWatchMenu))]
    public static class DlgWatchMenuSystem
    {
        public static void RegisterUIEvent(this DlgWatchMenu self)
        {
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
            // bool isLeader = self.ZoneScene().GetComponent<TeamComponent>().IsTeamLeader();
            //
            // PopupTipHelp.OpenPopupTip(self.DomainScene(), "我的队伍", isLeader? "是否离开队伍" : "是否离开队伍？",
            //     () =>
            //     {
            //         self.ZoneScene().GetComponent<TeamComponent>().SendLeaveRequest().Coroutine();
            //         self.OnClickImageBg();
            //     }).Coroutine();
        }

        public static void OnButton_InviteUnion(this DlgWatchMenu self)
        {
            // Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            // UserInfo userInfo = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo;
            //
            // Unit watchUnit = unit.GetParent<UnitComponent>().Get(self.UserId);
            // string playName = watchUnit.GetComponent<UnitInfoComponent>().MasterName;
            // PopupTipHelp.OpenPopupTip(self.ZoneScene(), "邀请加入", $"邀请玩家{playName}加入{userInfo.UnionName}家族?", () =>
            // {
            //     C2M_UnionInviteRequest request = new C2M_UnionInviteRequest() { InviteId = self.UserId };
            //     self.ZoneScene().GetComponent<SessionComponent>().Session.Send(request);
            // }, null).Coroutine();
        }

        public static void OnButton_KickUnion(this DlgWatchMenu self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "踢出家族", "确定将该玩家踢出家族?", () => { self.RequestKickUnion().Coroutine(); }, null).Coroutine();
        }

        public static async ETTask OnButton_JinYan(this DlgWatchMenu self)
        {
            if (self.UserId == 0)
            {
                return;
            }

            // C2C_ChatJinYanRequest reuqest = new C2C_ChatJinYanRequest()
            // {
            //     JinYanId = self.UserId,
            //     JinYanPlayer = self.UserName,
            //     UnitId = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.UserId,
            // };
            // C2C_ChatJinYanResponse response = (C2C_ChatJinYanResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(reuqest);
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_ServerBlack(this DlgWatchMenu self)
        {
            // int zone = self.ZoneScene().GetComponent<AccountInfoComponent>().ServerId;
            // if (string.IsNullOrEmpty(self.UserName))
            // {
            //     self.OnClickImageBg();
            //     return;
            // }
            //
            // for (int i = 1; i <= 5; i++)
            // {
            //     C2C_ChatJinYanRequest reuqest = new C2C_ChatJinYanRequest()
            //     {
            //         JinYanId = self.UserId, JinYanPlayer = self.UserName, UnitId = i + 100000,
            //     };
            //     C2C_ChatJinYanResponse response =
            //             (C2C_ChatJinYanResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(reuqest);
            // }
            //
            // C2C_GMCommonRequest request = new C2C_GMCommonRequest()
            // {
            //     Account = self.ZoneScene().GetComponent<AccountInfoComponent>().Account, Context = $"black {zone} {self.UserName}"
            // };
            // C2C_GMCommonResponse repose = (C2C_GMCommonResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(request);
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_OneChallenge(this DlgWatchMenu self)
        {
            // BattleMessageComponent battleMessageComponent = self.ZoneScene().GetComponent<BattleMessageComponent>();
            // if (!battleMessageComponent.OneChallengeTime.ContainsKey(self.UserId))
            // {
            //     battleMessageComponent.OneChallengeTime.Add(self.UserId, TimeHelper.ServerNow());
            // }
            // else
            // {
            //     if (TimeHelper.ServerNow() - battleMessageComponent.OneChallengeTime[self.UserId] < TimeHelper.Minute)
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("一分钟内不能向该玩家再次发起挑战！");
            //         return;
            //     }
            //
            //     battleMessageComponent.OneChallengeTime[self.UserId] = TimeHelper.ServerNow();
            // }
            //
            // C2M_OneChallengeRequest request = new C2M_OneChallengeRequest() { Operatate = 1, OtherId = self.UserId };
            // M2C_OneChallengeResponse response =
            //         (M2C_OneChallengeResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(request);
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_UnionOperate(this DlgWatchMenu self, int postion)
        {
            // Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            // C2U_UnionOperatateRequest c2M_ItemHuiShouRequest = new C2U_UnionOperatateRequest()
            // {
            //     UnitId = unit.Id, Operatate = 3, UnionId = unit.GetUnionId(), Value = $"{self.UserId}_{postion}"
            // };
            // U2C_UnionOperatateResponse r2c_roleEquip =
            //         (U2C_UnionOperatateResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_ItemHuiShouRequest);
            // UI uI = UIHelper.GetUI(self.ZoneScene(), UIType.UIFriend);
            // uI?.GetComponent<UIFriendComponent>().OnUpdateMyUnion();
            self.OnClickImageBg();
        }

        public static void OnButton_UnionTransfer(this DlgWatchMenu self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "转移族长", "是否转移族长？", () => { self.RequestUnionTransfer().Coroutine(); }, null).Coroutine();
        }

        public static async ETTask RequestUnionTransfer(this DlgWatchMenu self)
        {
            // C2M_UnionTransferRequest request = new C2M_UnionTransferRequest() { NewLeader = self.UserId };
            // M2C_UnionTransferResponse response =
            //         (M2C_UnionTransferResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(request);
            // UI uI = UIHelper.GetUI(self.ZoneScene(), UIType.UIFriend);
            // uI?.GetComponent<UIFriendComponent>().OnUpdateMyUnion();
            self.OnClickImageBg();
        }

        public static async ETTask RequestKickUnion(this DlgWatchMenu self)
        {
            // Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            // long unionId = (unit.GetComponent<NumericComponent>().GetAsLong(NumericType.UnionId_0));
            // C2U_UnionKickOutRequest c2M_SkillSet = new C2U_UnionKickOutRequest() { UnionId = unionId, UserId = self.UserId };
            // U2C_UnionKickOutResponse m2C_SkillSet =
            //         (U2C_UnionKickOutResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_SkillSet);
            //
            // UI uifreind = UIHelper.GetUI(self.ZoneScene(), UIType.UIFriend);
            // uifreind.GetComponent<UIFriendComponent>().OnUpdateMyUnion();

            self.OnClickImageBg();
        }

        public static void OnButton_KickOut(this DlgWatchMenu self)
        {
            // PopupTipHelp.OpenPopupTip(self.DomainScene(), "我的队伍", "是否踢出队伍？",
            //     () =>
            //     {
            //         self.ZoneScene().GetComponent<TeamComponent>().SendKickOutRequest(self.UserId).Coroutine();
            //         self.OnClickImageBg();
            //     }).Coroutine();
        }

        public static async ETTask OnButton_AddFriend(this DlgWatchMenu self)
        {
            // UserInfoComponent userInfoComponent = self.ZoneScene().GetComponent<UserInfoComponent>();
            // C2F_FriendApplyRequest c2F_FriendApplyReplyRequest = new C2F_FriendApplyRequest()
            // {
            //     UserID = self.UserId,
            //     RoleInfo = new FriendInfo()
            //     {
            //         UserId = userInfoComponent.UserInfo.UserId,
            //         PlayerName = userInfoComponent.UserInfo.Name,
            //         PlayerLevel = userInfoComponent.UserInfo.Lv,
            //         Occ = userInfoComponent.UserInfo.Occ,
            //     }
            // };
            // F2C_FriendApplyResponse f2C_FriendApplyResponse =
            //         (F2C_FriendApplyResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2F_FriendApplyReplyRequest);
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_BlackAdd(this DlgWatchMenu self)
        {
            // UserInfoComponent userInfoComponent = self.ZoneScene().GetComponent<UserInfoComponent>();
            // C2F_FriendBlacklistRequest c2F_FriendApplyReplyRequest = new C2F_FriendBlacklistRequest()
            // {
            //     OperateType = 1, UserID = userInfoComponent.UserInfo.UserId, FriendId = self.UserId,
            // };
            // F2C_FriendBlacklistResponse f2C_FriendApplyResponse =
            //         (F2C_FriendBlacklistResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2F_FriendApplyReplyRequest);
            // NetHelper.RequestFriendInfo(self.ZoneScene()).Coroutine();
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_BlackRemove(this DlgWatchMenu self)
        {
            // UserInfoComponent userInfoComponent = self.ZoneScene().GetComponent<UserInfoComponent>();
            // C2F_FriendBlacklistRequest c2F_FriendApplyReplyRequest = new C2F_FriendBlacklistRequest()
            // {
            //     OperateType = 2, UserID = userInfoComponent.UserInfo.UserId, FriendId = self.UserId,
            // };
            // F2C_FriendBlacklistResponse f2C_FriendApplyResponse =
            //         (F2C_FriendBlacklistResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2F_FriendApplyReplyRequest);
            // NetHelper.RequestFriendInfo(self.ZoneScene()).Coroutine();
            self.OnClickImageBg();
        }

        public static async ETTask OnButton_InviteTeam(this DlgWatchMenu self)
        {
            // C2T_TeamInviteRequest c2M_SkillSet = new C2T_TeamInviteRequest()
            // {
            //     UserID = self.UserId, TeamPlayerInfo = UnitHelper.GetSelfTeamPlayerInfo(self.ZoneScene())
            // };
            // T2C_TeamInviteResponse m2C_SkillSet =
            //         (T2C_TeamInviteResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_SkillSet);

            self.OnClickImageBg();
        }

        public static void OnButton_ApplyTeam(this DlgWatchMenu self)
        {
            // TeamComponent teamComponent = self.ZoneScene().GetComponent<TeamComponent>();
            // teamComponent.SendTeamApply(self.TeamId, 0, 0, 0, false).Coroutine();
            self.OnClickImageBg();
        }

        public static async ETTask OnClickButton_Watch(this DlgWatchMenu self)
        {
            // C2F_WatchPlayerRequest c2M_SkillSet = new C2F_WatchPlayerRequest() { UserId = self.UserId, WatchType = 0 };
            // F2C_WatchPlayerResponse m2C_SkillSet =
            //         (F2C_WatchPlayerResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_SkillSet);
            //
            // UI uI = await UIHelper.Create(self.DomainScene(), UIType.UIWatch);
            // uI.GetComponent<UIWatchComponent>().OnUpdateUI(m2C_SkillSet);

            self.OnClickImageBg();
        }

        /// <summary>
        /// 家族菜单
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

            // C2F_WatchPlayerRequest c2M_SkillSet = new C2F_WatchPlayerRequest() { UserId = self.UserId, WatchType = 2 };
            // F2C_WatchPlayerResponse m2C_SkillSet =
            //         (F2C_WatchPlayerResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_SkillSet);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            Unit watchUnit = unit.GetParent<UnitComponent>().Get(userId);
            long myunionid = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);
            long wathunion = watchUnit != null? watchUnit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0) : 0;

            // self.TeamId = m2C_SkillSet.TeamId;
            // int friendType = self.ZoneScene().GetComponent<FriendComponent>().GetFriendType(userId);
            // TeamInfo teamInfo = self.ZoneScene().GetComponent<TeamComponent>().GetSelfTeam();
            // long myUserId = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.UserId;
            // bool isLeader = teamInfo != null && teamInfo.PlayerList[0].UserID == myUserId;

            //self.Button_ApplyTeam.SetActive(false); 申请入队
            //self.Button_Leave.SetActive(false);     离开队伍
            //self.Button_KickOut.SetActive(false);   踢出队伍
            //self.Button_AddFriend.SetActive(false); 添加好友
            //self.Button_InviteTeam.SetActive(false);邀请组队
            //self.Button_Watch.SetActive(false);     观察

            // self.View.E_Button_ApplyTeamButton.gameObject.SetActive(teamInfo == null && userId != myUserId && m2C_SkillSet.TeamId != 0);
            // self.View.E_Button_LeaveTeamButton.gameObject.SetActive(teamInfo != null && userId == myUserId);
            // self.View.E_Button_KickTeamButton.gameObject.SetActive(isLeader && userId != myUserId && m2C_SkillSet.TeamId == myUserId);
            // self.View.E_Button_AddFriendButton.gameObject.SetActive(friendType == 0);
            // self.View.E_Button_BlackAddButton.gameObject.SetActive(friendType == 0);
            // self.View.E_Button_BlackRemoveButton.gameObject.SetActive(friendType == 2);
            // self.View.E_Button_InviteTeamButton.gameObject.SetActive(userId != myUserId && (isLeader || teamInfo == null) &&
            //     m2C_SkillSet.TeamId == 0);
            // self.View.E_Button_WatchButton.gameObject.SetActive(true);
            // self.View.E_Button_KickUnionButton.gameObject.SetActive(false);
            // self.View.E_Button_InviteUnionButton.gameObject.SetActive(myunionid > 0 && wathunion == 0);

            switch (menuEnumType)
            {
                case MenuEnumType.Main:
                case MenuEnumType.Chat:
                    // AccountInfoComponent accountInfoComponent = self.ZoneScene().GetComponent<AccountInfoComponent>();
                    // MapComponent mapComponent = self.ZoneScene().GetComponent<MapComponent>();
                    // self.View.E_Button_OneChallengeButton.gameObject.SetActive(mapComponent.SceneTypeEnum == SceneTypeEnum.MainCityScene);
                    // self.View.E_Button_ServerBlackButton.gameObject.SetActive(GMHelp.GmAccount.Contains(accountInfoComponent.Account));
                    // self.View.E_Button_JinYanButton.gameObject.SetActive(jinyan);
                    break;
                case MenuEnumType.Team:
                    break;
            }

            self.OnUpdateDi();
        }
    }
}