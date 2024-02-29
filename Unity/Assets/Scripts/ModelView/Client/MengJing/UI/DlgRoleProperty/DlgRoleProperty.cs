using System.Collections.Generic;

namespace ET.Client
{
    public class ShowPropertyList
    {
        public int NumericType;
        public string Name;
        public string IconID;
        public int Type;
    }

    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRoleProperty: Entity, IAwake, IUILogic
    {
        public DlgRolePropertyViewComponent View
        {
            get => this.GetComponent<DlgRolePropertyViewComponent>();
        }

        public Dictionary<int, Scroll_Item_RolePropertyBaseItem> ScrollItemRolePropertyBaseItems;
        public Dictionary<int, Scroll_Item_RolePropertyTeShuItem> ScrollItemRolePropertyTeShuItems;
        public List<ShowPropertyList> ShowPropertyList_Base = new();
        public List<ShowPropertyList> ShowPropertyList_TeShu = new();
        public List<int> PointList = new();
        public List<int> PointInit = new();
        public int PointRemain;
        public bool IsHoldDown;
    }
}