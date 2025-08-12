using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_RoleGem))]
    [FriendOf(typeof(DlgItemTipsViewComponent))]
    [FriendOf(typeof(DlgItemTips))]
    public static class DlgItemTipsSystem
    {
        public static void RegisterUIEvent(this DlgItemTips self)
        {
            self.View.E_BGButton.AddListener(self.OnBGButton);
            self.View.E_SellButton.AddListenerAsync(self.OnSellButton);
            self.View.E_UseButton.AddListenerAsync(self.OnUseButton);
            self.View.E_SplitButton.AddListenerAsync(self.OnSplitButton);
            self.View.E_PlanButton.AddListener(self.OnPlanButton);
            self.View.E_StoreHouseButton.AddListener(self.OnStoreHouseButton);
            self.View.E_HuiShouButton.AddListener(self.OnHuiShouButton);
            self.View.E_HuiShouCancleButton.AddListener(self.OnHuiShouCancleButton);
            self.View.E_XieXiaGemButton.AddListener(self.OnXieXiaGemButton);
            self.View.E_PutBagButton.AddListener(self.OnPutBagButton);
            
            self.Img_backVector2 = self.View.E_BackImage.GetComponent<RectTransform>().sizeDelta;
            self.Lab_ItemNameWidth = self.View.E_ItemNameText.GetComponent<RectTransform>().sizeDelta.x;
        }

        public static void ShowWindow(this DlgItemTips self, Entity contextData = null)
        {
        }

        public static void OnBGButton(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        public static void SetPosition(this DlgItemTips self, Vector2 vector2)
        {
            self.View.uiTransform.GetComponent<RectTransform>().anchoredPosition = vector2;
        }

        public static void  RefreshInfo(this DlgItemTips self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum, int currentHouse)
        {
            self.BagInfo = bagInfo;
            self.ItemOperateEnum = itemOperateEnum;
            self.CurrentHouse = currentHouse;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int itemType = itemConfig.ItemType;
            int itemSubType = itemConfig.ItemSubType;

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string qualityiconLine = FunctionUI.ItemQualityLine(itemConfig.ItemQuality);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconLine);
            Sprite sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.View.E_QualityLineImage.sprite = sprite;

            string qualityiconBack = FunctionUI.ItemQualityBack(itemConfig.ItemQuality);
            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconBack);
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.View.E_QulityBgImage.sprite = sprite;

            // 类型描述
            string itemTypename = "消耗品";
            ItemViewData.ItemTypeName.TryGetValue(itemType, out itemTypename);
            if (itemType == 1 && itemSubType == 131)
            {
                itemTypename = "家园烹饪";
            }

            using (zstring.Block())
            {
                self.View.E_ItemTypeText.text = zstring.Format("类型:{0}", itemTypename);
            }

            //显示是否绑定
            if (bagInfo.isBinging)
            {
                self.View.E_BangDingText.text = LanguageComponent.Instance.LoadLocalization("已绑定");
                self.View.E_BangDingText.color = new Color(175f / 255f, 1, 6f / 255f);
                self.View.E_BindingImage.gameObject.SetActive(true);
            }
            else
            {
                self.View.E_BangDingText.GetComponent<Text>().text = LanguageComponent.Instance.LoadLocalization("未绑定");
                self.View.E_BangDingText.GetComponent<Text>().color = new Color(255f / 255f, 240f / 255f, 200f / 255f);
                self.View.E_BindingImage.gameObject.SetActive(false);
            }

            // 道具Icon
            string ItemIcon = itemConfig.Icon;
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemIcon));
            self.View.E_ItemIconImage.sprite = sprite;
            string ItemQuality = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality));
            self.View.E_ItemQualityImage.sprite = sprite;

            // 宠物蛋附灵
            if (itemType == 1 && itemSubType == 102 && self.BagInfo.FuLing == 1)
            {
                self.View.E_FuLingText.gameObject.SetActive(true);
                self.View.E_FuLingDesText.gameObject.SetActive(true);
            }

            //显示道具信息
            self.View.E_ItemNameText.text = itemConfig.ItemName;
            self.View.E_ItemNameText.color = FunctionUI.QualityReturnColor(itemConfig.ItemQuality);

            string itemDes = ItemViewHelp.GetItemDesc(bagInfo).Replace("\\n", "\n");
            self.View.E_ItemDesText.text = itemDes;

            //Dictionary<int, ItemConfig> allitems = ItemConfigCategory.Instance.GetAll();
            //string itemDes = string.Empty;
            //foreach (var item in allitems)
            //{
            //    if (item.Value.Id > 1800404)
            //    {
            //        break;
            //    }
            //    bagInfo.ItemID = item.Value.Id;
            //    itemDes = ItemViewHelp.GetItemDesc(bagInfo).Replace("\\n", "\n");
            //    self.View.E_ItemDesText.text = itemDes;

            //    bool checkpunctuation = PunctuationCheckHelper.DetectMiddleWhitespace(self.View.E_ItemDesText);
            //    if (checkpunctuation)
            //    {
            //        Debug.LogWarning($"{bagInfo.ItemID}");
            //    }
            //    await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            //}

            float exceedWidth = self.View.E_ItemNameText.preferredWidth - self.Lab_ItemNameWidth;
            if (exceedWidth > -20)
            {
                self.View.E_PutBagImage.GetComponent<RectTransform>().sizeDelta =
                        new Vector2(self.Img_backVector2.x + exceedWidth + 30, self.Img_backVector2.y);
            }

            //鉴定品质符
            if (itemConfig.ItemSubType == 121)
            {
                using (zstring.Block())
                {
                    string itempar = string.IsNullOrEmpty(bagInfo.ItemPar) ? " " : $"鉴定符品质:{bagInfo.ItemPar}"; 
                    self.View.E_ItemDesText.GetComponent<Text>().text =zstring.Format("{0}\n\n{1}\n品质越高，鉴定出极品的概率越高。\n鉴定符品质与制造者技巧值相关。", itemDes, itempar);
                }
            }

            //鉴定品质符
            if (itemConfig.ItemType == 1 && itemConfig.ItemSubType == 131)
            {
                string[] addList = itemConfig.ItemUsePar.Split(';')[0].Split(',');
                using (zstring.Block())
                {
                    if (string.IsNullOrEmpty(bagInfo.ItemPar))
                    {
                        self.View.E_ItemDesText.GetComponent<Text>().text = zstring.Format("{0}\n\n烹饪品质:无？？", itemDes);
                    }
                    else
                    {
                        self.View.E_ItemDesText.GetComponent<Text>().text = zstring.Format("{0}\n\n烹饪品质:{1}", itemDes, bagInfo.ItemPar);
                    }
                }
            }

            //宠物技能
            if (itemConfig.ItemType == 2 && itemConfig.ItemSubType == 122)
            {
                SkillConfig skillCof = SkillConfigCategory.Instance.Get(int.Parse(itemConfig.ItemUsePar));
                using (zstring.Block())
                {
                    self.View.E_ItemDesText.GetComponent<Text>().text = zstring.Format("{0}\n\n技能描述:{1}", itemDes, skillCof.SkillDescribe);
                }
            }

            //藏宝图
            if (itemConfig.ItemSubType == 127 && !string.IsNullOrEmpty(self.BagInfo.ItemPar))
            {
                int sceneID = int.Parse(self.BagInfo.ItemPar.Split('@')[0]);
                using (zstring.Block())
                {
                    self.View.E_ItemDesText.GetComponent<Text>().text = zstring.Format("{0}\n前往地图:{1}开启藏宝图!", itemConfig.ItemDes,
                        DungeonConfigCategory.Instance.Get(sceneID).ChapterName);
                }
            }

            string langStr = LanguageComponent.Instance.LoadLocalization("使用等级");
            if (itemConfig.UseLv > 0)
            {
                self.View.E_ItemLvText.text = langStr + ":" + itemConfig.UseLv;
            }
            else
            {
                self.View.E_ItemLvText.text = langStr + ":1";
            }

            // 显示按钮
            self.View.E_UseButton.GetComponentInChildren<Text>().text = itemConfig.ItemSubType == 114 ? "镶嵌" : "使用";
            self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
            self.View.E_HuiShouButton.gameObject.SetActive(false);
            self.View.E_HuiShouCancleButton.gameObject.SetActive(false);
            self.View.E_XieXiaGemButton.gameObject.SetActive(false);
            self.View.E_UseButton.gameObject.SetActive(false);
            self.View.E_SplitButton.gameObject.SetActive(false);
            self.View.E_FuLingText.gameObject.SetActive(false);
            self.View.E_FuLingDesText.gameObject.SetActive(false);
            self.View.E_SellButton.gameObject.SetActive(false);
            self.View.E_StoreHouseButton.gameObject.SetActive(false);
            self.View.E_PutBagButton.gameObject.SetActive(false);
            switch (itemOperateEnum)
            {
                // 不显示任何按钮
                case ItemOperateEnum.None:
                case ItemOperateEnum.PaiMaiSell:
                case ItemOperateEnum.PaiMaiBuy:
                    //ItemBottomTextNum = 0;
                    break;
                case ItemOperateEnum.JianYuanBag:
                    break;
                // 背包打开显示对应功能按钮
                case ItemOperateEnum.Bag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    //判定当前是否打开仓库
                    self.View.E_SellButton.gameObject.SetActive(true);
                    self.View.E_UseButton.gameObject.SetActive(itemType != ItemTypeEnum.Material);
                    self.View.E_SplitButton.gameObject.SetActive(itemType == ItemTypeEnum.Material);
                    break;
                // 角色栏打开显示对应功能按钮
                case ItemOperateEnum.Juese:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_UseButton.gameObject.SetActive(true);
                    break;
                // 商店查看属性
                case ItemOperateEnum.Shop:
                    //ItemBottomTextNum = 0;
                    break;
                // 仓库查看属性
                case ItemOperateEnum.Cangku:
                    self.View.E_PutBagButton.gameObject.SetActive(true);
                    //ItemBottomTextNum = 0;
                    break;
                case ItemOperateEnum.GemCangku:
                    self.View.E_PutBagButton.gameObject.SetActive(true);
                    break;
                case ItemOperateEnum.GemBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_StoreHouseButton.gameObject.SetActive(true);
                    break;
                case ItemOperateEnum.CangkuBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_StoreHouseButton.gameObject.SetActive(true);
                    break;
                // 回收背包打开
                case ItemOperateEnum.HuishouBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_HuiShouButton.gameObject.SetActive(true);
                    break;
                // 回收功能显示
                case ItemOperateEnum.HuishouShow:
                    self.View.E_HuiShouCancleButton.gameObject.SetActive(true);
                    break;
                // 牧场  不显示任何按钮
                case ItemOperateEnum.Muchang:
                    //ItemBottomTextNum = 0;
                    break;
                // 牧场仓库  显示出售按钮
                case ItemOperateEnum.MuchangCangku:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_SellButton.gameObject.SetActive(true);
                    break;
                // 镶嵌背包切页
                case ItemOperateEnum.XiangQianBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_UseButton.gameObject.SetActive(true);
                    break;
                // 镶嵌在装备上的宝石
                case ItemOperateEnum.XiangQianGem:
                    self.View.E_XieXiaGemButton.gameObject.SetActive(true);
                    break;
                case ItemOperateEnum.PetHeXinBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_UseButton.gameObject.SetActive(true);
                    self.View.E_UseButton.transform.GetComponentInChildren<Text>().text = "装备";
                    break;
                default:
                    //ItemBottomTextNum = 0;
                    break;
            }

            // 图纸类型需要的按钮
            if (itemType == 1 && itemSubType == 5)
            {
                self.View.E_SellButton.gameObject.SetActive(false);
                self.View.E_UseButton.gameObject.SetActive(true);
                self.View.E_SplitButton.gameObject.SetActive(true);
            }

            float preferredHeight = self.View.E_ItemDesText.preferredHeight;
            if (preferredHeight > 200f)
            {
                float addheight = preferredHeight - 200f;
                Vector2 oldbagsize =  self.View.E_BackImage.GetComponent<RectTransform>().sizeDelta;
                oldbagsize.y += addheight;

                self.View.E_BackImage.GetComponent<RectTransform>().sizeDelta = oldbagsize;
                Log.Debug($"addheight:{addheight}");
            }
            
        }

        private static async ETTask OnSellButton(this DlgItemTips self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ItemSellTip);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgItemSellTip>().Init(self.BagInfo);
            self.OnCloseTips();
        }

        private static async ETTask OnUseButton(this DlgItemTips self)
        {
            //发送消息
            //判断当前技能是否再CD状态
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            string usrPar = "";

            if (itemConfig.DayUseNum > 0 && userInfoComponent.GetDayItemUse(itemConfig.Id) >= itemConfig.DayUseNum)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNoUseTime);
                return;
            }

            // 增幅卷轴
            if (itemConfig.ItemSubType == 17)
            {
                self.Root().GetComponent<FlyTipComponent>().ShowFlyTip("请前往家园装备增幅系统");
                return;
            }

            //材料
            if (itemConfig.ItemType == (int)ItemTypeEnum.Material)
            {
                return;
            }

            // 镶嵌宝石
            if (itemConfig.ItemType == (int)ItemTypeEnum.Gemstone)
            {
                DlgRole dlgRole = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRole>();
                if (dlgRole == null)
                {
                    return;
                }

                if (!dlgRole.View.ES_RoleGem.uiTransform.gameObject.activeSelf)
                {
                    return;
                }

                if (dlgRole.View.ES_RoleGem.XiangQianItem == null)
                {
                    FlyTipComponent.Instance.ShowFlyTip("请选择装备！");
                    return;
                }

                string gemHole = dlgRole.View.ES_RoleGem.XiangQianItem.GemHole;
                if (dlgRole.View.ES_RoleGem.XiangQianIndex == -1)
                {
                    FlyTipComponent.Instance.ShowFlyTip("请选择孔位！");
                    return;
                }

                string[] gemHolelist = gemHole.Split('_');
                if (gemHolelist.Length <= dlgRole.View.ES_RoleGem.XiangQianIndex)
                {
                    FlyTipComponent.Instance.ShowFlyTip("请选择孔位！");
                    return;
                }

                string itemgem = gemHolelist[dlgRole.View.ES_RoleGem.XiangQianIndex];
                if (itemgem != itemConfig.ItemSubType.ToString() && itemConfig.ItemSubType != 110 && itemConfig.ItemSubType != 111)
                {
                    FlyTipComponent.Instance.ShowFlyTip("宝石与孔位不符！");
                    return;
                }

                string[] getIdNew = dlgRole.View.ES_RoleGem.XiangQianItem.GemIDNew.Split('_');
                using (zstring.Block())
                {
                    usrPar = zstring.Format("{0}_{1}", dlgRole.View.ES_RoleGem.XiangQianItem.BagInfoID, dlgRole.View.ES_RoleGem.XiangQianIndex);

                    if (getIdNew[dlgRole.View.ES_RoleGem.XiangQianIndex] != "0")
                    {
                        PopupTipHelp.OpenPopupTip(self.Root(), "镶嵌宝石", "是否需要覆盖宝石?\n覆盖后原有位置得宝石会自动销毁哦!", () => { self.RequestXiangQianGem(usrPar); })
                                .Coroutine();
                    }
                    else
                    {
                        self.RequestXiangQianGem(usrPar);
                    }
                }

                return;
            }

            if (itemConfig.ItemType == (int)ItemTypeEnum.PetHeXin)
            {
                DlgPet dlgPet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>();
                await dlgPet.RequestPetHeXinSelect();

                self.OnCloseTips();

                return;
            }

            if (itemConfig.ItemSubType == 4 || itemConfig.ItemSubType == 14)
            {
                if (self.Root().GetComponent<MapComponent>().MapType != (int)MapTypeEnum.LocalDungeon)
                {
                    FlyTipComponent.Instance.ShowFlyTip("副本中才能使用!");
                    return;
                }
            }

            if (itemConfig.ItemSubType == 5)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TuZhiMake);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTuZhiMake>().OnInitUI(self.BagInfo);
                self.OnCloseTips();
                return;
            }

            if (itemConfig.ItemSubType == 15) //附魔
            {
                self.OnItemFumoUse(itemConfig).Coroutine();
                return;
            }

            if (itemConfig.ItemSubType == 16) //锻造精灵
            {
                int makeNew = int.Parse(itemConfig.ItemUsePar);
                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeNew);

                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                int makeType_1 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_1);
                int makeType_2 = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.MakeType_2);
                if (makeType_1 != equipMakeConfig.ProficiencyType && makeType_2 != equipMakeConfig.ProficiencyType)
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_MakeTypeError);
                    return;
                }

                if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.MakeList.Contains(makeNew))
                {
                    FlyTipComponent.Instance.ShowFlyTip("已经学习过该技能！");
                    return;
                }
            }

            if (itemConfig.ItemSubType == 101)
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                Quaternion quaternion = unit.Rotation;
                unit.GetComponent<SkillManagerComponentC>()
                        .SendUseSkill(int.Parse(itemConfig.ItemUsePar), itemConfig.Id, Mathf.FloorToInt(quaternion.eulerAngles.y), 0, 0).Coroutine();
                self.OnCloseTips();
                return;
            }

            if (itemConfig.ItemSubType == 102)
            {
                FlyTipComponent.Instance.ShowFlyTip("请前往主城的宠物蛋孵化处!");
                return;
            }

            if (itemConfig.ItemSubType == 112)
            {
                // AccountInfoComponent accountInfoComponent = self.ZoneScene().GetComponent<AccountInfoComponent>();
                // long openserverTime = ServerHelper.GetOpenServerTime(!GlobalHelp.IsOutNetMode, accountInfoComponent.ServerId);
                // if (TimeHelper.ServerNow() - openserverTime < TimeHelper.Hour * 4)
                // {
                //     FloatTipManager.Instance.ShowFloatTip("开区4小时后开启!");
                //     return;
                // }

                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ItemExpBox);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgItemExpBox>().OnInitUI(self.BagInfo);
                self.OnCloseTips();
                return;
            }

            // 弹出道具批量使用
            if (self.BagInfo.ItemNum >= 2 && ConfigData.BatchUseItemList.Contains(itemConfig.Id))
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ItemBatchUse);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgItemBatchUse>().OnInitUI(self.BagInfo);
                self.OnCloseTips();
                return;
            }

            if (itemConfig.ItemSubType == 113 || itemConfig.ItemSubType == 127)
            {
                if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
                {
                    FlyTipComponent.Instance.ShowFlyTip("背包格子不够！");
                    return;
                }

                int curSceneId = 0;
                int needSceneId = int.Parse(self.BagInfo.ItemPar.Split('@')[0]);
                MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
                if (mapComponent.MapType == (int)MapTypeEnum.LocalDungeon)
                {
                    curSceneId = mapComponent.SceneId;
                }

                if (curSceneId != needSceneId)
                {
                    string fubenName = DungeonConfigCategory.Instance.Get(needSceneId).ChapterName;
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("请前往{0}", fubenName));
                    }

                    return;
                }
                else
                {
                    EventSystem.Instance.Publish(self.Root(), new DigForTreasure() { BagInfo = self.BagInfo });
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Role);
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("消耗道具:{0}", itemConfig.ItemName));
                    }

                    self.OnCloseTips();
                    return;
                }
            }

            if (itemConfig.ItemSubType == 108
                || itemConfig.ItemSubType == 109
                || itemConfig.ItemSubType == 117
                || itemConfig.ItemSubType == 118
                || itemConfig.ItemSubType == 119
                || itemConfig.ItemSubType == 122)
            {
                PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
                RolePetInfo petInfo = petComponent.GetFightPet();
                if ((itemConfig.ItemSubType == 108
                        || itemConfig.ItemSubType == 109) && petInfo != null)
                {
                    PetNetHelper.RequestXiLian(self.Root(), self.BagInfo.BagInfoID, petInfo.Id).Coroutine();
                    self.OnCloseTips();
                    return;
                }

                FlyTipComponent.Instance.ShowFlyTip("请前往宠物重塑界面使用！");
                return;
            }

            if (itemConfig.ItemSubType == 132)
            {
                FlyTipComponent.Instance.ShowFlyTip("请前往赛季界面使用");
                return;
            }

            if (itemConfig.ItemSubType == 137)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetEggFuLing);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetEggFuLing>().UpdateItemList(self.BagInfo);
                CommonViewHelper.PlayUIMusic("10010");
                self.OnCloseTips();
                return;
            }

            if (itemConfig.ItemSubType == 139)
            {
                if (self.Root().GetComponent<BagComponentC>().BagAddCellNumber[0] >= 10)
                {
                    FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("已达到最大购买格子数量!"));
                    return;
                }
            }

            if (itemConfig.ItemSubType == 140)
            {
                if (self.Root().GetComponent<BagComponentC>().BagAddCellNumber[5] >= 10)
                {
                    FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("已达到最大购买格子数量!"));
                    return;
                }
            }

            long instanceid = self.InstanceId;
            M2C_ItemOperateResponse response = await BagClientNetHelper.RequestUseItem(self.Root(), self.BagInfo, usrPar);

            if (response != null && response.Error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("道具使用成功!"));

                if (response.RewardList.Count > 0)
                {
                    await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonReward);
                    DlgCommonReward dlgCommonReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>();
                    dlgCommonReward.OnUpdateUI(response.RewardList);
                }
            }

            if (response != null && response.Error == ErrorCode.ERR_ItemOnlyUseOcc)
            {
                OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(itemConfig.UseOcc);
                string tip;
                using (zstring.Block())
                {
                    tip = zstring.Format(HintHelp.GetErrorHint(ErrorCode.ERR_ItemOnlyUseOcc), occupationConfig.OccupationName);
                }

                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization(tip));
            }

            //播放音效
            CommonViewHelper.PlayUIMusic("10010");

            if (instanceid == self.InstanceId)
            {
                if (itemConfig.ItemSubType == 110)
                {
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Role);
                }

                //注销Tips
                self.OnCloseTips();
            }
        }

        public static async ETTask OnItemFumoUse(this DlgItemTips self, ItemConfig itemConfig)
        {
            await ETTask.CompletedTask;
            string[] itemparams = itemConfig.ItemUsePar.Split('@');
            int weizhi = int.Parse(itemparams[0]);
            ItemInfo equipinfo = self.Root().GetComponent<BagComponentC>().GetEquipBySubType(ItemLocType.ItemLocEquip, weizhi);
            if (equipinfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("对应的位置没有装备！");
                return;
            }

            if (weizhi == (int)ItemSubTypeEnum.Shiping)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ItemFumoSelect);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgItemFumoSelect>().OnInitUI(self.BagInfo);
                self.OnCloseTips();
                return;
            }

            List<HideProList> hideProLists = XiLianHelper.GetItemFumoPro(itemConfig.Id);
            string itemfumo = ItemViewHelp.GetFumpProDesc(hideProLists);

            if (equipinfo.FumoProLists.Count > 0)
            {
                string equipfumo = ItemViewHelp.GetFumpProDesc(equipinfo.FumoProLists);
                string fumopro;
                using (zstring.Block())
                {
                    fumopro = zstring.Format("当前附魔属性<color=#BEFF34>{0}</color> \n是否覆盖已有属性\n{1}\n此附魔道具已消耗", equipfumo, itemfumo);
                }

                BagClientNetHelper.SendFumoUse(self.Root(), self.BagInfo, hideProLists).Coroutine();
                PopupTipHelp.OpenPopupTip(self.Root(), "装备附魔", fumopro, () =>
                {
                    BagClientNetHelper.SendFumoPro(self.Root(), 0).Coroutine();
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("附魔属性 {0}", itemfumo));
                    }

                    self.OnCloseTips();
                }, () => { self.OnCloseTips(); }).Coroutine();
            }
            else
            {
                await BagClientNetHelper.SendFumoUse(self.Root(), self.BagInfo, hideProLists);
                await BagClientNetHelper.SendFumoPro(self.Root(), 0);
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("附魔属性 {0}", itemfumo));
                }

                self.OnCloseTips();
            }
        }

        private static void RequestXiangQianGem(this DlgItemTips self, string usrPar)
        {
            BagClientNetHelper.RequestXiangQianGem(self.Root(), self.BagInfo, usrPar).Coroutine();
            self.OnCloseTips();
        }

        private static async ETTask OnSplitButton(this DlgItemTips self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleBagSplit);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRoleBagSplit>().Init(self.BagInfo);
            self.OnCloseTips();
        }

        private static void OnPlanButton(this DlgItemTips self)
        {
            self.OnCloseTips();
        }

        private static void OnStoreHouseButton(this DlgItemTips self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            if (self.ItemOperateEnum == ItemOperateEnum.GemBag && itemConfig.ItemType != ItemTypeEnum.Gemstone)
            {
                FlyTipComponent.Instance.ShowFlyTip("只能放入宝石！");
                return;
            }

            if (self.ItemOperateEnum == ItemOperateEnum.AccountBag)
            {
                ItemViewHelp.AccountCangkuPutIn(self.Root(), self.BagInfo);
            }
            else
            {
                BagClientNetHelper.RquestPutStoreHouse(self.Root(), self.BagInfo, self.CurrentHouse).Coroutine();
            }

            self.OnCloseTips();
        }

        private static void OnHuiShouButton(this DlgItemTips self)
        {
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("1_{0}", self.BagInfo.BagInfoID) });
            }

            self.OnCloseTips();
        }

        private static void OnHuiShouCancleButton(this DlgItemTips self)
        {
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("0_{0}", self.BagInfo.BagInfoID) });
            }

            self.OnCloseTips();
        }

        private static void OnXieXiaGemButton(this DlgItemTips self)
        {
            DlgRole dlgRole = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRole>();
            if (dlgRole == null)
            {
                return;
            }

            if (!dlgRole.View.ES_RoleGem.uiTransform.gameObject.activeSelf)
            {
                return;
            }

            BagClientNetHelper.RequestXieXiaGem(self.Root(), dlgRole.View.ES_RoleGem.XiangQianItem,
                dlgRole.View.ES_RoleGem.XiangQianIndex.ToString()).Coroutine();
            self.OnCloseTips();
        }

        private static void OnPutBagButton(this DlgItemTips self)
        {
            if (self.ItemOperateEnum == ItemOperateEnum.AccountCangku)
            {
                BagClientNetHelper.RequestAccountWarehousOperate(self.Root(), 2, self.BagInfo.BagInfoID).Coroutine();
            }
            else
            {
                BagClientNetHelper.RquestPutBag(self.Root(), self.BagInfo).Coroutine();
            }

            self.OnCloseTips();
        }

        private static void OnCloseTips(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }
    }
}
