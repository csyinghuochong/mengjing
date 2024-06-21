using System;
using System.Collections.Generic;
using ET;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public static class ItemViewHelp
    {
        public static string GetAttributeDesc(List<PropertyValue> hideProLists)
        {
            string desc = "";
            for (int i = 0; i < hideProLists.Count; i++)
            {
                desc += $"{hideProLists[i].HideID} {hideProLists[i].HideValue}  ";
            }

            return desc;
        }

        public static string ReturnNumStr(long num)
        {
            if (num < 10000)
            {
                return num.ToString();
            }

            return (num / 10000.0f).ToString("0.##") + "万";
        }

        public static void AccountCangkuPutIn(Scene root, BagInfo bagInfo)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemType == 3 && itemConfig.EquipType < 100 && !bagInfo.isBinging)
            {
                DlgWarehouse dlgWarehouse = root.GetComponent<UIComponent>().GetDlgLogic<DlgWarehouse>();
                dlgWarehouse.View.ES_WarehouseAccount.BagInfoPutIn = bagInfo;
                BagClientNetHelper.RequestAccountWarehousOperate(root, 1, bagInfo.BagInfoID).Coroutine();
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTipDi("只能存放非绑定的角色装备！");
            }
        }

        public static string XiLianWeiZhiTip(int hideId)
        {
            string tip = string.Empty;
            HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hideId);
            int[] spaces = hideProListConfig.EquipSpace;
            if (spaces == null)
            {
                return tip;
            }

            tip += "\n\r";
            tip += "<color=#ACFF23FF>此属性可出现的装备部位：\n";

            for (int i = 0; i < spaces.Length; i++)
            {
                tip += GetItemSubType3Name(spaces[i]) + "、";
            }

            tip = tip.Substring(0, tip.Length - 1);

            tip += "</color>";
            return tip;
        }

        public static string ShowDuiHuanPet(int configId)
        {
            GlobalValueConfig globalValue = GlobalValueConfigCategory.Instance.Get(configId);
            string[] configInfo = globalValue.Value.Split('@');
            string[] iteminfo = configInfo[0].Split(';');

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(iteminfo[0]));
            PetConfig petConfig = PetConfigCategory.Instance.Get(int.Parse(configInfo[1]));
            string info = $"消耗{itemConfig.ItemName}X{iteminfo[1]}兑换{petConfig.PetName}";
            return info;
        }

        public static string GetAttributeIcon(int numberType)
        {
            NumericAttribute numericAttribute;
            ItemViewData.AttributeToName.TryGetValue(numberType, out numericAttribute);
            string icon = numericAttribute.Icon;
            if (string.IsNullOrEmpty(icon) && numberType > NumericType.Max)
            {
                return GetAttributeIcon(numberType / 100);
            }

            return numericAttribute.Icon;
        }

        public static string GetProName(int proID)
        {
            if (proID >= 10000)
            {
                proID = (int)(proID / 100);
            }

            string returnName = "";

            switch (proID)
            {
                case 1002:
                    returnName = "血量";
                    break;
                case 1003:
                    returnName = "最低攻击";
                    break;
                case 1004:
                    returnName = "最高攻击";
                    break;
                case 1005:
                    returnName = "最低防御";
                    break;
                case 1006:
                    returnName = "最高防御";
                    break;
                case 1007:
                    returnName = "最低魔防";
                    break;
                case 1008:
                    returnName = "最高魔防";
                    break;

                case 1051:
                    returnName = "力量";
                    break;

                case 1052:
                    returnName = "敏捷";
                    break;

                case 1053:
                    returnName = "智力";
                    break;

                case 1054:
                    returnName = "耐力";
                    break;

                case 1055:
                    returnName = "体质";
                    break;
            }

            return returnName;
        }

        //装备基础属性
        public static int ShowBaseAttribute(List<BagInfo> equipItemList, BagInfo baginfo, GameObject propertyGO,
        GameObject parentGO)
        {
            int properShowNum = 0;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(baginfo.ItemID);

            // 赛季晶核
            if (itemConfig.ItemType == 3 && itemConfig.EquipType == 201)
            {
                string showColor = "1";
                if (baginfo.XiLianHideProLists != null)
                {
                    foreach (HideProList hideProList in baginfo.XiLianHideProLists)
                    {
                        if (hideProList.HideID == 0) continue;
                        string attribute = "";
                        string proName = ItemViewHelp.GetAttributeName(hideProList.HideID);
                        int showType = NumericHelp.GetNumericValueType(hideProList.HideID);
                        if (showType == 2)
                        {
                            attribute = $"当前附加 {proName}:" + (hideProList.HideValue / 100f).ToString("0.##") + "%";
                        }
                        else
                        {
                            attribute = $"当前附加 {proName}:" + hideProList.HideValue;
                        }

                        ShowPropertyText(attribute, showColor, propertyGO, parentGO);
                        properShowNum += 1;
                    }
                }

                if (baginfo.HideSkillLists != null)
                {
                    for (int i = 0; i < baginfo.HideSkillLists.Count; i++)
                    {
                        int skillID = baginfo.HideSkillLists[i];
                        SkillConfig skillCof = SkillConfigCategory.Instance.Get(skillID);
                        string proStr = "当前附加技能" + ":" + skillCof.SkillName;
                        ShowPropertyText(proStr, "2", propertyGO, parentGO);
                        properShowNum += 1;
                    }
                }
            }

            EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemConfig.ItemEquipID);
            int equip_Hp = equipConfig.Equip_Hp;
            int equip_MinAct = equipConfig.Equip_MinAct;
            int equip_MaxAct = equipConfig.Equip_MaxAct;
            int equip_MinMagAct = equipConfig.Equip_MinMagAct;
            int equip_MaxMagAct = equipConfig.Equip_MaxMagAct;
            int equip_MinDef = equipConfig.Equip_MinDef;
            int equip_MaxDef = equipConfig.Equip_MaxDef;
            int equip_MinAdf = equipConfig.Equip_MinAdf;
            int equip_MaxAdf = equipConfig.Equip_MaxAdf;
            double equip_Cri = equipConfig.Equip_Cri;
            double equip_Hit = equipConfig.Equip_Hit;
            double equip_Dodge = equipConfig.Equip_Dodge;
            double equip_DamgeAdd = equipConfig.Equip_DamgeAdd;
            double equip_DamgeSub = equipConfig.Equip_DamgeSub;
            double equip_Speed = equipConfig.Equip_Speed;
            double equip_Lucky = equipConfig.Equip_Lucky;

            // 换算总显示数值
            if (baginfo.XiLianHideProLists != null)
            {
                for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                {
                    int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                    int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                    switch (hidePropertyType)
                    {
                        case NumericType.Base_MaxHp_Base:
                            equip_Hp = equip_Hp + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxAct_Base:
                            equip_MaxAct = equip_MaxAct + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxDef_Base:
                            equip_MaxDef = equip_MaxDef + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxAdf_Base:
                            equip_MaxAdf = equip_MaxAdf + hidePropertyValue;
                            break;
                    }
                }
            }

            // 显示职业护甲加成
            string occShowStr = "";
            string textShow = "";
            string langStr = "";

            if (equip_Hp != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("生命");
                textShow = langStr + "  " + equip_Hp + occShowStr;

                bool ifHideProperty = false;
                if (baginfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                    {
                        int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                        int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                        if (hidePropertyType == NumericType.Base_MaxHp_Base)
                        {
                            textShow = langStr + " ：" + equip_Hp + "(+" + hidePropertyValue + ")" + occShowStr + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", propertyGO, parentGO);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            if (equip_MinAct != 0 || equip_MaxAct != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("攻击");
                textShow = langStr + " ：" + equip_MinAct + " - " + equip_MaxAct;
                bool ifHideProperty = false;
                if (baginfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                    {
                        int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                        int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                        if (hidePropertyType == NumericType.Base_MaxAct_Base)
                        {
                            textShow = langStr + " ：" + equip_MinAct + " - " + equip_MaxAct + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", propertyGO, parentGO);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            if (equip_MinDef != 0 || equip_MaxDef != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("防御");
                textShow = langStr + " ：" + equip_MinDef + " - " + equip_MaxDef;
                bool ifHideProperty = false;
                if (baginfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                    {
                        int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                        int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                        if (hidePropertyType == NumericType.Base_MaxDef_Base)
                        {
                            textShow = langStr + " ：" + equip_MinDef + " - " + equip_MaxDef + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", propertyGO, parentGO);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            if (equip_MinAdf != 0 || equip_MaxAdf != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("魔防");
                textShow = langStr + " ：" + equip_MinAdf + " - " + equip_MaxAdf;
                bool ifHideProperty = false;
                if (baginfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < baginfo.XiLianHideProLists.Count; i++)
                    {
                        int hidePropertyType = baginfo.XiLianHideProLists[i].HideID;
                        int hidePropertyValue = (int)baginfo.XiLianHideProLists[i].HideValue;

                        if (hidePropertyType == NumericType.Base_MaxAdf_Base)
                        {
                            textShow = langStr + " ：" + equip_MinAdf + " - " + equip_MaxAdf + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", propertyGO, parentGO);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            if (equip_Cri != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("暴击");
                textShow = langStr + "  " + equip_Cri * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_Hit != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("命中");
                textShow = langStr + "  " + equip_Hit * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_Dodge != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("闪避");
                textShow = langStr + "  " + equip_Dodge * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_DamgeAdd != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("伤害加成");
                textShow = langStr + "  " + equip_DamgeAdd * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_DamgeSub != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("伤害减免");
                textShow = langStr + "  " + equip_DamgeSub * 100 + "%\n";
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_Speed != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("移动速度");
                textShow = langStr + "  " + equip_Dodge;
                ShowPropertyText(textShow, "0", propertyGO, parentGO);
                properShowNum += 1;
            }

            if (equip_Lucky != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("幸运值");
                textShow = langStr + "  " + equip_Lucky;
                ShowPropertyText(textShow, "6", propertyGO, parentGO);
                properShowNum += 1;
            }

            //显示隐藏洗炼属性
            if (baginfo.XiLianHideTeShuProLists != null)
            {
                for (int i = 0; i < baginfo.XiLianHideTeShuProLists.Count; i++)
                {
                    int nowType = baginfo.XiLianHideTeShuProLists[i].HideID;
                    if (nowType != NumericType.Base_MaxHp_Base && nowType != NumericType.Base_MaxAct_Base &&
                        nowType != NumericType.Base_MaxDef_Base && nowType != NumericType.Base_MaxAdf_Base)
                    {
                        int hidePropertyType = baginfo.XiLianHideTeShuProLists[i].HideID;
                        long hidePropertyValue = baginfo.XiLianHideTeShuProLists[i].HideValue;
                        HideProListConfig hidePro = HideProListConfigCategory.Instance.Get(hidePropertyType);
                        string proStr = "";
                        string showColor = "1";
                        if (NumericHelp.GetNumericValueType(hidePro.PropertyType) == 2)
                        {
                            proStr = hidePro.Name + GameSettingLanguge.LoadLocalization("提升") + ((float)hidePropertyValue / 100.0f).ToString("0.##") +
                                    "%"; // 0.82   0.80
                        }
                        else
                        {
                            proStr = hidePro.Name + GameSettingLanguge.LoadLocalization("提升") + hidePropertyValue +
                                    GameSettingLanguge.LoadLocalization("点");

                            if (hidePro.Name == "幸运值")
                            {
                                showColor = "6";
                            }
                        }

                        ShowPropertyText(proStr, showColor, propertyGO, parentGO);
                        properShowNum += 1;
                    }
                }
            }

            //显示隐藏技能
            if (baginfo.HideSkillLists != null)
            {
                string skillTip = itemConfig.EquipType == 301? "套装效果，附加技能：" : "隐藏技能：";
                for (int i = 0; i < baginfo.HideSkillLists.Count; i++)
                {
                    int skillID = baginfo.HideSkillLists[i];
                    SkillConfig skillCof = SkillConfigCategory.Instance.Get(skillID);
                    string proStr = GameSettingLanguge.LoadLocalization(skillTip) + skillCof.SkillName;
                    ShowPropertyText(proStr, "2", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            //显示装备附加属性
            for (int i = 0; i < equipConfig.AddPropreListType.Length; i++)
            {
                if (equipConfig.AddPropreListIfShow.Length <= i)
                {
                    continue;
                }

                if (equipConfig.AddPropreListIfShow[i] == 0)
                {
                    int numericType = equipConfig.AddPropreListType[i];
                    if (numericType == 0)
                    {
                        continue;
                    }

                    string attribute = "";
                    long numericValue = equipConfig.AddPropreListValue[i];

                    for (int y = 0; y < baginfo.XiLianHideProLists.Count; y++)
                    {
                        if (equipConfig.AddPropreListType.Length <= y)
                        {
                            break;
                        }

                        if (baginfo.XiLianHideProLists[y].HideID == equipConfig.AddPropreListType[i])
                        {
                            numericValue += baginfo.XiLianHideProLists[i].HideValue;
                        }
                    }

                    int showType = NumericHelp.GetNumericValueType(numericType);
                    if (showType == 2)
                    {
                        float value = (float)numericValue / 100f;
                        attribute = $"{ItemViewHelp.GetAttributeName(numericType)} + " + value.ToString("0.##") + "%";
                    }
                    else
                    {
                        attribute = $"{ItemViewHelp.GetAttributeName(numericType)} + {numericValue}";
                    }

                    ShowPropertyText(attribute, "0", propertyGO, parentGO);
                    properShowNum += 1;
                }
            }

            //显示附魔属性
            for (int i = 0; i < baginfo.FumoProLists.Count; i++)
            {
                HideProList hideProList = baginfo.FumoProLists[i];
                int showType = NumericHelp.GetNumericValueType(hideProList.HideID);
                string attribute;
                if (showType == 2)
                {
                    float value = (float)hideProList.HideValue / 100f;
                    attribute = $"附魔属性: {ItemViewHelp.GetAttributeName(hideProList.HideID)} + " + value.ToString("0.##") + "%";
                }
                else
                {
                    attribute = $"附魔属性: {ItemViewHelp.GetAttributeName(hideProList.HideID)} + {hideProList.HideValue}";
                }

                ShowPropertyText(attribute, "1", propertyGO, parentGO);
                properShowNum += 1;
            }

            // 显示增幅属性
            for (int i = 0; i < baginfo.IncreaseProLists.Count; i++)
            {
                HideProList hide = baginfo.IncreaseProLists[i];
                string canTransf = "";
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide.HideID);
                string proName = ItemViewHelp.GetAttributeName(hideProListConfig.PropertyType);
                int showType = NumericHelp.GetNumericValueType(hideProListConfig.PropertyType);

                if (hideProListConfig.IfMove == 1)
                {
                    canTransf = "传承";
                }

                string attribute;
                if (showType == 2)
                {
                    float value = (float)hide.HideValue / 100f;
                    attribute = $"{canTransf}增幅: {proName} + " + value.ToString("0.##") + "%";
                }
                else
                {
                    attribute = $"{canTransf}增幅: {proName} + {hide.HideValue}";
                }

                ShowPropertyText(attribute, "1", propertyGO, parentGO);
                properShowNum += 1;
            }

            // 显示增幅技能
            for (int i = 0; i < baginfo.IncreaseSkillLists.Count; i++)
            {
                int hide = baginfo.IncreaseSkillLists[i];
                string canTransf = "";
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide);
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideProListConfig.PropertyType);
                string skillName = skillConfig.SkillName;
                if (hideProListConfig.IfMove == 1)
                {
                    canTransf = "传承";
                }

                string attribute = $"{canTransf}增幅: " + skillName;
                ShowPropertyText(attribute, "1", propertyGO, parentGO);
                properShowNum += 1;
            }

            // 显示描述
            if (itemConfig.ItemDes != "" && itemConfig.ItemDes != "0" && itemConfig.ItemDes != null)
            {
                string[] des = itemConfig.ItemDes.Split('\n');
                foreach (string s in des)
                {
                    int allLength = s.Length;
                    int addNum = Mathf.CeilToInt(allLength / 18f);
                    for (int a = 0; a < addNum; a++)
                    {
                        int leftNum = allLength - a * 18;
                        leftNum = Math.Min(leftNum, 18);
                        ShowPropertyText(s.Substring(a * 18, leftNum), "1", propertyGO, parentGO);
                    }

                    properShowNum += addNum;
                }
            }

            //显示传承技能
            string showYanSe = "2";
            if (baginfo.InheritSkills != null)
            {
                for (int i = 0; i < baginfo.InheritSkills.Count; i++)
                {
                    int skillID = baginfo.InheritSkills[i];
                    if (skillID != 0)
                    {
                        SkillConfig skillCof = SkillConfigCategory.Instance.Get(skillID);
                        string proStr = GameSettingLanguge.LoadLocalization("传承鉴定") + ":" + skillCof.SkillDescribe;

                        //获取当前穿戴的装备是否有相同的传承属性
                        bool ifRepeat = false;

                        for (int y = 0; y < equipItemList.Count; y++)
                        {
                            //Debug.Log("equipItemList.Count = " + equipItemList.Count);
                            List<int> inheritSkills = equipItemList[i].InheritSkills;
                            Debug.Log("inheritSkills.Count = " + inheritSkills.Count);

                            for (int z = 0; z < inheritSkills.Count; z++)
                            {
                                if (inheritSkills[z] == skillID && equipItemList[y].BagInfoID != baginfo.BagInfoID)
                                {
                                    proStr += "\n(同类传承属性只激活一种)";
                                    ifRepeat = true;
                                    showYanSe = "11";
                                    break;
                                }
                            }
                        }

                        //////防止循环多次
                        if (ifRepeat)
                        {
                            break;
                        }

                        //ShowPropertyText(proStr, "2", Obj_EquipPropertyText, Obj_EquipBaseSetList);

                        int allLength = proStr.Length;
                        int addNum = Mathf.CeilToInt(allLength / 18f);
                        if (ifRepeat && allLength <= 18)
                        {
                            addNum += 1;
                        }

                        for (int a = 0; a < addNum; a++)
                        {
                            int leftNum = allLength - a * 18;
                            leftNum = Math.Min(leftNum, 18);
                            ShowPropertyText(proStr.Substring(a * 18, leftNum), showYanSe, propertyGO, parentGO);
                            properShowNum += 1;
                        }
                    }
                }
            }

            return properShowNum;
        }

        public static GameObject ShowPropertyText(string showText, string showType, GameObject proItem, GameObject parObj)
        {
            GameObject go = UnityEngine.Object.Instantiate(proItem, parObj.transform, true);
            go.transform.localScale = new Vector3(1, 1, 1);
            go.GetComponent<Text>().text = showText;
            go.transform.localPosition = new Vector3(0, 0, 0);
            go.SetActive(true);

            switch (showType)
            {
                //极品提示  绿色
                case "1":
                    go.GetComponent<Text>().color = new Color(80f / 255f, 160f / 255f, 0f);
                    break;
                //隐藏技能  橙色
                case "2":
                    go.GetComponent<Text>().color = new Color(248 / 255f, 62f / 255, 191f / 255f);
                    break;
                //红色
                case "3":
                    go.GetComponent<Text>().color = Color.red;
                    break;
                //蓝色
                case "4":
                    go.GetComponent<Text>().color = new Color(1f, 0.5f, 1f);
                    break;
                //白色
                case "5":
                    go.GetComponent<Text>().color = new Color(100f / 255f, 80f / 255f, 60f / 255f);
                    break;
                //橙色
                case "6":
                    go.GetComponent<Text>().color = new Color(255f / 255f, 90f / 255f, 0f);
                    break;
                //灰色
                case "11":
                    go.GetComponent<Text>().color = new Color(0.66f, 0.66f, 0.66f);
                    break;
            }

            return go;
        }

        public static string GetItemSubType3Name(int subType)
        {
            string name = string.Empty;
            ItemViewData.ItemSubType3Name.TryGetValue(subType, out name);
            return name;
        }

        public static string QualityReturnColorUI(int ItenQuality)
        {
            string color = "FFFFFF";
            switch (ItenQuality)
            {
                case 1:
                    color = "686868";
                    break;

                case 2:
                    color = "47930F";
                    break;
                case 3:
                    color = "108793";
                    break;

                case 4:
                    color = "9D298C";
                    break;
                case 5:
                    color = "9C2933";
                    break;
                case 6:
                    color = "9C2933";
                    break;
            }

            return color;
        }

        public static string GetEquipSonType(string itemSubType)
        {
            switch (itemSubType)
            {
                case "1":
                    return "武器";

                case "2":
                    return "衣服";

                case "3":
                    return "护符";

                case "4":
                    return "戒指";

                case "5":
                    return "饰品";

                case "6":
                    return "鞋子";

                case "7":
                    return "裤子";

                case "8":
                    return "腰带";

                case "9":
                    return "手套";

                case "10":
                    return "头盔";

                case "11":
                    return "项链";
            }

            return "";
        }

        public static string GetEquipTypeShow(int type)
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
            }

            return "";
        }

        public static string GetItemDesc(BagInfo baginfo)
        {
            ItemConfig itemconf = ItemConfigCategory.Instance.Get(baginfo.ItemID);
            string Text_ItemDes = itemconf.ItemDes;
            int itemType = itemconf.ItemType;
            int itemSubType = itemconf.ItemSubType;

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

            //数组大于2表示有换行符,否则显示原来的描述
            if (itemDesArray.Length >= 2)
            {
                Text_ItemDes = itemMiaoShu;
            }

            //根据Tips描述长度缩放底的大小
            int i1 = 0;
            i1 = (int)((Text_ItemDes.Length) / 16) + 1;
            if (itemDesArray.Length > i1)
            {
                i1 = itemDesArray.Length;
            }

            string langStr = "";
            //宝石显示额外的描述
            if (itemType == 4)
            {
                string holeStr = "";
                //string baoshitype = "101, 102, 103, 104, 105";
                string baoshitype = itemconf.ItemSubType.ToString();
                string[] holeStrList = baoshitype.Split(',');
                for (int i = 0; i < holeStrList.Length; i++)
                {
                    switch (holeStrList[i])
                    {
                        case "101":
                            langStr = GameSettingLanguge.LoadLocalization("黄色");
                            holeStr = holeStr + langStr + "、";
                            break;
                        case "102":
                            langStr = GameSettingLanguge.LoadLocalization("紫色");
                            holeStr = holeStr + langStr + "、";
                            break;
                        case "103":
                            langStr = GameSettingLanguge.LoadLocalization("蓝色");
                            holeStr = holeStr + langStr + "、";
                            break;
                        case "104":
                            langStr = GameSettingLanguge.LoadLocalization("绿色");
                            holeStr = holeStr + langStr + "、";
                            break;
                        /*
                        case "105":
                            langStr = GameSettingLanguge.LoadLocalization("白色");
                            holeStr = holeStr + langStr + "、";
                            break;
                        */
                        case "110":
                            langStr = GameSettingLanguge.LoadLocalization("任意");
                            holeStr = holeStr + langStr + "、";
                            break;
                        case "111":
                            langStr = GameSettingLanguge.LoadLocalization("任意");
                            holeStr = holeStr + langStr + "、";
                            break;
                    }
                }

                if (holeStr != "")
                {
                    holeStr = holeStr.Substring(0, holeStr.Length - 1);
                }

                i1 = i1 + 2;

                string langStr_2 = GameSettingLanguge.LoadLocalization("可镶嵌在");
                string langStr_3 = GameSettingLanguge.LoadLocalization("孔位");
                Text_ItemDes = Text_ItemDes + "\n" + "\n" + @"" + langStr_2 + holeStr + @langStr_3 + "";

                if (itemconf.ItemSubType == 110)
                {
                    Text_ItemDes = Text_ItemDes + "\n" + "\n" + @"提示:史诗宝石一旦镶嵌将无法卸下身上最多可镶嵌4颗史诗宝石";
                }
            }

            //宠物之核
            if (itemType == 5)
            {
                string holeStr = "";
                //string baoshitype = "101, 102, 103, 104, 105";
                string baoshitype = itemconf.ItemSubType.ToString();
                string[] holeStrList = baoshitype.Split(',');
                for (int i = 0; i < holeStrList.Length; i++)
                {
                    switch (holeStrList[i])
                    {
                        case "1":
                            langStr = GameSettingLanguge.LoadLocalization("进攻能量");
                            holeStr = holeStr + langStr + "、";
                            break;
                        case "2":
                            langStr = GameSettingLanguge.LoadLocalization("守护能量");
                            holeStr = holeStr + langStr + "、";
                            break;
                        case "3":
                            langStr = GameSettingLanguge.LoadLocalization("生命能量");
                            holeStr = holeStr + langStr + "、";
                            break;
                    }
                }

                if (holeStr != "")
                {
                    holeStr = holeStr.Substring(0, holeStr.Length - 1);
                }

                i1 = i1 + 2;

                string langStr_2 = GameSettingLanguge.LoadLocalization("可装备在宠物的");
                string langStr_3 = GameSettingLanguge.LoadLocalization("槽位");
                Text_ItemDes = Text_ItemDes + "\n" + "\n" + @"" + langStr_2 + holeStr + @langStr_3 + "";
            }

            //藏宝图额外描述
            if (itemType == 1 && itemSubType == 32)
            {
                string langStr_4 = GameSettingLanguge.LoadLocalization("挖宝位置");
                string itemPar = baginfo.ItemPar;
                string scenceName = ChapterSonConfigCategory.Instance.Get(int.Parse(itemPar)).Name;
                Text_ItemDes = Text_ItemDes + "\n" + "\n" + langStr_4 + ":" + scenceName;
                i1 = i1 + 2;
            }

            //牧场道具额外描述
            if (itemType == 6)
            {
                string langStr_5 = GameSettingLanguge.LoadLocalization("品质");

                string itemPar = "0";
                if (itemSubType == 1)
                {
                    itemPar = "";
                }

                if (itemSubType == 2)
                {
                    itemPar = baginfo.ItemPar;
                }

                Text_ItemDes = Text_ItemDes + "\n" + "\n" + "<color=#F0E2C0FF>" + langStr_5 + ":" + itemPar + "</color>";
                i1 = i1 + 2;
            }

            // 增幅卷轴增幅描述
            if (itemType == 1 && itemSubType == 17)
            {
                string attribute = "";
                for (int i = 0; i < baginfo.IncreaseProLists.Count; i++)
                {
                    HideProList hide = baginfo.IncreaseProLists[i];
                    string canTransf = "";
                    HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide.HideID);
                    string proName = ItemViewHelp.GetAttributeName(hideProListConfig.PropertyType);
                    int showType = NumericHelp.GetNumericValueType(hideProListConfig.PropertyType);

                    if (hideProListConfig.IfMove == 1)
                    {
                        canTransf = "传承";
                    }

                    if (showType == 2)
                    {
                        float value = (float)hide.HideValue / 100f;
                        attribute += $"{canTransf}增幅: {proName} + " + value.ToString("0.##") + "%\n";
                    }
                    else
                    {
                        attribute += $"{canTransf}增幅: {proName} + {hide.HideValue}\n";
                    }
                }

                // 显示增幅技能
                for (int i = 0; i < baginfo.IncreaseSkillLists.Count; i++)
                {
                    int hide = baginfo.IncreaseSkillLists[i];
                    string canTransf = "";
                    HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideProListConfig.PropertyType);
                    string skillName = skillConfig.SkillName;
                    if (hideProListConfig.IfMove == 1)
                    {
                        canTransf = "传承";
                    }

                    attribute += $"{canTransf}增幅: " + skillName + "\n";
                }

                Text_ItemDes = Text_ItemDes + "\n" + "\n" + "<color=#7EA800>" + attribute + "</color>";
            }

            return Text_ItemDes;
        }

        public static string GetAttributeName(int numberType)
        {
            NumericAttribute numericAttribute;
            ItemViewData.AttributeToName.TryGetValue(numberType, out numericAttribute);
            string name = numericAttribute.Name;
            if (string.IsNullOrEmpty(name) && numberType > NumericType.Max)
            {
                return GetAttributeName(numberType / 100);
            }

            return GameSettingLanguge.LoadLocalization(name);
        }
    }
}