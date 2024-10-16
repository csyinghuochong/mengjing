using UnityEngine;
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
            self.E_ClickButton.AddListener(self.OnClick);

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sp;
        }

        public static void RefreshCD(this Scroll_Item_PetMeleeItem self)
        {
        }

        private static void OnClick(this Scroll_Item_PetMeleeItem self)
        {
            if (self.EndTime > TimeHelper.ServerNow())
            {
                FlyTipComponent.Instance.ShowFlyTip("冷却中。。。");
                return;
            }

            if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>().OnClickItem(self.CostMoLi, self.RolePetInfo.Id))
            {
                self.EndTime = TimeHelper.ServerNow() + self.RefreshTime;
            }
        }
    }
}