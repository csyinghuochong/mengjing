using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMeleeItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetMeleeItem))]
    public static partial class Scroll_Item_PetMeleeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetMeleeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetMeleeItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_PetMeleeItem self, RolePetInfo rolePetInfo)
        {
            self.RolePetInfo = rolePetInfo;

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sp;
        }

        public static void RefreshCD(this Scroll_Item_PetMeleeItem self)
        {
            long timeNow = TimeInfo.Instance.ServerNow();
            if (self.EndTime <= timeNow)
            {
                self.E_CDImage.fillAmount = 0;
            }
            else
            {
                self.E_CDImage.fillAmount = (float)(self.EndTime - timeNow) / self.CD;
            }
        }

        public static void SetCD(this Scroll_Item_PetMeleeItem self)
        {
            self.EndTime = TimeHelper.ServerNow() + self.CD;
        }
    }
}