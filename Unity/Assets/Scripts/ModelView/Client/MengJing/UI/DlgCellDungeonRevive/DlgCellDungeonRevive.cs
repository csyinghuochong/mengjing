namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgCellDungeonRevive: Entity, IAwake, IUILogic
    {
        public DlgCellDungeonReviveViewComponent View
        {
            get => this.GetComponent<DlgCellDungeonReviveViewComponent>();
        }

        public long Timer;
        public int LeftTime;
        public int SceneType;
    }
}