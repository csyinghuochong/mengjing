namespace ET.Client
{
    [FriendOf(typeof(ES_UnionRoleXiuLian))]
    [FriendOf(typeof(ES_UnionPetXiuLian))]
    [FriendOf(typeof(ES_UnionBloodStone))]
    [FriendOf(typeof(DlgUnionXiuLian))]
    public static class DlgUnionXiuLianSystem
    {
        public static void RegisterUIEvent(this DlgUnionXiuLian self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgUnionXiuLian self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgUnionXiuLian self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_UnionRoleXiuLian.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_UnionPetXiuLian.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_UnionBloodStone.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }
    }
}