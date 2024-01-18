using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ChildOf()]
    public sealed class UI: Entity, IAwake<string, GameObject>, IDestroy
    {
        public GameObject GameObject;

        // public Action OnUpdateUI;
        //
        // public Action OnShowUI;

        public string Name { get; set; }

        public Dictionary<string, UI> nameChildren = new Dictionary<string, UI>();
    }
}