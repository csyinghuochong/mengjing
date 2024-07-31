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

            // Dictionary<string, AnimationClip> animationClips = new Dictionary<string, AnimationClip>();

            // // 获取Animator引用的所有动画片段，只能看到片段的名字(很多名字相同)
            // var animations = gameObject.GetComponentInChildren<Animator>().runtimeAnimatorController.animationClips;

            // // 获取Animator定义的State，名字，引用动画片段的名字，好像只能在编辑器模式下运行
            // if (gameObject.GetComponentInChildren<Animator>().runtimeAnimatorController is AnimatorController at)
            // {
            //     var stateMachine = at.layers[0].stateMachine;
            //     foreach (var animState in stateMachine.states)
            //     {
            //         if (animState.state.nameHash == gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash)
            //         {
            //             animationClips.Add(animState.state.name,);
            //         }
            //     }
            // }

            // 使用Animancer的话Animator不用添加Controller
            Animator animator = gameObject.GetComponentInChildren<Animator>();
            animator.runtimeAnimatorController = null;
        }

        [EntitySystem]
        private static void Destroy(this AnimationComponent self)
        {
        }

        public static void UpdateAnimData(this AnimationComponent self, GameObject go, int type)
        {
            self.Animancer = go.GetComponentInChildren<AnimancerComponent>();
            if (self.Animancer == null)
            {
                Log.Error("对象未添加 mono脚本 AnimancerComponent！！！");
                return;
            }

            self.ClipTransitions.Clear();

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
                { "Speak", "RoleFaShi/Girl_Act_1" },
            };

            Dictionary<string, string> monsterAnims = new()
            {
                { "More", "Monster/Lang_2_Animation" }
            };

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            Dictionary<string, string> date;
            if (type == 0)
            {
                date = roleAnims;

                foreach (KeyValuePair<string, string> keyValuePair in date)
                {
                    AnimationClip animationClip =
                            resourcesLoaderComponent.LoadAssetSync<AnimationClip>(ABPathHelper.GetAnimFbxPath(keyValuePair.Value));
                    ClipTransition clipTransition = new();
                    clipTransition.Clip = animationClip;
                    self.ClipTransitions.Add(keyValuePair.Key, clipTransition);
                }
            }
            else
            {
                date = roleAnims;

                // 有些是一个.fbx文件包含多个动画片段
                Dictionary<string, AnimationClip> animationClips =
                        resourcesLoaderComponent.LoadSubAssetsSync<AnimationClip>(ABPathHelper.GetAnimFbxPath("Monster/Lang_2_Animation"));
                foreach (KeyValuePair<string, AnimationClip> keyValuePair in animationClips)
                {
                    ClipTransition clipTransition = new();
                    clipTransition.Clip = keyValuePair.Value as AnimationClip;
                    self.ClipTransitions.Add(keyValuePair.Key, clipTransition);
                }
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