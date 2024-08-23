using System;
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
            if (self.AnimGroup != null)
            {
                UnityEngine.Object.DestroyImmediate(self.AnimGroup);
            }

            self.ClipTransitions.Clear();
        }

        public static void UpdateAnimData(this AnimationComponent self, GameObject go)
        {
            self.Animancer = null;
            self.AnimGroup = null;
            self.ClipTransitions.Clear();
            self.CurrentAnimation = string.Empty;

            // 使用Animancer的话Animator不要添加Controller
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

            if (animData.AnimGroup == null)
            {
                Log.Error("mono脚本 AnimData 没有添加AnimGroup！！！");
                return;
            }

            if (animData.AnimGroup.Animations.Length == 0)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("{0} 没有添加动画片段！！！", animData.AnimGroup.name));
                }

                return;
            }

            // ！！！复制一个ScriptableObject，不然直接引用的是同一个，设置OnEnd会出问题
            if (self.AnimGroup != null)
            {
                UnityEngine.Object.DestroyImmediate(self.AnimGroup);
            }

            self.AnimGroup = UnityEngine.Object.Instantiate(animData.AnimGroup);
            foreach (MotionTransition motionTransition in self.AnimGroup.Animations)
            {
                self.ClipTransitions.Add(motionTransition.StateName, motionTransition);
                self.SetAutoTransition(motionTransition);
            }
        }

        private static void SetAutoTransition(this AnimationComponent self, MotionTransition motionTransition)
        {
            if (string.IsNullOrEmpty(motionTransition.NextStateName))
            {
                return;
            }

            motionTransition.Events.OnEnd = () =>
            {
                using (zstring.Block())
                {
                    Log.Debug(zstring.Format("{0} 播放完毕,自动切换为 {1}", motionTransition.StateName, motionTransition.NextStateName));
                }

                self.Play(motionTransition.NextStateName);
            };
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