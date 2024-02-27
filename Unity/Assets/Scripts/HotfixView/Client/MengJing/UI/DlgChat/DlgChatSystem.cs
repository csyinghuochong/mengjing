using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgChat))]
    public static class DlgChatSystem
    {
        public static void RegisterUIEvent(this DlgChat self)
        {
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_ChatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChatItemsRefresh);
        }

        public static void ShowWindow(this DlgChat self, Entity contextData = null)
        {
            self.View.E_WordToggle.IsSelected(true);
        }

        private static void OnCloseButton(this DlgChat self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Chat);
        }

        private static void OnChatItemsRefresh(this DlgChat self, Transform transform, int index)
        {
            Scroll_Item_ChatItem scrollItemChatItem = self.ScrollItemChatItems[index].BindTrans(transform);
            scrollItemChatItem.Refresh(self.ShowChatInfos[index]);
        }

        private static void OnFunctionSetBtn(this DlgChat self, int index)
        {
            Log.Debug($"按下Toggle：{index}");

            UICommonHelper.SetToggleShow(self.View.E_WordToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.View.E_TeamToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.View.E_UnionToggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.View.E_SystemToggle.gameObject, index == 3);
            UICommonHelper.SetToggleShow(self.View.E_FriendToggle.gameObject, index == 4);
            UICommonHelper.SetToggleShow(self.View.E_PickToggle.gameObject, index == 5);
            UICommonHelper.SetToggleShow(self.View.E_PaiMaiToggle.gameObject, index == 6);

            self.CurrentChatType = index;
            self.Refresh();
        }

        private static void Refresh(this DlgChat self)
        {
            self.RefreshChatItems();
        }

        private static void RefreshChatItems(this DlgChat self)
        {
            // List<ChatInfo> chatlist = self.Root().GetComponent<ChatComponent>().GetChatListByType(itemType);
            List<ChatInfo> chatInfos = new List<ChatInfo>();
            self.View.E_ChatItemsLoopVerticalScrollRect.gameObject.SetActive(self.CurrentChatType != ChannelEnum.System);

            // 假数据
            chatInfos.Add(new ChatInfo());
            chatInfos.Add(new ChatInfo());
            chatInfos.Add(new ChatInfo());

            self.ShowChatInfos.Clear();
            self.ShowChatInfos.AddRange(chatInfos);

            self.AddUIScrollItems(ref self.ScrollItemChatItems, self.ShowChatInfos.Count);
            self.View.E_ChatItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChatInfos.Count);
        }
    }
}