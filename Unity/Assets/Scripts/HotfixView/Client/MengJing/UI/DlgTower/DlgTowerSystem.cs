using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_TowerDungeon))]
    [FriendOf(typeof(ES_TowerShop))]
    [FriendOf(typeof(DlgTower))]
    public static class DlgTowerSystem
    {
        public static void RegisterUIEvent(this DlgTower self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgTower self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgTower self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_TowerDungeon.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_TowerShop.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}