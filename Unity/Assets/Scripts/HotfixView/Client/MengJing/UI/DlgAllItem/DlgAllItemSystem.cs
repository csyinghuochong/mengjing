using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgAllItem))]
    public static class DlgAllItemSystem
    {
        public static void RegisterUIEvent(this DlgAllItem self)
        {
            self.View.E_Button_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_AllItem); });
        }

        public static void ShowWindow(this DlgAllItem self, Entity contextData = null)
        {
            self.View.E_ItemButton.gameObject.gameObject.SetActive(false);

            self.InitItemList();
        }

        private static void InitItemList(this DlgAllItem self)
        {
            GameObject gameObject = self.View.E_ItemButton.gameObject;

            foreach (ItemConfig itemConfig in ItemConfigCategory.Instance.GetAll().Values)
            {
                GameObject newItem = UnityEngine.Object.Instantiate(gameObject, self.View.EG_ContentRectTransform);
                newItem.SetActive(true);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                newItem.transform.Find("Image_Icon").GetComponent<Image>().sprite = sp;

                string qualityiconStr = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
                string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
                Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
                newItem.transform.Find("Image_Quality").GetComponent<Image>().sprite = sp2;

                newItem.transform.Find("Text_Name").GetComponent<Text>().text = itemConfig.ItemName;
                newItem.transform.Find("Text_Name").GetComponent<Text>().color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);
                
                newItem.transform.Find("Image_Icon").GetComponent<Button>().AddListener(() =>
                {
                    ItemInfo bagInfo = new ItemInfo();
                    bagInfo.ItemID = itemConfig.Id;
                    bagInfo.ItemNum = 1;
                    EventSystem.Instance.Publish(self.Root(),
                        new ShowItemTips()
                        {
                            BagInfo = bagInfo,
                            ItemOperateEnum = ItemOperateEnum.None,
                            InputPoint = Input.mousePosition,
                            Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                            EquipList = new List<ItemInfo>()
                        });
                });
            }
        }
    }
}