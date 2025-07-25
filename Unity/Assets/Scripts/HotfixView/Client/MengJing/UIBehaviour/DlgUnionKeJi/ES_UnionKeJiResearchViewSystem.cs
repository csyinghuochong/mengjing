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

            self.InitItemList();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionKeJiResearch self)
        {
            self.DestroyWidget();
        }

        private static void InitItemList(this ES_UnionKeJiResearch self)
        {
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
            
            self.UpdataProgressBar().Coroutine();
        }

        public static void UpdateInfo(this ES_UnionKeJiResearch self, int position)
        {
            self.Position = position;

            for (int i = 0; i < self.Items.Count; i++)
            {
                ES_UnionKeJiResearchItem item = self.Items[i];
                item.Refresh();
                if (position == item.Position)
                {
                    self.E_ImageSelectImage.transform.SetParent(item.EG_SelectRectTransform);
                    self.E_ImageSelectImage.transform.localPosition = Vector3.zero;
                    self.E_ImageSelectImage.gameObject.SetActive(true);
                }
            }

            UnionKeJiConfig nowUnionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[position]);

            bool jinxing = self.UnionMyInfo.KeJiActitePos != -1 && self.UnionMyInfo.KeJiActiteTime != 0;
            if (jinxing)
            {
                self.NeedTime = UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[self.UnionMyInfo.KeJiActitePos]).NeedTime;
                // "研究中"
            }
            else
            {
                self.NeedTime = 0;
            }
            self.EG_ProgressRectTransform.gameObject.SetActive(jinxing);
            self.E_UpBtnButton.gameObject.SetActive(!jinxing);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            
            self.E_HeadImgImage.sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, nowUnionKeJiConfig.Icon));
            Match match = Regex.Match(nowUnionKeJiConfig.EquipSpaceName, @"\d");
            self.E_NameTextText.text = nowUnionKeJiConfig.EquipSpaceName.Substring(0, match.Index);
            using (zstring.Block())
            {
                self.E_LvTextText.text = zstring.Format("科技等级：{0}/{1}", nowUnionKeJiConfig.QiangHuaLv.ToString(), UnionKeJiConfigCategory.Instance.UnionQiangHuaList[position].Count);
                // self.E_NeedUnionLvTextText.text = zstring.Format("需要公会等级达到{0}级", unionKeJiConfig.NeedUnionLv);
                
                self.E_NowAttributeTextText.text = ItemViewHelp.GetAttributeDesc(nowUnionKeJiConfig.EquipPropreAdd);
                if (nowUnionKeJiConfig.NextID != 0)
                {
                    UnionKeJiConfig unionKeJiConfig1 = UnionKeJiConfigCategory.Instance.Get(nowUnionKeJiConfig.NextID);
                    self.E_NextAttributeTextText.text = ItemViewHelp.GetAttributeDesc(unionKeJiConfig1.EquipPropreAdd);
                }
                else
                {
                    self.E_NextAttributeTextText.text = "";
                }

                self.E_CostItemIconImage.sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemConfigCategory.Instance.Get(35).Icon));
                self.E_CostUnionGoldTextText.text = zstring.Format("{0}万/{1}万", (nowUnionKeJiConfig.CostUnionGold / 10000f).ToString("0.#"), (self.UnionMyInfo.UnionGold / 10000f).ToString("0.#"));
                // self.E_NeedTimeTextText.text = zstring.Format("研究消耗时间：{0}小时", (unionKeJiConfig.NeedTime / 3600f).ToString("0.##"));
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
                            self.E_ProgressBarTextText.text = zstring.Format("研究剩余时间：{0}时{1}分{2}秒", leftTime / 3600, leftTime % 3600 / 60, leftTime % 3600 % 60);
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

        private static void OnQuickBtnButton(this ES_UnionKeJiResearch self)
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

                        FlyTipComponent.Instance.ShowFlyTip("加速完成");
                        
                        self.UnionMyInfo = response.UnionInfo;
                        self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnionKeJi>().UnionMyInfo = response.UnionInfo;
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
                string tip = "请先激活前置科技:";
                for (int i = 0; i < unionKeJiConfig.PreId.Length; i++)
                {
                    if (i != 0)
                    {
                        tip += "、";
                    }
                    
                    UnionKeJiConfig config = UnionKeJiConfigCategory.Instance.Get(unionKeJiConfig.PreId[i]);
                    tip += config.EquipSpaceName;
                }
                FlyTipComponent.Instance.ShowFlyTip(tip);
                return;
            }

            if (unionKeJiConfig.NextID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经达到满级！");
                return;
            }

            if (self.UnionMyInfo.UnionGold < unionKeJiConfig.CostUnionGold)
            {
                FlyTipComponent.Instance.ShowFlyTip("公会金币不足！");
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
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgUnionKeJi>().UnionMyInfo = response.UnionInfo;
            self.UpdateInfo(self.Position);
        }
    }
}