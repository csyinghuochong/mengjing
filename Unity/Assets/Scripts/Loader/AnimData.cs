using System;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

namespace ET
{
    [Serializable]
    public class MotionTransition : ClipTransition
    {
        public string StateName;

        [SerializeField, Tooltip("Should Root Motion be enabled when this animation plays?")]
        private bool _ApplyRootMotion;

        public override void Apply(AnimancerState state)
        {
            base.Apply(state);
            state.Root.Component.Animator.applyRootMotion = _ApplyRootMotion;
        }
    }

    public class AnimData : MonoBehaviour
    {
        public List<MotionTransition> Animations;

        // 也许可以保存在一个ScriptableObject中
        public AnimGroup AnimGroup;
    }
}