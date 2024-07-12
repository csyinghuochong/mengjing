using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SkillLearnItem))]
    [FriendOf(typeof(Scroll_Item_SkillLearnSkillItem))]
    [EntitySystemOf(typeof(ES_SkillLearn))]
    [FriendOfAttribute(typeof(ES_SkillLearn))]
    public static partial class ES_SkillLearnSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillLearn self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SkillInfoLearnBtnButton.AddListener(self.OnSkillInfoLearnBtn);
            self.E_ButtonResetButton.AddListener(() => { self.OnButtonReset(1); });

            self.E_BtnItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_SkillLearnItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSkillLearnItemsRefresh);
            self.E_SkillLearnSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSkillLearnSkillItemsRefresh);

            self.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillLearn self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_SkillLearn self, int index)
        {
            self.CurrentItemType = index;

            self.OnClickPageButton(index);
        }

        public static void OnClickPageButton(this ES_SkillLearn self, int page)
        {
            self.InitSkillList(page).Coroutine();
        }

        public static void OnButtonReset(this ES_SkillLearn self, int operation)
        {
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(20);
            int needGold = int.Parse(globalValueConfig.Value);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Gold < needGold)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_GoldNotEnoughError);
                return;
            }

            PopupTipHelp.OpenPopupTip(self.Root(), "技能点重置",
                $"是否花费{needGold}金币重置技能点",
                () => { self.RequestReset(operation).Coroutine(); }).Coroutine();
        }

        public static async ETTask RequestReset(this ES_SkillLearn self, int operation)
        {
            int error = await SkillNetHelper.SkillOperation(self.Root(), operation);
            if (error != 0)
            {
                return;
            }

            if (operation == 1)
            {
                EventSystem.Instance.Publish(self.Root(), new DataUpdate_SkillReset());
            }

            if (operation == 2)
            {
                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                userInfoComponent.UserInfo.OccTwo = 0;
                EventSystem.Instance.Publish(self.Root(), new DataUpdate_SkillReset());
            }

            self.InitSkillList(self.CurrentItemType).Coroutine();
        }

        public static void OnUpdateUI(this ES_SkillLearn self)
        {
            self.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
            self.UpdateLeftSp();
        }

        public static bool IsZhuDongSkill(this ES_SkillLearn self, int skilltype)
        {
            return skilltype == 1 || skilltype == 6;
        }

        private static void OnSkillLearnItemsRefresh(this ES_SkillLearn self, Transform transform, int index)
        {
            Scroll_Item_SkillLearnItem scrollItemSkillLearnItem = self.ScrollItemSkillLearnItems[index].BindTrans(transform);
            scrollItemSkillLearnItem.SetClickHander((SkillPro skillpro) => { self.OnSelectSkill(skillpro); });
            scrollItemSkillLearnItem.OnUpdateUI(self.ShowLearnSkillPros[index]);
        }

        private static void OnSkillLearnSkillItemsRefresh(this ES_SkillLearn self, Transform transform, int index)
        {
            Scroll_Item_SkillLearnSkillItem scrollItemSkillLearnSkillItem = self.ScrollItemSkillLearnSkillItems[index].BindTrans(transform);
            scrollItemSkillLearnSkillItem.SetClickHander((skillpro) => { self.OnUpdateSkillInfoPanel(skillpro); });
            scrollItemSkillLearnSkillItem.OnUpdateUI(self.ShowLearnSkillSkillPros[index]);
        }

        public static async ETTask InitSkillList(this ES_SkillLearn self, int page)
        {
            if (page <= 1) // 主动、被动
            {
                self.EG_SkillInfoPanelRectTransform.gameObject.SetActive(false);
                self.E_SkillLearnSkillItemsLoopVerticalScrollRect.gameObject.SetActive(false);
                self.E_SkillLearnItemsLoopVerticalScrollRect.gameObject.SetActive(true);

                List<SkillPro> skillPros = self.Root().GetComponent<SkillSetComponentC>().SkillList;
                List<SkillPro> showSkillPros = new List<SkillPro>();
                showSkillPros.AddRange(skillPros);

                // 临时增加显示
                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                int occ = userInfoComponent.UserInfo.Occ;
                int occTwo = userInfoComponent.UserInfo.OccTwo;
                if (occTwo != 0 && self.LinShiSkillStatus == false)
                {
                    OccupationTwoConfig occTwoCof = OccupationTwoConfigCategory.Instance.Get(occTwo);
                    for (int i = 0; i < occTwoCof.ShowPassiveSkill.Length; i++)
                    {
                        SkillPro pro = SkillPro.Create();
                        pro.SkillID = occTwoCof.ShowPassiveSkill[i];
                        showSkillPros.Add(pro);
                    }

                    self.LinShiSkillStatus = true;
                }

                self.ShowLearnSkillPros.Clear();

                for (int i = 0; i < showSkillPros.Count; i++)
                {
                    SkillPro skillPro = showSkillPros[i];
                    if (skillPro.SkillSetType == (int)SkillSetEnum.Item)
                    {
                        continue;
                    }

                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);
                    if (skillConfig.IsShow == 1)
                    {
                        continue;
                    }

                    // page ==0 主动 1被动
                    if (page == 0 && !self.IsZhuDongSkill(skillConfig.SkillType))
                    {
                        continue;
                    }

                    if (page == 1 && self.IsZhuDongSkill(skillConfig.SkillType))
                    {
                        continue;
                    }

                    // 屏蔽强化技能
                    if (SkillHelp.IsQiangHuaSkill(occ, skillPro.SkillID))
                    {
                        continue;
                    }

                    self.ShowLearnSkillPros.Add(skillPro);
                }

                self.AddUIScrollItems(ref self.ScrollItemSkillLearnItems, self.ShowLearnSkillPros.Count);
                self.E_SkillLearnItemsLoopVerticalScrollRect.SetVisible(true, self.ShowLearnSkillPros.Count);

                if (self.ScrollItemSkillLearnItems.Count > 0)
                {
                    Scroll_Item_SkillLearnItem scrollItemSkillLearnItem = self.ScrollItemSkillLearnItems[0];
                    scrollItemSkillLearnItem.OnImg_Button();
                }
            }
            else if (page == 2) // 强化
            {
                self.EG_SkillInfoPanelRectTransform.gameObject.SetActive(true);
                self.E_SkillLearnSkillItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                self.E_SkillLearnItemsLoopVerticalScrollRect.gameObject.SetActive(false);

                List<SkillPro> skillPros = self.Root().GetComponent<SkillSetComponentC>().SkillList;
                List<SkillPro> showSkillPros = new List<SkillPro>();
                showSkillPros.AddRange(skillPros);

                //临时增加显示
                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                int occ = userInfoComponent.UserInfo.Occ;
                int occTwo = userInfoComponent.UserInfo.OccTwo;
                if (occTwo != 0 && self.LinShiSkillStatus == false)
                {
                    OccupationTwoConfig occTwoCof = OccupationTwoConfigCategory.Instance.Get(occTwo);
                    for (int i = 0; i < occTwoCof.ShowPassiveSkill.Length; i++)
                    {
                        SkillPro pro = SkillPro.Create();
                        pro.SkillID = occTwoCof.ShowPassiveSkill[i];
                        showSkillPros.Add(pro);
                    }

                    self.LinShiSkillStatus = true;
                }

                self.ShowLearnSkillSkillPros.Clear();

                for (int i = 0; i < showSkillPros.Count; i++)
                {
                    SkillPro skillPro = showSkillPros[i];
                    if (skillPro.SkillSetType == (int)SkillSetEnum.Item)
                    {
                        continue;
                    }

                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);
                    // if (skillConfig.IsShow == 1)
                    // {
                    //     continue;
                    // }

                    //page ==0 主动 1被动
                    if (page == 0 && !self.IsZhuDongSkill(skillConfig.SkillType))
                    {
                        continue;
                    }

                    if (page == 1 && self.IsZhuDongSkill(skillConfig.SkillType))
                    {
                        continue;
                    }

                    //强化技能
                    if (page == 2 && !SkillHelp.IsQiangHuaSkill(occ, skillPro.SkillID))
                    {
                        continue;
                    }

                    self.ShowLearnSkillSkillPros.Add(skillPro);
                }

                self.AddUIScrollItems(ref self.ScrollItemSkillLearnSkillItems, self.ShowLearnSkillSkillPros.Count);
                self.E_SkillLearnSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowLearnSkillSkillPros.Count);

                if (self.ScrollItemSkillLearnSkillItems.Count > 0)
                {
                    Scroll_Item_SkillLearnSkillItem scrollItemSkillLearnSkillItem = self.ScrollItemSkillLearnSkillItems[0];
                    scrollItemSkillLearnSkillItem.OnImg_Button();
                }
            }

            await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
            // self.ZoneScene().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, UIType.UISkill);
        }

        /// <summary>
        /// 更新技能面板信息
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillPro"></param>
        public static void OnUpdateSkillInfoPanel(this ES_SkillLearn self, SkillPro skillPro)
        {
            for (int i = 0; i < self.ScrollItemSkillLearnSkillItems.Count; i++)
            {
                Scroll_Item_SkillLearnSkillItem scrollItemSkillLearnSkillItem = self.ScrollItemSkillLearnSkillItems[i];
                if (scrollItemSkillLearnSkillItem.uiTransform != null)
                {
                    if (scrollItemSkillLearnSkillItem.SkillPro == skillPro)
                    {
                        scrollItemSkillLearnSkillItem.E_BorderImgImage.gameObject.SetActive(true);
                    }
                    else
                    {
                        scrollItemSkillLearnSkillItem.E_BorderImgImage.gameObject.SetActive(false);
                    }
                }
            }

            self.SkillPro = skillPro;
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_SkillInfoNameTextText.text = skillConfig.SkillName;
            self.E_SkillInfoconImgImage.sprite = sp;

            self.E_NowTextText.text = skillConfig.SkillDescribe;
            if (skillConfig.NextSkillID != 0)
            {
                SkillConfig skillNextConfig = SkillConfigCategory.Instance.Get(skillConfig.NextSkillID);
                self.E_NextTextText.text = skillNextConfig.SkillDescribe;
                self.E_ConsumeTextText.text = $"消耗技能点:{skillConfig.CostSPValue}";
            }
            else
            {
                self.E_NextTextText.text = "";
                self.E_ConsumeTextText.text = $"达到最大级";
            }
        }

        /// <summary>
        /// 升级强化技能
        /// </summary>
        /// <param name="self"></param>
        public static void OnSkillInfoLearnBtn(this ES_SkillLearn self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.SkillPro.SkillID);

            int playerLv = userInfo.Lv;
            if (userInfo.Sp < skillConfig.CostSPValue)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("技能点不足！!");
                return;
            }

            if (playerLv < skillConfig.LearnRoseLv)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("等级不足！!");
                return;
            }

            if (skillConfig.NextSkillID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("已满级！!");
                return;
            }

            SkillNetHelper.ActiveSkillID(self.Root(), self.SkillPro.SkillID).Coroutine();
        }

        public static void OnSelectSkill(this ES_SkillLearn self, SkillPro skillPro)
        {
            self.SkillPro = skillPro;

            for (int i = 0; i < self.ScrollItemSkillLearnItems.Count; i++)
            {
                Scroll_Item_SkillLearnItem scrollItemSkillLearnItem = self.ScrollItemSkillLearnItems[i];
                if (scrollItemSkillLearnItem.uiTransform != null)
                {
                    scrollItemSkillLearnItem.OnSetSelected(skillPro.SkillID);
                }
            }
        }

        public static void UpdateLeftSp(this ES_SkillLearn self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.E_Text_LeftSpText.text = $"剩余技能点: {userInfo.Sp}";
        }

        public static void OnSkillUpgrade(this ES_SkillLearn self, string dataparams)
        {
            ////只刷新对应的技能
            string[] sArray = dataparams.Split('_');
            int newSkill = int.Parse(sArray[1]);

            if (self.ScrollItemSkillLearnItems != null)
            {
                for (int i = 0; i < self.ScrollItemSkillLearnItems.Count; i++)
                {
                    Scroll_Item_SkillLearnItem uISkillSetItemComponent = self.ScrollItemSkillLearnItems[i];

                    if (uISkillSetItemComponent.uiTransform == null)
                    {
                        continue;
                    }

                    SkillPro sp = uISkillSetItemComponent.SkillPro;
                    if (sp.SkillID == newSkill)
                    {
                        uISkillSetItemComponent.OnUpdateUI(sp);
                    }

                    uISkillSetItemComponent.ShowReddot();
                }
            }

            if (self.ScrollItemSkillLearnSkillItems != null)
            {
                for (int i = 0; i < self.ScrollItemSkillLearnSkillItems.Count; i++)
                {
                    Scroll_Item_SkillLearnSkillItem uiSkillLearnSkillItemComponent = self.ScrollItemSkillLearnSkillItems[i];

                    if (uiSkillLearnSkillItemComponent.uiTransform == null)
                    {
                        continue;
                    }

                    SkillPro sp = uiSkillLearnSkillItemComponent.SkillPro;
                    if (sp.SkillID == newSkill)
                    {
                        uiSkillLearnSkillItemComponent.OnUpdateUI(sp);
                        uiSkillLearnSkillItemComponent.OnImg_Button();
                    }
                }
            }

            self.UpdateLeftSp();
        }
    }
}