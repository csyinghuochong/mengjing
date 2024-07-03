namespace ET.Client
{
    [EntitySystemOf(typeof (DropComponentC))]
    [FriendOf(typeof (DropComponentC))]
    public static partial class DropComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this DropComponentC self)
        {
        }
    }
}