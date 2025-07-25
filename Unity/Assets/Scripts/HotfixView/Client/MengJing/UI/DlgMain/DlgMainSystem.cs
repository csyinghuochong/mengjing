using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ET.Client
{
    # region 注册的事件

    [Event(SceneType.Demo)]
    public class PetFightUpdate_DlgMainRefresh : AEvent<Scene, PetBarUpdate>
    {
        protected override async ETTask Run(Scene scene, PetBarUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.RefreshFightSet();
            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Demo)]
    public class PetFightPlan_DlgMainRefresh : AEvent<Scene, PetFightPlan>
    {
        protected override async ETTask Run(Scene scene, PetFightPlan args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.RefreshPetFightPlan();
            await ETTask.CompletedTask;
        }
    }
    

    [Event(SceneType.Demo)]
    public class DataUpdate_TeamUpdatet_DlgMainRefresh : AEvent<Scene, RecvTeamUpdate>
    {
        protected override async ETTask Run(Scene scene, RecvTeamUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnUpdateTeamUI();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TeamUpdatet_ZeroClock : AEvent<Scene, ZeroClock>
    {
        protected override async ETTask Run(Scene scene, ZeroClock args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnZeroClockUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class CommonHintErrorEvent : AEvent<Scene, CommonHintError>
    {
        protected override async ETTask Run(Scene root, CommonHintError args)
        {
            if (args.ErrorValue == ErrorCode.ERR_ModifyData)
            {
                root.GetComponent<RelinkComponent>()?.OnModifyData();
            }

            HintHelp.ShowErrorHint(root, args.ErrorValue);

            await ETTask.CompletedTask;
        }
    }

    [NumericWatcher(SceneType.Demo, NumericType.KillMonsterNumber)]
    public class NumericWatcher_KillMonsterNumber_UpdateDlgMain : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.UpdateKillMonsterReward();
        }
    }

    [NumericWatcher(SceneType.Demo, NumericType.BossBelongID)]
    public class NumericWatcher_BossBelongID_UpdateDlgMain : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainHpBar.OnUpdateBelongID(args.Defend.Id, args.NewValue);
        }
    }

    [NumericWatcher(SceneType.Demo, NumericType.UnionId_0)]
    public class NumericWatcher_UnionId_0_UpdateDlgMain : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (unit.MainHero)
            {
                //unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.E_UnionButton.gameObject.SetActive(args.NewValue > 0);
            }
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_OnPetFightSet_Refresh : AEvent<Scene, OnPetFightSet>
    {
        protected override async ETTask Run(Scene scene, OnPetFightSet args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_RoleHead.OnPetFightSet();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_BagItemUpdate_Refresh : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnBagItemUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class BuffUpdate_DlgMainRefresh : AEvent<Scene, BuffUpdate>
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
            else if (args.Unit.IsBoss())
            {
                dlgMain.View.ES_MainHpBar.ES_MainBuff.OnBuffUpdate(args.ABuffHandler, args.OperateType);
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillSetting_DlgMainRefresh : AEvent<Scene, SkillSetting>
    {
        protected override async ETTask Run(Scene scene, SkillSetting args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnSkillSetUpdate();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_UpdateUserData_Refresh : AEvent<Scene, UpdateUserData>
    {
        protected override async ETTask Run(Scene scene, UpdateUserData args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnUpdateUserData(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class UpdateUserDataExp_DlgMainRefresh : AEvent<Scene, UpdateUserDataExp>
    {
        protected override async ETTask Run(Scene scene, UpdateUserDataExp args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.UpdateShowRoleExp();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SettingUpdate_Refresh : AEvent<Scene, SettingUpdate>
    {
        protected override async ETTask Run(Scene scene, SettingUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnSettingUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskUpdate_Refresh : AEvent<Scene, TaskUpdate>
    {
        protected override async ETTask Run(Scene scene, TaskUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.RefreshMainTaskItems();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskTrace_Refresh : AEvent<Scene, TaskTrace>
    {
        protected override async ETTask Run(Scene scene, TaskTrace args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.RefreshMainTaskItems();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGet_DlgMainRefresh : AEvent<Scene, TaskGet>
    {
        protected override async ETTask Run(Scene scene, TaskGet args)
        {
            scene.GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.AcceptTask, args.TaskConfigId.ToString());
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskComplete_GetTreasure : AEvent<Scene, TaskComplete>
    {
        protected override async ETTask Run(Scene scene, TaskComplete args)
        {
            int taskid = args.TaskConfigId;
            // 完成藏宝图任务后自动接取藏宝图任务
            // if (TaskConfigCategory.Instance.Contain(taskid) && TaskConfigCategory.Instance.Get(taskid).TaskType == TaskTypeEnum.Treasure)
            // {
            //     // 任务公告板
            //     List<int> tasList = scene.GetComponent<TaskComponentC>().GetOpenTaskIds(1024);
            //     foreach (int id in tasList)
            //     {
            //         TaskConfig taskConfig = TaskConfigCategory.Instance.Get(id);
            //         if (taskConfig.TaskType == TaskTypeEnum.Treasure)
            //         {
            //             TaskClientNetHelper.RequestGetTask(scene, taskConfig.Id).Coroutine();
            //             break;
            //         }
            //     }
            // }
            //
            await scene.GetComponent<TimerComponent>().WaitAsync(200);
            scene.GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.CommitTask, taskid.ToString());
            
            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Demo)]
    public class DataUpdate_TaskComplete_DlgMainRefresh : AEvent<Scene, TaskComplete>
    {
        protected override async ETTask Run(Scene scene, TaskComplete args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_TaskGiveUp_DlgMainRefresh : AEvent<Scene, TaskGiveUp>
    {
        protected override async ETTask Run(Scene scene, TaskGiveUp args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvTaskUpdate();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_OnRecvChat_MainChatItemsRefresh : AEvent<Scene, OnRecvChat>
    {
        protected override async ETTask Run(Scene root, OnRecvChat args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnRecvChat();
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_BeforeMove_DlgMainRefresh : AEvent<Scene, BeforeMove>
    {
        protected override async ETTask Run(Scene root, BeforeMove args)
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
    public class DataUpdate_UpdateSing_DlgMainRefresh : AEvent<Scene, UpdateSing>
    {
        protected override async ETTask Run(Scene root, UpdateSing args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainHpBar.OnUpdateSing(args.DataParamString);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class SingingUpdate_DlgMainRefresh : AEvent<Scene, SingingUpdate>
    {
        protected override async ETTask Run(Scene root, SingingUpdate args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_Singing.OnTimer(args);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class BeforeSkill_DlgMainRefresh : AEvent<Scene, BeforeSkill>
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
    public class DataUpdate_SkillCDUpdate_DlgMainRefresh : AEvent<Scene, SkillCDUpdate>
    {
        protected override async ETTask Run(Scene root, SkillCDUpdate args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnSkillCDUpdate();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillBeging_DlgMainRefresh : AEvent<Scene, SkillBeging>
    {
        protected override async ETTask Run(Scene root, SkillBeging args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnSkillBeging(args.DataParamString);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_SkillFinish_DlgMainRefresh : AEvent<Scene, SkillFinish>
    {
        protected override async ETTask Run(Scene root, SkillFinish args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnSkillFinish(args.DataParamString);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class DataUpdate_JingLingButton_DlgMainRefresh : AEvent<Scene, JingLingButton>
    {
        protected override async ETTask Run(Scene root, JingLingButton args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.CheckJingLingFunction();

            await ETTask.CompletedTask;
        }
    }
    
    [NumericWatcher(SceneType.Current, NumericType.SealTowerArrived)]
    public class NumericWatcher_SealTowerArrived_UpdateDlgMain : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            unit.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MapMini.UpdateMapName();
        }
    }

    # endregion

    [Invoke(TimerInvokeType.UIMainFPSTimer)]
    public class UIMainFPSTimer : ATimer<DlgMain>
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
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [Invoke(TimerInvokeType.MainPetSwitchTimer)]
    public class MainPetSwitchTimer : ATimer<DlgMain>
    {
        protected override void Run(DlgMain self)
        {
            try
            {
                self.ShowPetSwitchTimer();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [FriendOf(typeof(Scroll_Item_MainTask))]
    [FriendOf(typeof(ES_CellDungeonCellMini))]
    [FriendOf(typeof(ES_MainPetFight))]
    [FriendOf(typeof(ES_DigTreasure))]
    [FriendOf(typeof(ES_MainActivityTip))]
    [FriendOf(typeof(Scroll_Item_MainTeamItem))]
    [FriendOf(typeof(ES_RoleHead))]
    [FriendOf(typeof(ES_MainBuff))]
    [FriendOf(typeof(ES_MainHpBar))]
    [FriendOf(typeof(ES_OpenBox))]
    [FriendOf(typeof(ES_Singing))]
    [FriendOf(typeof(DlgMainViewComponent))]
    [FriendOf(typeof(ES_JoystickMove))]
    [FriendOf(typeof(ES_MainSkill))]
    [FriendOf(typeof(Scroll_Item_MainChatItem))]
    [FriendOf(typeof(ChatComponent))]
    [FriendOf(typeof(TaskComponentC))]
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(DlgMain))]
    public static class DlgMainSystem
    {
        public static void RegisterUIEvent(this DlgMain self)
        {
            self.InitButtons();

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
            self.View.E_BagButton.AddListener(self.OnBagButton);

            self.View.E_OpenChatButton.AddListener(self.OnOpenChatButton);

            self.View.E_Button_ZhanKaiButton.AddListener(self.OnButton_ZhanKaiButton);

            self.View.E_Button_RunRaceButton.AddListener(self.OnButton_RunRaceButton);
            self.View.E_Button_HappyButton.AddListener(self.OnButton_HappyButton);
            self.View.E_Button_HappyButton.gameObject.SetActive(false);
            self.View.E_Button_HuntButton.AddListener(self.OnButton_HuntButton);
            self.View.E_Button_SoloButton.AddListener(self.OnButton_SoloButton);
            self.View.E_Btn_BattleButton.AddListener(self.OnBtn_BattleButton);
            self.View.E_Button_DonationButton.AddListener(self.OnButton_DonationButton);
            self.View.E_Button_FenXiangButton.AddListener(self.OnButton_FenXiangButton);
            self.View.E_Btn_EveryTaskButton.AddListener(self.OnBtn_EveryTaskButton);
            self.View.E_Button_RechargeButton.AddListener(self.OnButton_RechargeButton);
            self.View.E_Btn_HuoDongButton.AddListener(self.OnBtn_HuoDongButton);
            // self.View.E_Button_ZhenYingButton.AddListener();
            // self.View.E_Button_EnergyButton.AddListener();
            // self.View.E_Button_FashionButton.AddListener();
            // self.View.E_Button_DemonButton.AddListener();
            self.View.E_Button_SeasonButton.AddListener(self.OnButton_SeasonButton);

            // self.View.E_Button_ActivityV1Button.AddListener();
            self.View.E_Btn_AuctionButton.AddListener(self.OnBtn_AuctionButton);
            self.View.E_Button_HongBaoButton.AddListener(self.OnButton_HongBaoButton);
            self.View.E_Button_ZhanQuButton.AddListener(self.OnButton_ZhanQuButton);
            self.View.E_Button_NewYearButton.AddListener(self.OnButton_NewYearButton);
            self.View.E_Button_RechargeRewardButton.AddListener(self.OnButton_RechargeRewardButton);
            self.View.E_Button_WelfareButton.AddListener(self.OnButton_WelfareButton);
            self.View.E_Btn_GMButton.AddListener(self.OnBtn_GMButton);
            self.View.E_Btn_GMButton.gameObject.SetActive( ET.GMHelp.IsGmAccount(self.Root().GetComponent<PlayerInfoComponent>().Account) );
            self.View.E_Btn_RankButton.AddListener(self.OnBtn_RankButton);
            self.View.E_Button_WorldLvButton.AddListener(self.OnButton_WorldLvButton);
            self.View.E_Btn_PaiMaiHangButton.AddListener(self.OnBtn_PaiMaiHangButton);
            self.View.E_Btn_CellDungeonButton.AddListener(self.OnBtn_CellDungeon);
            self.View.E_Btn_PetMeleeButton.AddListener(self.OnBtn_PetMelee);

            self.View.EG_Btn_KillMonsterRewardRectTransform.GetComponent<ReferenceCollector>().Get<GameObject>("Image_ItemButton")
                    .GetComponent<Button>().AddListenerAsync(self.OnBtn_KillMonsterReward);
            self.View.EG_Btn_LvRewardRectTransform.GetComponent<ReferenceCollector>().Get<GameObject>("Image_ItemButton")
                    .GetComponent<Button>().AddListenerAsync(self.OnBtn_LvReward);
            self.View.E_MailHintTipButton.AddListener(self.OnMailHintTipButton);
            self.View.E_E_Btn_MapTransferButton.AddListener(() => { self.OnE_Btn_MapTransferButton().Coroutine(); });
            self.View.E_Btn_RerurnDungeonButton.AddListener(self.OnBtn_RerurnDungeonButton);
            self.View.E_Btn_RerurnBuildingButton.AddListener(self.OnBtn_RerurnBuildingButton);

            self.View.E_Btn_StopGuaJiButton.AddListener(self.OnBtn_StopGuaJiButton);

            self.View.E_LeftTypeSetToggleGroup.AddListener(self.OnLeftTypeSet);
            self.View.E_RoseTaskButton.AddListener(self.OnRoseTaskButton);
            self.View.E_RoseTeamButton.AddListener(self.OnRoseTeamButton);
            
            self.View.E_ButtonStallCancelButton.AddListener(self.OnButtonStallCancel);
            self.View.E_ButtonStallOpenButton.AddListenerAsync(self.OnButtonStallOpen);

            self.LockTargetComponent = self.Root().GetComponent<LockTargetComponent>();
            self.SkillIndicatorComponent = self.Root().GetComponent<SkillIndicatorComponent>();

            self.View.ES_RoleHead.uiTransform.gameObject.SetActive(true);
            self.View.ES_MainBuff.uiTransform.gameObject.SetActive(true);
            self.View.ES_MainHpBar.uiTransform.gameObject.SetActive(true);
            self.View.ES_OpenBox.uiTransform.gameObject.SetActive(false);
            self.View.ES_Singing.uiTransform.gameObject.SetActive(false);
            self.View.ES_MainActivityTip.uiTransform.gameObject.SetActive(false);
            self.View.ES_DigTreasure.uiTransform.gameObject.SetActive(false);

            self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);

            self.View.E_Btn_RerurnDungeonButton.gameObject.SetActive(false);

            self.View.E_Btn_ShouSuoButton.AddListener(self.OnShouSuo);
            self.View.EG_MainTaskRectTransform.gameObject.SetActive(false);
            self.View.EG_MainTeamRectTransform.gameObject.SetActive(false);
            self.View.E_LeftTypeSetToggleGroup.OnSelectIndex(0);
            self.RefreshMainTaskItems();

            //初始化基础属性
            self.InitShow();
            self.OnSettingUpdate();
            
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int guideid = PlayerPrefsHelp.GetInt($"{PlayerPrefsHelp.LastGuide}_{userInfo.UserId}");
            if (userInfo.Lv == 1 || guideid > 0)
            {
                self.Root().GetComponent<GuideComponent>().SetGuideId(guideid);
            }

            self.AfterEnterScene(MapTypeEnum.MainCityScene);

            // IOS适配
            IPHoneHelper.SetPosition(self.View.EG_PhoneLeftRectTransform.gameObject, new(120f, 0f));

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.GetGameSettingValue(GameSettingEnum.FenBianlLv) == "1")
            {
                self.SetFenBianLv1();
            }

            if (userInfoComponent.GetGameSettingValue(GameSettingEnum.FenBianlLv) == "2")
            {
                self.SetFenBianLv2();
            }

            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            if (playerInfoComponent.PlayerInfo.RealName == 0 || string.IsNullOrEmpty(playerInfoComponent.PlayerInfo.IdCardNo))
            {
                self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_RealName);
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRealName>().OnMainScene();
            }
            // if (PlayerPrefsHelp.GetInt(PlayerPrefsHelp.LastFrame) == 0)
            // {
            //     self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SettingFrame).Coroutine();
            // }
            // else
            // {
            //     string oldValue = userInfoComponent.GetGameSettingValue(GameSettingEnum.HighFps);
            //     CommonViewHelper.TargetFrameRate(oldValue == "1" ? 60 : 30);
            // }

            self.Root().GetComponent<FangChenMiComponentC>().OnLogin().Coroutine();

            string attackmode = userInfoComponent.GetGameSettingValue(GameSettingEnum.AttackTarget);
            self.Root().GetComponent<LockTargetComponent>().AttackTarget = int.Parse(attackmode);

            self.Root().GetComponent<LockTargetComponent>().SkillAttackPlayerFirst =
                    int.Parse(userInfoComponent.GetGameSettingValue(GameSettingEnum.SkillAttackPlayerFirst));

            self.View.E_DragPanelEventTrigger.gameObject.SetActive(PlayerPrefsHelp.GetInt(PlayerPrefsHelp.RotaAngle) == 1);

            userInfoComponent.PickSet = userInfoComponent.GetGameSettingValue(GameSettingEnum.PickSet).Split('@');

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.Friend, self.Reddot_Frined);
            redPointComponent.RegisterReddot(ReddotType.Team, self.Reddot_Team);
            redPointComponent.RegisterReddot(ReddotType.Email, self.Reddot_Email);
            redPointComponent.RegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);
            redPointComponent.RegisterReddot(ReddotType.SkillUp, self.Reddot_SkillUp);
            redPointComponent.RegisterReddot(ReddotType.PetSet, self.Reddot_PetSet);
            redPointComponent.RegisterReddot(ReddotType.Welfare, self.Reddot_Welfare);
            redPointComponent.RegisterReddot(ReddotType.Activity, self.Reddot_Activity);
            redPointComponent.RegisterReddot(ReddotType.Chat, self.Reddot_MainChat);

            ReddotComponentC reddotComponent = self.Root().GetComponent<ReddotComponentC>();
            if (reddotComponent.GetReddot(ReddotType.UnionApply) > 0)
            {
                reddotComponent.AddReddont(ReddotType.UnionApply);
            }

            if (reddotComponent.GetReddot(ReddotType.Email) > 0)
            {
                reddotComponent.AddReddont(ReddotType.Email);
            }

            if (reddotComponent.GetReddot(ReddotType.PetMine) > 0)
            {
                reddotComponent.AddReddont(ReddotType.PetMine);
            }

            reddotComponent.UpdateReddont(ReddotType.RolePoint);
            reddotComponent.UpdateReddont(ReddotType.SkillUp);
            reddotComponent.UpdateReddont(ReddotType.WelfareDraw);
            reddotComponent.UpdateReddont(ReddotType.WelfareLogin);
            reddotComponent.UpdateReddont(ReddotType.WelfareTask);
            reddotComponent.UpdateReddont(ReddotType.FriendApply);
            reddotComponent.UpdateReddont(ReddotType.FriendChat);
            reddotComponent.UpdateReddont(ReddotType.SingleRecharge);
        }

        public static void ShowWindow(this DlgMain self, Entity contextData = null)
        {
            self.ShowGuide().Coroutine();
        }

        public static async ETTask ShowGuide(this DlgMain self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIMain");
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.AcceptTask, "0");
        }

        public static void BeforeUnload(this DlgMain self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
            
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.Friend, self.Reddot_Frined);
            redPointComponent.UnRegisterReddot(ReddotType.Team, self.Reddot_Team);
            redPointComponent.UnRegisterReddot(ReddotType.Email, self.Reddot_Email);
            redPointComponent.UnRegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);
            redPointComponent.UnRegisterReddot(ReddotType.SkillUp, self.Reddot_SkillUp);
            redPointComponent.UnRegisterReddot(ReddotType.PetSet, self.Reddot_PetSet);
            redPointComponent.UnRegisterReddot(ReddotType.Welfare, self.Reddot_Welfare);
            redPointComponent.UnRegisterReddot(ReddotType.Chat, self.Reddot_MainChat);

            self.Root().GetComponent<TimerComponent>().Remove(ref self.MainPetSwitchTimer);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.TimerPing);
        }

        public static void Reddot_PetSet(this DlgMain self, int num)
        {
            self.View.E_PetFormationButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Frined(this DlgMain self, int num)
        {
            self.View.E_FriendButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Welfare(this DlgMain self, int num)
        {
            self.View.E_Button_WelfareButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Activity(this DlgMain self, int num)
        {
            self.View.E_Btn_HuoDongButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_MainChat(this DlgMain self, int num)
        {
            self.View.E_OpenChatButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Team(this DlgMain self, int num)
        {
            self.View.E_Team_Type_1Toggle.transform.Find("Reddot").gameObject.SetActive(num > 0);
            self.View.E_TeamDungeonButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_RolePoint(this DlgMain self, int num)
        {
            self.View.E_RoseEquipButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_SkillUp(this DlgMain self, int num)
        {
            self.View.E_RoseSkillButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void Reddot_Email(this DlgMain self, int num)
        {
            // self.View.E_MailHintTipButton.gameObject.SetActive(num > 0);
            self.View.E_MailHintTipButton.gameObject.SetActive(false);
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

        private static void InitButtons(this DlgMain self)
        {
            List<GameObject> buttons = new List<GameObject>();
            ReferenceCollector rc = self.View.uiTransform.GetComponent<ReferenceCollector>();
            ReferenceCollector rc_skill = rc.Get<GameObject>("UIMainSkill").GetComponent<ReferenceCollector>();
            for (int i = 0; i < 10; i++)
            {
                GameObject go = rc_skill.Get<GameObject>($"UI_MainRoseSkill_item_{i}");
                buttons.Add(go);
            }

            buttons.Add(rc_skill.Get<GameObject>("UI_MainRose_attack"));
            buttons.Add(rc_skill.Get<GameObject>("UI_MainRose_FanGun"));

            buttons.Add(rc.Get<GameObject>("Btn_RoseEquip"));
            buttons.Add(rc.Get<GameObject>("Btn_Pet"));
            buttons.Add(rc.Get<GameObject>("Btn_RoseSkill"));
            buttons.Add(rc.Get<GameObject>("Btn_ChengJiu"));
            buttons.Add(rc.Get<GameObject>("Btn_Friend"));
            buttons.Add(rc.Get<GameObject>("Btn_Task"));
            buttons.Add(rc.Get<GameObject>("UIMainChat"));
            buttons.Add(rc_skill.Get<GameObject>("Btn_CancleSkill"));
            buttons.Add(rc.Get<GameObject>("YaoGanDiFix"));
            buttons.Add(rc_skill.Get<GameObject>("UI_MainRoseSkill_item_juexing"));

            long userid = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            string positonlist;
            using (zstring.Block())
            {
                positonlist = PlayerPrefsHelp.GetString(zstring.Format("PlayerPrefsHelp.SkillPostion_{0}", userid));
            }

            string[] vector2list = positonlist.Split('@');

            for (int i = 0; i < vector2list.Length; i++)
            {
                string[] vectorinfo = vector2list[i].Split(';');
                if (vectorinfo.Length < 2)
                {
                    continue;
                }

                buttons[i].transform.localPosition = new Vector2() { x = float.Parse(vectorinfo[0]), y = float.Parse(vectorinfo[1]) };
            }
        }

        public static void ShowMainUI(this DlgMain self, bool show)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            int sceneType = mapComponent.MapType;
            self.View.EG_PhoneLeftRectTransform.gameObject.SetActive(show);
            self.View.ES_MainBuff.uiTransform.gameObject.SetActive(show);
            self.View.ES_MainHpBar.uiTransform.gameObject.SetActive(show);
            self.View.EG_RightBottomSetRectTransform.gameObject.SetActive(show);
            self.View.EG_RightSetRectTransform.gameObject.SetActive(show);
            if (show)
            {
                // self.View.ES_UIMainChat.UpdatePosition().Coroutine();
            }
            else
            {
                self.Root().GetComponent<SkillIndicatorComponent>()?.RecoveryEffect();
            }

            switch (sceneType)
            {
                case MapTypeEnum.JiaYuan:
                    self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>().SetShow(show);
                    break;
                default:
                    break;
            }
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
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
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

        public static void OnMoveStart(this DlgMain self)
        {
            self.StopAction();

            self.MainUnit.GetComponent<SingingComponent>()?.BeginMove();
        }

        public static void StopAction(this DlgMain self)
        {
            if (self.View.ES_OpenBox != null && self.View.ES_OpenBox.BoxUnitId > 0)
            {
                self.View.ES_OpenBox.OnOpenBox(null);
            }

            self.View.ES_MainSkill.ES_AttackGrid.StopAction();
        }

        public static void OnMainHeroMove(this DlgMain self)
        {
            self.View.ES_MapMini.OnMainHeroMove();
            self.LockTargetComponent.OnMainHeroMove();
            self.SkillIndicatorComponent.OnMainHeroMove();
            self.View.E_NpcDuiHuaButton.gameObject.SetActive(DuiHuaHelper.GetCanNpcDialog(self.Root()) != null);
            self.View.ES_MainSkill.E_Btn_NpcDuiHuaButton.gameObject.SetActive(DuiHuaHelper.GetCanNpcDialog(self.Root()) != null);
            if (self.TianQiEffectObj != null)
            {
                self.TianQiEffectObj.transform.localPosition = self.MainUnit.Position;
            }
        }

        public static void OnUnitChangePosition(this DlgMain self, Unit unit)
        {
            self.View.ES_MapMini.OnUpdateMiniMapOneUnit(unit);   
        }
        
        public static void OnUnitUnitRemove(this DlgMain self, List<long> removeIds)
        {
            self.View.ES_MapMini.OnUnitUnitRemove(removeIds);   
        }

        #region 左边

        private static void OnShouSuo(this DlgMain self)
        {
            bool active = self.View.E_LeftTypeSetToggleGroup.gameObject.activeSelf;
            self.View.EG_MainTaskRectTransform.gameObject.SetActive(!active);
            self.View.E_LeftTypeSetToggleGroup.gameObject.SetActive(!active);
            self.View.EG_MainTeamRectTransform.gameObject.SetActive(!active);

            self.View.E_Btn_ShouSuoButton.transform.localScale = active ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
        }

        public static void OnRecvTaskUpdate(this DlgMain self)
        {
            self.RefreshMainTaskItems();
            self.UpdateNpcTaskUI();
            self.Root().GetComponent<ReddotComponentC>().UpdateReddont(ReddotType.WelfareTask);
        }

        private static void UpdateNpcTaskUI(this DlgMain self)
        {
            List<EntityRef<Unit>> allunit = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
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

                if (unit.GetComponent<UINpcHpComponent>() != null)
                {
                    unit.GetComponent<UINpcHpComponent>().OnRecvTaskUpdate();
                }
            }
        }

        private static void OnLeftTypeSet(this DlgMain self, int index)
        {
            switch (index)
            {
                case 0:
                    if (self.View.EG_MainTaskRectTransform.gameObject.activeSelf)
                    {
                        self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Task).Coroutine();
                    }
                    else
                    {
                        self.View.EG_MainTaskRectTransform.gameObject.SetActive(true);
                        self.View.EG_MainTeamRectTransform.gameObject.SetActive(false);
                        self.RefreshMainTaskItems();
                    }

                    break;
                case 1:
                    self.View.EG_MainTaskRectTransform.gameObject.SetActive(false);
                    self.View.EG_MainTeamRectTransform.gameObject.SetActive(true);
                    self.OnUpdateTeamUI();
                    break;
            }
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

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowTaskPros.Count; i++)
            {
                if (!self.ScrollItemMainTasks.ContainsKey(i))
                {
                    Scroll_Item_MainTask item = self.AddChild<Scroll_Item_MainTask>();
                    string path = "Assets/Bundles/UI/Item/Item_MainTask.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.View.E_MainTaskItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemMainTasks.Add(i, item);
                }

                Scroll_Item_MainTask scrollItemMainTask = self.ScrollItemMainTasks[i];
                scrollItemMainTask.uiTransform.gameObject.SetActive(true);
                scrollItemMainTask.Refresh(self.ShowTaskPros[i]);
            }

            if (self.ScrollItemMainTasks.Count > self.ShowTaskPros.Count)
            {
                for (int i = self.ShowTaskPros.Count; i < self.ScrollItemMainTasks.Count; i++)
                {
                    Scroll_Item_MainTask scrollItemMainTask = self.ScrollItemMainTasks[i];
                    scrollItemMainTask.uiTransform.gameObject.SetActive(false);
                }
            }
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

            string fubenName;
            using (zstring.Block())
            {
                fubenName = zstring.Format("请前往{0} {1} 出接取任务", DungeonConfigCategory.Instance.Get(fubenId).ChapterName,
                    NpcConfigCategory.Instance.Get(getNpc).Name);
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            if (mapComponent.MapType != MapTypeEnum.LocalDungeon)
            {
                flyTipComponent.ShowFlyTip(fubenName);
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

            flyTipComponent.ShowFlyTip(fubenName);
        }

        private static void OnRoseTeamButton(this DlgMain self)
        {
            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            if (teamInfo == null || teamInfo.PlayerList.Count == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("没有队伍！");
                return;
            }

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Team).Coroutine();
        }

        public static async ETTask OnButtonStallOpen(this DlgMain self)
        {
            //UI uI = await UIHelper.Create(self.DomainScene(), UIType.UIPaiMaiStall);
            //Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            //Unit stall = unit.GetParent<UnitComponent>().Get(unit.GetComponent<NumericComponent>().GetAsLong(NumericType.Now_Stall));
            //uI.GetComponent<UIPaiMaiStallComponent>().OnUpdateUI(stall);
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_PaiMaiStall);
            Unit main = UnitHelper.GetMyUnitFromClientScene(self.Root());
            Unit stall = main.GetParent<UnitComponent>().Get(main.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_Stall));
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPaiMaiStall>().OnUpdateUI(stall);
            await ETTask.CompletedTask;
        }

        public static void OnButtonStallCancel(this DlgMain self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "摊位提示", "是否收起自己的摊位?\n 支持下线，摊位可以离线显示6小时!",
                () =>
                {
                    PaiMaiNetHelper.RequestStallOperation(self.Root(), 0, string.Empty).Coroutine();
                    //界面存在就销毁界面
                    //UIHelper.Remove(self.DomainScene(), UIType.UIPaiMaiStall);
                    //弹出提示
                    FlyTipComponent.Instance.ShowFlyTip("摊位已收起!");
                }).Coroutine();
        }
        
        public static void OnUpdateTeamDamage(this DlgMain self, M2C_SyncMiJingDamage message)
        {
            for (int i = 0; i < message.DamageList.Count; i++)
            {
                Scroll_Item_MainTeamItem uIMainTeamItemComponent = self.ScrollItemMainTeamItems[i];
                uIMainTeamItemComponent.OnUpdateDamage(message.DamageList[i]);
            }
        }

        public static void OnUpdateTeamHP(this DlgMain self, Unit unit)
        {
            if (self.ScrollItemMainTeamItems != null)
            {
                foreach (Scroll_Item_MainTeamItem item in self.ScrollItemMainTeamItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.OnUpdateHP(unit);
                }
            }
        }

        private static void ResetTeamUI(this DlgMain self)
        {
            if (self.ScrollItemMainTeamItems != null)
            {
                foreach (Scroll_Item_MainTeamItem item in self.ScrollItemMainTeamItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.OnReset();
                }
            }
        }

        public static void OnUpdateTeamUI(this DlgMain self)
        {
            self.ShowTeamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();

            if (self.ShowTeamInfo == null)
            {
                self.ShowTeamInfo = TeamInfo.Create();
            }
            
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowTeamInfo.PlayerList.Count; i++)
            {
                if (!self.ScrollItemMainTeamItems.ContainsKey(i))
                {
                    Scroll_Item_MainTeamItem item = self.AddChild<Scroll_Item_MainTeamItem>();
                    string path = "Assets/Bundles/UI/Item/Item_MainTeamItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.View.E_MainTeamItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemMainTeamItems.Add(i, item);
                }

                Scroll_Item_MainTeamItem scrollItemMainTeamItem = self.ScrollItemMainTeamItems[i];
                scrollItemMainTeamItem.uiTransform.gameObject.SetActive(true);
                scrollItemMainTeamItem.OnUpdateItem(self.ShowTeamInfo.PlayerList[i]);
            }

            if (self.ScrollItemMainTeamItems.Count > self.ShowTeamInfo.PlayerList.Count)
            {
                for (int i = self.ShowTeamInfo.PlayerList.Count; i < self.ScrollItemMainTeamItems.Count; i++)
                {
                    Scroll_Item_MainTeamItem scrollItemMainTeamItem = self.ScrollItemMainTeamItems[i];
                    scrollItemMainTeamItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }

        #endregion

        #region 左下角

        private static void OnShrinkButton(this DlgMain self)
        {
            // bool isShow = !self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf;
            // self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(isShow);
            Scene root = self.Root();
            MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
            cameraComponent.SetBuildEnter(UnitHelper.GetMyUnitFromClientScene(root), CameraBuildType.Type_3,
                () => { root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Function).Coroutine(); });
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
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_ChengJiu);
        }

        #endregion

        #region 右下角

        private static void OnAdventureButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_DungeonMap);
        }

        private static void OnPetFormationButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_PetSet);
        }

        public static void OnCityHorseButton(this DlgMain self, bool showtip)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
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

        private static void OnTeamDungeonButton(this DlgMain self)
        {
            Log.Debug("组队副本！！！");
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamDungeon).Coroutine();
        }

        public static void OnJiaYuanButton(this DlgMain self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            self.Root().GetComponent<JiaYuanComponentC>().MasterId = userInfoComponent.UserInfo.UserId;
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.JiaYuan, 2000011, 1, userInfoComponent.UserInfo.UserId.ToString()).Coroutine();
        }

        private static void OnNpcDuiHuaButton(this DlgMain self)
        {
            DuiHuaHelper.MoveToNpcDialog(self.Root());
        }

        private static void OnUnionButton(this DlgMain self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.Union, 2000009).Coroutine();
        }

        private static void OnBagButton(this DlgMain self)
        {
            Scene root = self.Root();
            if (SettingData.ModelShow == 0)
            {
                root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role).Coroutine();
            }
            else
            {
                MJCameraComponent cameraComponent = root.CurrentScene().GetComponent<MJCameraComponent>();
                cameraComponent.SetBuildEnter(UnitHelper.GetMyUnitFromClientScene(root), CameraBuildType.Type_2,
                    () => { root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Role).Coroutine(); });
            }
        }

        public static void UpdateShowRoleExp(this DlgMain self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (!ExpConfigCategory.Instance.Contain(userInfo.Lv))
            {
                FlyTipComponent.Instance.ShowFlyTip("非法修改数据！");
                return;
            }

            using (zstring.Block())
            {
                self.View.E_ExpValueText.text = zstring.Format("{0}/{1}", userInfo.Exp, ExpConfigCategory.Instance.Get(userInfo.Lv).UpExp);
            }

            //self.View.E_ExpProImage.fillAmount = (float)userInfo.Exp / (float)ExpConfigCategory.Instance.Get(userInfo.Lv).UpExp;
            float ratevalue = (float)userInfo.Exp / (float)ExpConfigCategory.Instance.Get(userInfo.Lv).UpExp;
            // self.View.E_ExpProImage.transform.localScale = new Vector3(ratevalue, 1f, 1f);
            self.View.E_ExpProImage.fillAmount = ratevalue;
        }

        #endregion

        #region 聊天

        private static void OnOpenChatButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Chat).Coroutine();
        }

        public static void OnRecvChat(this DlgMain self)
        {
            self.RefreshMainChatItems();
        }

        private static void RefreshMainChatItems(this DlgMain self)
        {
            ChatComponent chatComponent = self.Root().GetComponent<ChatComponent>();
            self.ShowChatInfos.Insert(0, chatComponent.LastChatInfo);
            
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowChatInfos.Count; i++)
            {
                if (!self.ScrollItemMainChatItems.ContainsKey(i))
                {
                    Scroll_Item_MainChatItem item = self.AddChild<Scroll_Item_MainChatItem>();
                    string path = "Assets/Bundles/UI/Item/Item_MainChatItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.View.E_MainChatItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemMainChatItems.Add(i, item);
                }

                Scroll_Item_MainChatItem scrollItemMainChatItem = self.ScrollItemMainChatItems[i];
                scrollItemMainChatItem.uiTransform.gameObject.SetActive(true);
                scrollItemMainChatItem.Refresh(self.ShowChatInfos[i]);
            }

            if (self.ScrollItemMainChatItems.Count > self.ShowChatInfos.Count)
            {
                for (int i = self.ShowChatInfos.Count; i < self.ScrollItemMainChatItems.Count; i++)
                {
                    Scroll_Item_MainChatItem scrollItemMainChatItem = self.ScrollItemMainChatItems[i];
                    scrollItemMainChatItem.uiTransform.gameObject.SetActive(false);
                }
            }

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
            self.View.E_MainChatItemsScrollRect.verticalNormalizedPosition = 0f;
        }

        #endregion

        # region 宠物出战

        private static void RefreshMainPetFightUI(this DlgMain self)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int petfightindex = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetFightIndex);
            self.View.ES_MainPetFight_0.uiTransform.localScale = petfightindex == 1 ? new Vector3(1.2f, 1.2f, 1f) : Vector3.one;
            self.View.ES_MainPetFight_1.uiTransform.localScale = petfightindex == 2 ? new Vector3(1.2f, 1.2f, 1f) : Vector3.one;
            self.View.ES_MainPetFight_2.uiTransform.localScale = petfightindex == 3 ? new Vector3(1.2f, 1.2f, 1f) : Vector3.one;

            self.View.ES_MainPetFight_0.Refresh(
                petComponentC.GetPetInfoByID(petComponentC.GetNowPetFightList().Count > 0 ? petComponentC.GetNowPetFightList()[0].PetId : 0), 1);
            self.View.ES_MainPetFight_1.Refresh(
                petComponentC.GetPetInfoByID(petComponentC.GetNowPetFightList().Count > 1 ? petComponentC.GetNowPetFightList()[1].PetId : 0), 2);
            self.View.ES_MainPetFight_2.Refresh(
                petComponentC.GetPetInfoByID(petComponentC.GetNowPetFightList().Count > 2 ? petComponentC.GetNowPetFightList()[2].PetId : 0), 3);
        }

        public static void ShowPetSwitchTimer(this DlgMain self)
        {
            int leftTime = (int)((self.MainPetSwitchEndTime - TimeHelper.ServerNow()) * 0.001f);
            if (leftTime <= 0)
            {
                // 先切换回英雄
                self.View.E_TextPetSwitchTitleText.gameObject.SetActive(false);
                self.View.E_TextPetSwitchText.text = string.Empty;
                self.Root().GetComponent<TimerComponent>().Remove(ref self.MainPetSwitchTimer);
                PetNetHelper.RequestPetFightSwitch(self.Root(), 0).Coroutine();
            }
            else
            {
                self.View.E_TextPetSwitchTitleText.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.View.E_TextPetSwitchText.text = zstring.Format("{0}", leftTime);
                }
            }
        }

        public static void RefreshPetFightPlan(this DlgMain self)
        {
            Scene root = self.Root();
            root.GetComponent<TimerComponent>().Remove(ref self.MainPetSwitchTimer);
             self.RefreshMainPetFightUI();
        }

        public static void RefreshFightSet(this DlgMain self)
        {
            Scene root = self.Root();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            int petfightindex = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetFightIndex);

            root.GetComponent<TimerComponent>().Remove(ref self.MainPetSwitchTimer);
            if (petfightindex > 0)
            {
                // FlyTipComponent.Instance.ShowFlyTip($"切换成宠物 Petfightindex：{petfightindex}");

                PetComponentC petComponentC = root.GetComponent<PetComponentC>();
                long petId = petComponentC.GetNowPetFightList()[petfightindex - 1].PetId;

                self.View.ES_MainSkill.OnEnterScene(unit, petId);
                self.View.ES_MainSkill.OnPetFightSwitch(petId);
                self.View.E_TextPetSwitchTitleText.gameObject.SetActive(true);
                self.View.E_TextPetSwitchText.text = ConfigData.PetSwichEndCD.ToString();
                self.MainPetSwitchEndTime = TimeHelper.ServerNow() + TimeHelper.Second * ConfigData.PetSwichEndCD;
                self.MainPetSwitchTimer = root.GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.MainPetSwitchTimer, self);
            }
            else
            {
                // FlyTipComponent.Instance.ShowFlyTip("切换成英雄");
                self.View.ES_MainSkill.OnEnterScene(unit, 0);
                self.View.ES_MainSkill.OnPetFightSwitch(0);
                self.View.E_TextPetSwitchTitleText.gameObject.SetActive(false);
                self.View.E_TextPetSwitchText.text = string.Empty;
                self.MainPetSwitchEndTime = 0;
            }

            self.RefreshMainPetFightUI();
        }

        # endregion

        # region 右上角按钮

        private static void OnButton_ZhanKaiButton(this DlgMain self)
        {
            bool active = self.View.EG_Btn_TopRight_1RectTransform.gameObject.activeSelf;
            self.View.EG_Btn_TopRight_1RectTransform.gameObject.SetActive(!active);
            self.View.EG_Btn_TopRight_2RectTransform.gameObject.SetActive(!active);
            self.View.EG_Btn_TopRight_3RectTransform.gameObject.SetActive(!active);

            self.View.E_Button_ZhanKaiButton.transform.localScale = active ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
        }

        private static void OnButton_RunRaceButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RunRace).Coroutine();
        }

        private static void OnButton_HappyButton(this DlgMain self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.Happy, BattleHelper.GetSceneIdByType(MapTypeEnum.Happy)).Coroutine();
        }

        private static void OnButton_HuntButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Hunt).Coroutine();
        }

        private static void OnButton_SoloButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Solo).Coroutine();
        }

        private static void OnBtn_BattleButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Battle).Coroutine();
        }

        private static void OnButton_DonationButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Donation).Coroutine();
        }

        private static void OnButton_FenXiangButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_FenXiang).Coroutine();
        }

        private static void OnBtn_EveryTaskButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Country).Coroutine();
        }

        private static void OnButton_RechargeButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
        }

        private static void OnBtn_HuoDongButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Activity).Coroutine();
        }

        private static void OnButton_SeasonButton(this DlgMain self)
        {
            int userlv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            if(userlv < SeasonHelper.GetOpenLv())
            {
                FlyTipComponent.Instance.ShowFlyTip($"{SeasonHelper.GetOpenLv()}级开启！");
                return;
            }
            
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Season).Coroutine();
        }

        private static void OnBtn_AuctionButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PaiMaiAuction).Coroutine();
        }

        private static void OnButton_HongBaoButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_HongBao).Coroutine();
        }

        private static void OnButton_ZhanQuButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ZhanQu).Coroutine();
        }

        private static void OnButton_NewYearButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_NewYear).Coroutine();
        }

        private static void OnButton_RechargeRewardButton(this DlgMain self)
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

        private static void OnButton_WelfareButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Welfare).Coroutine();
        }

        private static void OnBtn_GMButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_GM).Coroutine();
        }

        public static void OnBtn_RankButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Rank).Coroutine();
        }

        private static void OnButton_WorldLvButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WorldLv).Coroutine();
        }

        private static void OnBtn_PaiMaiHangButton(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PaiMai).Coroutine();
        }

        private static void OnBtn_CellDungeon(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CellChapterSelect).Coroutine();
        }

        private static void OnBtn_PetMelee(this DlgMain self)
        {
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.PetMelee, 2700001, FubenDifficulty.Normal, "0").Coroutine();
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

                using (zstring.Block())
                {
                    rc.Get<GameObject>("LvText (1)").GetComponent<Text>().text = zstring.Format("<color=#{0}>击败怪物</color>", color);
                    rc.Get<GameObject>("LvText").GetComponent<Text>().text =
                            zstring.Format("<color=#{0}>{1}/{2}</color>", color, numericComponent.GetAsInt(NumericType.KillMonsterNumber), newNum);
                }

                // self.View.EG_Btn_KillMonsterRewardRectTransform.gameObject.SetActive(true);
                self.View.EG_Btn_KillMonsterRewardRectTransform.gameObject.SetActive(false);
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
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = int.Parse(item[0]);
                bagInfo.ItemNum = int.Parse(item[1]);

                ShowItemTips showItemTips = new()
                {
                    BagInfo = bagInfo,
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

                using (zstring.Block())
                {
                    rc.Get<GameObject>("LvText (1)").GetComponent<Text>().text = zstring.Format("<color=#{0}>等级奖励</color>", color);
                    rc.Get<GameObject>("LvText").GetComponent<Text>().text = zstring.Format("<color=#{0}>{1}级领取</color>", color, newLv);
                }

                // self.View.EG_Btn_LvRewardRectTransform.gameObject.SetActive(true);
                self.View.EG_Btn_LvRewardRectTransform.gameObject.SetActive(false);
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
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = int.Parse(item[0]);
                bagInfo.ItemNum = int.Parse(item[1]);
                ShowItemTips showItemTips = new()
                {
                    BagInfo = bagInfo,
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

        private static void OnMailHintTipButton(this DlgMain self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType != (int)MapTypeEnum.MainCityScene)
            {
                FlyTipComponent.Instance.ShowFlyTip("请前往主城!");
                return;
            }

            self.Root().CurrentScene().GetComponent<OperaComponent>().OnClickNpc(20000006).Coroutine();
        }

        private static async ETTask OnE_Btn_MapTransferButton(this DlgMain self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DungeonMapTransfer);
            DlgDungeonMapTransfer dlgDungeonMapTransfer = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDungeonMapTransfer>();
        }

        public static void OnBtn_RerurnDungeonButton(this DlgMain self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "返回副本", LanguageComponent.Instance.LoadLocalization("移动次数消耗完毕，请返回副本!"),
                () =>
                {
                    int sceneid = self.Root().GetComponent<BattleMessageComponent>().LastDungeonId;
                    if (sceneid == 0)
                    {
                        EnterMapHelper.RequestQuitFuben(self.Root());
                    }
                    else
                    {
                        EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.LocalDungeon, sceneid, 0, "0").Coroutine();
                    }
                },
                null).Coroutine();
        }

        private static void OnBtn_RerurnBuildingButton(this DlgMain self)
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
            if (mapComponent.MapType == MapTypeEnum.Battle)
            {
                tipStr = "现在离开战场，将不会获得战场胜利的奖励哦。";
            }

            PopupTipHelp.OpenPopupTip(self.Root(), "", LanguageComponent.Instance.LoadLocalization(tipStr),
                () => { EnterMapHelper.RequestQuitFuben(self.Root()); },
                null).Coroutine();
        }

        #endregion

        public static void OnUpdateHP(this DlgMain self, int sceneType, Unit defend, Unit attack, long hurtvalue)
        {
            int unitType = defend.Type;
            if (unitType == UnitType.Player && sceneType == MapTypeEnum.TeamDungeon)
            {
                self.OnUpdateTeamHP(defend);
            }

            if (unitType == UnitType.Monster)
            {
                self.View.ES_MainHpBar.OnUpdateHP(defend);
                self.View.ES_MainHpBar.OnUpdateDamage(defend, attack, hurtvalue);
            }

            if (unitType == UnitType.Pet)
            {
                self.View.ES_RoleHead.OnUpdatePetHP(defend);
            }
        }
        
        public static void OnChapterOpen(this DlgMain self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CellChapterOpen).Coroutine();

            self.View.ES_CellDungeonCellMini.OnChapterOpen(true);
        }

        public static void OnCellDungeonEnterShow(this DlgMain self, int chapterId)
        {
            if (chapterId == 0)
                return;

            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_CellDungeonEnterShow);
            DlgCellDungeonEnterShow dlgCellDungeonEnterShow = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCellDungeonEnterShow>();
            dlgCellDungeonEnterShow.OnUpdateUI(chapterId);
        }

        public static void InitMainHero(this DlgMain self, int sceneTypeEnum)
        {
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            self.View.ES_JoystickMove.InitMainHero();
            self.View.ES_MainSkill.InitMainHero();
        }

        public static void BeforeEnterScene(this DlgMain self, int lastScene)
        {
            self.ResetTeamUI();
            self.View.ES_MainSkill.ResetUI();
            self.View.ES_MainBuff.ResetUI();
            self.View.ES_JoystickMove.ResetUI(true);

            self.View.ES_MapMini.BeforeEnterScene(lastScene);
            self.View.ES_Singing.uiTransform.gameObject.SetActive(false);
            self.View.ES_MainHpBar.BeforeEnterScene();
            self.Root().GetComponent<SkillIndicatorComponent>().BeforeEnterScene();
            self.Root().GetComponent<LockTargetComponent>().BeforeEnterScene();
            self.Root().GetComponent<BattleMessageComponent>().CancelRideTargetUnit(0);
            self.Root().GetComponent<BattleMessageComponent>().AttackSelfPlayer.Clear();
            self.Root().RemoveComponent<UnitGuaJiComponent>();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Chat);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DamageValue);
        }
        
        public static void DlgMainReset(this DlgMain self, int lastScene)
        {
            self.ResetTeamUI();
            self.View.ES_MainSkill.ResetUI();
            self.View.ES_MainBuff.ResetUI();
            //self.View.ES_JoystickMove.ResetUI(true);

            self.View.ES_MapMini.BeforeEnterScene(lastScene);
            self.View.ES_Singing.uiTransform.gameObject.SetActive(false);
            self.View.ES_MainHpBar.BeforeEnterScene();
            self.Root().GetComponent<SkillIndicatorComponent>().BeforeEnterScene();
            self.Root().GetComponent<LockTargetComponent>().BeforeEnterScene();
            self.Root().GetComponent<BattleMessageComponent>().CancelRideTargetUnit(0);
            self.Root().GetComponent<BattleMessageComponent>().AttackSelfPlayer.Clear();
            self.Root().RemoveComponent<UnitGuaJiComponent>();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Chat);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DamageValue);
        }
        
        /// <summary>
        /// 返回myunit 并且场景加载完成 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="sceneTypeEnum"></param>
        public static void AfterEnterScene(this DlgMain self, int sceneTypeEnum)
        {
            bool zhankai = self.View.E_Button_ZhanKaiButton.transform.localScale == new Vector3(-1f, 1f, 1f);
            
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            globalComponent.BloodRoot.gameObject.SetActive(true);
            GameObject.Find("Global").GetComponent<RenderScaleController>().ChangeUniversalBlurFeature(false);
        
            self.MainUnit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            self.View.EG_Btn_TopRight_1RectTransform.gameObject.SetActive(zhankai && SceneConfigHelper.ShowRightTopButton(sceneTypeEnum));
            self.View.EG_Btn_TopRight_2RectTransform.gameObject.SetActive(zhankai && SceneConfigHelper.ShowRightTopButton(sceneTypeEnum));
            self.View.E_Btn_RerurnBuildingButton.gameObject.SetActive(sceneTypeEnum != MapTypeEnum.MainCityScene &&
                sceneTypeEnum != MapTypeEnum.JiaYuan);
            // self.View.E_E_Btn_MapTransferButton.gameObject.SetActive(sceneTypeEnum == SceneTypeEnum.LocalDungeon);
            self.View.E_E_Btn_MapTransferButton.gameObject.SetActive(false);
            // self.LevelGuideMini.SetActive(sceneTypeEnum == SceneTypeEnum.CellDungeon);
            self.View.E_NpcDuiHuaButton.gameObject.SetActive(sceneTypeEnum == MapTypeEnum.MainCityScene);
            self.View.E_ShrinkButton.gameObject.SetActive(sceneTypeEnum != MapTypeEnum.RunRace && sceneTypeEnum != MapTypeEnum.Demon);
            self.View.ES_CellDungeonCellMini.uiTransform.gameObject.SetActive(sceneTypeEnum == MapTypeEnum.CellDungeon ||
                sceneTypeEnum == MapTypeEnum.DragonDungeon);
            self.View.E_OpenChatButton.gameObject.SetActive(false);
            self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(false);
            self.View.EG_MainPetFightsRectTransform.gameObject.SetActive(true);
            self.View.ES_MainBuff.InitMainHero();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string value = userInfoComponent.GetGameSettingValue(GameSettingEnum.HideLeftBottom);
            if (value == "1")
            {
                // self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(sceneTypeEnum == SceneTypeEnum.MainCityScene);
            }
            else
            {
                // self.View.EG_LeftBottomBtnsRectTransform.gameObject.SetActive(self.View.EG_LeftBottomBtnsRectTransform.gameObject.activeSelf &&
                //     sceneTypeEnum != SceneTypeEnum.RunRace && sceneTypeEnum != SceneTypeEnum.Demon);
            }

            self.View.ES_JoystickMove.AfterEnterScene();
            self.View.ES_MainHpBar.AfterEnterScene(sceneTypeEnum);
            if (!SceneConfigHelper.ShowLeftButton(sceneTypeEnum))
            {
                self.View.EG_PhoneLeftRectTransform.gameObject.SetActive(false);
                // self.OnClickPageButton(-1);
            }
            else
            {
                self.View.EG_PhoneLeftRectTransform.gameObject.SetActive(true);
                self.View.EG_MainTaskRectTransform.gameObject.SetActive(false);
                self.View.EG_MainTeamRectTransform.gameObject.SetActive(false);
                self.View.E_LeftTypeSetToggleGroup.OnSelectIndex(sceneTypeEnum == MapTypeEnum.TeamDungeon ? 1 : 0);
            }

            int sceneid = self.Root().GetComponent<MapComponent>().SceneId;
            self.View.EG_MainPetFightsRectTransform.gameObject.SetActive(false);
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.CellDungeon:
                    self.View.ES_CellDungeonCellMini.OnUpdateUI();
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    self.View.E_OpenChatButton.gameObject.SetActive(true);
                    self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                    self.View.EG_MainPetFightsRectTransform.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.DragonDungeon:
                    self.View.ES_CellDungeonCellMini.OnUpdateUI();
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    self.View.E_OpenChatButton.gameObject.SetActive(true);
                    self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                    self.View.EG_MainPetFightsRectTransform.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.MainCityScene:
                    self.View.ES_MainHpBar.EG_MonsterNodeRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainHpBar.EG_BossNodeRectTransform.gameObject.SetActive(false);
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(true);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(false);
                    self.View.E_MainTaskItemsScrollRect.gameObject.SetActive(true);
                    self.View.EG_PhoneLeftRectTransform.gameObject.SetActive(true);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                    self.View.E_OpenChatButton.gameObject.SetActive(true);
                    self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.Happy:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(false);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(false);
                    break;
                case MapTypeEnum.SingleHappy:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(false);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(false);
                    break;
                case MapTypeEnum.RunRace:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.Demon:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.JiaYuan:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(false);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                    self.View.E_OpenChatButton.gameObject.SetActive(true);
                    self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                    self.View.EG_MainPetFightsRectTransform.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.SealTower:
                    self.View.EG_PhoneLeftRectTransform.gameObject.SetActive(false);
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                    self.View.E_OpenChatButton.gameObject.SetActive(true);
                    self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                    self.View.EG_MainPetFightsRectTransform.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.LocalDungeon:
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
                            self.View.E_OpenChatButton.gameObject.SetActive(true);
                            self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                            self.View.EG_MainPetFightsRectTransform.gameObject.SetActive(true);
                            break;
                    }

                    break;
                case MapTypeEnum.PetMelee:
                case MapTypeEnum.PetMatch:
                    break;
                case MapTypeEnum.Union:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    self.View.E_OpenChatButton.gameObject.SetActive(true);
                    self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.UnionRace:
                    self.View.E_OpenChatButton.gameObject.SetActive(true);
                    self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                    break;
                case MapTypeEnum.MiJing:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    self.View.E_OpenChatButton.gameObject.SetActive(true);
                    self.View.EG_MainChatRectTransform.gameObject.gameObject.SetActive(true);
                    self.View.EG_MainPetFightsRectTransform.gameObject.SetActive(true);
                    break;
                default:
                    self.View.EG_HomeButtonRectTransform.gameObject.SetActive(false);
                    self.View.ES_MainSkill.uiTransform.gameObject.SetActive(true);
                    self.View.ES_JoystickMove.uiTransform.gameObject.SetActive(true);
                    break;
            }

            self.OnHorseRide();
            self.UpdateShadow();
            self.UpdateNpcTaskUI();
            self.View.ES_MapMini.OnEnterScene();
            self.View.ES_MainSkill.OnSkillSetUpdate();
            self.View.ES_RoleHead.OnEnterScene(sceneTypeEnum);
            // self.ZoneScene().GetComponent<RelinkComponent>().OnApplicationFocusHandler(true);
            //self.View.E_UnionButton.gameObject.SetActive(self.MainUnit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0) > 0);
            self.View.E_UnionButton.gameObject.SetActive(false);
            if (sceneTypeEnum == MapTypeEnum.LocalDungeon)
            {
                self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.EnterFuben, sceneid.ToString());
                bool shenmizhimen =
                        DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(self.Root().GetComponent<MapComponent>().SceneId);
                self.View.E_Btn_RerurnDungeonButton.gameObject.SetActive(shenmizhimen);
                // self.View.E_E_Btn_MapTransferButton.gameObject.SetActive(!shenmizhimen);
                self.View.E_E_Btn_MapTransferButton.gameObject.SetActive(false);
                self.View.E_Btn_RerurnBuildingButton.gameObject.SetActive(!shenmizhimen);
            }

            if (!self.View.ES_JoystickMove.uiTransform.gameObject.activeSelf
                || sceneTypeEnum == MapTypeEnum.PetDungeon
                || sceneTypeEnum == MapTypeEnum.PetTianTi
                || sceneTypeEnum == MapTypeEnum.PetMing)
            {
                self.MainUnit.GetComponent<StateComponentC>().StateTypeAdd(StateTypeEnum.NoMove);
            }

            self.Root().RemoveComponent<UnitGuaJiComponent>();
            self.View.EG_GuaJiSetRectTransform.gameObject.SetActive(false);

            self.UpdateLvReward();
            self.UpdateKillMonsterReward();

            self.CheckMailReddot().Coroutine();
            self.Root().CurrentScene().GetComponent<OperaComponent>().UpdateClickMode();
            self.RefreshFightSet();
            self.OnMainHeroMove();

            UserInfoNetHelper.RequestUserInfoInit(self.Root()).Coroutine();
        }

        public static void OnUpdateUserData(this DlgMain self, string updateType)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int userDataType = int.Parse(updateType.Split('_')[0]);

            string updateValue = updateType.Split('_')[1];

            switch (userDataType)
            {
                case UserDataType.PiLao:
                    self.View.ES_RoleHead.UpdateShowRolePiLao();
                    break;
                case UserDataType.Lv:
                    self.UpdateShowRoleExp();
                    self.View.ES_RoleHead.UpdateShowRoleExp();
                    // self.CheckFuntionButtonByLv(int.Parse(updateValue));
                    FunctionEffect.PlaySelfEffect(self.MainUnit, 200005); //升级特效
                    self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.LevelUp, userInfo.Lv.ToString());
                    // using (zstring.Block())
                    // {
                    //     FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0}{1}", GameSettingLanguge.Instance.LoadLocalization("恭喜你!等级提升至:"),
                    //         userInfo.Lv));
                    // }

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
                    if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTreasureOpen>() != null)
                    {
                        return;
                    }

                    if (int.Parse(updateValue) > 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得{0} 公会捐献", updateValue));
                        }
                    }

                    if (int.Parse(updateValue) < 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("消耗{0} 公会捐献", int.Parse(updateValue) * -1));
                        }
                    }

                    break;

                case UserDataType.Gold:
                    if (self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTreasureOpen>() != null)
                    {
                        return;
                    }

                    // if (int.Parse(updateValue) > 0)
                    // {
                    //     using (zstring.Block())
                    //     {
                    //         FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得{0} 金币", updateValue));
                    //     }
                    // }

                    if (int.Parse(updateValue) < 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("消耗{0} 金币", int.Parse(updateValue) * -1));
                        }
                    }

                    break;
                case UserDataType.WeiJingGold:
                    if (int.Parse(updateValue) > 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得{0} 兑换币", updateValue));
                        }
                    }

                    if (int.Parse(updateValue) < 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("消耗{0} 兑换币", int.Parse(updateValue) * -1));
                        }
                    }

                    break;
                case UserDataType.RongYu:
                    if (int.Parse(updateValue) > 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得{0} 荣誉", updateValue));
                        }
                    }

                    if (int.Parse(updateValue) < 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("消耗{0} 荣誉", int.Parse(updateValue) * -1));
                        }
                    }

                    break;
                case UserDataType.JiaYuanFund:
                    if (int.Parse(updateValue) > 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得{0} 家园资金", updateValue));
                        }
                    }

                    break;
                case UserDataType.BaoShiDu:
                    if (int.Parse(updateValue) > 0)
                    {
                        using (zstring.Block())
                        {
                            FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得{0} 饱食度", updateValue));
                        }
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
                    FlyTipComponent.Instance.ShowFlyTip("所有人不要乱跑哦");
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
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            string value = usevalue != "" ? usevalue : userInfoComponent.GetGameSettingValue(GameSettingEnum.Shadow);

            // 获取所有的Light组件
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            if (lights != null)
            {
                // 遍历所有灯光
                foreach (Light light in lights)
                {
                    //if (!light.name.Contains("Directional Light"))
                    //{
                    //    continue;
                    //}

                    if (light.type != LightType.Directional)
                    {
                        continue;
                    }
                    light.shadows = value == "0" ? LightShadows.None : LightShadows.Soft;
                    light.shadowStrength = 0.5f;
                    Log.Debug($"UpdateShadow:  {light.name}    {value}");
                }
            }

            GameObject Fence_5 = GameObject.Find("AdditiveHide/ScenceModelSet/SceneSet/Fence_5_Test_0910");
            if (Fence_5 != null)
            {
                Renderer rendererFence_5 = Fence_5.GetComponent<Renderer>();

                // 获取游戏对象上第一个材质的Shader
                Shader shaderFence_5 = rendererFence_5.material.shader;
                // 输出Shader的名称
                Log.Console("Fence_5,  Shader Name: " + shaderFence_5.name);
            }

            GameObject T1errain = GameObject.Find("AdditiveHide/ScenceModelSet/Terrain");
            if (T1errain != null)
            {
                // 获取当前游戏对象上的Terrain组件
                Terrain terrain = T1errain.GetComponent<Terrain>();
                // 获取Terrain的材质
                Material mat = terrain.materialTemplate;

                // 获取并打印Shader
                Shader shader = mat.shader;
                Debug.Log("Terrain ,  Shader Name: " + shader.name);
            }
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
            long ping = TimeInfo.Instance.Ping;
            self.View.E_TextPingText.text = StringBuilderHelper.GetPing(ping);
            if (ping <= 200)
            {
                self.View.E_TextPingText.color = Color.green;
                return;
            }

            if (ping <= 500)
            {
                self.View.E_TextPingText.color = Color.yellow;
                return;
            }

            self.View.E_TextPingText.color = Color.red;
        }

        public static void UpdateMessage(this DlgMain self)
        {
            // self.View.E_TextMessageText.text = StringBuilderHelper.GetMessageCnt(OpcodeHelper.OneTotalNumber);
            // OpcodeHelper.OneTotalNumber = 0;
        }

        public static void OnBtn_StopGuaJiButton(this DlgMain self)
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

            string fpsValue = userInfoComponent.GetGameSettingValue(GameSettingEnum.HighFps);
            CommonViewHelper.TargetFrameRate(fpsValue == "1" ? 60 : 30);
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

        public static void OnApplicationFocusExit(this DlgMain self)
        {
            //self.View.ES_JoystickMove.ResetUI(true);
            //self.OnMoveStart();
        }
        
        public static void OnSelfDead(this DlgMain self)
        {
            self.StopAction();
            self.View.ES_JoystickMove.ResetUI(true);
        }

        public static void OnSelfRevive(this DlgMain self)
        {
            self.View.ES_JoystickMove.AfterEnterScene();
        }

        public static void OnBagItemUpdate(this DlgMain self)
        {
            self.View.ES_MainSkill.OnBagItemUpdate();

            // self.CheckCanEquip().Coroutine();
        }

        public static long GetJoystickTimer(this DlgMain self)
        {
            return self.View.ES_JoystickMove.JoystickTimer;
        }

        public static void OnRechageSucess(this DlgMain self, int addNumber)
        {
            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("充值{0}元成功", addNumber));
            }

            self.Root().GetComponent<PlayerInfoComponent>().PlayerInfo.RechargeInfos.Add(new()
            {
                Amount = addNumber, Time = TimeHelper.ClientNow(), UnitId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId
            });
        }

        public static void ShowUIStall(this DlgMain self, long stallId)
        {
            self.View.EG_UIStallRectTransform.gameObject.SetActive(stallId > 0);
        }

        public static void OnZeroClockUpdate(this DlgMain self)
        {
            self.InitFunctionButton();
        }

        public static void InitFunctionButton(this DlgMain self)
        {
            FlyTipComponent.Instance.ShowFlyTip("重新设置主界面功能按钮");
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
            self.View.ES_MainSkill.E_Button_HorseButton.gameObject.SetActive(
                unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseFightID) > 0);
            self.View.E_CityHorseButton.gameObject.SetActive(unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.HorseFightID) > 0);
        }
    }
}
