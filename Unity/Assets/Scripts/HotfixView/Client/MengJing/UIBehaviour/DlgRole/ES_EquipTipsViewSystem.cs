using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(ES_EquipTips))]
    [FriendOfAttribute(typeof(ES_EquipTips))]
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
            self.E_SaveStoreHouseButton.AddListener(self.OnSaveStoreHouseButton);
            self.E_StoreHouseSetButton.AddListener(self.OnStoreHouseSetButton);

            self.TitleBigHeight_234 = 234f; //标题底框高度
            self.TitleMiniHeight_50 = 50; //条目标题高度
            self.TextItemHeight_40 = 40; //条目文本高度

            self.Obj_UIEquipGemHoleList = new GameObject[4];
            self.Obj_UIEquipGemHoleList[0] = self.EG_UIEquipGemHole_1RectTransform.gameObject;
            self.Obj_UIEquipGemHoleList[1] = self.EG_UIEquipGemHole_2RectTransform.gameObject;
            self.Obj_UIEquipGemHoleList[2] = self.EG_UIEquipGemHole_3RectTransform.gameObject;
            self.Obj_UIEquipGemHoleList[3] = self.EG_UIEquipGemHole_4RectTransform.gameObject;

            self.Obj_UIEquipGemHoleTextList = new GameObject[4];
            self.Obj_UIEquipGemHoleTextList[0] = self.E_UIEquipGemHoleText_1Text.gameObject;
            self.Obj_UIEquipGemHoleTextList[1] = self.E_UIEquipGemHoleText_2Text.gameObject;
            self.Obj_UIEquipGemHoleTextList[2] = self.E_UIEquipGemHoleText_3Text.gameObject;
            self.Obj_UIEquipGemHoleTextList[3] = self.E_UIEquipGemHoleText_4Text.gameObject;

            self.Obj_UIEquipGemHoleIconList = new GameObject[4];
            self.Obj_UIEquipGemHoleIconList[0] = self.E_UIEquipGemHoleIcon_1Image.gameObject;
            self.Obj_UIEquipGemHoleIconList[1] = self.E_UIEquipGemHoleIcon_2Image.gameObject;
            self.Obj_UIEquipGemHoleIconList[2] = self.E_UIEquipGemHoleIcon_3Image.gameObject;
            self.Obj_UIEquipGemHoleIconList[3] = self.E_UIEquipGemHoleIcon_4Image.gameObject;
            self.E_ShowEquipSuitButton.AddListener(self.OnShowEquipSuitButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipTips self)
        {
            self.DestroyWidget();
        }

        public static void RefreshInfo(this ES_EquipTips self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum, int currentHouse, int occTwoValue,
        List<ItemInfo> equipItemList)
        {
            using (zstring.Block())
            {
                self.BagInfo = bagInfo;
                self.ItemOpetateType = itemOperateEnum;
                self.CurrentHouse = currentHouse;
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (itemConfig.ItemEquipID == 0)
                {
                    return;
                }

                //-38 - > -112  = -74
                
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

                self.ExceedWidth = exceedWidth;

                // 部位、类型
                string textEquipType = LanguageComponent.Instance.LoadLocalization(ItemViewHelp.GetItemSubType3Name(itemConfig.ItemSubType));
                string textEquipTypeSon = self.GetEquipType(itemConfig.EquipType);
                if (itemConfig.EquipType == 101) // 生肖
                {
                    textEquipType = self.GetEquipShengXiaoType(itemConfig.ItemSubType % 100);
                    textEquipTypeSon = LanguageComponent.Instance.LoadLocalization("生肖");
                }

                self.E_EquipTypeText.text = zstring.Format("{0}:{1}", LanguageComponent.Instance.LoadLocalization("部位"), string.IsNullOrEmpty(textEquipType) ? "-" : textEquipType);
                self.E_EquipTypeSonText.text = zstring.Format("{0}:{1}", LanguageComponent.Instance.LoadLocalization("类型"), string.IsNullOrEmpty(textEquipType) ? "-" : textEquipType);

                int occTwo = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;
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
                if (itemConfig.UseLv > self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv)
                {
                    self.E_EquipNeedLvText.text =
                            zstring.Format("{0}:{1} (等级不足)", LanguageComponent.Instance.LoadLocalization("等级"), itemConfig.UseLv);
                    self.E_EquipNeedLvText.color = new Color(255f / 255f, 200f / 255f, 200f / 255f);
                }
                else
                {
                    self.E_EquipNeedLvText.text = zstring.Format("{0}:{1}", LanguageComponent.Instance.LoadLocalization("等级"), itemConfig.UseLv);
                }

                // 绑定
                if (self.BagInfo.isBinging)
                {
                    self.E_EquipBangDingText.text = LanguageComponent.Instance.LoadLocalization("已绑定");
                    self.E_EquipBangDingText.color = new Color(175f / 255f, 1, 6f / 255f);
                    self.E_EquipBangDingImgImage.gameObject.SetActive(true);
                }
                else
                {
                    self.E_EquipBangDingText.text = LanguageComponent.Instance.LoadLocalization("未绑定");
                    self.E_EquipBangDingText.color = new Color(255f / 255f, 240f / 255f, 200f / 255f);
                    self.E_EquipBangDingImgImage.gameObject.SetActive(false);
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
                self.E_EquipMakeText.text = !string.IsNullOrEmpty(self.BagInfo.MakePlayer)
                        ? zstring.Format("由<color=#805100>{0}</color>打造", self.BagInfo.MakePlayer) : "";

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
                self.EG_EquipZhuanJingSetRectTransform.gameObject.SetActive(false);
                switch (self.ItemOpetateType)
                {
                    case ItemOperateEnum.None:
                    case ItemOperateEnum.PaiMaiSell:
                    case ItemOperateEnum.PetHeXinBag:
                    case ItemOperateEnum.PaiMaiBuy:
                        break;
                    case ItemOperateEnum.PetEquipBag:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                        break;
                    case ItemOperateEnum.Bag:
                        self.EG_BagOpenSetRectTransform.gameObject.SetActive(true);
                        self.E_SellButton.gameObject.SetActive(true);

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
                        self.EG_RoseEquipOpenSetRectTransform.gameObject.SetActive(true);
                        break;
                    case ItemOperateEnum.Shop:
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

                // 基础属性  专精属性  隐藏技能  套装属性
                // 基础属性
                int properShowNum =
                        ItemViewHelp.ShowBaseAttribute(equipItemList, bagInfo, self.E_EquipPropertyTextText.gameObject,
                            self.EG_EquipBaseSetListRectTransform.gameObject);

                
                
                //显示宝石
                float startPostionY = 0 - self.TitleBigHeight_234 - self.TitleMiniHeight_50 - self.TextItemHeight_40 * properShowNum;
               
                int gemNumber = 0;
                if (!string.IsNullOrEmpty(self.BagInfo.GemHole) && self.BagInfo.GemHole != "0_0_0_0")
                {
                    Vector2 equipNeedvec2 = new Vector2(155.5f, startPostionY);
                    self.EG_UIEquipGemHoleSetRectTransform.gameObject.SetActive(true);
                    self.EG_UIEquipGemHoleSetRectTransform.GetComponent<RectTransform>().anchoredPosition = equipNeedvec2;
                    
                    string[] gemHoles = self.BagInfo.GemHole.Split('_');
                    string[] gemIds = self.BagInfo.GemIDNew.Split('_');
                    for (int g = 0; g < self.Obj_UIEquipGemHoleList.Length; g++)
                    {
                        self.Obj_UIEquipGemHoleList[g].SetActive(false);
                    }

                    for (int i = 0; i < gemIds.Length; i++)
                    {
                        if (gemHoles.Length <= i || string.IsNullOrEmpty(gemHoles[i]))
                        {
                            continue;
                        }
                        
                        self.Obj_UIEquipGemHoleList[gemNumber].SetActive(gemHoles[i] != "0");

                        GameObject icon_item = self.Obj_UIEquipGemHoleIconList[gemNumber];
                        GameObject icon_di = self.Obj_UIEquipGemHoleList[gemNumber].transform.Find("E_UIEquipGemHoleIcon_Di").gameObject;

                        int gemid = int.Parse(gemIds[gemNumber]);
                        self.TipsShowEquipGem(icon_item, icon_di, self.Obj_UIEquipGemHoleTextList[gemNumber],
                            int.Parse(gemHoles[gemNumber]), gemid);
                        gemNumber += (gemHoles[i] != "0" ? 1 : 0);

                        if (gemid > 0)
                        {
                            icon_item.GetComponent<Button>().onClick.AddListener(()=>
                            {
                                ItemInfo bagInfoGemids = new ItemInfo();
                                bagInfoGemids.ItemID = gemid;
                                bagInfoGemids.isBinging = true;
                                EventSystem.Instance.Publish(self.Root(),
                                    new ShowItemTips()
                                    {
                                        BagInfo = bagInfoGemids,
                                        ItemOperateEnum = ItemOperateEnum.None,
                                        InputPoint = Input.mousePosition,
                                        Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                                        EquipList = new List<ItemInfo>(),
                                        CurrentHouse =  self.CurrentHouse
                                    });
                            });
                        }
                    }
                }
                else
                {
                    self.EG_UIEquipGemHoleSetRectTransform.gameObject.SetActive(false);
                    self.Obj_UIEquipGemHoleList[0].SetActive(false);
                    self.Obj_UIEquipGemHoleList[1].SetActive(false);
                    self.Obj_UIEquipGemHoleList[2].SetActive(false);
                    self.Obj_UIEquipGemHoleList[3].SetActive(false);
                }

                float gemHoleShowHeight = gemNumber > 0 ? 135f : -20;

                //展示类装备不显示宝石
                if (self.BagInfo.BagInfoID == 0)
                {
                    self.EG_UIEquipGemHoleSetRectTransform.gameObject.SetActive(false);
                    //startPostionY += 50;
                    gemHoleShowHeight = -20;
                }


                //显示专精属性
                startPostionY -= gemHoleShowHeight;
                
               
                
                int zhunjingNumber = self.ShowZhuanJingAttribute(itemConfig, startPostionY);

                //显示隐藏技能
                //float HintTextNum = 50;
                startPostionY -= (zhunjingNumber > 0 ? self.TitleMiniHeight_50 : 0);
                startPostionY = startPostionY - zhunjingNumber * self.TextItemHeight_40;
                startPostionY  -= 5f;
                int hideSkillNumber = self.ShowHideSkill(itemConfig, startPostionY);

                //显示装备套装信息
                //float equipSuitTextNum = 0;
                startPostionY -= (hideSkillNumber > 0 ? self.TitleMiniHeight_50 : 0);
                startPostionY -= hideSkillNumber * self.TextItemHeight_40;

                EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemConfig.ItemEquipID);
                int suitEquipNumber = self.ShowSuitEquipInfo(itemConfig, equipConfig.EquipSuitID, startPostionY, equipItemList);
                suitEquipNumber = suitEquipNumber + (suitEquipNumber > 0 ? 2 : 0);
                startPostionY = startPostionY - self.TitleMiniHeight_50 - suitEquipNumber * self.TextItemHeight_40;
                startPostionY -= 5;

                float DiHight = startPostionY * -1 + 50;
                Vector2 backVector2 = self.E_BackImage.GetComponent<RectTransform>().sizeDelta;
                if (DiHight > backVector2.y)
                {
                    self.E_BackImage.GetComponent<RectTransform>().sizeDelta = new Vector2(backVector2.x, DiHight);
                }

                if (DiHight > 1150)
                {
                    float height = (DiHight - 1098f) * 0.5f;
                    self.EG_EquipBtnSetRectTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height);
                }
                else
                {
                    self.EG_EquipBtnSetRectTransform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                }

                //显示装备制造者的名字[名字直接放入baginfo]
            }
        }

        public static void TipsShowEquipGem(this ES_EquipTips self, GameObject icon,GameObject icondi, GameObject text, int gemHole, int gemId)
        {
            if (gemHole == 0)
            {
                return;
            }

            //text.GetComponent<Text>().text = ItemViewData.GemHoleName[gemHole];
            icon.SetActive(gemId != 0);
            text.SetActive(gemId != 0);
            using (zstring.Block())
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("Img_hole_{0}", gemHole));
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                icondi.GetComponent<Image>().sprite = sp;
            }
            
            if (gemId != 0)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(gemId);
                
                //等级 99 显示传承  98显示史诗
                text.GetComponent<Text>().text = ItemViewHelp.GetGemUseLv(itemConfig);
                text.GetComponent<Text>().color = FunctionUI.QualityReturnColor(itemConfig.ItemQuality);
                
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                icon.GetComponent<Image>().sprite = sp;

                int equipShiShiGemNum = 0;
                List<ItemInfo> equipList = self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemLocEquip);
                for (int i = 0; i < equipList.Count; i++)
                {
                    string[] gemList = equipList[i].GemIDNew.Split('_');
                    for (int y = 0; y < gemList.Length; y++)
                    {
                        if (CommonHelp.IfNull(gemList[y]) == false)
                        {
                            ItemConfig gemItemCof = ItemConfigCategory.Instance.Get(int.Parse(gemList[y]));
                            if (gemItemCof.ItemSubType == 110)
                            {
                                equipShiShiGemNum += 1;
                            }
                        }
                    }
                }

                if (itemConfig.ItemSubType == 110 && equipShiShiGemNum > 4)
                {
                    text.GetComponent<Text>().text += "(超过4个，属性无效)";
                }
            }
        }

        public static int ShowSuitEquipInfo(this ES_EquipTips self, ItemConfig itemConfig, int equipSuitID, float startPostionY,
        List<ItemInfo> itemList)
        {
            int properShowNum = 0;
            if (equipSuitID != 0)
            {
                Vector2 equipSuit_vec2 = new Vector2(0, startPostionY);
                using (zstring.Block())
                {
                    Log.Info(zstring.Format("equipSuit_vec2 = {0}", equipSuit_vec2.ToString()));
                }

                self.EG_UIEquipSuitRectTransform.GetComponent<RectTransform>().anchoredPosition = equipSuit_vec2;
                self.EG_UIEquipSuitRectTransform.gameObject.SetActive(true);

                EquipSuitConfig equipSuit = EquipSuitConfigCategory.Instance.Get(equipSuitID);

                string equipSuitName = equipSuit.Name;

                int[] needEquipIDSet = equipSuit.NeedEquipID;
                //string[] needEquipNumSet = equipSuit.NeedEquipNum.Split(';');
                string[] suitPropertyIDSet = equipSuit.SuitPropertyID.Split(';');

                List<int> itemIDList = new List<int>();
                for (int i = 0; i < itemList.Count; i++)
                {
                    itemIDList.Add(itemList[i].ItemID);
                }

                //获取自身拥有的装备
                int equipSuitNum = 0;
                for (int i = 0; i < needEquipIDSet.Length; i++)
                {
                    if (!ItemConfigCategory.Instance.Contain(needEquipIDSet[i]))
                    {
                        continue;
                    }

                    ItemConfig itemCof = ItemConfigCategory.Instance.Get(needEquipIDSet[i]);
                    string showType = "0";
                    if (itemIDList.Contains(needEquipIDSet[i]))
                    {
                        equipSuitNum = equipSuitNum + 1;
                        showType = "5";
                    }
                    else
                    {
                        showType = "11";
                    }

                    //显示套装名称
                    self.EquipSuitItemNamePropertyTextText.horizontalOverflow = HorizontalWrapMode.Overflow;
                    ItemViewHelp.ShowPropertyText(itemCof.ItemName, showType, self.EquipSuitItemNamePropertyTextText.gameObject,
                        self.EG_EquipSuitShowListSetRectTransform.gameObject);
                    properShowNum += 0;
                }

                int suitMaxValue = 0;

                //循环显示数值条
                for (int i = 0; i <= suitPropertyIDSet.Length - 1; i++)
                {
                    string triggerSuitNum = suitPropertyIDSet[i].Split(',')[0];
                    string triggerSuitPropertyID = suitPropertyIDSet[i].Split(',')[1];

                    EquipSuitPropertyConfig equipSuitProperty = EquipSuitPropertyConfigCategory.Instance.Get(int.Parse(triggerSuitPropertyID));
                    if (equipSuitProperty == null)
                    {
                        continue;
                    }

                    string equipSuitDes = equipSuitProperty.EquipSuitDes;
                    string ifShowSuitNum = equipSuitProperty.ifShowSuitNum.ToString();

                    //显示类型
                    string showType = "11";
                    //满足显示为绿色
                    if (equipSuitNum >= int.Parse(triggerSuitNum))
                    {
                        showType = "1";
                    }

                    if (ifShowSuitNum == "0")
                    {
                        string langStr = LanguageComponent.Instance.LoadLocalization("件套");
                        using (zstring.Block())
                        {
                            ItemViewHelp.ShowPropertyText(zstring.Format("{0}{1}:{2}", triggerSuitNum, langStr, equipSuitDes), showType,
                                self.E_EquipPropertyTextText.gameObject,
                                self.EG_EquipSuitSetListRectTransform.gameObject);
                        }

                        properShowNum += 1;
                    }

                    if (suitMaxValue < int.Parse(triggerSuitNum))
                    {
                        suitMaxValue = int.Parse(triggerSuitNum);
                    }
                }

                using (zstring.Block())
                {
                    //显示最大条目数
                    self.E_SuitNameText.text = zstring.Format("{0}({1}/{2})", equipSuitName, equipSuitNum, suitMaxValue);
                    self.E_SuitNameText.GetComponent<Text>().text = zstring.Format("{0}({1}/{2})", equipSuitName, equipSuitNum, suitMaxValue);
                }

                self.EG_UIEquipSuitRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.EG_UIEquipSuitRectTransform.gameObject.SetActive(false);
            }

            return properShowNum;
        }

        public static int ShowHideSkill(this ES_EquipTips self, ItemConfig itemconf, float startPostionY)
        {
            int properShowNum = 0;
            string skillIDStr = itemconf.SkillID;
            if (skillIDStr != "" && skillIDStr != "0" && itemconf.SkillIDIfShow == 0)
            {
                string[] skillID = skillIDStr.Split(';');

                Vector2 hint_vec2 = new(0f, startPostionY);
                self.EG_EquipHintSkillRectTransform.GetComponent<RectTransform>().anchoredPosition = hint_vec2;

                for (int i = 0; i <= skillID.Length - 1; i++)
                {
                    if (skillID[i] == "")
                        continue;

                    SkillConfig skillconf = SkillConfigCategory.Instance.Get(int.Parse(skillID[i]));
                    string skillName = skillconf.SkillName;
                    using (zstring.Block())
                    {
                        string showHintTxt = zstring.Format("{0}：{1}", LanguageComponent.Instance.LoadLocalization("技能"), skillName);
                        ItemViewHelp.ShowPropertyText(showHintTxt, "4", self.E_EquipPropertyTextText.gameObject,
                            self.EG_EquipHintSkillSetList.gameObject);
                    }

                    properShowNum += 1;
                }

                self.EG_EquipHintSkillRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.EG_EquipHintSkillRectTransform.gameObject.SetActive(false);
            }

            return properShowNum;
        }

        //显示专精属性
        public static int ShowZhuanJingAttribute(this ES_EquipTips self, ItemConfig itemconf, float startPostionY)
        {
            int properShowNum = 0;
            if (self.BagInfo.HideProLists != null && self.BagInfo.HideProLists.Count >= 1)
            {
                //统计长度需要在显示属性之前,要不显示属性会将self.properShowNum值累加
                Vector2 hint_vec2 = new Vector2(0, startPostionY);

                foreach (HideProList hide in self.BagInfo.HideProLists)
                {
                    //获取属性名称
                    string proName = ItemViewHelp.GetProName(hide.HideID);
                    string proText;
                    using (zstring.Block())
                    {
                        proText = zstring.Format("{0}提高{1}点", proName, hide.HideValue);
                    }

                    GameObject nowObj = ItemViewHelp.ShowPropertyText(proText, "1", self.E_EquipPropertyTextText.gameObject,
                        self.EG_EquipZhuanJingSetListRectTransform.gameObject);

                    properShowNum += 1;

                    //显示职业护甲加成
                    if (itemconf.EquipType == 11 || itemconf.EquipType == 12 || itemconf.EquipType == 13)
                    {
                        int occTwo = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;
                        if (occTwo != 0)
                        {
                            int selfMastery = OccupationTwoConfigCategory.Instance.Get(occTwo).ArmorMastery;
                            if (selfMastery != itemconf.EquipType)
                            {
                                //未激活专精的为灰色
                                nowObj.GetComponent<Text>().color = new Color(0.58f, 0.58f, 0.58f);
                            }
                        }
                        else
                        {
                            //未激活专精的为灰色
                            nowObj.GetComponent<Text>().color = new Color(0.58f, 0.58f, 0.58f);
                        }
                    }
                }

                self.EG_EquipZhuanJingSetRectTransform.GetComponent<RectTransform>().anchoredPosition = hint_vec2;
                self.EG_EquipZhuanJingSetRectTransform.gameObject.SetActive(true);
            }

            return properShowNum;
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
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int occTwo = userInfo.OccTwo;
            ItemConfig itemconf = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
            if (itemconf.EquipType == 301)
            {
                if (self.ItemOpetateType != ItemOperateEnum.PetEquipBag)
                {
                    FlyTipComponent.Instance.ShowFlyTip("请到宠物界面操作");
                    return;
                }

                DlgPet dlgPet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>();

                if (dlgPet == null)
                {
                    FlyTipComponent.Instance.ShowFlyTip("请到宠物界面操作");
                    return;
                }
                dlgPet.RequestPetEquipSelect().Coroutine();
            }
            else
            {
                if (itemconf.ItemSubType == (int)ItemSubTypeEnum.Wuqi)
                {
                    if (!ItemViewData.OccWeaponList[userInfo.Occ].Contains(itemconf.EquipType))
                    {
                        switch (userInfo.Occ)
                        {
                            //战士
                            case 1:
                                FlyTipComponent.Instance.ShowFlyTip("请选择武器类型为：刀 剑！");
                                break;
                            //法师
                            case 2:
                                FlyTipComponent.Instance.ShowFlyTip("请选择武器类型为：法杖 魔法书！！");
                                break;
                            //猎人
                            case 3:
                                FlyTipComponent.Instance.ShowFlyTip("本职业无法穿戴此武器");
                                break;
                        }

                        return;
                    }
                }

                if ((itemconf.ItemSubType != (int)ItemSubTypeEnum.Wuqi && itemconf.ItemSubType <= (int)ItemSubTypeEnum.Xianglian) && occTwo != 0)
                {
                    OccupationTwoConfig occupationTwo = OccupationTwoConfigCategory.Instance.Get(occTwo);
                    if (itemconf.EquipType != 0 && itemconf.EquipType != occupationTwo.ArmorMastery && itemconf.EquipType != 99)
                    {
                        //FloatTipManager.Instance.ShowFloatTip("请选择合适的装备！");
                        switch (occupationTwo.ArmorMastery)
                        {
                            //布甲
                            case 11:
                                FlyTipComponent.Instance.ShowFlyTip("转职后请选择布甲进行装备！");
                                break;
                            //轻甲
                            case 12:
                                FlyTipComponent.Instance.ShowFlyTip("转职后请选择轻甲进行装备！");
                                break;
                            //重甲
                            case 13:
                                FlyTipComponent.Instance.ShowFlyTip("转职后请选择重甲进行装备！");
                                break;
                        }

                        return;
                    }
                }

                BagClientNetHelper.RequestWearEquip(self.Root(), self.BagInfo).Coroutine();
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTakeoffButton(this ES_EquipTips self)
        {
            BagClientNetHelper.RequestTakeoffEquip(self.Root(), self.BagInfo).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSellButton(this ES_EquipTips self)
        {
            string[] gemids = self.BagInfo.GemIDNew.Split('_');
            bool haveGem = false;
            for (int i = 0; i < gemids.Length; i++)
            {
                if (gemids[i] != "0")
                {
                    haveGem = true;
                    break;
                }
            }

            if (haveGem)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "出售道具", "该装备镶嵌有宝石，是否出售道具？", () =>
                {
                    BagClientNetHelper.RequestSellItem(self.Root(), self.BagInfo, self.BagInfo.ItemNum.ToString()).Coroutine();
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
                }).Coroutine();

                return;
            }

            if (ItemConfigCategory.Instance.Get(self.BagInfo.ItemID).ItemQuality >= 4)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.BagInfo.ItemID);
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "出售道具", zstring.Format("是否出售道具:{0}", itemConfig.ItemName),
                        () =>
                        {
                            BagClientNetHelper.RequestSellItem(self.Root(), self.BagInfo, self.BagInfo.ItemNum.ToString()).Coroutine();
                            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
                        }).Coroutine();
                }

                return;
            }

            BagClientNetHelper.RequestSellItem(self.Root(), self.BagInfo, self.BagInfo.ItemNum.ToString()).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }

        private static void OnSaveStoreHouseButton(this ES_EquipTips self)
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
        }

        public static void OnStoreHouseSetButton(this ES_EquipTips self)
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
        }

        private static async ETTask OnHuiShouFangZhiButton(this ES_EquipTips self)
        {
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("1_{0}", self.BagInfo.BagInfoID) });
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTakeButton(this ES_EquipTips self)
        {
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("0_{0}", self.BagInfo.BagInfoID) });
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
            await ETTask.CompletedTask;
        }
        public static void OnShowEquipSuitButton(this ES_EquipTips self)
        {
        }
    }
}
