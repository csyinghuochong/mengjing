using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_CountryTask))]
    [FriendOf(typeof(ES_CountryHuoDong))]
    [FriendOf(typeof(ES_ActivitySingIn))]
    [FriendOf(typeof(ES_PetMatch))]
    [FriendOf(typeof(DlgCountry))]
    public static class DlgCountrySystem
    {
        public static void RegisterUIEvent(this DlgCountry self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgCountry self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgCountry self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_CountryTask.uiTransform.gameObject.SetActive(true);
                    self.View.ES_CountryTask.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_ActivitySingIn.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_CountryHuoDong.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_PetMatch.uiTransform.gameObject.SetActive(true);
                    self.View.ES_PetMatch.OnUpdateUI();
                    break;
            }
        }

        public static void OnUpdateRoleData(this DlgCountry self)
        {
            self.View.ES_CountryTask.OnTaskCountryUpdate();
        }
    }
}