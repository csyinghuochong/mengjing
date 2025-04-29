using System.Collections.Generic;
using UnityEngine;

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

            self.E_ButtonResetButton.AddListener(() => { self.OnButtonReset(1); });

            self.E_BtnItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_SkillLearnButton.AddListener(self.OnSkillLearn);

            self.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
            
            self.ShowGuide().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillLearn self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
            
            self.DestroyWidget();
        }

        public static async ETTask ShowGuide(this ES_SkillLearn self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitFrameAsync();
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UISkill");
        }
        
        private static void OnSkillLearn(this ES_SkillLearn self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;

            SkillConfig skillConfig_base = SkillConfigCategory.Instance.Get(self.SkillPro.SkillID);

            int playerLv = userInfo.Lv;
            if (userInfo.Sp < skillConfig_base.CostSPValue)
            {
                FlyTipComponent.Instance.ShowFlyTip("技能点不足！!");
                return;
            }

            if (playerLv < skillConfig_base.LearnRoseLv)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！!");
                return;
            }

            if (userInfo.Gold < skillConfig_base.CostGoldValue)
            {
                FlyTipComponent.Instance.ShowFlyTip("金币不足！!");
                return;
            }

            if (skillConfig_base.NextSkillID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已满级！!");
                return;
            }

            SkillNetHelper.ActiveSkillID(self.Root(), self.SkillPro.SkillID).Coroutine();
        }

        private static void OnButtonReset(this ES_SkillLearn self, int operation)
        {
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(20);
            int needGold = int.Parse(globalValueConfig.Value);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Gold < needGold)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_GoldNotEnoughError);
                return;
            }

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "技能点重置", zstring.Format("是否花费{0}金币重置技能点", needGold),
                    () => { self.RequestReset(operation).Coroutine(); }).Coroutine();
            }
        }

        private static async ETTask RequestReset(this ES_SkillLearn self, int operation)
        {
            int error = await SkillNetHelper.SkillOperation(self.Root(), operation);
            if (error != 0)
            {
                return;
            }

            if (operation == 1)
            {
                EventSystem.Instance.Publish(self.Root(), new SkillReset());
            }

            if (operation == 2)
            {
                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                userInfoComponent.UserInfo.OccTwo = 0;
                EventSystem.Instance.Publish(self.Root(), new SkillReset());
            }

            self.OnItemTypeSet(self.E_BtnItemTypeSetToggleGroup.GetCurrentIndex());
        }

        private static bool IsZhuDongSkill(this ES_SkillLearn self, int skilltype)
        {
            return skilltype == 1 || skilltype == 6;
        }

        private static void OnItemTypeSet(this ES_SkillLearn self, int page)
        {
            self.EG_SkillInfoPanelRectTransform.gameObject.SetActive(false);
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

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowLearnSkillPros.Count; i++)
            {
                if (!self.ScrollItemSkillLearnItems.ContainsKey(i))
                {
                    Scroll_Item_SkillLearnItem item = self.AddChild<Scroll_Item_SkillLearnItem>();
                    string path = "Assets/Bundles/UI/Item/Item_SkillLearnItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_SkillLearnItemsLoopVerticalScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemSkillLearnItems.Add(i, item);
                }

                Scroll_Item_SkillLearnItem scrollItemSkillLearnItem = self.ScrollItemSkillLearnItems[i];
                scrollItemSkillLearnItem.SetClickHander((SkillPro skillpro) => { self.OnSelectSkill(skillpro); });
                scrollItemSkillLearnItem.OnUpdateUI(self.ShowLearnSkillPros[i]);
            }

            if (self.ScrollItemSkillLearnItems.Count > self.ShowLearnSkillPros.Count)
            {
                for (int i = self.ShowLearnSkillPros.Count; i < self.ScrollItemSkillLearnItems.Count; i++)
                {
                    Scroll_Item_SkillLearnItem scrollItemSkillLearnItem = self.ScrollItemSkillLearnItems[i];
                    scrollItemSkillLearnItem.uiTransform.gameObject.SetActive(false);
                }
            }

            if (self.ScrollItemSkillLearnItems.Count > 0)
            {
                Scroll_Item_SkillLearnItem scrollItemSkillLearnItem = self.ScrollItemSkillLearnItems[0];
                scrollItemSkillLearnItem.OnClick();
            }
        }

        private static void OnSelectSkill(this ES_SkillLearn self, SkillPro skillPro)
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

            self.UpdateRightPanel();
            self.EG_SkillInfoPanelRectTransform.gameObject.SetActive(true);
        }

        private static void UpdateRightPanel(this ES_SkillLearn self)
        {
            if (self.SkillPro == null)
            {
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            SkillConfig skillBaseConfig = SkillConfigCategory.Instance.Get(self.SkillPro.SkillID);

            int weaponskill = SkillHelp.GetWeaponSkill(self.SkillPro.SkillID, UnitHelper.GetEquipType(self.Root()),
                self.Root().GetComponent<SkillSetComponentC>().SkillList);
            SkillConfig skillWeaponConfig = SkillConfigCategory.Instance.Get(weaponskill);
            int baseskill = SkillHelp.GetBaseSkill(weaponskill);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillWeaponConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_SkillIconImage.sprite = sp;
            using (zstring.Block())
            {
                self.E_SkillLvText.text = LanguageComponent.Instance.LoadLocalization("等级 ") + skillWeaponConfig.SkillLv;
                self.E_SkillNameText.text = skillWeaponConfig.SkillName;
                self.E_SkillTypeText.text = self.IsZhuDongSkill(skillBaseConfig.SkillType) ? "主动技能" : "被动技能";

                int itemEquipType = UnitHelper.GetEquipType(self.Root());
                SkillConfig skillConfig_base = SkillConfigCategory.Instance.Get(baseskill);

                self.E_SkillDesText.text = skillConfig_base.SkillDescribe.Replace("\\n", "\n");
                
                // string[] skillDesc = skillConfig_base.SkillDescribe.Split(new[] { "\\n\\n" }, StringSplitOptions.None);
                //
                // if (skillDesc.Length == 1)
                // {
                //     self.E_SkillDesText.text = skillDesc[0].Replace("\\n", "\n");
                // }
                // else
                // {
                //     if (itemEquipType == ItemEquipType.Sword || itemEquipType == ItemEquipType.Wand)
                //     {
                //         self.E_SkillDesText.text = skillDesc[0].Replace("\\n", "\n");
                //     }
                //     else
                //     {
                //         self.E_SkillDesText.text = skillDesc[1].Replace("\\n", "\n");
                //     }
                // }

                self.E_SkillCoinText.text = zstring.Format("需要金币：{0}", skillBaseConfig.CostGoldValue);
                self.E_SkillPointText.text = zstring.Format("技能点数：{0}/{1}", skillBaseConfig.CostSPValue, userInfo.Sp);
            }
        }

        public static void OnSkillUpgrade(this ES_SkillLearn self, string dataparams)
        {
            // 只刷新对应的技能
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
                }
            }

            self.UpdateRightPanel();
        }
    }
}