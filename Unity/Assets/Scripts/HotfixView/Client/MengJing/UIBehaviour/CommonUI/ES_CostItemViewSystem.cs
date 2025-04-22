using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_CostItem))]
    [FriendOfAttribute(typeof(ES_CostItem))]
    public static partial class ES_CostItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_CostItem self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_CostItem self)
        {
            self.DestroyWidget();
        }

        public static void UpdateItem(this ES_CostItem self, int itemId, int itemNum, bool usercolor = false)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);

            self.E_ItemNameText.text = itemConfig.ItemName;

            if (usercolor)
            {
                self.E_ItemNameText.color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);
            }
          

            //显示字
            using (zstring.Block())
            {
                self.E_ItemNumText.text = zstring.Format("{0}/{1}", CommonViewHelper.NumToWString(bagComponent.GetItemNumber(itemId)),
                    CommonViewHelper.NumToWString(itemNum));
            }

            //显示颜色
            self.E_ItemNumText.color = (itemNum < bagComponent.GetItemNumber(itemId)) ? Color.green : new Color(255f / 255f, 135f / 255f, 81f / 255f);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ItemIconImage.sprite = sp;

            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality));
            Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
            self.E_ItemQualityImage.sprite = sp2;
        }
    }
}
