using System;
using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof (BattleSceneComponent))]
    [FriendOf(typeof (BattleSceneComponent))]
    public static partial class BattleSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BattleSceneComponent self)
        {
            self.BattleInfos.Clear();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BattleSceneComponent self)
        {
            self.BattleInfos.Clear();
        }

        public static void OnZeroClockUpdate(this BattleSceneComponent self)
        {
            LogHelper.LogWarning("Battle:  OnZeroClockUpdate", true);
        }

        public static void OnBattleOpen(this BattleSceneComponent self)
        {
            self.BattleOpen = true;
            LogHelper.LogWarning($"OnBattleOpen : {self.Zone()}", true);
            if (ServerHelper.GetOpenServerDay(self.Zone()) > 0 && !ComHelperS.IsInnerNet())
            {
                ActorId robotSceneId = StartSceneConfigCategory.Instance.GetBySceneName(203, "Robot01").ActorId;
                self.Root().GetComponent<MessageSender>().Send(robotSceneId, new G2Robot_MessageRequest() { Zone = self.Zone(), MessageType = NoticeType.BattleOpen });
            }
        }

        public static async ETTask OnBattleOver(this BattleSceneComponent self)
        {
            self.BattleOpen = false;
            LogHelper.LogDebug($"OnBattleOver : {self.Zone()}");
            //Console.WriteLine($"OnBattleOver : {self.DomainZone()}");
            ActorId robotSceneId = StartSceneConfigCategory.Instance.GetBySceneName(203, "Robot01").ActorId;
            self.Root().GetComponent<MessageSender>().Send(robotSceneId, new G2Robot_MessageRequest() { Zone = self.Zone(), MessageType = NoticeType.BattleOver });

            await self.Root().GetComponent<TimerComponent>().WaitAsync(RandomHelper.RandomNumber(10000, 20000));
            for (int i = 0; i < self.BattleInfos.Count; i++)
            {
                try
                {
                    LocalDungeon2M_ExitResponse createUnit = (LocalDungeon2M_ExitResponse)await self.Root().GetComponent<MessageSender>().Call(
                        self.BattleInfos[i].ActorId, new M2LocalDungeon_ExitRequest()
                        {
                            SceneType = SceneTypeEnum.Battle,
                            FubenId = self.BattleInfos[i].FubenId,
                            Camp1Player = self.BattleInfos[i].Camp1Player,
                            Camp2Player = self.BattleInfos[i].Camp2Player,
                        });
                    if (createUnit.Error != ErrorCode.ERR_Success)
                    {
                        Log.Error($"createUnit.Error: {self.BattleInfos[i].FubenId} {createUnit.Error}");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }

            self.BattleInfos.Clear();
        }

        public static KeyValuePairInt GetBattleInstanceId(this BattleSceneComponent self, long unitid, int sceneId)
        {
            KeyValuePairInt keyValuePairInt = new KeyValuePairInt();
            if (!self.BattleOpen)
            {
                keyValuePairInt.KeyId = 0;
                keyValuePairInt.Value = 0;
                return keyValuePairInt;
            }

            int camp = 0;
            BattleInfo battleInfo = null;
            for (int i = 0; i < self.BattleInfos.Count; i++)
            {
                battleInfo = self.BattleInfos[i];
                if (battleInfo.SceneId != sceneId)
                {
                    continue;
                }

                if (battleInfo.Camp1Player.Contains(unitid))
                {
                    keyValuePairInt.KeyId = 1;
                    keyValuePairInt.Value = battleInfo.FubenInstanceId;
                    return keyValuePairInt;
                }

                if (battleInfo.Camp2Player.Contains(unitid))
                {
                    keyValuePairInt.KeyId = 2;
                    keyValuePairInt.Value = battleInfo.FubenInstanceId;
                    return keyValuePairInt;
                }

                if (battleInfo.PlayerNumber < ComHelp.GetPlayerLimit(sceneId))
                {
                    battleInfo.PlayerNumber++;
                    camp = battleInfo.PlayerNumber % 2 + 1;
                    if (camp == 1)
                    {
                        battleInfo.Camp1Player.Add(unitid);
                    }
                    else
                    {
                        battleInfo.Camp2Player.Add(unitid);
                    }

                    keyValuePairInt.KeyId = camp;
                    keyValuePairInt.Value = battleInfo.FubenInstanceId;
                    return keyValuePairInt;
                }
            }

            return null;
        }

        public static async ETTask<KeyValuePairInt> GenerateBattleInstanceId(this BattleSceneComponent self, long unitid, int sceneId)
        {
            //动态创建副本
            List<StartSceneConfig> zonelocaldungeons = StartSceneConfigCategory.Instance.LocalDungeons[self.Zone()];
            int n = RandomHelper.RandomNumber(0, zonelocaldungeons.Count);
            StartSceneConfig startSceneConfig = zonelocaldungeons[n];

            LocalDungeon2M_EnterResponse createUnit = (LocalDungeon2M_EnterResponse)await self.Root().GetComponent<MessageSender>().Call(
                startSceneConfig.ActorId,
                new M2LocalDungeon_EnterRequest()
                {
                    UserID = unitid,
                    SceneType = SceneTypeEnum.Battle,
                    SceneId = sceneId,
                    TransferId = 0,
                    Difficulty = 0
                });

            if (createUnit.Error != ErrorCode.ERR_Success)
            {
                return null;
            }

            BattleInfo battleInfo = self.AddChild<BattleInfo>();
            battleInfo.ProgressId = startSceneConfig.Process;
            battleInfo.ActorId = startSceneConfig.ActorId;
            battleInfo.FubenId = createUnit.FubenId;
            battleInfo.PlayerNumber = 0;
            battleInfo.FubenInstanceId = createUnit.FubenInstanceId;
            battleInfo.SceneId = sceneId;

            battleInfo.PlayerNumber++;
            int camp = battleInfo.PlayerNumber % 2 + 1;
            if (camp == 1)
            {
                battleInfo.Camp1Player.Add(unitid);
            }
            else
            {
                battleInfo.Camp2Player.Add(unitid);
            }

            self.BattleInfos.Add(battleInfo);
            return new KeyValuePairInt() { KeyId = camp, Value = battleInfo.FubenInstanceId };
        }
    }
}