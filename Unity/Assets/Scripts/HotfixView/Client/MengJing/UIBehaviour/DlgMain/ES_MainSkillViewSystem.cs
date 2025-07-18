using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(ES_JoystickMove))]
    [FriendOf(typeof(ES_AttackGrid))]
    [FriendOf(typeof(ES_FangunSkill))]
    [FriendOf(typeof(ES_SkillGrid))]
    [EntitySystemOf(typeof(ES_MainSkill))]
    [FriendOf(typeof(ES_MainSkill))]
    public static partial class ES_MainSkillSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainSkill self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_HorseButton.AddListener(self.OnButton_HorseButton);

            self.E_Btn_TargetButton.AddListener(self.OnBtn_TargetButton);

            self.E_Btn_ShiQuButton.AddListener(() => { self.OnShiquItem(ConfigData.DefaultShiquRange); });

            self.E_Btn_NpcDuiHuaButton.AddListener(self.OnBtn_NpcDuiHuaButton);

            self.E_Button_ZhuaPuButton.AddListener(self.OnButton_ZhuaPuButton);
            self.E_Button_ZhuaPuButton.gameObject.SetActive(false);

            self.E_Btn_PetTargetButton.AddListenerAsync(self.OnBtn_PetTargetButton);

            self.E_Btn_CancleSkillEventTrigger.RegisterEvent(EventTriggerType.PointerEnter, (pdata) => { self.OnEnterCancelButton(); });
            self.E_Btn_CancleSkillEventTrigger.gameObject.SetActive(false);

            self.E_Btn_JingLingButton.AddListenerAsync(self.OnBtn_JingLingButton);

            self.E_Button_Switch_0Button.AddListenerAsync(self.OnButton_Switch_0Button);

            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_0);
            self.ES_SkillGrid_Normal_0.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_1);
            self.ES_SkillGrid_Normal_1.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_2);
            self.ES_SkillGrid_Normal_2.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_3);
            self.ES_SkillGrid_Normal_3.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_4);
            self.ES_SkillGrid_Normal_4.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_5);
            self.ES_SkillGrid_Normal_5.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_6);
            self.ES_SkillGrid_Normal_6.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_7);
            self.ES_SkillGrid_Normal_7.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_8);
            self.ES_SkillGrid_Normal_8.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_Normal.Add(self.ES_SkillGrid_Normal_9);
            self.ES_SkillGrid_Normal_9.SkillCancelHandler = self.ShowCancelButton;

            self.ES_SkillGrid_Normal_juexing.SkillCancelHandler = self.ShowCancelButton;
            self.ES_SkillGrid_Normal_juexing.uiTransform.gameObject.SetActive(false);

            self.ES_FangunSkill.uiTransform.gameObject.SetActive(true);

            self.UISkillGirdList_PetFight.Add(self.ES_SkillGrid_PetFight_0);
            self.ES_SkillGrid_PetFight_0.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_PetFight.Add(self.ES_SkillGrid_PetFight_1);
            self.ES_SkillGrid_PetFight_1.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_PetFight.Add(self.ES_SkillGrid_PetFight_2);
            self.ES_SkillGrid_PetFight_2.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_PetFight.Add(self.ES_SkillGrid_PetFight_3);
            self.ES_SkillGrid_PetFight_3.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_PetFight.Add(self.ES_SkillGrid_PetFight_4);
            self.ES_SkillGrid_PetFight_4.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_PetFight.Add(self.ES_SkillGrid_PetFight_5);
            self.ES_SkillGrid_PetFight_5.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_PetFight.Add(self.ES_SkillGrid_PetFight_6);
            self.ES_SkillGrid_PetFight_6.SkillCancelHandler = self.ShowCancelButton;
            self.UISkillGirdList_PetFight.Add(self.ES_SkillGrid_PetFight_7);
            self.ES_SkillGrid_PetFight_7.SkillCancelHandler = self.ShowCancelButton;

            self.ES_AttackGrid.uiTransform.gameObject.SetActive(true);

            self.E_Btn_CancleSkillButton.AddListener(self.OnBtn_CancleSkillButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_MainSkill self)
        {
            self.DestroyWidget();
        }

        public static void OnButton_HorseButton(this ES_MainSkill self)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnCityHorseButton(true);
        }

        private static void OnCityHorseButton(this ES_MainSkill self, bool showtip)
        {
            Unit unit = self.MainUnit;
            int now_horse = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseRide);
            if (now_horse == 0 && !self.Root().GetComponent<BattleMessageComponent>().IsCanRideHorse())
            {
                FlyTipComponent.Instance.ShowFlyTip("战斗状态不能骑马!");
                return;
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (SceneConfigHelper.UseSceneConfig(mapComponent.MapType))
            {
                int sceneid = mapComponent.SceneId;
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
                if (sceneConfig.IfMount == 1)
                {
                    if (showtip)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("该场景不能骑马!");
                    }

                    return;
                }
            }

            UserInfoNetHelper.HorseRideRequest(self.Root()).Coroutine();
        }

        public static async ETTask OnBtn_PetTargetButton(this ES_MainSkill self)
        {
            long lockId = self.Root().GetComponent<LockTargetComponent>().LastLockId;
            if (lockId == 0)
            {
                return;
            }

            await BagClientNetHelper.PetTargetLock(self.Root(), lockId);
        }

        public static async ETTask OnButton_Switch_0Button(this ES_MainSkill self)
        {
            if (self.SwitchCDEndTime != 0)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemInfo equip_1 = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            ItemInfo equip_2 = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip_2, (int)ItemSubTypeEnum.Wuqi);
            if (equip_1 == null || equip_2 == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先在对应位置装备武器！");
                return;
            }

            Unit unit = self.MainUnit;
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int equipIndex = numericComponent.GetAsInt(NumericType.EquipIndex);

            M2C_ItemEquipIndexResponse response = await BagClientNetHelper.ItemEquipIndex(self.Root(), equipIndex == 0 ? 1 : 0);
            if (self.IsDisposed || response.Error > 0)
            {
                return;
            }

            self.SwitchCDEndTime = TimeHelper.ServerNow() + ConfigData.HunterSwichCD;

            self.OnUpdateButton();
            self.ShowSwitchCD().Coroutine();
            self.Root().GetComponent<AttackComponent>().UpdateComboTime();
            EventSystem.Instance.Publish(self.Root(), new EquipWear());
        }

        public static async ETTask ShowSwitchCD(this ES_MainSkill self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (self.SwitchCDEndTime > 0)
            {
                long passTime = self.SwitchCDEndTime - TimeHelper.ServerNow();
                if (passTime < 0)
                {
                    self.SwitchCDEndTime = 0;
                    break;
                }

                float rate = passTime * 1f / ConfigData.HunterSwichCD;
                self.E_Button_Switch_CDImage.fillAmount = rate;
                await timerComponent.WaitFrameAsync();
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }

        public static void OnUpdateButton(this ES_MainSkill self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int equipIndex = numericComponent.GetAsInt(NumericType.EquipIndex);
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            self.E_Button_Switch_0Button.gameObject.SetActive(occ == 3);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, equipIndex == 0 ? "c12" : "c11");
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_Button_Switch_0Image.sprite = sp;
        }

        public static void OnCardTranfer(this ES_MainSkill self, int runraceid)
        {
        }

        public static void OnRunRaceTranfer(this ES_MainSkill self, int runraceid)
        {
            //切换技能按钮。。 变身后只有一个技能按钮，读取monsterconfig.ActSkillID.. 
            if (runraceid > 0)
            {
                self.ES_SkillGrid_Transforms_0.SkillCancelHandler = self.ShowCancelButton;

                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(runraceid);
                if (monsterConfig.SkillID != null && monsterConfig.SkillID.Length > 0)
                {
                    SkillPro skillPro = new();
                    skillPro.SkillID = monsterConfig.SkillID[0];
                    skillPro.SkillSetType = SkillSetEnum.Skill;
                    self.ES_SkillGrid_Transforms_0.UpdateSkillInfo(skillPro);
                }

                self.EG_NormalRectTransform.gameObject.SetActive(false);
                self.EG_TransformsRectTransform.gameObject.SetActive(true);
                self.EG_PetFightRectTransform.gameObject.SetActive(false);
            }
            else
            {
                self.EG_NormalRectTransform.gameObject.SetActive(true);
                self.EG_TransformsRectTransform.gameObject.SetActive(false);
                self.EG_PetFightRectTransform.gameObject.SetActive(false);
            }
        }

        public static void OnPetFightSwitch(this ES_MainSkill self, long petId)
        {
            if (petId <= 0)
            {
                self.EG_NormalRectTransform.gameObject.SetActive(true);
                self.EG_TransformsRectTransform.gameObject.SetActive(false);
                self.EG_PetFightRectTransform.gameObject.SetActive(false);
                return;
            }

            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            List<int> skill = new List<int>();
            foreach (PetBarInfo petBarInfo in petComponentC.GetNowPetFightList())
            {
                if (petBarInfo.PetId == petId)
                {
                    // 释放出场技
                    if (petBarInfo.AppearSkill != 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("释放出场技");

                        int angle = 0;
                        long targetId = 0;
                        float distance = 0;
                        SkillConfig skillConfig = SkillConfigCategory.Instance.Get(petBarInfo.AppearSkill);
                        if (skillConfig.SkillZhishiTargetType == 1) //自身点
                        {
                            angle = 0;
                            targetId = 0;
                            distance = 0;
                        }
                        else
                        {
                            Unit enemy = GetTargetHelperc.GetNearestEnemy(self.MainUnit, (float)skillConfig.SkillRangeSize + 4);
                            if (enemy != null)
                            {
                                float3 direction = enemy.Position - self.MainUnit.Position;
                                float ange = math.degrees(math.atan2(direction.x, direction.z));
                                angle = (int)math.floor(ange);
                                targetId = enemy.Id;
                                distance = math.distance(enemy.Position, self.MainUnit.Position);
                            }
                        }

                        self.MainUnit.GetComponent<SkillManagerComponentC>().SendUseSkill(petBarInfo.AppearSkill, 0, angle, targetId, distance)
                                .Coroutine();
                    }

                    skill.AddRange(petBarInfo.ActiveSkill);
                    break;
                }
            }

            int max = 4;// 总共最多4个技能
            RolePetInfo rolePetInfo = petComponentC.GetPetInfoByID(petId);
            foreach (int skillId in rolePetInfo.PetSkill)
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
                if (skillConfig.SkillType == (int)SkillTypeEnum.PassiveSkill ||
                    skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkill ||
                    skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkillNoFight)
                {
                    continue;
                }

                if (skill.Count >= max)
                {
                    break;
                }

                skill.Add(skillId);
            }

            for (int i = 0; i < 8; i++)
            {
                ES_SkillGrid esSkillGrid = self.UISkillGirdList_PetFight[i];

                if (i < skill.Count)
                {
                    SkillPro skillPro = new();
                    skillPro.SkillID = skill[i];
                    skillPro.SkillSetType = SkillSetEnum.Skill;
                    esSkillGrid.uiTransform.gameObject.SetActive(true);
                    esSkillGrid.UpdateSkillInfo(skillPro);
                    continue;
                }

                if (i < max)
                {
                    esSkillGrid.uiTransform.gameObject.SetActive(true);
                    esSkillGrid.UpdateSkillInfo(null);
                    esSkillGrid.E_Img_MaskImage.gameObject.SetActive(true);
                    continue;
                }

                esSkillGrid.uiTransform.gameObject.SetActive(false);
                esSkillGrid.UpdateSkillInfo(null);
            }

            self.EG_NormalRectTransform.gameObject.SetActive(false);
            self.EG_TransformsRectTransform.gameObject.SetActive(false);
            self.EG_PetFightRectTransform.gameObject.SetActive(true);
        }

        public static void OnUpdateAngle(this ES_MainSkill self)
        {
            Unit unit = self.MainUnit;
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            bool show_old = self.ES_SkillGrid_Normal_juexing.uiTransform.gameObject.activeSelf;
            bool show_new = numericComponent.GetAsInt(NumericType.JueXingAnger) >= 500;
            self.ES_SkillGrid_Normal_juexing.uiTransform.gameObject.SetActive(show_new);
            if (show_old != show_new)
            {
                self.ES_SkillGrid_Normal_juexing.RemoveSkillInfoShow();
            }

            if (show_old && !show_new)
            {
                self.Root().GetComponent<SkillIndicatorComponent>().RecoveryEffect();
            }
        }

        public static void CheckJingLingFunction(this ES_MainSkill self)
        {
            self.E_Btn_JingLingButton.gameObject.SetActive(false);
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            if (chengJiuComponent.GetFightJingLing() == 0)
            {
                return;
            }

            bool showButton = false;
            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(chengJiuComponent.GetFightJingLing());
            switch (jingLingConfig.FunctionType)
            {
                case 1:
                    showButton = chengJiuComponent.RandomDrop == 0;
                    break;
                case 7:
                    showButton = true;
                    break;
                default:
                    showButton = false;
                    break;
            }

            self.E_Btn_JingLingButton.gameObject.SetActive(showButton);
        }

        public static async ETTask OnBtn_JingLingButton(this ES_MainSkill self)
        {
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            if (chengJiuComponent.GetFightJingLing() == 0)
            {
                return;
            }

            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(chengJiuComponent.GetFightJingLing());
            switch (jingLingConfig.FunctionType)
            {
                case 1:
                    if (chengJiuComponent.RandomDrop == 1)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("每日只能获取一次奖励！");
                        return;
                    }

                    await BagClientNetHelper.JingLingDrop(self.Root());
                    chengJiuComponent.RandomDrop = 1;
                    self.CheckJingLingFunction();
                    break;
                case 7:
                    int functionId = int.Parse(jingLingConfig.FunctionValue);
                    FuntionConfig funtionConfig = FuntionConfigCategory.Instance.Get(functionId);
                    WindowID uipath = FunctionUI.GetUIPath(funtionConfig.Name);
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(uipath).Coroutine();
                    break;
                default:
                    break;
            }
        }

        public static void OnLockUnit(this ES_MainSkill self, Unit unitlock)
        {
            if (unitlock == null || unitlock.Type != UnitType.Monster)
            {
                self.E_Button_ZhuaPuButton.gameObject.SetActive(false);
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitlock.ConfigId);
            //除了boss 都可以抓捕。。
            self.E_Button_ZhuaPuButton.gameObject.SetActive(monsterConfig.MonsterType == MonsterTypeEnum.Normal
                || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_58 
                || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_59);
        }

        public static void OnButton_ZhuaPuButton(this ES_MainSkill self)
        {
            long lockTargetId = self.Root().GetComponent<LockTargetComponent>().LastLockId;
            if (lockTargetId == 0)
            {
                return;
            }

            Unit main = self.MainUnit;
            Unit target = main.GetParent<UnitComponent>().Get(lockTargetId);
            if (target == null)
            {
                return;
            }

            if (target.Type != UnitType.Monster)
            {
                return;
            }
            
            float distance = 10f;
            int zhuabutype = self.GetZhuaBuType(target.ConfigId);
            if (zhuabutype == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("无法捕捉，此怪物无法成为您的宠物哦！");
                return;
            }
            if (zhuabutype == 1)
            {
                distance = 3f;
            }

            if (zhuabutype == 2)
            {
                int selflv = self.Root().GetComponent<UserInfoComponentC>().GetUserLv();
                int monsterlv = MonsterConfigCategory.Instance.Get(target.ConfigId).Lv;

                if (selflv < monsterlv)
                {
                    FlyTipComponent.Instance.ShowFlyTip("无法捕捉比自己等级高的宠物哦！");
                    return;
                }
            }

            if (PositionHelper.Distance2D(main.Position, target.Position) <= distance)
            {
                self.OnArriveNpc(target);
                return;
            }

            Vector3 unitPos = main.Position;
            Vector3 targetPos = target.Position;
            Vector3 dir = (unitPos - targetPos).normalized;
            Vector3 position = targetPos + dir * (distance - 1f);
            self.MoveToNpc(target, position).Coroutine();
        }

        public static void OnArriveNpc(this ES_MainSkill self, Unit target)
        {
            if (target == null || target.IsDisposed)
            {
                return;
            }
            int zhuabutype = self.GetZhuaBuType(target.ConfigId);
            if (zhuabutype == 0)
            {
                return;
            }
            if (zhuabutype == 1)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.uiTransform.gameObject.SetActive(false);
                 UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                 uiComponent.CurrentNpcId = target.ConfigId;
                 uiComponent.CurrentNpcUI = WindowID.WindowID_ZhuaPu;
                MJCameraComponent cameraComponent = self.Root().CurrentScene().GetComponent<MJCameraComponent>();
                
                cameraComponent.SetBuildEnter(target, CameraBuildType.Type_0, () => { self.OnBuildEnter().Coroutine(); });
                cameraComponent.NoHideIds = new List<long>() { target.Id  };
            }
            if (zhuabutype == 2)
            {
                self.OnBuildEnter().Coroutine();
            }
        }

        public static async ETTask MoveToNpc(this ES_MainSkill self, Unit target, Vector3 position)
        {
            Unit unit = self.MainUnit;
            if (ErrorCode.ERR_Success != unit.GetComponent<StateComponentC>().CanMove())
                return;

            int ret = await unit.MoveToAsync(position);
            if (ret != 0)
            {
                return;
            }

            if (PositionHelper.Distance2D(unit.Position, position) > 3f)
            {
                return;
            }

            self.OnArriveNpc(target);
        }

        public static async ETTask OnBuildEnter(this ES_MainSkill self)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
            long lockTargetId = self.Root().GetComponent<LockTargetComponent>().LastLockId;
            if (lockTargetId == 0)
            {
                return;
            }

            Unit unit = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(lockTargetId);
            if (unit == null || unit.Type != UnitType.Monster)
            {
                return;
            }
            
            int zhuabutype = self.GetZhuaBuType(unit.ConfigId);
            if (zhuabutype == 0)
            {
                return;
            }

            if (zhuabutype == 1)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ZhuaPu);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgZhuaPu>().OnInitUI(unit);
            }
            if(zhuabutype == 2)
            {
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                self.OnType2_ButtonDig(unit).Coroutine();
            }
        }

        public static int GetZhuaBuType(this ES_MainSkill self, int monsterid)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterid);
            if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_58
                || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_59)
            {
                return 1;
            }
            else
            {
                if ( !PetHelper.IsHaveQiYuPetId(monsterConfig.QiYuPetId) )
                {
                    return 0;
                }

                return 2;
            }
        }

        private static async ETTask OnType2_ButtonDig(this ES_MainSkill self, Unit zhupuUnit)
        {
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Vitality < 5)
            {
                FlyTipComponent.Instance.ShowFlyTip("活力不足！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int petexpendNumber = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber);
            int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, petexpendNumber);
            if (PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos) >= maxNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("宠物格子不足！");
                return;
            }
            
            M2C_ZhuaBuType2Response response = await JingLingNetHelper.ZhuaBuType2Request(self.Root(), zhupuUnit.Id, 0, "0");
            // 捕捉成功，
            // 捕捉失败怪物死亡（就是隐藏 并播放特效）
            // 捕捉失败怪物逃跑（怪物随机出现在当前地图的任意一个位置）
            if (response.Error == ErrorCode.ERR_Success && response.Message == string.Empty)
            {
                FlyTipComponent.Instance.ShowFlyTip("恭喜你，抓捕成功！");
            }
            if (response.Message == "1")
            {
                FlyTipComponent.Instance.ShowFlyTip("捕捉失败怪物死亡！");
            }
            if (response.Message == "2")
            {
                FlyTipComponent.Instance.ShowFlyTip("捕捉失败怪物逃跑！");
            }
        }
        
        public static void OnBtn_NpcDuiHuaButton(this ES_MainSkill self)
        {
            DuiHuaHelper.MoveToNpcDialog(self.Root());
        }

        public static void OnShiquItem(this ES_MainSkill self, float distance)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) <= 0)
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
                return;
            }

            Unit main = self.MainUnit;
            if (main.GetComponent<SkillManagerComponentC>().IsSkillMoveTime())
            {
                return;
            }

            List<Unit> units = MapHelper.GetCanShiQu(self.Root(), distance);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (units.Count > 0)
            {
                for (int i = units.Count - 1; i >= 0; i--)
                {
                    ItemConfig itemConfig =
                            ItemConfigCategory.Instance.Get(units[i].GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId));

                    if (userInfoComponent.PickSet[0] == "1" && itemConfig.ItemQuality == 2)
                    {
                        units.RemoveAt(i);
                        continue;
                    }

                    // 蓝色 金币除外
                    if (userInfoComponent.PickSet[1] == "1" && itemConfig.ItemQuality == 3 && itemConfig.Id != 1)
                    {
                        units.RemoveAt(i);
                        continue;
                    }
                }

                if (units.Count <= 0)
                {
                    return;
                }

                self.RequestShiQu(units).Coroutine();

                //播放音效
                CommonViewHelper.PlayUIMusic("10004");
                return;
            }
            else
            {
                Unit unit = MapHelper.GetNearItem(self.Root());
                if (unit != null)
                {
                    Vector3 mainPos = main.Position;
                    Vector3 unitPos = unit.Position;
                    Vector3 dir = (mainPos - unitPos).normalized;
                    Vector3 tar = unitPos + dir * 1f;
                    self.MoveToShiQu(tar).Coroutine();
                    return;
                }
            }

            long chestId = MapHelper.GetChestBox(self.Root());
            if (chestId != 0)
            {
                self.Root().CurrentScene().GetComponent<OperaComponent>().OnClickChest(chestId);
            }
        }

        public static async ETTask RequestShiQu(this ES_MainSkill self, List<Unit> units)
        {
            if (Time.time - self.LastPickTime < 1f)
            {
                return;
            }

            self.LastPickTime = Time.time;
            Unit unit = self.MainUnit;
            if (!unit.GetComponent<MoveComponent>().IsArrived())
            {
                self.Root().GetComponent<ClientSenderCompnent>().Send(C2M_Stop.Create());
            }

            unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmShiQuItem);

            foreach (Unit u in units)
            {
                DropFlyComponent dropFlyComponent = u.GetComponent<DropFlyComponent>();
                if (dropFlyComponent == null)
                {
                    u.AddComponent<DropFlyComponent>();
                }
            }

            unit.GetComponent<StateComponentC>().SetNetWaitEndTime(TimeHelper.ClientNow() + 200);
            long instancId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            if (instancId != self.InstanceId)
            {
                return;
            }

            unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmIdleState);
        }

        public static async ETTask MoveToShiQu(this ES_MainSkill self, Vector3 position)
        {
            Unit unit = self.MainUnit;
            int value = await unit.MoveToAsync(position);
            List<Unit> units = MapHelper.GetCanShiQu(self.Root(), 3f);
            if (value == 0 && units.Count > 0)
            {
                self.RequestShiQu(units).Coroutine();
            }
        }

        public static void CheckSkillSecond(this ES_MainSkill self)
        {
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                if (self.UISkillGirdList_Normal[i].SkillPro == null)
                {
                    continue;
                }

                if (self.UISkillGirdList_Normal[i].SkillSecond == 1)
                {
                    self.UISkillGirdList_Normal[i].CheckSkillSecond();
                }
            }
        }

        public static void OnSkillSecond(this ES_MainSkill self, M2C_SkillSecondResult message)
        {
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                if (self.UISkillGirdList_Normal[i].SkillPro == null)
                {
                    continue;
                }

                if (self.UISkillGirdList_Normal[i].SkillPro.SkillID == message.SkillId)
                {
                    self.UISkillGirdList_Normal[i].OnSkillSecondResult(message);
                }
            }
        }

        public static void OnSkillBeging(this ES_MainSkill self, string dataParams)
        {
            int skillId = int.Parse(dataParams);
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                if (self.UISkillGirdList_Normal[i].SkillPro == null)
                {
                    continue;
                }

                if (self.UISkillGirdList_Normal[i].SkillPro.SkillID == skillId)
                {
                    self.UISkillGirdList_Normal[i].E_Button_CancleButton.gameObject.SetActive(true);
                }
            }
        }

        public static void OnSkillFinish(this ES_MainSkill self, string dataParams)
        {
            int skillId = int.Parse(dataParams);
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                if (self.UISkillGirdList_Normal[i].SkillPro == null)
                {
                    continue;
                }

                if (self.UISkillGirdList_Normal[i].SkillPro.SkillID == skillId)
                {
                    self.UISkillGirdList_Normal[i].E_Button_CancleButton.gameObject.SetActive(false);
                }
            }
        }

        public static void OnSkillCDUpdate(this ES_MainSkill self)
        {
            long serverTime = TimeHelper.ServerNow();
            long pulicCd = self.SkillManagerComponent.SkillPublicCDTime - serverTime;
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                ES_SkillGrid uISkillGridComponent = self.UISkillGirdList_Normal[i];
                uISkillGridComponent.OnUpdate(self.SkillManagerComponent.GetCdTime(uISkillGridComponent.GetSkillId(), serverTime),
                    i < 8 ? pulicCd : 0);
            }

            for (int i = 0; i < self.UISkillGirdList_PetFight.Count; i++)
            {
                ES_SkillGrid uISkillGridComponent = self.UISkillGirdList_PetFight[i];
                uISkillGridComponent.OnUpdate(self.SkillManagerComponent.GetCdTime(uISkillGridComponent.GetSkillId(), serverTime),
                    i < 8 ? pulicCd : 0);
            }

            if (self.JueXingSkillId > 0)
            {
                self.ES_SkillGrid_Normal_juexing.OnUpdate(self.SkillManagerComponent.GetCdTime(self.JueXingSkillId, serverTime), pulicCd);
            }

            self.ES_SkillGrid_Transforms_0?.OnUpdate(self.SkillManagerComponent.GetCdTime(self.ES_SkillGrid_Transforms_0.GetSkillId(), serverTime),
                pulicCd);
            self.ES_FangunSkill.OnUpdate(self.SkillManagerComponent.GetCdTime(self.ES_FangunSkill.SkillId, serverTime));
        }
        
        public static void InitMainHero(this ES_MainSkill self)
        {
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            self.SkillManagerComponent = self.MainUnit.GetComponent<SkillManagerComponentC>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="main"></param>
        /// <param name="petid"></param>
        public static void OnEnterScene(this ES_MainSkill self, Unit main, long petid)
        {
            if (main == null)
            {
                return; 
            }

            self.InitMainHero();
            self.OnSkillCDUpdate();
            self.CheckJingLingFunction();
            self.OnUpdateButton();
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                self.UISkillGirdList_Normal[i].RemoveSkillInfoShow();
                self.UISkillGirdList_Normal[i].ResetSkillSecond();
            }

            self.ES_SkillGrid_Normal_juexing.RemoveSkillInfoShow();
        }

        public static void ResetUI(this ES_MainSkill self)
        {
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                ES_SkillGrid uISkillGridComponent = self.UISkillGirdList_Normal[i];
                uISkillGridComponent.RemoveSkillInfoShow();
                uISkillGridComponent.OnUpdate(0, 0);
                uISkillGridComponent.UseSkill = false;
            }

            self.ES_FangunSkill.OnUpdate(0);
        }

        public static void OnBtn_TargetButton(this ES_MainSkill self)
        {
            LockTargetComponent lockTargetComponent = self.Root().GetComponent<LockTargetComponent>();
            lockTargetComponent.LastLockId = 0;
            lockTargetComponent.ChangeTargetUnit();
            self.LastLockTime = Time.time;
            
            // if (Time.time - self.LastLockTime > 1)
            // {
            //     lockTargetComponent.LastLockId = 0;
            //     lockTargetComponent.LockTargetUnit(true);
            //     self.LastLockTime = Time.time;
            // }
            // else
            // {
            //     lockTargetComponent.LockTargetUnit(true);
            // }
        }

        public static void ShowCancelButton(this ES_MainSkill self, bool show)
        {
            self.E_Btn_CancleSkillButton.gameObject.SetActive(show);
        }

        public static void OnEnterCancelButton(this ES_MainSkill self)
        {
            FlyTipComponent.Instance.ShowFlyTip("取消技能施法");

            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                self.UISkillGirdList_Normal[i].OnEnterCancelButton();
            }

            self.ES_SkillGrid_Normal_juexing.OnEnterCancelButton();
        }

        public static void OnBagItemUpdate(this ES_MainSkill self)
        {
            for (int i = 0; i < self.UISkillGirdList_Normal.Count; i++)
            {
                self.UISkillGirdList_Normal[i].UpdateItemNumber();
            }
        }

        public static void OnSkillSetUpdate(this ES_MainSkill self)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            for (int i = 0; i < 10; i++)
            {
                ES_SkillGrid skillgrid = self.UISkillGirdList_Normal[i];
                SkillPro skillid = skillSetComponent.GetByPosition(i + 1);
                skillgrid.UpdateSkillInfo(skillid);
            }

            int occTwo = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;
            if (occTwo == 0)
            {
                return;
            }

            OccupationTwoConfig occupationConfigCategory = OccupationTwoConfigCategory.Instance.Get(occTwo);
            int juexingid = occupationConfigCategory.JueXingSkill[7];
            self.ES_SkillGrid_Normal_juexing.UpdateSkillInfo(skillSetComponent.GetSkillPro(juexingid));
            self.JueXingSkillId = juexingid;
        }

        public static void OnBtn_CancleSkillButton(this ES_MainSkill self)
        {
        }
    }
}
