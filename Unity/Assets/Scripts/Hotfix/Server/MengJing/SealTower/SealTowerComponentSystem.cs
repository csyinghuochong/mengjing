using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 封印之塔管理
    /// </summary>
    [EntitySystemOf(typeof(SealTowerComponent))]
    [FriendOf(typeof(SealTowerComponent))]
    public static partial class SealTowerComponentSystem
    {
        /// <summary>
        /// 怪物被击杀时触发
        /// </summary>
        /// <param name="self"></param>
        /// <param name="defend"></param>
        public static void OnKillEvent(this SealTowerComponent self, Unit defend)
        {
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            if (defend.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId) == players[0].Id)
            {
                return;
            }

            if (defend.Type != UnitType.Monster)
            {
                return;
            }

            players[0].GetComponent<SkillManagerComponentS>().ClearSkillAndCd();

            M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
            m2C_FubenSettlement.BattleResult = CombatResultEnum.Win;

            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            int arrived = players[0].GetComponent<NumericComponentS>().GetAsInt(NumericType.SealTowerArrived);
            players[0].GetComponent<NumericComponentS>().ApplyValue(NumericType.SealTowerFinished, arrived);
            MapMessageHelper.SendToClient(players[0], m2C_FubenSettlement);
        }

        /// <summary>
        /// 生成副本
        /// </summary>
        /// <param name="self"></param>
        /// <param name="arrivedConfigId">到达的层数</param>
        /// <param name="finishedConfigId">完成的层数</param>
        public static void GenerateFuben(this SealTowerComponent self, int arrivedConfigId, int finishedConfigId)
        {
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            
            // 判断该层是否清空
            if (arrivedConfigId > finishedConfigId && arrivedConfigId <= 100)
            {
                // 根据角色等级，配置封印之塔的
                // 1-19 级  201001
                // 20-29级 202001
                // 30-39级 203001
                // 40-49级 204001
                // 50-59级 205001
                // 60-99级 206001
                int lv = players[0].GetComponent<UserInfoComponentS>().UserInfo.Lv;
                int baseLevel = 200000;

                foreach (var sealcofnig in ConfigData.SealTowerLevelConfig)
                {
                    if (lv <= sealcofnig.Key)
                    {
                        baseLevel = sealcofnig.Value;
                        break;
                    }
                }

                // 读取配置表,根据到达层数生成怪物
                TowerConfig towerConfig = TowerConfigCategory.Instance.Get(baseLevel + arrivedConfigId);
                FubenHelp.CreateMonsterList(self.Scene(), towerConfig.MonsterSet);
            }
        }
        [EntitySystem]
        private static void Awake(this SealTowerComponent self)
        {

        }
    }
}