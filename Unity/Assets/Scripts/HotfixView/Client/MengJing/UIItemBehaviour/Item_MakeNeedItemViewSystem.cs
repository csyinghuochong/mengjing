using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MakeNeedItem))]
    [EntitySystemOf(typeof(Scroll_Item_MakeNeedItem))]
    public static partial class Scroll_Item_MakeNeedItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MakeNeedItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MakeNeedItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClickUIItem(this Scroll_Item_MakeNeedItem self)
        {
            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemID = self.ItemId;
            //弹出Tips
            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = bagInfo,
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new List<ItemInfo>()
                });
        }

        public static void UpdateItem(this Scroll_Item_MakeNeedItem self, int itemId, int needNumber)
        {
            self.E_Image_EventTriggerButton.AddListener(self.OnClickUIItem);

            self.ItemId = itemId;
            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(itemId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Image_ItemIconImage.sprite = sp;
            string qualityiconStr = FunctionUI.ItemQualiytoPath(itemconfig.ItemQuality);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);

            self.E_Image_ItemQualityImage.sprite = sp2;

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            long haveNumber = bagComponent.GetItemNumber(itemId);
            using (zstring.Block())
            {
                self.E_Label_ItemNumText.text = zstring.Format("{0}/{1}", haveNumber, needNumber);
            }

            if (haveNumber >= needNumber)
            {
                self.E_Label_ItemNumText.color = new Color(130f / 255f, 255f / 255f, 0f / 255f);
            }
            else
            {
                self.E_Label_ItemNumText.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
            }

            self.E_Label_ItemNameText.text = itemconfig.ItemName;
            self.E_Label_ItemNameText.color = FunctionUI.QualityReturnColor(itemconfig.ItemQuality);
        }
    }
}