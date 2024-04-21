namespace ET.Client
{


    [FriendOf(typeof(Item_MainTeamItem))]
    [EntitySystemOf(typeof(Item_MainTeamItem))]
    public static partial class Item_MainTeamItemViewSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.Item_MainTeamItem self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.Item_MainTeamItem self)
        {

        }
    }

}