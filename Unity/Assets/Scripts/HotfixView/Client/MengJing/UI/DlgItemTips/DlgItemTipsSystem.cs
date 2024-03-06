using System.Collections;
using System.Collections.Generic;
using System;
using MongoDB.Bson;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgItemTipsViewComponent))]
    [FriendOf(typeof (DlgItemTips))]
    public static class DlgItemTipsSystem
    {
        public static void RegisterUIEvent(this DlgItemTips self)
        {
            self.View.E_BGButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips); });
            self.View.E_SellButton.AddListenerAsync(self.OnSellButton);
            self.View.E_UseButton.AddListenerAsync(self.OnUseButton);
            self.View.E_SplitButton.AddListenerAsync(self.OnSplitButton);
            self.View.E_PlanButton.AddListener(self.OnPlanButton);
            self.View.E_StoreHouseButton.AddListener(self.OnStoreHouseButton);
            self.View.E_HuiShouButton.AddListener(self.OnHuiShouButton);
            self.View.E_HuiShouCancleButton.AddListener(self.OnHuiShouCancleButton);
            self.View.E_XieXiaGemButton.AddListener(self.OnXieXiaGemButton);
            self.View.E_PutBagButton.AddListener(self.OnPutBagButton);
        }

        public static void ShowWindow(this DlgItemTips self, Entity contextData = null)
        {
            self.Img_backVector2 = self.View.E_BackImage.GetComponent<RectTransform>().sizeDelta;
            self.Lab_ItemNameWidth = self.View.E_ItemNameText.GetComponent<RectTransform>().sizeDelta.x;
        }

        public static void SetPosition(this DlgItemTips self, Vector2 vector2)
        {
            self.View.uiTransform.GetComponent<RectTransform>().anchoredPosition = vector2;
        }

        public static void RefreshInfo(this DlgItemTips self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum)
        {
            self.BagInfo = bagInfo;
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

            self.View.E_ItemTypeText.text = "类型:" + itemTypename;

            //显示是否绑定
            if (bagInfo.isBinging)
            {
                self.View.E_BangDingText.text = GameSettingLanguge.LoadLocalization("已绑定");
                self.View.E_BangDingText.color = new Color(175f / 255f, 1, 6f / 255f);
                self.View.E_BangDingText.gameObject.SetActive(true);
            }
            else
            {
                self.View.E_BangDingText.GetComponent<Text>().text = GameSettingLanguge.LoadLocalization("未绑定");
                self.View.E_BangDingText.GetComponent<Text>().color = new Color(255f / 255f, 240f / 255f, 200f / 255f);
                self.View.E_BangDingText.gameObject.SetActive(false);
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

            float exceedWidth = self.View.E_ItemNameText.preferredWidth - self.Lab_ItemNameWidth;
            if (exceedWidth > -20)
            {
                self.View.E_PutBagImage.GetComponent<RectTransform>().sizeDelta =
                        new Vector2(self.Img_backVector2.x + exceedWidth + 30, self.Img_backVector2.y);
            }

            //鉴定品质符
            if (itemConfig.ItemSubType == 121)
            {
                self.View.E_ItemDesText.GetComponent<Text>().text = itemDes + "\n" + "\n" + $"鉴定符品质:{bagInfo.ItemPar}" + "\n" +
                        "品质越高,鉴定出极品的概率越高。" + "\n" +
                        "鉴定符品质与制造者熟练度相关。";
            }

            //鉴定品质符
            if (itemConfig.ItemType == 1 && itemConfig.ItemSubType == 131)
            {
                string[] addList = itemConfig.ItemUsePar.Split(';')[0].Split(',');
                self.View.E_ItemDesText.GetComponent<Text>().text = itemDes + "\n" + "\n" + "烹饪品质:" + bagInfo.ItemPar;
            }

            //宠物技能
            if (itemConfig.ItemType == 2 && itemConfig.ItemSubType == 122)
            {
                SkillConfig skillCof = SkillConfigCategory.Instance.Get(int.Parse(itemConfig.ItemUsePar));
                self.View.E_ItemDesText.GetComponent<Text>().text = itemDes + "\n" + "\n" + $"技能描述:{skillCof.SkillDescribe}";
            }

            //藏宝图
            if (itemConfig.ItemSubType == 127 && !string.IsNullOrEmpty(self.BagInfo.ItemPar))
            {
                int sceneID = int.Parse(self.BagInfo.ItemPar.Split('@')[0]);
                self.View.E_ItemDesText.GetComponent<Text>().text =
                        $"{itemConfig.ItemDes}\n前往地图:{DungeonConfigCategory.Instance.Get(sceneID).ChapterName}开启藏宝图!";
            }

            string langStr = GameSettingLanguge.LoadLocalization("使用等级");
            if (itemConfig.UseLv > 0)
            {
                self.View.E_ItemLvText.text = langStr + ":" + itemConfig.UseLv;
            }
            else
            {
                self.View.E_ItemLvText.text = langStr + ":1";
            }

            // 显示按钮
            self.View.E_UseButton.GetComponentInChildren<Text>().text = itemConfig.ItemSubType == 114? "镶嵌" : "使用";
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
        }

        private static async ETTask OnSellButton(this DlgItemTips self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ItemSellTip);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgItemSellTip>().Init(self.BagInfo);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static async ETTask OnUseButton(this DlgItemTips self)
        {
            //发送消息
            //判断当前技能是否再CD状态
            UserInfoComponentClient userInfoComponent = self.Root().GetComponent<UserInfoComponentClient>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            int errorCode = ErrorCode.ERR_Success;
            string usrPar = "";

            if (itemConfig.DayUseNum > 0 && userInfoComponent.GetDayItemUse(itemConfig.Id) >= itemConfig.DayUseNum)
            {
                ErrorViewHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNoUseTime);
                return;
            }

            // 增幅卷轴
            if (itemConfig.ItemSubType == 17)
            {
                self.Root().GetComponent<FlyTipComponent>().SpawnFlyTip("请前往家园装备增幅系统");
                return;
            }

            //材料
            if (itemConfig.ItemType == (int)ItemTypeEnum.Material)
            {
                return;
            }

            //镶嵌宝石
            // if (itemConfig.ItemType == (int)ItemTypeEnum.Gemstone)
            // {
            //     UI uiRole = UIHelper.GetUI(self.ZoneScene(), UIType.UIRole);
            //     if (uiRole == null)
            //     {
            //         return;
            //     }
            //
            //     UIRoleComponent uIRoleComponent = uiRole.GetComponent<UIRoleComponent>();
            //     if (uIRoleComponent.UIPageButton.CurrentIndex != (int)RolePageEnum.RoleGem)
            //     {
            //         uIRoleComponent.UIPageButton.OnSelectIndex((int)RolePageEnum.RoleGem);
            //         return;
            //     }
            //
            //     UIRoleGemComponent uIRoleGemComponent =
            //             uIRoleComponent.UIPageView.UISubViewList[(int)RolePageEnum.RoleGem].GetComponent<UIRoleGemComponent>();
            //     if (uIRoleGemComponent.XiangQianItem == null)
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("请选择装备！");
            //         return;
            //     }
            //
            //     string gemHole = uIRoleGemComponent.XiangQianItem.GemHole;
            //     if (uIRoleGemComponent.XiangQianIndex == -1)
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("请选择孔位！");
            //         return;
            //     }
            //
            //     string[] gemHolelist = gemHole.Split('_');
            //     if (gemHolelist.Length <= uIRoleGemComponent.XiangQianIndex)
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("请选择孔位！");
            //         return;
            //     }
            //
            //     string itemgem = gemHolelist[uIRoleGemComponent.XiangQianIndex];
            //     if (itemgem != itemConfig.ItemSubType.ToString() && itemConfig.ItemSubType != 110 && itemConfig.ItemSubType != 111)
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("宝石与孔位不符！");
            //         return;
            //     }
            //
            //     string[] getIdNew = uIRoleGemComponent.XiangQianItem.GemIDNew.Split('_');
            //     usrPar = $"{uIRoleGemComponent.XiangQianItem.BagInfoID}_{uIRoleGemComponent.XiangQianIndex}";
            //     if (getIdNew[uIRoleGemComponent.XiangQianIndex] != "0")
            //     {
            //         PopupTipHelp.OpenPopupTip(self.ZoneScene(), "镶嵌宝石", "是否需要覆盖宝石?\n覆盖后原有位置得宝石会自动销毁哦!", () => { self.RequestXiangQianGem(usrPar); })
            //                 .Coroutine();
            //     }
            //     else
            //     {
            //         self.RequestXiangQianGem(usrPar);
            //     }
            //
            //     return;
            // }

            // if (itemConfig.ItemType == (int)ItemTypeEnum.PetHeXin)
            // {
            //     UI uI = UIHelper.GetUI(self.ZoneScene(), UIType.UIPet);
            //     errorCode = await uI.GetComponent<UIPetComponent>().RequestPetHeXinSelect();
            //     //注销Tips
            //     if (errorCode == ErrorCode.ERR_Success)
            //     {
            //         self.OnCloseTips();
            //     }
            //
            //     return;
            // }

            // if (itemConfig.ItemSubType == 4 || itemConfig.ItemSubType == 14)
            // {
            //     if (self.ZoneScene().GetComponent<MapComponent>().SceneTypeEnum != (int)SceneTypeEnum.LocalDungeon)
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("副本中才能使用!");
            //         return;
            //     }
            // }

            // if (itemConfig.ItemSubType == 5)
            // {
            //     UI uI = await UIHelper.Create(self.ZoneScene(), UIType.UITuZhiMake);
            //     uI.GetComponent<UITuZhiMakeComponent>().OnInitUI(self.BagInfo).Coroutine();
            //     self.OnCloseTips();
            //     return;
            // }

            // if (itemConfig.ItemSubType == 15) //附魔
            // {
            //     self.OnItemFumoUse(itemConfig).Coroutine();
            //     return;
            // }

            // if (itemConfig.ItemSubType == 16) //锻造精灵
            // {
            //     int makeNew = int.Parse(itemConfig.ItemUsePar);
            //     EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeNew);
            //
            //     Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            //     int makeType_1 = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.MakeType_1);
            //     int makeType_2 = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.MakeType_2);
            //     if (makeType_1 != equipMakeConfig.ProficiencyType && makeType_2 != equipMakeConfig.ProficiencyType)
            //     {
            //         ErrorHelp.Instance.ErrorHint(ErrorCode.ERR_MakeTypeError);
            //         return;
            //     }
            //
            //     if (self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.MakeList.Contains(makeNew))
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("已经学习过该技能！");
            //         return;
            //     }
            // }

            // if (itemConfig.ItemSubType == 101)
            // {
            //     Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            //     unit.GetComponent<SkillManagerComponent>().SendUseSkill(int.Parse(itemConfig.ItemUsePar), itemConfig.Id,
            //         Mathf.FloorToInt(unit.Rotation.eulerAngles.y), 0, 0).Coroutine();
            //     self.OnCloseTips();
            //     return;
            // }

            // if (itemConfig.ItemSubType == 102)
            // {
            //     FloatTipManager.Instance.ShowFloatTip("请前往主城的宠物蛋孵化处!");
            //     return;
            // }

            // if (itemConfig.ItemSubType == 112)
            // {
            //     AccountInfoComponent accountInfoComponent = self.ZoneScene().GetComponent<AccountInfoComponent>();
            //     long openserverTime = ServerHelper.GetOpenServerTime(!GlobalHelp.IsOutNetMode, accountInfoComponent.ServerId);
            //     if (TimeHelper.ServerNow() - openserverTime < TimeHelper.Hour * 4)
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("开区4小时后开启!");
            //         return;
            //     }
            //
            //     UI uI = await UIHelper.Create(self.ZoneScene(), UIType.UIItemExpBox);
            //     uI.GetComponent<UIItemExpBoxComponent>().OnInitUI(self.BagInfo);
            //     self.OnCloseTips();
            //     return;
            // }
            //
            // // 弹出道具批量使用
            // if (self.BagInfo.ItemNum >= 2 && ConfigHelper.BatchUseItemList.Contains(itemConfig.Id))
            // {
            //     UI uI = await UIHelper.Create(self.ZoneScene(), UIType.UIItemBatchUse);
            //     uI.GetComponent<UIItemBatchUseComponent>().OnInitUI(self.BagInfo);
            //     self.OnCloseTips();
            //     return;
            // }
            //
            // if (itemConfig.ItemSubType == 113 || itemConfig.ItemSubType == 127)
            // {
            //     if (self.BagComponent.GetBagLeftCell() < 1)
            //     {
            //         FloatTipManager.Instance.ShowFloatTip("背包格子不够！");
            //         return;
            //     }
            //
            //     int curSceneId = 0;
            //     int needSceneId = int.Parse(self.BagInfo.ItemPar.Split('@')[0]);
            //     MapComponent mapComponent = self.ZoneScene().GetComponent<MapComponent>();
            //     if (mapComponent.SceneTypeEnum == (int)SceneTypeEnum.LocalDungeon)
            //     {
            //         curSceneId = mapComponent.SceneId;
            //     }
            //
            //     if (curSceneId != needSceneId)
            //     {
            //         string fubenName = DungeonConfigCategory.Instance.Get(needSceneId).ChapterName;
            //         FloatTipManager.Instance.ShowFloatTip($"请前往{fubenName}");
            //         return;
            //     }
            //     else
            //     {
            //         // $"{dungeonid}@{"TaskMove_6"}@{dropId}";
            //         Scene zoneScene = self.ZoneScene();
            //         EventType.DigForTreasure.Instance.BagInfo = self.BagInfo;
            //         EventType.DigForTreasure.Instance.ZoneScene = self.ZoneScene();
            //         Game.EventSystem.PublishClass(EventType.DigForTreasure.Instance);
            //         UIHelper.Remove(zoneScene, UIType.UIRole);
            //         self.OnCloseTips();
            //         FloatTipManager.Instance.ShowFloatTip($"消耗道具:{itemConfig.ItemName}");
            //         return;
            //     }
            // }
            //
            // if (itemConfig.ItemSubType == 108
            //     || itemConfig.ItemSubType == 109
            //     || itemConfig.ItemSubType == 117
            //     || itemConfig.ItemSubType == 118
            //     || itemConfig.ItemSubType == 119
            //     || itemConfig.ItemSubType == 122)
            // {
            //     PetComponent petComponent = self.ZoneScene().GetComponent<PetComponent>();
            //     RolePetInfo petInfo = petComponent.GetFightPet();
            //     if ((itemConfig.ItemSubType == 108
            //             || itemConfig.ItemSubType == 109) && petInfo != null)
            //     {
            //         petComponent.RequestXiLian(self.BagInfo.BagInfoID, petInfo.Id).Coroutine();
            //         self.OnCloseTips();
            //         return;
            //     }
            //
            //     FloatTipManager.Instance.ShowFloatTip("请前往宠物重塑界面使用！");
            //     return;
            // }
            //
            // if (itemConfig.ItemSubType == 132)
            // {
            //     FloatTipManager.Instance.ShowFloatTip("请前往赛季界面使用");
            //     return;
            // }
            //
            // if (itemConfig.ItemSubType == 137)
            // {
            //     UI ui = await UIHelper.Create(self.ZoneScene(), UIType.UIPetEggFuLing);
            //     ui.GetComponent<UIPetEggFuLingComponent>().UpdateItemList(self.BagInfo).Coroutine();
            //     UIHelper.PlayUIMusic("10010");
            //     self.OnCloseTips();
            //     return;
            // }
            //
            // if (itemConfig.ItemSubType == 139)
            // {
            //     if (self.ZoneScene().GetComponent<BagComponent>().AdditionalCellNum[0] >= 10)
            //     {
            //         FloatTipManager.Instance.ShowFloatTipDi(GameSettingLanguge.LoadLocalization("已达到最大购买格子数量!"));
            //         return;
            //     }
            // }
            //
            // if (itemConfig.ItemSubType == 140)
            // {
            //     if (self.ZoneScene().GetComponent<BagComponent>().AdditionalCellNum[5] >= 10)
            //     {
            //         FloatTipManager.Instance.ShowFloatTipDi(GameSettingLanguge.LoadLocalization("已达到最大购买格子数量!"));
            //         return;
            //     }
            // }
            //
            // long instanceid = self.InstanceId;
            errorCode = await BagClientNetHelper.RequestUseItem(self.Root(), self.BagInfo, usrPar);

            // if (errorCode == ErrorCode.ERR_Success)
            // {
            //     FloatTipManager.Instance.ShowFloatTipDi(GameSettingLanguge.LoadLocalization("道具使用成功!"));
            // }
            //
            // if (errorCode == ErrorCode.ERR_ItemOnlyUseOcc)
            // {
            //     OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(itemConfig.UseOcc);
            //     string tip = string.Format(ErrorHelp.Instance.GetHint(ErrorCode.ERR_ItemOnlyUseOcc), occupationConfig.OccupationName);
            //     FloatTipManager.Instance.ShowFloatTipDi(GameSettingLanguge.LoadLocalization(tip));
            // }
            //
            // //播放音效
            // UIHelper.PlayUIMusic("10010");
            //
            // if (instanceid == self.InstanceId)
            // {
            //     if (itemConfig.ItemSubType == 110)
            //     {
            //         UIHelper.Remove(self.ZoneScene(), UIType.UIRole);
            //     }
            //
            //     //注销Tips
            //     self.OnCloseTips();
            // }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static async ETTask OnSplitButton(this DlgItemTips self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleBagSplit);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRoleBagSplit>().Init(self.BagInfo);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static void OnPlanButton(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static void OnStoreHouseButton(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static void OnHuiShouButton(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static void OnHuiShouCancleButton(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static void OnXieXiaGemButton(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static void OnPutBagButton(this DlgItemTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }
    }
}