using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgShenQiMake: Entity, IAwake, IUILogic
    {
        public DlgShenQiMakeViewComponent View
        {
            get => this.GetComponent<DlgShenQiMakeViewComponent>();
        }

        public List<EntityRef<UIShenQiChapterComponent>> ChapterListUI = new();
        public int MakeId;
        public long Timer;
    }
}