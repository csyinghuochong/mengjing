using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
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

        public static void OnKillEvent(this PetMeleeDungeonComponent self, Unit defend)
        {
            if (self.GameOver)
            {
                return;
            }

            if (defend.Type == UnitType.Monster)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(defend.ConfigId);
                if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_62)
                {
                    self.GameOver = true;
                    self.Scene().RemoveComponent<YeWaiRefreshComponent>();

                    M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
                    int battleCamp = defend.GetComponent<NumericComponentS>().GetAsInt(NumericType.BattleCamp);
                    if (battleCamp == 1)
                    {
                        m2C_FubenSettlement.BattleResult = CombatResultEnum.Fail;
                    }
                    else
                    {
                        m2C_FubenSettlement.BattleResult = CombatResultEnum.Win;
                    }

                    List<Unit> players = FubenHelp.GetUnitList(self.Scene(), UnitType.Player);
                    MapMessageHelper.SendToClient(players[0], m2C_FubenSettlement);
                }
            }
        }
    }
}