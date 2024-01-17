namespace ET.Client
{
    [FriendOf(typeof (UICommonHuoBiSetComponent))]
    [EntitySystemOf(typeof (UICommonHuoBiSetComponent))]
    public static partial class UICommonHuoBiSetComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UICommonHuoBiSetComponent self)
        {
        }
    }
}