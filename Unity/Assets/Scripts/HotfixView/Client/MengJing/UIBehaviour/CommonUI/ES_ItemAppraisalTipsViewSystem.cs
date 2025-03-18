using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(ES_ItemAppraisalTips))]
    [FriendOfAttribute(typeof(ES_ItemAppraisalTips))]
    public static partial class ES_ItemAppraisalTipsSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ItemAppraisalTips self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SellButton.AddListenerAsync(self.OnSellButton);
            self.E_UseButton.AddListenerAsync(self.OnUseButton);
            self.E_HuiShouButton.AddListenerAsync(self.OnHuiShouButton);
            self.E_HuiShouCancleButton.AddListenerAsync(self.OnHuiShouCancleButton);
            self.E_JingHeAddQualityButton.AddListenerAsync(self.OnJingHeAddQualityButton);
            self.E_JingHeActivateButton.AddListenerAsync(self.OnJingHeActivateButton);
            self.E_SaveStoreHouseButton.AddListenerAsync(self.OnSaveStoreHouseButton);
            self.E_TakeStoreHouseButton.AddListenerAsync(self.OnTakeStoreHouseButton);
            self.E_XieXiaGemButton.AddListener(self.OnXieXiaGemButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_ItemAppraisalTips self)
        {
            self.DestroyWidget();
        }

        public static void RefreshInfo(this ES_ItemAppraisalTips self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum, int currentHouse)
        {
            using (zstring.Block())
            {
                self.BagInfo = bagInfo;
                self.ItemOpetateType = itemOperateEnum;
                self.CurrentHouse = currentHouse;
                ItemConfig itemconf = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                int itemType = itemconf.ItemType;
                int itemSubType = itemconf.ItemSubType;

                ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

                string qualityiconLine = FunctionUI.ItemQualityLine(itemconf.ItemQuality);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconLine);
                Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
                self.E_QualityLineImage.sprite = sp;

                string qualityiconBack = FunctionUI.ItemQualityBack(itemconf.ItemQuality);
                string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconBack);
                Sprite sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);
                self.E_QualityBgImage.sprite = sp1;

                //类型描述
                string itemTypename = "消耗品";
                ItemViewData.ItemTypeName.TryGetValue(itemType, out itemTypename);

                self.E_ItemTypeText.text = zstring.Format("类型:{0}", itemTypename);

                if (itemconf.ItemEquipID != 0 && itemconf.EquipType != 201)
                {
                    int appraisalItem = EquipConfigCategory.Instance.Get(itemconf.ItemEquipID).AppraisalItem;
                    if (appraisalItem != 0)
                    {
                        string tip_1 = itemconf.EquipType == 101 ? "封印生肖" : "进行鉴定";
                        string jiandingName = ItemConfigCategory.Instance.Get(appraisalItem).ItemName;

                        self.E_ItemCostDesText.text = zstring.Format("消耗<color=#EA8EF9>{0}</color>{1}", jiandingName, tip_1);
                    }
                }

                if (!string.IsNullOrEmpty(bagInfo.MakePlayer))
                {
                    self.E_ItemMakeText.gameObject.SetActive(true);

                    self.E_ItemMakeText.text = zstring.Format("此装备由<color=#805100>{0}</color>打造", self.BagInfo.MakePlayer);
                }
                else
                {
                    self.E_ItemMakeText.text = "";
                    self.E_ItemMakeText.gameObject.SetActive(false);
                }

                string equipType = "";
                if (itemType == 3)
                {
                    //获取类型显示
                    string textEquipType = ItemViewHelp.GetEquipSonType(itemconf.ItemSubType.ToString());
                    string textEquipSonType = ItemViewHelp.GetEquipTypeShow(itemconf.EquipType);

                    //121211 <color=#AFFF06>颜色</color>

                    if (textEquipSonType != "")
                    {
                        equipType = zstring.Format("<color=#AFFF06>    类型:{0}</color>", textEquipSonType);
                    }
                    
                    self.E_ItemTypeText.text = zstring.Format("部位:{0}", textEquipType);
                }

                string Text_ItemDes = itemconf.ItemDes;
                //获取道具描述的分隔符
                string[] itemDesArray = Text_ItemDes.Split(';');
                string itemMiaoShu = "";

                for (int i = 0; i <= itemDesArray.Length - 1; i++)
                {
                    if (itemMiaoShu == "")
                    {
                        itemMiaoShu = itemDesArray[i];
                    }
                    else
                    {
                        itemMiaoShu = zstring.Format("{0}\n{1}", itemMiaoShu, itemDesArray[i]);
                    }
                }

                //数组大于2表示有换行符,否则显示原来的描述
                if (itemDesArray.Length >= 2)
                {
                    Text_ItemDes = itemMiaoShu;
                }

                //根据Tips描述长度缩放底的大小
                Text_ItemDes = ItemViewHelp.GetItemDesc(bagInfo);
                //赞助宝箱设置描述为绿色
                if (itemSubType == 9)
                {
                    //self.ItemDes.GetComponent<Text>().color = Color.green;
                }

                //显示是否绑定
                if (bagInfo.isBinging)
                {
                    self.E_BangDingText.text = LanguageComponent.Instance.LoadLocalization("已绑定");
                    self.E_BangDingText.color = new Color(175f / 255f, 1, 6f / 255f);
                    self.E_BangDingImage.gameObject.SetActive(true);
                }
                else
                {
                    self.E_BangDingText.text = LanguageComponent.Instance.LoadLocalization("未绑定");
                    self.E_BangDingText.color = new Color(255f / 255f, 240f / 255f, 200f / 255f);
                    self.E_BangDingImage.gameObject.SetActive(false);
                }

                //显示图标
                //显示道具Icon
                string ItemIcon = itemconf.Icon;
                string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemIcon);
                Sprite sp2 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path2);

                self.E_ItemIconImage.sprite = sp2;

                // 显示封印
                self.E_FengYinImage.gameObject.SetActive(itemconf.EquipType == 101);
                CommonViewHelper.SetImageGray(self.Root(), self.E_ItemIconImage.gameObject, true);

                self.E_ItemDesText.text = itemconf.EquipType == 101 ? "封印生肖" : "未鉴定装备";
                // 赛季晶核
                if (itemType == 3 && itemconf.EquipType == 201)
                {
                    self.E_ItemDesText.gameObject.SetActive(false);
                    self.E_ItemJingHeQualityText.gameObject.SetActive(true);
                    int qua = 1;
                    int nowQua = int.Parse(bagInfo.ItemPar);
                    qua = (int)(nowQua / 20) + 1;
                    if (qua >= 5)
                    {
                        qua = 5;
                    }

                    string colorValue = ItemViewHelp.QualityReturnColorUI(qua);

                    self.E_ItemJingHeQualityText.text = zstring.Format("当前品质:{0}", bagInfo.ItemPar);

                    //self.Lab_ItemJingHeQuality.AddComponent<Outline>();
                    // 属性显示itemConfig.ItemUsePar
                    string attribute = "";
                    string[] parmainfos = itemconf.ItemUsePar.Split('@');
                    string[] attriinfos = parmainfos[1].Split(';');
                    int addType = int.Parse(attriinfos[0]);
                    if (addType == 1)
                    {
                        string[] hidevalueinfo = attriinfos[1].Split(',');
                        int hideid = int.Parse(hidevalueinfo[0]);
                        string proName = ItemViewHelp.GetAttributeName(hideid);
                        int showType = NumericHelp.GetNumericValueType(hideid);
                        if (showType == 2)
                        {
                            float hidevaluemin = float.Parse(hidevalueinfo[1]);
                            float hidevaluemax = float.Parse(hidevalueinfo[2]);

                            (hidevaluemin, hidevaluemax) = ItemHelper.GetJingHeHideProRange(hidevaluemin, hidevaluemax, nowQua);

                            attribute = zstring.Format("{0}:{1}~{2}%\n", proName, (hidevaluemin * 100).ToString("0.##"),
                                (hidevaluemax * 100).ToString("0.##"));
                        }
                        else
                        {
                            int hidevaluemin = int.Parse(hidevalueinfo[1]);
                            int hidevaluemax = int.Parse(hidevalueinfo[2]);
                            (hidevaluemin, hidevaluemax) = ItemHelper.GetJingHeHideProRange(hidevaluemin, hidevaluemax, nowQua);
                            attribute = zstring.Format("{0}:{1}~{2}", proName, hidevaluemin, hidevaluemax);
                        }
                    }
                    // else if (addType == 2)
                    // {
                    //     string[] hidevalueinfo = attriinfos[1].Split(',');
                    //     int hideid = int.Parse(hidevalueinfo[0]);
                    //     SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideid);
                    //     string skillName = skillConfig.SkillName;
                    //     attribute = $"当前附加 {skillName}:"+"\n";
                    // }

                    self.E_ItemJingHePropertyText.text = attribute;
                }

                self.E_UseButton.transform.Find("Text").GetComponent<Text>().text = itemconf.EquipType == 101 ? "开启封印" : "鉴定";

                string ItemQuality = FunctionUI.ItemQualiytoPath(itemconf.ItemQuality);
                string path3 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality);
                Sprite sp3 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path3);

                self.E_ItemQualityImage.sprite = sp3;

                string Text_ItemStory = itemconf.ItemDes;
                //显示道具描述
                int i2 = (int)((Text_ItemStory.Length) / 20) + 1;
                //float ItemBottomTextNum = 30.0f;

                self.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
                self.E_SaveStoreHouseButton.gameObject.SetActive(false);
                self.E_TakeStoreHouseButton.gameObject.SetActive(false);
                self.E_HuiShouButton.gameObject.SetActive(false);
                self.E_HuiShouCancleButton.gameObject.SetActive(false);
                self.E_JingHeAddQualityButton.gameObject.SetActive(false);
                self.E_JingHeActivateButton.gameObject.SetActive(false);
                self.E_XieXiaGemButton.gameObject.SetActive(false);

                //显示按钮
                switch ((ItemOperateEnum)itemOperateEnum)
                {
                    //不显示任何按钮
                    case ItemOperateEnum.None:
                    case ItemOperateEnum.PaiMaiSell:
                    case ItemOperateEnum.PaiMaiBuy:
                        //ItemBottomTextNum = 0;
                        break;
                    //背包打开显示对应功能按钮
                    case ItemOperateEnum.Bag:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                        self.E_TakeStoreHouseButton.gameObject.SetActive(false);
                        //判定当前是否打开仓库
                        bool openHouse = false;
                        if (openHouse)
                        {
                            self.E_SaveStoreHouseButton.gameObject.SetActive(true);
                            self.E_SellButton.gameObject.SetActive(false);
                        }
                        else
                        {
                            self.E_SaveStoreHouseButton.gameObject.SetActive(false);
                            self.E_SellButton.gameObject.SetActive(true);
                        }

                        // 赛季晶核
                        if (itemType == 3 && itemconf.EquipType == 201)
                        {
                            self.E_UseButton.gameObject.SetActive(false);
                            self.E_SellButton.gameObject.SetActive(false);
                            self.E_JingHeAddQualityButton.gameObject.SetActive(true);
                            self.E_JingHeActivateButton.gameObject.SetActive(true);
                        }

                        break;
                    //角色栏打开显示对应功能按钮
                    case ItemOperateEnum.Juese:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                        self.E_TakeStoreHouseButton.gameObject.SetActive(false);
                        break;
                    //商店查看属性
                    case ItemOperateEnum.Shop:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
                        //self.Obj_Btn_StoreHouseSet.SetActive(false);
                        //ItemBottomTextNum = 0;
                        break;
                    //仓库查看属性
                    case ItemOperateEnum.Cangku:
                    case ItemOperateEnum.AccountCangku:
                    case ItemOperateEnum.GemCangku:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
                        self.E_TakeStoreHouseButton.gameObject.SetActive(true);
                        //self.Obj_Btn_StoreHouseSet.SetActive(true);
                        //ItemBottomTextNum = 0;
                        break;
                    case ItemOperateEnum.CangkuBag:
                    case ItemOperateEnum.AccountBag:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                        self.E_SaveStoreHouseButton.gameObject.SetActive(true);
                        self.E_SellButton.gameObject.SetActive(false);
                        self.E_UseButton.gameObject.SetActive(false);
                        break;
                    //回收背包打开
                    case ItemOperateEnum.HuishouBag:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                        //self.Obj_Btn_StoreHouseSet.SetActive(false);
                        self.E_SaveStoreHouseButton.gameObject.SetActive(false);
                        self.E_HuiShouButton.gameObject.SetActive(true);
                        self.E_SellButton.gameObject.SetActive(false);
                        self.E_UseButton.gameObject.SetActive(false);
                        break;
                    //回收功能显示
                    case ItemOperateEnum.HuishouShow:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
                        //self.Obj_Btn_StoreHouseSet.SetActive(false);
                        self.E_HuiShouCancleButton.gameObject.SetActive(true);
                        self.E_SaveStoreHouseButton.gameObject.SetActive(false);
                        break;
                    //牧场  不显示任何按钮
                    case ItemOperateEnum.Muchang:
                        //ItemBottomTextNum = 0;
                        break;
                    //牧场仓库  显示出售按钮
                    case ItemOperateEnum.MuchangCangku:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                        //self.Obj_Btn_StoreHouseSet.SetActive(false);
                        self.E_SaveStoreHouseButton.gameObject.SetActive(false);
                        self.E_SellButton.gameObject.SetActive(true);
                        break;
                    default:
                        //ItemBottomTextNum = 0;
                        break;
                }

                //判定道具为宝石时显示使用变为镶嵌字样
                /*
                if (itemType == 4)
                {
                    string langStr_A = GameSettingLanguge.LoadLocalization("镶 嵌");
                    self.Obj_Btn_GemHoleText.GetComponent<Text>().text = langStr_A;
                }
                */
                //设置底的长度
                //self.ItemDi.GetComponent<RectTransform>().sizeDelta = new Vector2(301.0f, 180.0f + i1 * 20.0f + i2 * 16.0f + ItemBottomTextNum);

                //显示道具信息
                self.E_ItemNameText.text = itemconf.ItemName;
                self.E_ItemSubTypeText.text = equipType;
                self.E_ItemNameText.color = FunctionUI.QualityReturnColor(itemconf.ItemQuality);
                float exceedWidth = self.E_ItemNameText.preferredWidth - self.E_ItemNameText.transform.GetComponent<RectTransform>().sizeDelta.x;
                if (exceedWidth > -20)
                {
                    Vector2 vector2 = self.E_BackImage.GetComponent<RectTransform>().sizeDelta;
                    self.E_BackImage.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(vector2.x + exceedWidth + 30, vector2.y);
                }

                self.ExceedWidth = exceedWidth;

                string langStr = LanguageComponent.Instance.LoadLocalization("等级");
                if (itemconf.UseLv > 0)
                {
                    self.E_ItemLvText.text = zstring.Format("{0}:{1}", langStr, itemconf.UseLv);

                    if (itemconf.UseLv > self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv)
                    {
                        self.E_ItemLvText.text = zstring.Format("{0}:{1}", langStr, itemconf.UseLv);
                        //self.ItemItemLv.GetComponent<Text>().text = langStr + " : " + itemconf.UseLv + " (等级不足)";
                        self.E_ItemLvText.color = new Color(255f / 255f, 200f / 255f, 200f / 255f);
                    }
                }
                else
                {
                    self.E_ItemLvText.text = zstring.Format("{0}:1", langStr);
                }
            }
        }

        private static async ETTask OnSellButton(this ES_ItemAppraisalTips self)
        {
            //发送消息
            if (ItemConfigCategory.Instance.Get(self.BagInfo.ItemID).ItemQuality >= 4)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "出售道具", zstring.Format("是否出售道具:{0}", itemConfig.ItemName), () =>
                    {
                        BagClientNetHelper.RequestSellItem(self.Root(), self.BagInfo, self.BagInfo.ItemNum.ToString()).Coroutine();
                        self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
                    }).Coroutine();
                }
            }
            else
            {
                BagClientNetHelper.RequestSellItem(self.Root(), self.BagInfo, self.BagInfo.ItemNum.ToString()).Coroutine();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            }

            await ETTask.CompletedTask;
        }

        private static async ETTask OnUseButton(this ES_ItemAppraisalTips self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            if (itemConfig.EquipType == 101)
            {
                int appraisalItem = EquipConfigCategory.Instance.Get(itemConfig.ItemEquipID).AppraisalItem;

                BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
                ItemInfo costbaginfo = bagComponentC.GetBagInfoByConfigId(appraisalItem);
                if (costbaginfo == null)
                {
                    self.Root().GetComponent<FlyTipComponent>().ShowFlyTip("道具不足！");
                    return;
                }

                string costitem = ItemConfigCategory.Instance.Get(appraisalItem).ItemName;
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "开启封印", zstring.Format("是否消耗{0}开启封印?", costitem), () =>
                    {
                        BagClientNetHelper.RequestAppraisalItem(self.Root(), self.BagInfo, costbaginfo.BagInfoID).Coroutine();
                        self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
                    }).Coroutine();
                }
            }
            else
            {
                await uiComponent.ShowWindowAsync(WindowID.WindowID_AppraisalSelect);
                uiComponent.GetDlgLogic<DlgAppraisalSelect>().OnInitUI(self.BagInfo);
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            }

            await ETTask.CompletedTask;
        }

        private static async ETTask OnHuiShouButton(this ES_ItemAppraisalTips self)
        {
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("1_{0}", self.BagInfo.BagInfoID) });
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }

        private static async ETTask OnHuiShouCancleButton(this ES_ItemAppraisalTips self)
        {
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("0_{0}", self.BagInfo.BagInfoID) });
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }

        private static async ETTask OnJingHeAddQualityButton(this ES_ItemAppraisalTips self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SeasonJingHeZhuru);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSeasonJingHeZhuru>().InitInfo(self.BagInfo);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }

        private static async ETTask OnJingHeActivateButton(this ES_ItemAppraisalTips self)
        {
            await BagClientNetHelper.JingHeActivate(self.Root(), self.BagInfo.BagInfoID);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }

        private static async ETTask OnSaveStoreHouseButton(this ES_ItemAppraisalTips self)
        {
            if (self.ItemOpetateType == ItemOperateEnum.AccountBag)
            {
                ItemViewHelp.AccountCangkuPutIn(self.Root(), self.BagInfo);
            }
            else
            {
                BagClientNetHelper.RquestPutStoreHouse(self.Root(), self.BagInfo, self.CurrentHouse).Coroutine();
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTakeStoreHouseButton(this ES_ItemAppraisalTips self)
        {
            if (self.ItemOpetateType == ItemOperateEnum.AccountCangku)
            {
                BagClientNetHelper.RequestAccountWarehousOperate(self.Root(), 2, self.BagInfo.BagInfoID).Coroutine();
            }
            else
            {
                BagClientNetHelper.RquestPutBag(self.Root(), self.BagInfo).Coroutine();
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }
        public static void OnXieXiaGemButton(this ES_ItemAppraisalTips self)
        {
        }
    }
}
