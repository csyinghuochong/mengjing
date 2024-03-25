using UnityEngine;
using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Invoke(TimerInvokeType.FsmTimer)]
    public class FsmTimer : ATimer<FsmComponent>
    {
        protected override void Run(FsmComponent self)
        {
            try
            {
                self.Check();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    /// <summary>
    /// 适用于动画切换的栈式状态机
    /// </summary>
    [FriendOf(typeof(SkillManagerComponentC))]
    [FriendOf(typeof(AnimatorComponent))]
    [FriendOf(typeof(FsmComponent))]
    [EntitySystemOf(typeof(FsmComponent))]
    public static partial class FsmComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FsmComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            self.AnimatorComponent = unit.GetComponent<AnimatorComponent>();
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            bool idle = moveComponent == null || moveComponent.IsArrived();
            self.ChangeState(idle? FsmStateEnum.FsmIdleState : FsmStateEnum.FsmRunState);
            self.WaitIdleTime = 0;
        }
        [EntitySystem]
        private static void Destroy(this FsmComponent self)
        {
            self.EndTimer();
        }
        
        public static void Check(this FsmComponent self)
        {
            if (self.AnimatorComponent == null)
            {
                int monsterId = self.GetParent<Unit>().ConfigId;
                Log.Error($"{self.AnimatorComponent == null} {monsterId}");
                self.EndTimer();
                return;
            }

            SkillManagerComponentC skillManagerComponentC = self.GetParent<Unit>().GetComponent<SkillManagerComponentC>();
            if (skillManagerComponentC.SkillMoveTime != 0 && TimeHelper.ClientNow() >= skillManagerComponentC.SkillMoveTime)
            {
                skillManagerComponentC.SkillMoveTime = 0;
                if (self.CurrentFsm == FsmStateEnum.FsmIdleState)
                {
                    self.SetIdleState();
                }
                if (self.CurrentFsm == FsmStateEnum.FsmSkillState)  //光之能量 保持在动作的最后一帧
                {
                    self.SetIdleState();
                }
                if (self.CurrentFsm == FsmStateEnum.FsmRunState)
                {
                    self.SetRunState();
                }
                self.EndTimer();
            }
            if (skillManagerComponentC.SkillSingTime > 0 && TimeHelper.ClientNow() >= skillManagerComponentC.SkillSingTime)
            {
                skillManagerComponentC.SkillSingTime = 0;
                self.SetIdleState();
                self.EndTimer();
            }
            if (self.WaitIdleTime > 0 && TimeHelper.ClientNow() >= self.WaitIdleTime)   //连击回Idle
            {
                self.WaitIdleTime = 0;
                self.SetIdleState();
                self.EndTimer();
            }
        }

        public static void EndTimer(this FsmComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void BeginTimer(this FsmComponent self)
        {
            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.FsmTimer, self);
            }
        }

        public static void ChangeState(this FsmComponent self, int targetFsm, int skillid = 0)
        {
            if (self.AnimatorComponent == null)
            {
                return;
            }
            switch (self.CurrentFsm)
            {
                case FsmStateEnum.FsmRunState:
                    if (targetFsm == FsmStateEnum.FsmRunState)
                    {
                        return;
                    }
                    break;
                case FsmStateEnum.FsmComboState:
                    self.WaitIdleTime = 0;
                    self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                    break;
                case FsmStateEnum.FsmDeathState:
                    self.AnimatorComponent.SetBoolValue("Death", false);
                    break;
                case FsmStateEnum.FsmNpcSpeak:
                    self.AnimatorComponent.SetBoolValue("Idle", true);
                    break;
                case FsmStateEnum.FsmSinging:
                    self.AnimatorComponent.SetBoolValue("Run", false);
                    self.AnimatorComponent.SetBoolValue("Idle", true);
                    break;
                case FsmStateEnum.FsmSkillState:
                    self.AnimatorComponent.SetBoolValue("Run", false);
                    self.AnimatorComponent.SetBoolValue("Idle", true);
                    break;
                default:
                    break;
            }

            switch (targetFsm)
            {
                case FsmStateEnum.FsmComboState:
                    //this.ClearnAnimator();
                    self.AnimatorComponent.SetBoolValue("Idle", false);
                    self.AnimatorComponent.SetBoolValue("Run", false);
                    self.OnEnterFsmComboState(skillid);
                    break;
                case FsmStateEnum.FsmDeathState:
                    self.AnimatorComponent.SetBoolValue("Idle", false);
                    self.AnimatorComponent.SetBoolValue("Death", true);
                    self.AnimatorComponent.Play("Death");
                    break;
                case FsmStateEnum.FsmHui:
                    self.AnimatorComponent.SetBoolValue("Idle", false);
                    self.AnimatorComponent.Play("Hui");
                    break;
                case FsmStateEnum.FsmIdleState:
                    self.OnEnterIdleState();
                    break;
                case FsmStateEnum.FsmNpcSpeak:
                    self.AnimatorComponent.SetBoolValue("Idle", false);
                    self.AnimatorComponent.SetBoolValue("Run", false);
                    self.AnimatorComponent.Play("Speak");
                    break;
                case FsmStateEnum.FsmRunState:
                    self.OnEnterFsmRunState();
                    break;
                case FsmStateEnum.FsmShiQuItem:
                    self.AnimatorComponent.SetBoolValue("Idle", false);
                    self.AnimatorComponent.SetBoolValue("Run", false);
                    self.AnimatorComponent.Play("ShiQu");
                    break;
                case FsmStateEnum.FsmSinging:
                    self.AnimatorComponent.SetBoolValue("Idle", false);
                    self.AnimatorComponent.SetBoolValue("Run", false);
                    self.AnimatorComponent.Play("YinChang");
                    break;
                case FsmStateEnum.FsmSkillState:
                    self.OnEnterFsmSkillState(skillid);
                    break;
                case FsmStateEnum.FsmHorse:
                    self.AnimatorComponent.SetBoolValue("Idle", false);
                    self.AnimatorComponent.SetBoolValue("Run", false);
                    self.AnimatorComponent.Play("Horse");
                    break;
                default:
                    break;
            }
            self.CurrentFsm = targetFsm;
        }

        public static void OnEnterFsmSkillState(this FsmComponent self, int skillid)
        {
            SkillManagerComponentC skillManagerComponentC = self.GetParent<Unit>().GetComponent<SkillManagerComponentC>();
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
            if (skillManagerComponentC.SkillMoveTime > TimeHelper.ClientNow()
               || skillManagerComponentC.SkillSingTime > TimeHelper.ClientNow())
            {
                self.AnimatorComponent.SetBoolValue("Idle", false);
                self.AnimatorComponent.SetBoolValue("Run", false);
                self.BeginTimer();
            }
            else
            {
                self.AnimatorComponent.SetBoolValue("Run", false);
                self.AnimatorComponent.SetBoolValue("Idle", true);
            }
            self.AnimatorComponent.Play(skillConfig.SkillAnimation);
        }

        public static void OnEnterFsmRunState(this FsmComponent self)
        {
            self.LastAnimator = string.Empty;
            Unit unit = self.GetParent<Unit>();
            SkillManagerComponentC skillManagerComponentC = unit.GetComponent<SkillManagerComponentC>();
            if (TimeHelper.ClientNow() > skillManagerComponentC.SkillMoveTime)
            {
                self.SetRunState();
            }
        }

        public static void OnEnterIdleState(this FsmComponent self)
        {
            self.LastAnimator = string.Empty;
            SkillManagerComponentC skillManagerComponentC = self.GetParent<Unit>().GetComponent<SkillManagerComponentC>();
            if (skillManagerComponentC == null || TimeHelper.ClientNow() > skillManagerComponentC.SkillMoveTime)
            {
                self.SetIdleState();
            }
        }

        public static void SetHorseState(this FsmComponent self)
        {
            self.AnimatorComponent.SetBoolValue("Run", false);
            self.AnimatorComponent.SetBoolValue("Idle", false);
            self.AnimatorComponent.Animator.Play("ZuoQi");
        }

        public static void SetIdleState(this FsmComponent self)
        {
            self.AnimatorComponent.SetBoolValue("Run", false);
            self.AnimatorComponent.SetBoolValue("Idle", true);
            self.AnimatorComponent.Play("Idle");
        }

        public static void SetRunState(this FsmComponent self)
        {
            self.AnimatorComponent.SetBoolValue("Idle", false);
            self.AnimatorComponent.SetBoolValue("Run", true);
            self.AnimatorComponent.Play("Run");
        }

        public static void OnEnterFsmComboState(this FsmComponent self, int skillid)
        {
            Unit unit = self.GetParent<Unit>();
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
            //int EquipType = (int)ItemEquipType.Common;
            //int itemId = (int)unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Now_Weapon);
            //if (itemId != 0)
            //{
            //    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            //    EquipType = itemConfig.EquipType;
            //}

            //1:剑 2:刀 11 默认11  //(EquipType == 2)
            if (unit.ConfigId == 1)
            {
                string boolAnimation = skillConfig.SkillAnimation;
                if (boolAnimation == "Act_11")
                {
                    boolAnimation = "Act_1";
                }
                if (boolAnimation == "Act_12")
                {
                    boolAnimation = "Act_2";
                }
                if (boolAnimation == "Act_13")
                {
                    boolAnimation = "Act_3";
                }

                string curAckAnimation = String.Empty;
                AnimatorStateInfo animatorStateInfo = self.AnimatorComponent.Animator.GetCurrentAnimatorStateInfo(0);
                foreach (var item in SkillData.AckExitTime)
                {
                    if (animatorStateInfo.IsName(item.Key))
                    {
                        curAckAnimation = item.Key;
                        break;
                    }
                }
                if (self.LastAnimator == skillConfig.SkillAnimation)
                {
                    self.AnimatorComponent.SetBoolValue("Act_1", false);
                    self.AnimatorComponent.SetBoolValue("Act_2", false);
                    self.AnimatorComponent.SetBoolValue("Act_3", false);
                    self.AnimatorComponent.Play(skillConfig.SkillAnimation);
                }
                else if (curAckAnimation == String.Empty)
                {
                    self.AnimatorComponent.SetBoolValue("Act_1", false);
                    self.AnimatorComponent.SetBoolValue("Act_2", false);
                    self.AnimatorComponent.SetBoolValue("Act_3", false);
                    self.AnimatorComponent.Play(skillConfig.SkillAnimation);
                }
                else
                {
                    self.AnimatorComponent.SetBoolValue("Act_1", false);
                    self.AnimatorComponent.SetBoolValue("Act_2", false);
                    self.AnimatorComponent.SetBoolValue("Act_3", false);
                    self.AnimatorComponent.SetBoolValue(boolAnimation, true);
                }

                self.LastAnimator = skillConfig.SkillAnimation;
                self.WaitIdleTime = TimeHelper.ClientNow() + SkillData.AckExitTime[skillConfig.SkillAnimation];
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                self.BeginTimer();
            }
            else
            {
                self.AnimatorComponent.Play(skillConfig.SkillAnimation);
            }
        }

        public static void ClearnAnimator(this FsmComponent self)
        {
            //重置参数
            self.AnimatorComponent.SetBoolValue("Idle", false);
            self.AnimatorComponent.SetBoolValue("Run", false);
            self.AnimatorComponent.SetBoolValue("Death", false);
            self.AnimatorComponent.SetBoolValue("CriAct", false);
            self.AnimatorComponent.SetBoolValue("Act_1", false);
            self.AnimatorComponent.SetBoolValue("Act_2", false);
            self.AnimatorComponent.SetBoolValue("Act_3", false);
        }
    }
}