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
            GameObject gameObject = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;

            // 使用Animancer的话Animator不用添加Controller
            Animator animator = gameObject.GetComponentInChildren<Animator>();
            animator.runtimeAnimatorController = null;

            self.Animancer = gameObject.GetComponentInChildren<AnimancerComponent>();
            if (self.Animancer == null)
            {
                Log.Error("对象未添加 AnimancerComponent！！！");
            }

            self.InitAnimClip();
        }

        [EntitySystem]
        private static void Destroy(this AnimationComponent self)
        {
        }

        public static void InitAnimClip(this AnimationComponent self)
        {
            // 测试数据
            Dictionary<string, string> roleAnims = new()
            {
                { "Run", "RoleFaShi/Girl_Run2" },
                { "Idle", "RoleFaShi/Girl_Idle2" },
                { "Death", "RoleZhanShi/Death" },
                { "Act_1", "RoleFaShi/Girl_Act_1" },
                { "Act_2", "RoleFaShi/Girl_Act_2" },
                { "Act_3", "RoleFaShi/Girl_Act_3" },
                { "Act_11", "RoleFaShi/Girl_Act_1" },
                { "Act_12", "RoleFaShi/Girl_Act_1" },
                { "Act_13", "RoleFaShi/Girl_Act_1" },
                { "Skill_1", "RoleFaShi/Girl_Act_3" },
                { "Skill_2", "RoleFaShi/Girl_Skill_2" },
                { "Skill_3", "RoleFaShi/Girl_Act_3" },
                { "Skill_4", "RoleFaShi/Girl_Act_1" },
                { "Skill_5", "RoleFaShi/Girl_Act_1" },
                { "Skill_6", "RoleFaShi/Girl_Act_1" },
                { "Skill_7", "RoleFaShi/Girl_Act_1" },
                { "Skill_8", "RoleFaShi/Girl_Act_1" },
                { "Skill_9", "RoleFaShi/Girl_Act_1" },
                { "Skill_10", "RoleFaShi/Girl_Act_1" },
                { "Skill_11", "RoleFaShi/Girl_Act_1" },
            };

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            foreach (KeyValuePair<string, string> keyValuePair in roleAnims)
            {
                AnimationClip animationClip = resourcesLoaderComponent.LoadAssetSync<AnimationClip>(ABPathHelper.GetAnimFbxPath(keyValuePair.Value));
                ClipTransition clipTransition = new();
                clipTransition.Clip = animationClip;
                self.ClipTransitions.Add(keyValuePair.Key, clipTransition);
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