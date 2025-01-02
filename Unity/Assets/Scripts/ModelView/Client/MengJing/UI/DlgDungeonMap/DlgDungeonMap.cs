using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgDungeonMap : Entity, IAwake, IUILogic
    {
        public DlgDungeonMapViewComponent View { get => this.GetComponent<DlgDungeonMapViewComponent>(); }
        
        public float Duration = 0.5f; // 动画持续时间
        public GameObject[] MapGameObjects;
        public GameObject CurrentMap;
        public int OriginalIndex;
        public int Difficulty;
        public int ChapterId;
        public int LevelId { get; set; }
        public Dictionary<int, EntityRef<Scroll_Item_DungeonMapLevelItem>> ScrollItemDungeonMapLevelItems;
        public List<KeyValuePair> ShowBoosRefreshTime = new();
        public long Timer;
    }
}