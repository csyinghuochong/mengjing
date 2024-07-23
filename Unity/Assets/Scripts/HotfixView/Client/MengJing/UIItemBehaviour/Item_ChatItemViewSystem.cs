using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChatItem))]
    [EntitySystemOf(typeof(Scroll_Item_ChatItem))]
    public static partial class Scroll_Item_ChatItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ChatItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ChatItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_ChatItem self, ChatInfo chatInfo)
        {
            self.E_HeadIconButton.AddListenerAsync(self.OnWatchNemu);
            self.E_NameButton.AddListenerAsync(self.OnWatchNemu);
            for (int i = 0; i < ChannelEnum.Number; i++)
            {
                using (zstring.Block())
                {
                    self.TitleList[i] = self.uiTransform.Find(zstring.Format("EG_Node1/{0}", i)).gameObject;
                }

                self.TitleList[i].SetActive(false);
            }

            self.ChatInfo = chatInfo;
            int startindex = chatInfo.ChatMsg.IndexOf("<link=", StringComparison.Ordinal);
            int endindex = chatInfo.ChatMsg.IndexOf("></link>", StringComparison.Ordinal);

            string showValue = string.Empty;
            if (startindex != -1)
            {
                showValue = chatInfo.ChatMsg.Substring(0, startindex);
            }
            else
            {
                showValue = chatInfo.ChatMsg;
            }

            if (chatInfo.ChannelId == (int)ChannelEnum.System || chatInfo.ChannelId == ChannelEnum.Pick)
            {
                self.EG_Node1RectTransform.gameObject.SetActive(false);
                self.EG_Node2RectTransform.gameObject.SetActive(true);

                self.E_SystemText.text = showValue;

                self.uiTransform.GetComponent<RectTransform>().sizeDelta =
                        new Vector2(1000, self.E_SystemText.preferredHeight + 50);
            }
            else
            {
                self.EG_Node1RectTransform.gameObject.SetActive(true);
                self.EG_Node2RectTransform.gameObject.SetActive(false);

                self.E_NameText.text = chatInfo.PlayerName;
                self.E_LevelText.text = chatInfo.PlayerLevel.ToString();

                self.E_TextText.text = showValue;

                if (self.E_TextText.preferredHeight > 100)
                {
                    self.uiTransform.gameObject.GetComponent<RectTransform>().sizeDelta =
                            new Vector2(1000, self.E_TextText.preferredHeight + 110);
                }
                else
                {
                    self.uiTransform.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 200);
                }

                for (int i = 0; i < ChannelEnum.Number; i++)
                {
                    self.TitleList[i].SetActive(false);
                }

                self.TitleList[chatInfo.ChannelId].SetActive(true);

                //if (chatInfo.ChannelId == ChannelEnum.Word)
                //{
                //    self.Obj_ImgHeadIcon.SetActive(false);
                //    self.Obj_ImgHeadIconXiTong.SetActive(true);
                //}
                //else
                {
                    self.E_HeadIconButton.gameObject.SetActive(true);
                    self.E_HeadIconXiTongImage.gameObject.SetActive(false);

                    self.E_HeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, chatInfo.Occ.ToString()));
                }

                self.uiTransform.gameObject.SetActive(true);
            }
        }

        private static async ETTask OnWatchNemu(this Scroll_Item_ChatItem self)
        {
            if (self.ChatInfo.UserId == UnitHelper.GetMyUnitFromClientScene(self.Root()).Id)
            {
                return;
            }

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            // UI uI = await UIHelper.Create(self.ZoneScene(), UIType.UIWatchMenu);
            // uI.GetComponent<UIWatchMenuComponent>().OnUpdateUI_1(MenuEnumType.Chat, self.mChatInfo.UserId, self.mChatInfo.PlayerName).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}