using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_CommonItem))]
    [EntitySystemOf(typeof (ES_RoleGemHole))]
    [FriendOfAttribute(typeof (ES_RoleGemHole))]
    public static partial class ES_RoleGemHoleSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleGemHole self, Transform transform)
        {
            self.uiTransform = transform;
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
                // self.UIGemItem.OnClickUIItem();
            }

            self.ClickHandler(self.Index);
        }

        public static void SetSelected(this ES_RoleGemHole self, bool selected)
        {
            self.E_BackImage.gameObject.SetActive(selected);
        }

        public static void SetClickHandler(this ES_RoleGemHole self, Action<int> clickHander)
        {
            self.ClickHandler = clickHander;
        }

        public static void OnUpdateUI(this ES_RoleGemHole self, int holeId, int gemId, int index)
        {
            // self.Index = index;
            // self.E_BackImage.gameObject.SetActive(false);
            // if (holeId == 0)
            // {
            //     self.Lab_HoleName.SetActive(false);
            //     self.ImageHoleName.SetActive(false);
            //     self.UIGemItem.GameObject.SetActive(false);
            //     return;
            // }
            //
            // if (holeId != 0)
            // {
            //     string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"Img_hole_{holeId}");
            //     Sprite sp = ResourcesComponent.Instance.LoadAsset<Sprite>(path);
            //     if (!self.AssetPath.Contains(path))
            //     {
            //         self.AssetPath.Add(path);
            //     }
            //
            //     self.ImageHoleName.GetComponent<Image>().sprite = sp;
            //     self.ImageHoleName.SetActive(true);
            // }
            //
            // if (gemId == 0)
            // {
            //     self.Lab_HoleName.SetActive(true);
            //     //self.ImageHoleName.SetActive(true);
            //     self.UIGemItem.GameObject.SetActive(false);
            //     self.Lab_HoleName.GetComponent<Text>().text = ItemViewHelp.GemHoleName[holeId];
            //     string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"Img_hole_{holeId}");
            //     Sprite sp = ResourcesComponent.Instance.LoadAsset<Sprite>(path);
            //     if (!self.AssetPath.Contains(path))
            //     {
            //         self.AssetPath.Add(path);
            //     }
            //
            //     self.ImageHoleName.GetComponent<Image>().sprite = sp;
            //     self.ImageHoleName.SetActive(true);
            //     return;
            // }
            //
            // self.ImageHoleName.SetActive(true);
            // string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, $"Img_hole_{holeId}");
            // Sprite sp1 = ResourcesComponent.Instance.LoadAsset<Sprite>(path1);
            // if (!self.AssetPath.Contains(path1))
            // {
            //     self.AssetPath.Add(path1);
            // }
            //
            // self.ImageHoleName.GetComponent<Image>().sprite = sp1;
            // self.Lab_HoleName.SetActive(false);
            // self.UIGemItem.GameObject.SetActive(true);
            // BagInfo bagInfo = new BagInfo() { ItemID = gemId, ItemNum = 1 };
            // self.UIGemItem.UpdateItem(bagInfo, ItemOperateEnum.XiangQianGem);
        }
    }
}