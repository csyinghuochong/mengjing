using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIXuLieZhenComponent: Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject GameObject;
        public XuLieZhen XuLieZhen;
    }
}