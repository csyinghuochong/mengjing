using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (TrialDungeonComponent))]
    [FriendOf(typeof (TrialDungeonComponent))]
    public static partial class TrialDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TrialDungeonComponent self)
        {
            self.HurtValue = 0;
        }

        public static void OnKillEvent(this TrialDungeonComponent self, Unit defend)
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

            self.NoticePlayerDamage(players[0]);
            self.UploadHurtValue().Coroutine();

            M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
            m2C_FubenSettlement.BattleResult = CombatResultEnum.Win;

            long lastDungeonId = players[0].GetComponent<NumericComponentS>().GetAsLong(NumericType.TrialDungeonId);
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();

            string userName = players[0].GetComponent<UserInfoComponentS>().UserInfo.Name;
            Log.Warning(
                $"试炼之地通关： 区:{players[0].Zone()}   {players[0].Id}   {mapComponent.SonSceneId}  {userName}  {players[0].GetComponent<UserInfoComponentS>().UserInfo.Lv}");

            if (lastDungeonId < mapComponent.SonSceneId)
            {
                players[0].GetComponent<NumericComponentS>().ApplyValue(NumericType.TrialDungeonId, mapComponent.SonSceneId);
            }

            MapMessageHelper.SendToClient(players[0], m2C_FubenSettlement);

            players[0].GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.TrialTowerCeng_134, mapComponent.SonSceneId, 1);
        }

        private static void NoticePlayerDamage(this TrialDungeonComponent self, Unit player)
        {
            M2C_TrialDungeonDamage m2CTrialDungeonDamage = M2C_TrialDungeonDamage.Create();
            m2CTrialDungeonDamage.BeginTime = self.BeginTime;
            m2CTrialDungeonDamage.HurtValue = self.HurtValue;
            MapMessageHelper.SendToClient(player, m2CTrialDungeonDamage);
        }

        public static async ETTask UploadHurtValue(this TrialDungeonComponent self)
        {
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            if (players.Count == 0)
            {
                return;
            }

            long unitId = players[0].Id;
            long hurtValue = self.HurtValue;
            long usetime = TimeHelper.ServerNow() - self.BeginTime;
            usetime = usetime / 1000;
            usetime = Math.Max(1, usetime);
            hurtValue = hurtValue / usetime;

            players[0].GetComponent<DataCollationComponent>().OnSceondHurt(hurtValue);
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            ActorId mapInstanceId = UnitCacheHelper.GetRankServerId(self.Zone());
            M2R_RankTrialRequest M2R_RankTrialRequest = M2R_RankTrialRequest.Create();
            M2R_RankTrialRequest. RankingInfo = new KeyValuePairLong() { KeyId = unitId, Value = hurtValue, Value2 = mapComponent.SonSceneId};
            R2M_RankTrialResponse Response = (R2M_RankTrialResponse)await self.Root().GetComponent<MessageSender>().Call(mapInstanceId,M2R_RankTrialRequest);
            if (Response.Error == ErrorCode.ERR_Success && Response.RankId != 0)
            {
                players[0].GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.TrialRank_81, Response.RankId, 1);
            }

            self.HurtValue = 0;
            await ETTask.CompletedTask;
        }

        public static Unit OnUpdateDamage(this TrialDungeonComponent self, Unit player, Unit attack, Unit defend, long damage, int skillid)
        {
            if (player == null)
            {
                return null;
            }

            if (defend.Type != UnitType.Monster)
            {
                return null;
            }

            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            if (players.Count == 0)
            {
                return null;
            }
            
            self.HurtValue += damage;
            
            self.NoticePlayerDamage(players[0]);
         
            return players[0];
        }

        public static void GenerateFuben(this TrialDungeonComponent self, int towerId)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(towerId);
            FubenHelp.CreateMonsterList(self.Scene(), towerConfig.MonsterSet);
            self.HurtValue = 0;
            self.BeginTime = TimeHelper.ServerNow();
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            players[0].GetComponent<AttackRecordComponent>().ClearDamageList();
        }
    }
}