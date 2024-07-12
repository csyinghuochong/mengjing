using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [FriendOf(typeof (ES_CommonItem))]
    [EntitySystemOf(typeof (ES_SkillLifeShield))]
    [FriendOfAttribute(typeof (ES_SkillLifeShield))]
    public static partial class ES_SkillLifeShieldSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillLifeShield self, Transform transform)
        {
            self.uiTransform = transform;

            self.ShieldUIList.Add(self.ES_Shield_1);
            self.ShieldUIList.Add(self.ES_Shield_2);
            self.ShieldUIList.Add(self.ES_Shield_3);
            self.ShieldUIList.Add(self.ES_Shield_4);
            self.ShieldUIList.Add(self.ES_Shield_5);
            self.ShieldUIList.Add(self.ES_Shield_6);
            self.ES_Shield_1.OnInitUI(1);
            self.ES_Shield_2.OnInitUI(2);
            self.ES_Shield_3.OnInitUI(3);
            self.ES_Shield_4.OnInitUI(4);
            self.ES_Shield_5.OnInitUI(5);
            self.ES_Shield_6.OnInitUI(6);
            self.ES_Shield_1.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_2.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_3.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_4.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_5.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_6.SetClickHandler(self.OnClickShieldHandler);

            self.ShieldUIList[0].OnButtonClick();

            self.HuiShoulist.Add(self.ES_CommonItem_1);
            self.HuiShoulist.Add(self.ES_CommonItem_2);
            self.HuiShoulist.Add(self.ES_CommonItem_3);
            self.HuiShoulist.Add(self.ES_CommonItem_4);
            self.HuiShoulist.Add(self.ES_CommonItem_5);

            self.E_CommonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonItemsRefresh);

            self.E_Btn_ZhuRuButton.AddListenerAsync(self.OnBtn_ZhuRu);
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillLifeShield self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_SkillLifeShield self)
        {
            self.UpdateBagUI();
            self.OnUpdateShieldUI();
            self.UpdateZhuRuExp();

            for (int i = 0; i < self.HuiShoulist.Count; i++)
            {
                self.HuiShoulist[i].UpdateItem(null, ItemOperateEnum.None);
                self.HuiShoulist[i].HideItemName();
            }
        }

        public static void OnUpdateShieldUI(this ES_SkillLifeShield self)
        {
            for (int i = 0; i < self.ShieldUIList.Count; i++)
            {
                self.ShieldUIList[i].OnUpdateUI();
            }
        }

        public static void OnHuiShouSelect(this ES_SkillLifeShield self, string dataparams)
        {
            self.UpdateHuiShouInfo(dataparams);
            self.UpdateBagSelected();
            self.UpdateZhuRuExp();
        }

        public static void UpdateZhuRuExp(this ES_SkillLifeShield self)
        {
            List<long> costs = self.GetConstItems();
            if (costs.Count == 0)
            {
                self.E_Text_Zhuru_ExpText.text = string.Empty;
            }
            else
            {
                int minExp = 0;
                int maxExp = 0;

                for (int i = 0; i < costs.Count; i++)
                {
                    BagInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(costs[i]);
                    if (bagInfo == null)
                    {
                        continue;
                    }

                    if (!ConfigData.ItemAddShieldExp.ContainsKey(bagInfo.ItemID))
                    {
                        continue;
                    }

                    int addValue = ConfigData.ItemAddShieldExp[bagInfo.ItemID];
                    if (addValue > 10)
                    {
                        minExp += (int)(0.8f * addValue * bagInfo.ItemNum);
                        maxExp += (int)(1.2f * addValue * bagInfo.ItemNum);
                    }
                    else
                    {
                        minExp += addValue * bagInfo.ItemNum;
                        maxExp += addValue * bagInfo.ItemNum;
                    }
                }

                if (minExp == maxExp)
                {
                    self.E_Text_Zhuru_ExpText.text = $"本次注入预计获得{minExp}经验";
                }
                else
                {
                    self.E_Text_Zhuru_ExpText.text = $"本次注入预计获得{minExp}-{maxExp}经验";
                }
            }
        }

        public static void UpdateHuiShouInfo(this ES_SkillLifeShield self, string dataparams)
        {
            string[] huishouInfo = dataparams.Split('_');
            BagInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(long.Parse(huishouInfo[1]));
            if (bagInfo == null)
            {
                return;
            }

            //1新增  2移除 
            if (huishouInfo[0] == "1")
            {
                for (int i = 0; i < self.HuiShoulist.Count; i++)
                {
                    if (self.HuiShoulist[i].Baginfo == null)
                    {
                        continue;
                    }

                    if (self.HuiShoulist[i].Baginfo.BagInfoID == bagInfo.BagInfoID)
                    {
                        return;
                    }
                }

                for (int i = 0; i < self.HuiShoulist.Count; i++)
                {
                    if (self.HuiShoulist[i].Baginfo == null)
                    {
                        self.HuiShoulist[i].UpdateItem(bagInfo, ItemOperateEnum.HuishouShow);
                        self.HuiShoulist[i].E_ItemNameText.gameObject.SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < self.HuiShoulist.Count; i++)
                {
                    if (self.HuiShoulist[i].Baginfo == null)
                    {
                        continue;
                    }

                    if (self.HuiShoulist[i].Baginfo.BagInfoID == bagInfo.BagInfoID)
                    {
                        self.HuiShoulist[i].UpdateItem(null, ItemOperateEnum.None);
                        self.HuiShoulist[i].E_ItemNameText.gameObject.SetActive(false);
                    }
                }
            }
        }

        public static void UpdateBagSelected(this ES_SkillLifeShield self)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Count; i++)
            {
                Scroll_Item_CommonItem uIItemComponent = self.ScrollItemCommonItems[i];
                if (uIItemComponent.uiTransform == null)
                {
                    continue;
                }
                
                BagInfo bagInfo = uIItemComponent.ES_CommonItem.Baginfo;
                if (bagInfo == null)
                {
                    continue;
                }

                bool have = false;
                for (int h = 0; h < self.HuiShoulist.Count; h++)
                {
                    if (self.HuiShoulist[h].Baginfo != null && self.HuiShoulist[h].Baginfo == bagInfo)
                    {
                        have = true;
                    }
                }

                uIItemComponent.ES_CommonItem.E_XuanZhongImage.gameObject.SetActive(have);
            }
        }

        public static void OnClickShieldHandler(this ES_SkillLifeShield self, int shieldType)
        {
            self.ShieldType = shieldType;
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            int curLv = skillSetComponent.GetLifeShieldLevel(shieldType);
            int maxLv = LifeShieldConfigCategory.Instance.LifeShieldList[shieldType].Count;
            int nextlifeId = skillSetComponent.GetLifeShieldShowId(shieldType);

            LifeShieldConfig lifeShieldConfig = LifeShieldConfigCategory.Instance.Get(nextlifeId);
            self.E_Text_ShieldNameText.text = $"{lifeShieldConfig.ShieldName}";
            self.E_Text_ShieldDescText.text = lifeShieldConfig.Des;

            LifeShieldInfo lifeShieldInfo = skillSetComponent.GetLifeShieldByType(shieldType);
            int curExp = lifeShieldInfo != null? lifeShieldInfo.Exp : 0;

            if (curLv == maxLv)
            {
                self.E_Text_ProgessText.text = $"已满级";
            }
            else
            {
                self.E_Text_ProgessText.text = $"{curExp}/{lifeShieldConfig.ShieldExp}";
                self.E_ImageProgessImage.fillAmount = (float)(curExp) / (float)(lifeShieldConfig.ShieldExp);
            }

            for (int i = 0; i < self.ShieldUIList.Count; i++)
            {
                self.ShieldUIList[i].SetSelected(shieldType);
            }
        }

        public static async ETTask OnBtn_ZhuRu(this ES_SkillLifeShield self)
        {
            List<long> costs = self.GetConstItems();
            if (costs.Count == 0 || self.ShieldType == 0)
            {
                return;
            }

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            if (self.ShieldType == 6)
            {
                int hplv = skillSetComponent.GetLifeShieldLevel(self.ShieldType);
                int otlv = skillSetComponent.GetOtherMinLevel();
                if (otlv <= hplv)
                {
                    FlyTipComponent.Instance.ShowFlyTipDi("请先升级其他护盾！");
                    return;
                }
            }

            M2C_LifeShieldCostResponse response = await SkillNetHelper.LifeShieldCost(self.Root(), self.ShieldType, costs);

            if (response.AddExp > 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("注入成功!本次增加" + response.AddExp + "点魂值");
            }

            self.Root().GetComponent<SkillSetComponentC>().LifeShieldList = response.ShieldList;
            self.OnClickShieldHandler(self.ShieldType);
            self.OnUpdateUI();
        }

        private static void OnCommonItemsRefresh(this ES_SkillLifeShield self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.ES_CommonItem.UpdateItem(self.ShowBagInfos[index], ItemOperateEnum.HuishouBag);
            scrollItemCommonItem.ES_CommonItem.HideItemName();
            scrollItemCommonItem.ES_CommonItem.SetEventTrigger(true);
            scrollItemCommonItem.ES_CommonItem.PointerDownHandler = (BagInfo binfo, PointerEventData pdata) =>
            {
                self.OnPointerDown(binfo, pdata).Coroutine();
            };
            scrollItemCommonItem.ES_CommonItem.PointerUpHandler = (BagInfo binfo, PointerEventData pdata) => { self.OnPointerUp(binfo, pdata); };
            scrollItemCommonItem.ES_CommonItem.BeginDragHandler = (BagInfo binfo, PointerEventData pdata) => { self.OnBeginDrag(binfo, pdata); };
            scrollItemCommonItem.ES_CommonItem.DragingHandler = (BagInfo binfo, PointerEventData pdata) => { self.OnDraging(binfo, pdata); };
            scrollItemCommonItem.ES_CommonItem.EndDragHandler = (BagInfo binfo, PointerEventData pdata) => { self.OnEndDrag(binfo, pdata); };
        }

        public static void UpdateBagUI(this ES_SkillLifeShield self)
        {
            List<BagInfo> allInfos = new List<BagInfo>();
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            //allInfos.AddRange(bagComponent.GetItemsByType(ItemTypeEnum.Consume));
            allInfos.AddRange(bagComponent.GetItemsByType(ItemTypeEnum.Material));
            allInfos.AddRange(bagComponent.GetItemsByType(ItemTypeEnum.Equipment));

            self.ShowBagInfos.Clear();
            for (int i = 0; i < allInfos.Count; i++)
            {
                if (!ConfigData.ItemAddShieldExp.ContainsKey(allInfos[i].ItemID))
                {
                    continue;
                }

                self.ShowBagInfos.Add(allInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_CommonItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void OnBeginDrag(this ES_SkillLifeShield self, BagInfo bagInfo, PointerEventData pdata)
        {
            self.E_CommonItemsLoopVerticalScrollRect.OnBeginDrag(pdata);
            self.IsDrag = true;
        }

        public static void OnDraging(this ES_SkillLifeShield self, BagInfo bagInfo, PointerEventData pdata)
        {
            self.E_CommonItemsLoopVerticalScrollRect.OnDrag(pdata);
            self.IsDrag = true;
        }

        public static void OnEndDrag(this ES_SkillLifeShield self, BagInfo bagInfo, PointerEventData pdata)
        {
            self.E_CommonItemsLoopVerticalScrollRect.OnEndDrag(pdata);
            self.IsDrag = false;
        }

        public static async ETTask OnPointerDown(this ES_SkillLifeShield self, BagInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = true;
            self.ClickTime = TimeHelper.ClientNow();
            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            if (!self.IsHoldDown || self.IsDrag)
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

        public static void OnPointerUp(this ES_SkillLifeShield self, BagInfo binfo, PointerEventData pdata)
        {
            if (TimeHelper.ClientNow() - self.ClickTime < 200)
            {
                EventSystem.Instance.Publish(self.Root(), new DataUpdate_HuiShouSelect() { DataParamString = $"1_{binfo.BagInfoID}" });
            }

            self.IsHoldDown = false;
        }

        public static List<long> GetConstItems(this ES_SkillLifeShield self)
        {
            List<long> constids = new List<long>();
            for (int h = 0; h < self.HuiShoulist.Count; h++)
            {
                if (self.HuiShoulist[h].Baginfo != null)
                {
                    constids.Add(self.HuiShoulist[h].Baginfo.BagInfoID);
                }
            }

            return constids;
        }
    }
}