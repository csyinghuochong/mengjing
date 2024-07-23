using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_FriendBlackItem))]
    [EntitySystemOf(typeof(Scroll_Item_FriendBlackItem))]
    public static partial class Scroll_Item_FriendBlackItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_FriendBlackItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_FriendBlackItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_FriendBlackItem self, FriendInfo friendInfo, Action removeAction)
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

            self.E_WatchButton.AddListenerAsync(async () =>
            {
                F2C_WatchPlayerResponse response = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.FriendInfo.UserId, 0);
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Watch);
                DlgWatch dlgWatch = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgWatch>();
                dlgWatch.OnUpdateUI(response);
            });

            self.E_RemoveButton.AddListenerAsync(async () =>
            {
                await FriendNetHelper.RequestRemoveBlack(self.Root(), self.FriendInfo.UserId);
                await FriendNetHelper.RequestFriendInfo(self.Root());
                removeAction?.Invoke();
            });
        }
    }
}