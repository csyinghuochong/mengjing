namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetSet:Entity,IAwake,IUILogic
    {
        public DlgPetSetViewComponent View { get => this.GetComponent<DlgPetSetViewComponent>();} 

    }
    
}