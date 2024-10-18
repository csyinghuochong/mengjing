namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgOpenChest : Entity, IAwake, IUILogic
    {
        public DlgOpenChestViewComponent View { get => this.GetComponent<DlgOpenChestViewComponent>(); }

        private EntityRef<Unit> box;
        public Unit Box { get => this.box; set => this.box = value; }
    }
}