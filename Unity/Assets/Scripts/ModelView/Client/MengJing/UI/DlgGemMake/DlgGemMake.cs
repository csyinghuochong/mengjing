using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgGemMake: Entity, IAwake, IUILogic
    {
        public DlgGemMakeViewComponent View
        {
            get => this.GetComponent<DlgGemMakeViewComponent>();
        }

        public List<EntityRef<UIGemChapterComponent>> ChapterListUI = new();
        public int MakeId;
        public long Timer;
    }
}