using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_FriendListItem))]
    [EntitySystemOf(typeof(Scroll_Item_FriendListItem))]
    public static partial class Scroll_Item_FriendListItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_FriendListItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_FriendListItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_FriendListItem self, FriendInfo friendInfo, Action deleteAction, Action<FriendInfo> chatAction)
        {
            self.FriendInfo = friendInfo;
            self.E_HeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, friendInfo.Occ.ToString()));
            self.E_OnLineTimeText.text = friendInfo.OnLineTime == 1 ? "状态:在线" : "状态:离线";
            using (zstring.Block())
            {
                self.E_PlayerLevelText.text = zstring.Format("等级: {0}级", friendInfo.PlayerLevel);
                self.E_PlayerNameText.text = friendInfo.PlayerName;
                self.E_OccNameText.text = zstring.Format("职业:{0}", OccupationConfigCategory.Instance.Get(friendInfo.Occ).OccupationName);
            }

            self.E_DeleteButton.AddListenerAsync(async () =>
            {
                await FriendNetHelper.RequestFriendDelete(self.Root(), self.FriendInfo.UserId);
                deleteAction?.Invoke();
            });
            self.E_WatchButton.AddListener(async () =>
            {
                F2C_WatchPlayerResponse response = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.FriendInfo.UserId, 0);
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Watch);
                DlgWatch dlgWatch = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>();
                dlgWatch.OnUpdateUI(response);
            });
            self.E_ChatButton.AddListener(() => { chatAction.Invoke(self.FriendInfo); });
        }
    }
}