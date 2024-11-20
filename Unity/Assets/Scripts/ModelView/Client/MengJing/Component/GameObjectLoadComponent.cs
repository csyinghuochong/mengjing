using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class GameObjectLoadComponent : Entity, IAwake, IDestroy
    {
        
        public List<EntityRef<GameObjectLoad>> WaitLoadingList = new();
        
        public List<string> LoadingList = new();
        
        public long Timer;
    }
}