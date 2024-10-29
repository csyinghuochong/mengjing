using System;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace ET.Client
{
    [FriendOf(typeof (ES_CommonItem))]
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof (Scroll_Item_CommonItem))]
    public static partial class Scroll_Item_CommonItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CommonItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CommonItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_CommonItem self, ItemInfo bagInfo, ItemOperateEnum itemOperateEnum,
        Action<ItemInfo> onClickAction = null, int currentHouse = -1)
        {
            Transform UIParticle = self.uiTransform.Find("UIParticle");
            if (UIParticle != null)
            {
                UIParticle.gameObject.SetActive(false);
            }
            self.ES_CommonItem.UpdateItem(bagInfo, itemOperateEnum);
            self.ES_CommonItem.SetClickHandler(onClickAction);
            self.ES_CommonItem.SetCurrentHouse(currentHouse);
        }

        public static void ShowUIEffect(this Scroll_Item_CommonItem self, int effectid)
        {
            Transform UIParticle = self.uiTransform.Find("UIParticle");
            if (UIParticle == null)
            {
                return;
            }
            UIParticle.gameObject.SetActive(true);
            CommonViewHelper.DestoryChild(UIParticle.gameObject);
            EffectConfig effectConfig = EffectConfigCategory.Instance.Get(effectid);
            string path = StringBuilderHelper.GetEffectPathByConfig(effectConfig);
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
            GameObject go = UnityEngine.Object.Instantiate(prefab, UIParticle, true);
            UIParticle.GetComponent<Coffee.UIExtensions.UIParticle>().scale  = (float)effectConfig.Scale;
        }
        
        public static void UpdateSelectStatus(this Scroll_Item_CommonItem self, ItemInfo bagInfo)
        {
            self.ES_CommonItem.SetSelected(bagInfo);
        }
    }
}