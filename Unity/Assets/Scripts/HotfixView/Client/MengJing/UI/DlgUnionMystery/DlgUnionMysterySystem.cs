namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_BagItemUpdate_DlgUnionMysteryRefresh : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene root, BagItemUpdate args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgUnionMystery>()?.View.ES_UnionMystery_B.UpdateItemNum();

            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_UnionMystery_A))]
    [FriendOf(typeof(ES_UnionMystery_B))]
    [FriendOf(typeof(DlgUnionMystery))]
    public static class DlgUnionMysterySystem
    {
        public static void RegisterUIEvent(this DlgUnionMystery self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);

            self.View.ES_ModelShow.SetCameraPosition(new(0f, 115, 257f));
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(self.Root().GetComponent<UIComponent>().CurrentNpcId);
            using (zstring.Block())
            {
                self.View.ES_ModelShow.ShowOtherModel(zstring.Format("Npc/{0}", npcConfig.Asset)).Coroutine();
            }
        }

        public static void ShowWindow(this DlgUnionMystery self, Entity contextData = null)
        {
        }

        private static void OnFunctionSetBtn(this DlgUnionMystery self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_UnionMystery_A.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_UnionMystery_B.uiTransform.gameObject.SetActive(true);
                    self.View.ES_UnionMystery_B.OnUpdateUI();
                    break;
            }
        }
    }
}