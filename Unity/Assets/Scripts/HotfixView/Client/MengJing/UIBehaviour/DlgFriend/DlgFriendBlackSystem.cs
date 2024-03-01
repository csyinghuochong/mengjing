namespace ET.Client
{

    [EntitySystemOf(typeof(DlgFriendBlack))]
    [FriendOfAttribute(typeof(DlgFriendBlack))]
    public static partial class DlgFriendBlackSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.DlgFriendBlack self, UnityEngine.Transform args2)
        {
            self.uiTransform = args2;
            
            Log.Debug(("this.m_DlgFriendBlack == null222"));
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.DlgFriendBlack self)
        {
            self.DestroyWidget();
        }
    }

}