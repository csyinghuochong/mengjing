using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_CommonCostItem))]
    public static partial class Scroll_Item_CommonCostItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CommonCostItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CommonCostItem self)
        {
            self.DestroyWidget();
        }

        public static void UpdateItem(this Scroll_Item_CommonCostItem self, int itemId, int itemNum)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);

            self.E_ItemNameText.text = itemConfig.ItemName;

            //显示字
            //self.Label_ItemNum.GetComponent<Text>().text = $"{bagComponent.GetItemNumber(itemId)}/{itemNum}";
            using (zstring.Block())
            {
                self.E_ItemNumText.text = zstring.Format("{0}/{1}", CommonViewHelper.NumToWString(bagComponent.GetItemNumber(itemId)),
                    CommonViewHelper.NumToWString(itemNum));
            }

            //显示颜色
            self.E_ItemNumText.color = (itemNum <= bagComponent.GetItemNumber(itemId)) ? Color.green : new Color(255f / 255f, 135f / 255f, 81f / 255f);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ItemIconImage.sprite = sp;

            string qualityiconStr = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
            self.E_ItemQualityImage.sprite = sp2;

            self.E_ItemButtonButton.AddListener(() =>
            {
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = itemId;
                bagInfo.ItemNum = itemNum;
                EventSystem.Instance.Publish(self.Root(),
                    new ShowItemTips()
                    {
                        BagInfo = bagInfo,
                        ItemOperateEnum = ItemOperateEnum.None,
                        InputPoint = Input.mousePosition,
                        Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                        EquipList = new List<ItemInfo>()
                    });
            });
        }
    }
}