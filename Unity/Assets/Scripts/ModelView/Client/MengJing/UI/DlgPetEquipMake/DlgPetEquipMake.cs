using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetEquipMake : Entity, IAwake, IUILogic
    {
        public DlgPetEquipMakeViewComponent View { get => this.GetComponent<DlgPetEquipMakeViewComponent>(); }

        public List<EntityRef<UIPetEquipChapterComponent>> ChapterListUI = new();
        public int MakeId;
        public long Timer;
    }
}