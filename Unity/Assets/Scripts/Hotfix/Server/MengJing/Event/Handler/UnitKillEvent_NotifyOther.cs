using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class UnitKillEvent_NotifyOther : AEvent<Scene, UnitKillEvent>
    {
        protected override async ETTask Run(Scene scene, UnitKillEvent args)
        {
            Unit defendUnit = args.UnitDefend;
            Unit mainAttack = args.UnitAttack;
            
            Scene domainScene = defendUnit.Scene();
            MapComponent mapComponent = domainScene.GetComponent<MapComponent>();
            int sceneId = mapComponent.SceneId;
            int sceneTypeEnum = mapComponent.MapType;
            defendUnit.GetComponent<MoveComponent>()?.Stop(false);
            defendUnit.GetComponent<AIComponent>()?.Stop();
            defendUnit.GetComponent<SkillPassiveComponent>()?.Stop();
            defendUnit.GetComponent<SkillManagerComponentS>()?.OnFinish(false);
            defendUnit.GetComponent<BuffManagerComponentS>()?.OnDead(mainAttack);
            NumericComponentS numericComponent = defendUnit.GetComponent<NumericComponentS>();
            if (defendUnit.Type == UnitType.Player)
            {
                // RolePetInfo rolePetInfo = defendUnit.GetComponent<PetComponentS>().GetFightPet();
                // if (rolePetInfo != null)
                // {
                //     defendUnit.GetParent<UnitComponent>().Remove(rolePetInfo.Id);
                //     defendUnit.GetComponent<PetComponentS>().OnPetDead(rolePetInfo.Id);
                // }
                TransferHelper.RemoveFightPetList(defendUnit);

                int now_horse = numericComponent.GetAsInt(NumericType.HorseRide);
                if (now_horse > 0)
                {
                    numericComponent.ApplyValue(NumericType.HorseRide, 0, false);
                }
            }

            //玩家死亡，怪物技能清空
            if (defendUnit.Type == UnitType.Player && mainAttack != null && mainAttack.Type == UnitType.Monster)
            {
                Unit nearest = GetTargetHelpS.GetNearestEnemy(mainAttack, mainAttack.GetComponent<AIComponent>().GetActRange());
                if (nearest == null)
                {
                    mainAttack.GetComponent<AIComponent>().ChangeTarget(0);
                    mainAttack.GetComponent<SkillManagerComponentS>().OnFinish(true);
                }

                List<Unit> units = FubenHelp.GetUnitList(defendUnit.Scene(), UnitType.Monster);
                for (int i = 0; i < units.Count; i++)
                {
                    units[i].GetComponent<AttackRecordComponent>()?.OnRemoveAttackByUnit(defendUnit.Id);
                }
            }

            //怪物死亡， 清除玩家BUFF
            if (defendUnit.Type == UnitType.Monster && MonsterConfigCategory.Instance.Get(defendUnit.ConfigId).RemoveBuff == 0)
            {
                List<Unit> units = FubenHelp.GetUnitList(defendUnit.Scene(), UnitType.Player);
                for (int i = 0; i < units.Count; i++)
                {
                    units[i].GetComponent<BuffManagerComponentS>().OnDeadRemoveBuffBy(defendUnit.Id);
                }
            }

            if (defendUnit.Type == UnitType.Pet)
            {
                sceneTypeEnum = defendUnit.Scene().GetComponent<MapComponent>().MapType;
                if (sceneTypeEnum != (int)MapTypeEnum.PetTianTi
                    && sceneTypeEnum != (int)MapTypeEnum.PetDungeon
                    && sceneTypeEnum != (int)MapTypeEnum.PetMing
                    && sceneTypeEnum != MapTypeEnum.PetMelee
                    && sceneTypeEnum != MapTypeEnum.PetMatch)
                {
                    long manster = numericComponent.GetAsLong(NumericType.MasterId);
                    Unit unit_manster = defendUnit.GetParent<UnitComponent>().Get(manster);
                    //修改宠物出战状态
                    unit_manster.GetComponent<PetComponentS>().OnPetDead(defendUnit.Id);
                }
            }

            numericComponent.ApplyValue( NumericType.Now_Dead, 1 );
            bool selfDeath = defendUnit == mainAttack;
            if (selfDeath)
            {
                //自爆怪
                //if (defendUnit.ConfigId != 90000001 && defendUnit.ConfigId != 90000002 
                // && defendUnit.ConfigId != 90000005 && defendUnit.ConfigId != 72009001)
                //{
                //    Log.Warning($"找不到击杀方主人.defendUnit == mainAttack: {defendUnit.ConfigId}");
                //}
                OnRemoveUnit(defendUnit.Root(), args, 1).Coroutine();
                return;
            }

            if (mainAttack == null || mainAttack.IsDisposed)
            {
                //Log.Warning($"找不到击杀方主人.mainAttack == null ");
                OnRemoveUnit(defendUnit.Root(), args, 1).Coroutine();
                return;
            }

            if (mainAttack.Type != UnitType.Player)
            {
                mainAttack = domainScene.GetComponent<UnitComponent>().Get(mainAttack.GetMasterId());
            }

            if ((mainAttack == null || mainAttack.IsDisposed) && defendUnit.Type == UnitType.Monster
                && defendUnit.ConfigId != 90000001 && defendUnit.ConfigId != 90000002 && defendUnit.ConfigId != 90000005)
            {
                if (sceneTypeEnum == MapTypeEnum.LocalDungeon)
                {
                    //Log.Warning($"找不到击杀方主人.LocalDungeon1： 防： {defendUnit.ConfigId}  攻： {attackconfid} ");
                    mainAttack = domainScene.GetComponent<LocalDungeonComponent>().MainUnit;
                }

                if (sceneTypeEnum == MapTypeEnum.TeamDungeon)
                {
                    //Log.Warning($"找不到击杀方主人.TeamDungeon：   防： {defendUnit.ConfigId}   攻：  {attackconfid}");
                }
            }

            if (mainAttack != null && !mainAttack.IsDisposed)
            {
                int realPlayer = 1;
                List<long> allAttackIds = new List<long>();
                if (sceneTypeEnum == MapTypeEnum.TeamDungeon)
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

                    if (args.NoDrop)
                    {
                        continue;
                    }

                    attackUnit.GetComponent<TaskComponentS>().OnKillUnit(defendUnit, sceneTypeEnum);
                    attackUnit.GetComponent<ChengJiuComponentS>().OnKillUnit(defendUnit);
                    attackUnit.GetComponent<PetComponentS>().OnKillUnit(defendUnit);
                    attackUnit.GetComponent<UserInfoComponentS>().OnKillUnit(defendUnit, sceneTypeEnum, sceneId);
                }
                
                if (!args.NoDrop)
                {
                    UnitFactory.CreateDropItems(defendUnit, mainAttack, sceneTypeEnum, sceneId, realPlayer);
                }

                if (mainAttack.Type == UnitType.Player)
                {
                    JingLingInfo jinglinginfo = mainAttack.GetComponent<ChengJiuComponentS>().GetFightJingLing();
                    if (jinglinginfo != null)
                    {
                        JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jinglinginfo.JingLingID);
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
                    BroadCastHelper.SendBroadMessage(defendUnit.Root(), NoticeType.KillEvent, killtext);
                }
            }

            long waittime = defendUnit.IsChest() ? 1000 : 100;
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
                case MapTypeEnum.PetDungeon:
                    domainScene.GetComponent<PetDungeonComponent>().OnKillEvent();
                    break;
                case MapTypeEnum.CellDungeon:
                    domainScene.GetComponent<CellDungeonComponentS>().OnKillEvent();
                    break;
                case MapTypeEnum.PetTianTi:
                    domainScene.GetComponent<PetTianTiDungeonComponent>().OnKillEvent();
                    break;
                case MapTypeEnum.TeamDungeon:
                    TeamDungeonComponent TeamDungeonComponent = domainScene.GetComponent<TeamDungeonComponent>();
                    bool dungeonover = TeamDungeonComponent.OnKillEvent(defendUnit);
                    if (dungeonover)
                    {
                        domainScene.GetParent<TeamSceneComponent>().OnDungeonOver(TeamDungeonComponent.TeamId);
                    }
                    break;
                case MapTypeEnum.DragonDungeon:
                    DragonDungeonComponentS dragonDungeonComponent = domainScene.GetComponent<DragonDungeonComponentS>();
                    dungeonover = dragonDungeonComponent.OnKillEvent();
                    if (dungeonover)
                    {
                        domainScene.GetParent<TeamSceneComponent>().OnDungeonOver(dragonDungeonComponent.TeamId);
                    }
                    break;
                case MapTypeEnum.PetMing:
                    domainScene.GetComponent<PetMingDungeonComponent>().OnKillEvent();
                    break;
                case MapTypeEnum.BaoZang:
                    ;
                    break;
                case MapTypeEnum.MiJing:
                    domainScene.GetComponent<MiJingDungeonComponent>().OnKillEvent(defendUnit);
                    break;
                case MapTypeEnum.Solo:
                    domainScene.GetComponent<SoloDungeonComponent>().OnKillEvent(mainAttack, defendUnit);
                    break;
                case MapTypeEnum.Tower:
                    domainScene.GetComponent<TowerComponent>().OnKillEvent(defendUnit);
                    break;
                case MapTypeEnum.RandomTower:
                    domainScene.GetComponent<RandomTowerComponent>().OnKillEvent(defendUnit);
                    break;
                case MapTypeEnum.LocalDungeon:
                    domainScene.GetComponent<LocalDungeonComponent>().OnKillEvent(defendUnit, mainAttack);
                    break;
                case MapTypeEnum.Battle:
                    domainScene.GetComponent<BattleDungeonComponent>().OnKillEvent(defendUnit, mainAttack);
                    break;
                case MapTypeEnum.Arena:
                    domainScene.GetComponent<ArenaDungeonComponent>().OnKillEvent(defendUnit, mainAttack);
                    break;
                case MapTypeEnum.Union:
                    domainScene.GetComponent<UnionDungeonComponet>().OnKillEvent(defendUnit);
                    break;
                case MapTypeEnum.TrialDungeon:
                    domainScene.GetComponent<TrialDungeonComponent>().OnKillEvent(defendUnit);
                    break;
                case MapTypeEnum.SeasonTower:
                    domainScene.GetComponent<SeasonTowerComponent>().OnKillEvent(defendUnit);
                    break;
                case MapTypeEnum.SealTower:
                    domainScene.GetComponent<SealTowerComponent>().OnKillEvent(defendUnit);
                    break;
                case MapTypeEnum.Demon:
                    domainScene.GetComponent<DemonDungeonComponent>().OnKillEvent(defendUnit, mainAttack).Coroutine();
                    break;
                case MapTypeEnum.PetMelee:
                case MapTypeEnum.PetMatch:
                    domainScene.GetComponent<PetMeleeDungeonComponent>().OnKillEvent(defendUnit, sceneTypeEnum);
                    break;
                default:
                    break;
            }
 
            OnRemoveUnit(defendUnit.Root(), args, waittime).Coroutine();
            await ETTask.CompletedTask;
        }

        private async ETTask OnRemoveUnit(Scene root, UnitKillEvent args, long waittime)
        {
            Unit unitDefend = args.UnitDefend;
            await root.GetComponent<TimerComponent>().WaitAsync(waittime);
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