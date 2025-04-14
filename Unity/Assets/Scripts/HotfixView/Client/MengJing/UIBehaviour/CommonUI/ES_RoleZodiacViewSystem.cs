using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_RoleZodiac))]
    [FriendOfAttribute(typeof(ES_RoleZodiac))]
    public static partial class ES_RoleZodiacSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleZodiac self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);

            self.InitUI();
            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleZodiac self)
        {
            self.DestroyWidget();
        }

        private static void InitUI(this ES_RoleZodiac self)
        {
            GameObject go = self.EG_ZodiacListRectTransform.GetChild(0).gameObject;
            self.ZodiacList.Add(go);
            for (int i = 0; i < 11; i++)
            {
                self.ZodiacList.Add(UnityEngine.Object.Instantiate(go, self.EG_ZodiacListRectTransform));
            }

            go = self.EG_EquipSuitPropertyListRectTransform.GetChild(0).gameObject;
            self.EquipSuitPropertyList.Add(go);
            for (int i = 0; i < 2; i++)
            {
                self.EquipSuitPropertyList.Add(UnityEngine.Object.Instantiate(go, self.EG_EquipSuitPropertyListRectTransform));
            }
        }

        public static void OnUpdate(this ES_RoleZodiac self)
        {
            self.OnItemTypeSet(self.E_ItemTypeSetToggleGroup.GetCurrentIndex());
        }
        
        private static void OnItemTypeSet(this ES_RoleZodiac self, int index)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string path;
            Sprite sp;
            switch (index)
            {
                case 0:
                {
                    path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, "ItemQuality_2");
                    break;
                }
                case 1:
                {
                    path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, "ItemQuality_3");
                    break;
                }
                case 2:
                {
                    path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, "ItemQuality_4");
                    break;
                }
                default:
                {
                    path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, "ItemQuality_5");
                    break;
                }
            }

            sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> equipList = bagComponentC.GetItemsByLoc(ItemLocType.ItemLocEquip);
            int startId = 1600101 + index * 100;
            
            EquipConfig equipConfig = EquipConfigCategory.Instance.Get(ItemConfigCategory.Instance.Get(startId).ItemEquipID);
            EquipSuitConfig equipSuit = EquipSuitConfigCategory.Instance.Get(equipConfig.EquipSuitID);
            int[] needEquipIDSet = equipSuit.NeedEquipID;
            string[] suitPropertyIDSet = equipSuit.SuitPropertyID.Split(';');
            int equipSuitNum = 0;
            for (int i = 0; i < equipList.Count; i++)
            {
                if (needEquipIDSet.Contains(equipList[i].ItemID))
                {
                    equipSuitNum++;
                }
            }
            for (int i = 0; i < suitPropertyIDSet.Length; i++)
            {
                string triggerSuitNum = suitPropertyIDSet[i].Split(',')[0];
                string triggerSuitPropertyID = suitPropertyIDSet[i].Split(',')[1];
                
                EquipSuitPropertyConfig equipSuitProperty = EquipSuitPropertyConfigCategory.Instance.Get(int.Parse(triggerSuitPropertyID));

                GameObject go = self.EquipSuitPropertyList[i];
                
                using (zstring.Block())
                {
                    go.transform.Find("Text_Num").GetComponent<Text>().text = zstring.Format("激活{0}/{1}：", equipSuitNum, triggerSuitNum);
                }
                go.transform.Find("Text_Prop").GetComponent<Text>().text = equipSuitProperty.EquipSuitDes;
                go.transform.Find("Actived").gameObject.SetActive(equipSuitNum >= int.Parse(triggerSuitNum));
            }
            
            for (int i = 0; i < self.ZodiacList.Count; i++)
            {
                GameObject item = self.ZodiacList[i];
                ItemInfo itemInfo = null;
                foreach (ItemInfo info in equipList)
                {
                    if (info.ItemID == startId)
                    {
                        itemInfo = info;
                        break;
                    }
                }
                
                item.transform.Find("Img_Quality").GetComponent<Image>().sprite = sp;

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(startId);

                item.transform.Find("Img_Icon").GetComponent<Image>().sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
                CommonViewHelper.SetImageGray(self.Root(), item.transform.Find("Img_Icon").gameObject, itemInfo == null);
                
                item.transform.Find("Text_Name").GetComponent<Text>().text = itemConfig.ItemName;
                item.transform.Find("Text_Name").GetComponent<Text>().color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);

                item.transform.Find("Btn_Click").GetComponent<Button>().onClick.RemoveAllListeners();
                if (itemInfo != null)
                {
                    item.transform.Find("Btn_Click").GetComponent<Button>().AddListener(() => { self.OnClickZodiacItem(itemInfo); });
                }

                startId++;
            }
            
            self.RefreshBagItems();
        }

        private static void OnClickZodiacItem(this ES_RoleZodiac self, ItemInfo itemInfo)
        {
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = itemInfo,
                    ItemOperateEnum = ItemOperateEnum.Juese,
                    InputPoint = Input.mousePosition,
                    Occ = occ,
                    EquipList = self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemLocEquip)
                });
        }
        
        private static void RefreshBagItems(this ES_RoleZodiac self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();

            int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
            foreach (ItemInfo itemInfo in bagComponentC.GetItemsByLoc(ItemLocType.ItemLocBag))
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemInfo.ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.EquipType == 101)
                {
                    self.ShowBagInfos.Add(itemInfo);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, maxCount);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, maxCount);
        }

        private static void OnBagItemsRefresh(this ES_RoleZodiac self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            if (index < self.ShowBagInfos.Count)
            {
                scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.Bag, self.UpdateSelect);
                
                BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
                UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
                List<ItemInfo> equipList = bagComponentC.GetItemsByLoc(ItemLocType.ItemLocEquip);

                bool have = equipList.Any(itemInfo => itemInfo.ItemID == self.ShowBagInfos[index].ItemID);
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.ShowBagInfos[index].ItemID);
                scrollItemCommonItem.E_UpTipImage.gameObject.SetActive(!have && userInfoComponentC.UserInfo.Lv >= itemConfig.UseLv);
            }
            else
            {
                scrollItemCommonItem.Refresh(null, ItemOperateEnum.Bag, self.UpdateSelect);
            }
        }

        private static void UpdateSelect(this ES_RoleZodiac self, ItemInfo bagInfo)
        {
            foreach (Scroll_Item_CommonItem scrollItemCommonItem in self.ScrollItemCommonItems.Values)
            {
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.SetSelected(bagInfo);
                }
            }
        }
    }
}