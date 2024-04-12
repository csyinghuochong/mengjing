using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_EquipItem))]
    [FriendOfAttribute(typeof (ES_EquipItem))]
    public static partial class ES_EquipItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_EquipItem self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipItem self)
        {
            self.DestroyWidget();
        }

        public static void InitUI(this ES_EquipItem self, int subType)
        {
            self.BagInfo = null;

            self.E_EquipIconImage.gameObject.SetActive(false);
            self.E_EquipQualityImage.gameObject.SetActive(false);
            self.E_BangDingImage.gameObject.SetActive(false);

            if (subType < 100)
            {
                string qianghuaName = ItemViewData.EquipWeiZhiToName[subType].Icon;

                qianghuaName = "Img_20";
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, qianghuaName);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.E_EquipBackImage.sprite = sp;
            }
        }

        public static void Refresh(this ES_EquipItem self, BagInfo bagInfo, int occ, ItemOperateEnum itemOperateEnum,
        List<BagInfo> equipList)
        {
            self.E_EquipButton.AddListener(self.OnEquipButton);

            self.Occ = occ;
            self.BagInfo = bagInfo;
            self.ItemOperateEnum = itemOperateEnum;
            self.EquipList = equipList;
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
            self.E_BangDingImage.gameObject.SetActive(bagInfo.isBinging);
        }

        private static void OnEquipButton(this ES_EquipItem self)
        {
            if (self.BagInfo == null)
            {
                return;
            }

            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = self.BagInfo,
                    ItemOperateEnum = self.ItemOperateEnum,
                    InputPoint = Input.mousePosition,
                    Occ = self.Occ,
                    EquipList = self.EquipList
                });
        }
    }
}