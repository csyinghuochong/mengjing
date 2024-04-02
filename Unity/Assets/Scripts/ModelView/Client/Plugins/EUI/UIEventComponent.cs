using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class UIEventComponent : Entity,IAwake,IDestroy
    {
        [StaticField]
        public static UIEventComponent Instance { get; set; }
        public readonly Dictionary<WindowID, IAUIEventHandler> UIEventHandlers = new Dictionary<WindowID, IAUIEventHandler>();
        public bool IsClicked { get; set; }
        
        public GameObject BloodPlayer { get; set; }
        public GameObject BloodMonster { get; set; }
        public GameObject BloodText { get; set; }
        
        public Camera UICamera{ get; set; }
        public Camera MainCamera{ get; set; }
    }
}