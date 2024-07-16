namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgHappyMain: Entity, IAwake, IUILogic
    {
        public DlgHappyMainViewComponent View
        {
            get => this.GetComponent<DlgHappyMainViewComponent>();
        }

        public long NextFefreshTime;

        public long NextMoveTime;

        public long EndTime;

        public long Timer;

        public string DefaultTime = "0:0";
    }
}