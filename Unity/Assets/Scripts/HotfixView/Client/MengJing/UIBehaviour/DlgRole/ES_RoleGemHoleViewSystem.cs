using System;
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
            self.E_SelectButton.AddListener(self.OnBtn_Select);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleGemHole self)
        {
            self.DestroyWidget();
        }

        public static void OnBtn_Select(this ES_RoleGemHole self)
        {
            if (self.Index == -1)
            {
                return;
            }

            if (self.ES_CommonItem.uiTransform.gameObject.activeSelf)
            {
                self.ES_CommonItem.OnClickUIItem();
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
                self.E_HoleNameText.gameObject.SetActive(false);
                self.E_HoleBackImage.gameObject.SetActive(false);
                self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
                return;
            }

            using (zstring.Block())
            {
                if (holeId != 0)
                {
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("Img_hole_{0}", holeId));
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    self.E_HoleBackImage.sprite = sp;
                    self.E_HoleBackImage.gameObject.SetActive(true);
                }

                if (gemId == 0)
                {
                    self.E_HoleNameText.gameObject.SetActive(true);
                    self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
                    self.E_HoleNameText.text = ItemViewData.GemHoleName[holeId];
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("Img_hole_{0}", holeId));
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                    self.E_HoleBackImage.sprite = sp;
                    self.E_HoleBackImage.gameObject.SetActive(true);
                    return;
                }

                self.E_HoleBackImage.gameObject.SetActive(true);
                string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("Img_hole_{0}", holeId));
                Sprite sp1 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);
                self.E_HoleBackImage.sprite = sp1;
            }

            self.E_HoleNameText.gameObject.SetActive(false);
            self.ES_CommonItem.uiTransform.gameObject.SetActive(true);
            BagInfo bagInfo = BagInfo.Create();
            bagInfo.ItemID = gemId;
            bagInfo.ItemNum = 1;
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.XiangQianGem);
            self.ES_CommonItem.E_ItemQualityImage.gameObject.SetActive(false);
        }
    }
}