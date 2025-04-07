using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMeleeLevel : Entity, IAwake, IUILogic
    {
        public DlgPetMeleeLevelViewComponent View { get => this.GetComponent<DlgPetMeleeLevelViewComponent>(); }

        public Dictionary<int, EntityRef<Scroll_Item_PetMeleeLevelItem>> ScrollItemPetMeleeLevelItems;
        public List<int> ShowPetMeleeSceneIds = new();
        public int SceneId;
        public Dictionary<int, EntityRef<Scroll_Item_MonsterItem>> ScrollItemMonsterItems;
        public List<int> ShowMonsterIds = new();
        public int SelectIndex = -1;
    }
}