namespace ET.Client
{
    [FriendOf(typeof (ActivityComponentC))]
    [EntitySystemOf(typeof (ActivityComponentC))]
    public static partial class ActivityComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this ActivityComponentC self)
        {
        }
    }
}