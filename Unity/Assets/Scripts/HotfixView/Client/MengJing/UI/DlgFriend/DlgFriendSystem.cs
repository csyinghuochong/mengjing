using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_FriendList))]
    [FriendOf(typeof(ES_FriendBlack))]
    [FriendOf(typeof(ES_FriendApply))]
    [FriendOf(typeof(DlgFriend))]
    [FriendOf(typeof(DlgFriendBlack))]
    [FriendOf(typeof(DlgFriendList))]
    [FriendOf(typeof(ES_RoleBag))]
    public static class DlgFriendSystem
    {
        [Event(SceneType.Demo)]
        public class DataUpdate_FriendUpdate_FriendItemsRefresh : AEvent<Scene, FriendUpdate>
        {
            protected override async ETTask Run(Scene root, FriendUpdate args)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgFriend>()?.View.ES_FriendList.Refresh();
                root.GetComponent<UIComponent>().GetDlgLogic<DlgFriend>()?.View.ES_FriendApply.Refresh();
                await ETTask.CompletedTask;
            }
        }

        [Event(SceneType.Demo)]
        public class DataUpdate_FriendChat_Refresh : AEvent<Scene, FriendChat>
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

            self.RequestFriendInfo().Coroutine();

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.FriendApply, self.Reddot_FriendApply);
            redPointComponent.RegisterReddot(ReddotType.FriendChat, self.Reddot_FriendChat);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgFriend self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgFriend self)
        {
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.FriendApply, self.Reddot_FriendApply);
            redPointComponent.UnRegisterReddot(ReddotType.FriendChat, self.Reddot_FriendChat);
        }

        public static void Reddot_FriendChat(this DlgFriend self, int num)
        {
            self.View.E_Type_0Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_FriendApply(this DlgFriend self, int num)
        {
            self.View.E_Type_1Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static async ETTask RequestFriendInfo(this DlgFriend self)
        {
            await FriendNetHelper.RequestFriendInfo(self.Root());
            if (self.IsDisposed)
            {
                return;
            }

            self.ClickEnabled = true;
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
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
              default:
                    break;
            }
        }
        
    }
}