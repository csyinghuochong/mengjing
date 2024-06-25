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
            if (ServerHelper.GetOpenServerDay(false, self.Zone()) > 0 && !ComHelperS.IsInnerNet())
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
                    // LocalDungeon2M_ExitResponse createUnit = (LocalDungeon2M_ExitResponse)await self.Root().GetComponent<MessageSender>().Call(
                    //     self.BattleInfos[i].ActorId, new M2LocalDungeon_ExitRequest()
                    //     {
                    //         SceneType = SceneTypeEnum.Battle,
                    //         FubenId = self.BattleInfos[i].FubenId,
                    //         Camp1Player = self.BattleInfos[i].Camp1Player,
                    //         Camp2Player = self.BattleInfos[i].Camp2Player,
                    //     });
                    // if (createUnit.Error != ErrorCode.ERR_Success)
                    // {
                    //     Log.Error($"createUnit.Error: {self.BattleInfos[i].FubenId} {createUnit.Error}");
                    // }
                    Scene fubenscene = self.GetChild<Scene>(self.BattleInfos[i].FubenId);
                    fubenscene.GetComponent<BattleDungeonComponent>().OnBattleOver(self.BattleInfos[i].Camp1Player, self.BattleInfos[i].Camp2Player);
                    await fubenscene.GetComponent<BattleDungeonComponent>().KickOutPlayer();
                    await fubenscene.Root().GetComponent<TimerComponent>().WaitAsync(60000 + RandomHelper.RandomNumber(0, 1000));
                    TransferHelper.NoticeFubenCenter(fubenscene, 2).Coroutine();
                    fubenscene.Dispose();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }

            self.BattleInfos.Clear();
        }

        public static (int , BattleInfo) GetBattleInstanceId(this BattleSceneComponent self, long unitid, int sceneId)
        {
            if (!self.BattleOpen)
            {
                return (0, null);
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
                    camp = 1;
                    break;
                }

                if (battleInfo.Camp2Player.Contains(unitid))
                {
                    camp = 2;
                    break;
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

                    break;
                }
            }

            return (camp, battleInfo);
        }

        public static (int, BattleInfo) GenerateBattleInstanceId(this BattleSceneComponent self, long unitid, int sceneId)
        {
            //动态创建副本
            List<StartSceneConfig> zonelocaldungeons = StartSceneConfigCategory.Instance.LocalDungeons[self.Zone()];
            int n = RandomHelper.RandomNumber(0, zonelocaldungeons.Count);
            StartSceneConfig startSceneConfig = zonelocaldungeons[n];

            //动态创建副本

            long  fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId,  "Battle" + fubenid.ToString());
            //Console.WriteLine($"M2LocalDungeon_Enter: {fubnescene.Name}   {scene.DomainZone()}");
            fubnescene.AddComponent<BattleDungeonComponent>().SendReward = false;
            fubnescene.GetComponent<BattleDungeonComponent>().BattleOpenTime = TimeHelper.ServerNow();
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)SceneTypeEnum.Battle, sceneId, 0);
            mapComponent.NavMeshId = SceneConfigCategory.Instance.Get(sceneId).MapID;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            fubnescene.AddComponent<YeWaiRefreshComponent>().SceneId = sceneId;
            FubenHelp.CreateNpc(fubnescene, sceneId);
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(sceneId).CreateMonster);
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(sceneId).CreateMonsterPosi);

            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();

            BattleInfo battleInfo = self.AddChild<BattleInfo>();
            battleInfo.ProgressId = startSceneConfig.Process;
            battleInfo.FubenId = fubenid;
            battleInfo.PlayerNumber = 0;
            battleInfo.FubenInstanceId = fubenInstanceId;
            battleInfo.SceneId = sceneId;
            battleInfo.ActorId = new ActorId( self.Fiber().Process, self.Fiber().Id, fubenInstanceId );

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
            return (camp, battleInfo);
        }
    }
}