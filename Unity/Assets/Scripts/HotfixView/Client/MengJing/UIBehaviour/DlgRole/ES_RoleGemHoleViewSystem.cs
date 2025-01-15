using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [EntitySystemOf(typeof(ES_RoleGemHole))]
    [FriendOfAttribute(typeof(ES_RoleGemHole))]
    public static partial class ES_RoleGemHoleSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleGemHole self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_SelectButton.AddListener(self.OnSelectButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleGemHole self)
        {
            self.DestroyWidget();
        }

        public static void OnSelectButton(this ES_RoleGemHole self)
        {
            if (self.Index == -1)
            {
                return;
            }

            if (self.E_ItemIconImage.gameObject.activeSelf)
            {
                EventSystem.Instance.Publish(self.Root(),
                    new ShowItemTips()
                    {
                        BagInfo = self.Baginfo,
                        ItemOperateEnum = ItemOperateEnum.XiangQianGem,
                        InputPoint = Input.mousePosition,
                        Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                        EquipList = new List<ItemInfo>(),
                        CurrentHouse = -1
                    });
            }

            self.ClickHandler?.Invoke(self.Index);
        }

        public static void SetSelected(this ES_RoleGemHole self, bool selected)
        {
            self.E_HighlightImage.gameObject.SetActive(selected);
        }

        public static void SetClickHandler(this ES_RoleGemHole self, Action<int> clickHander)
        {
            self.ClickHandler = clickHander;
        }

        public static void OnUpdateUI(this ES_RoleGemHole self, int holeId, int gemId, int index)
        {
            self.Index = index;
            self.E_HighlightImage.gameObject.SetActive(false);
            if (holeId == 0)
            {
                self.uiTransform.gameObject.SetActive(false);
                return;
            }

            self.uiTransform.gameObject.SetActive(true);

            using (zstring.Block())
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, ItemViewData.GemHoleBack[holeId]);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.E_HoleBackImage.sprite = sp;
                self.E_HoleNameText.text = ItemViewData.GemHoleName[holeId];

                if (gemId == 0)
                {
                    self.E_ItemIconImage.gameObject.SetActive(false);
                    return;
                }
            }

            self.E_ItemIconImage.gameObject.SetActive(true);
            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemID = gemId;
            self.Baginfo = bagInfo;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.E_ItemIconImage.overrideSprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
        }
    }
}