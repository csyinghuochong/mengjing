namespace ET.Client
{
    [FriendOf(typeof(JiaYuanPlanEffectComponent))]
    [EntitySystemOf(typeof(JiaYuanPlanEffectComponent))]
    public static partial class JiaYuanPlanEffectComponentSystem
    {
        [EntitySystem]
        private static void Awake(this JiaYuanPlanEffectComponent self)
        {
        }
    }
}