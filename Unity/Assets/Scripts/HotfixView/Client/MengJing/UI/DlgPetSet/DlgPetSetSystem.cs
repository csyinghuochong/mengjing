using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgPetSet))]
    public static class DlgPetSetSystem
    {
        public static void RegisterUIEvent(this DlgPetSet self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgPetSet self, Entity contextData = null)
        {
            self.View.E_Type1Toggle.IsSelected(true);
        }

        private static void OnFunctionSetBtn(this DlgPetSet self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_Type1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_Type2Toggle.gameObject, index == 1);

            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
    }
}