namespace ET.Client
{

    [EntitySystemOf(typeof(UIDropComponent))]
    [FriendOf(typeof(UIDropComponent))]

    public static partial class UIDropComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.UIDropComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.UIDropComponent self)
        {

        }

        public static void InitData(this ET.Client.UIDropComponent self, DropInfo dropInfo)
        {
            
        }
    }

}