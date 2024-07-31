using System.Collections.Generic;
using Animancer;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 类似AnimationController一样，保存一个动画组，方便一键修改应用到全部使用的对象
    /// </summary>
    [CreateAssetMenu(menuName = Strings.MenuPrefix + "AnimSet", order = Strings.AssetMenuOrder + 1)]
    public class AnimGroup : ScriptableObject
    {
        public List<MotionTransition> Animations;
    }
}