namespace ET.Server
{

    [EntitySystemOf(typeof(TuoGuanComponet))]
    [FriendOf(typeof(TuoGuanComponet))]
    public static partial class TuoGuanComponetSystem
    {
        
        
        [EntitySystem]
        private static void Awake(this ET.Server.TuoGuanComponet self)
        {

        }
        
        [EntitySystem]
        private static void Deserialize(this ET.Server.TuoGuanComponet self)
        {

        }
    }

}