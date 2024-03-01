namespace ET.Client
{

    [EntitySystemOf(typeof(DlgFriendList))]
    [FriendOfAttribute(typeof(DlgFriendList))]
    public static partial class DlgFriendListSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.DlgFriendList self, UnityEngine.Transform args2)
        {
            self.uiTransform = args2;
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.DlgFriendList self)
        {
            self.DestroyWidget();
        }
    }

}