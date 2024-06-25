namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgTeamDungeon: Entity, IAwake, IUILogic
    {
        public DlgTeamDungeonViewComponent View
        {
            get => this.GetComponent<DlgTeamDungeonViewComponent>();
        }
    }
}