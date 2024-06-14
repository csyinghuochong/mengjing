namespace ET.Client
{

    [EntitySystemOf(typeof(ES_PetMiningItem))]
    [FriendOfAttribute(typeof(ES_PetMiningItem))]
    public static partial class ES_PetMiningItemSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_PetMiningItem self, UnityEngine.Transform args2)
        {
            self.uiTransform = args2;
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_PetMiningItem self)
        {
            self.DestroyWidget();
        }
    }

}