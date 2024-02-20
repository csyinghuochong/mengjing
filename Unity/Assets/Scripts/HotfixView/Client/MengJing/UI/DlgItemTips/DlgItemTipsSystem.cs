using System.Collections;
using System.Collections.Generic;
using System;
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
        }

        public static void ShowWindow(this DlgItemTips self, Entity contextData = null)
        {
            self.Img_backVector2 = self.View.E_BGImage.GetComponent<RectTransform>().sizeDelta;
            self.Lab_ItemNameWidth = self.View.E_ItemNameText.GetComponent<RectTransform>().sizeDelta.x;
        }

        public static void SetPosition(this DlgItemTips self, Vector2 vector2)
        {
            self.View.uiTransform.GetComponent<RectTransform>().anchoredPosition = vector2;
        }

        public static void RefreshInfo(this DlgItemTips self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum)
        {
            self.BagInfo = bagInfo;
            ItemConfig itemconf = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int itemType = itemconf.ItemType;
            int itemSubType = itemconf.ItemSubType;

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string qualityiconLine = FunctionUI.ItemQualityLine(itemconf.ItemQuality);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconLine);
            Sprite sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.View.E_QualityLineImage.sprite = sprite;

            string qualityiconBack = FunctionUI.ItemQualityBack(itemconf.ItemQuality);
            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconBack);
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.View.E_QulityBgImage.sprite = sprite;

            // 类型描述
            string itemTypename = "消耗品";
            ItemViewHelp.ItemTypeName.TryGetValue(itemType, out itemTypename);
            if (itemType == 1 && itemSubType == 131)
            {
                itemTypename = "家园烹饪";
            }

            self.View.E_ItemTypeText.text = "类型:" + itemTypename;

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
                    itemMiaoShu = itemMiaoShu + "\n" + itemDesArray[i];
                }
            }

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

            // 数组大于2表示有换行符,否则显示原来的描述
            if (itemDesArray.Length >= 2)
            {
                Text_ItemDes = itemMiaoShu;
            }

            // 根据Tips描述长度缩放底的大小
            int i1 = 0;
            Text_ItemDes = ItemViewHelp.GetItemDesc(bagInfo, ref i1);

            // 道具Icon
            string ItemIcon = itemconf.Icon;
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemIcon));
            self.View.E_ItemIconImage.sprite = sprite;
            string ItemQuality = FunctionUI.ItemQualiytoPath(itemconf.ItemQuality);
            sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality));
            self.View.E_ItemQualityImage.sprite = sprite;

            // 显示按钮
            self.View.E_UseButton.GetComponentInChildren<Text>().text = itemconf.ItemSubType == 114? "镶嵌" : "使用";
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
            switch (itemOperateEnum)
            {
                // 不显示任何按钮
                case ItemOperateEnum.None:
                case ItemOperateEnum.PaiMaiSell:
                case ItemOperateEnum.PaiMaiBuy:
                    //ItemBottomTextNum = 0;
                    break;
                case ItemOperateEnum.JianYuanBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
                    self.View.E_SplitButton.gameObject.SetActive(false);
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
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
                    //ItemBottomTextNum = 0;
                    break;
                // 仓库查看属性
                case ItemOperateEnum.Cangku:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
                    self.View.E_PutBagButton.gameObject.SetActive(true);
                    //ItemBottomTextNum = 0;
                    break;
                case ItemOperateEnum.GemCangku:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
                    self.View.E_PutBagButton.gameObject.SetActive(true);
                    break;
                case ItemOperateEnum.GemBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_StoreHouseButton.gameObject.SetActive(true);
                    self.View.E_UseButton.gameObject.SetActive(false);
                    break;
                case ItemOperateEnum.CangkuBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_StoreHouseButton.gameObject.SetActive(true);
                    self.View.E_UseButton.gameObject.SetActive(false);
                    break;
                // 回收背包打开
                case ItemOperateEnum.HuishouBag:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                    self.View.E_HuiShouButton.gameObject.SetActive(true);
                    break;
                // 回收功能显示
                case ItemOperateEnum.HuishouShow:
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
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
                    self.View.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
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

            // 宠物蛋附灵
            if (itemType == 1 && itemSubType == 102 && self.BagInfo.FuLing == 1)
            {
                self.View.E_FuLingText.gameObject.SetActive(true);
                // self.Lab_FuLing.GetComponent<Text>().color = new Color(175f / 255f, 1, 6f / 255f);
                self.View.E_FuLingDesText.gameObject.SetActive(true);
                // self.Lab_FuLingDes.GetComponent<Text>().color = new Color(175f / 255f, 1, 6f / 255f);
            }

            //判定道具为宝石时显示使用变为镶嵌字样
            if (itemType == 4)
            {
                string langStr_A = GameSettingLanguge.LoadLocalization("镶 嵌");
                //self.Obj_Btn_GemHoleText.GetComponent<Text>().text = langStr_A;
            }

            //设置底的长度
            //self.ItemDi.GetComponent<RectTransform>().sizeDelta = new Vector2(301.0f, 180.0f + i1 * 20.0f + i2 * 16.0f + ItemBottomTextNum);
            //显示道具信息
            self.View.E_ItemNameText.text = itemconf.ItemName;
            self.View.E_ItemNameText.color = FunctionUI.QualityReturnColor(itemconf.ItemQuality);
            self.View.E_ItemDesText.text = Text_ItemDes;
            //赞助宝箱设置描述为绿色
            //if (itemSubType == 9)
            //{
            //    self.ItemDes.GetComponent<Text>().color = Color.green;
            //}
            float exceedWidth = self.View.E_ItemNameText.preferredWidth - self.Lab_ItemNameWidth;
            if (exceedWidth > -20)
            {
                self.View.E_PutBagImage.GetComponent<RectTransform>().sizeDelta =
                        new Vector2(self.Img_backVector2.x + exceedWidth + 30, self.Img_backVector2.y);
            }

            //鉴定品质符
            if (itemconf.ItemSubType == 121)
            {
                self.View.E_ItemDesText.GetComponent<Text>().text = Text_ItemDes + "\n" + "\n" + $"鉴定符品质:{bagInfo.ItemPar}" + "\n" +
                        "品质越高,鉴定出极品的概率越高。" + "\n" +
                        "鉴定符品质与制造者熟练度相关。";
            }

            //鉴定品质符
            if (itemconf.ItemType == 1 && itemconf.ItemSubType == 131)
            {
                string[] addList = itemconf.ItemUsePar.Split(';')[0].Split(',');
                self.View.E_ItemDesText.GetComponent<Text>().text = Text_ItemDes + "\n" + "\n" + "烹饪品质:" + bagInfo.ItemPar;
            }

            //宠物技能
            if (itemconf.ItemType == 2 && itemconf.ItemSubType == 122)
            {
                SkillConfig skillCof = SkillConfigCategory.Instance.Get(int.Parse(itemconf.ItemUsePar));
                self.View.E_ItemDesText.GetComponent<Text>().text = Text_ItemDes + "\n" + "\n" + $"技能描述:{skillCof.SkillDescribe}";
            }

            //藏宝图
            if (itemconf.ItemSubType == 127 && !string.IsNullOrEmpty(self.BagInfo.ItemPar))
            {
                int sceneID = int.Parse(self.BagInfo.ItemPar.Split('@')[0]);
                self.View.E_ItemDesText.GetComponent<Text>().text =
                        $"{itemconf.ItemDes}\n前往地图:{DungeonConfigCategory.Instance.Get(sceneID).ChapterName}开启藏宝图!";
            }

            string langStr = GameSettingLanguge.LoadLocalization("使用等级");
            if (itemconf.UseLv > 0)
            {
                self.View.E_ItemLvText.text = langStr + ":" + itemconf.UseLv;
            }
            else
            {
                self.View.E_ItemLvText.text = langStr + ":1";
            }
        }
    }
}