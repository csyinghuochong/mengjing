using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CostItem))]
    [FriendOf(typeof(Scroll_Item_SeasonJingHeItem))]
    [EntitySystemOf(typeof(ES_SeasonJingHe))]
    [FriendOfAttribute(typeof(ES_SeasonJingHe))]
    public static partial class ES_SeasonJingHeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SeasonJingHe self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_SeasonJingHeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSeasonJingHeItemsRefresh);
            self.E_OpenBtnButton.AddListenerAsync(self.OnOpenBtnButton);
            self.E_EquipBtnButton.AddListenerAsync(self.OnEquipBtnButton);
            self.E_TakeOffBtnButton.AddListenerAsync(self.OnTakeOffBtnButton);
            self.E_TakeOffBtnButton.gameObject.SetActive(false);

            self.E_Btn_TianFu_2Button.AddListener(() => { self.OnBtn_TianFuPlan(1).Coroutine(); });
            self.E_Btn_TianFu_1Button.AddListener(() => { self.OnBtn_TianFuPlan(0).Coroutine(); });

            self.InitCell();
            self.UpdatePlanButton();
        }

        [EntitySystem]
        private static void Destroy(this ES_SeasonJingHe self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnBtn_TianFuPlan(this ES_SeasonJingHe self, int plan)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.SeasonJingHePlan == plan)
            {
                return;
            }

            await BagClientNetHelper.JingHePlan(self.Root(), plan);
            bagComponent.SeasonJingHePlan = plan;

            if (self.IsDisposed)
            {
                return;
            }

            self.UpdatePlanButton();
            self.UpdateInfo(self.JingHeId);
        }

        public static void UpdatePlanButton(this ES_SeasonJingHe self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            self.E_Btn_TianFu_1Button.transform.Find("Image").gameObject.SetActive(bagComponent.SeasonJingHePlan == 0);
            self.E_Btn_TianFu_2Button.transform.Find("Image").gameObject.SetActive(bagComponent.SeasonJingHePlan == 1);
        }

        private static void OnBagItemsRefresh(this ES_SeasonJingHe self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.None, self.OnSelect);
        }

        private static void OnSeasonJingHeItemsRefresh(this ES_SeasonJingHe self, Transform transform, int index)
        {
            foreach (Scroll_Item_SeasonJingHeItem item in self.ScrollItemSeasonJingHeItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_SeasonJingHeItem scrollItemSeasonJingHeItem = self.ScrollItemSeasonJingHeItems[index].BindTrans(transform);
            scrollItemSeasonJingHeItem.JingHeId = self.ShowSeasonJingHeConfigs[index].Id;
        }

        public static void InitCell(this ES_SeasonJingHe self)
        {
            self.ShowSeasonJingHeConfigs = SeasonJingHeConfigCategory.Instance.GetAll().Values.ToList();

            self.AddUIScrollItems(ref self.ScrollItemSeasonJingHeItems, self.ShowSeasonJingHeConfigs.Count);
            self.E_SeasonJingHeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowSeasonJingHeConfigs.Count);

            self.UpdateInfo(1);
        }

        public static void UpdateInfo(this ES_SeasonJingHe self, int jingHeId)
        {
            // 更新孔位信息
            self.JingHeId = jingHeId;

            self.E_TakeOffBtnButton.gameObject.SetActive(self.Root().GetComponent<BagComponentC>().GetJingHeByWeiZhi(jingHeId) != null);

            Scroll_Item_SeasonJingHeItem nowItem = null;
            foreach (Scroll_Item_SeasonJingHeItem item in self.ScrollItemSeasonJingHeItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                item.OnUpdateData();
                // 高亮
                item.E_OutLineImgImage.gameObject.SetActive(false);
                if (item.JingHeId == jingHeId)
                {
                    nowItem = item;
                    item.E_OutLineImgImage.gameObject.SetActive(true);
                    self.E_JingHeImgImage.sprite = item.E_IconImgImage.gameObject.activeSelf ? item.E_IconImgImage.sprite : self.OldSprite;
                }
            }

            SeasonJingHeConfig seasonJingHeConfig = SeasonJingHeConfigCategory.Instance.Get(jingHeId);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            // 更新右侧面板信息
            if (!userInfoComponent.UserInfo.OpenJingHeIds.Contains(seasonJingHeConfig.Id)) // 未解锁的孔位
            {
                self.E_NameTextText.text = "赛季晶核孔位";
                self.E_DesTextText.text = "可以让玩家在本赛季拥有额外的赛季能力";

                int costItemId = int.Parse(seasonJingHeConfig.Cost.Split(';')[0]);
                int cosrItemNum = int.Parse(seasonJingHeConfig.Cost.Split(';')[1]);

                self.ES_CostItem.UpdateItem(costItemId, cosrItemNum);

                self.E_BagItemsLoopVerticalScrollRect.gameObject.SetActive(false);
                self.ES_CostItem.uiTransform.gameObject.SetActive(true);

                self.E_OpenBtnButton.gameObject.SetActive(true);
                self.E_EquipBtnButton.gameObject.SetActive(false);
            }
            else // 解锁的孔位
            {
                self.E_NameTextText.text = "赛季晶核孔位";
                string attribute = "";
                if (nowItem != null && nowItem.BagInfo != null)
                {
                    if (nowItem.BagInfo.XiLianHideProLists != null)
                    {
                        foreach (HideProList hideProList in nowItem.BagInfo.XiLianHideProLists)
                        {
                            if (hideProList.HideID == 0) continue;
                            string proName = ItemViewHelp.GetAttributeName(hideProList.HideID);
                            int showType = NumericHelp.GetNumericValueType(hideProList.HideID);
                            using (zstring.Block())
                            {
                                if (showType == 2)
                                {
                                    attribute = zstring.Format("当前附加 {0}:{1}%\n", proName, (hideProList.HideValue / 100f).ToString("0.##"));
                                }
                                else
                                {
                                    attribute = zstring.Format("当前附加 {0}:{1}\n", proName, hideProList.HideValue);
                                }
                            }
                        }
                    }

                    if (nowItem.BagInfo.HideSkillLists != null)
                    {
                        for (int i = 0; i < nowItem.BagInfo.HideSkillLists.Count; i++)
                        {
                            int skillID = nowItem.BagInfo.HideSkillLists[i];
                            SkillConfig skillCof = SkillConfigCategory.Instance.Get(skillID);
                            using (zstring.Block())
                            {
                                attribute = zstring.Format("当前附加技能:{0}\n", skillCof.SkillName);
                            }
                        }
                    }

                    self.E_NameTextText.text = ItemConfigCategory.Instance.Get(nowItem.BagInfo.ItemID).ItemName;
                }

                self.E_DesTextText.text = attribute;

                BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

                self.ShowBagInfos.Clear();
                List<ItemInfo> bagInfos = bagComponent.GetItemsByLoc(ItemLocType.ItemLocBag);
                for (int i = 0; i < bagInfos.Count; i++)
                {
                    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                    if (bagInfos[i].IfJianDing == false && itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.EquipType == 201)
                    {
                        self.ShowBagInfos.Add(bagInfos[i]);
                    }
                }

                self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
                self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);

                self.E_BagItemsLoopVerticalScrollRect.transform.gameObject.SetActive(true);
                self.ES_CostItem.uiTransform.gameObject.SetActive(false);

                self.E_OpenBtnButton.gameObject.SetActive(false);
                self.E_EquipBtnButton.gameObject.SetActive(true);
            }
        }

        public static void OnSelect(this ES_SeasonJingHe self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(bagInfo);
                }
            }
        }

        public static async ETTask OnOpenBtnButton(this ES_SeasonJingHe self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.OpenJingHeIds.Contains(self.JingHeId))
            {
                FlyTipComponent.Instance.ShowFlyTip("孔位已开启！");
                return;
            }

            if (!SeasonJingHeConfigCategory.Instance.Contain(self.JingHeId))
            {
                FlyTipComponent.Instance.ShowFlyTip("无效孔位！");
                return;
            }

            SeasonJingHeConfig seasonJingHeConfig = SeasonJingHeConfigCategory.Instance.Get(self.JingHeId);
            int costItemId = int.Parse(seasonJingHeConfig.Cost.Split(';')[0]);
            int cosrItemNum = int.Parse(seasonJingHeConfig.Cost.Split(';')[1]);
            long havedNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(costItemId);
            if (havedNum < cosrItemNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("道具数量不足！");
                return;
            }

            M2C_SeasonOpenJingHeResponse response = await BagClientNetHelper.SeasonOpenJingHe(self.Root(), self.JingHeId);

            if (response.Error == ErrorCode.ERR_Success)
            {
                userInfoComponent.UserInfo.OpenJingHeIds.Add(self.JingHeId);
                self.UpdateInfo(self.JingHeId);
            }
        }

        /// <summary>
        /// 卸下晶核
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask OnTakeOffBtnButton(this ES_SeasonJingHe self)
        {
            if (self.JingHeId == 0)
            {
                return;
            }

            ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetJingHeByWeiZhi(self.JingHeId);
            if (bagInfo == null)
            {
                return;
            }

            await BagClientNetHelper.JingHeWear(self.Root(), bagInfo.BagInfoID, 2, self.JingHeId.ToString());
            if (self.InstanceId == 0)
            {
                return;
            }

            self.UpdateInfo(self.JingHeId);
        }

        public static async ETTask OnEquipBtnButton(this ES_SeasonJingHe self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (self.BagInfo == null || self.JingHeId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("未选择道具！");
                return;
            }

            //装备晶体（类似于生肖），  客户端根据孔位显示对应的装备 ItemConfig.ItemType == 3 EquipType = 201  ItemSubType2001 +
            await BagClientNetHelper.JingHeWear(self.Root(), self.BagInfo.BagInfoID, 1, self.JingHeId.ToString());
            self.BagInfo = null;
            self.UpdateInfo(self.JingHeId);
        }
    }
}
