namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgDungeonHappyMain: Entity, IAwake, IUILogic
    {
        public DlgDungeonHappyMainViewComponent View
        {
            get => this.GetComponent<DlgDungeonHappyMainViewComponent>();
        }

        public long NextMoveTime;
        public long EndTime;
        public long Timer;
        public string DefaultTime = "0:0";
    }
}