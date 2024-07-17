namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgFriend: Entity, IAwake, IUILogic
    {
        public DlgFriendViewComponent View
        {
            get => this.GetComponent<DlgFriendViewComponent>();
        }

        public bool ClickEnabled;
    }
}