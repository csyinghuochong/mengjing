using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class JiaYuanPlanEffectComponent : Entity, IAwake, IDestroy
    {
        public string PlanEffectPath;
        public GameObject PlanEffectObj;
    }
}