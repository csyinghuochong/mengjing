using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (Scroll_Item_FriendChatItem))]
    public static partial class Scroll_Item_FriendChatItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_FriendChatItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_FriendChatItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_FriendChatItem self, ChatInfo chatInfo)
        {
            self.E_HeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, chatInfo.Occ.ToString()));
            self.E_NameText.text = chatInfo.PlayerName;
            self.E_InfoText.text = chatInfo.ChatMsg;
        }
    }
}