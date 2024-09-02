using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_SeasonJingHeItem))]
    [EntitySystemOf(typeof (Scroll_Item_SeasonJingHeItem))]
    public static partial class Scroll_Item_SeasonJingHeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SeasonJingHeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SeasonJingHeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClickBtn(this Scroll_Item_SeasonJingHeItem self)
        {
            self.GetParent<ES_SeasonJingHe>().UpdateInfo(self.JingHeId);
        }

        public static void OnUpdateData(this Scroll_Item_SeasonJingHeItem self)
        {
            self.E_ClickBtnButton.AddListener(self.OnClickBtn);

            if (self.JingHeId == 0)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> equiplist = bagComponent.GetCurJingHeList();

            self.E_IconImgImage.gameObject.SetActive(false);
            self.BagInfo = null;
            for (int i = 0; i < equiplist.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equiplist[i].ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.EquipType == 201 && equiplist[i].EquipIndex == self.JingHeId)
                {
                    self.BagInfo = equiplist[i];
                    self.E_IconImgImage.gameObject.SetActive(true);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                    self.E_IconImgImage.sprite = sp;
                    self.E_NameTextText.text = itemConfig.ItemName;
                    break;
                }
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            self.E_LockImgImage.gameObject.SetActive(!userInfoComponent.UserInfo.OpenJingHeIds.Contains(self.JingHeId));
        }
    }
}