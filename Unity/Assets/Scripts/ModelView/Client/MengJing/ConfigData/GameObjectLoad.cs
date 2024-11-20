using System;
using UnityEngine;

namespace ET.Client
{

    [ChildOf(typeof(GameObjectLoadComponent))]
    public class GameObjectLoad: Entity, IAwake
    {
        public string Path { get; set; }
        public long FormId { get; set; }
        public Action<GameObject, long> LoadHandler { get; set; }
    }
}