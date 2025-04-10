using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_RoleQiangHuaItem))]
    [FriendOfAttribute(typeof(ES_RoleQiangHuaItem))]
    public static partial class ES_RoleQiangHuaItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleQiangHuaItem self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_EquipButton.AddListener(self.OnEquipButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleQiangHuaItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_RoleQiangHuaItem self, int index)
        {
            self.ItemSubType = index;
            
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemInfo bagInfo = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, index);
            
            self.E_EquipIconImage.gameObject.SetActive(false);
            self.E_EquipQualityImage.gameObject.SetActive(false);
            if (bagInfo != null)
            {
                self.E_EquipIconImage.gameObject.SetActive(true);
                self.E_EquipQualityImage.gameObject.SetActive(true);
                
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.E_EquipIconImage.sprite = sp;
                
                string qualityiconStr = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
                string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
                Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
                self.E_EquipQualityImage.sprite = sp2;
            }
        }

        public static void OnEquipButton(this ES_RoleQiangHuaItem self)
        {
            self.ClickHandler(self.ItemSubType);
        }

        public static void SetClickHandler(this ES_RoleQiangHuaItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnUpateUI(this ES_RoleQiangHuaItem self, int qianghuaLevel)
        {
            using (zstring.Block())
            {
                self.E_QiangHuaText.text = zstring.Format("共鸣+{0}", qianghuaLevel);
            }
        }
    }
}
