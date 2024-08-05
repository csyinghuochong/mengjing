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

            // ！！！克隆一个ScriptableObject，不然直接引用的是同一个，设置OnEnd会出问题
            self.AnimGroup = UnityEngine.Object.Instantiate(animData.AnimGroup);
            foreach (MotionTransition motionTransition in self.AnimGroup.Animations)
            {
                self.ClipTransitions.Add(motionTransition.StateName, motionTransition);
            }

            if (animData.AnimGroup.name == "HeroAnimGroup")
            {
                // 动画播放完毕后还没通知下一个State则自动转到Idle
                self.SetOnEnd("Act_1", () => { Log.Debug("Act_1播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Act_2", () => { Log.Debug("Act_2播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Act_3", () => { Log.Debug("Act_3播放完毕"); self.Play("Idle"); });
                
                self.SetOnEnd("Act_11", () => { Log.Debug("Act_11播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Act_12", () => { Log.Debug("Act_12播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Act_13", () => { Log.Debug("Act_13播放完毕"); self.Play("Idle"); });
                
                self.SetOnEnd("Skill_1", () => { Log.Debug("Skill_1播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_2", () => { Log.Debug("Skill_2播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_3", () => { Log.Debug("Skill_3播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_4", () => { Log.Debug("Skill_4播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_5", () => { Log.Debug("Skill_5播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_6", () => { Log.Debug("Skill_6播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_7", () => { Log.Debug("Skill_7播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_8", () => { Log.Debug("Skill_8播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_9", () => { Log.Debug("Skill_9播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_10", () => { Log.Debug("Skill_10播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Skill_11", () => { Log.Debug("Skill_11播放完毕"); self.Play("Idle"); });
                
                self.SetOnEnd("SelectNpc", () => { Log.Debug("SelectNpc播放完毕"); self.Play("Idle"); });
                self.SetOnEnd("Speak", () => { Log.Debug("Speak播放完毕"); self.Play("Idle"); });
            }
            else if (animData.AnimGroup.name == "MonsterAnimGroup")
            {
            }
            else if (animData.AnimGroup.name == "PetAnimGroup")
            {
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