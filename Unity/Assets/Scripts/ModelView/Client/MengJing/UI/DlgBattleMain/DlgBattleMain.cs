namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgBattleMain: Entity, IAwake, IUILogic
    {
        public DlgBattleMainViewComponent View
        {
            get => this.GetComponent<DlgBattleMainViewComponent>();
        }

        public long Timer;
        public int CDTime;
    }
}