namespace ET.Client
{

    [EntitySystemOf(typeof(ES_DragonDungeonMy))]
    [FriendOfAttribute(typeof(ES_DragonDungeonMy))]
    public static partial class ES_DragonDungeonMySystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_DragonDungeonMy self, UnityEngine.Transform args2)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_DragonDungeonMy self)
        {

        }
    }

}