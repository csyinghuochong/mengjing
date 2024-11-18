using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetbarSetPetItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetbarSetPetItem))]
    public static partial class Scroll_Item_PetbarSetPetItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetbarSetPetItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetbarSetPetItem self)
        {
            self.DestroyWidget();
        }

        public static void SetSelected(this Scroll_Item_PetbarSetPetItem self, long petid)
        {
            self.E_XuanZhongImage.gameObject.SetActive(self.PetId == petid);
        }

        public static void OnInitUI(this Scroll_Item_PetbarSetPetItem self, RolePetInfo rolePetInfo)
        {
            self.PetId = rolePetInfo.Id;

            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sp;
            self.E_NameText.text = rolePetInfo.PetName;
            using (zstring.Block())
            {
                self.E_LvText.text = zstring.Format("等级:{0}", rolePetInfo.PetLv);
            }
            self.E_XuanZhongImage.gameObject.SetActive(false);
        }
    }
}