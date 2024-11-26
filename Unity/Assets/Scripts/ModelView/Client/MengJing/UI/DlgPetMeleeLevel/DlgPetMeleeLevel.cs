namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMeleeLevel : Entity, IAwake, IUILogic
    {
        public DlgPetMeleeLevelViewComponent View { get => this.GetComponent<DlgPetMeleeLevelViewComponent>(); }

        public int SceneId;
    }
}