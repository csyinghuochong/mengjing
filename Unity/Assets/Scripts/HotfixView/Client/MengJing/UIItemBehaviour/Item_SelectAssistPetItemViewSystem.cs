﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectAssistPetItem))]
    [EntitySystemOf(typeof(Scroll_Item_SelectAssistPetItem))]
    public static partial class Scroll_Item_SelectAssistPetItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SelectAssistPetItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SelectAssistPetItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_SelectAssistPetItem self, int petTuJianConfigId)
        {
            self.E_TouchButton.AddListener(self.OnTouch);
            self.E_SelectedImage.gameObject.SetActive(false);

            self.PetTuJianConfigId = petTuJianConfigId;
            PetTuJianConfig petTuJianConfig = PetTuJianConfigCategory.Instance.Get(petTuJianConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petTuJianConfig.Icon.ToString());
            Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sprite;
            self.E_NameText.text = petTuJianConfig.Name;
        }

        private static void OnTouch(this Scroll_Item_SelectAssistPetItem self)
        {
            self.OnSelectAssistPetItem?.Invoke(self.PetTuJianConfigId);
        }
    }
}