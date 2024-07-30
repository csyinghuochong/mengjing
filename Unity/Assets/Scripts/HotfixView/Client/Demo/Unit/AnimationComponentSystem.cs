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

            self.Animancer = gameObject.GetComponentInChildren<AnimancerComponent>();
            
            Animator animator = gameObject.GetComponentInChildren<Animator>();
            // 暂时通过Animator获得要用到的Clip，也可以把Clip放在热更资源内，根据配置加载
            foreach (AnimationClip animationClip in animator.runtimeAnimatorController.animationClips)
            {
                ClipTransition clipTransition = new();
                clipTransition.Clip = animationClip;
                self.ClipTransitions.Add(animationClip.name, clipTransition);
            }
        }

        [EntitySystem]
        private static void Destroy(this AnimationComponent self)
        {
        }
    }
}