using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf()]
    public class MJUIEventComponent: Entity, IAwake, IDestroy
    {
        [StaticField]
        public static MJUIEventComponent Instance;

        public Dictionary<string, AUIEvent> UIEvents = new Dictionary<string, AUIEvent>();

        public Dictionary<int, Transform> UILayers = new Dictionary<int, Transform>();

        public GameObject BloodPlayer;
        public GameObject BloodMonster;
        public GameObject BloodText;

        public int CurrentNpcId = 0;

        public string CurrentNpcUI = string.Empty;

        public string GuideUISet = string.Empty;

        public List<string> WaitUIList = new List<string>();

        public List<string> OpenUIList = new List<string>();
    }
}