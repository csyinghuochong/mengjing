using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_XiLianShowEquipItem))]
    [EntitySystemOf(typeof(Scroll_Item_XiLianShowEquipItem))]
    public static partial class Scroll_Item_XiLianShowEquipItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_XiLianShowEquipItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_XiLianShowEquipItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_XiLianShowEquipItem self, ItemInfo bagInfo, int occ, ItemOperateEnum itemOperateEnum,
        List<ItemInfo> equipList)
        {
            self.Occ = occ;
            self.BagInfo = bagInfo;
            self.ItemOperateEnum = itemOperateEnum;
            self.EquipList = equipList;
            self.E_HighlightImage.gameObject.SetActive(false);

            if (bagInfo == null)
            {
                self.EG_ShowRectTransform.gameObject.SetActive(false);
                self.EG_NullRectTransform.gameObject.SetActive(true);
                return;
            }

            self.EG_ShowRectTransform.gameObject.SetActive(true);
            self.EG_NullRectTransform.gameObject.SetActive(false);

            self.E_ClickButton.AddListener(self.OnEquipButton);

            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ItemIconImage.sprite = sp;

            string ItemQuality = FunctionUI.ItemQualiytoPath(itemconfig.ItemQuality);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality);
            Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
            self.E_ItemQualityImage.sprite = sp2;

            self.E_ItemNameText.text = itemconfig.ItemName;
            self.E_ItemNameText.color = FunctionUI.QualityReturnColorDi(itemconfig.ItemQuality);

            using (zstring.Block())
            {
                self.E_ItemWordText.text = zstring.Format("隐藏词条：{0}",
                    bagInfo.XiLianHideProLists.Count + bagInfo.HideSkillLists.Count + bagInfo.XiLianHideTeShuProLists.Count);
            }
        }

        private static void OnEquipButton(this Scroll_Item_XiLianShowEquipItem self)
        {
            if (self.BagInfo == null)
            {
                return;
            }

            if (self.OnClickAction != null)
            {
                self.OnClickAction.Invoke(self.BagInfo);
                return;
            }

            // EventSystem.Instance.Publish(self.Root(),
            //     new ShowItemTips()
            //     {
            //         BagInfo = self.BagInfo,
            //         ItemOperateEnum = self.ItemOperateEnum,
            //         InputPoint = Input.mousePosition,
            //         Occ = self.Occ,
            //         EquipList = self.EquipList
            //     });
        }

        public static void UpdateSelectStatus(this Scroll_Item_XiLianShowEquipItem self, ItemInfo bagInfo)
        {
            self.E_HighlightImage.gameObject.SetActive(self.BagInfo == bagInfo);
        }
    }
}