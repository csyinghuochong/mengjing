using System;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectServerItem))]
    [EntitySystemOf(typeof(Scroll_Item_SelectServerItem))]
    public static partial class Scroll_Item_SelectServerItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SelectServerItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SelectServerItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClickImageButton(this Scroll_Item_SelectServerItem self)
        {
            self.ClickHandler(self.ServerInfo);
        }

        public static void OnUpdateData(this Scroll_Item_SelectServerItem self, ServerItem serverId, int index)
        {
            self.E_ImageButtonButton.AddListener(self.OnClickImageButton);
            self.ServerInfo = serverId;
            self.E_Text_ServerNameText.text = serverId.ServerName;
            self.E_ImageNewImage.gameObject.SetActive(index == 0 || serverId.New == 1);
        }

        public static void SetClickHandler(this Scroll_Item_SelectServerItem self, Action<ServerItem> action)
        {
            self.ClickHandler = action;
        }
    }
}