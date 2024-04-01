namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPetSelect: Entity, IAwake, IUILogic
    {
        public DlgPetSelectViewComponent View
        {
            get => this.GetComponent<DlgPetSelectViewComponent>();
        }
    }
}