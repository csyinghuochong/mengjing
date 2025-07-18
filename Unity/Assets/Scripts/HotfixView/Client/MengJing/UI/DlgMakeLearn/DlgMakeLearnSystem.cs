using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MakeLearnItem))]
    [FriendOf(typeof(DlgMakeLearn))]
    public static class DlgMakeLearnSystem
    {
        public static void RegisterUIEvent(this DlgMakeLearn self)
        {
            self.View.EG_SelectRectTransform.gameObject.SetActive(true);
            self.View.E_Select_1Image.transform.Find("Button_Select").GetComponent<Button>().AddListener(() => { self.On_Button_Select(1); });
            self.View.E_Select_2Image.transform.Find("Button_Select").GetComponent<Button>().AddListener(() => { self.On_Button_Select(2); });
            self.View.E_Select_3Image.transform.Find("Button_Select").GetComponent<Button>().AddListener(() => { self.On_Button_Select(3); });
            self.View.E_Select_6Image.transform.Find("Button_Select").GetComponent<Button>().AddListener(() => { self.On_Button_Select(6); });
            self.InitMakeItem(self.View.E_Select_1Image.transform.Find("RewardList"), 1);
            self.InitMakeItem(self.View.E_Select_2Image.transform.Find("RewardList"), 2);
            self.InitMakeItem(self.View.E_Select_3Image.transform.Find("RewardList"), 3);
            self.InitMakeItem(self.View.E_Select_6Image.transform.Find("RewardList"), 6);

            self.View.E_ButtonLearnButton.AddListenerAsync(self.OnButtonLearnButton);
            self.View.E_MakeLearnItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMakeLearnItemsRefresh);
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            
            self.MakeId = 0;
            self.MakeType = 1;
            self.OnBtn_Plan(1);
        }

        public static void ShowWindow(this DlgMakeLearn self, Entity contextData = null)
        {
        }

        private static void InitMakeItem(this DlgMakeLearn self, Transform transform, int type)
        {
            List<RewardItem> rewardItems = new List<RewardItem>();
            
            string[] itemList = ConfigData.SkillMakeConfig[type].Split(';');
            foreach (string itemId in itemList)
            {
                RewardItem rewardItem = new RewardItem();
                rewardItem.ItemID = int.Parse(itemId);
                rewardItems.Add(rewardItem);
            }
            
            ES_RewardList rewardList = self.View.AddChild<ES_RewardList,Transform>(transform);
            rewardList.Refresh(rewardItems, showNumber: false, showName: false);
        }
        
        private static void OnMakeLearnItemsRefresh(this DlgMakeLearn self, Transform transform, int index)
        {
            // 如果有 选中高亮 等功能，则要添加此段类型代码。
            // 原因：因为滚动组件是从对象池获取gameobject，当item不显示时并不会让item.uiTransform = null，所以可能导致不同item引用同一个gameobject。
            // 这样会出现点击了，但是没有高亮效果，因为激活物体后又隐藏物体。
            foreach (Scroll_Item_MakeLearnItem item in self.ScrollItemMakeLearnItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_MakeLearnItem scrollItemMakeLearnItem = self.ScrollItemMakeLearnItems[index].BindTrans(transform);
            scrollItemMakeLearnItem.SetClickHandler((int itemid) => { self.OnSelectLearnItem(itemid); });
            scrollItemMakeLearnItem.OnUpdateUI(self.ShowMakeLearns[index], self.Plan);
        }

        public static void OnBtn_Plan(this DlgMakeLearn self, int plan)
        {
            self.Plan = plan;

            self.CheckMakeType();
            self.UpdateShuLianDu();
        }

        public static void UpdateShuLianDu(this DlgMakeLearn self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int maxValue = GlobalValueConfigCategory.Instance.MaxShuLianDu;

            int shulianduNumeric = self.Plan == 1 ? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
            int curValue = unit.GetComponent<NumericComponentC>().GetAsInt(shulianduNumeric);

            using (zstring.Block())
            {
                self.View.E_Lab_ShuLianDuText.text = zstring.Format("{0}/{1}", curValue, maxValue);
            }

            self.View.E_Img_ShuLianProImage.fillAmount = curValue * 1f / maxValue;
        }

        public static void On_Button_Select(this DlgMakeLearn self, int makeId)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int makeType = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_1);
            if (makeType != 0)
            {
                int cost = GlobalValueConfigCategory.Instance.MakeResetCost;
                PopupTipHelp.OpenPopupTip(self.Root(), "技能重置",
                    "重置后自身学习的生活技能将全部遗忘，请谨慎选择!", () => { self.RequestMakeSelect(makeId).Coroutine(); }, null).Coroutine();
                return;
            }

            self.RequestMakeSelect(makeId).Coroutine();
        }

        public static async ETTask RequestMakeSelect(this DlgMakeLearn self, int makeId)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int makeType_1 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_1);
            int makeType_2 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_2);
            if (makeType_1 == makeId || makeType_2 == makeId)
            {
                FlyTipComponent.Instance.ShowFlyTip("该生活技能已学习！");
                return;
            }

            await SkillNetHelper.MakeSelect(self.Root(), makeId, self.Plan == -1 ? 1 : self.Plan);
            self.CheckMakeType();
        }

        //0:图纸制造（需要消耗图纸）
        //1.锻造类型
        //2.裁缝类型
        //3.炼金类型
        //4.宝石类型
        //5.神器类型
        //6.附魔类型
        //8.家园类型
        //9.宠物装备
        public static void CheckMakeType(this DlgMakeLearn self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int makeType_1 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_1);
            int makeType_2 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_2);

            int showValue = NpcConfigCategory.Instance.Get(self.Root().GetComponent<UIComponent>().CurrentNpcId).ShopValue;
            self.MakeType = showValue;
            self.Plan = -1;
            if (makeType_1 == showValue)
            {
                self.Plan = 1;
            }

            if (makeType_2 == showValue)
            {
                self.Plan = 2;
            }

            self.View.EG_RightRectTransform.gameObject.SetActive(self.Plan != -1);
            self.View.EG_LeftRectTransform.gameObject.SetActive(self.Plan != -1);
            self.View.EG_SelectRectTransform.gameObject.SetActive(self.Plan == -1);
            self.View.E_Select_1Image.gameObject.SetActive(showValue == 1);
            self.View.E_Select_2Image.gameObject.SetActive(showValue == 2);
            self.View.E_Select_3Image.gameObject.SetActive(showValue == 3);
            self.View.E_Select_6Image.gameObject.SetActive(showValue == 6);

            self.InitData(self.MakeType);
        }

        public static void InitData(this DlgMakeLearn self, int makeType)
        {
            if (self.MakeType != makeType)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int playeLv = userInfoComponent.UserInfo.Lv;
            Dictionary<int, EquipMakeConfig> keyValuePairs = EquipMakeConfigCategory.Instance.GetAll();
            string initMakeList = GlobalValueConfigCategory.Instance.Get(43).Value;
            self.ShowMakeLearns.Clear();
            foreach (var item in keyValuePairs)
            {
                if (userInfoComponent.UserInfo.MakeList.Contains(item.Key))
                {
                    continue;
                }

                if (initMakeList.Contains(item.Key.ToString()))
                {
                    continue;
                }

                if (playeLv < item.Value.LearnLv || item.Value.LearnType != 0)
                {
                    continue;
                }

                if (item.Value.ProficiencyType != self.MakeType)
                {
                    continue;
                }

                self.ShowMakeLearns.Add(item.Key);
            }

            self.AddUIScrollItems(ref self.ScrollItemMakeLearnItems, self.ShowMakeLearns.Count);
            self.View.E_MakeLearnItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMakeLearns.Count);

            if (self.ShowMakeLearns.Count > 0)
            {
                Scroll_Item_MakeLearnItem scrollItemMakeLearnItem = self.ScrollItemMakeLearnItems[0];
                if (self.ScrollItemMakeLearnItems != null && self.ScrollItemMakeLearnItems.Count > 0 && scrollItemMakeLearnItem.uiTransform != null)
                {
                    scrollItemMakeLearnItem.OnImageButton();
                }
            }

            if (self.MakeId != 0)
            {
                self.OnSelectLearnItem(self.MakeId);
            }
        }

        public static void OnSelectLearnItem(this DlgMakeLearn self, int makeid)
        {
            self.MakeId = makeid;
            if (self.ScrollItemMakeLearnItems != null)
            {
                foreach (Scroll_Item_MakeLearnItem item in self.ScrollItemMakeLearnItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(makeid);
                }
            }

            self.OnUpdateLearn(makeid);
        }

        public static void OnUpdateLearn(this DlgMakeLearn self, int makeid)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeid);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID);

            self.View.E_Lab_LearnItemCostText.text = equipMakeConfig.LearnGoldValue.ToString();

            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemID = itemConfig.Id;
            bagInfo.ItemNum = 1;
            self.View.ES_CommonItem.UseTextColor = true;
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.View.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.View.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);

            //显示需要熟练度
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int shulianduNumeric = self.Plan == 1 ? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
            int nowShuLianDu = unit.GetComponent<NumericComponentC>().GetAsInt(shulianduNumeric);
            using (zstring.Block())
            {
                if (unit.GetComponent<NumericComponentC>().GetAsInt(shulianduNumeric) < equipMakeConfig.NeedProficiencyValue)
                {
                    //不满足显示红色,满足显示绿色
                    self.View.E_LabNeedShuLianText.text = zstring.Format("{0}/{1}(技巧值不足)", nowShuLianDu, equipMakeConfig.NeedProficiencyValue);
                    self.View.E_LabNeedShuLianText.color = new Color(236f / 255f, 101f / 255f, 110f / 255f);
                }
                else
                {
                    //满足显示绿色,满足显示绿色
                    self.View.E_LabNeedShuLianText.text = zstring.Format("{0}/{1}(可学习)", nowShuLianDu, equipMakeConfig.NeedProficiencyValue);
                    self.View.E_LabNeedShuLianText.color = new Color(217f / 255f, 255f / 255f, 134f / 255f);
                }
            }

            self.View.ES_RewardList.Refresh(equipMakeConfig.NeedItems);
        }

        public static async ETTask OnButtonLearnButton(this DlgMakeLearn self)
        {
            if (self.MakeId == 0)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.MakeList.Contains(self.MakeId))
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("已经学习过该道具!"));
                return;
            }

            M2C_MakeLearnResponse response = await SkillNetHelper.MakeLearn(self.Root(), self.MakeId, self.Plan);
            if (response.Error == 0)
            {
                self.InitData(self.MakeType);
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("学习配方成功!"));
            }
        }
        public static void OnImageButtonButton(this DlgMakeLearn self)
        {
        }
    }
}
