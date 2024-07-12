using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionKeJiResearchItem))]
    [EntitySystemOf(typeof(ES_UnionKeJiResearch))]
    [FriendOfAttribute(typeof(ES_UnionKeJiResearch))]
    public static partial class ES_UnionKeJiResearchSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionKeJiResearch self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ProgressBarImgImage.fillAmount = 0;
            self.E_QuickBtnButton.AddListener(self.OnQuickBtn);
            self.E_StartBtnButton.AddListenerAsync(self.OnStartBtn);
            self.E_UnionKeJiResearchItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionKeJiResearchItemsRefresh);

            self.InitItemList().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionKeJiResearch self)
        {
            self.DestroyWidget();
        }

        private static void OnUnionKeJiResearchItemsRefresh(this ES_UnionKeJiResearch self, Transform transform, int index)
        {
            Scroll_Item_UnionKeJiResearchItem scrollItemUnionKeJiResearchItem = self.ScrollItemUnionKeJiResearchItems[index].BindTrans(transform);
            scrollItemUnionKeJiResearchItem.UpdateInfo(index, self.UnionMyInfo.UnionKeJiList[index]);
            scrollItemUnionKeJiResearchItem.ClickAction = self.UpdateInfo;
        }

        public static async ETTask InitItemList(this ES_UnionKeJiResearch self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = unit.GetUnionId();

            U2C_UnionMyInfoResponse respose = await UnionNetHelper.UnionMyInfo(self.Root(), unionId);

            self.UnionMyInfo = respose.UnionMyInfo;

            self.AddUIScrollItems(ref self.ScrollItemUnionKeJiResearchItems, self.UnionMyInfo.UnionKeJiList.Count);
            self.E_UnionKeJiResearchItemsLoopVerticalScrollRect.SetVisible(true, self.UnionMyInfo.UnionKeJiList.Count);

            self.UpdateInfo(0);
            self.UpdataProgressBar().Coroutine();
        }

        public static void UpdateInfo(this ES_UnionKeJiResearch self, int position)
        {
            self.Position = position;

            if (self.ScrollItemUnionKeJiResearchItems != null)
            {
                for (int i = 0; i < self.ScrollItemUnionKeJiResearchItems.Count; i++)
                {
                    Scroll_Item_UnionKeJiResearchItem item = self.ScrollItemUnionKeJiResearchItems[i];
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.UpdateInfo(i, self.UnionMyInfo.UnionKeJiList[i]);
                    GameObject highlightImg = item.E_HighlightImgImage.gameObject;
                    highlightImg.SetActive(item.Position == position);
                    if (item.Position == position)
                    {
                        self.E_HeadImgImage.sprite = item.E_IconImgImage.sprite;
                    }
                }
            }

            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[position]);

            if (self.UnionMyInfo.KeJiActitePos != -1)
            {
                self.NeedTime = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[self.UnionMyInfo.KeJiActitePos]).NeedTime;

                if (self.ScrollItemUnionKeJiResearchItems != null)
                {
                    for (int i = 0; i < self.ScrollItemUnionKeJiResearchItems.Count; i++)
                    {
                        Scroll_Item_UnionKeJiResearchItem item = self.ScrollItemUnionKeJiResearchItems[i];

                        if (item.uiTransform == null)
                        {
                            continue;
                        }

                        if (item.Position != self.UnionMyInfo.KeJiActitePos)
                        {
                            continue;
                        }

                        item.E_LvTextText.text = "研究中";
                        break;
                    }
                }
            }
            else
            {
                self.NeedTime = 0;
            }

            Match match = Regex.Match(unionKeJiConfig.EquipSpaceName, @"\d");
            self.E_NameTextText.text = unionKeJiConfig.EquipSpaceName.Substring(0, match.Index);
            self.E_LvTextText.text = $"等级：{unionKeJiConfig.QiangHuaLv.ToString()}";
            self.E_NeedUnionLvTextText.text = $"需要家族等级达到{unionKeJiConfig.NeedUnionLv}级";
            if (unionKeJiConfig.QiangHuaLv == 0)
            {
                UnionKeJiConfig unionKeJiConfig1 = UnionKeJiConfigCategory.Instance.Get(unionKeJiConfig.NextID);
                self.E_AttributeTextText.text = "下一级：" + ItemViewHelp.GetAttributeDesc(unionKeJiConfig1.EquipPropreAdd);
            }
            else
            {
                self.E_AttributeTextText.text = ItemViewHelp.GetAttributeDesc(unionKeJiConfig.EquipPropreAdd);
            }

            self.ES_CommonItem.UpdateItem(new() { ItemID = 35, ItemNum = unionKeJiConfig.CostUnionGold }, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.E_CostUnionGoldTextText.text = $"消耗家族金币：{unionKeJiConfig.CostUnionGold / 10000f:0.#}万/{self.UnionMyInfo.UnionGold / 10000f:0.#}万";
            self.E_NeedTimeTextText.text = $"研究消耗时间：{unionKeJiConfig.NeedTime / 3600f:0.##}小时";
        }

        public static async ETTask UpdataProgressBar(this ES_UnionKeJiResearch self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                if (self.NeedTime == 0)
                {
                    self.E_ProgressBarImgImage.fillAmount = 0;
                    self.E_UnderwayTextText.text = string.Empty;
                }
                else
                {
                    long timeNow = TimeHelper.ServerNow();
                    long passTime = (timeNow - self.UnionMyInfo.KeJiActiteTime) / 1000;
                    if (passTime < self.NeedTime)
                    {
                        self.E_ProgressBarImgImage.fillAmount = passTime * 1f / self.NeedTime;
                        long leftTime = self.NeedTime - passTime;
                        self.E_UnderwayTextText.text = $"{leftTime / 3600}时{leftTime % 3600 / 60}分{leftTime % 3600 % 60}秒";
                    }
                    else
                    {
                        self.E_ProgressBarImgImage.fillAmount = 0;
                        self.E_UnderwayTextText.text = string.Empty;
                    }
                }

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }

        public static void OnQuickBtn(this ES_UnionKeJiResearch self)
        {
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[self.Position]);
            if (self.UnionMyInfo.KeJiActiteTime == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("没有正在研究的科技！");
                return;
            }

            if (unionKeJiConfig.NextID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("已经达到满级！");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem("3;200"))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("钻石数量不足！");
                return;
            }

            PopupTipHelp.OpenPopupTip(self.Root(), "加速科技",
                $"是否花费{UnionHelper.CalcuNeedeForAccele(self.UnionMyInfo.KeJiActiteTime, unionKeJiConfig.NeedTime)}钻石加速科技", async () =>
                {
                    Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                    long unionId = unit.GetUnionId();

                    U2C_UnionKeJiQuickResponse response = await UnionNetHelper.UnionKeJiQuickRequest(self.Root(), unionId, self.Position);

                    if (response.Error != ErrorCode.ERR_Success)
                    {
                        return;
                    }

                    self.UnionMyInfo = response.UnionInfo;
                    self.UpdateInfo(self.Position);
                }, () => { }).Coroutine();
        }

        public static async ETTask OnStartBtn(this ES_UnionKeJiResearch self)
        {
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[self.Position]);

            long timeNow = TimeHelper.ServerNow();
            long passTime = (timeNow - self.UnionMyInfo.KeJiActiteTime) / 1000;
            if (passTime < unionKeJiConfig.NeedTime)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("有科技正在研究中！");
                return;
            }

            if (unionKeJiConfig.NextID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("已经达到满级！");
                return;
            }

            if (self.UnionMyInfo.UnionGold < unionKeJiConfig.CostUnionGold)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("家族金币不足！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = unit.GetUnionId();

            U2C_UnionKeJiActiteResponse response = await UnionNetHelper.UnionKeJiActiteRequest(self.Root(), unionId, self.Position);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.UnionMyInfo = response.UnionInfo;
            self.UpdateInfo(self.Position);
        }
    }
}