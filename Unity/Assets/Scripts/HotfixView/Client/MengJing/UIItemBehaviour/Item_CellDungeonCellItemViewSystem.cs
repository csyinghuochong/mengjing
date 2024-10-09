using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_CellDungeonCellItem))]
    public static partial class Scroll_Item_CellDungeonCellItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CellDungeonCellItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CellDungeonCellItem self)
        {
            self.DestroyWidget();
        }

        public static void UpdateOpenEffect(this Scroll_Item_CellDungeonCellItem self)
        {
            // if (!self.ShowOpen)
            //     return;
            //
            // self.PassTime += 1;
            // self.CrossFadeAlpha(self.PassTime % 2);
        }

        public static void CrossFadeAlpha(this Scroll_Item_CellDungeonCellItem self, float alpha)
        {
            // for (int i = 0; i < self.Transform.childCount; i++)
            // {
            //     Image image = self.Transform.GetChild(i).gameObject.GetComponent<Image>();
            //
            //     if (image == null)
            //     {
            //         continue;
            //     }
            //
            //     image.CrossFadeAlpha(alpha, 1f, false);
            // }
        }

        public static void OnChapterOpen(this Scroll_Item_CellDungeonCellItem self, bool open)
        {
            // if (!open)
            // {
            //     self.ShowOpen = false;
            //     self.CrossFadeAlpha(1f);
            //     return;
            // }
            //
            // CellDungeonComponent fubenComponent = self.ZoneScene().GetComponent<CellDungeonComponent>();
            //
            // ChapterConfig chapterConfig = ChapterConfigCategory.Instance.Get(fubenComponent.ChapterId);
            // CellDungeonInfo fubenCellInfo = self.fubenCellInfo;
            // int cellIndex = fubenComponent.GetCellIndex(fubenCellInfo.row, fubenCellInfo.line);
            // int[] size = chapterConfig.InitSize;
            //
            // bool benext = false;
            // if (Mathf.Abs(cellIndex - fubenComponent.SonFubenInfo.CurrentCell) == 1 &&
            //     (fubenCellInfo.line == (int)(fubenComponent.SonFubenInfo.CurrentCell / size[0]))
            //     || Mathf.Abs(cellIndex - fubenComponent.SonFubenInfo.CurrentCell) == size[0])
            // {
            //     benext = true;
            // }
            //
            // self.ShowOpen = benext && (fubenCellInfo.ctype == (byte)CellDungeonStatu.Passable ||
            //     fubenCellInfo.ctype == (byte)CellDungeonStatu.Start || fubenCellInfo.ctype == (byte)CellDungeonStatu.End);
        }

        public static void OnUpdateUI(this Scroll_Item_CellDungeonCellItem self, CellDungeonInfo fubenCellInfo)
        {
        }
    }
}