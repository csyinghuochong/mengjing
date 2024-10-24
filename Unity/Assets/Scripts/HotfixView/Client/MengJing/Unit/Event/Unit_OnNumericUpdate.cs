﻿namespace ET.Client
{
    [Event(SceneType.Current)]
    public class Unit_OnNumericUpdate : AEvent<Scene, NumbericChange>
    {
        protected override async ETTask Run(Scene scene, NumbericChange args)
        {
            Scene root = scene.Root();
            switch (args.NumericType)
            {
                case NumericType.RechargeNumber:
                    int rechargeNumber = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber);
                    int addNumer = rechargeNumber - (int)args.OldValue;

                    UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
                    if (!userInfoComponent.UserInfo.SingleRechargeIds.Contains(addNumer))
                    {
                        userInfoComponent.UserInfo.SingleRechargeIds.Add(addNumer);
                        root.GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.SingleRecharge);
                    }

                    root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRechageSucess(addNumer);
                    break;
                case NumericType.PetExploreLuckly:
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgPetEgg>()?.OnUpdateLuckly();
                    break;
                case NumericType.WearWeaponFisrt:
                    root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WearWeapon).Coroutine();
                    break;
                case NumericType.Now_Stall:
                    int stallType = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.Now_Stall);
                    args.Defend.GetComponent<GameObjectComponent>().OnUnitStallUpdate(stallType);
                    if (args.Defend.MainHero)
                    {
                        root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().ShowUIStall(stallType);
                    }

                    break;
                case NumericType.OccCombatRankID:
                case NumericType.FirstUnionName:
                    args.Defend.GetComponent<UIPlayerHpComponent>()?.OnUpdateUnionName();
                    break;
                case NumericType.BattleCamp:
                    Unit unitmain = UnitHelper.GetMyUnitFromClientScene(root);
                    args.Defend.GetComponent<UIPlayerHpComponent>()?.UpdateBattleCamp(unitmain, args.Defend.Id);
                    break;
                case NumericType.RunRaceTransform:
                    int runraceMonster = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.RunRaceTransform);
                    args.Defend.GetComponent<GameObjectComponent>()?.OnRunRaceTranfer(runraceMonster, true);
                    if (args.Defend.MainHero)
                    {
                        args.Defend.Root().GetComponent<AttackComponent>().OnTransformId(args.Defend.ConfigId, runraceMonster);
                    }

                    break;
                case NumericType.PetFightIndex:
                    if (args.Defend.MainHero)
                    {
                        root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().RefreshFightSet();
                    }

                    break;
                case NumericType.CardTransform:
                    int cardMonster = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.CardTransform);
                    args.Defend.GetComponent<GameObjectComponent>().OnCardTranfer(cardMonster, true);
                    if (args.Defend.MainHero)
                    {
                        args.Defend.Root().GetComponent<AttackComponent>().OnTransformId(args.Defend.ConfigId, cardMonster);
                    }

                    break;
                case NumericType.HappyCellIndex:
                    if (args.Defend.MainHero)
                    {
                        long oldvalue = args.OldValue;
                        long newvalue = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.HappyCellIndex);
                        if (oldvalue == newvalue)
                        {
                            FlyTipComponent.Instance.ShowFlyTip("位置没有改变！");
                        }
                    }

                    break;
                case NumericType.JueXingAnger:
                    if (args.Defend.MainHero)
                    {
                        root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainSkill.OnUpdateAngle();
                        args.Defend.GetComponent<UIPlayerHpComponent>()?.UptateJueXingAnger();
                    }

                    break;
                case NumericType.UnionRaceWin:
                    if (args.Defend.MainHero)
                    {
                        args.Defend.GetComponent<UIPlayerHpComponent>()?.UpdateShow();
                    }

                    break;
                case NumericType.SkillUseMP:
                    if (args.Defend.MainHero)
                    {
                        args.Defend.GetComponent<UIPlayerHpComponent>()?.UpdateSkillUseMP();
                    }

                    break;
                case NumericType.UnionId_0:
                    long unionId = args.Defend.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);
                    DlgFriend dlgFriend = root.GetComponent<UIComponent>().GetDlgLogic<DlgFriend>();
                    if (args.Defend.MainHero && dlgFriend != null && unionId > 0)
                    {
                        dlgFriend.OnCreateUnion();
                    }

                    if (args.Defend.MainHero && dlgFriend != null && unionId == 0)
                    {
                        dlgFriend.OnLeaveUnion();
                    }

                    if (args.Defend.MainHero)
                    {
                        root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.E_UnionButton.gameObject.SetActive(unionId > 0);
                    }

                    break;
                case NumericType.UnionLeader:
                    if (args.Defend.MainHero)
                    {
                        args.Defend.GetComponent<UIPlayerHpComponent>().UpdateShow();
                    }

                    break;
                case NumericType.BossBelongID:
                    long bossbelongid = args.Defend.GetComponent<NumericComponentC>().GetAsLong(NumericType.BossBelongID);

                    root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainHpBar.OnUpdateBelongID(args.Defend.Id, bossbelongid);
                    break;
                case NumericType.PetChouKa:
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgPetEgg>()?.UpdateChouKaTime();
                    break;
                case NumericType.Now_Weapon:
                    int weaponId = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.Now_Weapon);
                    args.Defend.GetComponent<ChangeEquipComponent>()?.ChangeWeapon(weaponId);
                    if (args.Defend.MainHero)
                    {
                        root.GetComponent<AttackComponent>().OnInitOcc(args.Defend.ConfigId);
                    }

                    break;
                case NumericType.EquipIndex:
                    args.Defend.GetComponent<ChangeEquipComponent>()?.ChangeEquipIndex();
                    if (args.Defend.MainHero)
                    {
                        root.GetComponent<AttackComponent>().OnInitOcc(args.Defend.ConfigId);
                        args.Defend.GetComponent<AnimatorComponent>()?.UpdateController();
                        args.Defend.GetComponent<AnimationComponent>().UpdateAnimData(args.Defend.GetComponent<GameObjectComponent>().GameObject);
                        args.Defend.GetComponent<GameObjectComponent>().CheckRunState();
                    }

                    break;
                case NumericType.Now_XiLian:
                    break;
                case NumericType.Ling_DiLv:
                    break;
                case NumericType.Ling_DiExp:
                    break;
                case NumericType.PetSkin:
                    args.Defend.RemoveComponent<EffectViewComponent>();
                    args.Defend.RemoveComponent<GameObjectComponent>();
                    args.Defend.RemoveComponent<AnimatorComponent>();
                    args.Defend.RemoveComponent<HeroTransformComponent>();
                    args.Defend.RemoveComponent<FsmComponent>();
                    args.Defend.RemoveComponent<UIPlayerHpComponent>();
                    args.Defend.AddComponent<GameObjectComponent>();
                    break;
                case NumericType.TitleID:
                    args.Defend.GetComponent<UIPlayerHpComponent>()?.UpdateShow();
                    break;
                case NumericType.ZeroClock:
                    root.GetComponent<UserInfoComponentC>().ClearDayData();
                    root.GetComponent<TaskComponentC>().OnZeroClockUpdate();
                    root.GetComponent<ActivityComponentC>().OnZeroClockUpdate();
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnZeroClockUpdate();
                    break;
                case NumericType.HongBao:
                    int hongbao = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.HongBao);
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnHongBao(hongbao);
                    break;
                case NumericType.PointRemain:
                    ReddotComponentC reddotComponent = root.GetComponent<ReddotComponentC>();
                    reddotComponent.UpdateReddont(ReddotType.RolePoint);
                    break;
                case NumericType.BossInCombat:
                    int incombat = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.BossInCombat);
                    args.Defend.GetComponent<MonsterActRangeComponent>()?.OnBossInCombat(incombat);
                    break;
                case NumericType.Now_AI:
                    args.Defend.GetComponent<UIPlayerHpComponent>()?.UpdateAI();
                    break;
                case NumericType.Now_TurtleAI:
                    //小龟状态改变。 头顶随机说一句话
                    args.Defend.GetComponent<UINpcHpComponent>()?.UpdateTurtleAI();
                    break;
                case NumericType.HorseRide:
                    args.Defend.GetComponent<GameObjectComponent>()?.OnUpdateHorse();
                    args.Defend.GetComponent<UIPlayerHpComponent>()?.OnUpdateHorse();
                    break;
                case NumericType.HorseFightID:
                    if (args.Defend.MainHero)
                    {
                        root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnHorseRide();
                    }

                    break;
                case NumericType.JiaYuanPickOther:
                case NumericType.JiaYuanGatherOther:
                    DlgJiaYuanMain dlgJiaYuanMain = root.GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>();
                    if (dlgJiaYuanMain != null)
                    {
                        dlgJiaYuanMain.View.ES_JiaYuaVisit.UpdateGatherTimes();
                    }

                    break;
                case NumericType.BattleTodayKill:
                    DlgBattleMain dlgBattleMain = root.GetComponent<UIComponent>().GetDlgLogic<DlgBattleMain>();
                    dlgBattleMain?.OnUpdateSelfKill();
                    break;
                case NumericType.PetExtendNumber:
                    Log.Debug("NumericType.PetExtendNumber");
                    break;
                case NumericType.TowerId:
                    int towerId = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.TowerId);
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgTowerOpen>().OnUpdateUI(towerId);
                    break;
                case NumericType.KillMonsterNumber:
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().UpdateKillMonsterReward();
                    break;
                case NumericType.RingTaskId:
                    int newvalue1 = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.RingTaskId);
                    if (newvalue1 != 0)
                    {
                        TaskClientNetHelper.RequestGetTask(root, newvalue1).Coroutine();
                    }

                    break;
                case NumericType.UnionTaskId:
                    int newvalue2 = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.UnionTaskId);
                    if (newvalue2 != 0)
                    {
                        TaskClientNetHelper.RequestGetTask(root, newvalue2).Coroutine();
                    }

                    break;
                case NumericType.DailyTaskID:
                    int newvalue3 = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.DailyTaskID);
                    if (newvalue3 != 0)
                    {
                        TaskClientNetHelper.RequestGetTask(root, newvalue3).Coroutine();
                    }

                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}