using System;
using System.Collections.Generic;

namespace ET.Client
{
    public class BuffDispatcherComponentC: Singleton<BuffDispatcherComponentC>, ISingletonAwake
    {
        private readonly Dictionary<string, BuffHandlerC> aiHandlers = new();
        
        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof (BuffHandlerCAttribute));
            foreach (Type type in types)
            {
                BuffHandlerC aaiHandler = Activator.CreateInstance(type) as BuffHandlerC;
                if (aaiHandler == null)
                {
                    Log.Error($"robot ai is not AAIHandler: {type.Name}");
                    continue;
                }
                this.aiHandlers.Add(type.Name, aaiHandler);
            }
        }

        public BuffHandlerC Get(string key)
        {
            this.aiHandlers.TryGetValue(key, out var aaiHandler);
            return aaiHandler;
        }
    
    }
    
}