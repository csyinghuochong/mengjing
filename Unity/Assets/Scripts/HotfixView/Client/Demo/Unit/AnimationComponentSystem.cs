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

            self.InitAnimClip().Coroutine();
        }

        [EntitySystem]
        private static void Update(this AnimationComponent self)
        {
            // 测试
            if (Input.GetMouseButton(0))
            {
                Log.Warning("按下");
                self.Play("Anim_Move");
            }
            else
            {
                self.Play("Anim_Idel");
            }
        }

        [EntitySystem]
        private static void Destroy(this AnimationComponent self)
        {
        }

        public static async ETTask InitAnimClip(this AnimationComponent self)
        {
            // 测试数据
            Dictionary<string, string> roleAnims = new()
            {
                { "Anim_Move", "RoleFaShi/Girl_Run2" },
                { "Anim_Idel", "RoleFaShi/Girl_Idle2" }
            };

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            foreach (KeyValuePair<string, string> keyValuePair in roleAnims)
            {
                AnimationClip animationClip = await resourcesLoaderComponent.LoadAssetAsync<AnimationClip>(ABPathHelper.GetAnimPath(keyValuePair.Value));
                ClipTransition clipTransition = new();
                clipTransition.Clip = animationClip;
                self.ClipTransitions.Add(keyValuePair.Key, clipTransition);
            }
        }

        public static void Play(this AnimationComponent self, string name)
        {
            if (self.ClipTransitions.ContainsKey(name))
            {
                self.Animancer.Play(self.ClipTransitions[name]);
            }
        }
    }
}