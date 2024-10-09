using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CellDungeonItem))]
    [EntitySystemOf(typeof(Scroll_Item_CellDungeonItem))]
    public static partial class Scroll_Item_CellDungeonItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CellDungeonItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CellDungeonItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_CellDungeonItem self, int levelId)
        {
            self.E_ImageButtonButton.AddListener(self.OnClick);
            self.LevelId = levelId;

            CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(levelId);
        }

        public static void OnClick(this Scroll_Item_CellDungeonItem self)
        {
            self.GetParent<DlgCellChapterSelect>().OnSelect(self.LevelId);
        }
    }
}