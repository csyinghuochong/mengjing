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
        public class DataUpdate_FriendUpdate_FriendItemsRefresh: AEvent<Scene, FriendUpdate>
        {
            protected override async ETTask Run(Scene root, FriendUpdate args)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgFriend>()?.View.ES_FriendList.Refresh();
                root.GetComponent<UIComponent>().GetDlgLogic<DlgFriend>()?.View.ES_FriendApply.Refresh();
                await ETTask.CompletedTask;
            }
        }

        [Event(SceneType.Demo)]
        public class DataUpdate_FriendChat_Refresh: AEvent<Scene, FriendChat>
        {
            protected override async ETTask Run(Scene root, FriendChat args)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgFriend>()?.View.ES_FriendList.OnFriendChat();
                await ETTask.CompletedTask;
            }
        }

        public static void RegisterUIEvent(this DlgFriend self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgFriend self, Entity contextData = null)
        {
            self.RequestFriendInfo().Coroutine();
        }

        public static async ETTask RequestFriendInfo(this DlgFriend self)
        {
            await FriendNetHelper.RequestFriendInfo(self.Root());
            if (self.IsDisposed)
            {
                return;
            }

            self.ClickEnabled = true;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0));
            if (unionId > 0)
            {
                self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(4);
            }
            else
            {
                self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(3);
            }
        }

        private static void OnFunctionSetBtn(this DlgFriend self, int index)
        {
            if (!self.ClickEnabled)
            {
                return;
            }

            CommonViewHelper.HideChildren(self.View.EG_SubViewNodeRectTransform);

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
                    self.View.ES_UnionShow.OnUpdateUI();
                    break;
                case 4:
                    Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                    long unionId = (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0));
                    if (unionId == 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi("请先创建或者加入一个家族");
                        return;
                    }

                    self.View.ES_UnionMy.uiTransform.gameObject.SetActive(true);
                    self.View.ES_UnionMy.OnUpdateUI().Coroutine();
                    break;
            }
        }

        public static void OnCreateUnion(this DlgFriend self)
        {
            self.View.ES_UnionShow.OnCreateUnion();
        }

        public static void OnLeaveUnion(this DlgFriend self)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }
    }
}