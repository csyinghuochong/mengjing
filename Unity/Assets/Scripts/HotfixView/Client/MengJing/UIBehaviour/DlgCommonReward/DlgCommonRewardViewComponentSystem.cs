namespace ET.Client
{
    [EntitySystemOf(typeof (DlgCommonRewardViewComponent))]
    [FriendOfAttribute(typeof (DlgCommonRewardViewComponent))]
    public static partial class DlgCommonRewardViewComponentSystem
    {
        [EntitySystem]
        private static void Awake(this DlgCommonRewardViewComponent self)
        {
            self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
        }

        [EntitySystem]
        private static void Destroy(this DlgCommonRewardViewComponent self)
        {
            self.DestroyWidget();
        }
    }
}