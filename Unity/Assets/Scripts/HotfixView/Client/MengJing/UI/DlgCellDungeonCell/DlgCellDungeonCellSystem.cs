using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgCellDungeonCell))]
    public static class DlgCellDungeonCellSystem
    {
        public static void RegisterUIEvent(this DlgCellDungeonCell self)
        {
            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonCell); });
        }

        public static void ShowWindow(this DlgCellDungeonCell self, Entity contextData = null)
        {
            self.InitUI();
        }

        private static void InitUI(this DlgCellDungeonCell self)
        {
            CellDungeonComponentC cellDungeonComponentC = self.Root().GetComponent<CellDungeonComponentC>();
            CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(cellDungeonComponentC.ChapterId);
            int[] size = cellGenerateConfig.InitSize;

            self.View.EG_CellContainerRectTransform.GetComponent<GridLayoutGroup>().constraintCount = size[0];
            int totalsize = size[0] * size[1];

            GameObject cellItem = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<GameObject>(ABPathHelper.GetUGUIPath("Item/Item_CellDungeonCellItem"));
            for (int i = 0; i < totalsize; i++)
            {
                GameObject item = UnityEngine.Object.Instantiate(cellItem, self.View.EG_CellContainerRectTransform, true);
                item.SetActive(true);
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.zero;
                self.AddChild<Scroll_Item_CellDungeonCellItem>().OnUpdateUI(cellDungeonComponentC.GetFubenCell(i));
            }
        }
    }
}