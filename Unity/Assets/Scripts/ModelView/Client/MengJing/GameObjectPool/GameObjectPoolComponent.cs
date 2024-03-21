using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ChildOf(typeof (GameObjectPoolComponent))]
    public class GameObjectLoad: Entity, IAwake
    {
        public string Path;
        public long FormId;
        public Action<GameObject, long> LoadHandler;
    }

    [ComponentOf(typeof (Scene))]
    public class GameObjectPoolComponent: Entity, IAwake, IDestroy
    {
        [StaticField]
        public static GameObjectPoolComponent Instance;

        public List<GameObjectLoad> LoadingList = new List<GameObjectLoad>();

        public Dictionary<string, List<GameObject>> ExternalReferences = new Dictionary<string, List<GameObject>>();

        public long Timer;
    }
}