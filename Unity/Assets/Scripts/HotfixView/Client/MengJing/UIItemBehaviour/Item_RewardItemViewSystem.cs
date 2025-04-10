using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RewardItem))]
    [EntitySystemOf(typeof(Scroll_Item_RewardItem))]
    public static partial class Scroll_Item_RewardItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RewardItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RewardItem self)
        {
            self.DestroyWidget();
        }

        public static void UpdateItem(this Scroll_Item_RewardItem self, ItemInfo bagInfo)
        {
            self.Baginfo = bagInfo;

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

            self.E_ItemQualityImage.overrideSprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(
                ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality)));

            self.E_ItemIconImage.overrideSprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));

            using (zstring.Block())
            {
                self.E_ItemNumText.text = zstring.Format("x{0}", ItemViewHelp.ReturnNumStr(bagInfo.ItemNum));
            }

            self.E_ItemNameText.text = itemConfig.ItemName;
            self.E_ItemNameText.color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);
        }

        public static void ShowUIEffect(this Scroll_Item_RewardItem self, int effectid)
        {
            Transform UIParticle = self.uiTransform.Find("UIParticle");
            if (UIParticle == null)
            {
                return;
            }

            Coffee.UIExtensions.UIParticle uiParticle = UIParticle.GetComponent<Coffee.UIExtensions.UIParticle>();
            if (uiParticle == null)
            {
                return;
            }

            float scale = uiParticle.scale;
            string path = string.Empty;
            if (effectid != 41100001)
            {
                EffectConfig effectConfig = EffectConfigCategory.Instance.Get(effectid);
                path = StringBuilderHelper.GetEffectPathByConfig(effectConfig);
                scale = (float)effectConfig.Scale;
            }
            else
            {
                if (self.Baginfo == null)
                {
                    return;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.Baginfo.ItemID);
                if (itemConfig.ItemQuality < 2)
                {
                    return;
                }

                using (zstring.Block())
                {
                    path = zstring.Format("Assets/Bundles/Effect/UIEffect/UIEffect_Quaity_{0}", itemConfig.ItemQuality);
                }
            }

            UIParticle.gameObject.SetActive(true);
            CommonViewHelper.DestoryChild(UIParticle.gameObject);
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(prefab, UIParticle, true);
            go.transform.localPosition = Vector3.zero;

            uiParticle.particles.Clear();
            uiParticle.RefreshParticles();
            uiParticle.scale = scale;
        }
    }
}