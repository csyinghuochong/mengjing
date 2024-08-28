namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgDungeonMap : Entity, IAwake, IUILogic
    {
        public DlgDungeonMapViewComponent View { get => this.GetComponent<DlgDungeonMapViewComponent>(); }

        public float ScaleFactor = 1.5f; // 缩放系数
        public float Duration = 0.5f; // 动画持续时间
    }
}