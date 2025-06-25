using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (ES_RankShow))]
    [FriendOf(typeof (ES_RankPet))]
    [FriendOf(typeof (ES_RankReward))]
    [FriendOf(typeof (ES_RankPetReward))]
    [FriendOf(typeof (DlgRank))]
    public static class DlgRankSystem
    {
        public static void RegisterUIEvent(this DlgRank self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);

            int version = GlobalHelp.GetVersionMode();
            self.View.E_FunctionSetBtnToggleGroup.transform.Find("Type_1").gameObject.SetActive(version != 2);

            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgRank self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgRank self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_RankShow.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RankShow.OnShowWindow();
                    break;
                case 1:
                    self.View.ES_RankPet.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RankPet.OnShowWindow();
                    break;
            }
        }
    }
}
