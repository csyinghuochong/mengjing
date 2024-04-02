namespace ET.Client
{


    [EntitySystemOf(typeof(EffectViewComponent))]
    [FriendOf(typeof(EffectViewComponent))]
    public static partial class EffectViewComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.EffectViewComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.EffectViewComponent self)
        {

        }

        public static void EffectFactory(this EffectViewComponent self, EffectData effectData)
        {
        }
    }

}