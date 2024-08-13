using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetInfo))]
    public static class DlgPetInfoSystem
    {
        public static void RegisterUIEvent(this DlgPetInfo self)
        {
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);
            self.View.E_ButtonAddPointButton.AddListener(self.OnButtonAddPointButton);
            self.View.E_ButtonCloseHexinButton.AddListener(self.OnButtonCloseHexinButton);
            self.View.E_ButtonCloseAddPointButton.AddListener(self.OnButtonCloseAddPointButton);
            self.View.E_ImageJinHuaButton.AddListener(self.OnImageJinHuaButton);
        }

        public static void ShowWindow(this DlgPetInfo self, Entity contextData = null)
        {
        }

        public static void OnButtonCloseButton(this DlgPetInfo self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetInfo);
        }
        
        public static void OnUpdateUI(this DlgPetInfo self, RolePetInfo rolePetInfo, List<BagInfo> bagInfos, List<int> keys, List<long> values)
        {
        }
        public static void OnButtonAddPointButton(this DlgPetInfo self)
        {
        }
        public static void OnButtonCloseHexinButton(this DlgPetInfo self)
        {
        }
        public static void OnButtonCloseAddPointButton(this DlgPetInfo self)
        {
        }
        public static void OnImageJinHuaButton(this DlgPetInfo self)
        {
        }
    }
}
