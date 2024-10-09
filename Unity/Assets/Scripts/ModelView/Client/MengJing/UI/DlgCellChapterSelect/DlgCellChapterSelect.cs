using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgCellChapterSelect : Entity, IAwake, IUILogic
    {
        public DlgCellChapterSelectViewComponent View { get => this.GetComponent<DlgCellChapterSelectViewComponent>(); }

        public float ScaleFactor = 1.5f; // 缩放系数
        public float Duration = 0.5f; // 动画持续时间
        public GameObject[] MapGameObjects;
        public GameObject CurrentMap;
        public int OriginalIndex;
        public int Difficulty;
        public int ChapterId;
        public int LevelId { get; set; }
        public Dictionary<int, EntityRef<Scroll_Item_CellDungeonItem>> ScrollItemCellDungeonItems;
        public long Timer;
    }
}