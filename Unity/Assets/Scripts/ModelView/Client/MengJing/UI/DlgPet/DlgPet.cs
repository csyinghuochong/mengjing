namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPet: Entity, IAwake, IUILogic
    {
        public DlgPetViewComponent View
        {
            get => this.GetComponent<DlgPetViewComponent>();
        }

        public int PetItemWeizhi; //-1左 1 右边
    }
}