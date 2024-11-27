using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMeleeLevel : Entity, IAwake, IUILogic
    {
        public DlgPetMeleeLevelViewComponent View { get => this.GetComponent<DlgPetMeleeLevelViewComponent>(); }

        public int SceneId;
        public Dictionary<int, EntityRef<Scroll_Item_MonsterItem>> ScrollItemMonsterItems;
        public List<int> ShowMonsterIds = new();
    }
}