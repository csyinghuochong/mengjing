namespace ET.Server
{

    [EntitySystemOf(typeof(RandomTowerComponent))]
    [FriendOf(typeof(RandomTowerComponent))]
    public static partial class RandomTowerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RandomTowerComponent self)
        {

        }
        
        public static void OnKillEvent(this RandomTowerComponent self, Unit unitdefend)
        {
            Unit mainUnit = UnitHelper.GetUnitList(self.Scene(), UnitType.Player)[0];
            bool allMonsterDead = FubenHelp.IsAllMonsterDead(self.Scene(), mainUnit);
            bool mainUnitDead = unitdefend.Id == mainUnit.Id;
            if (!allMonsterDead && !mainUnitDead)
            {
                return;
            }
            if (allMonsterDead)
            {
                NumericComponentS numericComponent = mainUnit.GetComponent<NumericComponentS>();
                numericComponent.ApplyValue(NumericType.RandomTowerId, self.TowerId);
            }

            M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
            m2C_FubenSettlement.BattleResult = allMonsterDead ? 1 : 0;
            MapMessageHelper.SendToClient(mainUnit, m2C_FubenSettlement);
        }
        
    }

}
