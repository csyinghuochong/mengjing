using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UnionJingXuanTimer)]
    public class UnionJingXuanTimer : ATimer<ES_UnionMy>
    {
        protected override void Run(ES_UnionMy self)
        {
            try
            {
                self.OnUnionJingXuanTimer();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [FriendOf(typeof(Scroll_Item_UnionMyItem))]
    [EntitySystemOf(typeof(ES_UnionMy))]
    [FriendOfAttribute(typeof(ES_UnionMy))]
    public static partial class ES_UnionMySystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionMy self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_UnionMyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionMyItemsRefresh);

            self.E_UnionRecordsBtnButton.AddListenerAsync(self.OnUnionRecordsBtnButton);
            self.E_Text_Button_1Button.AddListener(() => { self.OnShowModify(true); });
            self.E_ButtonModifyButton.AddListenerAsync(self.OnButtonModifyButton);
            self.E_ButtonJingXuanButton.AddListenerAsync(self.OnButtonJingXuanButton);
            self.E_ButtonJingXuanButton.gameObject.SetActive(false);
            self.E_InputFieldPurposeInputField.onValueChanged.AddListener((string text) => { self.CheckSensitiveWords_2(); });
            self.E_ButtonApplyListButton.AddListenerAsync(self.OnButtonApplyListButton);
            self.E_ButtonApplyListButton.gameObject.SetActive(false);
            self.E_ButtonLeaveButton.AddListener(self.OnButtonLeaveButton);
            self.E_ButtonNameButton.AddListenerAsync(self.OnButtonNameButton);
            self.E_InputFieldNameInputField.onValueChanged.AddListener((string text) => { self.CheckSensitiveWords(); });
            self.E_Text_EnterUnionButton.AddListener(self.OnText_EnterUnionButton);
            self.E_Text_LevelButton.AddListener(self.OnText_LevelButton);
            self.E_Text_ExpButton.AddListener(self.OnText_ExpButton);
            self.E_Button_UpgradeButton.AddListener(self.OnButtonUpgrade);
            
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.UnionApply, self.Reddot_UnionApply);
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionMy self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.UnionJingXuanTimer);

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent?.UnRegisterReddot(ReddotType.UnionApply, self.Reddot_UnionApply);
            self.DestroyWidget();
        }

        public static void OnText_EnterUnion(this ES_UnionMy self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.Union, 2000009).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Friend);
        }

        public static async ETTask OnUnionRecordsBtnButton(this ES_UnionMy self)
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

        public static async ETTask OnButtonJingXuanButton(this ES_UnionMy self)
        {
            if (self.UnionInfo == null)
            {
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_UnionJingXuan);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnionJingXuan>().OnUpdateUI(self.UnionInfo);
        }

        public static async ETTask OnButtonModifyButton(this ES_UnionMy self)
        {
            string text = self.E_InputFieldPurposeInputField.text;
            bool mask = MaskWordHelper.Instance.IsContainSensitiveWords(text);
            if (mask)
            {
                FlyTipComponent.Instance.ShowFlyTip("输入不合法!");
                return;
            }

            if (!StringHelper.IsSpecialChar(text))
            {
                FlyTipComponent.Instance.ShowFlyTip("输入不合法!");
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
            MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            self.E_InputFieldNameInputField.text = text_old;
        }

        public static void CheckSensitiveWords_2(this ES_UnionMy self)
        {
            string text_new = "";
            string text_old = self.E_InputFieldPurposeInputField.text;
            MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            self.E_InputFieldPurposeInputField.text = text_old;
            self.E_ButtonModifyButton.gameObject.SetActive(true);
        }

        public static async ETTask OnButtonNameButton(this ES_UnionMy self)
        {
            string text = self.E_InputFieldNameInputField.text;
            bool mask = MaskWordHelper.Instance.IsContainSensitiveWords(text);
            if (mask)
            {
                FlyTipComponent.Instance.ShowFlyTip("请重新输入！");
                return;
            }

            await UnionNetHelper.UnionOperatate(self.Root(), self.UnionInfo.UnionId, 1, text);
            self.UnionInfo.UnionName = text;
            self.E_Text_UnionNameText.text = self.UnionInfo.UnionName;
        }

        public static void OnButtonLeaveButton(this ES_UnionMy self)
        {
            if (self.UnionInfo == null)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.UserId == self.UnionInfo.LeaderId && self.UnionInfo.UnionPlayerList.Count > 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("会长不能离开公会， 请先转移会长！");
                return;
            }

            PopupTipHelp.OpenPopupTip(self.Root(), "离开公会", "离开公会24小时内无法加入新公会", () => { self.RequestLevelUnion().Coroutine(); }, null)
                    .Coroutine();
        }

        public static async ETTask RequestLevelUnion(this ES_UnionMy self)
        {
            await UnionNetHelper.UnionLeave(self.Root());
        }

        public static async ETTask OnButtonApplyListButton(this ES_UnionMy self)
        {
            if (self.UnionInfo == null)
            {
                return;
            }

            self.EG_LeftRectTransform.gameObject.SetActive(false);
            self.EG_RightRectTransform.gameObject.SetActive(false);

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_UnionApplyList);
            DlgUnionApplyList dlgUnionApplyList = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnionApplyList>();
            dlgUnionApplyList.ActionFunc = () => { self.ShowSetShow(); };

            UserInfoNetHelper.ReddotReadRequest(self.Root(), ReddotType.UnionApply).Coroutine();
        }

        public static void ShowSetShow(this ES_UnionMy self)
        {
            self.UnionInfo = null;
            self.EG_LeftRectTransform.gameObject.SetActive(true);
            self.EG_RightRectTransform.gameObject.SetActive(true);
            self.OnUpdateUI().Coroutine();
        }

        public static async ETTask OnUpdateUI(this ES_UnionMy self)
        {
            U2C_UnionMyInfoResponse response = await UnionNetHelper.UnionMyInfo(self.Root());

            self.UnionInfo = response.UnionMyInfo;
            self.OnLinePlayer = response.OnLinePlayer;
 
            self.UpdateMyUnion();
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

        public static void UpdateUnionLevel(this ES_UnionMy self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            UnionPlayerInfo mainPlayerInfo = UnionHelper.GetUnionPlayerInfo(self.UnionInfo.UnionPlayerList, userInfoComponent.UserInfo.UserId);
            
            int unionlevel = self.UnionInfo.Level;
            UnionConfig unionConfig = UnionConfigCategory.Instance.Get(unionlevel);
            bool leader = userInfoComponent.UserInfo.UserId == self.UnionInfo.LeaderId;
            self.E_Text_LevelText.text =  self.UnionInfo.Level.ToString();
            using (zstring.Block())
            {
                if (UnionConfigCategory.Instance.Contain(unionlevel + 1))
                {
                    self.E_Text_ExpText.text = zstring.Format("{0}/{1}", self.UnionInfo.Exp, unionConfig.Exp);
                    if (self.UnionInfo.UnionGold <= unionConfig.UnionGoldLimit)
                    {
                        self.E_Text_UnionGoldText.text = zstring.Format("{0}万/{1}万", (self.UnionInfo.UnionGold / 10000f).ToString("0.#"),
                            (unionConfig.UnionGoldLimit / 10000f).ToString("0.#"));
                    }
                    else
                    {
                        self.E_Text_UnionGoldText.text = zstring.Format("{0}万/{1}万", (unionConfig.UnionGoldLimit / 10000f).ToString("0.#"),
                            (unionConfig.UnionGoldLimit / 10000f).ToString("0.#"));
                    }
                }
                else
                {
                    self.E_Text_ExpText.text = string.Empty;
                    self.E_Text_UnionGoldText.text = string.Empty;
                }
            }
            
            using (zstring.Block())
            {
                self.E_Text_OnLineText.text = zstring.Format("在线人数 {0}", self.OnLinePlayer.Count);
                self.E_Text_PurposeText.text = self.UnionInfo.UnionPurpose;
                self.E_Text_NumberText.text = zstring.Format("{0}/{1}", self.UnionInfo.UnionPlayerList.Count, unionConfig.PeopleNum);
            }

            self.E_Text_LeaderText.text = self.UnionInfo.LeaderName;
            self.E_Text_UnionNameText.text = self.UnionInfo.UnionName;
            self.EG_LeadNodeRectTransform.gameObject.SetActive(leader || mainPlayerInfo.Position != 0);
            self.E_ButtonApplyListButton.gameObject.SetActive(leader || mainPlayerInfo.Position != 0);
            self.E_ButtonJingXuanButton.gameObject.SetActive(self.UnionInfo.JingXuanEndTime > 0);

            self.E_Button_UpgradeButton.gameObject.SetActive(leader);
            self.E_Button_UpgradeButton.transform.Find("Reddot").gameObject.SetActive(self.UnionInfo.Exp >= unionConfig.Exp && UnionConfigCategory.Instance.Contain(unionlevel + 1));
        }

        public static void UpdateMyUnion(this ES_UnionMy self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            UnionPlayerInfo mainPlayerInfo = UnionHelper.GetUnionPlayerInfo(self.UnionInfo.UnionPlayerList, userInfoComponent.UserInfo.UserId);
            
            self.UpdateUnionLevel();
            
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
                int positiona = a.Position == 0 ? 10 : a.Position;
                int positionb = b.Position == 0 ? 10 : b.Position;
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
            foreach (Scroll_Item_UnionMyItem item in self.ScrollItemUnionMyItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_UnionMyItem scrollItemUnionMyItem = self.ScrollItemUnionMyItems[index].BindTrans(transform);
            scrollItemUnionMyItem.OnUpdateUI(self.UnionInfo, self.ShowUnionPlayerInfos[index]);
        }

        public static void OnText_EnterUnionButton(this ES_UnionMy self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.Union, 2000009).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Union);
        }

        public static void OnText_LevelButton(this ES_UnionMy self)
        {
        }

        public static void OnText_ExpButton(this ES_UnionMy self)
        {
        }

        private static async ETTask RequestUnionUpgrade(this ES_UnionMy self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            U2C_UnionUpgradeResponse response =  await UnionNetHelper.UnionUpgradeRequest(self.Root(), unit.GetUnionId(), unit.Id);
            if (response != null && response.Error == ErrorCode.ERR_Success)
            {
                self.UnionInfo = response.UnionMyInfo;
                self.UpdateUnionLevel();
                FlyTipComponent.Instance.ShowFlyTip("升级成功!");
            }
        }

        public   static void OnButtonUpgrade(this ES_UnionMy self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
    
            int unionlevel = self.UnionInfo.Level;

            UnionConfig unionConfig = UnionConfigCategory.Instance.Get(unionlevel);
            if (self.UnionInfo.Exp < unionConfig.Exp)
            {
                FlyTipComponent.Instance.ShowFlyTip("经验不足！");
                return;
            }

            if (self.UnionInfo.UnionGold < unionConfig.UnionGoldCost)
            {
                FlyTipComponent.Instance.ShowFlyTip("资金不足！");
                return;
            }
                
            if ( !UnionConfigCategory.Instance.Contain(unionlevel + 1))
            {
                FlyTipComponent.Instance.ShowFlyTip("已达到最大等级！");
                return;
            }
            
            PopupTipHelp.OpenPopupTip(self.Root(), "公会升级", $"是否确认花费{unionConfig.UnionGoldCost}公会资金升级？", () => { self.RequestUnionUpgrade().Coroutine(); }, null)
                .Coroutine();
        }
    }
}
