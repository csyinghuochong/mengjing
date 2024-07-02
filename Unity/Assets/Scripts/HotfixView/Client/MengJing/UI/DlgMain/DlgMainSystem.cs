using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [NumericWatcher(SceneType.Demo, NumericType.KillMonsterNumber)]
    public class NumericWatcher_KillMonsterNumber_UpdateDlgMain: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.UpdateKillMonsterReward();
        }
    }

    [NumericWatcher(SceneType.Demo, NumericType.BossBelongID)]
    public class NumericWatcher_BossBelongID_UpdateDlgMain: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainHpBar.OnUpdateBelongID(args.Defend.Id, args.NewValue);
        }
    }

    [NumericWatcher(SceneType.Demo, NumericType.UnionId_0)]
    public class NumericWatcher_UnionId_0_UpdateDlgMain: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (unit.MainHero)
            {
                unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.E_UnionButton.gameObject.SetActive(args.NewValue > 0);
            }
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_OnPetFightSet_Refresh: AEvent<Scene, DataUpdate_OnPetFightSet>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_OnPetFightSet args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_RoleHead.OnPetFightSet();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_BagItemUpdate_Refresh: AEvent<Scene, DataUpdate_BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnBagItemUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class BuffUpdate_DlgMainRefresh: AEvent<Scene, BuffUpdate>
    {
        protected override async ETTask Run(Scene scene, BuffUpdate args)
        {
            DlgMain dlgMain = scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            if (dlgMain == null)
            {
                return;
            }

            if (args.Unit.MainHero)
            {
                dlgMain.View.ES_MainBuff.OnBuffUpdate(args.ABuffHandler, args.OperateType);
            }
            else
            {
                dlgMain.View.ES_MainHpBar.ES_MainBuff.OnBuffUpdate(args.ABuffHandler, args.OperateType);
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillSetting_DlgMainRefresh: AEvent<Scene, DataUpdate_SkillSetting>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_SkillSetting args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnSkillSetUpdate();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_UpdateUserData_Refresh: AEvent<Scene, DataUpdate_UpdateUserData>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_UpdateUserData args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnUpdateUserData(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SettingUpdate_Refresh: AEvent<Scene, DataUpdate_SettingUpdate>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_SettingUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnSettingUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskUpdate_Refresh: AEvent<Scene, DataUpdate_TaskUpdate>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_TaskUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.RefreshMainTaskItems();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskTrace_Refresh: AEvent<Scene, DataUpdate_TaskTrace>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_TaskTrace args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.RefreshMainTaskItems();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGet_DlgMainRefresh: AEvent<Scene, DataUpdate_TaskGet>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_TaskGet args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskComplete_DlgMainRefresh: AEvent<Scene, DataUpdate_TaskComplete>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_TaskComplete args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGiveUp_DlgMainRefresh: AEvent<Scene, DataUpdate_TaskGiveUp>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_TaskGiveUp args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_OnRecvChat_MainChatItemsRefresh: AEvent<Scene, DataUpdate_OnRecvChat>
    {
        protected override async ETTask Run(Scene root, DataUpdate_OnRecvChat args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvChat();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_MainHeroMove_MainChatItemsRefresh: AEvent<Scene, DataUpdate_MainHeroMove>
    {
        protected override async ETTask Run(Scene root, DataUpdate_MainHeroMove args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnMainHeroMove();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_BeforeMove_DlgMainRefresh: AEvent<Scene, DataUpdate_BeforeMove>
    {
        protected override async ETTask Run(Scene root, DataUpdate_BeforeMove args)
        {
            if (args.DataParamString == "1")
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.AutoHorse();
            }

            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnMoveStart();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_UpdateSing_DlgMainRefresh: AEvent<Scene, DataUpdate_UpdateSing>
    {
        protected override async ETTask Run(Scene root, DataUpdate_UpdateSing args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainHpBar.OnUpdateSing(args.DataParamString);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class SingingUpdate_DlgMainRefresh: AEvent<Scene, SingingUpdate>
    {
        protected override async ETTask Run(Scene root, SingingUpdate args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_Singing.OnTimer(args);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class BeforeSkill_DlgMainRefresh: AEvent<Scene, BeforeSkill>
    {
        protected override async ETTask Run(Scene root, BeforeSkill args)
        {
            DlgMain dlgMain = root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            if (dlgMain != null)
            {
                dlgMain.OnSpellStart();
                dlgMain.OnBeforeSkill();
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillCDUpdate_DlgMainRefresh: AEvent<Scene, DataUpdate_SkillCDUpdate>
    {
        protected override async ETTask Run(Scene root, DataUpdate_SkillCDUpdate args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnSkillCDUpdate();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillBeging_DlgMainRefresh: AEvent<Scene, DataUpdate_SkillBeging>
    {
        protected override async ETTask Run(Scene root, DataUpdate_SkillBeging args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnSkillBeging(args.DataParamString);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillFinish_DlgMainRefresh: AEvent<Scene, DataUpdate_SkillFinish>
    {
        protected override async ETTask Run(Scene root, DataUpdate_SkillFinish args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnSkillFinish(args.DataParamString);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_JingLingButton_DlgMainRefresh: AEvent<Scene, DataUpdate_JingLingButton>
    {
        protected override async ETTask Run(Scene root, DataUpdate_JingLingButton args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.CheckJingLingFunction();

            await ETTask.CompletedTask;
        }
    }

    [Invoke(TimerInvokeType.UIMainFPSTimer)]
    public class UIMainFPSTimer: ATimer<DlgMain>
    {
        protected override void Run(DlgMain self)
        {
            try
            {
                self.UpdatePing();
                self.UpdateMessage();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof (ES_RoleHead))]
    [FriendOf(typeof (ES_MainBuff))]
    [FriendOf(typeof (ES_MainHpBar))]
    [FriendOf(typeof (ES_OpenBox))]
    [FriendOf(typeof (ES_Singing))]
    [FriendOf(typeof (ES_ButtonPositionSet))]
    [FriendOf(typeof (DlgMainViewComponent))]
    [FriendOf(typeof (ES_JoystickMove))]
    [FriendOf(typeof (ES_MainSkill))]
    [FriendOf(typeof (Scroll_Item_MainChatItem))]
    [FriendOf(typeof (ChatComponent))]
    [FriendOf(typeof (TaskComponentC))]
    [FriendOf(typeof (UserInfoComponentC))]
    [FriendOf(typeof (DlgMain))]
    public static class DlgMainSystem
    {
        public static void RegisterUIEvent(this DlgMain self)
        {
            self.View.ES_ButtonPositionSet.InitButtons(self.View.uiTransform.gameObject);
            self.View.ES_ButtonPositionSet.uiTransform.gameObject.SetActive(false);

            self.View.E_DragPanelEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.View.E_DragPanelEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
            self.View.E_DragPanelEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            self.View.E_ShrinkButton.AddListener(self.OnShrinkButton);
            self.View.E_RoseEquipButton.AddListenerAsync(self.OnRoseEquipButton);
            self.View.E_PetButton.AddListenerAsync(self.OnPetButton);
            self.View.E_RoseSkillButton.AddListenerAsync(self.OnRoseSkillButton);
            self.View.E_TaskButton.AddListenerAsync(self.OnTaskButton);
            self.View.E_FriendButton.AddListener(self.OnFriendButton);
            self.View.E_ChengJiuButton.AddListener(self.OnChengJiuButton);

            self.View.E_AdventureButton.AddListener(self.OnAdventureButton);
            self.View.E_PetFormationButton.AddListener(self.OnPetFormationButton);
            self.View.E_CityHorseButton.AddListener(() => { self.OnCityHorseButton(true); });
            self.View.E_TeamDungeonButton.AddListener(self.OnTeamDungeonButton);
            self.View.E_JiaYuanButton.AddListener(self.OnJiaYuanButton);
            self.View.E_NpcDuiHuaButton.AddListener(self.OnNpcDuiHuaButton);
            self.View.E_UnionButton.AddListener(self.OnUnionButton);

            self.View.E_OpenChatButton.AddListener(self.OnOpenChat);

            self.View.E_Button_ZhanKaiButton.AddListener(self.OnButtonZhanKai);

            self.View.E_Button_RunRaceButton.AddListener(self.OnButton_RunRace);
            self.View.E_Button_HappyButton.AddListener(self.OnButton_Happy);
            self.View.E_Button_HuntButton.AddListener(self.OnButton_Hunt);
            self.View.E_Button_SoloButton.AddListener(self.OnButton_Solo);
            self.View.E_Btn_BattleButton.AddListener(self.OnButton_Battle);
            self.View.E_Button_DonationButton.AddListener(self.OnButton_Donation);
            self.View.E_Button_FenXiangButton.AddListener(self.OnButton_FenXiang);
            self.View.E_Btn_EveryTaskButton.AddListener(self.OnButton_EveryTask);
            self.View.E_Button_RechargeButton.AddListener(self.OnButton_Recharge);
            self.View.E_Btn_HuoDongButton.AddListener(self.OnButton_HuoDong);
            // self.View.E_Button_ZhenYingButton.AddListener();
            // self.View.E_Button_EnergyButton.AddListener();
            // self.View.E_Button_FashionButton.AddListener();
            // self.View.E_Button_DemonButton.AddListener();
            self.View.E_Button_SeasonButton.AddListener(self.OnButton_Season);

            // self.View.E_Button_ActivityV1Button.AddListener();
            self.View.E_Btn_AuctionButton.AddListener(self.OnButton_PaiMaiAuction);
            self.View.E_Button_HongBaoButton.AddListener(self.OnButton_HongBao);
            self.View.E_Button_ZhanQuButton.AddListener(self.OnButton_ZhanQu);
            self.View.E_Button_NewYearButton.AddListener(self.OnButton_NewYear);
            self.View.E_Button_RechargeRewardButton.AddListener(self.OnButton_RechargeReward);
            self.View.E_Button_WelfareButton.AddListener(self.OnButton_Welfare);
            self.View.E_Btn_GMButton.AddListener(self.OnBtn_GM);
            self.View.E_Btn_RankButton.AddListener(self.OnBtn_Rank);
            self.View.E_Button_WorldLvButton.AddListener(self.OnButton_WorldLv);
            self.View.E_Btn_PaiMaiHangButton.AddListener(self.OnBtn_PaiMaiHang);

            self.View.EG_Btn_KillMonsterRewardRectTransform.GetComponent<ReferenceCollector>().Get<GameObject>("Image_ItemButton")
                    .GetComponent<Button>().AddListenerAsync(self.OnBtn_KillMonsterReward);
            self.View.EG_Btn_LvRewardRectTransform.GetComponent<ReferenceCollector>().Get<GameObject>("Image_ItemButton")
                    .GetComponent<Button>().AddListenerAsync(self.OnBtn_LvReward);
            self.View.E_MailHintTipButton.AddListener(self.OnMailHintTip);
            self.View.E_E_Btn_MapTransferButton.AddListener(() => { self.OnBtn_MapTransfer().Coroutine(); });
            self.View.E_Btn_RerurnDungeonButton.AddListener(self.OnBtn_RerurnDungeon);
            self.View.E_Btn_RerurnBuildingButton.AddListener(self.OnClickReturnButton);

            self.View.E_Btn_StopGuaJiButton.AddListener(self.OnStopGuaJi);

            self.View.E_LeftTypeSetToggleGroup.AddListener(self.OnLeftTypeSet);
            self.View.E_MainTaskItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMainTaskItemsRefresh);
            self.View.E_RoseTaskButton.AddListener(self.OnOpenTask);
            self.View.E_MainTeamItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMainTeamItemsRefresh);
            self.View.E_RoseTeamButton.AddListener(self.OnBtn_RoseTeam);

            self.View.E_MainChatItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMainChatItemsRefresh);
            self.View.E_RoseTaskButton.AddListener(self.OnRoseTaskButton);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
            self.LockTargetComponent = self.Root().GetComponent<LockTargetComponent>();
            self.SkillIndicatorComponent = self.Root().GetComponent<SkillIndicatorComponent>();

            self.View.ES_RoleHead.uiTransform.gameObject.SetActive(true);
            self.View.ES_MainBuff.uiTransform.gameObject.SetActive(true);
            self.View.ES_MainHpBar.uiTransform.gameObject.SetActive(true);
            self.View.ES_OpenBox.uiTransform.gameObject.SetActive(false);
            self.View.ES_Singing.uiTransform.gameObject.SetActive(false);

            self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);

            self.View.E_LeftTypeSetToggleGroup.OnSelectIndex(0);
            self.RefreshMainTaskItems();

            //初始化基础属性
            self.InitShow();
            self.OnSettingUpdate();

            self.AfterEnterScene(SceneTypeEnum.MainCityScene);

            // IOS适配
            IPHoneHelper.SetPosition(self.View.EG_PhoneLeftRectTransform.gameObject, new Vector2(120f, 0f));
        }

        public static void BeforeUnload(this DlgMain self)
        {
            Log.Debug("DlgMain.BeforeUnload");
        }

        public static void BeginDrag(this DlgMain self, PointerEventData pdata)
        {
            self.PreviousPressPosition = pdata.position;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().StartRotate();
        }

        public static void Drag(this DlgMain self, PointerEventData pdata)
        {
            self.AngleX = (pdata.position.x - self.PreviousPressPosition.x) * self.DRAG_TO_ANGLE;
            self.AngleY = (pdata.position.y - self.PreviousPressPosition.y) * self.DRAG_TO_ANGLE;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().Rotate(-self.AngleX, -self.AngleY);
            self.PreviousPressPosition = pdata.position;
        }

        public static void EndDrag(this DlgMain self, PointerEventData pdata)
        {
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().EndRotate();
        }

        public static void ShowMainUI(this DlgMain self, bool show)
        {
            // MapComponent mapComponent = self.ZoneScene().GetComponent<MapComponent>();
            // int sceneType = mapComponent.SceneTypeEnum;
            // self.DoMoveLeft.SetActive(show);
            // self.DoMoveRight.SetActive(show);
            // self.DoMoveBottom.SetActive(show );
            // if (show)
            // {
            //     self.UIMainChat.UpdatePosition().Coroutine();
            // }
            // else
            // {
            //     self.ZoneScene().GetComponent<SkillIndicatorComponent>()?.RecoveryEffect();
            //     //self.UIJoystickMoveComponent.ResetUI(); //防止打开其他界面摇杆接受不到ui事件
            // }
            //
            // switch (sceneType)
            // {
            //     case SceneTypeEnum.JiaYuan:
            //         UIHelper.GetUI(self.ZoneScene(), UIType.UIJiaYuanMain).GameObject.SetActive(show);
            //         break;
            //     default:
            //         break;
            // }
        }

        public static void AutoHorse(this DlgMain self)
        {
            NumericComponentC numericComponent = self.MainUnit.GetComponent<NumericComponentC>();
            if (numericComponent.GetAsInt(NumericType.HorseRide) == 0 && numericComponent.GetAsInt(NumericType.HorseFightID) > 0)
            {
                self.OnButton_Horse(false);
            }
        }

        public static void OnButton_Horse(this DlgMain self, bool showtip)
        {
            // Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            // int now_horse = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseRide);
            // if (now_horse == 0 && !self.Root().GetComponent<BattleMessageComponent>().IsCanRideHorse())
            // {
            //     FlyTipComponent.Instance.SpawnFlyTipDi("战斗状态不能骑马!");
            //     return;
            // }
            //
            // MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            // if (SceneConfigHelper.UseSceneConfig(mapComponent.SceneType))
            // {
            //     int sceneid = mapComponent.SceneId;
            //     SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
            //     if (sceneConfig.IfMount == 1)
            //     {
            //         if (showtip)
            //         {
            //             FlyTipComponent.Instance.SpawnFlyTipDi("该场景不能骑马!");
            //         }
            //
            //         return;
            //     }
            // }
            //
            // C2M_HorseRideRequest request = new C2M_HorseRideRequest() { };
            // self.ZoneScene().GetComponent<SessionComponent>().Session.Call(request).Coroutine();
        }

        public static void OnMoveStart(this DlgMain self)
        {
            if (self.View.ES_OpenBox != null && self.View.ES_OpenBox.BoxUnitId > 0)
            {
                self.View.ES_OpenBox.OnOpenBox(null);
            }

            self.View.ES_MainSkill.ES_AttackGrid.OnMoveStart();

            self.MainUnit.GetComponent<SingingComponent>()?.BeginMove();
        }

        public static void OnMainHeroMove(this DlgMain self)
        {
            self.View.ES_MapMini.OnMainHeroMove();
            self.LockTargetComponent.OnMainHeroMove();
            self.SkillIndicatorComponent.OnMainHeroMove();

            if (self.TianQiEffectObj != null)
            {
                self.TianQiEffectObj.transform.localPosition = self.MainUnit.Position;
            }
        }

        #region 左边

        public static void OnRecvTaskUpdate(this DlgMain self)
        {
            self.RefreshMainTaskItems();
            self.UpdateNpcTaskUI();
            self.Root().GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.WelfareTask);
        }

        private static void UpdateNpcTaskUI(this DlgMain self)
        {
            List<Unit> allunit = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunit.Count; i++)
            {
                Unit unit = allunit[i];
                if (unit.InstanceId == 0 || unit.IsDisposed)
                {
                    continue;
                }

                if (unit.Type != UnitType.Npc)
                {
                    continue;
                }

                // if (unit.GetComponent<NpcHeadBarComponent>() != null)
                // {
                //     unit.GetComponent<NpcHeadBarComponent>().OnRecvTaskUpdate();
                // }
            }
        }

        private static void OnLeftTypeSet(this DlgMain self, int index)
        {
            switch (index)
            {
                case 0:
                    self.View.EG_MainTaskRectTransform.gameObject.SetActive(true);
                    self.View.EG_MainTeamRectTransform.gameObject.SetActive(false);
                    break;
                case 1:
                    self.View.EG_MainTaskRectTransform.gameObject.SetActive(false);
                    self.View.EG_MainTeamRectTransform.gameObject.SetActive(true);
                    break;
            }
        }

        private static void OnMainTaskItemsRefresh(this DlgMain self, Transform transform, int index)
        {
            Scroll_Item_MainTask scrollItemMainTask = self.ScrollItemMainTasks[index].BindTrans(transform);
            scrollItemMainTask.Refresh(self.ShowTaskPros[index]);
        }

        public static void RefreshMainTaskItems(this DlgMain self)
        {
            self.ShowTaskPros.Clear();
            foreach (TaskPro taskPro in self.Root().GetComponent<TaskComponentC>().RoleTaskList)
            {
                if (taskPro.TrackStatus == 0)
                {
                    continue;
                }

                self.ShowTaskPros.Add(taskPro);
            }

            self.View.E_RoseTaskButton.gameObject.SetActive(self.ShowTaskPros.Count == 0);

            self.AddUIScrollItems(ref self.ScrollItemMainTasks, self.ShowTaskPros.Count);
            self.View.E_MainTaskItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTaskPros.Count);
        }

        private static void OnOpenTask(this DlgMain self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();

            int nextTask = taskComponent.GetNextMainTask();
            if (nextTask == 0)
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task).Coroutine();
                return;
            }

            int getNpc = TaskConfigCategory.Instance.Get(nextTask).GetNpcID;
            int fubenId = TaskViewHelp.GetFubenByNpc(getNpc);
            if (fubenId == 0)
            {
                return;
            }

            string fubenName = $"请前往{DungeonConfigCategory.Instance.Get(fubenId).ChapterName} {NpcConfigCategory.Instance.Get(getNpc).Name} 出接取任务";
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.SceneType != SceneTypeEnum.LocalDungeon)
            {
                FlyTipComponent.Instance.ShowFlyTipDi(fubenName);
                return;
            }

            int curdungeonid = mapComponent.SceneId;
            if (curdungeonid == fubenId)
            {
                TaskViewHelp.MoveToNpc(self.Root(), getNpc).Coroutine();
                return;
            }

            if (TaskViewHelp.GeToOtherFuben(self.Root(), fubenId, mapComponent.SceneId))
            {
                return;
            }

            FlyTipComponent.Instance.ShowFlyTipDi(fubenName);
        }

        private static void OnMainTeamItemsRefresh(this DlgMain self, Transform transform, int index)
        {
            Scroll_Item_MainTeamItem scrollItemMainTeamItem = self.ScrollItemMainTeamItems[index].BindTrans(transform);
            // scrollItemMainTeamItem.Refresh(self.ShowTaskPros[index]);
        }

        public static void RefreshMainTeamItems(this DlgMain self)
        {
        }

        public static void OnUpdateDamage(this DlgMain self, M2C_SyncMiJingDamage message)
        {
            // for (int i = 0; i < message.DamageList.Count; i++)
            // {
            //     UIMainTeamItemComponent uIMainTeamItemComponent = self.TeamUIList[i];
            //     uIMainTeamItemComponent.OnUpdateDamage(message.DamageList[i]);
            // }
        }

        public static void OnBtn_RoseTeam(this DlgMain self)
        {
            // TeamInfo teamInfo = self.Root().GetComponent<TeamComponent>().GetSelfTeam();
            // if (teamInfo == null || teamInfo.PlayerList.Count == 0)
            // {
            //     FloatTipManager.Instance.ShowFloatTip("没有队伍！");
            //     return;
            // }
            //
            // UIHelper.Create(self.DomainScene(), UIType.UITeam).Coroutine();
        }

        private static void OnRoseTaskButton(this DlgMain self)
        {
            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();

            int nextTask = taskComponent.GetNextMainTask();
            if (nextTask == 0)
            {
                self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Task);
                return;
            }

            int getNpc = TaskConfigCategory.Instance.Get(nextTask).GetNpcID;
            int fubenId = TaskViewHelp.GetFubenByNpc(getNpc);
            if (fubenId == 0)
            {
                return;
            }

            string fubenName = $"请前往{DungeonConfigCategory.Instance.Get(fubenId).ChapterName} {NpcConfigCategory.Instance.Get(getNpc).Name} 出接取任务";
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            if (mapComponent.SceneType != SceneTypeEnum.LocalDungeon)
            {
                flyTipComponent.ShowFlyTipDi(fubenName);
                return;
            }

            int curdungeonid = mapComponent.SceneId;
            if (curdungeonid == fubenId)
            {
                TaskViewHelp.MoveToNpc(self.Root(), getNpc).Coroutine();
                return;
            }

            if (TaskViewHelp.GeToOtherFuben(self.Root(), fubenId, mapComponent.SceneId))
            {
                return;
            }

            flyTipComponent.ShowFlyTipDi(fubenName);
        }

        #endregion

        #region 左下角

        private static void OnShrinkButton(this DlgMain self)
        {
            bool isShow = !self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf;
            self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(isShow);
        }

        private static async ETTask OnRoseEquipButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role);
        }

        private static async ETTask OnPetButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Pet);
        }

        private static async ETTask OnRoseSkillButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Skill);
        }

        private static async ETTask OnTaskButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task);
        }

        private static void OnFriendButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Friend);
        }

        private static void OnChengJiuButton(this DlgMain self)
        {
            //self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_ChengJiu);

            self.Root().RemoveComponent<ClientSenderCompnent>();
        }

        #endregion

        #region 右下角

        private static void OnAdventureButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Dungeon);
        }

        private static void OnPetFormationButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_PetSet);
        }

        private static void OnCityHorseButton(this DlgMain self, bool showtip)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int now_horse = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseRide);
            if (now_horse == 0 && !self.Root().GetComponent<BattleMessageComponent>().IsCanRideHorse())
            {
                FlyTipComponent.Instance.ShowFlyTipDi("战斗状态不能骑马!");
                return;
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (SceneConfigHelper.UseSceneConfig(mapComponent.SceneType))
            {
                int sceneid = mapComponent.SceneId;
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
                if (sceneConfig.IfMount == 1)
                {
                    if (showtip)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi("该场景不能骑马!");
                    }

                    return;
                }
            }

            UserInfoNetHelper.HorseRideRequest(self.Root()).Coroutine();
        }

        private static void OnTeamDungeonButton(this DlgMain self)
        {
            Log.Debug("组队副本！！！");
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamDungeon).Coroutine();
        }

        public static void OnJiaYuanButton(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            self.Root().GetComponent<JiaYuanComponent>().MasterId = userInfoComponent.UserInfo.UserId;
            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.JiaYuan, 2000011, 1, userInfoComponent.UserInfo.UserId.ToString()).Coroutine();
        }

        private static void OnNpcDuiHuaButton(this DlgMain self)
        {
            DuiHuaHelper.MoveToNpcDialog(self.Root());
        }

        private static void OnUnionButton(this DlgMain self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.Union, 2000009).Coroutine();
        }

        private static void UpdateShowRoleExp(this DlgMain self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (!ExpConfigCategory.Instance.Contain(userInfo.Lv))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("非法修改数据！");
                return;
            }

            self.View.E_ExpValueText.text = userInfo.Exp + "/" + ExpConfigCategory.Instance.Get(userInfo.Lv).UpExp;
            self.View.E_ExpProImage.fillAmount = (float)userInfo.Exp / (float)ExpConfigCategory.Instance.Get(userInfo.Lv).UpExp;
        }

        #endregion

        #region 聊天

        private static void OnOpenChat(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Chat).Coroutine();
        }

        public static void OnRecvChat(this DlgMain self)
        {
            self.RefreshMainChatItems();
        }

        private static void OnMainChatItemsRefresh(this DlgMain self, Transform transform, int index)
        {
            Scroll_Item_MainChatItem scrollItemMainChatItem = self.ScrollItemMainChatItems[index].BindTrans(transform);
            scrollItemMainChatItem.Refresh(self.ShowChatInfos[index]);
        }

        private static void RefreshMainChatItems(this DlgMain self)
        {
            ChatComponent chatComponent = self.Root().GetComponent<ChatComponent>();
            self.ShowChatInfos.Insert(0, chatComponent.LastChatInfo);

            self.AddUIScrollItems(ref self.ScrollItemMainChatItems, self.ShowChatInfos.Count);
            self.View.E_MainChatItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChatInfos.Count);
            self.UpdatePosition().Coroutine();
        }

        private static async ETTask UpdatePosition(this DlgMain self)
        {
            long instanceid = self.InstanceId;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(100);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            foreach (Scroll_Item_MainChatItem scrollItemMainChatItem in self.ScrollItemMainChatItems.Values)
            {
                if (scrollItemMainChatItem == null)
                {
                    continue;
                }

                if (scrollItemMainChatItem.uiTransform == null)
                {
                    continue;
                }

                scrollItemMainChatItem.UpdateHeight();
            }

            await timerComponent.WaitAsync(100);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            // 无效。。。
            self.View.E_MainChatItemsLoopVerticalScrollRect.verticalNormalizedPosition = 0f;
        }

        #endregion

        # region 右上角按钮

        private static void OnButtonZhanKai(this DlgMain self)
        {
            bool active = self.View.EG_Btn_TopRight_1RectTransform.gameObject.activeSelf;
            self.View.EG_Btn_TopRight_1RectTransform.gameObject.SetActive(!active);
            self.View.EG_Btn_TopRight_2RectTransform.gameObject.SetActive(!active);
            self.View.EG_Btn_TopRight_3RectTransform.gameObject.SetActive(!active);

            self.View.E_Button_ZhanKaiButton.transform.localScale = active? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
        }

        private static void OnButton_RunRace(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RunRace).Coroutine();
        }

        private static void OnButton_Happy(this DlgMain self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.Happy, BattleHelper.GetSceneIdByType(SceneTypeEnum.Happy)).Coroutine();
        }

        private static void OnButton_Hunt(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Hunt).Coroutine();
        }

        private static void OnButton_Solo(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Solo).Coroutine();
        }

        private static void OnButton_Battle(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Battle).Coroutine();
        }

        private static void OnButton_Donation(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Donation).Coroutine();
        }

        private static void OnButton_FenXiang(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_FenXiang).Coroutine();
        }

        private static void OnButton_EveryTask(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Country).Coroutine();
        }

        private static void OnButton_Recharge(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
        }

        private static void OnButton_HuoDong(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Activity).Coroutine();
        }

        private static void OnButton_Season(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Season).Coroutine();
        }

        private static void OnButton_PaiMaiAuction(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PaiMaiAuction).Coroutine();
        }

        private static void OnButton_HongBao(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_HongBao).Coroutine();
        }

        private static void OnButton_ZhanQu(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ZhanQu).Coroutine();
        }

        private static void OnButton_NewYear(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_NewYear).Coroutine();
        }

        private static void OnButton_RechargeReward(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RechargeReward).Coroutine();
        }

        public static void CheckRechargeRewardButton(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            bool showButton = false;
            foreach (var item in ConfigData.RechargeReward)
            {
                if (!userInfoComponent.UserInfo.RechargeReward.Contains(item.Key))
                {
                    showButton = true;
                    break;
                }
            }

            self.View.E_Button_RechargeRewardButton.gameObject.SetActive(showButton);
        }

        private static void OnButton_Welfare(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Welfare).Coroutine();
        }

        private static void OnBtn_GM(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GM).Coroutine();
        }

        public static void OnBtn_Rank(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Rank).Coroutine();
        }

        private static void OnButton_WorldLv(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WorldLv).Coroutine();
        }

        private static void OnBtn_PaiMaiHang(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PaiMai).Coroutine();
        }

        public static void UpdateKillMonsterReward(this DlgMain self)
        {
            if (self.MainUnit == null)
            {
                return;
            }

            NumericComponentC numericComponent = self.MainUnit.GetComponent<NumericComponentC>();
            int oldNum = numericComponent.GetAsInt(NumericType.KillMonsterReward);
            int newNum = int.MaxValue;
            bool flag = false;
            foreach (int key in ConfigData.KillMonsterReward.Keys)
            {
                if (key > oldNum)
                {
                    newNum = Math.Min(key, newNum);
                    flag = true;
                }
            }

            if (flag)
            {
                self.KillMonsterRewardKey = newNum;

                string[] occItems = ConfigData.KillMonsterReward[self.KillMonsterRewardKey].Split('&');
                string[] items;
                if (occItems.Length == 3)
                {
                    UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                    items = occItems[userInfoComponent.UserInfo.Occ - 1].Split('@');
                }
                else
                {
                    items = occItems[0].Split('@');
                }

                string[] item = items[0].Split(';');

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(item[0]));
                ReferenceCollector rc = self.View.EG_Btn_KillMonsterRewardRectTransform.GetComponent<ReferenceCollector>();

                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                rc.Get<GameObject>("Image_ItemIcon").GetComponent<Image>().sprite = sp;

                string qualityiconStr = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
                string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
                Sprite sp1 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);

                rc.Get<GameObject>("Image_ItemQuality").GetComponent<Image>().sprite = sp1;
                rc.Get<GameObject>("Label_ItemNum").GetComponent<Text>().text = item[1];

                string color = "FFFFFF";
                if (numericComponent.GetAsInt(NumericType.KillMonsterNumber) >= newNum)
                {
                    color = "C4FF00";
                }

                rc.Get<GameObject>("LvText (1)").GetComponent<Text>().text = $"<color=#{color}>击败怪物</color>";
                rc.Get<GameObject>("LvText").GetComponent<Text>().text =
                        $"<color=#{color}>{numericComponent.GetAsInt(NumericType.KillMonsterNumber)}/{newNum}</color>";
                self.View.EG_Btn_KillMonsterRewardRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.View.EG_Btn_KillMonsterRewardRectTransform.gameObject.SetActive(false);
            }
        }

        private static async ETTask OnBtn_KillMonsterReward(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            NumericComponentC numericComponent = self.MainUnit.GetComponent<NumericComponentC>();
            string[] occItems = ConfigData.KillMonsterReward[self.KillMonsterRewardKey].Split('&');
            string[] items;
            if (occItems.Length == 3)
            {
                items = occItems[userInfoComponent.UserInfo.Occ - 1].Split('@');
            }
            else
            {
                items = occItems[0].Split('@');
            }

            string[] item = items[0].Split(';');
            if (numericComponent.GetAsInt(NumericType.KillMonsterNumber) < self.KillMonsterRewardKey)
            {
                ShowItemTips showItemTips = new()
                {
                    BagInfo = new BagInfo() { ItemID = int.Parse(item[0]), ItemNum = int.Parse(item[1]) },
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new()
                };
                EventSystem.Instance.Publish(self.Root(), showItemTips);
            }
            else
            {
                if (items.Length > 1)
                {
                    await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SelectReward);
                    self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSelectReward>().UpdateInfo(self.KillMonsterRewardKey, 1);
                }
                else
                {
                    // 一个道具直接领取
                    await ActivityNetHelper.KillMonsterRewardRequest(self.Root(), self.KillMonsterRewardKey, 0);

                    if (!self.IsDisposed)
                    {
                        self.UpdateKillMonsterReward();
                    }
                }
            }
        }

        public static void UpdateLvReward(this DlgMain self)
        {
            NumericComponentC numericComponent = self.MainUnit.GetComponent<NumericComponentC>();
            int oldLv = numericComponent.GetAsInt(NumericType.LeavlReward);

            int newLv = int.MaxValue;
            bool flag = false;
            foreach (int key in ConfigData.LeavlRewardItem.Keys)
            {
                if (key > oldLv)
                {
                    newLv = Math.Min(key, newLv);
                    flag = true;
                }
            }

            if (flag)
            {
                self.LevelRewardKey = newLv;

                string[] occItems = ConfigData.LeavlRewardItem[self.LevelRewardKey].Split('&');
                string[] items;
                UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
                if (occItems.Length == 3)
                {
                    items = occItems[userInfoComponent.UserInfo.Occ - 1].Split('@');
                }
                else
                {
                    items = occItems[0].Split('@');
                }

                string[] item = items[0].Split(';');

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(item[0]));
                ReferenceCollector rc = self.View.EG_Btn_LvRewardRectTransform.GetComponent<ReferenceCollector>();

                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                rc.Get<GameObject>("Image_ItemIcon").GetComponent<Image>().sprite = sp;

                string qualityiconStr = FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality);
                string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
                Sprite sp1 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);

                rc.Get<GameObject>("Image_ItemQuality").GetComponent<Image>().sprite = sp1;

                rc.Get<GameObject>("Label_ItemNum").GetComponent<Text>().text = item[1];

                string color = "FFFFFF";
                if (userInfoComponent.UserInfo.Lv >= newLv)
                {
                    color = "C4FF00";
                }

                rc.Get<GameObject>("LvText (1)").GetComponent<Text>().text = $"<color=#{color}>等级奖励</color>";
                rc.Get<GameObject>("LvText").GetComponent<Text>().text = $"<color=#{color}>{newLv}级领取</color>";
                self.View.EG_Btn_LvRewardRectTransform.gameObject.SetActive(true);
            }
            else
            {
                self.View.EG_Btn_LvRewardRectTransform.gameObject.SetActive(false);
            }
        }

        private static async ETTask OnBtn_LvReward(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string[] occItems = ConfigData.LeavlRewardItem[self.LevelRewardKey].Split('&');
            string[] items;
            if (occItems.Length == 3)
            {
                items = occItems[userInfoComponent.UserInfo.Occ - 1].Split('@');
            }
            else
            {
                items = occItems[0].Split('@');
            }

            string[] item = items[0].Split(';');
            if (userInfoComponent.UserInfo.Lv < self.LevelRewardKey)
            {
                ShowItemTips showItemTips = new()
                {
                    BagInfo = new BagInfo() { ItemID = int.Parse(item[0]), ItemNum = int.Parse(item[1]) },
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new()
                };
                EventSystem.Instance.Publish(self.Root(), showItemTips);
            }
            else
            {
                if (items.Length > 1)
                {
                    await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SelectReward);
                    self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSelectReward>().UpdateInfo(self.LevelRewardKey, 0);
                }
                else
                {
                    // 一个道具直接领取
                    await ActivityNetHelper.LeavlRewardRequest(self.Root(), self.LevelRewardKey, 0);
                    self.UpdateLvReward();
                }
            }
        }

        private static void OnMailHintTip(this DlgMain self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.SceneType != (int)SceneTypeEnum.MainCityScene)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("请前往主城!");
                return;
            }

            self.Root().CurrentScene().GetComponent<OperaComponent>().OnClickNpc(20000006).Coroutine();
        }

        private static async ETTask OnBtn_MapTransfer(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DungeonMapTransfer);
            DlgDungeonMapTransfer dlgDungeonMapTransfer = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDungeonMapTransfer>();
        }

        public static void OnBtn_RerurnDungeon(this DlgMain self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "返回副本", GameSettingLanguge.LoadLocalization("移动次数消耗完毕,请返回副本!"),
                () =>
                {
                    int sceneid = self.Root().GetComponent<BattleMessageComponent>().LastDungeonId;
                    if (sceneid == 0)
                    {
                        EnterMapHelper.RequestQuitFuben(self.Root());
                    }
                    else
                    {
                        EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.LocalDungeon, sceneid, 0, "0").Coroutine();
                    }
                },
                null).Coroutine();
        }

        private static void OnClickReturnButton(this DlgMain self)
        {
            Scene zoneScene = self.Root();
            MapComponent mapComponent = zoneScene.GetComponent<MapComponent>();

            DlgTowerOpen dlgTowerOpen = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTowerOpen>();
            if (dlgTowerOpen != null && dlgTowerOpen.M2C_FubenSettlement == null)
            {
                dlgTowerOpen.RequestTowerQuit();
                return;
            }

            string tipStr = "确定返回主城？";
            if (mapComponent.SceneType == SceneTypeEnum.Battle)
            {
                tipStr = "现在离开战场,将不会获得战场胜利的奖励哦";
            }

            PopupTipHelp.OpenPopupTip(self.Root(), "", GameSettingLanguge.LoadLocalization(tipStr),
                () => { EnterMapHelper.RequestQuitFuben(self.Root()); },
                null).Coroutine();
        }

        #endregion

        public static void OnUpdateHP(this DlgMain self, int sceneType, Unit defend, Unit attack, long hurtvalue)
        {
            int unitType = defend.Type;
            if (unitType == UnitType.Player && sceneType == SceneTypeEnum.TeamDungeon)
            {
                // self.UIMainTeam.OnUpdateHP(defend);
            }

            if (unitType == UnitType.Monster)
            {
                self.View.ES_MainHpBar.OnUpdateHP(defend);
                self.View.ES_MainHpBar.OnUpdateHP(defend, attack, hurtvalue);
            }

            if (unitType == UnitType.Pet)
            {
                self.View.ES_RoleHead.OnUpdatePetHP(defend);
            }
        }

        public static void BeginEnterScene(this DlgMain self, int lastScene)
        {
            Log.Debug("BeginEnterScene");

            // self.View.ES_MainTeam.ResetUI();
            self.View.ES_MainSkill.ResetUI();
            self.View.ES_MainBuff.ResetUI();
            self.View.ES_JoystickMove.ResetUI();

            self.View.ES_MapMini.BeginChangeScene(lastScene);
            self.View.ES_Singing.uiTransform.gameObject.SetActive(false);
            self.View.ES_MainHpBar.BeginEnterScene();
            self.Root().GetComponent<SkillIndicatorComponent>().BeginEnterScene();
            self.Root().GetComponent<LockTargetComponent>().BeginEnterScene();
            self.Root().GetComponent<BattleMessageComponent>().CancelRideTargetUnit(0);
            self.Root().GetComponent<BattleMessageComponent>().AttackSelfPlayer.Clear();
            // self.Root().RemoveComponent<UnitGuaJiComponen>();
        }

        /// <summary>
        /// 返回myunit 并且场景加载完成 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="sceneTypeEnum"></param>
        public static void AfterEnterScene(this DlgMain self, int sceneTypeEnum)
        {
            bool zhankai = self.View.E_Button_ZhanKaiButton.transform.localScale == new Vector3(-1f, 1f, 1f);
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());

            self.View.EG_Btn_TopRight_1RectTransform.gameObject.SetActive(zhankai && SceneConfigHelper.ShowRightTopButton(sceneTypeEnum));
            self.View.EG_Btn_TopRight_2RectTransform.gameObject.SetActive(zhankai && SceneConfigHelper.ShowRightTopButton(sceneTypeEnum));
            self.View.E_Btn_RerurnBuildingButton.gameObject.SetActive(sceneTypeEnum != SceneTypeEnum.MainCityScene &&
                sceneTypeEnum != SceneTypeEnum.JiaYuan);
            self.View.E_E_Btn_MapTransferButton.gameObject.SetActive(sceneTypeEnum == SceneTypeEnum.LocalDungeon);
            // self.LevelGuideMini.SetActive(sceneTypeEnum == SceneTypeEnum.CellDungeon);
            self.View.E_NpcDuiHuaButton.gameObject.SetActive(sceneTypeEnum == SceneTypeEnum.MainCityScene);
            self.View.E_ShrinkButton.gameObject.SetActive(sceneTypeEnum != SceneTypeEnum.RunRace && sceneTypeEnum != SceneTypeEnum.Demon);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string value = userInfoComponent.GetGameSettingValue(GameSettingEnum.HideLeftBottom);
            if (value == "1")
            {
                self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(sceneTypeEnum == SceneTypeEnum.MainCityScene);
            }
            else
            {
                self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf &&
                    sceneTypeEnum != SceneTypeEnum.RunRace && sceneTypeEnum != SceneTypeEnum.Demon);
            }

            self.View.ES_JoystickMove.AfterEnterScene();

            if (!SceneConfigHelper.ShowLeftButton(sceneTypeEnum))
            {
                self.View.E_LeftTypeSetToggleGroup.gameObject.SetActive(false);
                // self.OnClickPageButton(-1);
            }
            else
            {
                self.View.E_LeftTypeSetToggleGroup.gameObject.SetActive(true);
                self.View.E_LeftTypeSetToggleGroup.OnSelectIndex(sceneTypeEnum == SceneTypeEnum.TeamDungeon? 1 : 0);
            }

            int sceneid = self.Root().GetComponent<MapComponent>().SceneId;
            switch (sceneTypeEnum)
            {
                case SceneTypeEnum.CellDungeon:
                    // self.UILevelGuideMini.GetComponent<UICellDungeonCellMiniComponent>().OnUpdateUI();
                    break;
                case SceneTypeEnum.MainCityScene:
                    self.View.ES_MainHpBar.EG_MonsterNodeRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainHpBar.EG_BossNodeRectTransform.gameObject.SetActive(false);
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(true);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(false);
                    self.View.E_MainTaskItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                    self.View.E_LeftTypeSetToggleGroup.gameObject.SetActive(true);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                    break;
                case SceneTypeEnum.Happy:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(false);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(false);
                    break;
                case SceneTypeEnum.RunRace:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    break;
                case SceneTypeEnum.Demon:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    break;
                case SceneTypeEnum.JiaYuan:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(false);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                    break;
                // case SceneTypeEnum.TowerOfSeal:
                //     self.UIMainTask.GameObject.SetActive(false);
                //     self.FunctionSetBtn.SetActive(false);
                //     self.HomeButton.SetActive(false);
                //     self.UIMainSkill.SetActive(true);
                //     self.UIJoystickMoveComponent.GameObject.SetActive(true);
                //     break;
                case SceneTypeEnum.LocalDungeon:
                    DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(sceneid);
                    switch (dungeonConfig.MapType)
                    {
                        case SceneSubTypeEnum.LocalDungeon_1:
                            self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                            self.View.ES_MainSkill.uiTransform.gameObject.SetActive(false);
                            self.View.EG_Btn_TopRight_1RectTransform.gameObject.SetActive(false);
                            self.View.EG_Btn_TopRight_2RectTransform.gameObject.SetActive(false);
                            self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(false);
                            break;
                        default:
                            self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                            self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                            self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                            break;
                    }

                    break;
                default:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                    break;
            }

            // self.OnHorseRide();
            self.UpdateShadow();
            self.UpdateNpcTaskUI();
            self.View.ES_MapMini.OnEnterScene();
            self.View.ES_MainSkill.OnEnterScene(self.MainUnit, sceneTypeEnum);
            self.View.ES_MainSkill.OnSkillSetUpdate();
            self.View.ES_RoleHead.OnEnterScene(sceneTypeEnum);
            // self.ZoneScene().GetComponent<RelinkComponent>().OnApplicationFocusHandler(true);

            self.View.E_UnionButton.gameObject.SetActive(self.MainUnit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0) > 0);
            if (sceneTypeEnum == SceneTypeEnum.LocalDungeon)
            {
                // self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.EnterFuben, sceneid.ToString());
                bool shenmizhimen =
                        DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(self.Root().GetComponent<MapComponent>().SceneId);
                self.View.E_Btn_RerurnDungeonButton.gameObject.SetActive(shenmizhimen);
                self.View.E_E_Btn_MapTransferButton.gameObject.SetActive(!shenmizhimen);
                self.View.E_Btn_RerurnBuildingButton.gameObject.SetActive(!shenmizhimen);
            }

            if (!self.View.ES_JoystickMove.uiTransform.gameObject.activeSelf
                || sceneTypeEnum == SceneTypeEnum.PetDungeon
                || sceneTypeEnum == SceneTypeEnum.PetTianTi
                || sceneTypeEnum == SceneTypeEnum.PetMing)
            {
                self.MainUnit.GetComponent<StateComponentC>().StateTypeAdd(StateTypeEnum.NoMove);
            }

            self.Root().RemoveComponent<UnitGuaJiComponent>();
            self.View.EG_GuaJiSetRectTransform.gameObject.SetActive(false);

            self.UpdateLvReward();
            self.UpdateKillMonsterReward();

            self.CheckMailReddot().Coroutine();
        }

        public static void OnUpdateUserData(this DlgMain self, string updateType)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int userDataType = int.Parse(updateType.Split('_')[0]);

            string updateValue = updateType.Split('_')[1];

            switch (userDataType)
            {
                case UserDataType.Exp:
                    self.View.ES_RoleHead.UpdateShowRoleExp();
                    self.UpdateShowRoleExp();
                    break;
                case UserDataType.PiLao:
                    self.View.ES_RoleHead.UpdateShowRolePiLao();
                    break;
                case UserDataType.Lv:
                    self.UpdateShowRoleExp();
                    self.View.ES_RoleHead.UpdateShowRoleExp();
                    // self.CheckFuntionButtonByLv(int.Parse(updateValue));
                    FunctionEffect.PlaySelfEffect(self.MainUnit, 60000002);
                    // self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.LevelUp, userInfo.Lv.ToString());
                    FlyTipComponent.Instance.ShowFlyTipDi(GameSettingLanguge.LoadLocalization("恭喜你!等级提升至:") + userInfo.Lv);
                    self.UpdateLvReward();
                    // self.CheckCanEquip().Coroutine();
                    // if (int.Parse(updateValue) > 30)
                    // {
                    //     self.UpdateTaskList().Coroutine();
                    // }

                    break;
                case UserDataType.Name:
                    self.View.ES_RoleHead.UpdateShowRoleName();
                    break;
                case UserDataType.Vitality:
                    self.View.ES_RoleHead.UpdateShowRoleHuoLi();
                    break;

                case UserDataType.UnionContri:
                    // if (UIHelper.GetUI(self.ZoneScene(), UIType.UITreasureOpen) != null)
                    // {
                    //     return;
                    // }
                    //
                    // if (int.Parse(updateValue) > 0)
                    // {
                    //     FloatTipManager.Instance.ShowFloatTip($"获得{updateValue} 家族捐献");
                    // }
                    //
                    // if (int.Parse(updateValue) < 0)
                    // {
                    //     FloatTipManager.Instance.ShowFloatTip($"消耗{int.Parse(updateValue) * -1} 家族捐献");
                    // }

                    break;

                case UserDataType.Gold:
                    // if (UIHelper.GetUI(self.ZoneScene(), UIType.UITreasureOpen) != null)
                    // {
                    //     return;
                    // }
                    //
                    // if (int.Parse(updateValue) > 0)
                    // {
                    //     FloatTipManager.Instance.ShowFloatTip($"获得{updateValue} 金币");
                    // }
                    //
                    // if (int.Parse(updateValue) < 0)
                    // {
                    //     FloatTipManager.Instance.ShowFloatTip($"消耗{int.Parse(updateValue) * -1} 金币");
                    // }

                    break;
                case UserDataType.WeiJingGold:
                    if (int.Parse(updateValue) > 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi($"获得{updateValue} 兑换币");
                    }

                    if (int.Parse(updateValue) < 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi($"消耗{int.Parse(updateValue) * -1} 兑换币");
                    }

                    break;
                case UserDataType.RongYu:
                    if (int.Parse(updateValue) > 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi($"获得{updateValue} 荣誉");
                    }

                    if (int.Parse(updateValue) < 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi($"消耗{int.Parse(updateValue) * -1} 荣誉");
                    }

                    break;
                case UserDataType.JiaYuanFund:
                    if (int.Parse(updateValue) > 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi($"获得{updateValue} 家园资金");
                    }

                    break;
                case UserDataType.BaoShiDu:
                    if (int.Parse(updateValue) > 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi($"获得{updateValue} 饱食度");
                    }

                    break;

                case UserDataType.Combat:
                    self.View.ES_RoleHead.OnUpdateCombat();

                    break;
                case UserDataType.Sp:
                    ReddotComponentC reddotComponent = self.Root().GetComponent<ReddotComponentC>();
                    reddotComponent.UpdateReddont(ReddotType.SkillUp);
                    break;
                case UserDataType.Message:
                    PopupTipHelp.OpenPopupTip_2(self.Root(), "系统消息", updateValue, null).Coroutine();
                    break;
                case UserDataType.PullBack:
                    FlyTipComponent.Instance.ShowFlyTipDi("所有人不要乱跑哦");
                    FunctionEffect.PlaySelfEffect(self.MainUnit, 30000002);
                    break;
                default:
                    break;
            }
        }

        private static async ETTask CheckMailReddot(this DlgMain self)
        {
            if (!self.View.E_MailHintTipButton.gameObject.activeSelf)
            {
                return;
            }

            E2C_GetAllMailResponse response = await MailNetHelper.SendGetMailList(self.Root());
            if (response.MailInfos.Count == 0)
            {
                self.View.E_MailHintTipButton.gameObject.SetActive(false);
            }
        }

        public static void SetFenBianLv1(this DlgMain self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            Screen.SetResolution(uiComponent.ResolutionWidth, uiComponent.ResolutionHeight, true);
        }

        public static void SetFenBianLv2(this DlgMain self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            Screen.SetResolution((int)(uiComponent.ResolutionWidth * 0.8f), (int)(uiComponent.ResolutionHeight * 0.8f), true);
        }

        public static void UpdateShadow(this DlgMain self, string usevalue = "")
        {
            GameObject gameObject = GameObject.Find("Directional Light");
            if (gameObject == null)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string value = usevalue != ""? usevalue : userInfoComponent.GetGameSettingValue(GameSettingEnum.Shadow);
            Light light = gameObject.GetComponent<Light>();
            light.shadows = value == "0"? LightShadows.None : LightShadows.Soft;
        }

        public static void ShowPing(this DlgMain self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            if (self.View.EG_FpsRectTransform.gameObject.activeSelf)
            {
                self.View.EG_FpsRectTransform.gameObject.SetActive(false);
                // OpcodeHelper.ShowMessage = false;
                timerComponent.Remove(ref self.TimerPing);
            }
            else
            {
                self.View.EG_FpsRectTransform.gameObject.SetActive(true);
                // self.TextMessage.text = string.Empty;
                // OpcodeHelper.ShowMessage = true;
                // OpcodeHelper.OneTotalNumber = 0;
                timerComponent.Remove(ref self.TimerPing);
                self.TimerPing = timerComponent.NewRepeatedTimer(5000, TimerInvokeType.UIMainFPSTimer, self);
            }
        }

        public static void UpdatePing(this DlgMain self)
        {
            // SessionComponent sessionComponent = self.Root()?.GetComponent<SessionComponent>();
            // if (sessionComponent == null || sessionComponent.Session == null)
            // {
            //     return;
            // }
            //
            // PingComponent pingComponent = sessionComponent.Session.GetComponent<PingComponent>();
            // if (pingComponent == null)
            // {
            //     return;
            // }
            //
            // long ping = pingComponent.Ping;
            // self.TextPing.text = StringBuilderHelper.GetPing(ping);
            // if (ping <= 200)
            // {
            //     self.TextPing.color = Color.green;
            //     return;
            // }
            //
            // if (ping <= 500)
            // {
            //     self.TextPing.color = Color.yellow;
            //     return;
            // }
            //
            // self.TextPing.color = Color.red;
        }

        public static void UpdateMessage(this DlgMain self)
        {
            // self.TextMessage.text = StringBuilderHelper.GetMessageCnt(OpcodeHelper.OneTotalNumber);
            // OpcodeHelper.OneTotalNumber = 0;
        }

        public static void OnStopGuaJi(this DlgMain self)
        {
            if (self.Root().GetComponent<UnitGuaJiComponent>() != null)
            {
                //移除挂机组件
                self.Root().RemoveComponent<UnitGuaJiComponent>();
                FlyTipComponent.Instance.ShowFlyTip("取消挂机!");
            }

            self.View.EG_GuaJiSetRectTransform.gameObject.SetActive(false);
        }

        public static void InitShow(this DlgMain self)
        {
            self.UpdateShowRoleExp();

            // Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            // self.ShowUIStall(unit.GetComponent<NumericComponent>().GetAsLong((int)NumericType.Now_Stall));
            // self.OnTianQiChange(self.ZoneScene().GetComponent<AccountInfoComponent>().TianQiValue);
        }

        public static void OnSettingUpdate(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int operatMode = int.Parse(userInfoComponent.GetGameSettingValue(GameSettingEnum.YanGan));
            self.View.ES_JoystickMove.UpdateOperateMode(operatMode);

            string oldValue = userInfoComponent.GetGameSettingValue(GameSettingEnum.Smooth);
            SettingHelper.OnSmooth(oldValue);

            oldValue = userInfoComponent.GetGameSettingValue(GameSettingEnum.NoShowOther);
            SettingHelper.OnShowOther(oldValue);

            string value = userInfoComponent.GetGameSettingValue(GameSettingEnum.AutoAttack);
            AttackComponent attackComponent = self.Root().GetComponent<AttackComponent>();
            attackComponent.AutoAttack = value == "1";
        }

        public static void OnSpellStart(this DlgMain self)
        {
            if (self.View.ES_OpenBox != null && self.View.ES_OpenBox.BoxUnitId > 0)
            {
                self.View.ES_OpenBox.OnOpenBox(null);
            }
        }

        public static void OnBeforeSkill(this DlgMain self)
        {
            self.View.ES_JoystickMove.lastSendTime = 0;
        }

        public static void OnStopAction(this DlgMain self)
        {
            self.View.ES_JoystickMove.ResetUI();
            self.OnMoveStart();
        }

        public static void OnBagItemUpdate(this DlgMain self)
        {
            self.View.ES_MainSkill.OnBagItemUpdate();

            // self.CheckCanEquip().Coroutine();
        }

        public static void OnRechageSucess(this DlgMain self, int addNumber)
        {
            FlyTipComponent.Instance.ShowFlyTipDi($"充值{addNumber}元成功");

            self.Root().GetComponent<PlayerComponent>().PlayerInfo.RechargeInfos.Add(new()
            {
                Amount = addNumber, Time = TimeHelper.ClientNow(), UnitId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId
            });
        }

        public static void ShowUIStall(this DlgMain self, long stallId)
        {
            // self.View.EG_UIStall.SetActive(stallId > 0);
        }

        public static void OnZeroClockUpdate(this DlgMain self)
        {
            self.InitFunctionButton();
        }

        public static void InitFunctionButton(this DlgMain self)
        {
            FlyTipComponent.Instance.ShowFlyTipDi("重新设置主界面功能按钮");
            // self.FunctionButtons.Clear();
            //
            // long serverTime = TimeHelper.ServerNow();
            // DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);
            // long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            // self.MainUnit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            //
            // //1058变身大赛 1055喜从天降 1052狩猎活动 1045竞技场    1062争霸捐献 1063开区奖励 1064活跃     1065商城 1066活动      
            // //1040拍卖特惠 1023红包活动 1067新年活动 1068萌新福利  1069分享     1016排行榜   1025战场活动 1070世界等级 1014拍卖行
            //
            // List<int> functonIds = new List<int>()
            // {
            //     1023,
            //     1025,
            //     1031,
            //     1040,
            //     1045,
            //     1052,
            //     1055,
            //     1057,
            //     1058,
            //     1059,
            //     1062,
            //     1063,
            //     1064,
            //     1065,
            //     1066,
            //     1067,
            //     1068,
            //     1069,
            //     1016,
            //     1070,
            //     1014,
            //     1071
            // };
            // for (int i = 0; i < functonIds.Count; i++)
            // {
            //     long startTime = FunctionHelp.GetOpenTime(functonIds[i]);
            //     long endTime = FunctionHelp.GetCloseTime(functonIds[i]) - 10;
            //
            //     if (functonIds[i] == 1025) //战场按钮延长30分钟消失
            //     {
            //         endTime += (30 * 60);
            //     }
            //
            //     if (functonIds[i] == 1052)
            //     {
            //         endTime += (10 * 60);
            //     }
            //
            //     if (curTime >= endTime)
            //     {
            //         continue;
            //     }
            //
            //     long sTime = serverTime + (startTime - curTime) * 1000;
            //     self.FunctionButtons.Add(new ActivityTimer()
            //     {
            //         FunctionId = functonIds[i], FunctionType = 1, BeginTime = sTime
            //     }); //FunctionType1 并且大于beingTime 开启
            //
            //     long eTime = serverTime + (endTime - curTime) * 1000;
            //     self.FunctionButtons.Add(new ActivityTimer()
            //     {
            //         FunctionId = functonIds[i], FunctionType = 0, BeginTime = eTime
            //     }); //FunctionType0 并且大于beingTime 关闭时间点
            // }
            //
            // TimerComponent.Instance.Remove(ref self.TimerFunctiuon);
            // if (self.FunctionButtons.Count > 0)
            // {
            //     self.FunctionButtons.Sort(delegate(ActivityTimer a, ActivityTimer b)
            //     {
            //         long endTime_1 = a.BeginTime;
            //         long endTime_2 = b.BeginTime;
            //         return (int)(endTime_1 - endTime_2);
            //     });
            //
            //     self.TimerFunctiuon = TimerComponent.Instance.NewOnceTimer(self.FunctionButtons[0].BeginTime, TimerType.UIMainTimer, self);
            // }
        }

        public static void OnHongBao(this DlgMain self, int value)
        {
            if (value == 1)
            {
                self.View.E_Button_HongBaoButton.gameObject.SetActive(false);
            }
        }

        public static void OnHorseRide(this DlgMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            // self.View.E_Button_Horse.SetActive(unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseFightID) > 0);
            self.View.E_CityHorseButton.gameObject.SetActive(unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseFightID) > 0);
        }
        
        public static  void OnCellDungeonEnterShow(this DlgMain self, int chapterId)
        {
            if (chapterId == 0)
                return;

            // var BaseObj = ResourcesComponent.Instance.LoadAsset<GameObject>(ABPathHelper.GetUGUIPath("CellDungeon/UICellDungeonEnterShow"));
            // UI uiskillButton = self.AddChild<UI, string, GameObject>("ChapterEnterShow", GameObject.Instantiate(BaseObj));
            // uiskillButton.AddComponent<UICellDungeonEnterShowComponent>().OnUpdateUI(chapterId);
            //
            // UICommonHelper.SetParent(uiskillButton.GameObject, UIEventComponent.Instance.UILayers[(int)UILayer.Mid].gameObject);
        }
    }
}