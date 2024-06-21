using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UnionJingXuanTimer)]
    public class UnionJingXuanTimer: ATimer<ES_UnionMy>
    {
        protected override void Run(ES_UnionMy self)
        {
            try
            {
                self.OnUnionJingXuanTimer();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [EntitySystemOf(typeof (ES_UnionMy))]
    [FriendOfAttribute(typeof (ES_UnionMy))]
    public static partial class ES_UnionMySystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionMy self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_UnionMyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionMyItemsRefresh);

            self.E_UnionRecordsBtnButton.AddListenerAsync(self.UnionRecordsBtn);
            self.E_Text_Button_1Button.AddListener(() => { self.OnShowModify(true); });
            self.E_ButtonModifyButton.AddListenerAsync(self.OnButtonModify);
            self.E_ButtonJingXuanButton.AddListenerAsync(self.OnButtonJingXuan);
            self.E_ButtonJingXuanButton.gameObject.SetActive(false);
            self.E_InputFieldPurposeInputField.onValueChanged.AddListener((string text) => { self.CheckSensitiveWords_2(); });
            self.E_ButtonApplyListButton.AddListenerAsync(self.OnButtonApplyList);
            self.E_ButtonApplyListButton.gameObject.SetActive(false);
            self.E_ButtonLeaveButton.AddListener(self.OnButtonLeave);
            self.E_ButtonNameButton.AddListenerAsync(self.OnButtonName);
            self.E_InputFieldNameInputField.onValueChanged.AddListener((string text) => { self.CheckSensitiveWords(); });
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionMy self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.UnionJingXuanTimer);

            // ReddotViewComponent redPointComponent = self.DomainScene().GetComponent<ReddotViewComponent>();
            // redPointComponent.UnRegisterReddot(ReddotType.UnionApply, self.Reddot_UnionApply);
            self.DestroyWidget();
        }

        public static void OnText_EnterUnion(this ES_UnionMy self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.Union, 2000009).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Friend);
        }

        public static async ETTask UnionRecordsBtn(this ES_UnionMy self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_UnionRecords);
            DlgUnionRecords dlgUnionRecords = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnionRecords>();
            dlgUnionRecords.Refresh(self.UnionInfo);
        }

        public static void OnShowModify(this ES_UnionMy self, bool val)
        {
            self.E_InputFieldPurposeInputField.gameObject.SetActive(val);
            self.E_ButtonModifyButton.gameObject.SetActive(val);
        }

        public static async ETTask OnButtonJingXuan(this ES_UnionMy self)
        {
            if (self.UnionInfo == null)
            {
                return;
            }

            FlyTipComponent.Instance.ShowFlyTipDi("UIUnionJingXuan 暂未开放");
            await ETTask.CompletedTask;
            // UI uI = await UIHelper.Create(self.ZoneScene(), UIType.UIUnionJingXuan);
            // uI.GetComponent<UIUnionJingXuanComponent>().OnUpdateUI(self.UnionInfo);
        }

        public static async ETTask OnButtonModify(this ES_UnionMy self)
        {
            string text = self.E_InputFieldPurposeInputField.text;
            bool mask = MaskWordComponent.Instance.IsContainSensitiveWords(text);
            if (mask)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("输入不合法!");
                return;
            }

            if (!StringHelper.IsSpecialChar(text))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("输入不合法!");
                return;
            }

            await UnionNetHelper.UnionOperatate(self.Root(), self.UnionInfo.UnionId, 2, text);
            self.UnionInfo.UnionPurpose = text;
            self.E_Text_PurposeText.text = text;
            self.OnShowModify(false);

            await ETTask.CompletedTask;
        }

        public static void Reddot_UnionApply(this ES_UnionMy self, int num)
        {
            self.E_ButtonApplyListButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void CheckSensitiveWords(this ES_UnionMy self)
        {
            string text_new = "";
            string text_old = self.E_InputFieldNameInputField.text;
            MaskWordComponent.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            self.E_InputFieldNameInputField.text = text_old;
        }

        public static void CheckSensitiveWords_2(this ES_UnionMy self)
        {
            string text_new = "";
            string text_old = self.E_InputFieldPurposeInputField.text;
            MaskWordComponent.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            self.E_InputFieldPurposeInputField.text = text_old;
            self.E_ButtonModifyButton.gameObject.SetActive(true);
        }

        public static async ETTask OnButtonName(this ES_UnionMy self)
        {
            string text = self.E_InputFieldNameInputField.text;
            bool mask = MaskWordComponent.Instance.IsContainSensitiveWords(text);
            if (mask)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("请重新输入！");
                return;
            }

            await UnionNetHelper.UnionOperatate(self.Root(), self.UnionInfo.UnionId, 1, text);
            self.UnionInfo.UnionName = text;
            self.E_Text_UnionNameText.text = self.UnionInfo.UnionName;
        }

        public static void OnButtonLeave(this ES_UnionMy self)
        {
            if (self.UnionInfo == null)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.UserId == self.UnionInfo.LeaderId && self.UnionInfo.UnionPlayerList.Count > 1)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("族长不能离开家族, 请先转移族长！");
                return;
            }

            PopupTipHelp.OpenPopupTip(self.Root(), "离开家族", "离开家族24小时内无法加入新家族", () => { self.RequestLevelUnion().Coroutine(); }, null)
                    .Coroutine();
        }

        public static async ETTask RequestLevelUnion(this ES_UnionMy self)
        {
            await UnionNetHelper.UnionLeave(self.Root());
        }

        public static async ETTask OnButtonApplyList(this ES_UnionMy self)
        {
            if (self.UnionInfo == null)
            {
                return;
            }

            self.EG_ShowSetRectTransform.gameObject.SetActive(false);

            FlyTipComponent.Instance.ShowFlyTipDi("UIUnionApplyList 暂未开放");
            // UIHelper.Create(self.ZoneScene(), UIType.UIUnionApplyList).Coroutine();
            // UI ui = UIHelper.GetUI(self.ZoneScene(), UIType.UIUnionApplyList);
            // ui.GetComponent<UIUnionApplyListComponent>().ActionFunc = () => { self.ShowSetShow(); };

            // C2M_ReddotReadRequest m_ReddotReadRequest = new C2M_ReddotReadRequest() { ReddotType = ReddotType.UnionApply };
            // M2C_ReddotReadResponse m_ReddotReadResponse =
            //         (M2C_ReddotReadResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(m_ReddotReadRequest);
            // self.Root().GetComponent<ReddotComponent>().RemoveReddont(ReddotType.UnionApply);

            await ETTask.CompletedTask;
        }

        public static void ShowSetShow(this ES_UnionMy self)
        {
            self.UnionInfo = null;
            self.EG_ShowSetRectTransform.gameObject.SetActive(true);
            self.OnUpdateUI().Coroutine();
        }

        public static async ETTask OnUpdateUI(this ES_UnionMy self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0));

            U2C_UnionMyInfoResponse response = await UnionNetHelper.UnionMyInfo(self.Root(), unionId);

            self.UnionInfo = response.UnionMyInfo;
            self.OnLinePlayer = response.OnLinePlayer;
            self.E_Text_LevelText.text = $"{response.UnionMyInfo.Level}";
            if (UnionConfigCategory.Instance.Contain(response.UnionMyInfo.Level))
            {
                UnionConfig unionConfig = UnionConfigCategory.Instance.Get(response.UnionMyInfo.Level);
                self.E_Text_ExpText.text = $"{response.UnionMyInfo.Exp}/{unionConfig.Exp}";
                if (response.UnionMyInfo.UnionGold <= unionConfig.UnionGoldLimit)
                {
                    self.E_Text_UnionGoldText.text =
                            $"{response.UnionMyInfo.UnionGold / 10000f:0.#}万/{unionConfig.UnionGoldLimit / 10000f:0.#}万";
                }
                else
                {
                    self.E_Text_UnionGoldText.text =
                            $"{unionConfig.UnionGoldLimit / 10000f:0.#}万/{unionConfig.UnionGoldLimit / 10000f:0.#}万";
                }
            }
            else
            {
                self.E_Text_ExpText.text = String.Empty;
                self.E_Text_UnionGoldText.text = string.Empty;
            }

            await self.UpdateMyUnion(self.UnionInfo);
        }

        public static void OnUnionJingXuanTimer(this ES_UnionMy self)
        {
            long lastTime = self.UnionInfo.JingXuanEndTime - TimeHelper.ServerNow();
            if (lastTime < 0)
            {
                self.E_TextJingXuanEndTimeText.text = string.Empty;
                return;
            }

            self.E_TextJingXuanEndTimeText.text = TimeHelper.ShowLeftTime(lastTime);
        }

        public static async ETTask UpdateMyUnion(this ES_UnionMy self, UnionInfo unionInfo)
        {
            //客户端获取家族等级
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0));
            U2C_UnionMyInfoResponse response = await UnionNetHelper.UnionMyInfo(self.Root(), unionId);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            UnionPlayerInfo mainPlayerInfo = UnionHelper.GetUnionPlayerInfo(self.UnionInfo.UnionPlayerList, userInfoComponent.UserInfo.UserId);
            UnionConfig unionCof = UnionConfigCategory.Instance.Get(unionInfo.Level);
            bool leader = userInfoComponent.UserInfo.UserId == self.UnionInfo.LeaderId;
            self.E_Text_OnLineText.text = $"在线人数 {self.OnLinePlayer.Count}";
            self.E_Text_PurposeText.text = self.UnionInfo.UnionPurpose;
            self.E_Text_NumberText.text = $"{self.UnionInfo.UnionPlayerList.Count}/{unionCof.PeopleNum}";
            self.E_Text_LeaderText.text = self.UnionInfo.LeaderName;
            self.E_Text_UnionNameText.text = self.UnionInfo.UnionName;
            self.EG_LeadNodeRectTransform.gameObject.SetActive(leader || mainPlayerInfo.Position != 0);
            self.E_ButtonApplyListButton.gameObject.SetActive(leader || mainPlayerInfo.Position != 0);
            self.E_ButtonJingXuanButton.gameObject.SetActive(self.UnionInfo.JingXuanEndTime > 0);
            if (self.UnionInfo.JingXuanEndTime > 0)
            {
                self.OnUnionJingXuanTimer();
                self.Root().GetComponent<TimerComponent>().Remove(ref self.UnionJingXuanTimer);
                self.UnionJingXuanTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UnionJingXuanTimer, self);
            }
            else
            {
                self.E_TextJingXuanEndTimeText.text = string.Empty;
            }

            List<Entity> childs = self.Children.Values.ToList();
            self.UnionInfo.UnionPlayerList.Sort(delegate(UnionPlayerInfo a, UnionPlayerInfo b)
            {
                //int leaderida = (a.UserID == self.UnionInfo.LeaderId) ? 1 : 0;
                //int leaderidb = (b.UserID == self.UnionInfo.LeaderId) ? 1 : 0;
                //return (leaderidb - leaderida);
                int positiona = a.Position == 0? 10 : a.Position;
                int positionb = b.Position == 0? 10 : b.Position;
                return positiona - positionb;
            });

            self.ShowUnionPlayerInfos.Clear();
            for (int i = 0; i < self.UnionInfo.UnionPlayerList.Count; i++)
            {
                UnionPlayerInfo unionPlayerInfo = self.UnionInfo.UnionPlayerList[i];
                self.ShowUnionPlayerInfos.Add(unionPlayerInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemUnionMyItems, self.ShowUnionPlayerInfos.Count);
            self.E_UnionMyItemsLoopVerticalScrollRect.SetVisible(true, self.ShowUnionPlayerInfos.Count);
        }

        private static void OnUnionMyItemsRefresh(this ES_UnionMy self, Transform transform, int index)
        {
            Scroll_Item_UnionMyItem scrollItemUnionMyItem = self.ScrollItemUnionMyItems[index].BindTrans(transform);
            scrollItemUnionMyItem.OnUpdateUI(self.UnionInfo, self.ShowUnionPlayerInfos[index]);
        }
    }
}