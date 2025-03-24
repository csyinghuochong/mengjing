using System.Text.RegularExpressions;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_UnionKeJiResearchItem))]
    [FriendOf(typeof(Scroll_Item_UnionKeJiResearchItem))]
    [EntitySystemOf(typeof(ES_UnionKeJiResearch))]
    [FriendOfAttribute(typeof(ES_UnionKeJiResearch))]
    public static partial class ES_UnionKeJiResearchSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionKeJiResearch self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ImageSelectImage.gameObject.SetActive(false);
            self.E_ProgressBarImgImage.fillAmount = 0;
            self.E_QuickBtnButton.AddListener(self.OnQuickBtnButton);
            self.E_UpBtnButton.AddListenerAsync(self.OnUpBtnButton);

            self.InitItemList().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionKeJiResearch self)
        {
            self.DestroyWidget();
        }

        public static async ETTask InitItemList(this ES_UnionKeJiResearch self)
        {
            U2C_UnionMyInfoResponse respose = await UnionNetHelper.UnionMyInfo(self.Root());

            self.UnionMyInfo = respose.UnionMyInfo;

            if (self.Items.Count == 0)
            {
                for (int i = 0; i < self.EG_ContentRectTransform.childCount; i++)
                {
                    Transform subTrans = self.EG_ContentRectTransform.GetChild(i);
                    ES_UnionKeJiResearchItem item = self.AddChild<ES_UnionKeJiResearchItem, Transform>(subTrans);
                    item.Init(i);
                    self.Items.Add(item);
                }
            }

            foreach (ES_UnionKeJiResearchItem item in self.Items)
            {
                item.Refresh();
            }

            self.UpdateInfo(0);
            self.UpdataProgressBar().Coroutine();
        }

        public static void UpdateInfo(this ES_UnionKeJiResearch self, int position)
        {
            self.Position = position;

            for (int i = 0; i < self.Items.Count; i++)
            {
                ES_UnionKeJiResearchItem item = self.Items[i];
                if (position == item.Position)
                {
                    self.E_ImageSelectImage.transform.SetParent(item.uiTransform);
                    self.E_ImageSelectImage.transform.localPosition = Vector3.zero;
                    self.E_ImageSelectImage.gameObject.SetActive(true);
                }
            }

            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[position]);

            if (self.UnionMyInfo.KeJiActitePos != -1)
            {
                self.NeedTime = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[self.UnionMyInfo.KeJiActitePos]).NeedTime;
                // "研究中"
            }
            else
            {
                self.NeedTime = 0;
            }
            self.EG_ProgressRectTransform.gameObject.SetActive(self.UnionMyInfo.KeJiActitePos == position);
            self.E_UpBtnButton.gameObject.SetActive(self.UnionMyInfo.KeJiActitePos != position);

            Match match = Regex.Match(unionKeJiConfig.EquipSpaceName, @"\d");
            self.E_NameTextText.text = unionKeJiConfig.EquipSpaceName.Substring(0, match.Index);
            using (zstring.Block())
            {
                self.E_LvTextText.text = zstring.Format("等级：{0}", unionKeJiConfig.QiangHuaLv.ToString());
                self.E_NeedUnionLvTextText.text = zstring.Format("需要家族等级达到{0}级", unionKeJiConfig.NeedUnionLv);
                if (unionKeJiConfig.QiangHuaLv == 0)
                {
                    UnionKeJiConfig unionKeJiConfig1 = UnionKeJiConfigCategory.Instance.Get(unionKeJiConfig.NextID);
                    self.E_AttributeTextText.text = zstring.Format("下一级：{0}", ItemViewHelp.GetAttributeDesc(unionKeJiConfig1.EquipPropreAdd));
                }
                else
                {
                    self.E_AttributeTextText.text = ItemViewHelp.GetAttributeDesc(unionKeJiConfig.EquipPropreAdd);
                }

                self.ES_CommonItem.UpdateItem(new() { ItemID = 35, ItemNum = unionKeJiConfig.CostUnionGold }, ItemOperateEnum.None);
                self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
                self.E_CostUnionGoldTextText.text = zstring.Format("消耗家族金币：{0}万/{1}万", (unionKeJiConfig.CostUnionGold / 10000f).ToString("0.#"),
                    (self.UnionMyInfo.UnionGold / 10000f).ToString("0.#"));
                self.E_NeedTimeTextText.text = zstring.Format("研究消耗时间：{0}小时", (unionKeJiConfig.NeedTime / 3600f).ToString("0.##"));
            }
        }

        private static async ETTask UpdataProgressBar(this ES_UnionKeJiResearch self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                if (self.NeedTime == 0)
                {
                    self.E_ProgressBarImgImage.fillAmount = 0;
                    self.E_ProgressBarTextText.text = string.Empty;
                }
                else
                {
                    long timeNow = TimeHelper.ServerNow();
                    long passTime = (timeNow - self.UnionMyInfo.KeJiActiteTime) / 1000;
                    if (passTime < self.NeedTime)
                    {
                        self.E_ProgressBarImgImage.fillAmount = passTime * 1f / self.NeedTime;
                        long leftTime = self.NeedTime - passTime;
                        using (zstring.Block())
                        {
                            self.E_ProgressBarTextText.text = zstring.Format("研究剩余时间{0}时{1}分{2}秒", leftTime / 3600, leftTime % 3600 / 60, leftTime % 3600 % 60);
                        }
                    }
                    else
                    {
                        self.E_ProgressBarImgImage.fillAmount = 0;
                        self.E_ProgressBarTextText.text = string.Empty;
                    }
                }

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }

        public static void OnQuickBtnButton(this ES_UnionKeJiResearch self)
        {
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[self.Position]);
            if (self.UnionMyInfo.KeJiActiteTime == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("没有正在研究的科技！");
                return;
            }

            if (unionKeJiConfig.NextID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经达到满级！");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem("3;200"))
            {
                FlyTipComponent.Instance.ShowFlyTip("钻石数量不足！");
                return;
            }

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "加速科技",
                    zstring.Format("是否花费{0}钻石加速科技", UnionHelper.CalcuNeedeForAccele(self.UnionMyInfo.KeJiActiteTime, unionKeJiConfig.NeedTime)),
                    async () =>
                    {
                        Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                        long unionId = unit.GetUnionId();

                        M2C_UnionKeJiQuickResponse response = await UnionNetHelper.UnionKeJiQuickRequest(self.Root(), unionId, self.Position);

                        if (response.Error != ErrorCode.ERR_Success)
                        {
                            return;
                        }

                        self.UnionMyInfo = response.UnionInfo;
                        self.UpdateInfo(self.Position);
                    }, () => { }).Coroutine();
            }
        }

        private static async ETTask OnUpBtnButton(this ES_UnionKeJiResearch self)
        {
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[self.Position]);

            long timeNow = TimeHelper.ServerNow();
            long passTime = (timeNow - self.UnionMyInfo.KeJiActiteTime) / 1000;
            if (passTime < unionKeJiConfig.NeedTime)
            {
                FlyTipComponent.Instance.ShowFlyTip("有科技正在研究中！");
                return;
            }

            bool havePre = false;
            for (int i = 0; i < unionKeJiConfig.PreId.Length; i++)
            {
                if (UnionKeJiConfigCategory.Instance.HavePreId(unionKeJiConfig.PreId[i], self.UnionMyInfo.UnionKeJiList))
                {
                    havePre = true;
                    break;
                }
            }
            if (!havePre)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先激活前置科技！");
                return;
            }

            if (unionKeJiConfig.NextID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经达到满级！");
                return;
            }

            if (self.UnionMyInfo.UnionGold < unionKeJiConfig.CostUnionGold)
            {
                FlyTipComponent.Instance.ShowFlyTip("家族金币不足！");
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