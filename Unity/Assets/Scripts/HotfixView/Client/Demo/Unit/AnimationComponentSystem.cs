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

            self.Animancer = gameObject.GetComponentInChildren<AnimancerComponent>();

            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            // 初始化Clip
            List<string> list = rc.GetKeysWithStart("Anim_");
            foreach (string s in list)
            {
                ClipTransition clipTransition = new();
                clipTransition.Clip = rc.Get<AnimationClip>(s);
                self.ClipTransitions.Add(s, clipTransition);
            }
        }

        [EntitySystem]
        private static void Destroy(this AnimationComponent self)
        {
        }

        public static void Play(this AnimationComponent self, string name)
        {
            self.Animancer.Play(self.ClipTransitions[name]);
        }
    }
}