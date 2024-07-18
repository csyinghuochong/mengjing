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

        public static void OnUpdateDamage(this TrialDungeonComponent self, Unit player, Unit attack, Unit defend, long damage, int skillid)
        {
            if (defend.Type != UnitType.Monster)
            {
                return;
            }

            self.HurtValue += damage;

            if (player.Id == 2010003137213038592)
            {
                string skillName = string.Empty;
                if (skillid != 0)
                {
                    skillName = SkillConfigCategory.Instance.Get(skillid).SkillName;
                    ;
                }

                if (attack.Type == UnitType.Player)
                {
                    LogHelper.TrialBattleInfo(44, $"南宫灵蓝 使用{skillName} 造成了{damage}伤害");
                }

                if (attack.Type == UnitType.Pet)
                {
                    PetConfig petConfig = PetConfigCategory.Instance.Get(attack.ConfigId);
                    LogHelper.TrialBattleInfo(44, $"南宫灵蓝 宠物{petConfig.PetName} 使用{skillName} 造成了{damage}伤害");
                }

                if (attack.Type == UnitType.Monster)
                {
                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(attack.ConfigId);
                    LogHelper.TrialBattleInfo(44, $"南宫灵蓝 召唤怪{monsterConfig.MonsterName} 使用{skillName} 造成了{damage}伤害");
                }
            }
        }

        public static void GenerateFuben(this TrialDungeonComponent self, int towerId)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(towerId);
            FubenHelp.CreateMonsterList(self.Scene(), towerConfig.MonsterSet);
            self.HurtValue = 0;
            self.BeginTime = TimeHelper.ServerNow();
        }
    }
}