using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetCangKuItem))]
    [EntitySystemOf(typeof (Scroll_Item_PetCangKuItem))]
    public static partial class Scroll_Item_PetCangKuItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetCangKuItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetCangKuItem self)
        {
            self.DestroyWidget();
        }

        public static void SetAction(this Scroll_Item_PetCangKuItem self, Action action)
        {
            self.PetCangKuAction = action;
        }

        public static void OnUpdateUI(this Scroll_Item_PetCangKuItem self, RolePetInfo rolePetInfo)
        {
            self.E_ButtonPutButton.AddListenerAsync(self.OnButtonPut);

            self.RolePetInfo = rolePetInfo;
            self.E_Lab_PetNameText.text = rolePetInfo.PetName;

            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Img_PetHeroIonImage.sprite = sp;
        }

        public static async ETTask OnButtonPut(this Scroll_Item_PetCangKuItem self)
        {
            int error = await JiaYuanNetHelper.PetPutCangKu(self.Root(), self.RolePetInfo.Id, 3);
            if (error != 0)
            {
                return;
            }

            self.Root().GetComponent<PetComponentC>().GetPetInfoByID(self.RolePetInfo.Id).PetStatus = 3;
            self.PetCangKuAction?.Invoke();
        }
    }
}