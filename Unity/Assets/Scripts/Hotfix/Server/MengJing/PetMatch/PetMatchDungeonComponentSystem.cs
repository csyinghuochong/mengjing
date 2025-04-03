using System;
using System.Collections.Generic;


namespace ET.Server
{

    [EntitySystemOf(typeof(PetMatchDungeonComponent))]
    [FriendOf(typeof(PetMatchDungeonComponent))]
    public static partial class PetMatchDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.PetMatchDungeonComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.PetMatchDungeonComponent self)
        {

        }
        
        public static void OnKillEvent(this PetMatchDungeonComponent self, Unit defend)
        {
            if (self.GameOver)
            {
                return;
            }

            // if (defend.Type == UnitType.Monster)
            // {
            //     MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(defend.ConfigId);
            //     if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_62)
            //     {
            //         self.Scene().RemoveComponent<YeWaiRefreshComponent>();
            //
            //         int battleCamp = defend.GetComponent<NumericComponentS>().GetAsInt(NumericType.BattleCamp);
            //         self.SetGameOver(battleCamp == 1 ? CombatResultEnum.Fail : CombatResultEnum.Win);
            //     }
            // }
        }
    }
}
