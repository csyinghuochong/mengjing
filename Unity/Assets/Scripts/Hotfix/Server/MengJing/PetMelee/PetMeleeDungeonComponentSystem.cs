namespace ET.Server
{
    [Event(SceneType.Map)]
    public class UnitKillEvent_PetMelee : AEvent<Scene, UnitKillEvent>
    {
        protected override async ETTask Run(Scene scene, UnitKillEvent args)
        {
            Unit defendUnit = args.UnitDefend;
            Unit mainAttack = args.UnitAttack;

            if (defendUnit.Type == UnitType.HomeBase)
            {
                // 老家被拆了，判断结果
            }

            await ETTask.CompletedTask;
        }
    }

    [EntitySystemOf(typeof(PetMeleeDungeonComponent))]
    [FriendOf(typeof(PetMeleeDungeonComponent))]
    public static partial class PetMeleeDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PetMeleeDungeonComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this PetMeleeDungeonComponent self)
        {
        }

        public static void GenerateFuben(this PetMeleeDungeonComponent self)
        {
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();

            FubenHelp.CreateMonsterList(self.Scene(), SceneConfigCategory.Instance.Get(mapComponent.SceneId).CreateMonsterPosi);

            // 生成双方的基地
        }
    }
}