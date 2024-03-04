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

        public static void InitData(this ES_EquipTips self, BagInfo baginfo, ItemOperateEnum equipTipsType, int occTwoValue,
        List<BagInfo> equipItemList)
        {
            self.BagInfo = baginfo;
            self.ItemOpetateType = equipTipsType;
            ItemConfig itemconf = ItemConfigCategory.Instance.Get(baginfo.ItemID);
            if (itemconf.ItemEquipID == 0)
            {
                return;
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string qualityiconLine = FunctionUI.ItemQualityLine(itemconf.ItemQuality);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconLine);
            Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.E_QualityLineImage.sprite = sp;

            string qualityiconBack = FunctionUI.ItemQualityBack(itemconf.ItemQuality);
            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconBack);
            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            self.E_QualityBgImage.sprite = sp;

            self.ShowBaseAttribute();
            self.ZhuanJingStatus(occTwoValue, itemconf, baginfo);
        }

        private static void ShowBaseAttribute(this ES_EquipTips self)
        {
            ItemConfig itemconf = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            string ItemIcon = itemconf.Icon;
            int ItemQuality = itemconf.ItemQuality;
            string equip_ID = itemconf.ItemEquipID.ToString();
            string equipName = itemconf.ItemName;
            string equipLv = itemconf.UseLv.ToString();
            string ItemBlackDes = itemconf.ItemDes;
            string textEquipType = "";
            string textEquipTypeSon = "";
            textEquipType = ItemViewHelp.GetItemSubType3Name(itemconf.ItemSubType);
            textEquipTypeSon = self.GetEquipType(itemconf.EquipType);
            textEquipType = GameSettingLanguge.LoadLocalization(textEquipType);

            // 生肖处理
            if (itemconf.EquipType == 101)
            {
                textEquipType = self.GetEquipShengXiaoType(itemconf.ItemSubType % 100);
                textEquipTypeSon = GameSettingLanguge.LoadLocalization("生肖");
            }

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
            if (itemconf.ItemType == 3 && (itemconf.EquipType == 101 || itemconf.EquipType == 201))
            {
                self.E_EquipQiangHuaText.gameObject.SetActive(false);
            }

            // 显示是否绑定
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

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemIcon);
            Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            self.E_EquipIconImage.sprite = sp;
            string qualityiconStr = FunctionUI.ItemQualiytoPath(ItemQuality);
            Log.Info("qualityiconStr = " + qualityiconStr);

            path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            self.E_EquipQualityImage.sprite = sp;

            //显示基础信息
            self.E_EquipNameText.text = equipName;
            self.E_EquipNameText.color = FunctionUI.QualityReturnColor(ItemQuality);
            float exceedWidth = self.E_EquipNameText.preferredWidth - self.E_EquipNameText.transform.GetComponent<RectTransform>().sizeDelta.x;
            if (exceedWidth > 0)
            {
                Vector2 vector2 = self.E_BackImage.GetComponent<RectTransform>().sizeDelta;
                self.E_BackImage.GetComponent<RectTransform>().sizeDelta = new Vector2(vector2.x + exceedWidth, vector2.y);
            }

            string langStr = GameSettingLanguge.LoadLocalization("部位");
            self.E_EquipTypeText.text = langStr + ":" + textEquipType;
            langStr = GameSettingLanguge.LoadLocalization("类型");
            self.E_EquipTypeSonText.text = langStr + ":" + textEquipTypeSon;

            int occTwo = self.Root().GetComponent<UserInfoComponentClient>().UserInfo.OccTwo;
            if (occTwo != 0)
            {
                OccupationTwoConfig occupationTwo = OccupationTwoConfigCategory.Instance.Get(occTwo);
                if (itemconf.EquipType != 0 && itemconf.EquipType != occupationTwo.ArmorMastery)
                {
                    self.E_EquipTypeSonText.color = new Color(248f / 255f, 148f / 255f, 148f / 255f);
                    //self.Obj_EquipTypeSon.GetComponent<Text>().text = self.Obj_EquipTypeSon.GetComponent<Text>().text + "(类型不符)";
                }
            }

            langStr = GameSettingLanguge.LoadLocalization("等级");
            self.E_EquipNeedLvText.text = langStr + " : " + equipLv;

            if (int.Parse(equipLv) > self.Root().GetComponent<UserInfoComponentClient>().UserInfo.Lv)
            {
                self.E_EquipNeedLvText.text = langStr + " : " + equipLv + " (等级不足)";
                self.E_EquipNeedLvText.color = new Color(255f / 255f, 200f / 255f, 200f / 255f);
            }

            string propertyLimit = "";
            string[] needProperty = propertyLimit.Split(',');
            if (needProperty[0] != "" && needProperty[0] != "0")
            {
                string propertyName = FunctionUI.ReturnEquipNeedPropertyName(needProperty[0]);
                string langStr_1 = GameSettingLanguge.LoadLocalization("需要");
                string langStr_2 = GameSettingLanguge.LoadLocalization("达到");
                string langStr_4 = GameSettingLanguge.LoadLocalization(propertyName);
                self.E_EquipNeedProText.text = langStr_1 + langStr_4 + langStr_2 + " ： " + needProperty[1];

                switch (needProperty[0])
                {
                    case "1":
                        int value = 0;
                        if (value < int.Parse(needProperty[1]))
                        {
                            string langStr_3 = GameSettingLanguge.LoadLocalization("攻击力不足");
                            self.E_EquipNeedProText.text = langStr_1 + langStr_4 + langStr_2 + " ：" + needProperty[1] +
                                    "<color=#ff0000ff>  (" + langStr_3 + ")</color>";
                        }

                        break;
                }

                self.E_EquipNeedProText.gameObject.SetActive(true);
            }
            else
            {
                self.E_EquipNeedProText.gameObject.SetActive(false);
            }

            int ItemBlackNum = 0;
            if (ItemBlackDes != "0" && ItemBlackDes != "")
            {
                ItemBlackNum = (ItemBlackDes.Length - 16) / 16 + 1;
            }
            else
            {
                self.EG_EquipBottomRectTransform.gameObject.SetActive(false);
            }

            if (ItemBlackDes.Length > 32)
            {
                ItemBlackNum = (ItemBlackDes.Length - 32) / 16 + 1;
                self.E_EquipDesText.GetComponent<RectTransform>().sizeDelta = new Vector2(240.0f, 40.0f + 16.0f * ItemBlackNum);
                self.E_EquipDesText.text = ItemBlackDes;
            }

            // 显示制造方
            self.E_EquipMakeText.text = !string.IsNullOrEmpty(self.BagInfo.MakePlayer)? $"由<color=#805100>{self.BagInfo.MakePlayer}</color>打造" : "";
        }

        private static void ZhuanJingStatus(this ES_EquipTips self, int occTwoValue, ItemConfig itemconf, BagInfo baginfo)
        {
            if (occTwoValue != 0)
            {
                if (itemconf.EquipType == 11 || itemconf.EquipType == 12 || itemconf.EquipType == 13 && baginfo.Loc == (int)ItemLocType.ItemLocEquip)
                {
                    self.E_ZhuanJingStatusDesText.gameObject.SetActive(true);
                    int selfMastery = OccupationTwoConfigCategory.Instance.Get(occTwoValue).ArmorMastery;
                    if (selfMastery == itemconf.EquipType)
                    {
                        //occShowStr = "         (护甲专精+20%)";
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