using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.MakeCDTimer)]
    public class SkillMakeTimer: ATimer<ES_SkillMake>
    {
        protected override void Run(ES_SkillMake self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof (ES_CommonItem))]
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [FriendOf(typeof (Scroll_Item_MakeNeedItem))]
    [FriendOf(typeof (Scroll_Item_MakeItem))]
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

            self.E_MakeNeedItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMakeNeedItemsRefresh);
            self.E_MakeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMakeItemsRefresh);

            self.E_Btn_MeltBeginButton.AddListenerAsync(self.OnBtn_MeltBegin);
            self.E_CommonItemLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonItemsRefresh);

            self.HuiShouUIList[0] = self.ES_CommonItem_1;
            self.HuiShouUIList[1] = self.ES_CommonItem_2;
            self.HuiShouUIList[2] = self.ES_CommonItem_3;
            self.HuiShouUIList[3] = self.ES_CommonItem_4;
            self.HuiShouUIList[4] = self.ES_CommonItem_5;

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
                self.EG_SelectRectTransform.gameObject.SetActive(true);
                self.EG_MeltRectTransform.gameObject.SetActive(false);
            }, null).Coroutine();
        }

        public static void OnBtn_Learn(this ES_SkillMake self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "学习技能", "可以在主城对应的各职业学习大师处学习当前等级最新的生活技能喔!", () =>
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                int makeTypenumreic = self.Plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2;
                int makeId = unit.GetComponent<NumericComponentC>().GetAsInt(makeTypenumreic);
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

                // self.Root().CurrentScene().GetComponent<OperaComponent>().OnClickNpc(npcId).Coroutine();

                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Skill);
            }, null).Coroutine();
        }

        public static async ETTask RequestMakeSelect(this ES_SkillMake self, int makeId)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int makeType_1 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_1);
            int makeType_2 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_2);
            if (makeType_1 == makeId || makeType_2 == makeId)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("该生活技能已学习！");
                return;
            }

            await SkillNetHelper.MakeSelect(self.Root(), makeId, self.Plan == -1? 1 : self.Plan);

            self.OnUpdateMakeType();
            self.UpdateShuLianDu();
        }

        public static void OnUpdateMakeType(this ES_SkillMake self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int makeTypeNumeric = self.Plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2;
            int makeType = unit.GetComponent<NumericComponentC>().GetAsInt(makeTypeNumeric);
            self.EG_RightRectTransform.gameObject.SetActive(makeType != 0);
            self.EG_LeftRectTransform.gameObject.SetActive(makeType != 0);
            self.EG_SelectRectTransform.gameObject.SetActive(makeType == 0);
            self.EG_MeltRectTransform.gameObject.SetActive(false);
            self.UpdateMakeList(makeType);
        }

        public static void OnBtn_Melt(this ES_SkillMake self)
        {
            self.EG_RightRectTransform.gameObject.SetActive(false);
            self.EG_SelectRectTransform.gameObject.SetActive(false);
            self.EG_MeltRectTransform.gameObject.SetActive(true);
            self.OnUpdateUI();
        }

        public static void OnBtn_Plan(this ES_SkillMake self, int plan)
        {
            if (self.Plan == plan)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int rechargeNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber);
            int needRecharge = GlobalValueConfigCategory.Instance.Get(113).Value2;
            int skillmakePlan_2 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.SkillMakePlan2);
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

                PopupTipHelp.OpenPopupTipWithButtonText(self.Root(), "开启栏位", tip, () =>
                {
                    if (rechargeNumber < needRecharge)
                    {
                        FlyTipComponent.Instance.SpawnFlyTipDi("充值额度不足！");
                    }
                    else
                    {
                        self.OnUpdate_Plan(plan);
                        self.UpdateSkillMakePlan2().Coroutine();
                    }
                }, () =>
                {
                    // self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
                }, "开启", "前往充值").Coroutine();
                return;
            }

            self.OnUpdate_Plan(plan);
        }

        public static async ETTask UpdateSkillMakePlan2(this ES_SkillMake self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.SkillMakePlan2) == 1)
            {
                return;
            }

            await SkillNetHelper.SkillOperation(self.Root(), 3);
        }

        public static void OnUpdate_Plan(this ES_SkillMake self, int plan)
        {
            self.Plan = plan;
            self.MakeId = 0;
            self.E_Btn_TianFu_1Image.transform.Find("Image").gameObject.SetActive(plan == 1);
            self.E_Btn_TianFu_2Image.transform.Find("Image").gameObject.SetActive(plan == 2);
            self.SetPlan(plan);

            self.OnUpdateMakeType();
            self.UpdateShuLianDu();
        }

        public static async ETTask OnBtn_Make(this ES_SkillMake self)
        {
            if (self.MakeId == 0)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(self.MakeId);
            if (cdEndTime > TimeHelper.ServerNow())
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_InMakeCD);
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

            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Vitality < equipMakeConfig.CostVitality)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("活力不足！");
                return;
            }

            bool success = self.Root().GetComponent<BagComponentC>().CheckNeedItem(costItems);
            if (!success)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("材料不足！");
                return;
            }

            await SkillNetHelper.MakeEquip(self.Root(), 0, self.MakeId, self.Plan);

            self.OnUpdateMakeType();
            self.UpdateShuLianDu();
            self.OnBagItemUpdate();
        }

        public static void UpdateShuLianDu(this ES_SkillMake self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int maxValue = ComHelp.MaxShuLianDu();
            int shulianduNumeric = self.Plan == 1? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
            int curValue = unit.GetComponent<NumericComponentC>().GetAsInt(shulianduNumeric);

            self.E_Lab_ShuLianDuText.text = $"{curValue}/{maxValue}";
            self.E_Img_ShuLianProImage.fillAmount = curValue * 1f / maxValue;
        }

        public static void OnBagItemUpdate(this ES_SkillMake self)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);

            self.ES_CommonItem_0.UpdateItem(new BagInfo() { ItemID = equipMakeConfig.MakeItemID }, ItemOperateEnum.MakeItem);
            self.ES_CommonItem_0.E_ItemNumText.gameObject.SetActive(false);

            string needItems = equipMakeConfig.NeedItems;
            string[] itemsList = needItems.Split('@');

            //显示名称
            self.E_Lab_MakeNameText.text = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID).ItemName;
            self.E_Lab_MakeNameText.color =
                    UICommonHelper.QualityReturnColor(ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID).ItemQuality);
            self.E_Lab_MakeNumText.text = equipMakeConfig.MakeEquipNum.ToString();

            if (equipMakeConfig.ProficiencyValue[0] != 0)
            {
                self.E_Lab_ShuLianShowText.text =
                        $"熟练度:{equipMakeConfig.ProficiencyValue[0]}-{equipMakeConfig.ProficiencyValue[1]}点 上限:{equipMakeConfig.ProficiencyMax}点";
            }
            else
            {
                self.E_Lab_ShuLianShowText.text = "";
            }

            //self.TextVitality.GetComponent<Text>().text = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Vitality.ToString();
            //显示消耗活力
            self.E_Lab_HuoLiText.text = equipMakeConfig.CostVitality.ToString();
            self.E_Text_CurrentText.text = $"当前活力:  {self.Root().GetComponent<UserInfoComponentC>().UserInfo.Vitality}";

            self.ShowMakeNeed.Clear();

            for (int i = 0; i < itemsList.Length; i++)
            {
                string[] itemInfo = itemsList[i].Split(';');
                if (itemInfo.Length < 2)
                {
                    break;
                }

                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);

                self.ShowMakeNeed.Add((itemId, itemNum));
            }

            self.AddUIScrollItems(ref self.ScrollItemMakeNeedItems, self.ShowMakeNeed.Count);
            self.E_MakeNeedItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMakeNeed.Count);
        }

        private static void OnMakeNeedItemsRefresh(this ES_SkillMake self, Transform transform, int index)
        {
            Scroll_Item_MakeNeedItem scrollItemMakeNeedItem = self.ScrollItemMakeNeedItems[index].BindTrans(transform);
            scrollItemMakeNeedItem.UpdateItem(self.ShowMakeNeed[index].Item1, self.ShowMakeNeed[index].Item2);
        }

        public static void OnUpdate(this ES_SkillMake self)
        {
            int makeId = self.MakeId;
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(makeId);
            if (cdEndTime <= TimeHelper.ServerNow())
            {
                self.E_Lab_MakeCDTimeText.gameObject.SetActive(false);
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                return;
            }

            self.E_Lab_MakeCDTimeText.text = TimeHelper.ShowLeftTime(cdEndTime - TimeHelper.ServerNow());
        }

        public static void ShowCDTime(this ES_SkillMake self)
        {
            self.E_Lab_MakeCDTimeText.gameObject.SetActive(false);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            int makeId = self.MakeId;
            if (makeId == 0)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(makeId);
            if (cdEndTime <= TimeHelper.ServerNow())
            {
                return;
            }

            self.E_Lab_MakeCDTimeText.gameObject.SetActive(true);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.MakeCDTimer, self);
            self.OnUpdate();
        }

        public static void OnSelectMakeItem(this ES_SkillMake self, int makeid)
        {
            self.MakeId = makeid;
            if (makeid == 0)
            {
                self.EG_MakeINeedNodeRectTransform.gameObject.SetActive(false);
                return;
            }

            self.ShowCDTime();
            self.EG_RightRectTransform.gameObject.SetActive(true);
            self.EG_SelectRectTransform.gameObject.SetActive(false);
            self.EG_MeltRectTransform.gameObject.SetActive(false);
            self.EG_MakeINeedNodeRectTransform.gameObject.SetActive(true);
            self.OnBagItemUpdate();

            //设置选中框
            for (int k = 0; k < self.ScrollItemMakeItems.Count; k++)
            {
                if (self.ScrollItemMakeItems[k].uiTransform != null)
                {
                    if (self.ScrollItemMakeItems[k].MakeID == makeid)
                    {
                        self.E_ImageSelectImage.gameObject.SetActive(true);
                        UICommonHelper.SetParent(self.E_ImageSelectImage.gameObject, self.ScrollItemMakeItems[k].uiTransform.gameObject);
                        self.E_ImageSelectImage.gameObject.transform.localPosition = new Vector3(0f, 12f, 0f);
                        break;
                    }
                }
            }
        }

        private static void OnMakeItemsRefresh(this ES_SkillMake self, Transform transform, int index)
        {
            Scroll_Item_MakeItem scrollItemMakeItem = self.ScrollItemMakeItems[index].BindTrans(transform);
            scrollItemMakeItem.SetClickAction((int itemid) => { self.OnSelectMakeItem(itemid); });
            scrollItemMakeItem.OnUpdateUI(self.ShowMake[index]);
        }

        public static void UpdateMakeList(this ES_SkillMake self, int makeType)
        {
            if (makeType == 0)
            {
                return;
            }

            self.ShowMake.Clear();

            int number = 0;
            List<int> makeList = self.Root().GetComponent<UserInfoComponentC>().UserInfo.MakeList;
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

                self.ShowMake.Add(equipMakeConfig.Id);
                number++;
            }

            self.AddUIScrollItems(ref self.ScrollItemMakeItems, self.ShowMake.Count);
            self.E_MakeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMake.Count);

            if (self.MakeId != 0)
            {
                self.OnSelectMakeItem(self.MakeId);
            }
            else
            {
                self.OnSelectMakeItem(number == 0? 0 : self.ScrollItemMakeItems[0].MakeID);
            }
        }

        public static void SetPlan(this ES_SkillMake self, int plan)
        {
            self.PlanMelt = plan;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int makeType = unit.GetComponent<NumericComponentC>().GetAsInt(plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2);

            self.ES_CommonItem.UpdateItem(new BagInfo() { ItemID = XiLianHelper.ReturnMeltingItem(makeType) }, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
        }

        public static void OnUpdateUI(this ES_SkillMake self)
        {
            self.HuiShouInfos = new BagInfo[self.HuiShouInfos.Length];
            self.UpdateBagUI();
            self.UpdateHuiShouUI();
            self.UpdateSelected();
        }

        public static void OnHuiShouSelect(this ES_SkillMake self, string dataparams)
        {
            self.UpdateHuiShouInfo(dataparams);
            self.UpdateHuiShouUI();
            self.UpdateSelected();
        }

        public static void UpdateHuiShouInfo(this ES_SkillMake self, string dataparams)
        {
            string[] huishouInfo = dataparams.Split('_');
            BagInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(long.Parse(huishouInfo[1]));
            if (huishouInfo[0] == "1")
            {
                for (int i = 0; i < self.HuiShouInfos.Length; i++)
                {
                    if (self.HuiShouInfos[i] == bagInfo)
                    {
                        return;
                    }
                }

                for (int i = 0; i < self.HuiShouInfos.Length; i++)
                {
                    if (self.HuiShouInfos[i] == null)
                    {
                        self.HuiShouInfos[i] = bagInfo;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < self.HuiShouInfos.Length; i++)
                {
                    if (self.HuiShouInfos[i] == bagInfo)
                    {
                        self.HuiShouInfos[i] = null;
                        break;
                    }
                }
            }
        }

        public static List<long> GetHuiShouList(this ES_SkillMake self)
        {
            List<long> huishouList = new List<long>();
            for (int i = 0; i < self.HuiShouInfos.Length; i++)
            {
                if (self.HuiShouInfos[i] != null)
                {
                    huishouList.Add(self.HuiShouInfos[i].BagInfoID);
                }
            }

            return huishouList;
        }

        public static async ETTask OnBtn_MeltBegin(this ES_SkillMake self)
        {
            List<long> huishouList = self.GetHuiShouList();
            if (huishouList.Count == 0)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int makeId = unit.GetComponent<NumericComponentC>().GetAsInt(self.Plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2);

            await SkillNetHelper.ItemMelting(self.Root(), huishouList, makeId);

            self.OnUpdateUI();
        }

        public static void UpdateSelected(this ES_SkillMake self)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Count; i++)
            {
                if (self.ScrollItemCommonItems[i].uiTransform == null)
                {
                    continue;
                }

                Scroll_Item_CommonItem uIItemComponent = self.ScrollItemCommonItems[i];
                BagInfo bagInfo = uIItemComponent.ES_CommonItem.Baginfo;
                if (bagInfo == null)
                {
                    continue;
                }

                bool have = false;
                for (int h = 0; h < self.HuiShouInfos.Length; h++)
                {
                    if (self.HuiShouInfos[h] != null && self.HuiShouInfos[h].BagInfoID == bagInfo.BagInfoID)
                    {
                        have = true;
                    }
                }

                uIItemComponent.ES_CommonItem.E_XuanZhongImage.gameObject.SetActive(have);
            }
        }

        public static void UpdateHuiShouUI(this ES_SkillMake self)
        {
            for (int i = 0; i < self.HuiShouInfos.Length; i++)
            {
                self.HuiShouUIList[i].UpdateItem(self.HuiShouInfos[i], ItemOperateEnum.HuishouShow);
            }
        }

        private static void OnCommonItemsRefresh(this ES_SkillMake self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.ES_CommonItem.UpdateItem(self.ShowBagInfos[index], ItemOperateEnum.HuishouBag);
            scrollItemCommonItem.ES_CommonItem.SetEventTrigger(true);
            scrollItemCommonItem.ES_CommonItem.PointerDownHandler = (BagInfo binfo, PointerEventData pdata) => { self.OnPointerDown(binfo, pdata); };
            scrollItemCommonItem.ES_CommonItem.PointerUpHandler = (BagInfo binfo, PointerEventData pdata) => { self.OnPointerUp(binfo, pdata); };
            scrollItemCommonItem.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
        }

        public static void UpdateBagUI(this ES_SkillMake self, int itemType = -1)
        {
            self.ShowBagInfos.Clear();

            List<BagInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetItemsByType(ItemTypeEnum.Equipment);
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].IsProtect)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemQuality < 4)
                {
                    continue;
                }

                self.ShowBagInfos.Add(bagInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_CommonItemLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static async ETTask OnPutInItem(this ES_SkillMake self, BagInfo binfo)
        {
            self.IsHoldDown = true;
            EventSystem.Instance.Publish(self.Root(), new DataUpdate_HuiShouSelect() { DataParamString = $"1_{binfo.BagInfoID}" });
            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            if (!self.IsHoldDown)
                return;

            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = binfo,
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new List<BagInfo>()
                });
        }

        public static void OnPointerDown(this ES_SkillMake self, BagInfo binfo, PointerEventData pdata)
        {
            if (ItemHelper.GetGemIdList(binfo).Count > 0)
            {
                List<long> huishouList = self.GetHuiShouList();
                if (huishouList.Contains(binfo.BagInfoID))
                {
                    return;
                }

                PopupTipHelp.OpenPopupTip(self.Root(), "生活熔炼", "该装备镶嵌有宝石，是否放入熔炼?", () => { self.OnPutInItem(binfo).Coroutine(); }, null)
                        .Coroutine();
            }
            else
            {
                self.OnPutInItem(binfo).Coroutine();
            }
        }

        public static void OnPointerUp(this ES_SkillMake self, BagInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }
    }
}