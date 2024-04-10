using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_SkillMake))]
    [FriendOfAttribute(typeof (ES_SkillMake))]
    public static partial class ES_SkillMakeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillMake self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_TianFu_1Button.AddListener(() => { self.OnBtn_Plan(1); });
            self.E_Btn_TianFu_1Button.AddListener(() => { self.OnBtn_Plan(2); });
            self.E_Btn_MakeButton.AddListener(() => { self.OnBtn_Make().Coroutine(); });
            self.E_Btn_MeltButton.AddListener(self.OnBtn_Melt);
            self.E_Button_Select_1Button.AddListener(() => { self.RequestMakeSelect(1).Coroutine(); });
            self.E_Button_Select_2Button.AddListener(() => { self.RequestMakeSelect(3).Coroutine(); });
            self.E_Button_Select_3Button.AddListener(() => { self.RequestMakeSelect(3).Coroutine(); });
            self.E_Button_Select_4Button.AddListener(() => { self.RequestMakeSelect(6).Coroutine(); });
            self.E_Btn_ResetButton.AddListener(self.OnBtn_Reset);
            self.E_Btn_LearnButton.AddListener(self.OnBtn_Learn);

            self.OnInitUI();
            self.OnBtn_Plan(1);
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillMake self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.DestroyWidget();
        }

        public static void OnBtn_Reset(this ES_SkillMake self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "遗忘技能", "遗忘后将可以重新学习其他的生活技能，之前学习的所有技能将重置,请谨慎选择", () =>
            {
                self.EG_RightRectTransform.gameObject.SetActive(false);
                self.EG_LeftRectTransform.gameObject.SetActive(false);
                self.E_selecSelect.SetActive(true);
                self.Melt.SetActive(false);
            }, null).Coroutine();
        }

        public static void OnBtn_Learn(this ES_SkillMake self)
        {
            PopupTipHelp.OpenPopupTip(self.ZoneScene(), "学习技能", "可以在主城对应的各职业学习大师处学习当前等级最新的生活技能喔!", () =>
            {
                Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
                int makeTypenumreic = self.Plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2;
                int makeId = unit.GetComponent<NumericComponent>().GetAsInt(makeTypenumreic);
                int npcId = 0;
                switch (makeId)
                {
                    case 1: //锻造
                        npcId = 20000013;
                        break;
                    case 2: //裁缝
                        npcId = 20000012;
                        break;
                    case 3: //炼金
                        npcId = 20000014;
                        break;
                    case 6: //附魔
                        npcId = 20000026;
                        break;
                    default:
                        npcId = 0;
                        break;
                }

                if (npcId == 0)
                {
                    return;
                }

                self.ZoneScene().CurrentScene().GetComponent<OperaComponent>().OnClickNpc(npcId).Coroutine();
                UIHelper.Remove(self.ZoneScene(), UIType.UISkill);
            }, null).Coroutine();
        }

        public static async ETTask RequestMakeSelect(this ES_SkillMake self, int makeId)
        {
            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            int makeType_1 = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.MakeType_1);
            int makeType_2 = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.MakeType_2);
            if (makeType_1 == makeId || makeType_2 == makeId)
            {
                FloatTipManager.Instance.ShowFloatTip("该生活技能已学习！");
                return;
            }

            C2M_MakeSelectRequest request = new C2M_MakeSelectRequest() { MakeType = makeId, Plan = self.Plan == -1? 1 : self.Plan };
            M2C_MakeSelectResponse response = (M2C_MakeSelectResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(request);
            self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.MakeList.Clear();
            self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.MakeList = response.MakeList;
            self.OnUpdateMakeType();
            self.UpdateShuLianDu();
        }

        public static void OnInitUI(this ES_SkillMake self)
        {
            var path = ABPathHelper.GetUGUIPath("Main/Common/UICommonItem");
            var bundleGameObject = ResourcesComponent.Instance.LoadAsset<GameObject>(path);
            GameObject bagSpace = GameObject.Instantiate(bundleGameObject);
            UICommonHelper.SetParent(bagSpace, self.UIItemMake);
            UIItemComponent uIItemComponent = self.AddChild<UIItemComponent, GameObject>(bagSpace);
            uIItemComponent.Label_ItemNum.SetActive(false);
            uIItemComponent.Label_ItemName.SetActive(false);
            self.MakeItemUI = uIItemComponent;
        }

        public static void OnUpdateMakeType(this ES_SkillMake self)
        {
            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            int makeTypeNumeric = self.Plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2;
            int makeType = unit.GetComponent<NumericComponent>().GetAsInt(makeTypeNumeric);
            self.Right.SetActive(makeType != 0);
            self.Left.SetActive(makeType != 0);
            self.Select.SetActive(makeType == 0);
            self.Melt.SetActive(false);
            self.UpdateMakeList(makeType).Coroutine();
        }

        public static void OnBtn_Melt(this ES_SkillMake self)
        {
            self.Right.SetActive(false);
            self.Select.SetActive(false);
            self.Melt.SetActive(true);
            self.MeltingComponent.OnUpdateUI();
        }

        public static void OnBtn_Plan(this ES_SkillMake self, int plan)
        {
            if (self.Plan == plan)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            int rechargeNumber = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.RechargeNumber);
            int needRecharge = GlobalValueConfigCategory.Instance.Get(113).Value2;
            int skillmakePlan_2 = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.SkillMakePlan2);
            string tip = string.Empty;
            if (plan == 2 && skillmakePlan_2 == 0)
            {
                if (rechargeNumber < needRecharge)
                {
                    tip = $"当前充值金额累计达到{needRecharge}元，将自动开启第二个生活技能栏位，当前充值金额{rechargeNumber}元";
                }
                else
                {
                    tip = $"当前充值金额累计达到{needRecharge}元，将自动开启第二个生活技能栏位，您目前已经满足条件，请点击开启";
                }

                PopupTipHelp.OpenPopupTipWithButtonText(self.ZoneScene(), "开启栏位", tip, () =>
                {
                    if (rechargeNumber < needRecharge)
                    {
                        FloatTipManager.Instance.ShowFloatTip("充值额度不足！");
                    }
                    else
                    {
                        self.OnUpdate_Plan(plan);
                        self.UpdateSkillMakePlan2().Coroutine();
                    }
                }, () => { UIHelper.Create(self.ZoneScene(), UIType.UIRecharge).Coroutine(); }, "开启", "前往充值").Coroutine();
                return;
            }

            self.OnUpdate_Plan(plan);
        }

        public static async ETTask UpdateSkillMakePlan2(this ES_SkillMake self)
        {
            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.SkillMakePlan2) == 1)
            {
                return;
            }

            C2M_SkillOperation c2M_SkillOperation = new C2M_SkillOperation() { OperationType = 3 };
            M2C_SkillOperation m2C_SkillOperation =
                    (M2C_SkillOperation)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(c2M_SkillOperation);
        }

        public static void OnUpdate_Plan(this ES_SkillMake self, int plan)
        {
            self.Plan = plan;
            self.MakeId = 0;
            self.Btn_TianFu_1.transform.Find("Image").gameObject.SetActive(plan == 1);
            self.Btn_TianFu_2.transform.Find("Image").gameObject.SetActive(plan == 2);
            self.MeltingComponent.SetPlan(plan);

            self.OnUpdateMakeType();
            self.UpdateShuLianDu();
        }

        public static async ETTask OnBtn_Make(this ES_SkillMake self)
        {
            if (self.MakeId == 0)
            {
                return;
            }

            UserInfoComponent userInfoComponent = self.ZoneScene().GetComponent<UserInfoComponent>();
            long cdEndTime = userInfoComponent.GetMakeTime(self.MakeId);
            if (cdEndTime > TimeHelper.ServerNow())
            {
                FloatTipManager.Instance.ShowFloatTip(ErrorHelp.Instance.ErrorHintList[ErrorCode.ERR_InMakeCD]);
                return;
            }

            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);
            List<RewardItem> costItems = new List<RewardItem>();
            string neadItems = equipMakeConfig.NeedItems;
            string[] needList = neadItems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                if (ComHelp.IfNull(needList[i]))
                {
                    continue;
                }

                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            if (self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Vitality < equipMakeConfig.CostVitality)
            {
                FloatTipManager.Instance.ShowFloatTip("活力不足！");
                return;
            }

            bool success = self.ZoneScene().GetComponent<BagComponent>().CheckNeedItem(costItems);
            if (!success)
            {
                FloatTipManager.Instance.ShowFloatTip("材料不足！");
                return;
            }

            await NetHelper.RequestEquipMake(self.ZoneScene(), 0, self.MakeId, self.Plan);

            self.OnUpdateMakeType();
            self.UpdateShuLianDu();
            self.OnBagItemUpdate().Coroutine();
        }

        public static void UpdateShuLianDu(this ES_SkillMake self)
        {
            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            int maxValue = ComHelp.MaxShuLianDu();
            int shulianduNumeric = self.Plan == 1? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
            int curValue = unit.GetComponent<NumericComponent>().GetAsInt(shulianduNumeric);

            self.Lab_ShuLianDu.GetComponent<Text>().text = $"{curValue}/{maxValue}";
            self.Img_ShuLianPro.GetComponent<Image>().fillAmount = curValue * 1f / maxValue;
        }

        public static async ETTask OnBagItemUpdate(this ES_SkillMake self)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);

            if (self.MakeItemUI != null)
            {
                self.MakeItemUI.UpdateItem(new BagInfo() { ItemID = equipMakeConfig.MakeItemID }, ItemOperateEnum.MakeItem);
                self.MakeItemUI.Label_ItemNum.SetActive(false);
            }

            long instanceid = self.InstanceId;
            var path = ABPathHelper.GetUGUIPath("Main/Make/UIMakeNeed");
            var bundleGameObject = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            string needItems = equipMakeConfig.NeedItems;
            string[] itemsList = needItems.Split('@');

            //显示名称
            self.Lab_MakeName.GetComponent<Text>().text = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID).ItemName;
            self.Lab_MakeName.GetComponent<Text>().color =
                    UICommonHelper.QualityReturnColor(ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID).ItemQuality);
            self.Lab_MakeNum.GetComponent<Text>().text = equipMakeConfig.MakeEquipNum.ToString();

            if (equipMakeConfig.ProficiencyValue[0] != 0)
            {
                self.Lab_ShuLianShow.GetComponent<Text>().text =
                        $"熟练度:{equipMakeConfig.ProficiencyValue[0]}-{equipMakeConfig.ProficiencyValue[1]}点 上限:{equipMakeConfig.ProficiencyMax}点";
            }
            else
            {
                self.Lab_ShuLianShow.GetComponent<Text>().text = "";
            }

            //self.TextVitality.GetComponent<Text>().text = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Vitality.ToString();
            //显示消耗活力
            self.TextVitality.GetComponent<Text>().text = equipMakeConfig.CostVitality.ToString();
            self.Text_Current.GetComponent<Text>().text = $"当前活力:  {self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Vitality}";

            int number = 0;
            for (int i = 0; i < itemsList.Length; i++)
            {
                string[] itemInfo = itemsList[i].Split(';');
                if (itemInfo.Length < 2)
                {
                    break;
                }

                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                UIMakeNeedComponent ui_2 = null;
                if (number < self.NeedListUI.Count)
                {
                    ui_2 = self.NeedListUI[number];
                    ui_2.GameObject.SetActive(true);
                }
                else
                {
                    GameObject itemSpace = GameObject.Instantiate(bundleGameObject);
                    itemSpace.SetActive(true);
                    UICommonHelper.SetParent(itemSpace, self.NeedListNode);
                    ui_2 = self.AddChild<UIMakeNeedComponent, GameObject>(itemSpace);
                    self.NeedListUI.Add(ui_2);
                }

                ui_2.UpdateItem(itemId, itemNum);
                number++;
            }

            for (int k = number; k < self.NeedListUI.Count; k++)
            {
                self.NeedListUI[k].GameObject.SetActive(false);
            }
        }

        public static void OnUpdate(this ES_SkillMake self)
        {
            int makeId = self.MakeId;
            UserInfoComponent userInfoComponent = self.ZoneScene().GetComponent<UserInfoComponent>();
            long cdEndTime = userInfoComponent.GetMakeTime(makeId);
            if (cdEndTime <= TimeHelper.ServerNow())
            {
                self.Lab_MakeCDTime.SetActive(false);
                TimerComponent.Instance?.Remove(ref self.Timer);
                return;
            }

            self.Lab_MakeCDTime.GetComponent<Text>().text = TimeHelper.ShowLeftTime(cdEndTime - TimeHelper.ServerNow());
        }

        public static void ShowCDTime(this ES_SkillMake self)
        {
            self.Lab_MakeCDTime.SetActive(false);
            TimerComponent.Instance?.Remove(ref self.Timer);
            int makeId = self.MakeId;
            if (makeId == 0)
            {
                return;
            }

            UserInfoComponent userInfoComponent = self.ZoneScene().GetComponent<UserInfoComponent>();
            long cdEndTime = userInfoComponent.GetMakeTime(makeId);
            if (cdEndTime <= TimeHelper.ServerNow())
            {
                return;
            }

            self.Lab_MakeCDTime.SetActive(true);
            TimerComponent.Instance?.Remove(ref self.Timer);
            self.Timer = TimerComponent.Instance.NewRepeatedTimer(1000, TimerType.MakeCDTimer, self);
            self.OnUpdate();
        }

        public static void OnSelectMakeItem(this ES_SkillMake self, int makeid)
        {
            self.MakeId = makeid;
            if (makeid == 0)
            {
                self.MakeINeedNode.SetActive(false);
                return;
            }

            self.ShowCDTime();
            self.Right.SetActive(true);
            self.Select.SetActive(false);
            self.Melt.SetActive(false);
            self.MakeINeedNode.SetActive(true);
            self.OnBagItemUpdate().Coroutine();

            //设置选中框
            for (int k = 0; k < self.MakeListUI.Count; k++)
            {
                if (self.MakeListUI[k].MakeID == makeid)
                {
                    self.ImageSelect.SetActive(true);
                    UICommonHelper.SetParent(self.ImageSelect, self.MakeListUI[k].GameObject);
                    self.ImageSelect.transform.localPosition = new Vector3(0f, 12f, 0f);
                    break;
                }
            }
        }

        public static async ETTask UpdateMakeList(this ES_SkillMake self, int makeType)
        {
            for (int k = 0; k < self.MakeListUI.Count; k++)
            {
                self.MakeListUI[k].GameObject.SetActive(false);
            }

            if (makeType == 0)
            {
                return;
            }

            int number = 0;
            var path = ABPathHelper.GetUGUIPath("Main/Make/UIMakeItem");
            var bundleGameObject = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);

            List<int> makeList = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.MakeList;
            for (int i = 0; i < makeList.Count; i++)
            {
                if (!EquipMakeConfigCategory.Instance.Contain(makeList[i]))
                {
                    continue;
                }

                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeList[i]);
                if (equipMakeConfig.ProficiencyType != makeType)
                {
                    continue;
                }

                UIMakeItemComponent ui_2 = null;
                if (i < self.MakeListUI.Count)
                {
                    ui_2 = self.MakeListUI[number];
                    ui_2.GameObject.SetActive(true);
                }
                else
                {
                    GameObject itemSpace = GameObject.Instantiate(bundleGameObject);
                    itemSpace.SetActive(true);
                    UICommonHelper.SetParent(itemSpace, self.MakeListNode);
                    ui_2 = self.AddChild<UIMakeItemComponent, GameObject>(itemSpace);
                    ui_2.SetClickAction((int itemid) => { self.OnSelectMakeItem(itemid); });
                    self.MakeListUI.Add(ui_2);
                }

                number++;
                ui_2.OnUpdateUI(equipMakeConfig.Id);
            }

            if (self.MakeId != 0)
            {
                self.OnSelectMakeItem(self.MakeId);
            }
            else
            {
                self.OnSelectMakeItem(number == 0? 0 : self.MakeListUI[0].MakeID);
            }
        }
    }
}