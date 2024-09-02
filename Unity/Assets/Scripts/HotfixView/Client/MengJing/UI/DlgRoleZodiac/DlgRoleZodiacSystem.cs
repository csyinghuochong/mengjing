using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_EquipItem))]
    [FriendOf(typeof(DlgRoleZodiac))]
    public static class DlgRoleZodiacSystem
    {
        public static void RegisterUIEvent(this DlgRoleZodiac self)
        {
            self.EquipList.Add(self.View.ES_EquipItem_0);
            self.EquipList.Add(self.View.ES_EquipItem_1);
            self.EquipList.Add(self.View.ES_EquipItem_2);
            self.EquipList.Add(self.View.ES_EquipItem_3);
            self.EquipList.Add(self.View.ES_EquipItem_4);
            self.EquipList.Add(self.View.ES_EquipItem_5);
            self.EquipList.Add(self.View.ES_EquipItem_6);
            self.EquipList.Add(self.View.ES_EquipItem_7);
            self.EquipList.Add(self.View.ES_EquipItem_8);
            self.EquipList.Add(self.View.ES_EquipItem_9);
            self.EquipList.Add(self.View.ES_EquipItem_10);
            self.EquipList.Add(self.View.ES_EquipItem_11);

            self.View.E_ButtonColseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRole>().OnCloseRoleZodiac();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleZodiac);
            });

            self.View.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
        }

        public static void ShowWindow(this DlgRoleZodiac self, Entity contextData = null)
        {
            self.View.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        private static void OnItemTypeSet(this DlgRoleZodiac self, int index)
        {
            self.CurrentItemType = index;
            self.OnClickPageButton(index);
        }

        private static void OnClickPageButton(this DlgRoleZodiac self, int page)
        {
            self.ResetEquipShow();
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            for (int i = 0; i < self.EquipList.Count; i++)
            {
                ES_EquipItem item = self.EquipList[i];
                item.E_EquipBackImage.gameObject.SetActive(false);
                item.E_EquipQualityImage.gameObject.SetActive(true);

                //改变底框
                if (page == 0)
                {
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, "ItemQuality_2");
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    item.E_EquipQualityImage.sprite = sp;
                }

                if (page == 1)
                {
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, "ItemQuality_3");
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    item.E_EquipQualityImage.sprite = sp;
                }

                if (page == 2)
                {
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, "ItemQuality_4");
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    item.E_EquipQualityImage.sprite = sp;
                }

                if (page == 3)
                {
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, "ItemQuality_5");
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    item.E_EquipQualityImage.sprite = sp;
                }
            }

            List<ItemInfo> equiplist = self.EquipInfoList;
            for (int i = 0; i < equiplist.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equiplist[i].ItemID);
                if (itemConfig.EquipType != 101)
                {
                    continue;
                }

                int subType = itemConfig.ItemSubType / 100;
                if (page == 0 && subType != 11)
                {
                    continue;
                }

                if (page == 1 && subType != 12)
                {
                    continue;
                }

                if (page == 2 && subType != 13)
                {
                    continue;
                }

                if (page == 3 && subType != 14)
                {
                    continue;
                }

                ES_EquipItem esEquipItem = self.EquipList[itemConfig.ItemSubType % 100 - 1];
                esEquipItem.Refresh(equiplist[i], self.Occ, self.ItemOperateEnum, equiplist);
            }

            //线条显示
            for (int i = 0; i < self.View.EG_LinkShowSetRectTransform.transform.childCount; i++)
            {
                GameObject obj = self.View.EG_LinkShowSetRectTransform.transform.GetChild(i).gameObject;
                obj.SetActive(false);
                string linkName = obj.name;
                string resName = "Link_2";

                if (page == 1)
                {
                    linkName = linkName.Replace("160001", "160002");
                    resName = "Link_3";
                }

                if (page == 2)
                {
                    linkName = linkName.Replace("160001", "160003");
                    resName = "Link_4";
                }

                if (ItemHelper.IfShengXiaoActiveLine(linkName, equiplist))
                {
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, resName);
                    Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

                    obj.GetComponent<Image>().sprite = sp;
                    obj.SetActive(true);
                }
            }
        }

        public static void ResetEquipShow(this DlgRoleZodiac self)
        {
            for (int i = 0; i < self.EquipList.Count; i++)
            {
                ES_EquipItem esEquipItem = self.EquipList[i];
                esEquipItem.InitUI(1101);
            }
        }

        public static void OnInitUI(this DlgRoleZodiac self, List<ItemInfo> equiplist, int occ, ItemOperateEnum itemOperateEnum)
        {
            self.EquipInfoList = equiplist;
            self.ItemOperateEnum = itemOperateEnum;
            self.Occ = occ;

            self.View.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        public static void UpdateBagUI(this DlgRoleZodiac self, List<ItemInfo> equiplist, int occ, ItemOperateEnum itemOperateEnum)
        {
            self.EquipInfoList = equiplist;
            self.ItemOperateEnum = itemOperateEnum;
            self.Occ = occ;

            self.OnClickPageButton(self.CurrentItemType);
        }
    }
}
