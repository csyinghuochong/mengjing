namespace ET.Client
{
    
    /// <summary>
    /// 表现
    /// </summary>
    ///
    ///
    /// 
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
                    int singlerechargeid = ActivityHelper.GetSingleRechargeId(addNumer);
                    if (singlerechargeid > 0 && !userInfoComponent.UserInfo.SingleRechargeIds.Contains(singlerechargeid))
                    {
                        userInfoComponent.UserInfo.SingleRechargeIds.Add(singlerechargeid);
                        root.GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.SingleRecharge);
                    }

                    root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRechageSucess(addNumer);
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgRecharge>()?.UpdateRechargeNum();
                    break;
                case NumericType.PetExploreLuckly:
                    root.GetComponent<UIComponent>().GetDlgLogic<DlgPetEgg>()?.OnUpdateLuckly();
                    break;
                case NumericType.WearWeaponFisrt:
                    //root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WearWeapon).Coroutine();
                    break;
                case NumericType.Now_Stall:
                    long stallType = args.Defend.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_Stall);
                    Log.Debug($"NumericType.Now_Stall: {args.Defend.Id}  {stallType}");
                    args.Defend.OnUnitStallUpdate(stallType);
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
                    MapViewHelper.UpdateBattleCamp(unitmain, args.Defend.Id);
                    break;
                case NumericType.RunRaceTransform:
                    int runraceMonster = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.RunRaceTransform);
                    args.Defend.GetComponent<GameObjectComponent>()?.OnRunRaceTranfer(runraceMonster);
                    if (args.Defend.MainHero)
                    {
                        args.Defend.Root().GetComponent<AttackComponent>().OnTransformId(args.Defend.ConfigId, runraceMonster);
                    }

                    break;
                case NumericType.PetFightIndex:
                    int petfightindex = (int)args.NewValue;
                    if (args.Defend.MainHero)
                    {
                        if (petfightindex > 0)
                        {
                           
                        }
                        else
                        {
                            // 切换成英雄特效
                            FunctionEffect.PlaySelfEffect(args.Defend, 200004);
                        }
                        
                        EventSystem.Instance.Publish(root, new PetBarUpdate());
                    }
                    else
                    {
                        if (petfightindex > 0)
                        {
                            // 其他玩家切换成宠物特效
                        }
                        else
                        {
                            // 其他玩家切换成英雄特效
                            // FunctionEffect.PlaySelfEffect(args.Defend, 200004);
                        }
                    }
                    break;
                case NumericType.PetMeleeMoLi:
                    if (args.Defend.MainHero)
                    {
                        root.GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>()?.UpdateMoLi();
                    }

                    break;
                case NumericType.CardTransform:
                    int cardMonster = args.Defend.GetComponent<NumericComponentC>().GetAsInt(NumericType.CardTransform);
                    args.Defend.GetComponent<GameObjectComponent>().OnCardTranfer(cardMonster);
                    args.Defend.GetComponent<GameObjectComponent>().LoadGameObject();
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
                        if (oldvalue == newvalue && oldvalue!=0)
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
                    DlgUnion dlgFriend = root.GetComponent<UIComponent>().GetDlgLogic<DlgUnion>();
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
                        //root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.E_UnionButton.gameObject.SetActive(unionId > 0);
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
                        // args.Defend.GetComponent<AnimationComponent>()?.UpdateAnimData(args.Defend.GetComponent<GameObjectComponent>().GameObject);
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
                case NumericType.PetMeleeMoLiAdd:
                    scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>()?.UpdatePetMeleeMoRPS();
                    break;
                case NumericType.SingleHappyRemainTimes:
                    Log.Debug($"NumericType.SingleHappyRemainTimes:  {args.NewValue}");
                    scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSingleHappyMain>()?.ShowTimes();
                    break;
                case NumericType.Now_Hp:
                case NumericType.Now_MaxHp:
                    NumericComponentC numericComponentDefend = args.Defend.GetComponent<NumericComponentC>();
                    long costHp = 0;
                    if (args.NumericType == NumericType.Now_Hp)
                    {
                        long nowHpValue = numericComponentDefend.GetAsLong(NumericType.Now_Hp);
                        costHp = (nowHpValue - args.OldValue);
                    }

                    EventSystem.Instance.Publish(args.Defend.Root(), new Now_Hp_Update()
                    {
                        Defend = args.Defend,
                        ChangeHpValue = costHp,
                        DamgeType = args.DamgeType,
                        SkillID = args.SkillId,
                        AttackId = args.AttackId
                    });
                    break;
                default:
                    break;
            }

            await ETTask.CompletedTask;
        }
    }
}