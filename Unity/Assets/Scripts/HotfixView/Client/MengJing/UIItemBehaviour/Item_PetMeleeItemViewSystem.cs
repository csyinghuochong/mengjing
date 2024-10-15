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
        }

        private static void OnClick(this Scroll_Item_PetMeleeItem self)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>().OnClickItem(self.RolePetInfo);
        }
    }
}