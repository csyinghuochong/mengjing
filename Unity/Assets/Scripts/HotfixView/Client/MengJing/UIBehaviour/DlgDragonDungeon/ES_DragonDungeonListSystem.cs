namespace ET.Client
{

    [EntitySystemOf(typeof(ES_DragonDungeonList))]
    [FriendOfAttribute(typeof(ES_DragonDungeonList))]
    public static partial class ES_DragonDungeonListSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_DragonDungeonList self, UnityEngine.Transform args2)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_DragonDungeonList self)
        {

        }
    }

}