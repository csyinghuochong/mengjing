using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    public class UIXuLieZhenComponent: Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject GameObject;
        public XuLieZhen XuLieZhen;
    }
}