using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_PetChouKa))]
    [FriendOf(typeof(ES_PetEggList))]
    [FriendOf(typeof(ES_PetEggDuiHuan))]
    [FriendOf(typeof(ES_PetEggChouKa))]
    [FriendOf(typeof(ES_PetHeXinChouKa))]
    [FriendOf(typeof(DlgPetEgg))]
    public static class DlgPetEggSystem
    {
        public static void RegisterUIEvent(this DlgPetEgg self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgPetEgg self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgPetEgg self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_PetEggList.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetEggList.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_PetEggDuiHuan.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetEggDuiHuan.OnUpdateUI();
                    break;
                case 2:
                    self.View.ES_PetEggChouKa.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_PetHeXinChouKa.uiTransform.gameObject.SetActive(true);
                    break;
                case 4:
                    self.View.ES_PetChouKa.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        public static void OnUpdateLuckly(this DlgPetEgg self)
        {
            self.View.ES_PetEggChouKa.OnUpdateInfo();
        }

        public static void UpdateChouKaTime(this DlgPetEgg self)
        {
            // UI ui = self.UIPageView.UISubViewList[(int)PetEggEnum.PetChouKa];
            // ui.GetComponent<UIPetChouKaComponent>().UpdateChouKaTime();
        }
    }
}