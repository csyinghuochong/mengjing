using System;
using System.Collections.Generic;
using ET;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public static class ItemViewHelp
    {
        //装备基础属性
        public static int ShowBaseAttribute(List<BagInfo> equipItemList, BagInfo baginfo, GameObject Obj_EquipPropertyText,
        GameObject Obj_EquipBaseSetList)
        {
            int properShowNum = 0;
            ItemConfig itemconf = ItemConfigCategory.Instance.Get(baginfo.ItemID);
            string ItemIcon = itemconf.Icon;
            int ItemQuality = itemconf.ItemQuality;
            string equip_ID = itemconf.ItemEquipID.ToString();
            string equipName = itemconf.ItemName;
            string equipLv = itemconf.UseLv.ToString();
            string ItemBlackDes = itemconf.ItemDes;

            // 赛季晶核
            if (itemconf.ItemType == 3 && itemconf.EquipType == 201)
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

                        ShowPropertyText(attribute, showColor, Obj_EquipPropertyText, Obj_EquipBaseSetList);
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
                        ShowPropertyText(proStr, "2", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                        properShowNum += 1;
                    }
                }
            }

            EquipConfig equipconf = EquipConfigCategory.Instance.Get(itemconf.ItemEquipID);
            int equip_Hp = equipconf.Equip_Hp;
            int equip_MinAct = equipconf.Equip_MinAct;
            int equip_MaxAct = equipconf.Equip_MaxAct;
            int equip_MinMagAct = equipconf.Equip_MinMagAct;
            int equip_MaxMagAct = equipconf.Equip_MaxMagAct;
            int equip_MinDef = equipconf.Equip_MinDef;
            int equip_MaxDef = equipconf.Equip_MaxDef;
            int equip_MinAdf = equipconf.Equip_MinAdf;
            int equip_MaxAdf = equipconf.Equip_MaxAdf;
            double equip_Cri = equipconf.Equip_Cri;
            double equip_Hit = equipconf.Equip_Hit;
            double equip_Dodge = equipconf.Equip_Dodge;
            double equip_DamgeAdd = equipconf.Equip_DamgeAdd;
            double equip_DamgeSub = equipconf.Equip_DamgeSub;
            double equip_Speed = equipconf.Equip_Speed;
            double equip_Lucky = equipconf.Equip_Lucky;
            /*
            HideProList hide1 = new HideProList();
            hide1.HideID = (int)NumericType.Base_MaxAct_Base;
            hide1.HideValue = 12;
            baginfo.XiLianHideProLists.Add(hide1);
            */

            //换算总显示数值
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
                        /*
                        case NumericType.Base_Agility_Base:
                            equip_MaxAdf = equip_MaxAdf + hidePropertyValue;
                            break;
                        */
                    }
                }
            }

            //显示职业护甲加成
            string occShowStr = "";
            string textShow = "";
            string langStr = "";

            if (equip_Hp != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("生命");
                textShow = langStr + "  " + equip_Hp + occShowStr;
                //textNum = textNum + 1;

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
                    ShowPropertyText(textShow, "1", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
            }

            if (equip_MinAct != 0 || equip_MaxAct != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("攻击");
                textShow = langStr + " ：" + equip_MinAct + " - " + equip_MaxAct;
                //textShow = langStr + "  " + equip_MaxAct + occShowStr;
                //textNum = textNum + 1;
                //ShowPropertyText(textShow);
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
                            //textShow = langStr + "  " + equip_MaxAct + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
            }

            if (equip_MinDef != 0 || equip_MaxDef != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("防御");
                textShow = langStr + " ：" + equip_MinDef + " - " + equip_MaxDef;
                //textShow = langStr + "  " + equip_MaxDef + occShowStr;
                //textNum = textNum + 1;
                //ShowPropertyText(textShow);
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
                            //textShow = langStr + "  " + equip_MaxDef + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
            }

            if (equip_MinAdf != 0 || equip_MaxAdf != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("魔防");
                textShow = langStr + " ：" + equip_MinAdf + " - " + equip_MaxAdf;
                //textShow = langStr + "  " + equip_MaxAdf + occShowStr;
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
                            //textShow = langStr + "  " + equip_MaxAdf + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    ShowPropertyText(textShow, "1", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
                else
                {
                    ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
            }

            if (equip_Cri != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("暴击");
                textShow = langStr + "  " + equip_Cri * 100 + "%\n";
                //textNum = textNum + 1;
                ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                properShowNum += 1;
            }

            if (equip_Hit != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("命中");
                textShow = langStr + "  " + equip_Hit * 100 + "%\n";
                //textNum = textNum + 1;
                ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                properShowNum += 1;
            }

            if (equip_Dodge != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("闪避");
                textShow = langStr + "  " + equip_Dodge * 100 + "%\n";
                //textNum = textNum + 1;
                ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                properShowNum += 1;
            }

            if (equip_DamgeAdd != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("伤害加成");
                textShow = langStr + "  " + equip_DamgeAdd * 100 + "%\n";
                //textNum = textNum + 1;
                ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                properShowNum += 1;
            }

            if (equip_DamgeSub != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("伤害减免");
                textShow = langStr + "  " + equip_DamgeSub * 100 + "%\n";
                //textNum = textNum + 1;
                ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                properShowNum += 1;
            }

            if (equip_Speed != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("移动速度");
                textShow = langStr + "  " + equip_Dodge;
                //textNum = textNum + 1;
                ShowPropertyText(textShow, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                properShowNum += 1;
            }

            if (equip_Lucky != 0)
            {
                langStr = GameSettingLanguge.LoadLocalization("幸运值");
                textShow = langStr + "  " + equip_Lucky;
                //textNum = textNum + 1;
                ShowPropertyText(textShow, "6", Obj_EquipPropertyText, Obj_EquipBaseSetList);
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

                        ShowPropertyText(proStr, showColor, Obj_EquipPropertyText, Obj_EquipBaseSetList);
                        properShowNum += 1;
                    }
                }
            }

            //显示隐藏技能
            if (baginfo.HideSkillLists != null)
            {
                string skillTip = itemconf.EquipType == 301? "套装效果，附加技能：" : "隐藏技能：";
                for (int i = 0; i < baginfo.HideSkillLists.Count; i++)
                {
                    int skillID = baginfo.HideSkillLists[i];
                    SkillConfig skillCof = SkillConfigCategory.Instance.Get(skillID);
                    string proStr = GameSettingLanguge.LoadLocalization(skillTip) + skillCof.SkillName;
                    ShowPropertyText(proStr, "2", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    properShowNum += 1;
                }
            }

            //显示装备附加属性
            for (int i = 0; i < equipconf.AddPropreListType.Length; i++)
            {
                if (equipconf.AddPropreListIfShow.Length <= i)
                {
                    continue;
                }

                if (equipconf.AddPropreListIfShow[i] == 0)
                {
                    int numericType = equipconf.AddPropreListType[i];
                    if (numericType == 0)
                    {
                        continue;
                    }

                    string attribute = "";
                    long numericValue = equipconf.AddPropreListValue[i];

                    for (int y = 0; y < baginfo.XiLianHideProLists.Count; y++)
                    {
                        if (equipconf.AddPropreListType.Length <= y)
                        {
                            break;
                        }

                        if (baginfo.XiLianHideProLists[y].HideID == equipconf.AddPropreListType[i])
                        {
                            numericValue += baginfo.XiLianHideProLists[i].HideValue;
                        }
                    }

                    int showType = NumericHelp.GetNumericValueType(numericType);
                    if (showType == 2)
                    {
                        float value = (float)numericValue / 100f;
                        //attribute = $"{ItemViewHelp.GetAttributeName(showType)} + {numericValue * 0.01f}%";
                        attribute = $"{ItemViewHelp.GetAttributeName(numericType)} + " + value.ToString("0.##") + "%";
                    }
                    else
                    {
                        attribute = $"{ItemViewHelp.GetAttributeName(numericType)} + {numericValue}";
                    }

                    ShowPropertyText(attribute, "0", Obj_EquipPropertyText, Obj_EquipBaseSetList);
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

                ShowPropertyText(attribute, "1", Obj_EquipPropertyText, Obj_EquipBaseSetList);
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

                ShowPropertyText(attribute, "1", Obj_EquipPropertyText, Obj_EquipBaseSetList);
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
                ShowPropertyText(attribute, "1", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                properShowNum += 1;
            }

            //显示描述
            if (itemconf.ItemDes != "" && itemconf.ItemDes != "0" && itemconf.ItemDes != null)
            {
                string[] des = itemconf.ItemDes.Split('\n');
                foreach (string s in des)
                {
                    int allLength = s.Length;
                    int addNum = Mathf.CeilToInt(allLength / 18f);
                    for (int a = 0; a < addNum; a++)
                    {
                        int leftNum = allLength - a * 18;
                        leftNum = Math.Min(leftNum, 18);
                        ShowPropertyText(s.Substring(a * 18, leftNum), "1", Obj_EquipPropertyText, Obj_EquipBaseSetList);
                    }

                    properShowNum += addNum;
                }

                //int zifuLenght = GetNumbers(itemconf.ItemDes) + GetTeShu(itemconf.ItemDes);
                //int lenght = (allLength - zifuLenght) + (int)(zifuLenght * 0.5f);
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
                            ShowPropertyText(proStr.Substring(a * 18, leftNum), showYanSe, Obj_EquipPropertyText, Obj_EquipBaseSetList);
                            properShowNum += 1;
                        }
                    }
                }
            }

            return properShowNum;
        }

        public static GameObject ShowPropertyText(string showText, string showType, GameObject proItem, GameObject parObj)
        {
            GameObject propertyObj = (GameObject)GameObject.Instantiate(proItem);
            propertyObj.transform.SetParent(parObj.transform);
            propertyObj.transform.localScale = new Vector3(1, 1, 1);
            propertyObj.GetComponent<Text>().text = showText;
            //propertyObj.transform.localPosition = new Vector3(-12, -30 - 25 * self.properShowNum, 0);
            propertyObj.transform.localPosition = new Vector3(0, 0, 0);
            propertyObj.SetActive(true);

            switch (showType)
            {
                //极品提示  绿色
                case "1":
                    //propertyObj.GetComponent<Text>().color = new Color(0.5f, 1f, 0f);
                    propertyObj.GetComponent<Text>().color = new Color(80f / 255f, 160f / 255f, 0f);
                    break;
                //隐藏技能  橙色
                case "2":
                    propertyObj.GetComponent<Text>().color = new Color(248 / 255f, 62f / 255, 191f / 255f);
                    break;
                //红色
                case "3":
                    propertyObj.GetComponent<Text>().color = Color.red;
                    break;
                //蓝色
                case "4":
                    propertyObj.GetComponent<Text>().color = new Color(1f, 0.5f, 1f);
                    break;
                //白色
                case "5":
                    //propertyObj.GetComponent<Text>().color = new Color(1f, 1f, 1f);
                    propertyObj.GetComponent<Text>().color = new Color(100f / 255f, 80f / 255f, 60f / 255f);
                    break;
                //橙色
                case "6":
                    //propertyObj.GetComponent<Text>().color = new Color(1f, 1f, 1f);
                    propertyObj.GetComponent<Text>().color = new Color(255f / 255f, 90f / 255f, 0f);
                    break;
                //灰色
                case "11":
                    propertyObj.GetComponent<Text>().color = new Color(0.66f, 0.66f, 0.66f);
                    break;
            }

            return propertyObj;
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