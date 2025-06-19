using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(GameObjectComponent))]
    [EntitySystemOf(typeof(AnimatorComponent))]
    [FriendOf(typeof(AnimatorComponent))]
    public static partial class AnimatorComponentSystem
    {
        [EntitySystem]
        private static void Destroy(this AnimatorComponent self)
        {
            self.Animator = null;
        }

        [EntitySystem]
        private static void Awake(this AnimatorComponent self)
        {
            self.Parameter.Clear();
            self.MissParameter.Clear();
            self.animationClips.Clear();
            self.animatorControllers.Clear();
            GameObject gameObject = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
            self.InitController(gameObject);
            self.UpdateAnimator(gameObject);
            self.UpdateController();
        }
        
        public static void InitController(this AnimatorComponent self, GameObject gameObject)
        {
            Unit unit = self.GetParent<Unit>();
            self.UnitType = unit.Type;
            if (unit.Type != UnitType.Player || unit.ConfigId != 3)
            {
                return;
            }

            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
            if (rc == null)
            {
                self.animatorControllers.Add(gameObject.GetComponent<Animator>().runtimeAnimatorController);

                return;
            }

            GameObject AnimatorList = rc.Get<GameObject>("AnimatorList");
            if (AnimatorList == null)
            {
                self.animatorControllers.Add(gameObject.GetComponent<Animator>().runtimeAnimatorController);

                return;
            }

            for (int i = 0; i < AnimatorList.transform.childCount; i++)
            {
                GameObject child = AnimatorList.transform.GetChild(i).gameObject;
                self.animatorControllers.Add(child.GetComponent<Animator>().runtimeAnimatorController);
            }
        }

        public static void UpdateController(this AnimatorComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            if (unit.Type != UnitType.Player || unit.ConfigId != 3)
            {
                return;
            }

            int equipIndex = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.EquipIndex);
            if (self.animatorControllers.Count < equipIndex)
            {
                equipIndex = 0;
            }

            GameObject gameObject = unit.GetComponent<GameObjectComponent>().GameObject;
            Animator[] animator = gameObject.GetComponentsInChildren<Animator>();
            animator[0].runtimeAnimatorController = self.animatorControllers[equipIndex];

            self.Animator = animator;
            self.animationClips.Clear();
            self.Parameter.Clear();
            foreach (AnimationClip animationClip in animator[0].runtimeAnimatorController.animationClips)
            {
                self.animationClips[animationClip.name] = animationClip;
            }

            foreach (AnimatorControllerParameter animatorControllerParameter in animator[0].parameters)
            {
                self.Parameter.Add(animatorControllerParameter.name);
            }
        }

        public static void UpdateAnimator(this AnimatorComponent self, GameObject gameObject)
        {
            Animator[] animator = gameObject.GetComponentsInChildren<Animator>();
            if (animator == null || animator.Length == 0)
            {
                return;
            }

            if (animator[0].runtimeAnimatorController == null)
            {
                return;
            }

            if (animator[0].runtimeAnimatorController.animationClips == null)
            {
                return;
            }

            List<Animator> enabledAnimators = new List<Animator>();
            foreach (Animator a in animator)
            {
                if (a.enabled)
                {
                    enabledAnimators.Add(a);
                }
            }
            Animator[] animators = enabledAnimators.ToArray();
            
            self.Animator = animators;
            self.animationClips.Clear();
            self.Parameter.Clear();

            if (animators == null || animators.Length == 0)
            {
                return;
            }

            foreach (AnimationClip animationClip in animators[0].runtimeAnimatorController.animationClips)
            {
                self.animationClips[animationClip.name] = animationClip;
            }

            foreach (AnimatorControllerParameter animatorControllerParameter in animators[0].parameters)
            {
                self.Parameter.Add(animatorControllerParameter.name);
            }
        }

        public static void Update(this AnimatorComponent self)
        {
            if (self.isStop)
            {
                return;
            }

            if (self.MotionType == MotionType.None)
            {
                return;
            }

            try
            {
                self.SetFloatValue("MotionSpeed", self.MontionSpeed);
                self.SetTrigger(self.MotionType.ToString());

                self.MontionSpeed = 1;
                self.MotionType = MotionType.None;
            }
            catch (Exception ex)
            {
                throw new Exception($"动作播放失败: {self.MotionType}", ex);
            }
        }

        public static bool HasParameter(this AnimatorComponent self, string parameter)
        {
            return self.Parameter.Contains(parameter);
        }

        public static string CurrentAnimation(this AnimatorComponent self)
        {
            AnimatorClipInfo animatorClipInfo = self.Animator[0].GetCurrentAnimatorClipInfo(0)[0];
            Log.Debug($"animatorClipInfo.clip.name： {animatorClipInfo.clip.name}");
            return animatorClipInfo.clip.name;
        }

        public static float CurrentSateTime(this AnimatorComponent self)
        {
            AnimatorStateInfo animatorStateInfo = self.Animator[0].GetCurrentAnimatorStateInfo(0);
            return animatorStateInfo.normalizedTime;
        }

        public static void Play(this AnimatorComponent self, string motionType, int skillid = 0, float motionSpeed = 1f, bool replay = false)
        {
            self.MotionType = motionType;
            self.MontionSpeed = motionSpeed;
            if (null == self.Animator || !SettingData.ShowAnimation)
            {
                return;
            }

            if (self.MissParameter.Contains(motionType))
            {
                if (self.UnitType == UnitType.Player)
                {
                    Log.Debug($"缺失动作: {motionType}  技能ID:{skillid}  强制改为动作:Skill_1");
                    motionType = "Skill_1";
                    self.MotionType = motionType;
                }
                else
                {
                    return;
                }
            }

            if (self.HasParameter(motionType.ToString()))
            {
                self.PlayAnimator(motionType, replay);
                return;
            }

            if (self.Animator == null || self.Animator.Length == 0)
            {
                return;
            }

            bool hasAction = self.Animator[0].HasState(0, Animator.StringToHash(motionType));
            if (hasAction)
            {
                self.Parameter.Add(motionType);
                self.PlayAnimator(motionType, false);
            }
            else
            {
                self.MissParameter.Add(motionType);
            }
        }

        public static void PauseAnimator(this AnimatorComponent self)
        {
            if (self.isStop)
            {
                return;
            }

            self.isStop = true;

            if (self.Animator == null)
            {
                return;
            }

            self.stopSpeed = self.Animator[0].speed;
            self.SetAnimatorSpeed(0);
        }

        public static void RunAnimator(this AnimatorComponent self)
        {
            if (!self.isStop)
            {
                return;
            }

            self.isStop = false;

            if (self.Animator == null)
            {
                return;
            }

            self.SetAnimatorSpeed(self.stopSpeed);
        }

        public static void SetBoolValue(this AnimatorComponent self, string name, bool state)
        {
            if (self.Animator == null)
            {
                return;
            }

            if (!self.HasParameter(name))
            {
                return;
            }

            for (int i = 0; i < self.Animator.Length; i++)
            {
                self.Animator[i].SetBool(name, state);
            }
        }
        
        public static void SetFloatValue(this AnimatorComponent self, string name, float state)
        {
            if (self.Animator == null)
            {
                return;
            }

            if (!self.HasParameter(name))
            {
                return;
            }

            for (int i = 0; i < self.Animator.Length; i++)
            {
                self.Animator[i].SetFloat(name, state);
            }
        }
        
        //self.Animator.SetFloat("MotionSpeed", self.MontionSpeed);
        //self.Animator.SetTrigger(self.MotionType.ToString());

        public static void PlayAnimator(this AnimatorComponent self, string animator, bool replay)
        {
            if (replay)
            {
                for (int i = 0; i < self.Animator.Length; i++)
                {
                    self.Animator[i].Play(animator,0,0 );
                }
            }
            else
            {
                for (int i = 0; i < self.Animator.Length; i++)
                {
                    self.Animator[i].Play(animator);
                }
            }
        }
        
        public static void SetIntValue(this AnimatorComponent self, string name, int value)
        {
            if (self.Animator == null)
            {
                return;
            }

            if (!self.HasParameter(name))
            {
                return;
            }

            for (int i = 0; i < self.Animator.Length; i++)
            {
                self.Animator[i].SetInteger(name, value);
            }
        }

        public static void SetTrigger(this AnimatorComponent self, string name)
        {
            if (self.Animator == null)
            {
                return;
            }

            if (!self.HasParameter(name))
            {
                return;
            }

            for (int i = 0; i < self.Animator.Length; i++)
            {
                self.Animator[i].SetTrigger(name);
            }
        }

        public static void SetAnimatorSpeed(this AnimatorComponent self, float speed)
        {
            self.stopSpeed = self.Animator[0].speed;
            for (int i = 0; i < self.Animator.Length; i++)
            {
                self.Animator[i].speed = speed;
            }
        }

        public static void ResetAnimatorSpeed(this AnimatorComponent self)
        {
            for (int i = 0; i < self.Animator.Length; i++)
            {
                self.Animator[i].speed = self.stopSpeed;
            }
        }
    }
}