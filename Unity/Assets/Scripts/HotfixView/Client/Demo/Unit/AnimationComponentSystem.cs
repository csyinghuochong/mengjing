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
            self.Animancer = null;
            self.AnimGroup = null;
            self.CurrentAnimation = null;
        }

        public static void UpdateAnimData(this AnimationComponent self, GameObject go)
        {
            self.Animancer = null;
            self.AnimGroup = null;
            self.CurrentAnimation = null;

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

            if (animData.AnimGroup.AnimInfos.Length == 0)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("{0} 没有添加动画片段！！！", animData.AnimGroup.name));
                }

                return;
            }

            self.AnimGroup = animData.AnimGroup;

            self.Play("Idle");
        }

        public static void Play(this AnimationComponent self, string name, float speed = 0)
        {
            AnimInfo animInfo = null;
            foreach (AnimInfo a in self.AnimGroup.AnimInfos)
            {
                if (a.StateName == name)
                {
                    animInfo = a;
                    break;
                }
            }

            if (animInfo == null)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("动画 {0} 未加载", name));
                }

                return;
            }

            self.CurrentAnimation = name;
            self.Animancer.Playable.Speed = speed != 0 ? speed : animInfo.Speed;

            using (zstring.Block())
            {
                Log.Debug(zstring.Format("播放动画 {0}", name));
            }

            if (!string.IsNullOrEmpty(animInfo.NextStateName))
            {
                self.Animancer.Play(animInfo.AnimationClip, 0.25f, FadeMode.FromStart).Events.OnEnd = () =>
                {
                    using (zstring.Block())
                    {
                        Log.Debug(zstring.Format("{0} 播放完毕,自动切换为 {1}", animInfo.StateName, animInfo.NextStateName));
                    }

                    self.Play(animInfo.NextStateName);
                };
            }
            else
            {
                self.Animancer.Play(animInfo.AnimationClip, 0.25f, FadeMode.FromStart);
            }
        }
    }
}