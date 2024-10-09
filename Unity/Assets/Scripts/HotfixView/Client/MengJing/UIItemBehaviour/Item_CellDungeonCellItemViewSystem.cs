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

        public static void OnUpdateUI(this Scroll_Item_CellDungeonCellItem self, CellDungeonInfo fubenCellInfo)
        {
        }
    }
}