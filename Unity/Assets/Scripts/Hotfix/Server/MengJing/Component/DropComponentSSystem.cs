namespace ET.Server
{
    [EntitySystemOf(typeof(DropComponentS))]
    [FriendOf(typeof(DropComponentS))]
    public static partial class DropComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this DropComponentS self)
        {
            self.OwnerId = 0;
            self.ProtectTime = 0;
            self.BeAttackPlayerList.Clear();
        }
    }
}