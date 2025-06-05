using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_ChengJiuPetTuJian))]
    [FriendOf(typeof(ES_PetTuJian))]
    [FriendOf(typeof(ES_ChengJiuJingling))]
    [FriendOf(typeof(ES_ChengJiuShow))]
    [FriendOf(typeof(ES_ChengJiuReward))]
    [FriendOf(typeof(DlgChengJiu))]
    public static class DlgChengJiuSystem
    {
        public static void RegisterUIEvent(this DlgChengJiu self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgChengJiu self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgChengJiu self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_ChengJiuReward.uiTransform.gameObject.SetActive(true);
                    self.View.ES_ChengJiuReward.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_ChengJiuShow.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_ChengJiuJingling.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_ChengJiuPetTuJian.uiTransform.gameObject.SetActive(true);
                    break;
                case 4:
                    self.View.ES_PetTuJian.uiTransform.gameObject.SetActive(true);
                    
                    self.View.ES_PetTuJian.OnUpdateUI();break;
            }
        }
    }
}
