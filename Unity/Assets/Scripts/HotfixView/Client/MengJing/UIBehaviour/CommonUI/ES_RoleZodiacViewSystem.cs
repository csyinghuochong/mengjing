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
            self.RefreshBagItems();
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
            int startId = 16000101 + index * 100;
            for (int i = 0; i < self.ZodiacList.Count; i++)
            {
                GameObject item = self.ZodiacList[i];

                item.transform.Find("Img_Quality").GetComponent<Image>().sprite = sp;

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(startId);

                item.transform.Find("Img_Icon").GetComponent<Image>().sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
                CommonViewHelper.SetImageGray(self.Root(), item.transform.Find("Img_Icon").gameObject, true);
                item.transform.Find("Text_Name").GetComponent<Text>().text = itemConfig.ItemName;
                item.transform.Find("Text_Name").GetComponent<Text>().color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);

                startId++;
            }
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
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag, self.UpdateSelect);
        }

        private static void UpdateSelect(this ES_RoleZodiac self, ItemInfo bagInfo)
        {
            foreach (Scroll_Item_CommonItem scrollItemCommonItem in self.ScrollItemCommonItems.Values)
            {
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.UpdateSelectStatus(bagInfo);
                }
            }
        }
    }
}