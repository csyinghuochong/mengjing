using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (SeasonTowerComponent))]
    [FriendOf(typeof (SeasonTowerComponent))]
    public static partial class SeasonTowerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SeasonTowerComponent self)
        {
        }

        public static void OnKillEvent(this SeasonTowerComponent self, Unit defend)
        {
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);

            if (defend.Id == players[0].Id)
            {
                M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
                m2C_FubenSettlement.BattleResult = CombatResultEnum.Fail;
                m2C_FubenSettlement.StarInfos = new List<int> { 0, 0, 0 };
                MapMessageHelper.SendToClient(players[0], m2C_FubenSettlement);
                return;
            }

            if (FubenHelp.IsAllMonsterDead(self.Scene(), players[0]))
            {
                M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
                m2C_FubenSettlement.BattleResult = CombatResultEnum.Win;
                m2C_FubenSettlement.StarInfos = new List<int> { 1, 1, 1 };
                MapMessageHelper.SendToClient(players[0], m2C_FubenSettlement);

                self.UploadHurtValue(players[0]).Coroutine();
            }
        }

        public static async ETTask UploadHurtValue(this SeasonTowerComponent self, Unit unit)
        {
            long userTime = TimeHelper.ServerNow() - self.BeginTime;
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            KeyValuePairLong rankingInfo = new KeyValuePairLong() { KeyId = unit.Id, Value = userTime, Value2 = mapComponent.SonSceneId };

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.SeasonTowerId, mapComponent.SonSceneId);
            ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());
            M2R_RankSeasonTowerRequest reuqest = M2R_RankSeasonTowerRequest.Create();
            reuqest.RankingInfo = rankingInfo;
            R2M_RankSeasonTowerResponse Response =
                    (R2M_RankSeasonTowerResponse)await self.Root().GetComponent<MessageSender>().Call(mapInstanceId, reuqest);
        }

        public static void GenerateFuben(this SeasonTowerComponent self, int towerId)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(towerId);
            FubenHelp.CreateMonsterList(self.Scene(), towerConfig.MonsterSet);
            self.BeginTime = TimeHelper.ServerNow();
        }
    }
}