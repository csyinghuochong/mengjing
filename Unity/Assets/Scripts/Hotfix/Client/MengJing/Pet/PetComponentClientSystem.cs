namespace ET.Client
{

    [EntitySystemOf(typeof(PetComponentClient))]
    [FriendOf(typeof(PetComponentClient))]
    public static partial class PetComponentClientSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.PetComponentClient self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.PetComponentClient self)
        {

        }
        
        
        
        
    }

}
