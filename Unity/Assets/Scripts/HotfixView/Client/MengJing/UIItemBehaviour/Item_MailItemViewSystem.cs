using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_MailItem))]
    [EntitySystemOf(typeof (Scroll_Item_MailItem))]
    public static partial class Scroll_Item_MailItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MailItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MailItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_MailItem self, MailInfo mailInfo)
        {
            self.E_ItemIconImage.gameObject.SetActive(false);
            self.E_MailIconImage.gameObject.SetActive(false);
            self.E_ImageSelectImage.gameObject.SetActive(false);
            self.E_ImageButtonButton.AddListener(self.OnImageButton);

            self.MailInfo = mailInfo;
            self.E_TextConentText.text = mailInfo.Title;

            if (mailInfo.ItemList != null && mailInfo.ItemList.Count > 0)
            {
                self.E_ItemIconImage.gameObject.SetActive(true);
                ItemInfoProto itemInfoProto = mailInfo.ItemList[0];
                self.E_ItemIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemInfoProto.ItemID.ToString()));
            }
            else
            {
                self.E_MailIconImage.gameObject.SetActive(true);
            }
        }

        public static void OnImageButton(this Scroll_Item_MailItem self)
        {
            self.Root().GetComponent<MailComponentC>().SelectMail = self.MailInfo;
            self.ActionClick();
        }

        public static void SetSelected(this Scroll_Item_MailItem self, MailInfo value)
        {
            self.E_ImageSelectImage.gameObject.SetActive(self.MailInfo == value);
        }

        public static void ResetUI(this Scroll_Item_MailItem self)
        {
            self.MailInfo = null;
        }

        public static void SetClickHandler(this Scroll_Item_MailItem self, Action action)
        {
            self.ActionClick = action;
        }
    }
}