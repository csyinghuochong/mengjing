using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanOneKeyPlant : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanOneKeyPlantViewComponent View { get => this.GetComponent<DlgJiaYuanOneKeyPlantViewComponent>(); }

        public List<int> Lands = new();
        public List<int> Seeds = new();
        public Dictionary<int, int> SeedToggles = new(); // index,BagInfo.ItemID
        public Dictionary<int, GameObject> SeedToggleGameObjects = new();
    }
}