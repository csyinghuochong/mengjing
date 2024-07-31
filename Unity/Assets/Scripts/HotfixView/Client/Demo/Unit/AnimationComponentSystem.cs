using System;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(AnimationComponent))]
    [EntitySystemOf(typeof(AnimationComponent))]
    public static partial class AnimationComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AnimationComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this AnimationComponent self)
        {
        }

        public static void UpdateAnimData(this AnimationComponent self, GameObject go)
        {
            self.Animancer = null;
            self.ClipTransitions.Clear();
            self.CurrentAnimation = string.Empty;

            // 使用Animancer的话Animator不用添加Controller
            Animator animator = go.GetComponentInChildren<Animator>();
            animator.runtimeAnimatorController = null;

            self.Animancer = go.GetComponentInChildren<AnimancerComponent>();
            if (self.Animancer == null)
            {
                Log.Error("对象未添加 mono脚本 AnimancerComponent！！！");
                return;
            }

            AnimData animData = go.GetComponentInChildren<AnimData>();
            if (animData == null)
            {
                Log.Error("对象未添加 mono脚本 AnimData！！！");
                return;
            }

            if (animData.Animations == null || animData.Animations.Count == 0)
            {
                Log.Error("mono脚本 AnimData 没有添加动画片段！！！");
                return;
            }

            foreach (MotionTransition motionTransition in animData.Animations)
            {
                self.ClipTransitions.Add(motionTransition.StateName, motionTransition);
            }
        }

        public static void Play(this AnimationComponent self, string name, float speed = 1f)
        {
            if (self.ClipTransitions.ContainsKey(name))
            {
                self.CurrentAnimation = name;
                self.Animancer.Playable.Speed = speed;

                self.Animancer.Play(self.ClipTransitions[name]);
                using (zstring.Block())
                {
                    Log.Debug(zstring.Format("播放动画 {0}", name));
                }
            }
            else
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("动画 {0} 未加载", name));
                }
            }
        }

        public static void SetOnEnd(this AnimationComponent self, string name, Action action)
        {
            if (self.ClipTransitions.ContainsKey(name))
            {
                self.ClipTransitions[name].Events.OnEnd = action;
            }
            else
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("动画 {0} 未加载", name));
                }
            }
        }
    }
}