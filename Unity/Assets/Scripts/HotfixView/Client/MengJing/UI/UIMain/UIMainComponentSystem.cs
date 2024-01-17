namespace ET.Client
{
    [FriendOf(typeof (UIMainComponent))]
    [EntitySystemOf(typeof (UIMainComponent))]
    public static partial class UIMainComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIMainComponent self)
        {
        }
    }
}