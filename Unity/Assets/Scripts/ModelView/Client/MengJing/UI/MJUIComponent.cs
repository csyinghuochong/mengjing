using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf()]
    public class MJUIComponent: Entity, IAwake, IDestroy
    {
        public Camera UICamera;
        public Camera MainCamera;

        [StaticField]
        public static MJUIComponent Instance;

        public int ResolutionWidth;
        public int ResolutionHeight;
        public Dictionary<string, UI> UIs = new Dictionary<string, UI>();
    }
}