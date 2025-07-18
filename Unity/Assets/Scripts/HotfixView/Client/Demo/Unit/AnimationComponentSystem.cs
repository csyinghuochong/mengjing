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
            self.UpdateAnimData(gameObject);
        }

        [EntitySystem]
        private static void Destroy(this AnimationComponent self)
        {
            self.Animancer.Clear();
            self.AnimGroup.Clear();
            self.CurrentAnimation = null;
        }

        public static void UpdateAnimData(this AnimationComponent self, GameObject go)
        {
            self.Animancer.Clear();
            self.AnimGroup.Clear();
            self.CurrentAnimation = null;

            // 使用Animancer的话Animator不要添加Controller
            Animator[] animators = go.GetComponentsInChildren<Animator>();
            foreach (Animator animator in animators)
            {
                if (!animator.enabled)
                {
                    continue;
                }
                
                animator.runtimeAnimatorController = null;

                AnimancerComponent animancerComponent = animator.gameObject.GetComponent<AnimancerComponent>();
                if (animancerComponent == null)
                {
                    Log.Warning($"对象未添加 mono脚本 AnimancerComponent！！！  {go.name}");
                    return;
                }

                AnimData animData = animator.gameObject.GetComponent<AnimData>();
                if (animData == null)
                {
                    Log.Warning($"对象未添加 mono脚本 AnimData！！！  {go.name}");
                    return;
                }

                if (animData.AnimGroup == null)
                {
                    Log.Warning("mono脚本 AnimData 没有添加AnimGroup！！！");
                    return;
                }

                if (animData.AnimGroup.AnimInfos.Length == 0)
                {
                    using (zstring.Block())
                    {
                        Log.Warning(zstring.Format("{0} 没有添加动画片段！！！", animData.AnimGroup.name));
                    }

                    return;
                }

                self.Animancer.Add(animancerComponent);
                self.AnimGroup.Add(animData.AnimGroup);
            }

            self.Play("Idle");
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="fadeMode">
        /// FadeMode.FixedDuration 一般用于等待、行走等循环动画 或 播放期间不会重新播放。此模式下，若想重复一个动作，而该动作仍在运行时，不会有变化。
        /// FadeMode.FromStart 一般用于攻击动画。当想要重复一个动作，而该动作仍在运行时使用。如平A动画未结束又重新平A。
        /// </param>
        /// <param name="speed"></param>
        public static void Play(this AnimationComponent self, string name, FadeMode fadeMode = FadeMode.FixedDuration, float speed = 0)
        {
            for (int i = 0; i < self.Animancer.Count; i++)
            {
                AnimInfo animInfo = null;
                foreach (AnimInfo a in self.AnimGroup[i].AnimInfos)
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
                        Log.Debug(zstring.Format("动画 {0} 未加载", name));
                    }

                    continue;
                }

                if (animInfo.AnimationClip == null)
                {
                    using (zstring.Block())
                    {
                        Log.Debug(zstring.Format("动画片段 {0} 未加载", name));
                    }

                    continue;
                }

                self.CurrentAnimation = name;
                self.Animancer[i].Playable.Speed = speed != 0 ? speed : animInfo.Speed;

                using (zstring.Block())
                {
                    Log.Debug(zstring.Format("播放动画 {0}", name));
                }

                if (!string.IsNullOrEmpty(animInfo.NextStateName))
                {
                    self.Animancer[i].Play(animInfo.AnimationClip, 0.25f, fadeMode).Events.OnEnd = () =>
                    {
                        using (zstring.Block())
                        {
                            Log.Debug(zstring.Format("{0} 播放完毕，自动切换为 {1}", animInfo.StateName, animInfo.NextStateName));
                        }

                        self.Play(animInfo.NextStateName);
                    };
                }
                else
                {
                    self.Animancer[i].Play(animInfo.AnimationClip, 0.25f, fadeMode);
                }
            }
        }
    }
}
