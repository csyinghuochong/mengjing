using System.Collections.Generic;
using System;

namespace ET
{
    
    [Code]
    public class BehaviourDispatcherComponent : Singleton<BehaviourDispatcherComponent>, ISingletonAwake
    {
        public Dictionary<string, BehaviourHandler> AIHandlers = new Dictionary<string, BehaviourHandler>();
        
        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof (BehaviourHandlerAttribute));
            foreach (Type type in types)
            {
                BehaviourHandler aaiHandler = Activator.CreateInstance(type) as BehaviourHandler;
                if (aaiHandler == null)
                {
                    Log.Error($"robot ai is not AAIHandler: {type.Name}");
                    continue;
                }
                this.AIHandlers.Add(type.Name, aaiHandler);
            }
        }

        public BehaviourHandler Get(string key)
        {
            this.AIHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    }
}
