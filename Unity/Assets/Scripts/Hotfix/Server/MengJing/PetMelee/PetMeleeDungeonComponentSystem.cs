using Unity.Mathematics;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class UnitKillEvent_PetMelee : AEvent<Scene, UnitKillEvent>
    {
        protected override async ETTask Run(Scene scene, UnitKillEvent args)
        {
            Unit defendUnit = args.UnitDefend;
            Unit mainAttack = args.UnitAttack;

            Scene domainScene = defendUnit.Scene();
            MapComponent mapComponent = domainScene.GetComponent<MapComponent>();
            if (mapComponent.SceneType == SceneTypeEnum.PetMelee)
            {
                if (defendUnit.Type == UnitType.Monster)
                {
                    // 老家被拆了，判断结果
                }
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
        }
    }
}