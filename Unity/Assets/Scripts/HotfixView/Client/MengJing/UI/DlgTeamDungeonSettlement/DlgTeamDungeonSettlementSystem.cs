using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TeamDungeonSettlementPlayer))]
    [FriendOf(typeof(Scroll_Item_SettlementRwardItem))]
    [FriendOf(typeof(DlgTeamDungeonSettlementViewComponent))]
    [FriendOf(typeof(DlgTeamDungeonSettlement))]
    public static class DlgTeamDungeonSettlementSystem
    {
        public static void RegisterUIEvent(this DlgTeamDungeonSettlement self)
        {
            ReferenceCollector rc = self.View.uiTransform.GetComponent<ReferenceCollector>();

            self.View.EG_SelectEffectSetRectTransform.gameObject.SetActive(false);

            self.SettlementRward1 = rc.Get<GameObject>("SettlementRward1");
            self.SettlementRward1.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                GameObject cellitem = UnityEngine.Object.Instantiate(self.SettlementRward1);
                cellitem.SetActive(true);
                CommonViewHelper.SetParent(cellitem, self.SettlementRward1.transform.parent.gameObject);

                Scroll_Item_SettlementRwardItem uISettlementRewardComponent = self.AddChild<Scroll_Item_SettlementRwardItem>();
                uISettlementRewardComponent.uiTransform = cellitem.transform;
                uISettlementRewardComponent.SetClickHandler((int index) => { self.OnClickRewardItem(index).Coroutine(); }, i);
                self.RewardUIList.Add(uISettlementRewardComponent);
            }

            self.SettlementRward2 = rc.Get<GameObject>("SettlementRward2");
            self.SettlementRward2.SetActive(false);
            for (int i = 3; i < 6; i++)
            {
                GameObject cellitem = UnityEngine.Object.Instantiate(self.SettlementRward2);
                cellitem.SetActive(true);
                CommonViewHelper.SetParent(cellitem, self.SettlementRward2.transform.parent.gameObject);

                Scroll_Item_SettlementRwardItem uISettlementRewardComponent = self.AddChild<Scroll_Item_SettlementRwardItem>();
                uISettlementRewardComponent.uiTransform = cellitem.transform;
                uISettlementRewardComponent.SetClickHandler((int index) => { self.OnClickRewardItem(index).Coroutine(); }, i);
                self.RewardUIList.Add(uISettlementRewardComponent);
            }

            self.SettlementItem = rc.Get<GameObject>("SettlementItem");
            self.SettlementItem.gameObject.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                GameObject cellitem = UnityEngine.Object.Instantiate(self.SettlementItem);
                cellitem.SetActive(true);
                CommonViewHelper.SetParent(cellitem, self.SettlementItem.transform.parent.gameObject);
                Scroll_Item_TeamDungeonSettlementPlayer uISettlementRewardComponent = self.AddChild<Scroll_Item_TeamDungeonSettlementPlayer>();
                uISettlementRewardComponent.uiTransform = cellitem.transform;
                self.PlayerUIList.Add(uISettlementRewardComponent);
            }

            self.View.E_Button_exitButton.AddListener(self.OnButton_exit);
            self.View.E_Img_back2Button.AddListener(self.OnButton_exit);

            self.IfLingQuStatus = false;
            self.BeingTimer().Coroutine();
        }

        public static void ShowWindow(this DlgTeamDungeonSettlement self, Entity contextData = null)
        {
        }

        public static async ETTask BeingTimer(this DlgTeamDungeonSettlement self)
        {
            long instanceIds = self.InstanceId;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            for (int i = 10; i >= 0; i--)
            {
                self.OnUpdate(i);
                await timerComponent.WaitAsync(1000);
                if (instanceIds != self.InstanceId)
                {
                    break;
                }
            }
        }

        public static void OnUpdate(this DlgTeamDungeonSettlement self, int leftTime)
        {
            self.LeftTime = leftTime;
            if (leftTime <= 0)
            {
                self.CheckSelfSelected();
                self.View.E_Text_LeftTimeText.gameObject.SetActive(false);
                return;
            }

            using (zstring.Block())
            {
                self.View.E_Text_LeftTimeText.text = zstring.Format("选择剩余时间:{0}秒", leftTime);
            }
        }

        public static void CheckSelfSelected(this DlgTeamDungeonSettlement self)
        {
            if (self.IfLingQuStatus)
            {
                return;
            }

            int index = -1;
            for (int i = 0; i < 3; i++)
            {
                if (self.RewardUIList[i].IsCanClicked())
                {
                    index = i;
                    break;
                }
            }

            self.IfLingQuStatus = true;
            if (index == -1)
            {
                return;
            }

            self.OnClickRewardItem(index).Coroutine();
        }

        public static void OnTeamDungeonBoxReward(this DlgTeamDungeonSettlement self, M2C_TeamDungeonBoxRewardResult message)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.TeamDungeon)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeonSettlement);
                return;
            }

            if (message.BoxIndex < 0 || message.BoxIndex >= self.RewardUIList.Count)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("message.BoxIndex : {0}", message.BoxIndex));
                }

                return;
            }

            self.RewardUIList[message.BoxIndex].ShowRewardItem(message.PlayerName);
            long userId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            if (userId == message.UserId)
            {
                if (message.BoxIndex <= 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        self.RewardUIList[i].DisableClick();
                    }

                    self.IfLingQuStatus = true;
                    self.View.E_Text_LeftTimeText.gameObject.SetActive(false);
                }
                else
                {
                    for (int i = 3; i < 6; i++)
                    {
                        self.RewardUIList[i].DisableClick();
                    }
                }
            }
        }

        public static async ETTask OnClickRewardItem(this DlgTeamDungeonSettlement self, int index)
        {
            if (TimeHelper.ServerNow() - self.SendGetTime < 1000)
            {
                return;
            }

            self.SendGetTime = TimeHelper.ServerNow();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (index >= 3 && !unit.IsYueKaStates())
            {
                FlyTipComponent.Instance.ShowFlyTip("周卡用户才能开启喔！");
                return;
            }

            Scroll_Item_SettlementRwardItem select = self.RewardUIList[index];
            self.View.EG_SelectEffectSetRectTransform.gameObject.SetActive(true);
            CommonViewHelper.SetParent(self.View.EG_SelectEffectSetRectTransform.gameObject, select.uiTransform.gameObject);
            RewardItem rewardItem = select.RewardItem;

            M2C_TeamDungeonBoxRewardResponse response = await TeamNetHelper.TeamDungeonBoxRewardRequest(self.Root(), index, rewardItem);

            if (self.InstanceId == 0)
            {
                return;
            }

            if (response.Mail == 1)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "副本奖励", "由于您背包已满通关宝箱的奖励已经自动发放进您的邮箱中，请注意查收。", null, null).Coroutine();
            }
        }

        public static void OnUpdateUI(this DlgTeamDungeonSettlement self, M2C_TeamDungeonSettlement m2C_FubenSettlement)
        {
            // 奖励列表
            for (int i = 0; i < m2C_FubenSettlement.RewardList.Count; i++)
            {
                self.RewardUIList[i].OnUpdateData(m2C_FubenSettlement.RewardList[i]);
            }

            for (int i = 0; i < m2C_FubenSettlement.RewardListExcess.Count; i++)
            {
                self.RewardUIList[i + 3].OnUpdateData(m2C_FubenSettlement.RewardListExcess[i]);
            }

            long idExtra = 0;
            int damageMax = 0;
            for (int i = 0; i < m2C_FubenSettlement.PlayerList.Count; i++)
            {
                if (m2C_FubenSettlement.PlayerList[i].Damage >= damageMax)
                {
                    damageMax = m2C_FubenSettlement.PlayerList[i].Damage;
                    idExtra = m2C_FubenSettlement.PlayerList[i].UserID;
                }
            }

            // 伤害数据
            for (int i = 0; i < self.PlayerUIList.Count; i++)
            {
                if (i >= m2C_FubenSettlement.PlayerList.Count)
                {
                    self.PlayerUIList[i].uiTransform.gameObject.SetActive(false);
                    continue;
                }

                TeamPlayerInfo teamPlayerInfo = m2C_FubenSettlement.PlayerList[i];
                self.PlayerUIList[i].OnUpdateUI(teamPlayerInfo, idExtra == teamPlayerInfo.UserID ? m2C_FubenSettlement.RewardExtraItem : null);
            }
        }

        public static void OnButton_exit(this DlgTeamDungeonSettlement self)
        {
            if (self.LeftTime > 5)
            {
                return;
            }

            // 判断宝箱自己是否领取
            if (self.IfLingQuStatus == false)
            {
                FlyTipComponent.Instance.ShowFlyTip("请在右侧领取自己的战利品哦!");
                return;
            }

            // 离开副本
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeonSettlement);
        }
    }
}
