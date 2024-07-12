using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgMail : Entity, IAwake, IUILogic
    {
        public DlgMailViewComponent View
        {
            get => this.GetComponent<DlgMailViewComponent>();
        }

        public Dictionary<int, EntityRef<Scroll_Item_MailItem>> ScrollItemMailItems;
        public int Reverse = 1;
    }
}