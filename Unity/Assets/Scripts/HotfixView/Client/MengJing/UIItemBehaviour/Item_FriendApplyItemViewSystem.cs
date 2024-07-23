using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_FriendApplyItem))]
    [EntitySystemOf(typeof(Scroll_Item_FriendApplyItem))]
    public static partial class Scroll_Item_FriendApplyItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_FriendApplyItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_FriendApplyItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_FriendApplyItem self, FriendInfo friendInfo)
        {
            self.FriendInfo = friendInfo;

            self.E_HeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, friendInfo.Occ.ToString()));
            self.E_PlayerOnLineText.text = friendInfo.OnLineTime == 1 ? "状态:在线" : "状态:离线";
            if (friendInfo.OnLineTime != 1)
            {
                self.E_PlayerOnLineText.color = new Color(0.62f, 0.62f, 0.62f);
            }

            using (zstring.Block())
            {
                self.E_PlayerLevelText.text = zstring.Format("等级:{0}", friendInfo.PlayerLevel);
            }

            self.E_PlayerNameText.text = friendInfo.PlayerName;
            self.E_PlayerOccText.text = OccupationConfigCategory.Instance.Get(friendInfo.Occ).OccupationName;

            self.E_AgreeButton.AddListener(() => { FriendNetHelper.RequestFriendApplyReply(self.Root(), self.FriendInfo, 1).Coroutine(); });
            self.E_RefuseButton.AddListener(() => { FriendNetHelper.RequestFriendApplyReply(self.Root(), self.FriendInfo, 2).Coroutine(); });
        }
    }
}