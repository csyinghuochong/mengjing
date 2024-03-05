using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
    [EntitySystemOf(typeof (ES_EquipTips))]
    [FriendOfAttribute(typeof (ES_EquipTips))]
    public static partial class ES_EquipTipsSystem
    {
        [EntitySystem]
        private static void Awake(this ES_EquipTips self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_UseButton.AddListenerAsync(self.OnUseButton);
            self.E_TakeoffButton.AddListenerAsync(self.OnTakeoffButton);
            self.E_SellButton.AddListenerAsync(self.OnSellButton);
            self.E_HuiShouFangZhiButton.AddListenerAsync(self.OnHuiShouFangZhiButton);
            self.E_TakeButton.AddListenerAsync(self.OnTakeButton);
            self.E_SaveStoreHouseButton.AddListenerAsync(self.OnSaveStoreHouseButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipTips self)
        {
            self.DestroyWidget();
        }

        public static void InitData(this ES_EquipTips self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum, int occTwoValue,
        List<BagInfo> equipItemList)
        {
            self.BagInfo = bagInfo;
            self.ItemOpetateType = itemOperateEnum;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemEquipID == 0)
            {
                return;
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            // 背部
            string qualityiconLine = FunctionUI.ItemQualityLine(itemConfig.ItemQuality);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconLine);
            Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.E_QualityLineImage.sprite = sp;
            string qualityiconBack = FunctionUI.ItemQualityBack(itemConfig.ItemQuality);
            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconBack);
            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.E_QualityBgImage.sprite = sp;

            // 道具Icon
            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.E_EquipIconImage.sprite = sp;
            string qualityiconStr = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.E_EquipQualityImage.sprite = sp;

            // 道具名字
            self.E_EquipNameText.text = itemConfig.ItemName;
            self.E_EquipNameText.color = FunctionUI.QualityReturnColor(itemConfig.ItemQuality);
            float exceedWidth = self.E_EquipNameText.preferredWidth - self.E_EquipNameText.transform.GetComponent<RectTransform>().sizeDelta.x;
            if (exceedWidth > 0)
            {
                Vector2 vector2 = self.E_BackImage.GetComponent<RectTransform>().sizeDelta;
                self.E_BackImage.GetComponent<RectTransform>().sizeDelta = new Vector2(vector2.x + exceedWidth, vector2.y);
            }

            // 部位、类型
            string textEquipType = GameSettingLanguge.LoadLocalization(ItemViewHelp.GetItemSubType3Name(itemConfig.ItemSubType));
            string textEquipTypeSon = self.GetEquipType(itemConfig.EquipType);
            if (itemConfig.EquipType == 101) // 生肖
            {
                textEquipType = self.GetEquipShengXiaoType(itemConfig.ItemSubType % 100);
                textEquipTypeSon = GameSettingLanguge.LoadLocalization("生肖");
            }

            self.E_EquipTypeText.text = GameSettingLanguge.LoadLocalization("部位") + ":" + textEquipType;
            self.E_EquipTypeSonText.text = GameSettingLanguge.LoadLocalization("类型") + ":" + textEquipTypeSon;

            int occTwo = self.Root().GetComponent<UserInfoComponentClient>().UserInfo.OccTwo;
            if (occTwo != 0)
            {
                OccupationTwoConfig occupationTwo = OccupationTwoConfigCategory.Instance.Get(occTwo);
                if (itemConfig.EquipType != 0 && itemConfig.EquipType != occupationTwo.ArmorMastery)
                {
                    self.E_EquipTypeSonText.color = new Color(248f / 255f, 148f / 255f, 148f / 255f);
                    self.E_EquipTypeSonText.text = "(类型不符)";
                }
            }

            // 使用等级
            if (itemConfig.UseLv > self.Root().GetComponent<UserInfoComponentClient>().UserInfo.Lv)
            {
                self.E_EquipNeedLvText.text = GameSettingLanguge.LoadLocalization("等级") + " : " + itemConfig.UseLv + " (等级不足)";
                self.E_EquipNeedLvText.color = new Color(255f / 255f, 200f / 255f, 200f / 255f);
            }
            else
            {
                self.E_EquipNeedLvText.text = GameSettingLanguge.LoadLocalization("等级") + " : " + itemConfig.UseLv;
            }

            // 绑定
            if (self.BagInfo.isBinging)
            {
                self.E_EquipBangDingText.text = GameSettingLanguge.LoadLocalization("已绑定");
                self.E_EquipBangDingText.color = new Color(175f / 255f, 1, 6f / 255f);
                self.E_EquipBangDingText.gameObject.SetActive(true);
            }
            else
            {
                self.E_EquipBangDingText.text = GameSettingLanguge.LoadLocalization("未绑定");
                self.E_EquipBangDingText.color = new Color(255f / 255f, 240f / 255f, 200f / 255f);
                self.E_EquipBangDingText.gameObject.SetActive(false);
            }

            // 强化
            // string langStr = GameSettingLanguge.LoadLocalization("强化");
            // int qianghuaLevel = self.Root().GetComponent<BagComponentClient>().GetQiangHuaLevel(itemconf.ItemSubType);
            // if (qianghuaLevel != 0)
            // {
            //     self.E_EquipQiangHuaText.text = "+" + qianghuaLevel + langStr;
            // }
            // else
            // {
            //     self.E_EquipQiangHuaText.text = "+" + 0 + langStr;
            // }

            // 生肖和晶核不显示强化
            // if (itemConfig.ItemType == 3 && (itemConfig.EquipType == 101 || itemConfig.EquipType == 201))
            // {
            //     self.E_EquipQiangHuaText.gameObject.SetActive(false);
            // }

            // 道具描述
            if (string.IsNullOrEmpty(itemConfig.ItemDes))
            {
                self.EG_EquipBottomRectTransform.gameObject.SetActive(false);
            }

            if (itemConfig.ItemDes.Length > 32)
            {
                int line = (itemConfig.ItemDes.Length - 32) / 16 + 1;
                self.E_EquipDesText.GetComponent<RectTransform>().sizeDelta = new Vector2(240.0f, 40.0f + 16.0f * line);
            }

            self.E_EquipDesText.text = itemConfig.ItemDes;

            // 制造方
            self.E_EquipMakeText.text = !string.IsNullOrEmpty(self.BagInfo.MakePlayer)? $"由<color=#805100>{self.BagInfo.MakePlayer}</color>打造" : "";

            // 专精
            if (occTwoValue != 0)
            {
                if (itemConfig.EquipType == 11 || itemConfig.EquipType == 12 ||
                    itemConfig.EquipType == 13 && bagInfo.Loc == (int)ItemLocType.ItemLocEquip)
                {
                    self.E_ZhuanJingStatusDesText.gameObject.SetActive(true);
                    if (itemConfig.EquipType == OccupationTwoConfigCategory.Instance.Get(occTwoValue).ArmorMastery)
                    {
                        self.E_ZhuanJingStatusDesText.text = "已激活护甲专精";
                        self.E_ZhuanJingStatusDesText.color = new Color(0.52f, 0.75f, 0);
                        self.E_ZhuanJingStatusImgImage.gameObject.SetActive(true);
                    }
                    else
                    {
                        self.E_ZhuanJingStatusDesText.text = "未激活护甲专精";
                        self.E_ZhuanJingStatusDesText.color = new Color(0.58f, 0.58f, 0.58f);
                        self.E_ZhuanJingStatusImgImage.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                self.E_ZhuanJingStatusDesText.text = "转职后激活护甲专精";
                self.E_ZhuanJingStatusDesText.color = new Color(0.58f, 0.58f, 0.58f);
                self.E_ZhuanJingStatusImgImage.gameObject.SetActive(false);
            }

            // 按钮
            self.EG_BagOpenSetRectTransform.gameObject.SetActive(false);
            self.EG_RoseEquipOpenSetRectTransform.gameObject.SetActive(false);
            self.E_StoreHouseSetButton.gameObject.SetActive(false);
            self.E_SaveStoreHouseButton.gameObject.SetActive(false);
            self.E_HuiShouFangZhiButton.gameObject.SetActive(false);
            self.E_TakeButton.gameObject.SetActive(false);
            switch (self.ItemOpetateType)
            {
                case ItemOperateEnum.None:
                case ItemOperateEnum.PaiMaiSell:
                case ItemOperateEnum.PetHeXinBag:
                case ItemOperateEnum.PaiMaiBuy:
                case ItemOperateEnum.PetEquipBag:
                case ItemOperateEnum.Bag:
                    bool StoreHouseStatus = false;
                    if (StoreHouseStatus)
                    {
                        self.E_SaveStoreHouseButton.gameObject.SetActive(true);
                        // self.Obj_Diu.SetActive(false);
                    }
                    else
                    {
                        self.E_SaveStoreHouseButton.gameObject.SetActive(false);
                        // self.Obj_Diu.SetActive(true);
                    }

                    // 赛季晶核
                    if (itemConfig.ItemType == 3 && itemConfig.EquipType == 201)
                    {
                        self.E_EquipMakeText.gameObject.SetActive(false);
                        self.E_UseButton.gameObject.SetActive(false);
                        Vector3 localPosition = self.E_SellButton.GetComponent<RectTransform>().localPosition;
                        localPosition.x = 0;
                        self.E_SellButton.GetComponent<RectTransform>().localPosition = localPosition;
                    }

                    break;
                case ItemOperateEnum.XiangQianBag:
                    break;
                case ItemOperateEnum.Juese:
                    // self.Obj_RoseEquipOpenSet.SetActive(true);
                    break;
                case ItemOperateEnum.Shop:
                    // self.Obj_RoseEquipOpenSet.SetActive(false);
                    break;
                case ItemOperateEnum.Cangku:
                case ItemOperateEnum.GemCangku:
                case ItemOperateEnum.AccountCangku:
                    self.E_StoreHouseSetButton.gameObject.SetActive(true);
                    break;
                case ItemOperateEnum.CangkuBag:
                case ItemOperateEnum.AccountBag:
                    self.E_SaveStoreHouseButton.gameObject.SetActive(true);
                    break;
                case ItemOperateEnum.MailReward:
                    break;
                case ItemOperateEnum.Watch:

                    break;
                case ItemOperateEnum.HuishouBag:
                    self.E_HuiShouFangZhiButton.gameObject.SetActive(true);
                    break;
                case ItemOperateEnum.HuishouShow:
                    self.E_TakeButton.gameObject.SetActive(true);
                    break;
                case ItemOperateEnum.MakeItem:
                    break;
            }

            //基础属性  专精属性  隐藏技能  套装属性
            // 基础属性
            // int properShowNum =
            //         ItemViewHelp.ShowBaseAttribute(equipItemList, bagInfo, self.E_EquipPropertyTextText.gameObject, self.EquipBaseSetList);
            //
            // //显示宝石
            // float startPostionY = 0 - self.TitleBigHeight_160 - self.TitleMiniHeight_50 - self.TextItemHeight_40 * properShowNum;
            // Vector2 equipNeedvec2 = new Vector2(155.5f, startPostionY);
            // self.Obj_UIEquipGemHoleSet.transform.GetComponent<RectTransform>().anchoredPosition = equipNeedvec2;
            // float gemHoleShowHeight = self.ShowGemList() * 35f;
            //
            // //显示专精属性
            // startPostionY -= gemHoleShowHeight;
            // startPostionY -= 5;
            // int zhunjingNumber = self.ShowZhuanJingAttribute(itemconf, startPostionY);
            //
            // //显示隐藏技能
            // //float HintTextNum = 50;
            // startPostionY -= (zhunjingNumber > 0? self.TitleMiniHeight_50 : 0);
            // startPostionY = startPostionY - zhunjingNumber * self.TextItemHeight_40;
            // startPostionY -= 5;
            // int hideSkillNumber = self.ShowHideSkill(itemconf, startPostionY);
            //
            // //显示装备套装信息
            // //float equipSuitTextNum = 0;
            // startPostionY -= (hideSkillNumber > 0? self.TitleMiniHeight_50 : 0);
            // startPostionY -= hideSkillNumber * self.TextItemHeight_40;
            //
            // int suitEquipNumber = self.ShowSuitEquipInfo(itemconf, equipconf.EquipSuitID, startPostionY, equipItemList);
            // suitEquipNumber = suitEquipNumber + (suitEquipNumber > 0? 2 : 0);
            // startPostionY = startPostionY - self.TitleMiniHeight_50 - suitEquipNumber * self.TextItemHeight_40;
            // startPostionY -= 5;
            //
            // float DiHight = startPostionY * -1 + 70;
            // if (DiHight > self.Img_backVector2.y)
            // {
            //     self.Img_back.GetComponent<RectTransform>().sizeDelta = new Vector2(self.Img_backVector2.x, DiHight);
            // }
            //
            // if (DiHight > 1150)
            // {
            //     float height = (DiHight - 1098f) * 0.5f;
            //     self.Obj_BtnSet.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height);
            // }
            // else
            // {
            //     self.Obj_BtnSet.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            // }

            //显示装备制造者的名字[名字直接放入baginfo]
        }

        //获取装备子类型名称
        private static string GetEquipType(this ES_EquipTips self, int type)
        {
            switch (type)
            {
                case 0:
                    return "首饰";

                case 1:
                    return "剑";

                case 2:
                    return "刀";

                case 3:
                    return "法杖";

                case 4:
                    return "魔法书";

                case 11:
                    return "布甲";

                case 12:
                    return "轻甲";

                case 13:
                    return "重甲";

                case 99:
                    return "无限制";
            }

            return "";
        }

        //获取装备子类型名称
        private static string GetEquipShengXiaoType(this ES_EquipTips self, int type)
        {
            switch (type)
            {
                case 1:
                    return "鼠";

                case 2:
                    return "牛";

                case 3:
                    return "虎";

                case 4:
                    return "兔";

                case 5:
                    return "龙";

                case 6:
                    return "蛇";

                case 7:
                    return "马";

                case 8:
                    return "羊";

                case 9:
                    return "猴";

                case 10:
                    return "鸡";

                case 11:
                    return "狗";

                case 12:
                    return "猪";
            }

            return "";
        }

        private static async ETTask OnUseButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTakeoffButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSellButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSaveStoreHouseButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnHuiShouFangZhiButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTakeButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }
    }
}