namespace ET.Server
{

    [EntitySystemOf(typeof(PetMeleeDungeonComponent))]
    [FriendOf(typeof(PetMeleeDungeonComponent))]
    public static partial class PetMeleeDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.PetMeleeDungeonComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.PetMeleeDungeonComponent self)
        {

        }

        public static void GenerateFuben(this ET.Server.PetMeleeDungeonComponent self)
        {
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            
            FubenHelp.CreateMonsterList(self.Scene(), SceneConfigCategory.Instance.Get(mapComponent.SceneId).CreateMonsterPosi);
        }
    }

}
