using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetEggSelectItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetEggSelectItem))]
    public static partial class Scroll_Item_PetEggSelectItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetEggSelectItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetEggSelectItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitData(this Scroll_Item_PetEggSelectItem self, int index, int itemConfigId, int num)
        {
            self.Index = index;
            self.ItemConfigId = itemConfigId;
            self.E_Btn_UseButton.AddListener(self.OnClickPetItem);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemConfigId);

            self.E_ItemQualityImage.overrideSprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(
                ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality)));

            self.E_ItemIconImage.overrideSprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));

            self.E_ItemNameText.text = itemConfig.ItemName;
            
            using (zstring.Block())
            {
                self.E_ItemNumText.text = zstring.Format("数量:{0}", num);
            }
        }

        private static void OnClickPetItem(this Scroll_Item_PetEggSelectItem self)
        {
            self.GetParent<ES_PetEggList>().PetEggItemSelect(self.Index, self.ItemConfigId).Coroutine();
        }
    }
}