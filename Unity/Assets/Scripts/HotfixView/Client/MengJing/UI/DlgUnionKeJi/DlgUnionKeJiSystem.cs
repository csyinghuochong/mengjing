namespace ET.Client
{
    [FriendOf(typeof(ES_UnionKeJiResearch))]
    [FriendOf(typeof(ES_UnionKeJiLearn))]
    [FriendOf(typeof(DlgUnionKeJi))]
    public static class DlgUnionKeJiSystem
    {
        public static void RegisterUIEvent(this DlgUnionKeJi self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgUnionKeJi self, Entity contextData = null)
        {
            self.Init().Coroutine();
        }

        private static async ETTask Init(this DlgUnionKeJi self)
        {
            self.View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(false);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            U2C_UnionMyInfoResponse response = await UnionNetHelper.UnionMyInfo(self.Root());
            self.UnionMyInfo = response.UnionMyInfo;

            self.View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(true);
            self.IsInitInfo = true;

            foreach (UnionPlayerInfo unionPlayerInfo in response.UnionMyInfo.UnionPlayerList)
            {
                if (unionPlayerInfo.UserID == unit.Id)
                {
                    if (unionPlayerInfo.Position == 0)
                    {
                        self.View.E_FunctionSetBtnToggleGroup.transform.Find("Type_0").gameObject.SetActive(false);
                        self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(1);
                        return;
                    }
                }
            }

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgUnionKeJi self, int index)
        {
            if (!self.IsInitInfo)
            {
                return;
            }

            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_UnionKeJiResearch.uiTransform.gameObject.SetActive(true);
                    self.View.ES_UnionKeJiResearch.UnionMyInfo = self.UnionMyInfo;
                    self.View.ES_UnionKeJiResearch.UpdateInfo(self.View.ES_UnionKeJiResearch.Position);
                    break;
                case 1:
                    self.View.ES_UnionKeJiLearn.uiTransform.gameObject.SetActive(true);
                    self.View.ES_UnionKeJiLearn.UnionMyInfo = self.UnionMyInfo;
                    self.View.ES_UnionKeJiLearn.UpdateInfo(self.View.ES_UnionKeJiLearn.Position);
                    break;
            }
        }
    }
}