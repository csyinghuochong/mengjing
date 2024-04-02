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
    [FriendOf(typeof(FsmComponent))]
    [EntitySystemOf(typeof(FsmComponent))]
    public static partial class FsmComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FsmComponent self)
        {
            Unit unit = self.GetParent<Unit>();
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
            SkillManagerComponentC skillManagerComponentCSystem = self.GetParent<Unit>().GetComponent<SkillManagerComponentC>();
            if (skillManagerComponentCSystem.SkillMoveTime != 0 && TimeHelper.ClientNow() >= skillManagerComponentCSystem.SkillMoveTime)
            {
                skillManagerComponentCSystem.SkillMoveTime = 0;
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
            if (skillManagerComponentCSystem.SkillSingTime > 0 && TimeHelper.ClientNow() >= skillManagerComponentCSystem.SkillSingTime)
            {
                skillManagerComponentCSystem.SkillSingTime = 0;
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
            Unit unit = self.GetParent<Unit>();
            AnimatorComponent animatorComponent = unit.GetComponent<AnimatorComponent>();
            if (animatorComponent == null)
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
                    animatorComponent.SetBoolValue("Death", false);
                    break;
                case FsmStateEnum.FsmNpcSpeak:
                    animatorComponent.SetBoolValue("Idle", true);
                    break;
                case FsmStateEnum.FsmSinging:
                    animatorComponent.SetBoolValue("Run", false);
                    animatorComponent.SetBoolValue("Idle", true);
                    break;
                case FsmStateEnum.FsmSkillState:
                    animatorComponent.SetBoolValue("Run", false);
                    animatorComponent.SetBoolValue("Idle", true);
                    break;
                default:
                    break;
            }

            switch (targetFsm)
            {
                case FsmStateEnum.FsmComboState:
                    //this.ClearnAnimator();
                    animatorComponent.SetBoolValue("Idle", false);
                    animatorComponent.SetBoolValue("Run", false);
                    self.OnEnterFsmComboState(skillid);
                    break;
                case FsmStateEnum.FsmDeathState:
                    animatorComponent.SetBoolValue("Idle", false);
                    animatorComponent.SetBoolValue("Death", true);
                    animatorComponent.Play("Death");
                    break;
                case FsmStateEnum.FsmHui:
                    animatorComponent.SetBoolValue("Idle", false);
                    animatorComponent.Play("Hui");
                    break;
                case FsmStateEnum.FsmIdleState:
                    self.OnEnterIdleState();
                    break;
                case FsmStateEnum.FsmNpcSpeak:
                    animatorComponent.SetBoolValue("Idle", false);
                    animatorComponent.SetBoolValue("Run", false);
                    animatorComponent.Play("Speak");
                    break;
                case FsmStateEnum.FsmRunState:
                    self.OnEnterFsmRunState();
                    break;
                case FsmStateEnum.FsmShiQuItem:
                    animatorComponent.SetBoolValue("Idle", false);
                    animatorComponent.SetBoolValue("Run", false);
                    animatorComponent.Play("ShiQu");
                    break;
                case FsmStateEnum.FsmSinging:
                    animatorComponent.SetBoolValue("Idle", false);
                    animatorComponent.SetBoolValue("Run", false);
                    animatorComponent.Play("YinChang");
                    break;
                case FsmStateEnum.FsmSkillState:
                    self.OnEnterFsmSkillState(skillid);
                    break;
                case FsmStateEnum.FsmHorse:
                    animatorComponent.SetBoolValue("Idle", false);
                    animatorComponent.SetBoolValue("Run", false);
                    animatorComponent.Play("Horse");
                    break;
                default:
                    break;
            }
            self.CurrentFsm = targetFsm;
        }

        public static void OnEnterFsmSkillState(this FsmComponent self, int skillid)
        {

            Unit unit = self.GetParent<Unit>();
            AnimatorComponent animatorComponent = unit.GetComponent<AnimatorComponent>();
            SkillManagerComponentC skillManagerComponentCSystem = unit.GetComponent<SkillManagerComponentC>();
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
            
            if (skillManagerComponentCSystem.SkillMoveTime > TimeHelper.ClientNow()
               || skillManagerComponentCSystem.SkillSingTime > TimeHelper.ClientNow())
            {
                animatorComponent.SetBoolValue("Idle", false);
                animatorComponent.SetBoolValue("Run", false);
                self.BeginTimer();
            }
            else
            {
                animatorComponent.SetBoolValue("Run", false);
                animatorComponent.SetBoolValue("Idle", true);
            }
            animatorComponent.Play(skillConfig.SkillAnimation);
        }

        public static void OnEnterFsmRunState(this FsmComponent self)
        {
            self.LastAnimator = string.Empty;
            Unit unit = self.GetParent<Unit>();
            SkillManagerComponentC skillManagerComponentCSystem = unit.GetComponent<SkillManagerComponentC>();
            if (TimeHelper.ClientNow() > skillManagerComponentCSystem.SkillMoveTime)
            {
                self.SetRunState();
            }
        }

        public static void OnEnterIdleState(this FsmComponent self)
        {
            self.LastAnimator = string.Empty;
            SkillManagerComponentC skillManagerComponentCSystem = self.GetParent<Unit>().GetComponent<SkillManagerComponentC>();
            if (skillManagerComponentCSystem == null || TimeHelper.ClientNow() > skillManagerComponentCSystem.SkillMoveTime)
            {
                self.SetIdleState();
            }
        }

        public static void SetHorseState(this FsmComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            AnimatorComponent animatorComponent = unit.GetComponent<AnimatorComponent>();
            animatorComponent.SetBoolValue("Run", false);
            animatorComponent.SetBoolValue("Idle", false);
            animatorComponent.Animator.Play("ZuoQi");
        }

        public static void SetIdleState(this FsmComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            AnimatorComponent animatorComponent = unit.GetComponent<AnimatorComponent>();
            animatorComponent.SetBoolValue("Run", false);
            animatorComponent.SetBoolValue("Idle", true);
            animatorComponent.Play("Idle");
        }

        public static void SetRunState(this FsmComponent self)
        { 
            Unit unit = self.GetParent<Unit>();
            AnimatorComponent animatorComponent = unit.GetComponent<AnimatorComponent>();
            animatorComponent.SetBoolValue("Idle", false);
            animatorComponent.SetBoolValue("Run", true);
            animatorComponent.Play("Run");
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
            AnimatorComponent animatorComponent = unit.GetComponent<AnimatorComponent>();

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
                AnimatorStateInfo animatorStateInfo = animatorComponent.Animator.GetCurrentAnimatorStateInfo(0);
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
                    animatorComponent.SetBoolValue("Act_1", false);
                    animatorComponent.SetBoolValue("Act_2", false);
                    animatorComponent.SetBoolValue("Act_3", false);
                    animatorComponent.Play(skillConfig.SkillAnimation);
                }
                else if (curAckAnimation == String.Empty)
                {
                    animatorComponent.SetBoolValue("Act_1", false);
                    animatorComponent.SetBoolValue("Act_2", false);
                    animatorComponent.SetBoolValue("Act_3", false);
                    animatorComponent.Play(skillConfig.SkillAnimation);
                }
                else
                {
                    animatorComponent.SetBoolValue("Act_1", false);
                    animatorComponent.SetBoolValue("Act_2", false);
                    animatorComponent.SetBoolValue("Act_3", false);
                    animatorComponent.SetBoolValue(boolAnimation, true);
                }

                self.LastAnimator = skillConfig.SkillAnimation;
                self.WaitIdleTime = TimeHelper.ClientNow() + SkillData.AckExitTime[skillConfig.SkillAnimation];
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                self.BeginTimer();
            }
            else
            {
                animatorComponent.Play(skillConfig.SkillAnimation);
            }
        }

        public static void ClearnAnimator(this FsmComponent self)
        {
            //重置参数
            Unit unit = self.GetParent<Unit>();
            AnimatorComponent animatorComponent = unit.GetComponent<AnimatorComponent>();
            animatorComponent.SetBoolValue("Idle", false);
            animatorComponent.SetBoolValue("Run", false);
            animatorComponent.SetBoolValue("Death", false);
            animatorComponent.SetBoolValue("CriAct", false);
            animatorComponent.SetBoolValue("Act_1", false);
            animatorComponent.SetBoolValue("Act_2", false);
            animatorComponent.SetBoolValue("Act_3", false);
        }
    }
}