using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class UnitKillEvent_NotifyOther: AEvent<Scene, UnitKillEvent>
    {
        

        protected override async ETTask Run(Scene scene, UnitKillEvent args)
        {
            Unit defendUnit = args.UnitDefend;
            Unit mainAttack = args.UnitAttack;

            bool selfDeath = defendUnit == mainAttack;
            if (selfDeath)
            {
                //自爆怪
                //if (defendUnit.ConfigId != 90000001 && defendUnit.ConfigId != 90000002 
                // && defendUnit.ConfigId != 90000005 && defendUnit.ConfigId != 72009001)
                //{
                //    Log.Warning($"找不到击杀方主人.defendUnit == mainAttack: {defendUnit.ConfigId}");
                //}
                OnRemoveUnit(scene, args, 1).Coroutine();
                return;
            }

            if (mainAttack == null || mainAttack.IsDisposed)
            {
                //Log.Warning($"找不到击杀方主人.mainAttack == null ");
                OnRemoveUnit(scene, args, 1).Coroutine();
                return;
            }

            int attackconfid = mainAttack.ConfigId;
            Scene domainScene = defendUnit.Scene();
            MapComponent mapComponent = domainScene.GetComponent<MapComponent>();
            int sceneId = mapComponent.SceneId;
            int sceneTypeEnum = mapComponent.SceneType;
            if (mainAttack.Type != UnitType.Player)
            {
                mainAttack = domainScene.GetComponent<UnitComponent>().Get(mainAttack.GetMasterId());
            }

            if ((mainAttack == null || mainAttack.IsDisposed) && defendUnit.Type == UnitType.Monster
                && defendUnit.ConfigId != 90000001 && defendUnit.ConfigId != 90000002 && defendUnit.ConfigId != 90000005)
            {
                if (sceneTypeEnum == SceneTypeEnum.LocalDungeon)
                {
                    //Log.Warning($"找不到击杀方主人.LocalDungeon1： 防： {defendUnit.ConfigId}  攻： {attackconfid} ");
                    mainAttack = domainScene.GetComponent<LocalDungeonComponent>().MainUnit;
                }

                if (sceneTypeEnum == SceneTypeEnum.TeamDungeon)
                {
                    //Log.Warning($"找不到击杀方主人.TeamDungeon：   防： {defendUnit.ConfigId}   攻：  {attackconfid}");
                }
            }

            if (mainAttack != null && !mainAttack.IsDisposed)
            {
                int realPlayer = 1;
                List<long> allAttackIds = new List<long>();
                if (sceneTypeEnum == SceneTypeEnum.TeamDungeon)
                {
                    List<Unit> units = UnitHelper.GetUnitList(domainScene, UnitType.Player);
                    for (int k = 0; k < units.Count; k++)
                    {
                        allAttackIds.Add(units[k].Id);
                    }

                    realPlayer = UnitHelper.GetRealPlayer(domainScene);
                }
                else
                {
                    allAttackIds = defendUnit.GetComponent<AttackRecordComponent>().GetBeAttackPlayerList();
                    if (!allAttackIds.Contains(mainAttack.Id))
                    {
                        allAttackIds.Add(mainAttack.Id);
                    }
                }

                if (allAttackIds.Count >= 50)
                {
                    Console.WriteLine(
                        $"allAttackIds.Count : {allAttackIds.Count >= 50}  {TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow()).ToString()}");
                }

                for (int i = 0; i < allAttackIds.Count; i++)
                {
                    if (i >= 20)
                    {
                        break;
                    }

                    Unit attackUnit = domainScene.GetComponent<UnitComponent>().Get(allAttackIds[i]);
                    if (attackUnit == null || attackUnit.Type != UnitType.Player)
                    {
                        continue;
                    }

                    attackUnit.GetComponent<TaskComponentS>().OnKillUnit(defendUnit, sceneTypeEnum);
                    attackUnit.GetComponent<ChengJiuComponentS>().OnKillUnit(defendUnit);
                    attackUnit.GetComponent<PetComponentS>().OnKillUnit(defendUnit);
                    attackUnit.GetComponent<UserInfoComponentS>().OnKillUnit(defendUnit, sceneTypeEnum, sceneId);
                }

                UnitFactory.CreateDropItems(defendUnit, mainAttack, sceneTypeEnum, sceneId, realPlayer);

                if (mainAttack.Type == UnitType.Player)
                {
                    int jinglingid = mainAttack.GetComponent<ChengJiuComponentS>().JingLingId;
                    if (jinglingid != 0)
                    {
                        JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jinglingid);
                        if (jingLingConfig.FunctionType == JingLingFunctionType.ExtraDrop)
                        {
                            int dropid = int.Parse(jingLingConfig.FunctionValue);
                            UnitFactory.CreateDropItems(mainAttack, defendUnit, 1, dropid, "1");
                        }
                    }
                }

                if (mainAttack.Type == UnitType.Player && defendUnit.Type == UnitType.Player
                    && SceneConfigHelper.UseSceneConfig(sceneTypeEnum))
                {
                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
                    string attackname = mainAttack.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    string defendname = defendUnit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    string killtext =
                            $"<color=#B6FF00>{attackname}</color> 在<color=#FFA313>{sceneConfig.Name}</color> 击败了 <color=#00F6E6>{defendname}</color>";
                    BroadMessageHelper.SendBroadMessage(defendUnit.Root(), NoticeType.KillEvent, killtext);
                }
            }

            long waittime = defendUnit.IsChest()? 1000 : 100;
            if (defendUnit.Type == UnitType.Monster)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(defendUnit.ConfigId);
                if (monsterConfig.DeathSkillId != 0)
                {
                    SkillConfig skillConfigCategory = SkillConfigCategory.Instance.Get(monsterConfig.DeathSkillId);
                    waittime = 1000 + (long)(skillConfigCategory.SkillDelayTime * 1000) + skillConfigCategory.SkillLiveTime;
                }
            }

            if (defendUnit.Type == UnitType.Pet)
            {
                waittime = 1000;
            }

            switch (sceneTypeEnum)
            {
                case SceneTypeEnum.PetDungeon:
                    domainScene.GetComponent<PetFubenComponent>().OnKillEvent();
                    break;
                case SceneTypeEnum.CellDungeon:
                    domainScene.GetComponent<CellDungeonComponent>().OnKillEvent();
                    break;
                case SceneTypeEnum.PetTianTi:
                    domainScene.GetComponent<PetTianTiComponent>().OnKillEvent();
                    break;
                case SceneTypeEnum.TeamDungeon:
                    TeamDungeonComponent TeamDungeonComponent = domainScene.GetComponent<TeamDungeonComponent>();
                    bool dungeonover = TeamDungeonComponent.OnKillEvent(defendUnit);
                    if (dungeonover)
                    {
                        (domainScene.Parent as TeamSceneComponent).OnDungeonOver(TeamDungeonComponent.TeamInfo.TeamId);
                    }
                    break;
                case SceneTypeEnum.PetMing:
                    domainScene.GetComponent<PetMingDungeonComponent>().OnKillEvent();
                    break;
                case SceneTypeEnum.BaoZang:
                    ;
                    break;
                case SceneTypeEnum.MiJing:
                    domainScene.GetComponent<MiJingComponent>().OnKillEvent(defendUnit);
                    break;
                case SceneTypeEnum.Solo:
                    domainScene.GetComponent<SoloDungeonComponent>().OnKillEvent(mainAttack, defendUnit);
                    break;
                case SceneTypeEnum.Tower:
                    domainScene.GetComponent<TowerComponent>().OnKillEvent(defendUnit);
                    break;
                case SceneTypeEnum.RandomTower:
                    domainScene.GetComponent<RandomTowerComponent>().OnKillEvent(defendUnit);
                    break;
                case SceneTypeEnum.LocalDungeon:
                    domainScene.GetComponent<LocalDungeonComponent>().OnKillEvent(defendUnit, mainAttack);
                    break;
                case SceneTypeEnum.Battle:
                    domainScene.GetComponent<BattleDungeonComponent>().OnKillEvent(defendUnit, mainAttack);
                    break;
                case SceneTypeEnum.Arena:
                    domainScene.GetComponent<ArenaDungeonComponent>().OnKillEvent(defendUnit, mainAttack);
                    break;
                case SceneTypeEnum.Union:
                    domainScene.GetParent<UnionSceneComponent>().OnKillEvent(domainScene, defendUnit);
                    break;
                case SceneTypeEnum.TrialDungeon:
                    domainScene.GetComponent<TrialDungeonComponent>().OnKillEvent(defendUnit);
                    break;
                case SceneTypeEnum.SeasonTower:
                    domainScene.GetComponent<SeasonTowerComponent>().OnKillEvent(defendUnit);
                    break;
                case SceneTypeEnum.SealTower:
                    domainScene.GetComponent<SealTowerComponent>().OnKillEvent(defendUnit);
                    break;
                case SceneTypeEnum.Demon:
                    domainScene.GetComponent<DemonDungeonComponent>().OnKillEvent(defendUnit, mainAttack).Coroutine();
                    break;
                default:
                    break;
            }

            OnRemoveUnit(mainAttack.Root(), args, waittime).Coroutine();
            await ETTask.CompletedTask;
        }
        
        private async ETTask OnRemoveUnit(Scene root, UnitKillEvent args, long waittime)
        {
            Unit unitDefend = args.UnitDefend;
            await root.GetComponent<TimerComponent>() .WaitAsync(waittime);
            if (unitDefend.IsDisposed)
            {
                return;
            }
            if (unitDefend.Type != UnitType.Player && args.WaitRevive == 0)
            {
                unitDefend.GetParent<UnitComponent>().Remove(unitDefend.Id);
            }
        }

    }
}