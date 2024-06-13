namespace ET.Client
{
    [EntitySystemOf(typeof(DlgPetSetViewComponent))]
    [FriendOfAttribute(typeof(ET.Client.DlgPetSetViewComponent))]
    public static partial class DlgPetSetViewComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.DlgPetSetViewComponent self)
        {
            self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.DlgPetSetViewComponent self)
        {
            self.DestroyWidget();
        }
    }
}

