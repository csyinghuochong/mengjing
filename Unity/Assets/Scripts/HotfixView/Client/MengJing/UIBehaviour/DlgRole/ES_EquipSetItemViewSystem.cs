using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_EquipSetItem))]
    [FriendOfAttribute(typeof (ES_EquipSetItem))]
    public static partial class ES_EquipSetItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_EquipSetItem self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_EquipButton.AddListener(self.OnEquipButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipSetItem self)
        {
            self.DestroyWidget();
        }

        public static void OnEquipButton(this ES_EquipSetItem self)
        {
            if (self.BagInfo == null)
                return;

            if (self.OnClickAction != null)
            {
                self.OnClickAction.Invoke(self.BagInfo);
                return;
            }

            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = self.BagInfo,
                    ItemOperateEnum = self.itemOperateEnum,
                    InputPoint = Input.mousePosition,
                    Occ = self.Occ,
                    EquipList = self.EquipIdList
                });
        }

        public static void InitUI(this ES_EquipSetItem self, int subType)
        {
            self.BagInfo = null;

            self.E_EquipIconImage.gameObject.SetActive(false);
            self.E_EquipQualityImage.gameObject.SetActive(false);
            self.EG_BangDingRectTransform.gameObject.SetActive(false);
            self.E_QiangHuaNameText.text = ItemViewHelp.GetItemSubType3Name(subType);
            // if (subType < 100)
            // {
            //     string qianghuaName = ItemViewData.EquipWeiZhiToName[subType].Icon;
            //     string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, qianghuaName);
            //     Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            //
            //     self.E_EquipBackImage.sprite = sp;
            // }
        }

        public static void UpdateData(this ES_EquipSetItem self, ItemInfo bagInfo, int occ, ItemOperateEnum itemOperateEnum,
        List<ItemInfo> equipIdList)
        {
            try
            {
                self.Occ = occ;
                self.BagInfo = bagInfo;
                self.itemOperateEnum = itemOperateEnum;
                self.EquipIdList = equipIdList;

                if (bagInfo != null)
                {
                    ItemConfig itemconfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                    self.E_EquipIconImage.gameObject.SetActive(true);
                    self.E_EquipIconImage.sprite = sp;

                    //设置品质
                    string ItemQuality = FunctionUI.ItemQualiytoPath(itemconfig.ItemQuality);
                    self.E_EquipQualityImage.gameObject.SetActive(true);
                    string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemQuality);
                    Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);

                    self.E_EquipQualityImage.sprite = sp2;

                    //显示绑定
                    self.EG_BangDingRectTransform.gameObject.SetActive(bagInfo.isBinging);
                }
                else
                {
                    self.E_EquipIconImage.gameObject.SetActive(false);
                    self.E_EquipQualityImage.gameObject.SetActive(false);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
    }
}
