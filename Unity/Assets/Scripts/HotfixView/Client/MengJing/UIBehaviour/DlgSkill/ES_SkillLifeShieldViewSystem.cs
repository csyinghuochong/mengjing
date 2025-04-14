using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [EntitySystemOf(typeof(ES_SkillLifeShield))]
    [FriendOfAttribute(typeof(ES_SkillLifeShield))]
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
            self.ShieldUIList.Add(self.ES_Shield_7);
            self.ES_Shield_1.OnInitUI(1);
            self.ES_Shield_2.OnInitUI(2);
            self.ES_Shield_3.OnInitUI(3);
            self.ES_Shield_4.OnInitUI(4);
            self.ES_Shield_5.OnInitUI(5);
            self.ES_Shield_6.OnInitUI(6);
            self.ES_Shield_7.OnInitUI(7);
            self.ES_Shield_1.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_2.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_3.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_4.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_5.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_6.SetClickHandler(self.OnClickShieldHandler);
            self.ES_Shield_7.SetClickHandler(self.OnClickShieldHandler);
            
            ES_Shield esShield = self.ShieldUIList[0];
            esShield.OnImageIconButton();
            
            self.E_CommonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonItemsRefresh);

            self.E_Btn_ZhuRuButton.AddListenerAsync(self.OnBtn_ZhuRuButton);
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
            self.HuiShoulist.Clear();
        }

        public static void OnUpdateShieldUI(this ES_SkillLifeShield self)
        {
            for (int i = 0; i < self.ShieldUIList.Count; i++)
            {
                ES_Shield esShield = self.ShieldUIList[i];
                esShield.OnUpdateUI();
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
                    ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(costs[i]);
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

                using (zstring.Block())
                {
                    if (minExp == maxExp)
                    {
                        self.E_Text_Zhuru_ExpText.text = zstring.Format("本次注入预计获得{0}经验", minExp);
                    }
                    else
                    {
                        self.E_Text_Zhuru_ExpText.text = zstring.Format("本次注入预计获得{0}-{1}经验", minExp, maxExp);
                    }
                }
            }

            int total = LifeShieldConfigCategory.Instance.GetAll().Count;
            int cur = self.GetOtherLifeShieldLevel(new List<int>(){1,2,3,4,5,6,7});
            using (zstring.Block())
            {
                self.E_Text_TotalLevel.text = zstring.Format("{0}/{1}", cur, total);   
            }
        }

        public static void UpdateHuiShouInfo(this ES_SkillLifeShield self, string dataparams)
        {
            string[] huishouInfo = dataparams.Split('_');
            ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(long.Parse(huishouInfo[1]));
            if (bagInfo == null)
            {
                return;
            }

            //1新增  2移除 
            if (huishouInfo[0] == "1")
            {
                if (!self.HuiShoulist.Contains(bagInfo.BagInfoID))
                {
                    self.HuiShoulist.Add(bagInfo.BagInfoID);
                }
            }
            else
            {
                self.HuiShoulist.Remove(bagInfo.BagInfoID);
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

                ItemInfo bagInfo = uIItemComponent.Baginfo;
                if (bagInfo == null)
                {
                    continue;
                }

                bool have = self.HuiShoulist.Contains(bagInfo.BagInfoID);
                uIItemComponent.E_XuanZhongImage.gameObject.SetActive(have);
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
            self.E_Text_ShieldNameText.text = lifeShieldConfig.ShieldName;
            self.E_Text_ShieldDescText.text = lifeShieldConfig.Des.Replace(",", "\n");  //lifeShieldConfig.Des;
            self.E_Text_ShieldLevel.text = lifeShieldConfig.ShieldLevel.ToString();

            LifeShieldInfo lifeShieldInfo = skillSetComponent.GetLifeShieldByType(shieldType);
            int curExp = lifeShieldInfo != null ? lifeShieldInfo.Exp : 0;

            if (curLv == maxLv)
            {
                self.E_Text_ProgessText.text = "已满级";
            }
            else
            {
                using (zstring.Block())
                {
                    self.E_Text_ProgessText.text = zstring.Format("{0}/{1}", curExp, lifeShieldConfig.ShieldExp);
                }

                self.E_ImageProgessImage.fillAmount = (float)(curExp) / (float)(lifeShieldConfig.ShieldExp);
            }

            for (int i = 0; i < self.ShieldUIList.Count; i++)
            {
                ES_Shield esShield = self.ShieldUIList[i];
                esShield.SetSelected(shieldType);
            }
        }

        private static int GetOtherLifeShieldLevel(this ES_SkillLifeShield self, List<int> typelist)
        {
            int lv = 0;
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            foreach (var i in typelist)
            {
                lv +=  skillSetComponent.GetLifeShieldLevel(i);
            }
            return lv;  
        }

        public static async ETTask OnBtn_ZhuRuButton(this ES_SkillLifeShield self)
        {
            List<long> costs = self.GetConstItems();
            if (costs.Count == 0 || self.ShieldType == 0)
            {
                return;
            }
            
            //技能的生灵系统调整 增加一个格子，之前是周围不能超过中间，现在是当前6个总和超过共享上限等级
            //就需要升级中间的来提升共享上限等级，初始是6级，中间升一级 会提升6个共享上限等级

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            if (self.ShieldType != 7)   //非能量之源升级 需要 判断 共享上限
            {
                int hplv = skillSetComponent.GetLifeShieldLevel(7) * 6;
                int culv = self.GetOtherLifeShieldLevel(new List<int>(){1,2,3,4,5,6});
                if (hplv <= culv)
                {
                    FlyTipComponent.Instance.ShowFlyTip("请先升级能量之源！");
                    return;
                }
            }

            long instanceid = self.InstanceId;
            M2C_LifeShieldCostResponse response = await SkillNetHelper.LifeShieldCost(self.Root(), self.ShieldType, costs);
            if (instanceid != self.InstanceId)
            {
                return;
            }
            if (response.AddExp > 0)
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("注入成功!本次增加{0}点魂值", response.AddExp));
                }
            }

            skillSetComponent.LifeShieldList = response.ShieldList;
            self.OnClickShieldHandler(self.ShieldType);
            self.OnUpdateUI();
        }

        private static void OnCommonItemsRefresh(this ES_SkillLifeShield self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.UpdateItem(self.ShowBagInfos[index], ItemOperateEnum.HuishouBag);
            scrollItemCommonItem.HideItemName();
            scrollItemCommonItem.SetEventTrigger(true);
            scrollItemCommonItem.PointerDownHandler = (ItemInfo binfo, PointerEventData pdata) =>
            {
                self.OnPointerDown(binfo, pdata).Coroutine();
            };
            scrollItemCommonItem.PointerUpHandler = (ItemInfo binfo, PointerEventData pdata) => { self.OnPointerUp(binfo, pdata); };
            // scrollItemCommonItem.ES_CommonItem.BeginDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.OnBeginDrag(binfo, pdata); };
            // scrollItemCommonItem.ES_CommonItem.DragingHandler = (ItemInfo binfo, PointerEventData pdata) => { self.OnDraging(binfo, pdata); };
            scrollItemCommonItem.EndDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.OnEndDrag(binfo, pdata); };
            //scrollItemCommonItem.ES_CommonItem.ClickItemHandler =  (ItemInfo binfo) => { self.OnClickItem(binfo); };
        }

        public static void UpdateBagUI(this ES_SkillLifeShield self)
        {
            List<ItemInfo> allInfos = new List<ItemInfo>();
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

        public static void OnClickItem(this ES_SkillLifeShield self, ItemInfo bagInfo)
        {
            
        }

       
        public static void OnEndDrag(this ES_SkillLifeShield self, ItemInfo bagInfo, PointerEventData pdata)
        {
            self.E_CommonItemsLoopVerticalScrollRect.OnEndDrag(pdata);
            self.IsDrag = false;
        }

        public static async ETTask OnPointerDown(this ES_SkillLifeShield self, ItemInfo binfo, PointerEventData pdata)
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
                    EquipList = new List<ItemInfo>()
                });
        }

        public static void OnPointerUp(this ES_SkillLifeShield self, ItemInfo binfo, PointerEventData pdata)
        {
            if (TimeHelper.ClientNow() - self.ClickTime < 200)
            {
                int add = self.HuiShoulist.Contains(binfo.BagInfoID) ? 2 : 1;   
                string paramsStr = $"{add}_{binfo.BagInfoID}";
                self.OnHuiShouSelect(paramsStr);
            }

            self.IsHoldDown = false;
        }

        public static List<long> GetConstItems(this ES_SkillLifeShield self)
        {
            return  self.HuiShoulist;
        }
    }
}
