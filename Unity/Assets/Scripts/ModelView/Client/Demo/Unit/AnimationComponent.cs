using System.Collections.Generic;
using Animancer;

namespace ET.Client
{
    [ComponentOf]
    public class AnimationComponent : Entity, IAwake, IDestroy
    {
        public List<AnimancerComponent> Animancer = new();
        public List<AnimGroup> AnimGroup = new();
        public string CurrentAnimation { get; set; }
    }
}