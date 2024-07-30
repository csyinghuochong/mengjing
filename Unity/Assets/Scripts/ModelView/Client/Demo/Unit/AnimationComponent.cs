using System.Collections.Generic;
using Animancer;

namespace ET.Client
{
    [ComponentOf]
    public class AnimationComponent : Entity, IAwake, IDestroy,IUpdate
    {
        public AnimancerComponent Animancer;
        public Dictionary<string, ClipTransition> ClipTransitions = new();
    }
}