namespace ET.Client
{
    [FriendOf(typeof (ES_UnionMy))]
    [FriendOf(typeof (ES_UnionShow))]
    [FriendOf(typeof (ES_FriendList))]
    [FriendOf(typeof (ES_FriendBlack))]
    [FriendOf(typeof (ES_FriendApply))]
    [FriendOf(typeof (DlgFriend))]
    [FriendOf(typeof (DlgFriendBlack))]
    [FriendOf(typeof (DlgFriendList))]
    [FriendOf(typeof (ES_RoleBag))]
    public static class DlgFriendSystem
    {
        [Event(SceneType.Demo)]
        public class DataUpdate_FriendUpdate_FriendItemsRefresh: AEvent<Scene, DataUpdate_FriendUpdate>
        {
            protected override async ETTask Run(Scene root, DataUpdate_FriendUpdate args)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgFriend>()?.View.ES_FriendList.Refresh();
                root.GetComponent<UIComponent>().GetDlgLogic<DlgFriend>()?.View.ES_FriendApply.Refresh();
                await ETTask.CompletedTask;
            }
        }

        public static void RegisterUIEvent(this DlgFriend self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgFriend self, Entity contextData = null)
        {
            self.View.E_Button_0Toggle.IsSelected(true);

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_HuoBiSet);
            uiComponent.GetDlgLogic<DlgHuoBiSet>().AddCloseEvent(self.OnCloseButton);
        }

        private static void OnFunctionSetBtn(this DlgFriend self, int index)
        {
            UICommonHelper.SetToggleShow(self.View.E_Button_0Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_Button_1Toggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_Button_2Toggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_Button_3Toggle.gameObject, index == 3);
            UICommonHelper.SetToggleShow(self.View.E_Button_4Toggle.gameObject, index == 4);

            UICommonHelper.HideChildren(self.View.EG_SubViewNodeRectTransform);

            switch (index)
            {
                case 0:
                    self.View.ES_FriendList.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_FriendApply.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.ES_FriendBlack.uiTransform.gameObject.SetActive(true);
                    break;
                case 3:
                    self.View.ES_UnionShow.uiTransform.gameObject.SetActive(true);
                    break;
                case 4:
                    self.View.ES_UnionMy.uiTransform.gameObject.SetActive(true);
                    break;
            }
        }

        private static void OnCloseButton(this DlgFriend self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();

            uiComponent.CloseWindow(WindowID.WindowID_Friend);
        }
    }
}