namespace ET.Client
{

    [EntitySystemOf(typeof(ES_DragonDungeonShop))]
    [FriendOfAttribute(typeof(ES_DragonDungeonShop))]
    public static partial class ES_DragonDungeonShopSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_DragonDungeonShop self, UnityEngine.Transform args2)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_DragonDungeonShop self)
        {

        }
    }
}