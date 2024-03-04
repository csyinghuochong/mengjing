using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ItemAppraisalTips))]
    [FriendOfAttribute(typeof (ES_ItemAppraisalTips))]
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
        }

        [EntitySystem]
        private static void Destroy(this ES_ItemAppraisalTips self)
        {
            self.DestroyWidget();
        }

        // public static void RefreshInfo(this ES_ItemAppraisalTips self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum)
        // {
        //     self.BagInfo = bagInfo;
        //     self.ItemOpetateType = itemOperateEnum;
        //     ItemConfig itemconf = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
        //     int itemType = itemconf.ItemType;
        //     int itemSubType = itemconf.ItemSubType;
        //
        //     ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
        //
        //     string qualityiconLine = FunctionUI.ItemQualityLine(itemconf.ItemQuality);
        //     string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconLine);
        //     Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
        //     self.E_QualityLineImage.sprite = sp;
        //
        //     string qualityiconBack = FunctionUI.ItemQualityBack(itemconf.ItemQuality);
        //     string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconBack);
        //     Sprite sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);
        //     self.E_QualityBgImage.sprite = sp1;
        //
        //     //类型描述
        //     string itemTypename = "消耗品";
        //     ItemViewData.ItemTypeName.TryGetValue(itemType, out itemTypename);
        //     self.E_ItemTypeText.text = "类型:" + itemTypename;
        //     if (itemconf.ItemEquipID != 0 && itemconf.EquipType != 201)
        //     {
        //         int appraisalItem = EquipConfigCategory.Instance.Get(itemconf.ItemEquipID).AppraisalItem;
        //         if (appraisalItem != 0)
        //         {
        //             string tip_1 = itemconf.EquipType == 101? "封印生肖" : "进行鉴定";
        //             string jiandingName = ItemConfigCategory.Instance.Get(appraisalItem).ItemName;
        //             self.Obj_Lab_ItemCostDes.GetComponent<Text>().text = $"消耗<color=#EA8EF9>{jiandingName}</color>{tip_1}";
        //         }
        //     }
        //
        //     if (baginfo.MakePlayer != "" && baginfo.MakePlayer != null)
        //     {
        //         self.Lab_ItemMake.SetActive(true);
        //         self.Lab_ItemMake.GetComponent<Text>().text = $"此装备由<color=#805100>{self.BagInfo.MakePlayer}</color>打造";
        //     }
        //     else
        //     {
        //         self.Lab_ItemMake.GetComponent<Text>().text = "";
        //         self.Lab_ItemMake.SetActive(false);
        //     }
        //
        //     string equipType = "";
        //     if (itemType == 3)
        //     {
        //         //获取类型显示
        //         string textEquipType = ItemViewHelp.GetEquipSonType(itemconf.ItemSubType.ToString());
        //         string textEquipSonType = ItemViewHelp.GetEquipTypeShow(itemconf.EquipType);
        //
        //         //121211 <color=#AFFF06>颜色</color>
        //         equipType = $"<color=#AFFF06>    类型:{textEquipSonType}</color>";
        //         self.ItemType.GetComponent<Text>().text = "部位:" + textEquipType;
        //     }
        //
        //     string Text_ItemDes = itemconf.ItemDes;
        //     //获取道具描述的分隔符
        //     string[] itemDesArray = Text_ItemDes.Split(';');
        //     string itemMiaoShu = "";
        //
        //     for (int i = 0; i <= itemDesArray.Length - 1; i++)
        //     {
        //         if (itemMiaoShu == "")
        //         {
        //             itemMiaoShu = itemDesArray[i];
        //         }
        //         else
        //         {
        //             itemMiaoShu = itemMiaoShu + "\n" + itemDesArray[i];
        //         }
        //     }
        //
        //     //数组大于2表示有换行符,否则显示原来的描述
        //     if (itemDesArray.Length >= 2)
        //     {
        //         Text_ItemDes = itemMiaoShu;
        //     }
        //
        //     //根据Tips描述长度缩放底的大小
        //     int i1 = 0;
        //     Text_ItemDes = ItemViewHelp.GetItemDesc(baginfo, ref i1);
        //     //赞助宝箱设置描述为绿色
        //     if (itemSubType == 9)
        //     {
        //         //self.ItemDes.GetComponent<Text>().color = Color.green;
        //     }
        //
        //     //显示是否绑定
        //     if (baginfo.isBinging)
        //     {
        //         self.Obj_Lab_EquipBangDing.GetComponent<Text>().text = GameSettingLanguge.LoadLocalization("已绑定");
        //         self.Obj_Lab_EquipBangDing.GetComponent<Text>().color = new Color(175f / 255f, 1, 6f / 255f);
        //         self.Obj_Img_EquipBangDing.SetActive(true);
        //     }
        //     else
        //     {
        //         self.Obj_Lab_EquipBangDing.GetComponent<Text>().text = GameSettingLanguge.LoadLocalization("未绑定");
        //         self.Obj_Lab_EquipBangDing.GetComponent<Text>().color = new Color(255f / 255f, 240f / 255f, 200f / 255f);
        //         self.Obj_Img_EquipBangDing.SetActive(false);
        //     }
        //
        //     //显示图标
        //     //显示道具Icon
        //     string ItemIcon = itemconf.Icon;
        //     string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemIcon);
        //     Sprite sp2 = ResourcesComponent.Instance.LoadAsset<Sprite>(path2);
        //     if (!self.AssetPath.Contains(path2))
        //     {
        //         self.AssetPath.Add(path2);
        //     }
        //
        //     self.Obj_ItemIcon.GetComponent<Image>().sprite = sp2;
        //
        //     self.Img_FengYin.SetActive(itemconf.EquipType == 101);
        //     UICommonHelper.SetImageGray(self.Obj_ItemIcon, true);
        //
        //     self.ItemDes.GetComponent<Text>().text = itemconf.EquipType == 101? "封印生肖" : "未鉴定装备";
        //     // 赛季晶核
        //     if (itemType == 3 && itemconf.EquipType == 201)
        //     {
        //         self.ItemDes.SetActive(false);
        //         self.Lab_ItemJingHeQuality.SetActive(true);
        //         int qua = 1;
        //         int nowQua = int.Parse(baginfo.ItemPar);
        //         qua = (int)(nowQua / 20) + 1;
        //         if (qua >= 5)
        //         {
        //             qua = 5;
        //         }
        //
        //         string colorValue = ItemViewHelp.QualityReturnColorUI(qua);
        //         self.Lab_ItemJingHeQuality.GetComponent<Text>().text = $"当前品质:{baginfo.ItemPar}";
        //         //self.Lab_ItemJingHeQuality.AddComponent<Outline>();
        //         // 属性显示itemConfig.ItemUsePar
        //         string attribute = "";
        //         string[] parmainfos = itemconf.ItemUsePar.Split('@');
        //         string[] attriinfos = parmainfos[1].Split(';');
        //         int addType = int.Parse(attriinfos[0]);
        //         if (addType == 1)
        //         {
        //             string[] hidevalueinfo = attriinfos[1].Split(',');
        //             int hideid = int.Parse(hidevalueinfo[0]);
        //             string proName = ItemViewHelp.GetAttributeName(hideid);
        //             int showType = NumericHelp.GetNumericValueType(hideid);
        //             if (showType == 2)
        //             {
        //                 float hidevaluemin = float.Parse(hidevalueinfo[1]);
        //                 float hidevaluemax = float.Parse(hidevalueinfo[2]);
        //
        //                 (hidevaluemin, hidevaluemax) = ItemHelper.GetJingHeHideProRange(hidevaluemin, hidevaluemax, nowQua);
        //                 attribute = $"{proName}:" + (hidevaluemin * 100).ToString("0.##") + "~" + (hidevaluemax * 100).ToString("0.##") +
        //                         "%\n";
        //             }
        //             else
        //             {
        //                 int hidevaluemin = int.Parse(hidevalueinfo[1]);
        //                 int hidevaluemax = int.Parse(hidevalueinfo[2]);
        //                 (hidevaluemin, hidevaluemax) = ItemHelper.GetJingHeHideProRange(hidevaluemin, hidevaluemax, nowQua);
        //                 attribute = $"{proName}:" + hidevaluemin + "~" + hidevaluemax;
        //             }
        //         }
        //         // else if (addType == 2)
        //         // {
        //         //     string[] hidevalueinfo = attriinfos[1].Split(',');
        //         //     int hideid = int.Parse(hidevalueinfo[0]);
        //         //     SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideid);
        //         //     string skillName = skillConfig.SkillName;
        //         //     attribute = $"当前附加 {skillName}:"+"\n";
        //         // }
        //
        //         self.Lab_ItemJingHeProperty.GetComponent<Text>().text = attribute;
        //     }
        //
        //     self.Btn_Use.transform.Find("Text").GetComponent<Text>().text = itemconf.EquipType == 101? "开启封印" : "鉴定";
        //
        //     string ItemQuality = FunctionUI.GetInstance().ItemQualiytoPath(itemconf.ItemQuality);
        //     string path3 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality);
        //     Sprite sp3 = ResourcesComponent.Instance.LoadAsset<Sprite>(path3);
        //     if (!self.AssetPath.Contains(path3))
        //     {
        //         self.AssetPath.Add(path3);
        //     }
        //
        //     self.Obj_ItemQuality.GetComponent<Image>().sprite = sp3;
        //
        //     string Text_ItemStory = itemconf.ItemDes;
        //     //显示道具描述
        //     int i2 = (int)((Text_ItemStory.Length) / 20) + 1;
        //     //float ItemBottomTextNum = 30.0f;
        //
        //     self.Obj_BagOpenSet.SetActive(false);
        //     self.Obj_SaveStoreHouse.SetActive(false);
        //     self.Btn_TakeStoreHouse.SetActive(false);
        //     self.Obj_Btn_HuiShou.SetActive(false);
        //     self.Obj_Btn_HuiShouCancle.SetActive(false);
        //     self.Btn_JingHeAddQuality.SetActive(false);
        //     self.Btn_JingHeActivate.SetActive(false);
        //     self.Obj_Btn_XieXiaGemSet.SetActive(false);
        //
        //     //显示按钮
        //     switch ((ItemOperateEnum)equipTipsType)
        //     {
        //         //不显示任何按钮
        //         case ItemOperateEnum.None:
        //         case ItemOperateEnum.PaiMaiSell:
        //         case ItemOperateEnum.PaiMaiBuy:
        //             //ItemBottomTextNum = 0;
        //             break;
        //         //背包打开显示对应功能按钮
        //         case ItemOperateEnum.Bag:
        //             self.Obj_BagOpenSet.SetActive(true);
        //             self.Btn_TakeStoreHouse.SetActive(false);
        //             //判定当前是否打开仓库
        //             bool openHouse = false;
        //             if (openHouse)
        //             {
        //                 self.Obj_SaveStoreHouse.SetActive(true);
        //                 self.Obj_Diu.SetActive(false);
        //             }
        //             else
        //             {
        //                 self.Obj_SaveStoreHouse.SetActive(false);
        //                 self.Obj_Diu.SetActive(true);
        //             }
        //
        //             // 赛季晶核
        //             if (itemType == 3 && itemconf.EquipType == 201)
        //             {
        //                 self.Btn_Use.SetActive(false);
        //                 self.Btn_Sell.SetActive(false);
        //                 self.Btn_JingHeAddQuality.SetActive(true);
        //                 self.Btn_JingHeActivate.SetActive(true);
        //             }
        //
        //             break;
        //         //角色栏打开显示对应功能按钮
        //         case ItemOperateEnum.Juese:
        //             self.Obj_BagOpenSet.SetActive(true);
        //             self.Btn_TakeStoreHouse.SetActive(false);
        //             break;
        //         //商店查看属性
        //         case ItemOperateEnum.Shop:
        //             self.Obj_BagOpenSet.SetActive(false);
        //             //self.Obj_Btn_StoreHouseSet.SetActive(false);
        //             //ItemBottomTextNum = 0;
        //             break;
        //         //仓库查看属性
        //         case ItemOperateEnum.Cangku:
        //         case ItemOperateEnum.AccountCangku:
        //         case ItemOperateEnum.GemCangku:
        //             self.Obj_BagOpenSet.SetActive(false);
        //             self.Btn_TakeStoreHouse.SetActive(true);
        //             //self.Obj_Btn_StoreHouseSet.SetActive(true);
        //             //ItemBottomTextNum = 0;
        //             break;
        //         case ItemOperateEnum.CangkuBag:
        //         case ItemOperateEnum.AccountBag:
        //             self.Obj_BagOpenSet.SetActive(true);
        //             self.Obj_SaveStoreHouse.SetActive(true);
        //             self.Btn_Sell.SetActive(false);
        //             self.Btn_Use.SetActive(false);
        //             break;
        //         //回收背包打开
        //         case ItemOperateEnum.HuishouBag:
        //             self.Obj_BagOpenSet.SetActive(true);
        //             //self.Obj_Btn_StoreHouseSet.SetActive(false);
        //             self.Obj_SaveStoreHouse.SetActive(false);
        //             self.Obj_Btn_HuiShou.SetActive(true);
        //             self.Btn_Sell.SetActive(false);
        //             self.Btn_Use.SetActive(false);
        //             break;
        //         //回收功能显示
        //         case ItemOperateEnum.HuishouShow:
        //             self.Obj_BagOpenSet.SetActive(false);
        //             //self.Obj_Btn_StoreHouseSet.SetActive(false);
        //             self.Obj_Btn_HuiShouCancle.SetActive(true);
        //             self.Obj_SaveStoreHouse.SetActive(false);
        //             break;
        //         //牧场  不显示任何按钮
        //         case ItemOperateEnum.Muchang:
        //             //ItemBottomTextNum = 0;
        //             break;
        //         //牧场仓库  显示出售按钮
        //         case ItemOperateEnum.MuchangCangku:
        //             self.Obj_BagOpenSet.SetActive(true);
        //             //self.Obj_Btn_StoreHouseSet.SetActive(false);
        //             self.Obj_SaveStoreHouse.SetActive(false);
        //             self.Obj_Diu.SetActive(true);
        //             break;
        //         default:
        //             //ItemBottomTextNum = 0;
        //             break;
        //     }
        //
        //     //判定道具为宝石时显示使用变为镶嵌字样
        //     /*
        //     if (itemType == 4)
        //     {
        //         string langStr_A = GameSettingLanguge.LoadLocalization("镶 嵌");
        //         self.Obj_Btn_GemHoleText.GetComponent<Text>().text = langStr_A;
        //     }
        //     */
        //     //设置底的长度
        //     //self.ItemDi.GetComponent<RectTransform>().sizeDelta = new Vector2(301.0f, 180.0f + i1 * 20.0f + i2 * 16.0f + ItemBottomTextNum);
        //
        //     //显示道具信息
        //     self.Lab_ItemName.GetComponent<Text>().text = itemconf.ItemName;
        //     self.Lab_ItemSubType.GetComponent<Text>().text = equipType;
        //     self.Lab_ItemName.GetComponent<Text>().color = FunctionUI.GetInstance().QualityReturnColor(itemconf.ItemQuality);
        //     float exceedWidth = self.Lab_ItemName.GetComponent<Text>().preferredWidth - self.Lab_ItemNameWidth;
        //     if (exceedWidth > -20)
        //     {
        //         self.Img_back.GetComponent<RectTransform>().sizeDelta =
        //                 new Vector2(self.Img_backVector2.x + exceedWidth + 30, self.Img_backVector2.y);
        //     }
        //
        //     string langStr = GameSettingLanguge.LoadLocalization("等级");
        //     if (itemconf.UseLv > 0)
        //     {
        //         self.ItemItemLv.GetComponent<Text>().text = langStr + ":" + itemconf.UseLv;
        //
        //         if (itemconf.UseLv > self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Lv)
        //         {
        //             self.ItemItemLv.GetComponent<Text>().text = langStr + " : " + itemconf.UseLv;
        //             //self.ItemItemLv.GetComponent<Text>().text = langStr + " : " + itemconf.UseLv + " (等级不足)";
        //             self.ItemItemLv.GetComponent<Text>().color = new Color(255f / 255f, 200f / 255f, 200f / 255f);
        //         }
        //     }
        //     else
        //     {
        //         self.ItemItemLv.GetComponent<Text>().text = langStr + ":1";
        //     }
        // }

        private static async ETTask OnSellButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnUseButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnHuiShouButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnHuiShouCancleButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnJingHeAddQualityButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnJingHeActivateButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSaveStoreHouseButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTakeStoreHouseButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }
    }
}